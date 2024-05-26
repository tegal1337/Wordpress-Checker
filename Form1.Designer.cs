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
            txtOutput.Size = new Size(540, 406);
            txtOutput.TabIndex = 4;
            txtOutput.Text = "";
            // 
            // txtOutputFileName
            // 
            txtOutputFileName.BackColor = Color.Black;
            txtOutputFileName.ForeColor = Color.White;
            txtOutputFileName.Location = new Point(14, 524);
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
            btnBrowseSaveLocation.Location = new Point(467, 554);
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
            txtSaveLocation.Location = new Point(14, 554);
            txtSaveLocation.Margin = new Padding(4, 3, 4, 3);
            txtSaveLocation.Name = "txtSaveLocation";
            txtSaveLocation.ReadOnly = true;
            txtSaveLocation.Size = new Size(445, 23);
            txtSaveLocation.TabIndex = 6;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(568, 594);
            Controls.Add(txtSaveLocation);
            Controls.Add(btnBrowseSaveLocation);
            Controls.Add(txtOutputFileName);
            Controls.Add(txtOutput);
            Controls.Add(btnStop);
            Controls.Add(btnCheckLogins);
            Controls.Add(txtFilePath);
            Controls.Add(btnBrowse);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            Name = "Form1";
            Text = "WordPress Login Checker | Tegal1337";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
