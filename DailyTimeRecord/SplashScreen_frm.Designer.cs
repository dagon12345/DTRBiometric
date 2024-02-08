namespace DailyTimeRecord
{
    partial class SplashScreen_frm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SplashScreen_frm));
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BirthdayLabel = new System.Windows.Forms.TextBox();
            this.picseeyou = new System.Windows.Forms.PictureBox();
            this.lblname = new System.Windows.Forms.TextBox();
            this.lblgreetings = new System.Windows.Forms.TextBox();
            this.picwelcome = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picseeyou)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picwelcome)).BeginInit();
            this.SuspendLayout();
            // 
            // Timer
            // 
            this.Timer.Enabled = true;
            this.Timer.Interval = 35;
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(0, 699);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1072, 23);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1048, 108);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(112, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(348, 34);
            this.label2.TabIndex = 2;
            this.label2.Text = "Daily time record system";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(112, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(409, 39);
            this.label1.TabIndex = 2;
            this.label1.Text = "CTP Shipping Lines Corp.";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DailyTimeRecord.Properties.Resources.ctp_logo;
            this.pictureBox1.Location = new System.Drawing.Point(6, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 90);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.BirthdayLabel);
            this.groupBox2.Controls.Add(this.picseeyou);
            this.groupBox2.Controls.Add(this.lblname);
            this.groupBox2.Controls.Add(this.lblgreetings);
            this.groupBox2.Controls.Add(this.picwelcome);
            this.groupBox2.Location = new System.Drawing.Point(12, 126);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1048, 567);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // BirthdayLabel
            // 
            this.BirthdayLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BirthdayLabel.BackColor = System.Drawing.Color.Green;
            this.BirthdayLabel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.BirthdayLabel.Font = new System.Drawing.Font("Calibri", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BirthdayLabel.ForeColor = System.Drawing.Color.White;
            this.BirthdayLabel.HideSelection = false;
            this.BirthdayLabel.Location = new System.Drawing.Point(3, 18);
            this.BirthdayLabel.Name = "BirthdayLabel";
            this.BirthdayLabel.ReadOnly = true;
            this.BirthdayLabel.Size = new System.Drawing.Size(1045, 74);
            this.BirthdayLabel.TabIndex = 5;
            this.BirthdayLabel.TabStop = false;
            this.BirthdayLabel.Text = "----";
            this.BirthdayLabel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.BirthdayLabel.Visible = false;
            // 
            // picseeyou
            // 
            this.picseeyou.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.picseeyou.Image = global::DailyTimeRecord.Properties.Resources.giphy;
            this.picseeyou.Location = new System.Drawing.Point(390, 98);
            this.picseeyou.Name = "picseeyou";
            this.picseeyou.Size = new System.Drawing.Size(270, 181);
            this.picseeyou.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picseeyou.TabIndex = 4;
            this.picseeyou.TabStop = false;
            // 
            // lblname
            // 
            this.lblname.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblname.BackColor = System.Drawing.Color.Navy;
            this.lblname.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblname.Font = new System.Drawing.Font("Calibri", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblname.ForeColor = System.Drawing.Color.White;
            this.lblname.HideSelection = false;
            this.lblname.Location = new System.Drawing.Point(15, 457);
            this.lblname.Name = "lblname";
            this.lblname.ReadOnly = true;
            this.lblname.Size = new System.Drawing.Size(1012, 58);
            this.lblname.TabIndex = 0;
            this.lblname.TabStop = false;
            this.lblname.Text = "----";
            this.lblname.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblgreetings
            // 
            this.lblgreetings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblgreetings.BackColor = System.Drawing.Color.Navy;
            this.lblgreetings.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblgreetings.Font = new System.Drawing.Font("Arial Rounded MT Bold", 100.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblgreetings.ForeColor = System.Drawing.Color.White;
            this.lblgreetings.HideSelection = false;
            this.lblgreetings.Location = new System.Drawing.Point(6, 257);
            this.lblgreetings.Name = "lblgreetings";
            this.lblgreetings.ReadOnly = true;
            this.lblgreetings.Size = new System.Drawing.Size(1036, 194);
            this.lblgreetings.TabIndex = 1;
            this.lblgreetings.TabStop = false;
            this.lblgreetings.Text = "----";
            this.lblgreetings.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // picwelcome
            // 
            this.picwelcome.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.picwelcome.Image = global::DailyTimeRecord.Properties.Resources.source__1_;
            this.picwelcome.Location = new System.Drawing.Point(348, 103);
            this.picwelcome.Name = "picwelcome";
            this.picwelcome.Size = new System.Drawing.Size(355, 176);
            this.picwelcome.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picwelcome.TabIndex = 3;
            this.picwelcome.TabStop = false;
            // 
            // SplashScreen_frm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Navy;
            this.ClientSize = new System.Drawing.Size(1072, 722);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.progressBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SplashScreen_frm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SplashScreen_frm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SplashScreen_frm_FormClosing);
            this.Load += new System.EventHandler(this.SplashScreen_frm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picseeyou)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picwelcome)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.PictureBox picwelcome;
        public System.Windows.Forms.TextBox lblgreetings;
        public System.Windows.Forms.TextBox lblname;
        public System.Windows.Forms.PictureBox picseeyou;
        public System.Windows.Forms.TextBox BirthdayLabel;
        public System.Windows.Forms.ProgressBar progressBar1;
        public System.Windows.Forms.Timer Timer;
    }
}