
using digital_imaging.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace digital_imaging
{
    public partial class DataEntry : Form
    {
        DigitalImageEntities db = new DigitalImageEntities();
        
        string fPath = System.Configuration.ConfigurationSettings.AppSettings["fPath"];

        public DataEntry()
        {
            InitializeComponent();
        }

        private void DataEntry_Load(object sender, EventArgs e)
        {
            getFileInfo();
        }
        public void getFileInfo()
        {
            // DirectoryInfo directoryInfo = new DirectoryInfo(fPath);
            // List<string> fileName = new List<string>; int a = 0;
            //foreach (DirectoryInfo subdir in directoryInfo.GetDirectories())
            //{


            //    fileName.Add(db.file_info.Where(x => x.run_num == subdir.Name).Select(x => x.run_num).ToString());

            //    a++;

            //}

            //var getFile = from fl in db.file_info where 
            //dataGridView1.AutoGenerateColumns = true;
            // dataGridView1.DataSource = db.file_info.ToList();

            fileInfo fileInfo = new fileInfo();
            fileInfo.fileUniqueID = Guid.NewGuid().ToString();
            fileInfo.imageList = "imagelist1,imagelist2,imagelist3";
            fileInfo.pro_date = DateTime.Now;
            fileInfo.rumNum = "file-name";
            fileInfo.fileType_id = 1;
            fileInfo.uenType_id = 1;
            fileInfo.uenValue = "test";
            fileInfo.docType_id = 1;
            fileInfo.status = 0;
            fileInfo.maker = "Maker";
            fileInfo.chacker = "";
            fileInfo.genPDF = Guid.NewGuid().ToString();
            fileInfo.created_at = DateTime.Now;
            db.fileInfoes.Add(fileInfo);
            db.SaveChanges();




        }

      
    }
}
