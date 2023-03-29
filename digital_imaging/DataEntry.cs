
using digital_imaging.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ListView = System.Windows.Forms.ListView;

namespace digital_imaging
{
    public partial class DataEntry : Form
    {
        DigitalImageEntities db = new DigitalImageEntities();
        ColumnHeader columnheader;
        private ListViewColumnSorter lvwColumnSorter;
        string fPath = System.Configuration.ConfigurationSettings.AppSettings["fPath"];

        public DataEntry()
        {
            InitializeComponent();
           


            dEnList.View = View.Details;

            columnheader = new ColumnHeader();
            columnheader.Text = "Name";
            dEnList.Columns.Add(columnheader);

            columnheader = new ColumnHeader();
            columnheader.Text = "Path";
            dEnList.Columns.Add(columnheader);

            columnheader = new ColumnHeader();
            columnheader.Text = "Date Modified";
            dEnList.Columns.Add(columnheader);

            columnheader = new ColumnHeader();
            columnheader.Text = "Size";
            dEnList.Columns.Add(columnheader);

            columnheader = new ColumnHeader();
            columnheader.Text = "Type";
            dEnList.Columns.Add(columnheader);

            dEnList.FullRowSelect = true;
            dEnList.GridLines = true;

            dEnList.AllowColumnReorder = true;
            dEnList.Sorting = SortOrder.Ascending;
            foreach (ColumnHeader ch in this.dEnList.Columns)
            {
                ch.Width = 150;

            }

        }

        private void DataEntry_Load(object sender, EventArgs e)
        {
            getFileInfo();


        }



        public void getFileInfo()
        {
            
            try
            {
                lvwColumnSorter = new ListViewColumnSorter();
                dEnList.ListViewItemSorter = lvwColumnSorter;

                this.dEnList.Items.Clear();
                List<Array> fileName = new List<Array>();
                fileName.Add(db.fileInfoes.Where(x => x.status == 0 & (x.maker == null || x.maker == "")).Select(x => x.fileUniqueID).ToArray());
                DirectoryInfo directoryInfo = new DirectoryInfo(fPath);
                if (fileName != null)
                {
                    if (directoryInfo.Exists)
                    {
                        foreach (DirectoryInfo subdir in directoryInfo.GetDirectories())
                        {
                            foreach (string file in fileName[0])
                            {
                                if (subdir.Name == file)
                                {
                                    DirectoryInfo getFolder = new DirectoryInfo(fPath + file);
                                    if (getFolder.Exists)
                                    {

                                        foreach (FileInfo imgs in getFolder.GetFiles())
                                        {
                                            if (imgs.Extension == ".png" || imgs.Extension == ".jpeg" || imgs.Extension == ".tiff" || imgs.Extension == ".jpg")
                                            {
                                                string[] sizes = { "B", "KB", "MB", "GB", "TB" };
                                                double len = imgs.Length;
                                                int order = 0;
                                                while (len >= 1024 && order < sizes.Length - 1)
                                                {
                                                    order++;
                                                    len = len / 1024;
                                                }

                                                string result = String.Format("{0:0.##} {1}", len, sizes[order]);
                                                ListViewItem listViewItem1 = new ListViewItem(new string[] { imgs.Name, imgs.FullName, imgs.LastWriteTime.ToString(), result, imgs.Extension }, -1, Color.Empty, Color.Empty, new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, ((System.Byte)(0))));

                                                dEnList.Items.AddRange(new ListViewItem[] { listViewItem1 });
                                                dEnList.Tag = fPath + file;

                                            }
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("file not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                    break;
                                }
                                else if (subdir.Name != file)
                                {
                                    continue;
                                }
                            }
                            if (dEnList.Items.Count > 0)
                            {
                                break;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Directory not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Not found entry file!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        //show image
        private void dEnList_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (this != null && dEnList.SelectedItems.Count > 0)
            {
                ListViewItem lvi = dEnList.SelectedItems[0];
                string imagekeyname = dEnList.Tag + "\\" + lvi.Text;

                if (this.pictureBox1.Image != null)
                {
                    this.pictureBox1.Image.Dispose();
                    this.pictureBox1.InitialImage = null;
                    this.pictureBox1.Image = null;
                }

                this.pictureBox1.Load(imagekeyname);

            }

        }



        //srot order by column
        private void dEnList_ColumnClick(object sender, ColumnClickEventArgs e)
        {

            if (e.Column == lvwColumnSorter.SortColumn)
            {
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            this.dEnList.Sort();
        }
    }
}
