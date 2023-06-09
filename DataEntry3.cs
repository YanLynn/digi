﻿using System;
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

    public partial class DataEntry3 : Form
    {
        DigitalImageEntities _entity = new DigitalImageEntities();
        string fPath = System.Configuration.ConfigurationSettings.AppSettings["fPath"];
        string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;

        

        //ImageList _imageList = new ImageList();
        fileInfo _currentFileInfo = null;
        List<uenType> uenTypes = null;

        public DataEntry3()
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
           uenTypes = _entity.uenTypes.ToList();
            foreach(uenType uenType in uenTypes)
            {
                uenTypeComboBox.Items.Add(uenType.uenName);
            }
        }


        private void imageListView1_DragDrop(object sender, DragEventArgs e)
        {
            updateImageList();
        }

        private void updateImageList()
        {
            string _imageNames = "";
            foreach (ImageListViewItem item in imageListView1.Items)
            {
                _imageNames += item.Text + ",";
            }
            _currentFileInfo = _entity.fileInfoes.Where(x => x.id == _currentFileInfo.id).FirstOrDefault();
            _currentFileInfo.imageList = _imageNames;
            _entity.SaveChanges();

        }

        void Application_Idle(object sender, EventArgs e)
        {
            rotateLeftButton.Enabled = imageListView1.SelectedItems.Count > 0;
            rotateRightButton.Enabled = imageListView1.SelectedItems.Count > 0;
            deleteImageButton.Enabled = imageListView1.SelectedItems.Count > 0;
            switchViewButton.Enabled = imageListView1.SelectedItems.Count > 0;

            panel1.Enabled = _currentFileInfo != null;

        }

            private void getItem()
        {
            _currentFileInfo = _entity.fileInfoes.Where(x => x.status == 0).FirstOrDefault();
            if (_currentFileInfo != null)
            {
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

            }
            else
            {
                resetForm();
                MessageBox.Show("No more file info for Data Entry.");
            }

        }

        private void getItem(object sender, EventArgs e)
        {
            getItem();
        }

        private void deleteImage(object sender, EventArgs e)
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
        }

        private void rotateRight(object sender, EventArgs e)
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
        }

        private void rotateLeft(object sender, EventArgs e)
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
        }

        

        private void submit(object sender, EventArgs e)
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
                resetForm();
                SetLoading(false, "");
                getItem();
            }

        }

        private void generatePDF()
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

        private void SetLoading(bool displayLoader, String message)
        {
            if (displayLoader)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    loadingLabel.Text = message;
                    loadingLabel.Visible = true;
                    this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                });
            }
            else
            {
                this.Invoke((MethodInvoker)delegate
                {
                    loadingLabel.Visible = false;
                    this.Cursor = System.Windows.Forms.Cursors.Default;
                });
            }
        }


        private void updateFileInfo()
        {
            
            _currentFileInfo = _entity.fileInfoes.Where(x => x.id == _currentFileInfo.id).FirstOrDefault();
            _currentFileInfo.uenType = uenTypes[uenTypeComboBox.SelectedIndex];
            _currentFileInfo.maker = userName;
            _currentFileInfo.status = 1;
            _currentFileInfo.uenValue = uenTextBox.Text;
            _entity.SaveChanges();
        }

        private void resetForm()
        {
            this.imageListView1.Items.Clear();
            this.uenTypeComboBox.SelectedIndex = -1;
            this.uenTextBox.Clear();
            this.runNumTextBox.Clear();

        }

        private void updateRejectStatus()
        {

            _currentFileInfo = _entity.fileInfoes.Where(x => x.id == _currentFileInfo.id).FirstOrDefault();
            _currentFileInfo.maker = userName;
            _currentFileInfo.status = 3;
            _entity.SaveChanges();
        }

        private void rejectFileInfo(object sender, EventArgs e)
        {
            if (MessageBox.Show("Reject File Info. Are you sure you want to continue?",
                "Digital Imaging", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                updateRejectStatus();
                resetForm();
                getItem();
            }
        }

        private void switchView(object sender, EventArgs e)
        {
            if(imageListView1.View == Manina.Windows.Forms.View.Gallery)
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
        }

        private void uenTextBoxValidating(object sender, CancelEventArgs e)
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
        }

        private void uenTypeValidating(object sender, CancelEventArgs e)
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
        }
    }
}
