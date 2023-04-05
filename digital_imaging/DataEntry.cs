using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using digital_imaging.Models;
using Manina.Windows.Forms;
using System.Diagnostics;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using digital_imaging.Properties;


namespace digital_imaging
{

    public partial class DataEntry : Form
    {
        DigitalImageEntities _entity = new DigitalImageEntities();
        string fPath = System.Configuration.ConfigurationSettings.AppSettings["fPath"];
        string userName = Environment.UserName;

        int makerOrChecker = 0; // 0 for maker, 1 for checker;

        

        //ImageList _imageList = new ImageList();
        fileInfo _currentFileInfo = null;
        List<uenType> uenTypes = null;

        public DataEntry()
        {
            InitializeComponent();

            Application.Idle += new EventHandler(Application_Idle);

           
            if (Settings.Default.ImageMode == 0)
            {
                imageListView1.View = Manina.Windows.Forms.View.Gallery;
            }
            else
            {
                imageListView1.PaneWidth = 500;
                imageListView1.View = Manina.Windows.Forms.View.Pane;
            }
            imageListView1.DragDrop += imageListView1_DragDrop;

            setUpUENType();

            
        }


        private void setUpUENType()
        {
            try
            {
                uenTypes = _entity.uenTypes.ToList();
                foreach (uenType uenType in uenTypes)
                {
                    uenTypeComboBox.Items.Add(uenType.uenName);
                }
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void imageListView1_DragDrop(object sender, DragEventArgs e)
        {
            updateImageList();
        }

        private void updateImageList()
        {
            try
            {
                string _imageNames = "";
                foreach (ImageListViewItem item in imageListView1.Items)
                {
                    _imageNames += item.Text + ",";
                }
                _currentFileInfo = _entity.fileInfoes.Where(x => x.id == _currentFileInfo.id).FirstOrDefault();
                _currentFileInfo.imageList = _imageNames;
                _entity.SaveChanges();
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        void Application_Idle(object sender, EventArgs e)
        {
            try
            {
                rotateLeftButton.Enabled = imageListView1.SelectedItems.Count > 0;
                rotateRightButton.Enabled = imageListView1.SelectedItems.Count > 0;
                deleteImageButton.Enabled = imageListView1.SelectedItems.Count > 0;
                switchViewButton.Enabled = imageListView1.SelectedItems.Count > 0;

                tableLayoutPanel2.Enabled = _currentFileInfo != null;
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

            private void getItem()
        {
            try
            {
                _currentFileInfo = _entity.fileInfoes.Where(x => x.status == 0 || (x.status == 1 && x.maker != null && x.maker != userName)).FirstOrDefault();
                
                if (_currentFileInfo != null)
                {

                    if (_currentFileInfo.status == 1)
                    {
                        if (!isNullorEmpty(_currentFileInfo.maker))
                        {
                            if (_currentFileInfo.maker != userName)
                            {
                                // checker scenario
                                makerOrChecker = 1;
                                string message = string.Format("User - {0} - started DataEntry as - Checker",userName);
                                logAuditTrailNoWait(message);
                            }
                            else
                            {
                                _currentFileInfo = _entity.fileInfoes.Where(x => x.status == 0
                                                                    || (x.status == 1
                                                                    && x.maker != userName)).FirstOrDefault();
                            }
                        }
                        else
                        {
                            // maker scenario
                            makerOrChecker = 0;
                            string message = string.Format("User - {0} - started DataEntry as - Maker", userName);
                            logAuditTrailNoWait(message);
                        }
                    }
                    else
                    {
                        // maker scenario
                        makerOrChecker = 0;
                        string message = string.Format("User - {0} - started DataEntry as - Maker", userName);
                        logAuditTrailNoWait(message);
                    }


                    this.Text = String.Format("Data Entry - {0}", _currentFileInfo.fileUniqueID);
                    runNumTextBox.Text = _currentFileInfo.rumNum;
                    List<string> images = _currentFileInfo.imageList.Split(',').ToList();

                    foreach (string img in images)
                    {
                        if (System.IO.File.Exists(fPath + _currentFileInfo.fileUniqueID + "\\" + img))
                        {
                            // _imageList.Images.Add(img, Image.FromFile(fPath + _currentFileInfo.fileUniqueID + "\\" + img));

                            imageListView1.Items.Add(fPath + _currentFileInfo.fileUniqueID + "\\" + img);
                        }
                    }
                    if(makerOrChecker == 1)
                    {
                        int index = 0;
                        foreach(uenType tmp in uenTypes)
                        {
                            if(tmp.id == _currentFileInfo.uenType.id)
                            {
                                break;
                            }

                            index++;
                        }

                        uenTypeComboBox.SelectedIndex = index;
                        uenTextBox.Text = _currentFileInfo.uenValue;
                    }
                    

                }
                else
                {
                    resetForm();
                    MessageBox.Show("No more file info for Data Entry.");
                }
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void getItem(object sender, EventArgs e)
        {
            getItem();
        }

        private void deleteImage(object sender, EventArgs e)
        {

            try
            {
                if (MessageBox.Show("Remove images from list. Are you sure you want to continue?",
                "Digital Imaging", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    imageListView1.SuspendLayout();

                    foreach (var item in imageListView1.SelectedItems)
                        imageListView1.Items.Remove(item);

                    imageListView1.ResumeLayout(true);

                    updateImageList();
                }
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void rotateRight(object sender, EventArgs e)
        {
            try
            {
                foreach (ImageListViewItem item in imageListView1.SelectedItems)
                {
                    item.BeginEdit();
                    using (Image img = Image.FromFile(item.FileName))
                    {
                        img.RotateFlip(RotateFlipType.Rotate90FlipNone);
                        img.Save(item.FileName);
                    }
                    item.Update();
                    item.EndEdit();
                }
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void rotateLeft(object sender, EventArgs e)
        {
            try
            {
                foreach (ImageListViewItem item in imageListView1.SelectedItems)
                {
                    item.BeginEdit();
                    using (Image img = Image.FromFile(item.FileName))
                    {
                        img.RotateFlip(RotateFlipType.Rotate270FlipNone);
                        img.Save(item.FileName);
                    }
                    item.Update();
                    item.EndEdit();
                }
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        

        private void submit(object sender, EventArgs e)
        {

            try
            {
                foreach (Control control in this.Controls)
                {
                    // Set focus on control
                    control.Focus();
                    // Validate causes the control's Validating event to be fired,
                    // if CausesValidation is True
                    if (!Validate())
                    {
                        DialogResult = DialogResult.None;
                        MessageBox.Show("Validation Failed", "Please check your input!");
                        return;
                    }
                }

                if (_currentFileInfo != null)
                {
                    SetLoading(true, "Generating PDF and saving...");
                    generatePDF();
                    updateFileInfo();

                    string mkrckr = makerOrChecker == 0 ? "Maker" : "Checker";
                    string message = string.Format("User - {0} - {1} - Submitted Vals - type:{2} - val:{3}",
                                                    userName, mkrckr, uenTypeComboBox.Text, uenTextBox.Text);

                    logAuditTrailNoWait(message);


                    resetForm();
                    SetLoading(false, "");
                    getItem();
                }

            }catch  (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void generatePDF()
        {

            try
            {
                PdfDocument outPdf = new PdfDocument();

                PdfDocument doc = new PdfDocument();
                var tmpint = 0;

                foreach (ImageListViewItem item in imageListView1.Items)
                {
                    doc.Pages.Add(new PdfPage());
                    XGraphics xgr = XGraphics.FromPdfPage(doc.Pages[tmpint]);
                    tmpint++;
                    XImage img = XImage.FromFile(item.FileName);
                    xgr.DrawImage(img, 0, 0);
                }

                String fileName = _currentFileInfo.fileUniqueID + ".PDF";

                doc.Save(fPath + _currentFileInfo.fileUniqueID + "\\" + fileName);
                doc.Close();
            }
            catch
            (Exception ex){
                MessageBox.Show(ex.Message);
            }
        }

        private void SetLoading(bool displayLoader, String message)
        {
            try
            {
                if (displayLoader)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        loadingLabel.Text = message;
                        imageListView1.Visible = false;
                        loadingLabel.Visible = true;
                        this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                    });
                }
                else
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        imageListView1.Visible = true;
                        loadingLabel.Visible = false;
                        this.Cursor = System.Windows.Forms.Cursors.Default;
                    });
                }
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void updateFileInfo()
        {

            try
            {
                

                _currentFileInfo = _entity.fileInfoes.Where(x => x.id == _currentFileInfo.id).FirstOrDefault();
                _currentFileInfo.uenType = uenTypes[uenTypeComboBox.SelectedIndex];
                if(makerOrChecker == 0)
                {
                    _currentFileInfo.maker = userName;
                    _currentFileInfo.status = 1;
                }
                else
                {
                    _currentFileInfo.checker = userName;
                    _currentFileInfo.status = 2;
                }
                
                _currentFileInfo.uenValue = uenTextBox.Text;
                _entity.SaveChanges();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void resetForm()
        {
            try
            {
                this.imageListView1.Items.Clear();
                this.uenTypeComboBox.SelectedIndex = -1;
                this.uenTextBox.Clear();
                this.runNumTextBox.Clear();
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void updateRejectStatus()
        {

            try
            {
                _currentFileInfo = _entity.fileInfoes.Where(x => x.id == _currentFileInfo.id).FirstOrDefault();
                _currentFileInfo.maker = userName;
                _currentFileInfo.status = 3;
                _entity.SaveChanges();
            }catch (Exception ex){ MessageBox.Show(ex.Message); }
        }

        private void rejectFileInfo(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Reject File Info. Are you sure you want to continue?",
                "Digital Imaging", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    updateRejectStatus();

                    string mkrckr = makerOrChecker == 0 ? "Maker" : "Checker";
                    string message = string.Format("User - {0} - {1} - Rejected fileInfo:{2}",
                                                    userName, mkrckr, _currentFileInfo.fileUniqueID);
                    logAuditTrailNoWait(message);

                    resetForm();
                    getItem();
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void switchView(object sender, EventArgs e)
        {
            try
            {
                if (imageListView1.View == Manina.Windows.Forms.View.Gallery)
                {
                    imageListView1.PaneWidth = 500;
                    imageListView1.View = Manina.Windows.Forms.View.Pane;
                    Settings.Default.ImageMode = 1;
                }
                else
                {
                    imageListView1.View = Manina.Windows.Forms.View.Gallery;
                    Settings.Default.ImageMode = 0;
                }

                Settings.Default.Save();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void uenTextBoxValidating(object sender, CancelEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(uenTextBox.Text))
                {
                    e.Cancel = true;
                    errorProvider1.SetError(uenTextBox, "UEN should not be left blank!");
                }
                else
                {
                    errorProvider1.SetError(uenTextBox, null);
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool isNullorEmpty(string str)
        {
            if (str == null || str.Length == 0) return true;

            return false;
        }

        private void uenTypeValidating(object sender, CancelEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(uenTypeComboBox.Text))
                {
                    e.Cancel = true;
                    errorProvider1.SetError(uenTypeComboBox, "UEN Type should not be left blank!");
                }
                else
                {
                    errorProvider1.SetError(uenTypeComboBox, null);
                }
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        

        private void logAuditTrailNoWait(string message)
        {
            try
            {
                user_auditTrail user_AuditTrail = new user_auditTrail();
                user_AuditTrail.fileInfoID = _currentFileInfo.id;
                user_AuditTrail.message = message;
                user_AuditTrail.machine_name = System.Windows.Forms.SystemInformation.ComputerName;
                user_AuditTrail.username = userName;
                user_AuditTrail.date = DateTime.Now;
                _entity.user_auditTrail.Add(user_AuditTrail);
                _entity.SaveChanges();

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }
    }
}
