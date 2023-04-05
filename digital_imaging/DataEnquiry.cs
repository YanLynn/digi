using digital_imaging.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using System.IO;

namespace digital_imaging
{
    public partial class DataEnquiry : Form
    {
        DigitalImageEntities db = new DigitalImageEntities();
        string fPath = System.Configuration.ConfigurationSettings.AppSettings["fPath"];
        public DataEnquiry()
        {
            InitializeComponent();
        }

        private void EnqSubmit_Click(object sender, EventArgs e)
        {
            try
            {
               
                List<view_fileInfo> dEnq = new List<view_fileInfo>();

                dEnq = db.view_fileInfo.Where(x => (DbFunctions.DiffDays(x.pro_date, proDate.Value) == 0))
                                        .Where(x => (runNum.Text != "") ? x.rumNum.Contains(runNum.Text) : true)
                                        .Where(x => (uenvle.Text != "") ? x.uenValue.Contains(uenvle.Text): true)
                                        .Where(x => scan.Checked ? x.status == 0 : true)
                                        .Where(x => entry.Checked ? x.status == 1 : true)
                                        .Where(x => complete.Checked ? x.status == 2 : true)
                                        .Where(x => reject.Checked ? x.status == 3 : true)
                                        .Where(x => maker.Checked ? x.maker != null : true)
                                        .Where(x => checker.Checked ? x.checker != null : true)
                                        .ToList();
                enqGrid.DataSource = dEnq;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void expFile_Click(object sender, EventArgs e)
        {
            try
            {
                Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbook workbook = excel.Workbooks.Add(Type.Missing);
                Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.ActiveSheet;

                for (int i = 1; i <= enqGrid.Columns.Count; i++)
                {
                    worksheet.Cells[1, i] = enqGrid.Columns[i - 1].HeaderText;
                }
                for (int i = 0; i < enqGrid.Rows.Count; i++)
                {
                    for (int j = 0; j < enqGrid.Columns.Count; j++)
                    {
                     
                        worksheet.Cells[i + 2, j + 1] = (enqGrid.Rows[i].Cells[j].Value == null) ? "" : enqGrid.Rows[i].Cells[j].Value.ToString();
                    }
                }
                DirectoryInfo directoryInfo = new DirectoryInfo(fPath);

                String sDate = DateTime.Now.ToString();
                DateTime datevalue = (Convert.ToDateTime(sDate.ToString()));

                String dy = datevalue.Day.ToString();
                String mn = datevalue.Month.ToString();
                String yy = datevalue.Year.ToString();
                String date = dy + mn + yy;
                workbook.SaveAs(directoryInfo + date +"excelReport.xlsx");
                workbook.Close(true, Type.Missing, Type.Missing);
                excel.Quit();
                MessageBox.Show("Export Success","info",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void formatCell(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.enqGrid.Columns[e.ColumnIndex].Name == "status")
            {
                if (e.Value != null)
                {
                    if (e.Value.ToString() == "0")
                    {
                        e.Value = "Scanned";
                    }
                    else if (e.Value.ToString() == "1")
                    {
                        e.Value = "Data Entry";
                    }
                    else if (e.Value.ToString() == "2")
                    {
                        e.Value = "Completed";
                    }
                    else if (e.Value.ToString() == "3")
                    {
                        e.Value = "Rejected";
                    }
                    e.FormattingApplied = true;
                }
            }
        }
    }
}
