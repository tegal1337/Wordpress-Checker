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
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            telegramChatID = new TextBox();
            telegramBotToken = new TextBox();
            label2 = new Label();
            label1 = new Label();
            groupBox3 = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)numericUpDownThreads).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
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
            txtOutput.Size = new Size(540, 249);
            txtOutput.TabIndex = 4;
            txtOutput.Text = "";
            // 
            // txtOutputFileName
            // 
            txtOutputFileName.BackColor = Color.Black;
            txtOutputFileName.BorderStyle = BorderStyle.FixedSingle;
            txtOutputFileName.ForeColor = Color.White;
            txtOutputFileName.Location = new Point(7, 20);
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
            btnBrowseSaveLocation.Location = new Point(460, 26);
            btnBrowseSaveLocation.Margin = new Padding(4, 3, 4, 3);
            btnBrowseSaveLocation.Name = "btnBrowseSaveLocation";
            btnBrowseSaveLocation.Size = new Size(72, 27);
            btnBrowseSaveLocation.TabIndex = 7;
            btnBrowseSaveLocation.Text = "Browse...";
            btnBrowseSaveLocation.UseVisualStyleBackColor = false;
            btnBrowseSaveLocation.Click += btnBrowseSaveLocation_Click;
            // 
            // txtSaveLocation
            // 
            txtSaveLocation.BackColor = Color.Black;
            txtSaveLocation.BorderStyle = BorderStyle.FixedSingle;
            txtSaveLocation.ForeColor = Color.White;
            txtSaveLocation.Location = new Point(8, 48);
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
            numericUpDownThreads.Location = new Point(125, 17);
            numericUpDownThreads.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownThreads.Name = "numericUpDownThreads";
            numericUpDownThreads.Size = new Size(294, 23);
            numericUpDownThreads.TabIndex = 8;
            numericUpDownThreads.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblThreads
            // 
            lblThreads.AutoSize = true;
            lblThreads.ForeColor = Color.White;
            lblThreads.Location = new Point(6, 19);
            lblThreads.Name = "lblThreads";
            lblThreads.Size = new Size(113, 15);
            lblThreads.TabIndex = 9;
            lblThreads.Text = "Number of Threads:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblThreads);
            groupBox1.Controls.Add(numericUpDownThreads);
            groupBox1.ForeColor = SystemColors.ButtonHighlight;
            groupBox1.Location = new Point(13, 366);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(540, 48);
            groupBox1.TabIndex = 12;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thread and Option";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(telegramChatID);
            groupBox2.Controls.Add(telegramBotToken);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(label1);
            groupBox2.ForeColor = SystemColors.ButtonHighlight;
            groupBox2.Location = new Point(19, 522);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(540, 98);
            groupBox2.TabIndex = 13;
            groupBox2.TabStop = false;
            groupBox2.Text = "Thread and Option";
            // 
            // telegramChatID
            // 
            telegramChatID.BackColor = Color.Black;
            telegramChatID.BorderStyle = BorderStyle.FixedSingle;
            telegramChatID.ForeColor = Color.White;
            telegramChatID.Location = new Point(119, 57);
            telegramChatID.Margin = new Padding(4, 3, 4, 3);
            telegramChatID.Name = "telegramChatID";
            telegramChatID.Size = new Size(392, 23);
            telegramChatID.TabIndex = 16;
            telegramChatID.Text = "telegram_chat_id";
            // 
            // telegramBotToken
            // 
            telegramBotToken.BackColor = Color.Black;
            telegramBotToken.BorderStyle = BorderStyle.FixedSingle;
            telegramBotToken.ForeColor = Color.White;
            telegramBotToken.Location = new Point(119, 16);
            telegramBotToken.Margin = new Padding(4, 3, 4, 3);
            telegramBotToken.Name = "telegramBotToken";
            telegramBotToken.Size = new Size(392, 23);
            telegramBotToken.TabIndex = 14;
            telegramBotToken.Text = "telegram_bot_token";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.White;
            label2.Location = new Point(6, 65);
            label2.Name = "label2";
            label2.Size = new Size(98, 15);
            label2.TabIndex = 15;
            label2.Text = "Telegram Chat ID";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.White;
            label1.Location = new Point(6, 19);
            label1.Name = "label1";
            label1.Size = new Size(112, 15);
            label1.TabIndex = 9;
            label1.Text = "Telegram Bot Token";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(txtOutputFileName);
            groupBox3.Controls.Add(btnBrowseSaveLocation);
            groupBox3.Controls.Add(txtSaveLocation);
            groupBox3.ForeColor = SystemColors.ButtonFace;
            groupBox3.Location = new Point(17, 438);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(539, 77);
            groupBox3.TabIndex = 14;
            groupBox3.TabStop = false;
            groupBox3.Text = "Output Path";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(572, 658);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
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
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label label1;
        private Label label2;
        private TextBox telegramChatID;
        private TextBox telegramBotToken;
        private GroupBox groupBox3;
    }
}
