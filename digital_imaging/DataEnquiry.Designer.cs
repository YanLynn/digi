namespace digital_imaging
{
    partial class DataEnquiry
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.enqTbl = new System.Windows.Forms.TableLayoutPanel();
            this.expFile = new System.Windows.Forms.Button();
            this.enqFormTbl = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.checker = new System.Windows.Forms.CheckBox();
            this.maker = new System.Windows.Forms.CheckBox();
            this.labelrumNum = new System.Windows.Forms.Label();
            this.labeluenValue = new System.Windows.Forms.Label();
            this.labelstatus = new System.Windows.Forms.Label();
            this.labelmakerChecker = new System.Windows.Forms.Label();
            this.labelpro_date = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.entry = new System.Windows.Forms.CheckBox();
            this.reject = new System.Windows.Forms.CheckBox();
            this.complete = new System.Windows.Forms.CheckBox();
            this.scan = new System.Windows.Forms.CheckBox();
            this.EnqSubmit = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.proDate = new System.Windows.Forms.DateTimePicker();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.uenvle = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.runNum = new System.Windows.Forms.TextBox();
            this.enqGrid = new System.Windows.Forms.DataGridView();
            this.enqTbl.SuspendLayout();
            this.enqFormTbl.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.enqGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // enqTbl
            // 
            this.enqTbl.ColumnCount = 1;
            this.enqTbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.enqTbl.Controls.Add(this.expFile, 0, 2);
            this.enqTbl.Controls.Add(this.enqFormTbl, 0, 0);
            this.enqTbl.Controls.Add(this.enqGrid, 0, 1);
            this.enqTbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.enqTbl.Location = new System.Drawing.Point(0, 0);
            this.enqTbl.Name = "enqTbl";
            this.enqTbl.Padding = new System.Windows.Forms.Padding(30);
            this.enqTbl.RowCount = 3;
            this.enqTbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42.15017F));
            this.enqTbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 57.84983F));
            this.enqTbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.enqTbl.Size = new System.Drawing.Size(1378, 700);
            this.enqTbl.TabIndex = 0;
            // 
            // expFile
            // 
            this.expFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.expFile.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.expFile.Location = new System.Drawing.Point(1230, 619);
            this.expFile.Margin = new System.Windows.Forms.Padding(3, 3, 3, 5);
            this.expFile.Name = "expFile";
            this.expFile.Size = new System.Drawing.Size(115, 46);
            this.expFile.TabIndex = 0;
            this.expFile.Text = "Report";
            this.expFile.UseVisualStyleBackColor = false;
            this.expFile.Click += new System.EventHandler(this.expFile_Click);
            // 
            // enqFormTbl
            // 
            this.enqFormTbl.ColumnCount = 3;
            this.enqFormTbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.enqFormTbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.enqFormTbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.enqFormTbl.Controls.Add(this.tableLayoutPanel2, 1, 3);
            this.enqFormTbl.Controls.Add(this.labelrumNum, 0, 0);
            this.enqFormTbl.Controls.Add(this.labeluenValue, 0, 1);
            this.enqFormTbl.Controls.Add(this.labelstatus, 0, 2);
            this.enqFormTbl.Controls.Add(this.labelmakerChecker, 0, 3);
            this.enqFormTbl.Controls.Add(this.labelpro_date, 0, 4);
            this.enqFormTbl.Controls.Add(this.tableLayoutPanel1, 1, 2);
            this.enqFormTbl.Controls.Add(this.EnqSubmit, 1, 5);
            this.enqFormTbl.Controls.Add(this.tableLayoutPanel3, 1, 4);
            this.enqFormTbl.Controls.Add(this.tableLayoutPanel4, 1, 1);
            this.enqFormTbl.Controls.Add(this.tableLayoutPanel5, 1, 0);
            this.enqFormTbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.enqFormTbl.Location = new System.Drawing.Point(33, 33);
            this.enqFormTbl.Name = "enqFormTbl";
            this.enqFormTbl.RowCount = 6;
            this.enqFormTbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.enqFormTbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.enqFormTbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.enqFormTbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.enqFormTbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.enqFormTbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.enqFormTbl.Size = new System.Drawing.Size(1312, 241);
            this.enqFormTbl.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.05263F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.31579F));
            this.tableLayoutPanel2.Controls.Add(this.checker, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.maker, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(396, 123);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(453, 34);
            this.tableLayoutPanel2.TabIndex = 8;
            // 
            // checker
            // 
            this.checker.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checker.AutoSize = true;
            this.checker.Location = new System.Drawing.Point(211, 5);
            this.checker.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.checker.Name = "checker";
            this.checker.Size = new System.Drawing.Size(91, 24);
            this.checker.TabIndex = 12;
            this.checker.Text = "checker";
            this.checker.UseVisualStyleBackColor = true;
            // 
            // maker
            // 
            this.maker.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.maker.AutoSize = true;
            this.maker.Location = new System.Drawing.Point(10, 5);
            this.maker.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.maker.Name = "maker";
            this.maker.Size = new System.Drawing.Size(79, 24);
            this.maker.TabIndex = 8;
            this.maker.Text = "maker";
            this.maker.UseVisualStyleBackColor = true;
            // 
            // labelrumNum
            // 
            this.labelrumNum.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelrumNum.AutoSize = true;
            this.labelrumNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelrumNum.Location = new System.Drawing.Point(10, 9);
            this.labelrumNum.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.labelrumNum.Name = "labelrumNum";
            this.labelrumNum.Size = new System.Drawing.Size(125, 22);
            this.labelrumNum.TabIndex = 0;
            this.labelrumNum.Text = "Rum Number";
            // 
            // labeluenValue
            // 
            this.labeluenValue.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labeluenValue.AutoSize = true;
            this.labeluenValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labeluenValue.Location = new System.Drawing.Point(10, 49);
            this.labeluenValue.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.labeluenValue.Name = "labeluenValue";
            this.labeluenValue.Size = new System.Drawing.Size(108, 22);
            this.labeluenValue.TabIndex = 1;
            this.labeluenValue.Text = "UEN Value";
            // 
            // labelstatus
            // 
            this.labelstatus.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelstatus.AutoSize = true;
            this.labelstatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelstatus.Location = new System.Drawing.Point(10, 89);
            this.labelstatus.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.labelstatus.Name = "labelstatus";
            this.labelstatus.Size = new System.Drawing.Size(67, 22);
            this.labelstatus.TabIndex = 2;
            this.labelstatus.Text = "Status";
            // 
            // labelmakerChecker
            // 
            this.labelmakerChecker.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelmakerChecker.AutoSize = true;
            this.labelmakerChecker.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelmakerChecker.Location = new System.Drawing.Point(10, 129);
            this.labelmakerChecker.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.labelmakerChecker.Name = "labelmakerChecker";
            this.labelmakerChecker.Size = new System.Drawing.Size(156, 22);
            this.labelmakerChecker.TabIndex = 3;
            this.labelmakerChecker.Text = "Maker / Checker";
            // 
            // labelpro_date
            // 
            this.labelpro_date.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelpro_date.AutoSize = true;
            this.labelpro_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelpro_date.Location = new System.Drawing.Point(10, 169);
            this.labelpro_date.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.labelpro_date.Name = "labelpro_date";
            this.labelpro_date.Size = new System.Drawing.Size(52, 22);
            this.labelpro_date.TabIndex = 4;
            this.labelpro_date.Text = "Date";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.05263F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.31579F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.31579F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.31579F));
            this.tableLayoutPanel1.Controls.Add(this.entry, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.reject, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.complete, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.scan, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(396, 83);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(453, 34);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // entry
            // 
            this.entry.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.entry.AutoSize = true;
            this.entry.Location = new System.Drawing.Point(105, 5);
            this.entry.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.entry.Name = "entry";
            this.entry.Size = new System.Drawing.Size(70, 24);
            this.entry.TabIndex = 12;
            this.entry.Text = "entry";
            this.entry.UseVisualStyleBackColor = true;
            // 
            // reject
            // 
            this.reject.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.reject.AutoSize = true;
            this.reject.Location = new System.Drawing.Point(343, 5);
            this.reject.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.reject.Name = "reject";
            this.reject.Size = new System.Drawing.Size(74, 24);
            this.reject.TabIndex = 10;
            this.reject.Text = "reject";
            this.reject.UseVisualStyleBackColor = true;
            // 
            // complete
            // 
            this.complete.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.complete.AutoSize = true;
            this.complete.Location = new System.Drawing.Point(224, 5);
            this.complete.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.complete.Name = "complete";
            this.complete.Size = new System.Drawing.Size(100, 24);
            this.complete.TabIndex = 11;
            this.complete.Text = "complete";
            this.complete.UseVisualStyleBackColor = true;
            // 
            // scan
            // 
            this.scan.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.scan.AutoSize = true;
            this.scan.Location = new System.Drawing.Point(10, 5);
            this.scan.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.scan.Name = "scan";
            this.scan.Size = new System.Drawing.Size(69, 24);
            this.scan.TabIndex = 8;
            this.scan.Tag = "1";
            this.scan.Text = "scan";
            this.scan.UseVisualStyleBackColor = true;
            // 
            // EnqSubmit
            // 
            this.EnqSubmit.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.EnqSubmit.Location = new System.Drawing.Point(403, 205);
            this.EnqSubmit.Margin = new System.Windows.Forms.Padding(10, 5, 3, 3);
            this.EnqSubmit.Name = "EnqSubmit";
            this.EnqSubmit.Size = new System.Drawing.Size(101, 33);
            this.EnqSubmit.TabIndex = 10;
            this.EnqSubmit.Text = "Submit";
            this.EnqSubmit.UseVisualStyleBackColor = false;
            this.EnqSubmit.Click += new System.EventHandler(this.EnqSubmit_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.proDate, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(396, 163);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(453, 34);
            this.tableLayoutPanel3.TabIndex = 11;
            // 
            // proDate
            // 
            this.proDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.proDate.Location = new System.Drawing.Point(10, 3);
            this.proDate.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.proDate.Name = "proDate";
            this.proDate.Size = new System.Drawing.Size(440, 26);
            this.proDate.TabIndex = 10;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.uenvle, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(396, 43);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(453, 34);
            this.tableLayoutPanel4.TabIndex = 12;
            // 
            // uenvle
            // 
            this.uenvle.BackColor = System.Drawing.Color.LightGray;
            this.uenvle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uenvle.Location = new System.Drawing.Point(10, 3);
            this.uenvle.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.uenvle.Name = "uenvle";
            this.uenvle.Size = new System.Drawing.Size(440, 26);
            this.uenvle.TabIndex = 7;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Controls.Add(this.runNum, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(396, 3);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(453, 34);
            this.tableLayoutPanel5.TabIndex = 13;
            // 
            // runNum
            // 
            this.runNum.BackColor = System.Drawing.Color.LightGray;
            this.runNum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.runNum.Location = new System.Drawing.Point(10, 3);
            this.runNum.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.runNum.Name = "runNum";
            this.runNum.Size = new System.Drawing.Size(440, 26);
            this.runNum.TabIndex = 6;
            // 
            // enqGrid
            // 
            this.enqGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.enqGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.enqGrid.Location = new System.Drawing.Point(33, 280);
            this.enqGrid.Name = "enqGrid";
            this.enqGrid.RowHeadersWidth = 62;
            this.enqGrid.RowTemplate.Height = 28;
            this.enqGrid.Size = new System.Drawing.Size(1312, 333);
            this.enqGrid.TabIndex = 2;
            // 
            // DataEnquiry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1378, 700);
            this.Controls.Add(this.enqTbl);
            this.Name = "DataEnquiry";
            this.Text = "DataEnquiry";
            this.enqTbl.ResumeLayout(false);
            this.enqFormTbl.ResumeLayout(false);
            this.enqFormTbl.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.enqGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel enqTbl;
        private System.Windows.Forms.Button expFile;
        private System.Windows.Forms.TableLayoutPanel enqFormTbl;
        private System.Windows.Forms.Label labelrumNum;
        private System.Windows.Forms.Label labeluenValue;
        private System.Windows.Forms.Label labelstatus;
        private System.Windows.Forms.Label labelmakerChecker;
        private System.Windows.Forms.Label labelpro_date;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckBox entry;
        private System.Windows.Forms.CheckBox reject;
        private System.Windows.Forms.CheckBox complete;
        private System.Windows.Forms.CheckBox scan;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.CheckBox checker;
        private System.Windows.Forms.CheckBox maker;
        private System.Windows.Forms.Button EnqSubmit;
        private System.Windows.Forms.DataGridView enqGrid;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.DateTimePicker proDate;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TextBox uenvle;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.TextBox runNum;
    }
}