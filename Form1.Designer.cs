namespace WordPressLoginChecker
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Button btnCheckLogins;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.RichTextBox txtOutput;
        private System.Windows.Forms.TextBox txtOutputFileName;
        private System.Windows.Forms.Button btnBrowseSaveLocation;
        private System.Windows.Forms.TextBox txtSaveLocation;
        private System.Windows.Forms.NumericUpDown numericUpDownThreads;
        private System.Windows.Forms.Label lblThreads;
        private System.Windows.Forms.ComboBox comboBoxMatchType;
        private System.Windows.Forms.Label lblMatchType;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            btnBrowse = new Button();
            txtFilePath = new TextBox();
            btnCheckLogins = new Button();
            btnStop = new Button();
            txtOutput = new RichTextBox();
            txtOutputFileName = new TextBox();
            btnBrowseSaveLocation = new Button();
            txtSaveLocation = new TextBox();
            numericUpDownThreads = new NumericUpDown();
            lblThreads = new Label();
            comboBoxMatchType = new ComboBox();
            lblMatchType = new Label();
            groupBox1 = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)numericUpDownThreads).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // btnBrowse
            // 
            btnBrowse.BackColor = Color.Black;
            btnBrowse.FlatStyle = FlatStyle.Flat;
            btnBrowse.ForeColor = Color.White;
            btnBrowse.Location = new Point(467, 14);
            btnBrowse.Margin = new Padding(4, 3, 4, 3);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(88, 27);
            btnBrowse.TabIndex = 0;
            btnBrowse.Text = "Browse...";
            btnBrowse.UseVisualStyleBackColor = false;
            btnBrowse.Click += btnBrowse_Click;
            // 
            // txtFilePath
            // 
            txtFilePath.BackColor = Color.Black;
            txtFilePath.ForeColor = Color.White;
            txtFilePath.Location = new Point(14, 14);
            txtFilePath.Margin = new Padding(4, 3, 4, 3);
            txtFilePath.Name = "txtFilePath";
            txtFilePath.ReadOnly = true;
            txtFilePath.Size = new Size(445, 23);
            txtFilePath.TabIndex = 1;
            // 
            // btnCheckLogins
            // 
            btnCheckLogins.BackColor = Color.FromArgb(0, 192, 0);
            btnCheckLogins.FlatStyle = FlatStyle.Flat;
            btnCheckLogins.ForeColor = Color.White;
            btnCheckLogins.Location = new Point(14, 44);
            btnCheckLogins.Margin = new Padding(4, 3, 4, 3);
            btnCheckLogins.Name = "btnCheckLogins";
            btnCheckLogins.Size = new Size(540, 27);
            btnCheckLogins.TabIndex = 2;
            btnCheckLogins.Text = "Check Logins";
            btnCheckLogins.UseVisualStyleBackColor = false;
            btnCheckLogins.Click += btnCheckLogins_Click;
            // 
            // btnStop
            // 
            btnStop.BackColor = Color.Red;
            btnStop.FlatStyle = FlatStyle.Flat;
            btnStop.ForeColor = Color.White;
            btnStop.Location = new Point(14, 77);
            btnStop.Margin = new Padding(4, 3, 4, 3);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(540, 27);
            btnStop.TabIndex = 3;
            btnStop.Text = "Stop";
            btnStop.UseVisualStyleBackColor = false;
            btnStop.Click += btnStop_Click;
            // 
            // txtOutput
            // 
            txtOutput.BackColor = Color.Black;
            txtOutput.DetectUrls = false;
            txtOutput.ForeColor = Color.Lime;
            txtOutput.Location = new Point(14, 111);
            txtOutput.Margin = new Padding(4, 3, 4, 3);
            txtOutput.Name = "txtOutput";
            txtOutput.ScrollBars = RichTextBoxScrollBars.Vertical;
            txtOutput.Size = new Size(540, 381);
            txtOutput.TabIndex = 4;
            txtOutput.Text = "";
            // 
            // txtOutputFileName
            // 
            txtOutputFileName.BackColor = Color.Black;
            txtOutputFileName.ForeColor = Color.White;
            txtOutputFileName.Location = new Point(14, 562);
            txtOutputFileName.Margin = new Padding(4, 3, 4, 3);
            txtOutputFileName.Name = "txtOutputFileName";
            txtOutputFileName.Size = new Size(445, 23);
            txtOutputFileName.TabIndex = 5;
            txtOutputFileName.Text = "successful_logins.txt";
            // 
            // btnBrowseSaveLocation
            // 
            btnBrowseSaveLocation.BackColor = Color.Black;
            btnBrowseSaveLocation.FlatStyle = FlatStyle.Flat;
            btnBrowseSaveLocation.ForeColor = Color.White;
            btnBrowseSaveLocation.Location = new Point(467, 575);
            btnBrowseSaveLocation.Margin = new Padding(4, 3, 4, 3);
            btnBrowseSaveLocation.Name = "btnBrowseSaveLocation";
            btnBrowseSaveLocation.Size = new Size(88, 27);
            btnBrowseSaveLocation.TabIndex = 7;
            btnBrowseSaveLocation.Text = "Browse...";
            btnBrowseSaveLocation.UseVisualStyleBackColor = false;
            btnBrowseSaveLocation.Click += btnBrowseSaveLocation_Click;
            // 
            // txtSaveLocation
            // 
            txtSaveLocation.BackColor = Color.Black;
            txtSaveLocation.ForeColor = Color.White;
            txtSaveLocation.Location = new Point(13, 591);
            txtSaveLocation.Margin = new Padding(4, 3, 4, 3);
            txtSaveLocation.Name = "txtSaveLocation";
            txtSaveLocation.ReadOnly = true;
            txtSaveLocation.Size = new Size(445, 23);
            txtSaveLocation.TabIndex = 6;
            // 
            // numericUpDownThreads
            // 
            numericUpDownThreads.BackColor = Color.Black;
            numericUpDownThreads.ForeColor = Color.White;
            numericUpDownThreads.Location = new Point(414, 14);
            numericUpDownThreads.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownThreads.Name = "numericUpDownThreads";
            numericUpDownThreads.Size = new Size(120, 23);
            numericUpDownThreads.TabIndex = 8;
            numericUpDownThreads.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblThreads
            // 
            lblThreads.AutoSize = true;
            lblThreads.ForeColor = Color.White;
            lblThreads.Location = new Point(296, 19);
            lblThreads.Name = "lblThreads";
            lblThreads.Size = new Size(112, 15);
            lblThreads.TabIndex = 9;
            lblThreads.Text = "Number of Threads:";
            // 
            // comboBoxMatchType
            // 
            comboBoxMatchType.BackColor = Color.Black;
            comboBoxMatchType.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxMatchType.ForeColor = Color.White;
            comboBoxMatchType.FormattingEnabled = true;
            comboBoxMatchType.IntegralHeight = false;
            comboBoxMatchType.ItemHeight = 15;
            comboBoxMatchType.Items.AddRange(new object[] { "Valid User Only", "Valid Admin", "Valid Admin + Upload Plugin" });
            comboBoxMatchType.Location = new Point(82, 19);
            comboBoxMatchType.Name = "comboBoxMatchType";
            comboBoxMatchType.Size = new Size(183, 23);
            comboBoxMatchType.TabIndex = 10;
            // 
            // lblMatchType
            // 
            lblMatchType.AutoSize = true;
            lblMatchType.ForeColor = Color.White;
            lblMatchType.Location = new Point(6, 22);
            lblMatchType.Name = "lblMatchType";
            lblMatchType.Size = new Size(71, 15);
            lblMatchType.TabIndex = 11;
            lblMatchType.Text = "Match Type:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(comboBoxMatchType);
            groupBox1.Controls.Add(lblThreads);
            groupBox1.Controls.Add(lblMatchType);
            groupBox1.Controls.Add(numericUpDownThreads);
            groupBox1.ForeColor = SystemColors.ButtonHighlight;
            groupBox1.Location = new Point(14, 508);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(540, 48);
            groupBox1.TabIndex = 12;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thread and Option";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(567, 626);
            Controls.Add(groupBox1);
            Controls.Add(txtSaveLocation);
            Controls.Add(btnBrowseSaveLocation);
            Controls.Add(txtOutputFileName);
            Controls.Add(txtOutput);
            Controls.Add(btnStop);
            Controls.Add(btnCheckLogins);
            Controls.Add(txtFilePath);
            Controls.Add(btnBrowse);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            Name = "Form1";
            Text = "WordPress Login Checker | Tegal1337";
            ((System.ComponentModel.ISupportInitialize)numericUpDownThreads).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private GroupBox groupBox1;
    }
}
