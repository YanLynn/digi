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
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.rotateLeftButton = new System.Windows.Forms.ToolStripButton();
            this.rotateRightButton = new System.Windows.Forms.ToolStripButton();
            this.deleteImageButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.switchViewButton = new System.Windows.Forms.ToolStripButton();
            this.imageListView1 = new Manina.Windows.Forms.ImageListView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rejectButton = new System.Windows.Forms.Button();
            this.submitButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.uenTypeComboBox = new System.Windows.Forms.ComboBox();
            this.uenTextBox = new System.Windows.Forms.TextBox();
            this.runNumTextBox = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.loadingLabel = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
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
            this.toolStrip1.Size = new System.Drawing.Size(1200, 33);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::digital_imaging.Properties.Resources.arrow_down;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(34, 28);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.Click += new System.EventHandler(this.getItem);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 33);
            // 
            // rotateLeftButton
            // 
            this.rotateLeftButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.rotateLeftButton.Image = global::digital_imaging.Properties.Resources.arrow_rotate_anticlockwise;
            this.rotateLeftButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.rotateLeftButton.Name = "rotateLeftButton";
            this.rotateLeftButton.Size = new System.Drawing.Size(34, 28);
            this.rotateLeftButton.Text = "toolStripButton2";
            this.rotateLeftButton.Click += new System.EventHandler(this.rotateLeft);
            // 
            // rotateRightButton
            // 
            this.rotateRightButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.rotateRightButton.Image = global::digital_imaging.Properties.Resources.arrow_rotate_clockwise;
            this.rotateRightButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.rotateRightButton.Name = "rotateRightButton";
            this.rotateRightButton.Size = new System.Drawing.Size(34, 28);
            this.rotateRightButton.Text = "toolStripButton2";
            this.rotateRightButton.Click += new System.EventHandler(this.rotateRight);
            // 
            // deleteImageButton
            // 
            this.deleteImageButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.deleteImageButton.Image = global::digital_imaging.Properties.Resources.cross_small;
            this.deleteImageButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteImageButton.Name = "deleteImageButton";
            this.deleteImageButton.Size = new System.Drawing.Size(34, 28);
            this.deleteImageButton.Text = "toolStripButton2";
            this.deleteImageButton.Click += new System.EventHandler(this.deleteImage);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 33);
            // 
            // switchViewButton
            // 
            this.switchViewButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.switchViewButton.Image = global::digital_imaging.Properties.Resources.transform_flip;
            this.switchViewButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.switchViewButton.Name = "switchViewButton";
            this.switchViewButton.Size = new System.Drawing.Size(34, 28);
            this.switchViewButton.Text = "toolStripButton2";
            this.switchViewButton.Click += new System.EventHandler(this.switchView);
            // 
            // imageListView1
            // 
            this.imageListView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageListView1.Location = new System.Drawing.Point(0, 0);
            this.imageListView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.imageListView1.Name = "imageListView1";
            this.imageListView1.PersistentCacheDirectory = "";
            this.imageListView1.PersistentCacheSize = ((long)(100));
            this.imageListView1.Size = new System.Drawing.Size(1200, 445);
            this.imageListView1.TabIndex = 1;
            this.imageListView1.UseWIC = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rejectButton);
            this.panel1.Controls.Add(this.submitButton);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.uenTypeComboBox);
            this.panel1.Controls.Add(this.uenTextBox);
            this.panel1.Controls.Add(this.runNumTextBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 478);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1200, 214);
            this.panel1.TabIndex = 2;
            // 
            // rejectButton
            // 
            this.rejectButton.BackColor = System.Drawing.Color.Red;
            this.rejectButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.rejectButton.Location = new System.Drawing.Point(1018, 137);
            this.rejectButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rejectButton.Name = "rejectButton";
            this.rejectButton.Size = new System.Drawing.Size(112, 35);
            this.rejectButton.TabIndex = 7;
            this.rejectButton.Text = "Reject";
            this.rejectButton.UseVisualStyleBackColor = false;
            this.rejectButton.Click += new System.EventHandler(this.rejectFileInfo);
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(710, 137);
            this.submitButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(156, 35);
            this.submitButton.TabIndex = 6;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submit);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 152);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "UEN No. :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 91);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "UEN Type :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Run No. :";
            // 
            // uenTypeComboBox
            // 
            this.uenTypeComboBox.FormattingEnabled = true;
            this.uenTypeComboBox.Location = new System.Drawing.Point(180, 78);
            this.uenTypeComboBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uenTypeComboBox.Name = "uenTypeComboBox";
            this.uenTypeComboBox.Size = new System.Drawing.Size(352, 28);
            this.uenTypeComboBox.TabIndex = 1;
            this.uenTypeComboBox.Validating += new System.ComponentModel.CancelEventHandler(this.uenTypeValidating);
            // 
            // uenTextBox
            // 
            this.uenTextBox.Location = new System.Drawing.Point(180, 142);
            this.uenTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uenTextBox.Name = "uenTextBox";
            this.uenTextBox.Size = new System.Drawing.Size(352, 26);
            this.uenTextBox.TabIndex = 2;
            this.uenTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.uenTextBoxValidating);
            // 
            // runNumTextBox
            // 
            this.runNumTextBox.Enabled = false;
            this.runNumTextBox.Location = new System.Drawing.Point(180, 11);
            this.runNumTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.runNumTextBox.Name = "runNumTextBox";
            this.runNumTextBox.Size = new System.Drawing.Size(352, 26);
            this.runNumTextBox.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.loadingLabel);
            this.panel2.Controls.Add(this.imageListView1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 33);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1200, 445);
            this.panel2.TabIndex = 3;
            // 
            // loadingLabel
            // 
            this.loadingLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loadingLabel.Location = new System.Drawing.Point(0, 0);
            this.loadingLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.loadingLabel.Name = "loadingLabel";
            this.loadingLabel.Size = new System.Drawing.Size(1200, 445);
            this.loadingLabel.TabIndex = 2;
            this.loadingLabel.Text = "Loading...";
            this.loadingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.loadingLabel.Visible = false;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // DataEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 692);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "DataEntry";
            this.Text = "DataEntry";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private Manina.Windows.Forms.ImageListView imageListView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox runNumTextBox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton rotateLeftButton;
        private System.Windows.Forms.ToolStripButton rotateRightButton;
        private System.Windows.Forms.ToolStripButton deleteImageButton;
        private System.Windows.Forms.TextBox uenTextBox;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox uenTypeComboBox;
        private System.Windows.Forms.Button rejectButton;
        private System.Windows.Forms.Label loadingLabel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton switchViewButton;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}