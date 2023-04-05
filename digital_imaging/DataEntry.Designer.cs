namespace digital_imaging
{
    partial class DataEntry
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
            this.components = new System.ComponentModel.Container();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.panel2 = new System.Windows.Forms.Panel();
            this.loadingLabel = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.imageListView1 = new Manina.Windows.Forms.ImageListView();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.rotateLeftButton = new System.Windows.Forms.ToolStripButton();
            this.rotateRightButton = new System.Windows.Forms.ToolStripButton();
            this.deleteImageButton = new System.Windows.Forms.ToolStripButton();
            this.switchViewButton = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.runNumTextBox = new System.Windows.Forms.TextBox();
            this.uenTypeComboBox = new System.Windows.Forms.ComboBox();
            this.uenTextBox = new System.Windows.Forms.TextBox();
            this.rejectButton = new System.Windows.Forms.Button();
            this.submitButton = new System.Windows.Forms.Button();
            this.toolStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripSeparator1,
            this.rotateLeftButton,
            this.rotateRightButton,
            this.deleteImageButton,
            this.toolStripSeparator2,
            this.switchViewButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.toolStrip1.Size = new System.Drawing.Size(1200, 38);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 38);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 38);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.loadingLabel);
            this.panel2.Controls.Add(this.imageListView1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(4, 5);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1192, 393);
            this.panel2.TabIndex = 3;
            // 
            // loadingLabel
            // 
            this.loadingLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loadingLabel.Location = new System.Drawing.Point(0, 0);
            this.loadingLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.loadingLabel.Name = "loadingLabel";
            this.loadingLabel.Size = new System.Drawing.Size(1192, 393);
            this.loadingLabel.TabIndex = 2;
            this.loadingLabel.Text = "Loading...";
            this.loadingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.loadingLabel.Visible = false;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // imageListView1
            // 
            this.imageListView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageListView1.Location = new System.Drawing.Point(0, 0);
            this.imageListView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.imageListView1.Name = "imageListView1";
            this.imageListView1.PersistentCacheDirectory = "";
            this.imageListView1.PersistentCacheSize = ((long)(100));
            this.imageListView1.Size = new System.Drawing.Size(1192, 393);
            this.imageListView1.TabIndex = 1;
            this.imageListView1.UseWIC = true;
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::digital_imaging.Properties.Resources.arrow_down;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(34, 33);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.Click += new System.EventHandler(this.getItem);
            // 
            // rotateLeftButton
            // 
            this.rotateLeftButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.rotateLeftButton.Image = global::digital_imaging.Properties.Resources.arrow_rotate_anticlockwise;
            this.rotateLeftButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.rotateLeftButton.Name = "rotateLeftButton";
            this.rotateLeftButton.Size = new System.Drawing.Size(34, 33);
            this.rotateLeftButton.Text = "toolStripButton2";
            this.rotateLeftButton.Click += new System.EventHandler(this.rotateLeft);
            // 
            // rotateRightButton
            // 
            this.rotateRightButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.rotateRightButton.Image = global::digital_imaging.Properties.Resources.arrow_rotate_clockwise;
            this.rotateRightButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.rotateRightButton.Name = "rotateRightButton";
            this.rotateRightButton.Size = new System.Drawing.Size(34, 33);
            this.rotateRightButton.Text = "toolStripButton2";
            this.rotateRightButton.Click += new System.EventHandler(this.rotateRight);
            // 
            // deleteImageButton
            // 
            this.deleteImageButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.deleteImageButton.Image = global::digital_imaging.Properties.Resources.cross_small;
            this.deleteImageButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteImageButton.Name = "deleteImageButton";
            this.deleteImageButton.Size = new System.Drawing.Size(34, 33);
            this.deleteImageButton.Text = "toolStripButton2";
            this.deleteImageButton.Click += new System.EventHandler(this.deleteImage);
            // 
            // switchViewButton
            // 
            this.switchViewButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.switchViewButton.Image = global::digital_imaging.Properties.Resources.transform_flip;
            this.switchViewButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.switchViewButton.Name = "switchViewButton";
            this.switchViewButton.Size = new System.Drawing.Size(34, 33);
            this.switchViewButton.Text = "toolStripButton2";
            this.switchViewButton.Click += new System.EventHandler(this.switchView);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 38);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 61.6208F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 38.3792F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1200, 654);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.16667F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.83333F));
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.runNumTextBox, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.uenTypeComboBox, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.uenTextBox, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.rejectButton, 2, 3);
            this.tableLayoutPanel2.Controls.Add(this.submitButton, 1, 3);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 406);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1194, 245);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(80, 13);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 13, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 20);
            this.label3.TabIndex = 16;
            this.label3.Text = "UEN No. :";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(75, 74);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 13, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 20);
            this.label2.TabIndex = 15;
            this.label2.Text = "UEN Type :";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(82, 135);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 13, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 20);
            this.label1.TabIndex = 14;
            this.label1.Text = "Run No. :";
            // 
            // runNumTextBox
            // 
            this.runNumTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.runNumTextBox.Enabled = false;
            this.runNumTextBox.Location = new System.Drawing.Point(244, 5);
            this.runNumTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 0);
            this.runNumTextBox.Name = "runNumTextBox";
            this.runNumTextBox.Size = new System.Drawing.Size(362, 26);
            this.runNumTextBox.TabIndex = 17;
            // 
            // uenTypeComboBox
            // 
            this.uenTypeComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uenTypeComboBox.FormattingEnabled = true;
            this.uenTypeComboBox.Location = new System.Drawing.Point(244, 66);
            this.uenTypeComboBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uenTypeComboBox.Name = "uenTypeComboBox";
            this.uenTypeComboBox.Size = new System.Drawing.Size(362, 28);
            this.uenTypeComboBox.TabIndex = 18;
            // 
            // uenTextBox
            // 
            this.uenTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uenTextBox.Location = new System.Drawing.Point(244, 127);
            this.uenTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uenTextBox.Name = "uenTextBox";
            this.uenTextBox.Size = new System.Drawing.Size(362, 26);
            this.uenTextBox.TabIndex = 19;
            // 
            // rejectButton
            // 
            this.rejectButton.BackColor = System.Drawing.Color.Red;
            this.rejectButton.CausesValidation = false;
            this.rejectButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.rejectButton.Location = new System.Drawing.Point(614, 188);
            this.rejectButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rejectButton.Name = "rejectButton";
            this.rejectButton.Size = new System.Drawing.Size(133, 45);
            this.rejectButton.TabIndex = 21;
            this.rejectButton.Text = "Reject";
            this.rejectButton.UseVisualStyleBackColor = false;
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(244, 188);
            this.submitButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(120, 45);
            this.submitButton.TabIndex = 20;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = true;
            // 
            // DataEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 692);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.toolStrip1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "DataEntry";
            this.Text = "DataEntry";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private Manina.Windows.Forms.ImageListView imageListView1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton rotateLeftButton;
        private System.Windows.Forms.ToolStripButton rotateRightButton;
        private System.Windows.Forms.ToolStripButton deleteImageButton;
        private System.Windows.Forms.Label loadingLabel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton switchViewButton;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox runNumTextBox;
        private System.Windows.Forms.ComboBox uenTypeComboBox;
        private System.Windows.Forms.TextBox uenTextBox;
        private System.Windows.Forms.Button rejectButton;
        private System.Windows.Forms.Button submitButton;
    }
}