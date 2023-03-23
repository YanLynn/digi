using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Permissions;
using System.Runtime.InteropServices;
using System.Diagnostics.CodeAnalysis;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.IO;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using ZXing;
using digital_imaging.Images;
using TWAINWorkingGroup;


namespace digital_imaging
{
    public partial class MainForm : Form, IMessageFilter
    {
        string fPath = System.Configuration.ConfigurationSettings.AppSettings["fPath"];
        string rPath = System.Configuration.ConfigurationSettings.AppSettings["rPath"];
        private ScannedImageList imageList = new ScannedImageList();

        public MainForm()
        {

            InitializeComponent();


            // Open the log in our working folder, and say hi...
            TWAINWorkingGroup.Log.Open("TWAINCSScan", ".", 1);
            TWAINWorkingGroup.Log.Info("TWAINCSScan v" + System.Reflection.Assembly.GetEntryAssembly().GetName().Version.ToString());

            // Init other stuff...
            m_blIndicators = true;
            m_blExit = false;
            m_iUseBitmap = 0;
            this.FormClosing += new FormClosingEventHandler(MainForm_FormClosing);

            // Create our image capture object...
            try
            {
                // Init stuff...
                TWAIN.DeviceEventCallback deviceeventcallback = DeviceEventCallback;
                TWAIN.ScanCallback scancallback = ScanCallbackTrigger;
                TWAIN.RunInUiThreadDelegate runinuithreaddelegate = RunInUiThread;

                // Instantiate TWAIN, and register ourselves...
                m_twain = new TWAIN
                (
                    "TWAIN Working Group",
                    "TWAIN Open Source",
                    "TWAIN CS Scan App",
                    (ushort)TWAIN.TWON_PROTOCOL.MAJOR,
                    (ushort)TWAIN.TWON_PROTOCOL.MINOR,
                    ((uint)TWAIN.DG.APP2 | (uint)TWAIN.DG.CONTROL | (uint)TWAIN.DG.IMAGE),
                    TWAIN.TWCY.USA,
                    "TWAIN CS Scan App",
                    TWAIN.TWLG.ENGLISH_USA,
                    2,
                    4,
                    false,
                    false,
                    deviceeventcallback,
                    scancallback,
                    runinuithreaddelegate,
                    this.Handle
                );
            }
            catch (Exception exception)
            {
                TWAINWorkingGroup.Log.Error("exception - " + exception.Message);
                m_twain = null;
                m_blExit = true;
                MessageBox.Show
                (
                    "Unable to start, the most likely reason is that the TWAIN\n" +
                    "Data Source Manager is not installed on your system.\n\n" +
                    "An internet search for 'TWAIN DSM' will locate it and once\n" +
                    "installed, you should be able to proceed.\n\n" +
                    "You can also try the following link:\n" +
                    "http://sourceforge.net/projects/twain-dsm/",
                    "Error Starting TWAIN CS Scan"
                );
                return;
            }

            // Init our picture box...
            //InitImage();

            // Prep for TWAIN events...
            SetMessageFilter(true);

            // Init our buttons...
            SetButtons(EBUTTONSTATE.CLOSED);


        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Make sure this thing is off...
            SetMessageFilter(false);

            // Get rid of the TWAIN object...
            if (m_twain != null)
            {
                m_twain.Dispose();
                m_twain = null;
            }

            // This will prevent ReportImage from doing anything as we close...
            m_graphics1 = null;

            // Bye-bye logging...
            TWAINWorkingGroup.Log.Close();
        }



        public delegate void ScanCallbackEvent();
        private void ScanCallbackEventHandler(object sender, EventArgs e)
        {
            ScanCallback((m_twain == null) ? true : (m_twain.GetState() <= TWAIN.STATE.S3));
        }

       
        public void Rollback(TWAIN.STATE a_state)
        {
            TWAIN.TW_PENDINGXFERS twpendingxfers = default(TWAIN.TW_PENDINGXFERS);
            TWAIN.TW_USERINTERFACE twuserinterface = default(TWAIN.TW_USERINTERFACE);
            TWAIN.TW_IDENTITY twidentity = default(TWAIN.TW_IDENTITY);

            // Make sure we have something to work with...
            if (m_twain == null)
            {
                return;
            }

            // Walk the states, we don't care about the status returns.  Basically,
            // these need to work, or we're guaranteed to hang...

            // 7 --> 6
            if ((m_twain.GetState() == TWAIN.STATE.S7) && (a_state < TWAIN.STATE.S7))
            {
                m_twain.DatPendingxfers(TWAIN.DG.CONTROL, TWAIN.MSG.ENDXFER, ref twpendingxfers);
            }

            // 6 --> 5
            if ((m_twain.GetState() == TWAIN.STATE.S6) && (a_state < TWAIN.STATE.S6))
            {
                m_twain.DatPendingxfers(TWAIN.DG.CONTROL, TWAIN.MSG.RESET, ref twpendingxfers);
            }

            // 5 --> 4
            if ((m_twain.GetState() == TWAIN.STATE.S5) && (a_state < TWAIN.STATE.S5))
            {
                m_twain.DatUserinterface(TWAIN.DG.CONTROL, TWAIN.MSG.DISABLEDS, ref twuserinterface);
            }

            // 4 --> 3
            if ((m_twain.GetState() == TWAIN.STATE.S4) && (a_state < TWAIN.STATE.S4))
            {
                TWAIN.CsvToIdentity(ref twidentity, m_twain.GetDsIdentity());
                m_twain.DatIdentity(TWAIN.DG.CONTROL, TWAIN.MSG.CLOSEDS, ref twidentity);
            }

            // 3 --> 2
            if ((m_twain.GetState() == TWAIN.STATE.S3) && (a_state < TWAIN.STATE.S3))
            {
                m_twain.DatParent(TWAIN.DG.CONTROL, TWAIN.MSG.CLOSEDSM, ref m_intptrHwnd);
            }
        }

       
        [SecurityPermissionAttribute(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        public bool PreFilterMessage(ref Message a_message)
        {
            if (m_twain != null)
            {
                return (m_twain.PreFilterMessage(a_message.HWnd, a_message.Msg, a_message.WParam, a_message.LParam));
            }
            return (true);
        }

    
        private void RunInUiThread(Action a_action)
        {
            RunInUiThread(this, a_action);
        }

       
        static public void RunInUiThread(Object a_object, Action a_action)
        {
            Control control = (Control)a_object;
            if (control.InvokeRequired)
            {
                control.Invoke(new MainForm.RunInUiThreadDelegate(RunInUiThread), new object[] { a_object, a_action });
                return;
            }
            a_action();
        }

     
        public void SetMessageFilter(bool a_blAdd)
        {
            if (a_blAdd)
            {
                Application.AddMessageFilter(this);
            }
            else
            {
                Application.RemoveMessageFilter(this);
            }
        }

    
        [PermissionSet(SecurityAction.LinkDemand, Name = "FullTrust", Unrestricted = false)]
        public TWAIN.STS RestoreSnapshot(string a_szFile)
        {
            TWAIN.STS sts;
            byte[] abSettings;
            UInt32 u32Length;
            IntPtr intptrHandle;
            string szCustomdsdata;
            string szStatus;
            CSV csv = new CSV();
            TWAIN.TW_CAPABILITY twcapability;
            TWAIN.TW_CUSTOMDSDATA twcustomdsdata;

            // Reset the driver, we don't care if it succeeds or fails...
            szStatus = "";
            twcapability = default(TWAIN.TW_CAPABILITY);
            m_twain.CsvToCapability(ref twcapability, ref szStatus, "0,0,0");
            m_twain.DatCapability(TWAIN.DG.CONTROL, TWAIN.MSG.RESETALL, ref twcapability);

            // Get the snapshot from a file...
            FileStream filestream = null;
            try
            {
                filestream = new FileStream(a_szFile, FileMode.Open);
                u32Length = (UInt32)filestream.Length;
                abSettings = new byte[u32Length];
                filestream.Read(abSettings, 0, abSettings.Length);
            }
            finally
            {
                if (filestream != null)
                {
                    filestream.Dispose();
                }
            }

            // Put it in an intptr...
            intptrHandle = Marshal.AllocHGlobal((int)u32Length);
            Marshal.Copy(abSettings, 0, intptrHandle, (int)u32Length);

            // Set the snapshot, if possible...
            csv.Add(u32Length.ToString());
            csv.Add(intptrHandle.ToString());
            szCustomdsdata = csv.Get();
            twcustomdsdata = default(TWAIN.TW_CUSTOMDSDATA);
            m_twain.CsvToCustomdsdata(ref twcustomdsdata, szCustomdsdata);
            sts = m_twain.DatCustomdsdata(TWAIN.DG.CONTROL, TWAIN.MSG.SET, ref twcustomdsdata);

            // Cleanup...
            Marshal.FreeHGlobal(intptrHandle);

            // All done...
            return (sts);
        }

     
        [PermissionSet(SecurityAction.LinkDemand, Name = "FullTrust", Unrestricted = false)]
        public TWAIN.STS SaveSnapshot(string a_szFile)
        {
            TWAIN.STS sts;
            TWAIN.TW_CUSTOMDSDATA twcustomdsdata;

            // Test...
            if ((a_szFile == null) || (a_szFile == ""))
            {
                return (TWAIN.STS.SUCCESS);
            }

            // Get a snapshot, if possible...
            twcustomdsdata = default(TWAIN.TW_CUSTOMDSDATA);
            sts = m_twain.DatCustomdsdata(TWAIN.DG.CONTROL, TWAIN.MSG.GET, ref twcustomdsdata);
            if (sts != TWAIN.STS.SUCCESS)
            {
                TWAINWorkingGroup.Log.Error("DAT_CUSTOMDSDATA failed...");
                return (sts);
            }

            // Save the data to a file...
            FileStream filestream = null;
            try
            {
                IntPtr intptrInfo;
                filestream = new FileStream(a_szFile, FileMode.Create);
                byte[] abSettings = new byte[twcustomdsdata.InfoLength];
                intptrInfo = m_twain.DsmMemLock(twcustomdsdata.hData);
                Marshal.Copy(intptrInfo, abSettings, 0, (int)twcustomdsdata.InfoLength);
                m_twain.DsmMemUnlock(twcustomdsdata.hData);
                filestream.Write(abSettings, 0, abSettings.Length);
            }
            finally
            {
                if (filestream != null)
                {
                    filestream.Dispose();
                }
            }

            // Free the memory...
            m_twain.DsmMemFree(ref twcustomdsdata.hData);

            // All done...
            return (TWAIN.STS.SUCCESS);
        }

        
        private TWAIN.STS DeviceEventCallback()
        {
            TWAIN.STS sts;
            TWAIN.TW_DEVICEEVENT twdeviceevent;

            // Drain the event queue...
            while (true)
            {
                // Try to get an event...
                twdeviceevent = default(TWAIN.TW_DEVICEEVENT);
                sts = m_twain.DatDeviceevent(TWAIN.DG.CONTROL, TWAIN.MSG.GET, ref twdeviceevent);
                if (sts != TWAIN.STS.SUCCESS)
                {
                    break;
                }
            }

            // Return a status, in case we ever need it for anything...
            return (TWAIN.STS.SUCCESS);
        }

   
        private TWAIN.STS ScanCallbackTrigger(bool a_blClosing)
        {
            BeginInvoke(new MethodInvoker(delegate { ScanCallbackEventHandler(this, new EventArgs()); }));
            return (TWAIN.STS.SUCCESS);
        }
        private TWAIN.STS ScanCallback(bool a_blClosing)
        {
            TWAIN.STS sts;

            // Scoot...
            if (m_twain == null)
            {
                return (TWAIN.STS.FAILURE);
            }

            // We're superfluous...
            if (m_twain.GetState() <= TWAIN.STATE.S4)
            {
                return (TWAIN.STS.SUCCESS);
            }

            // We're leaving...
            if (a_blClosing)
            {
                return (TWAIN.STS.SUCCESS);
            }

            // Do this in the right thread, we'll usually be in the
            // right spot, save maybe on the first call...
            if (this.InvokeRequired)
            {
                return
                (
                    (TWAIN.STS)Invoke
                    (
                        (Func<TWAIN.STS>)delegate
                        {
                            return (ScanCallback(a_blClosing));
                        }
                    )
                );
            }

            // Handle DAT_NULL/MSG_XFERREADY...
            if (m_twain.IsMsgXferReady() && !m_blXferReadySent)
            {
                m_blXferReadySent = true;

                // Get the amount of memory needed...
                m_twsetupmemxfer = default(TWAIN.TW_SETUPMEMXFER);
                sts = m_twain.DatSetupmemxfer(TWAIN.DG.CONTROL, TWAIN.MSG.GET, ref m_twsetupmemxfer);
                if ((sts != TWAIN.STS.SUCCESS) || (m_twsetupmemxfer.Preferred == 0))
                {
                    m_blXferReadySent = false;
                    if (!m_blDisableDsSent)
                    {
                        m_blDisableDsSent = true;
                        Rollback(TWAIN.STATE.S4);
                    }
                }

                // Allocate the transfer memory (with a little extra to protect ourselves)...
                m_intptrXfer = Marshal.AllocHGlobal((int)m_twsetupmemxfer.Preferred + 65536);
                if (m_intptrXfer == IntPtr.Zero)
                {
                    m_blDisableDsSent = true;
                    Rollback(TWAIN.STATE.S4);
                }
            }

            // Handle DAT_NULL/MSG_CLOSEDSREQ...
            if (m_twain.IsMsgCloseDsReq() && !m_blDisableDsSent)
            {
                m_blDisableDsSent = true;
                Rollback(TWAIN.STATE.S4);
                SetButtons(EBUTTONSTATE.OPEN);
            }

            // Handle DAT_NULL/MSG_CLOSEDSOK...
            if (m_twain.IsMsgCloseDsOk() && !m_blDisableDsSent)
            {
                m_blDisableDsSent = true;
                Rollback(TWAIN.STATE.S4);
                SetButtons(EBUTTONSTATE.OPEN);
            }

            // This is where the state machine transfers and optionally
            // saves the images to disk (it also displays them).  It'll go back
            // and forth between states 6 and 7 until an error occurs, or until
            // we run out of images...
            if (m_blXferReadySent && !m_blDisableDsSent)
            {
                CaptureImages();
            }

            // Trigger the next event, this is where things all chain together.
            // We need begininvoke to prevent blockking, so that we don't get
            // backed up into a messy kind of recursion.  We need DoEvents,
            // because if things really start moving fast it's really hard for
            // application events, like button clicks to break through...
            Application.DoEvents();
            BeginInvoke(new MethodInvoker(delegate { ScanCallbackEventHandler(this, new EventArgs()); }));

            // All done...
            return (TWAIN.STS.SUCCESS);
        }

   
        private void SetButtons(EBUTTONSTATE a_ebuttonstate)
        {
            switch (a_ebuttonstate)
            {
                default:
                case EBUTTONSTATE.CLOSED:
                    tsScan.Enabled = false;
                    tsSavePDF.Enabled = false;
                    tsSaveImage.Enabled = false;
                    tsDelete.Enabled = false;
                    dEntry.Enabled = true;
                    tsDenq.Enabled = false;
                    tsAbout.Enabled = false;
                    break;

                case EBUTTONSTATE.OPEN:
                    tsScan.Enabled = true;
                    tsSavePDF.Enabled = true;
                    tsSaveImage.Enabled = true;
                    tsDelete.Enabled = true;
                    dEntry.Enabled = true;
                    tsDenq.Enabled = true;
                    tsAbout.Enabled = true;
                    break;

                case EBUTTONSTATE.SCANNING:
                    tsScan.Enabled = false;
                    tsSavePDF.Enabled = false;
                    tsSaveImage.Enabled = false;
                    tsDelete.Enabled = false;
                    dEntry.Enabled = false;
                    tsDenq.Enabled = false;
                    tsAbout.Enabled = true;
                    break;
            }
        }

       
        private void CaptureImages()
        {
            TWAIN.STS sts;
            TWAIN.TW_IMAGEINFO twimageinfo = default(TWAIN.TW_IMAGEINFO);
            TWAIN.TW_IMAGEMEMXFER twimagememxfer = default(TWAIN.TW_IMAGEMEMXFER);
            TWAIN.TW_PENDINGXFERS twpendingxfers = default(TWAIN.TW_PENDINGXFERS);
            TWAIN.TW_USERINTERFACE twuserinterface = default(TWAIN.TW_USERINTERFACE);

            // Dispatch on the state...
            switch (m_twain.GetState())
            {
                // Not a good state, just scoot...
                default:
                    return;

                // We're on our way out...
                case TWAIN.STATE.S5:
                    m_blDisableDsSent = true;
                    m_twain.DatUserinterface(TWAIN.DG.CONTROL, TWAIN.MSG.DISABLEDS, ref twuserinterface);
                    SetButtons(EBUTTONSTATE.OPEN);
                    return;

                // Memory transfers...
                case TWAIN.STATE.S6:
                case TWAIN.STATE.S7:
                    TWAIN.CsvToImagememxfer(ref twimagememxfer, "0,0,0,0,0,0,0," + ((int)TWAIN.TWMF.APPOWNS | (int)TWAIN.TWMF.POINTER) + "," + m_twsetupmemxfer.Preferred + "," + m_intptrXfer);
                    sts = m_twain.DatImagememxfer(TWAIN.DG.IMAGE, TWAIN.MSG.GET, ref twimagememxfer);
                    break;
            }

            // Handle problems...
            if ((sts != TWAIN.STS.SUCCESS) && (sts != TWAIN.STS.XFERDONE))
            {
                m_blDisableDsSent = true;
                Rollback(TWAIN.STATE.S4);
                SetButtons(EBUTTONSTATE.OPEN);
                return;
            }

            // Allocate or grow the image memory...
            if (m_intptrImage == IntPtr.Zero)
            {
                m_intptrImage = Marshal.AllocHGlobal((int)twimagememxfer.BytesWritten);
            }
            else
            {
                m_intptrImage = Marshal.ReAllocHGlobal(m_intptrImage, (IntPtr)(m_iImageBytes + twimagememxfer.BytesWritten));
            }

            // Ruh-roh...
            if (m_intptrImage == IntPtr.Zero)
            {
                m_blDisableDsSent = true;
                Rollback(TWAIN.STATE.S4);
                SetButtons(EBUTTONSTATE.OPEN);
                return;
            }

            // Copy into the buffer, and bump up our byte tally...
            TWAIN.MemCpy(m_intptrImage + m_iImageBytes, m_intptrXfer, (int)twimagememxfer.BytesWritten);
            m_iImageBytes += (int)twimagememxfer.BytesWritten;

            // If we saw XFERDONE we can save the image, display it,
            // end the transfer, and see if we have more images...
            if (sts == TWAIN.STS.XFERDONE)
            {
                // Bump up our image counter, this always grows for the
                // life of the entire session...
                m_iImageCount += 1;

                // Get the image info...
                sts = m_twain.DatImageinfo(TWAIN.DG.IMAGE, TWAIN.MSG.GET, ref twimageinfo);

                // Add the appropriate header...

                // Bitonal uncompressed...
                if (((TWAIN.TWPT)twimageinfo.PixelType == TWAIN.TWPT.BW) && ((TWAIN.TWCP)twimageinfo.Compression == TWAIN.TWCP.NONE))
                {
                    TWAIN.TiffBitonalUncompressed tiffbitonaluncompressed;
                    tiffbitonaluncompressed = new TWAIN.TiffBitonalUncompressed((uint)twimageinfo.ImageWidth, (uint)twimageinfo.ImageLength, (uint)twimageinfo.XResolution.Whole, (uint)m_iImageBytes);
                    m_intptrImage = Marshal.ReAllocHGlobal(m_intptrImage, (IntPtr)(Marshal.SizeOf(tiffbitonaluncompressed) + m_iImageBytes));
                    TWAIN.MemMove((IntPtr)((UInt64)m_intptrImage + (UInt64)Marshal.SizeOf(tiffbitonaluncompressed)), m_intptrImage, m_iImageBytes);
                    Marshal.StructureToPtr(tiffbitonaluncompressed, m_intptrImage, true);
                    m_iImageBytes += (int)Marshal.SizeOf(tiffbitonaluncompressed);
                }

                // Bitonal GROUP4...
                else if (((TWAIN.TWPT)twimageinfo.PixelType == TWAIN.TWPT.BW) && ((TWAIN.TWCP)twimageinfo.Compression == TWAIN.TWCP.GROUP4))
                {
                    TWAIN.TiffBitonalG4 tiffbitonalg4;
                    tiffbitonalg4 = new TWAIN.TiffBitonalG4((uint)twimageinfo.ImageWidth, (uint)twimageinfo.ImageLength, (uint)twimageinfo.XResolution.Whole, (uint)m_iImageBytes);
                    m_intptrImage = Marshal.ReAllocHGlobal(m_intptrImage, (IntPtr)(Marshal.SizeOf(tiffbitonalg4) + m_iImageBytes));
                    TWAIN.MemMove((IntPtr)((UInt64)m_intptrImage + (UInt64)Marshal.SizeOf(tiffbitonalg4)), m_intptrImage, m_iImageBytes);
                    Marshal.StructureToPtr(tiffbitonalg4, m_intptrImage, true);
                    m_iImageBytes += (int)Marshal.SizeOf(tiffbitonalg4);
                }

                // Gray uncompressed...
                else if (((TWAIN.TWPT)twimageinfo.PixelType == TWAIN.TWPT.GRAY) && ((TWAIN.TWCP)twimageinfo.Compression == TWAIN.TWCP.NONE))
                {
                    TWAIN.TiffGrayscaleUncompressed tiffgrayscaleuncompressed;
                    tiffgrayscaleuncompressed = new TWAIN.TiffGrayscaleUncompressed((uint)twimageinfo.ImageWidth, (uint)twimageinfo.ImageLength, (uint)twimageinfo.XResolution.Whole, (uint)m_iImageBytes);
                    m_intptrImage = Marshal.ReAllocHGlobal(m_intptrImage, (IntPtr)(Marshal.SizeOf(tiffgrayscaleuncompressed) + m_iImageBytes));
                    TWAIN.MemMove((IntPtr)((UInt64)m_intptrImage + (UInt64)Marshal.SizeOf(tiffgrayscaleuncompressed)), m_intptrImage, m_iImageBytes);
                    Marshal.StructureToPtr(tiffgrayscaleuncompressed, m_intptrImage, true);
                    m_iImageBytes += (int)Marshal.SizeOf(tiffgrayscaleuncompressed);
                }

                // Gray JPEG...
                else if (((TWAIN.TWPT)twimageinfo.PixelType == TWAIN.TWPT.GRAY) && ((TWAIN.TWCP)twimageinfo.Compression == TWAIN.TWCP.JPEG))
                {
                    // No work to be done, we'll output JPEG...
                }

                // RGB uncompressed...
                else if (((TWAIN.TWPT)twimageinfo.PixelType == TWAIN.TWPT.RGB) && ((TWAIN.TWCP)twimageinfo.Compression == TWAIN.TWCP.NONE))
                {
                    TWAIN.TiffColorUncompressed tiffcoloruncompressed;
                    tiffcoloruncompressed = new TWAIN.TiffColorUncompressed((uint)twimageinfo.ImageWidth, (uint)twimageinfo.ImageLength, (uint)twimageinfo.XResolution.Whole, (uint)m_iImageBytes);
                    m_intptrImage = Marshal.ReAllocHGlobal(m_intptrImage, (IntPtr)(Marshal.SizeOf(tiffcoloruncompressed) + m_iImageBytes));
                    TWAIN.MemMove((IntPtr)((UInt64)m_intptrImage + (UInt64)Marshal.SizeOf(tiffcoloruncompressed)), m_intptrImage, m_iImageBytes);
                    Marshal.StructureToPtr(tiffcoloruncompressed, m_intptrImage, true);
                    m_iImageBytes += (int)Marshal.SizeOf(tiffcoloruncompressed);
                }

                // RGB JPEG...
                else if (((TWAIN.TWPT)twimageinfo.PixelType == TWAIN.TWPT.RGB) && ((TWAIN.TWCP)twimageinfo.Compression == TWAIN.TWCP.JPEG))
                {
                    // No work to be done, we'll output JPEG...
                }

                // Oh well...
                else
                {
                    TWAINWorkingGroup.Log.Error("unsupported format <" + twimageinfo.PixelType + "," + twimageinfo.Compression + ">");
                    m_blDisableDsSent = true;
                    Rollback(TWAIN.STATE.S4);
                    SetButtons(EBUTTONSTATE.OPEN);
                    return;
                }

                // Save the image to disk, if we're doing that...
                if (!string.IsNullOrEmpty(m_formsetup.GetImageFolder()))
                {
                    // Create the directory, if needed...
                    if (!Directory.Exists(m_formsetup.GetImageFolder()))
                    {
                        try
                        {
                            Directory.CreateDirectory(m_formsetup.GetImageFolder());
                        }
                        catch (Exception exception)
                        {
                            TWAINWorkingGroup.Log.Error("CreateDirectory failed - " + exception.Message);
                        }
                    }

                    // Write it out...
                    string szFilename = Path.Combine(m_formsetup.GetImageFolder(), "img" + string.Format("{0:D6}", m_iImageCount));
                    
                    TWAIN.WriteImageFile(szFilename, m_intptrImage, m_iImageBytes, out szFilename);
                }

                // Turn the image into a byte array, and free the original memory...
                byte[] abImage = new byte[m_iImageBytes];
                Marshal.Copy(m_intptrImage, abImage, 0, m_iImageBytes);
                Marshal.FreeHGlobal(m_intptrImage);
                m_intptrImage = IntPtr.Zero;
                m_iImageBytes = 0;

                // Turn the byte array into a stream...
                MemoryStream memorystream = new MemoryStream(abImage);
                Bitmap bitmap = (Bitmap)Image.FromStream(memorystream);

                BarcodeReader reader = new BarcodeReader();
                var result = reader.Decode(bitmap);
                if (result != null)
                {
                    pathName = fPath + result.ToString();
                    Directory.CreateDirectory(pathName);
                }
                else
                {
                    SaveImage(bitmap, pathName);
                }

                

                /*
                // Display the image...
                if (m_iUseBitmap == 0)
                {
                    m_iUseBitmap = 1;
                    /LoadImage(ref m_pictureboxImage1, ref m_graphics1, ref m_bitmapGraphic1, bitmap);
                }
                else
                {
                    m_iUseBitmap = 0;
                    //LoadImage(ref m_pictureboxImage2, ref m_graphics2, ref m_bitmapGraphic2, bitmap);
                }
                */

                // Cleanup...
                bitmap.Dispose();
                memorystream = null; // disposed by the bitmap
                abImage = null;

                // End the transfer...
                m_twain.DatPendingxfers(TWAIN.DG.CONTROL, TWAIN.MSG.ENDXFER, ref twpendingxfers);

                // Looks like we're done!
                if (twpendingxfers.Count == 0)
                {
                    m_blDisableDsSent = true;
                    m_twain.DatUserinterface(TWAIN.DG.CONTROL, TWAIN.MSG.DISABLEDS, ref twuserinterface);
                    SetButtons(EBUTTONSTATE.OPEN);
                    treeView1.Refresh();
                    return;
                }
                
            }
        }

      
        [SuppressMessage("Microsoft.Security", "CA2123:OverrideLinkDemandsShouldBeIdenticalToBase")]
        [SecurityPermissionAttribute(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                if (m_twain != null)
                {
                    m_twain.Dispose();
                    m_twain = null;
                }
                if (m_bitmapGraphic1 != null)
                {
                    m_bitmapGraphic1.Dispose();
                    m_bitmapGraphic1 = null;
                }
                if (m_bitmapGraphic2 != null)
                {
                    m_bitmapGraphic2.Dispose();
                    m_bitmapGraphic2 = null;
                }
                if (m_brushBackground != null)
                {
                    m_brushBackground.Dispose();
                    m_brushBackground = null;
                }
                components.Dispose();
            }
            base.Dispose(disposing);
        }

     
        public bool ExitRequested()
        {
            return (m_blExit);
        }

        public void ClearEvents()
        {
            m_blXferReadySent = false;
            m_blDisableDsSent = false;
        }




        private void MainForm_Load(object sender, EventArgs e)
        {
            treeLoad();
            this.imageList1.ImageSize = new Size(32, 32);
        }

        static ImageList _imageList;
        public static ImageList ImageList
        {
            get
            {
                if (_imageList == null)
                {
                    _imageList = new ImageList();
                   
                    _imageList.Images.Add("Application", Properties.Resources.folder_icon_1320191242863903371);
                }
                return _imageList;
            }
        }

        private void BuildTree(DirectoryInfo directoryInfo, TreeNodeCollection addInMe)
        {
            TreeNode curNode = addInMe.Add(directoryInfo.Name);
            foreach (FileInfo file in directoryInfo.GetFiles())
            {
                curNode.Nodes.Add(file.FullName, file.Name);
            }
            foreach (DirectoryInfo subdir in directoryInfo.GetDirectories())
            {
                BuildTree(subdir, curNode.Nodes);
            }
        }

        private void treeLoad()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(fPath);
            if (directoryInfo.Exists)
            {
                treeView1.AfterSelect += treeView1_AfterSelect_1;
                BuildTree(directoryInfo, treeView1.Nodes);
                treeView1.ImageList = MainForm.ImageList;
            }
            
        }
     

        //image list 

        private void treeView1_AfterSelect_1(System.Object sender, System.Windows.Forms.TreeViewEventArgs e)
        {

            //this.listView1.Items.Clear();
            this.imageList1.Images.Clear();
            imageList = new ScannedImageList();
            UpdateThumbnails();
            if (e.Node.Nodes.Count != 0)
            {
               
                for (int i = 0; i < e.Node.Nodes.Count; i++)
                {
                    ListViewItem lvi = new ListViewItem();
                    string imagePath = e.Node.Nodes[i].Name;
                    if (imagePath.EndsWith(".jpeg")|| imagePath.EndsWith(".jpg") || imagePath.EndsWith(".png") || imagePath.EndsWith(".tiff"))
                    {
                        if (System.IO.File.Exists(imagePath))
                        {

                            imageList.Images.Add(Image.FromFile(imagePath));

                        }
                    }
                }
                if (e.Node.Name.EndsWith("png") || e.Node.Name.EndsWith("tiff") || e.Node.Name.EndsWith("jpg")|| e.Node.Name.EndsWith("jpeg"))
                {
                    //this.richTextBox1.Clear();
                    StreamReader reader = new StreamReader(e.Node.Name);
                    //this.richTextBox1.Text = reader.ReadToEnd();
                    reader.Close();
                }

                UpdateThumbnails();
            }

        }

     

        private void tsScan_ButtonClick(object sender, EventArgs e)
        {
            m_iUseBitmap = 0;
            string szTwmemref;
            TWAIN.STS sts;

            // Silently start scanning if we detect that customdsdata is supported,
            // otherwise bring up the driver GUI so the user can change settings...
            if (m_formsetup.IsCustomDsDataSupported())
            {
                szTwmemref = "FALSE,FALSE," + this.Handle;
            }
            else
            {
                szTwmemref = "TRUE,FALSE," + this.Handle;
            }

            // Send the command...
            ClearEvents();
            TWAIN.TW_USERINTERFACE twuserinterface = default(TWAIN.TW_USERINTERFACE);
            m_twain.CsvToUserinterface(ref twuserinterface, szTwmemref);
            sts = m_twain.DatUserinterface(TWAIN.DG.CONTROL, TWAIN.MSG.ENABLEDS, ref twuserinterface);
            if (sts == TWAIN.STS.SUCCESS)
            {
                SetButtons(EBUTTONSTATE.SCANNING);
            }
        }


        private void scannerItem_Click(object sender, EventArgs e)
        {
            string szIdentity;
            string szDefault = "";
            string szStatus;
            List<string> lszIdentity = new List<string>();
            FormSelect formselect;
            DialogResult dialogresult;
            TWAIN.STS sts;
            TWAIN.TW_CAPABILITY twcapability;
            TWAIN.TW_IDENTITY twidentity = default(TWAIN.TW_IDENTITY);

            // Get the default driver...
            m_intptrHwnd = this.Handle;
            sts = m_twain.DatParent(TWAIN.DG.CONTROL, TWAIN.MSG.OPENDSM, ref m_intptrHwnd);
            if (sts != TWAIN.STS.SUCCESS)
            {
                MessageBox.Show("OPENDSM failed...");
                return;
            }

            // Get the default driver...
            sts = m_twain.DatIdentity(TWAIN.DG.CONTROL, TWAIN.MSG.GETDEFAULT, ref twidentity);
            if (sts == TWAIN.STS.SUCCESS)
            {
                szDefault = TWAIN.IdentityToCsv(twidentity);
            }

            // Enumerate the drivers...
            for (sts = m_twain.DatIdentity(TWAIN.DG.CONTROL, TWAIN.MSG.GETFIRST, ref twidentity);
                 sts != TWAIN.STS.ENDOFLIST;
                 sts = m_twain.DatIdentity(TWAIN.DG.CONTROL, TWAIN.MSG.GETNEXT, ref twidentity))
            {
                lszIdentity.Add(TWAIN.IdentityToCsv(twidentity));
            }

            // Ruh-roh...
            if (lszIdentity.Count == 0)
            {
                MessageBox.Show("There are no TWAIN drivers installed on this system...");
                return;
            }

            // Instantiate our form...
            formselect = new FormSelect(lszIdentity, szDefault);
            formselect.StartPosition = FormStartPosition.CenterParent;
            dialogresult = formselect.ShowDialog(this);
            if (dialogresult != System.Windows.Forms.DialogResult.OK)
            {
                m_blExit = true;
                return;
            }

            // Get all the identities...
            szIdentity = formselect.GetSelectedDriver();
            if (szIdentity == null)
            {
                m_blExit = true;
                return;
            }

            // Get the selected identity...
            m_blExit = true;
            foreach (string sz in lszIdentity)
            {
                if (sz.Contains(szIdentity))
                {
                    m_blExit = false;
                    szIdentity = sz;
                    break;
                }
            }
            if (m_blExit)
            {
                return;
            }

            // Make it the default, we don't care if this succeeds...
            twidentity = default(TWAIN.TW_IDENTITY);
            TWAIN.CsvToIdentity(ref twidentity, szIdentity);
            m_twain.DatIdentity(TWAIN.DG.CONTROL, TWAIN.MSG.SET, ref twidentity);

            // Open it...
            sts = m_twain.DatIdentity(TWAIN.DG.CONTROL, TWAIN.MSG.OPENDS, ref twidentity);
            if (sts != TWAIN.STS.SUCCESS)
            {
                MessageBox.Show("Unable to open scanner (it is turned on and plugged in?)");
                m_blExit = true;
                return;
            }

            // Update the main form title...
            this.Text = "Digital Imaging (" + twidentity.ProductName.Get() + ")";

            // Strip off unsafe chars.  Sadly, mono let's us down here...
            m_szProductDirectory = CSV.Parse(szIdentity)[11];
            foreach (char c in new char[41]
                            { '\x00', '\x01', '\x02', '\x03', '\x04', '\x05', '\x06', '\x07',
                              '\x08', '\x09', '\x0A', '\x0B', '\x0C', '\x0D', '\x0E', '\x0F', '\x10', '\x11', '\x12',
                              '\x13', '\x14', '\x15', '\x16', '\x17', '\x18', '\x19', '\x1A', '\x1B', '\x1C', '\x1D',
                              '\x1E', '\x1F', '\x22', '\x3C', '\x3E', '\x7C', ':', '*', '?', '\\', '/'
                            }
                    )
            {
                m_szProductDirectory = m_szProductDirectory.Replace(c, '_');
            }

            // We're doing memory transfers...
            szStatus = "";
            twcapability = default(TWAIN.TW_CAPABILITY);
            m_twain.CsvToCapability(ref twcapability, ref szStatus, "ICAP_XFERMECH,TWON_ONEVALUE,TWTY_UINT16,TWSX_MEMORY");
            sts = m_twain.DatCapability(TWAIN.DG.CONTROL, TWAIN.MSG.SET, ref twcapability);
            if (sts != TWAIN.STS.SUCCESS)
            {
                m_blExit = true;
                return;
            }

            // Decide whether or not to show the driver's window messages...
            szStatus = "";
            twcapability = default(TWAIN.TW_CAPABILITY);
            m_twain.CsvToCapability(ref twcapability, ref szStatus, "CAP_INDICATORS,TWON_ONEVALUE,TWTY_BOOL," + (m_blIndicators ? "TRUE" : "FALSE"));
            sts = m_twain.DatCapability(TWAIN.DG.CONTROL, TWAIN.MSG.SET, ref twcapability);
            if (sts != TWAIN.STS.SUCCESS)
            {
                m_blExit = true;
                return;
            }

            // New state...
            SetButtons(EBUTTONSTATE.OPEN);

            // Create the setup form...
            m_formsetup = new FormSetup(this, ref m_twain, m_szProductDirectory);
        }

        private void SaveImage(Bitmap bitmap, string pathName)
        {
            
                string fName = String.Format("scan-{0}.jpeg", new Random().Next().ToString());
                bitmap.Save(pathName+ "\\" + fName, ImageFormat.Jpeg);

            
            
        }


        private void generatePDF()
        {
            String fodLocation = fPath;
            PdfDocument outPdf = new PdfDocument();

            List<string> dirs = Directory.GetDirectories(fodLocation, "*", SearchOption.TopDirectoryOnly).ToList<string>();

            foreach (string dir in dirs)
            {

                List<string> images = Directory.GetFiles(dir, "*", SearchOption.AllDirectories).ToList();

                PdfDocument doc = new PdfDocument();


                var tmpint = 0;

                foreach (string image in images)
                {
                    doc.Pages.Add(new PdfPage());
                    XGraphics xgr = XGraphics.FromPdfPage(doc.Pages[tmpint]);
                    tmpint++;
                    XImage img = XImage.FromFile(image);
                    xgr.DrawImage(img, 0, 0);
                }

                String fodName = Path.GetFileName(dir);

                doc.Save(dir + "\\" + fodName + ".PDF");
                doc.Close();
            }
            treeView1.Refresh();

        }

        private void LoadImage(ref PictureBox a_picturebox, ref Graphics a_graphics, ref Bitmap a_bitmapGraphic, Bitmap a_bitmap)
        {
            // We want to maintain the aspect ratio...
            double fRatioWidth = (double)a_bitmapGraphic.Size.Width / (double)a_bitmap.Width;
            double fRatioHeight = (double)a_bitmapGraphic.Size.Height / (double)a_bitmap.Height;
            double fRatio = (fRatioWidth < fRatioHeight) ? fRatioWidth : fRatioHeight;
            int iWidth = (int)(a_bitmap.Width * fRatio);
            int iHeight = (int)(a_bitmap.Height * fRatio);

            // Display the image...
            a_graphics.FillRectangle(m_brushBackground, m_rectangleBackground);
            a_graphics.DrawImage(a_bitmap, new Rectangle(((int)a_bitmapGraphic.Width - iWidth) / 2, ((int)a_bitmapGraphic.Height - iHeight) / 2, iWidth, iHeight));
            a_picturebox.Image = a_bitmapGraphic;
            a_picturebox.Update();
        }

        /// <summary>
        /// Our button states...
        /// </summary>
        private enum EBUTTONSTATE
        {
            CLOSED,
            OPEN,
            SCANNING
        }



        //////////////////////////////////////////////////////////////////////////////
        // Private Attributes...
        ///////////////////////////////////////////////////////////////////////////////
        #region Private Attributes...

        private bool m_blExit;

        private TWAIN m_twain;
        private IntPtr m_intptrHwnd;
        private bool m_blDisableDsSent = false;
        private bool m_blXferReadySent = false;
        private IntPtr m_intptrXfer = IntPtr.Zero;
        private IntPtr m_intptrImage = IntPtr.Zero;
        private int m_iImageBytes = 0;
        private TWAIN.TW_SETUPMEMXFER m_twsetupmemxfer;

        // Setup information...
        private FormSetup m_formsetup;

        private string m_szProductDirectory;

        private bool m_blIndicators;

        private Bitmap m_bitmapGraphic1;
        private Bitmap m_bitmapGraphic2;
        private Graphics m_graphics1;
        private Graphics m_graphics2;
        private Brush m_brushBackground;
        private Rectangle m_rectangleBackground;
        private int m_iUseBitmap;
        private int m_iImageCount = 0;
        private string pathName = System.Configuration.ConfigurationSettings.AppSettings["fPath"];

     
        public delegate void RunInUiThreadDelegate(Object a_object, Action a_action);

        #endregion

        private void tsSavePDF_Click(object sender, EventArgs e)
        {
            generatePDF();
        }


        private IEnumerable<int> SelectedIndices
        {
            get
            {
                return thumbnailList1.SelectedIndices.OfType<int>();
            }
            set
            {
                thumbnailList1.SelectedIndices.Clear();
                foreach (int i in value)
                {
                    thumbnailList1.SelectedIndices.Add(i);
                }
            }
        }

        private void UpdateThumbnails()
        {
            // TODO: Make incremental updates (i.e. appends) faster if there are many images
            thumbnailList1.UpdateImages(imageList.Images);
        }

        private void UpdateThumbnails(IEnumerable<int> selection)
        {
            UpdateThumbnails();
            SelectedIndices = selection;
        }

        private void Clear()
        {
            if (imageList.Images.Count > 0)
            {
                if (MessageBox.Show(string.Format("Confirm", imageList.Images.Count), "Clear", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    imageList.Delete(Enumerable.Range(0, imageList.Images.Count));
                    UpdateThumbnails();
                }
            }
        }

        private void Delete()
        {
            if (SelectedIndices.Any())
            {
                if (MessageBox.Show(string.Format("Delete?", SelectedIndices.Count()), "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    imageList.Delete(SelectedIndices);
                    UpdateThumbnails();
                }
            }
        }

        private void SelectAll()
        {
            UpdateThumbnails(Enumerable.Range(0, imageList.Images.Count));
        }

        private void MoveDown()
        {
            UpdateThumbnails(imageList.MoveDown(SelectedIndices));
        }

        private void MoveUp()
        {
            UpdateThumbnails(imageList.MoveUp(SelectedIndices));
        }

        private void RotateLeft()
        {
            UpdateThumbnails(imageList.RotateFlip(SelectedIndices, RotateFlipType.Rotate270FlipNone));
        }

        private void RotateRight()
        {
            UpdateThumbnails(imageList.RotateFlip(SelectedIndices, RotateFlipType.Rotate90FlipNone));
        }

        private void Flip()
        {
            UpdateThumbnails(imageList.RotateFlip(SelectedIndices, RotateFlipType.RotateNoneFlipXY));
        }

        private void thumbnailList1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Delete:
                    Delete();
                    break;
                case Keys.Left:
                    if (e.Control)
                    {
                        MoveUp();
                    }
                    break;
                case Keys.Right:
                    if (e.Control)
                    {
                        MoveDown();
                    }
                    break;
                case Keys.A:
                    if (e.Control)
                    {
                        SelectAll();
                    }
                    break;
            }
        }

        private void thumbnailList1_ItemActivate(object sender, EventArgs e)
        {
            /*if (SelectedIndices.Any())
            {
                using (var image = imageList.Images[SelectedIndices.First()].GetImage())
                {
                    var viewer = FormFactory.Create<FViewer>();
                    viewer.Image = image;
                    viewer.ShowDialog();
                }
            }*/
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            MoveUp();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            MoveDown();
        }

        private void tsDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void dEntry_Click(object sender, EventArgs e)
        {
            DataEntry dEn = new DataEntry();
            if (!dEn.Visible)
            {
                dEn.ShowDialog();
            }
            else
            {
                dEn.BringToFront();
            }
        }
    }
}
