namespace DailyTimeRecord
{
    partial class DailyTimeRecord
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DailyTimeRecord));
            this.TimeStatus = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtrfidnumber = new System.Windows.Forms.TextBox();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.formulabox = new System.Windows.Forms.GroupBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dttodayout = new System.Windows.Forms.DateTimePicker();
            this.dttimeoutidentefier = new System.Windows.Forms.DateTimePicker();
            this.lbltotalhourstoday = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txttimeoutovertime = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.dttodayin = new System.Windows.Forms.DateTimePicker();
            this.LoadProgressBar = new System.Windows.Forms.ProgressBar();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.dtprevioustimein = new System.Windows.Forms.DateTimePicker();
            this.dttimein = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.dttimeout = new System.Windows.Forms.DateTimePicker();
            this.lblprevioustimein = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label20 = new System.Windows.Forms.Label();
            this.lblrfid = new System.Windows.Forms.Label();
            this.lblcounter = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.BirthdayLabel = new System.Windows.Forms.TextBox();
            this.lblrfidstatus = new System.Windows.Forms.TextBox();
            this.cmbtimestatus = new System.Windows.Forms.Label();
            this.groupBox14 = new System.Windows.Forms.GroupBox();
            this.btnenter = new System.Windows.Forms.Button();
            this.FingerprintDriverText = new System.Windows.Forms.ComboBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label17 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.authorize_btn = new System.Windows.Forms.Button();
            this.password_txt = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.BirthdayStatus = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbltime = new System.Windows.Forms.TextBox();
            this.lbldate = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label26 = new System.Windows.Forms.Label();
            this.FingerPrintPicturebox = new System.Windows.Forms.PictureBox();
            this.imageBoxFrameGrabber = new Emgu.CV.UI.ImageBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblpercent = new System.Windows.Forms.Label();
            this.FingerStatusLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LogoPictureBox = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblnoonstatus = new System.Windows.Forms.TextBox();
            this.lblemployeename = new System.Windows.Forms.TextBox();
            this.lbldepartment = new System.Windows.Forms.TextBox();
            this.lblstatus = new System.Windows.Forms.TextBox();
            this.EmployeePicture = new System.Windows.Forms.PictureBox();
            this.dgbday = new System.Windows.Forms.DataGridView();
            this.ResetTimer = new System.Windows.Forms.Timer(this.components);
            this.backuprfidreset = new System.Windows.Forms.Timer(this.components);
            this.facedetectiontimer = new System.Windows.Forms.Timer(this.components);
            this.FormulaBackup = new System.Windows.Forms.Timer(this.components);
            this.rfidstatustimer = new System.Windows.Forms.Timer(this.components);
            this.bw = new System.ComponentModel.BackgroundWorker();
            this.groupBox10.SuspendLayout();
            this.formulabox.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FingerPrintPicturebox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxFrameGrabber)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LogoPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmployeePicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgbday)).BeginInit();
            this.SuspendLayout();
            // 
            // TimeStatus
            // 
            this.TimeStatus.Interval = 90;
            this.TimeStatus.Tick += new System.EventHandler(this.TimeStatus_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 34);
            this.label1.TabIndex = 0;
            this.label1.Text = "Time Status:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(7, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 35);
            this.label2.TabIndex = 0;
            this.label2.Text = "RFID SENSOR";
            // 
            // txtrfidnumber
            // 
            this.txtrfidnumber.BackColor = System.Drawing.Color.White;
            this.txtrfidnumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtrfidnumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtrfidnumber.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtrfidnumber.ForeColor = System.Drawing.Color.Yellow;
            this.txtrfidnumber.Location = new System.Drawing.Point(3, 139);
            this.txtrfidnumber.Name = "txtrfidnumber";
            this.txtrfidnumber.ReadOnly = true;
            this.txtrfidnumber.Size = new System.Drawing.Size(414, 22);
            this.txtrfidnumber.TabIndex = 0;
            this.txtrfidnumber.TabStop = false;
            this.txtrfidnumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtrfidnumber.TextChanged += new System.EventHandler(this.txtrfidnumber_TextChanged);
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.formulabox);
            this.groupBox10.Location = new System.Drawing.Point(384, 9);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(371, 202);
            this.groupBox10.TabIndex = 15;
            this.groupBox10.TabStop = false;
            // 
            // formulabox
            // 
            this.formulabox.Controls.Add(this.label23);
            this.formulabox.Controls.Add(this.label10);
            this.formulabox.Controls.Add(this.dttodayout);
            this.formulabox.Controls.Add(this.dttimeoutidentefier);
            this.formulabox.Controls.Add(this.lbltotalhourstoday);
            this.formulabox.Controls.Add(this.label13);
            this.formulabox.Controls.Add(this.txttimeoutovertime);
            this.formulabox.Controls.Add(this.label11);
            this.formulabox.Controls.Add(this.dttodayin);
            this.formulabox.Location = new System.Drawing.Point(6, 21);
            this.formulabox.Name = "formulabox";
            this.formulabox.Size = new System.Drawing.Size(338, 137);
            this.formulabox.TabIndex = 13;
            this.formulabox.TabStop = false;
            this.formulabox.Text = "Formula";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Arial Narrow", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.White;
            this.label23.Location = new System.Drawing.Point(227, 71);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(63, 17);
            this.label23.TabIndex = 22;
            this.label23.Text = "TimeoutOT";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial Narrow", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(9, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(86, 17);
            this.label10.TabIndex = 9;
            this.label10.Text = "Time in Identifier";
            // 
            // dttodayout
            // 
            this.dttodayout.CustomFormat = "MM/dd/yyyy hh:mm:ss tt";
            this.dttodayout.Enabled = false;
            this.dttodayout.Font = new System.Drawing.Font("Arial Narrow", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dttodayout.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dttodayout.Location = new System.Drawing.Point(6, 74);
            this.dttodayout.Name = "dttodayout";
            this.dttodayout.Size = new System.Drawing.Size(201, 22);
            this.dttodayout.TabIndex = 10;
            this.dttodayout.Value = new System.DateTime(2020, 11, 3, 15, 21, 0, 0);
            // 
            // dttimeoutidentefier
            // 
            this.dttimeoutidentefier.CustomFormat = "hh:mm:ss tt ";
            this.dttimeoutidentefier.Enabled = false;
            this.dttimeoutidentefier.Font = new System.Drawing.Font("Arial Narrow", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dttimeoutidentefier.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dttimeoutidentefier.Location = new System.Drawing.Point(6, 102);
            this.dttimeoutidentefier.Name = "dttimeoutidentefier";
            this.dttimeoutidentefier.Size = new System.Drawing.Size(201, 22);
            this.dttimeoutidentefier.TabIndex = 11;
            this.dttimeoutidentefier.Value = new System.DateTime(2020, 11, 3, 3, 21, 0, 0);
            // 
            // lbltotalhourstoday
            // 
            this.lbltotalhourstoday.AutoSize = true;
            this.lbltotalhourstoday.Font = new System.Drawing.Font("Arial Narrow", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltotalhourstoday.ForeColor = System.Drawing.Color.White;
            this.lbltotalhourstoday.Location = new System.Drawing.Point(227, 44);
            this.lbltotalhourstoday.Name = "lbltotalhourstoday";
            this.lbltotalhourstoday.Size = new System.Drawing.Size(14, 17);
            this.lbltotalhourstoday.TabIndex = 13;
            this.lbltotalhourstoday.Text = "0";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial Narrow", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(225, 13);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(106, 17);
            this.label13.TabIndex = 13;
            this.label13.Text = "(Total Hours Today)";
            // 
            // txttimeoutovertime
            // 
            this.txttimeoutovertime.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txttimeoutovertime.Font = new System.Drawing.Font("Arial Narrow", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttimeoutovertime.Location = new System.Drawing.Point(227, 101);
            this.txttimeoutovertime.Name = "txttimeoutovertime";
            this.txttimeoutovertime.ReadOnly = true;
            this.txttimeoutovertime.Size = new System.Drawing.Size(70, 22);
            this.txttimeoutovertime.TabIndex = 15;
            this.txttimeoutovertime.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial Narrow", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(3, 54);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(92, 17);
            this.label11.TabIndex = 12;
            this.label11.Text = "Time out Identifier";
            // 
            // dttodayin
            // 
            this.dttodayin.CustomFormat = "MM/dd/yyyy hh:mm:ss tt ";
            this.dttodayin.Enabled = false;
            this.dttodayin.Font = new System.Drawing.Font("Arial Narrow", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dttodayin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dttodayin.Location = new System.Drawing.Point(6, 29);
            this.dttodayin.Name = "dttodayin";
            this.dttodayin.Size = new System.Drawing.Size(201, 22);
            this.dttodayin.TabIndex = 8;
            this.dttodayin.Value = new System.DateTime(2020, 11, 3, 15, 21, 0, 0);
            // 
            // LoadProgressBar
            // 
            this.LoadProgressBar.Location = new System.Drawing.Point(211, 281);
            this.LoadProgressBar.Name = "LoadProgressBar";
            this.LoadProgressBar.Size = new System.Drawing.Size(155, 17);
            this.LoadProgressBar.TabIndex = 68;
            this.LoadProgressBar.Visible = false;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.dtprevioustimein);
            this.groupBox7.Controls.Add(this.dttimein);
            this.groupBox7.Controls.Add(this.label8);
            this.groupBox7.Controls.Add(this.dttimeout);
            this.groupBox7.Controls.Add(this.lblprevioustimein);
            this.groupBox7.Controls.Add(this.label9);
            this.groupBox7.Location = new System.Drawing.Point(761, 9);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(273, 202);
            this.groupBox7.TabIndex = 21;
            this.groupBox7.TabStop = false;
            // 
            // dtprevioustimein
            // 
            this.dtprevioustimein.CustomFormat = "MM/dd/yyyy hh:mm tt ";
            this.dtprevioustimein.Enabled = false;
            this.dtprevioustimein.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtprevioustimein.Location = new System.Drawing.Point(9, 169);
            this.dtprevioustimein.Name = "dtprevioustimein";
            this.dtprevioustimein.Size = new System.Drawing.Size(214, 22);
            this.dtprevioustimein.TabIndex = 13;
            this.dtprevioustimein.Value = new System.DateTime(2021, 6, 9, 0, 0, 0, 0);
            // 
            // dttimein
            // 
            this.dttimein.CustomFormat = "hh:mm tt";
            this.dttimein.Enabled = false;
            this.dttimein.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dttimein.Location = new System.Drawing.Point(6, 38);
            this.dttimein.Name = "dttimein";
            this.dttimein.Size = new System.Drawing.Size(135, 22);
            this.dttimein.TabIndex = 4;
            this.dttimein.Value = new System.DateTime(2020, 11, 3, 15, 21, 0, 0);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(3, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(99, 17);
            this.label8.TabIndex = 5;
            this.label8.Text = "Desig Timein:";
            // 
            // dttimeout
            // 
            this.dttimeout.CustomFormat = "hh:mm tt";
            this.dttimeout.Enabled = false;
            this.dttimeout.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dttimeout.Location = new System.Drawing.Point(8, 95);
            this.dttimeout.Name = "dttimeout";
            this.dttimeout.Size = new System.Drawing.Size(127, 22);
            this.dttimeout.TabIndex = 6;
            this.dttimeout.Value = new System.DateTime(2020, 11, 3, 15, 21, 0, 0);
            // 
            // lblprevioustimein
            // 
            this.lblprevioustimein.AutoSize = true;
            this.lblprevioustimein.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblprevioustimein.ForeColor = System.Drawing.Color.White;
            this.lblprevioustimein.Location = new System.Drawing.Point(6, 141);
            this.lblprevioustimein.Name = "lblprevioustimein";
            this.lblprevioustimein.Size = new System.Drawing.Size(99, 17);
            this.lblprevioustimein.TabIndex = 14;
            this.lblprevioustimein.Text = "Last Timed In:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(6, 75);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(108, 17);
            this.label9.TabIndex = 7;
            this.label9.Text = "Desig Timeout:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label20);
            this.groupBox4.Controls.Add(this.lblrfid);
            this.groupBox4.Controls.Add(this.lblcounter);
            this.groupBox4.Controls.Add(this.label21);
            this.groupBox4.Font = new System.Drawing.Font("Arial Narrow", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(164, 75);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox4.Size = new System.Drawing.Size(195, 116);
            this.groupBox4.TabIndex = 20;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Results: ";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.White;
            this.label20.Location = new System.Drawing.Point(12, 20);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(150, 18);
            this.label20.TabIndex = 17;
            this.label20.Text = "Person\'s RFID Number:";
            // 
            // lblrfid
            // 
            this.lblrfid.AutoSize = true;
            this.lblrfid.Font = new System.Drawing.Font("Calibri", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblrfid.ForeColor = System.Drawing.Color.Blue;
            this.lblrfid.Location = new System.Drawing.Point(12, 45);
            this.lblrfid.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblrfid.Name = "lblrfid";
            this.lblrfid.Size = new System.Drawing.Size(54, 17);
            this.lblrfid.TabIndex = 16;
            this.lblrfid.Text = "(Empty)";
            // 
            // lblcounter
            // 
            this.lblcounter.AutoSize = true;
            this.lblcounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcounter.ForeColor = System.Drawing.Color.Red;
            this.lblcounter.Location = new System.Drawing.Point(11, 85);
            this.lblcounter.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblcounter.Name = "lblcounter";
            this.lblcounter.Size = new System.Drawing.Size(19, 20);
            this.lblcounter.TabIndex = 15;
            this.lblcounter.Text = "0";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.White;
            this.label21.Location = new System.Drawing.Point(8, 67);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(176, 18);
            this.label21.TabIndex = 14;
            this.label21.Text = "Number of faces detected: ";
            // 
            // BirthdayLabel
            // 
            this.BirthdayLabel.BackColor = System.Drawing.Color.Green;
            this.BirthdayLabel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.BirthdayLabel.Font = new System.Drawing.Font("Calibri", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BirthdayLabel.ForeColor = System.Drawing.Color.White;
            this.BirthdayLabel.HideSelection = false;
            this.BirthdayLabel.Location = new System.Drawing.Point(3, 48);
            this.BirthdayLabel.Name = "BirthdayLabel";
            this.BirthdayLabel.ReadOnly = true;
            this.BirthdayLabel.Size = new System.Drawing.Size(414, 41);
            this.BirthdayLabel.TabIndex = 21;
            this.BirthdayLabel.TabStop = false;
            this.BirthdayLabel.Text = "----";
            this.BirthdayLabel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.BirthdayLabel.Visible = false;
            this.BirthdayLabel.TextChanged += new System.EventHandler(this.BirthdayLabel_TextChanged);
            // 
            // lblrfidstatus
            // 
            this.lblrfidstatus.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblrfidstatus.BackColor = System.Drawing.Color.Black;
            this.lblrfidstatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblrfidstatus.Font = new System.Drawing.Font("Britannic Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblrfidstatus.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblrfidstatus.Location = new System.Drawing.Point(296, 15);
            this.lblrfidstatus.Name = "lblrfidstatus";
            this.lblrfidstatus.ReadOnly = true;
            this.lblrfidstatus.Size = new System.Drawing.Size(713, 26);
            this.lblrfidstatus.TabIndex = 20;
            this.lblrfidstatus.TabStop = false;
            this.lblrfidstatus.Text = "-----";
            this.lblrfidstatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cmbtimestatus
            // 
            this.cmbtimestatus.AutoSize = true;
            this.cmbtimestatus.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbtimestatus.ForeColor = System.Drawing.Color.LightGreen;
            this.cmbtimestatus.Location = new System.Drawing.Point(183, 9);
            this.cmbtimestatus.Name = "cmbtimestatus";
            this.cmbtimestatus.Size = new System.Drawing.Size(75, 34);
            this.cmbtimestatus.TabIndex = 19;
            this.cmbtimestatus.Text = "-----";
            // 
            // groupBox14
            // 
            this.groupBox14.Location = new System.Drawing.Point(6, 83);
            this.groupBox14.Name = "groupBox14";
            this.groupBox14.Size = new System.Drawing.Size(411, 10);
            this.groupBox14.TabIndex = 18;
            this.groupBox14.TabStop = false;
            // 
            // btnenter
            // 
            this.btnenter.BackColor = System.Drawing.Color.Transparent;
            this.btnenter.FlatAppearance.BorderSize = 0;
            this.btnenter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnenter.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnenter.ForeColor = System.Drawing.Color.Black;
            this.btnenter.Location = new System.Drawing.Point(461, 623);
            this.btnenter.Name = "btnenter";
            this.btnenter.Size = new System.Drawing.Size(408, 15);
            this.btnenter.TabIndex = 2;
            this.btnenter.Text = "ENTER";
            this.btnenter.UseVisualStyleBackColor = false;
            this.btnenter.Click += new System.EventHandler(this.btnenter_Click);
            // 
            // FingerprintDriverText
            // 
            this.FingerprintDriverText.Enabled = false;
            this.FingerprintDriverText.FormattingEnabled = true;
            this.FingerprintDriverText.Location = new System.Drawing.Point(88, 151);
            this.FingerprintDriverText.Name = "FingerprintDriverText";
            this.FingerprintDriverText.Size = new System.Drawing.Size(44, 24);
            this.FingerprintDriverText.TabIndex = 64;
            this.FingerprintDriverText.Visible = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(211, 243);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(155, 17);
            this.progressBar1.TabIndex = 18;
            this.progressBar1.Visible = false;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(7, 18);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(104, 17);
            this.label17.TabIndex = 16;
            this.label17.Text = "Face Detector";
            // 
            // label19
            // 
            this.label19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.White;
            this.label19.Location = new System.Drawing.Point(10, 574);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(89, 17);
            this.label19.TabIndex = 16;
            this.label19.Text = "RESET TIMER:";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.groupBox2);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.BirthdayStatus);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.lbltime);
            this.groupBox3.Controls.Add(this.lblrfidstatus);
            this.groupBox3.Controls.Add(this.lbldate);
            this.groupBox3.Controls.Add(this.label19);
            this.groupBox3.Controls.Add(this.groupBox1);
            this.groupBox3.Controls.Add(this.lblpercent);
            this.groupBox3.Controls.Add(this.FingerStatusLabel);
            this.groupBox3.Controls.Add(this.btnenter);
            this.groupBox3.Controls.Add(this.panel1);
            this.groupBox3.Controls.Add(this.dgbday);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1324, 697);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.authorize_btn);
            this.groupBox2.Controls.Add(this.password_txt);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Location = new System.Drawing.Point(1118, 42);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 167);
            this.groupBox2.TabIndex = 74;
            this.groupBox2.TabStop = false;
            this.groupBox2.Visible = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.SeaGreen;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(9, 116);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(185, 27);
            this.button3.TabIndex = 2;
            this.button3.Text = "Cancel";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // authorize_btn
            // 
            this.authorize_btn.BackColor = System.Drawing.Color.SeaGreen;
            this.authorize_btn.FlatAppearance.BorderSize = 0;
            this.authorize_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.authorize_btn.ForeColor = System.Drawing.Color.White;
            this.authorize_btn.Location = new System.Drawing.Point(9, 83);
            this.authorize_btn.Name = "authorize_btn";
            this.authorize_btn.Size = new System.Drawing.Size(185, 27);
            this.authorize_btn.TabIndex = 1;
            this.authorize_btn.Text = "Authorize";
            this.authorize_btn.UseVisualStyleBackColor = false;
            this.authorize_btn.Click += new System.EventHandler(this.authorize_btn_Click);
            // 
            // password_txt
            // 
            this.password_txt.Location = new System.Drawing.Point(9, 46);
            this.password_txt.Name = "password_txt";
            this.password_txt.Size = new System.Drawing.Size(185, 22);
            this.password_txt.TabIndex = 0;
            this.password_txt.UseSystemPasswordChar = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(6, 26);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(69, 17);
            this.label12.TabIndex = 0;
            this.label12.Text = "Password";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.Crimson;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(1218, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 27);
            this.button1.TabIndex = 15;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // BirthdayStatus
            // 
            this.BirthdayStatus.AutoSize = true;
            this.BirthdayStatus.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BirthdayStatus.ForeColor = System.Drawing.Color.Lime;
            this.BirthdayStatus.Location = new System.Drawing.Point(129, 15);
            this.BirthdayStatus.Name = "BirthdayStatus";
            this.BirthdayStatus.Size = new System.Drawing.Size(38, 17);
            this.BirthdayStatus.TabIndex = 73;
            this.BirthdayStatus.Text = "-----";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(3, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 17);
            this.label6.TabIndex = 73;
            this.label6.Text = "Today\'s Birthday";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(11, 596);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 17);
            this.label5.TabIndex = 72;
            this.label5.Text = "Status:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(967, 621);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(264, 17);
            this.label4.TabIndex = 71;
            this.label4.Text = "Developed by: Lance Andrei U. Espina";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(10, 510);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(216, 51);
            this.label3.TabIndex = 71;
            this.label3.Text = "CTP Shipping Lines Corporation\r\nDaily Time Record\r\nRFID + BIOMETRIC AND Face";
            // 
            // lbltime
            // 
            this.lbltime.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lbltime.BackColor = System.Drawing.Color.Black;
            this.lbltime.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbltime.Font = new System.Drawing.Font("Arial Rounded MT Bold", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltime.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lbltime.Location = new System.Drawing.Point(296, 574);
            this.lbltime.Name = "lbltime";
            this.lbltime.ReadOnly = true;
            this.lbltime.Size = new System.Drawing.Size(719, 39);
            this.lbltime.TabIndex = 70;
            this.lbltime.Text = "Time";
            this.lbltime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.lbltime.TextChanged += new System.EventHandler(this.lbltime_TextChanged);
            // 
            // lbldate
            // 
            this.lbldate.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lbldate.BackColor = System.Drawing.Color.Black;
            this.lbldate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbldate.Font = new System.Drawing.Font("Arial Rounded MT Bold", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldate.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lbldate.Location = new System.Drawing.Point(296, 527);
            this.lbldate.Name = "lbldate";
            this.lbldate.ReadOnly = true;
            this.lbldate.Size = new System.Drawing.Size(719, 39);
            this.lbldate.TabIndex = 69;
            this.lbldate.Text = "Date";
            this.lbldate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.LoadProgressBar);
            this.groupBox1.Controls.Add(this.groupBox7);
            this.groupBox1.Controls.Add(this.groupBox10);
            this.groupBox1.Controls.Add(this.progressBar1);
            this.groupBox1.Location = new System.Drawing.Point(6, 669);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1312, 22);
            this.groupBox1.TabIndex = 67;
            this.groupBox1.TabStop = false;
            this.groupBox1.Visible = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.groupBox4);
            this.groupBox5.Controls.Add(this.label26);
            this.groupBox5.Controls.Add(this.FingerprintDriverText);
            this.groupBox5.Controls.Add(this.FingerPrintPicturebox);
            this.groupBox5.Controls.Add(this.imageBoxFrameGrabber);
            this.groupBox5.Controls.Add(this.label17);
            this.groupBox5.Location = new System.Drawing.Point(7, 9);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(371, 214);
            this.groupBox5.TabIndex = 17;
            this.groupBox5.TabStop = false;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.White;
            this.label26.Location = new System.Drawing.Point(7, 103);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(140, 17);
            this.label26.TabIndex = 66;
            this.label26.Text = "Fingerprint Detector";
            // 
            // FingerPrintPicturebox
            // 
            this.FingerPrintPicturebox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.FingerPrintPicturebox.Location = new System.Drawing.Point(10, 130);
            this.FingerPrintPicturebox.Name = "FingerPrintPicturebox";
            this.FingerPrintPicturebox.Size = new System.Drawing.Size(72, 69);
            this.FingerPrintPicturebox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.FingerPrintPicturebox.TabIndex = 65;
            this.FingerPrintPicturebox.TabStop = false;
            // 
            // imageBoxFrameGrabber
            // 
            this.imageBoxFrameGrabber.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.imageBoxFrameGrabber.Location = new System.Drawing.Point(10, 54);
            this.imageBoxFrameGrabber.Name = "imageBoxFrameGrabber";
            this.imageBoxFrameGrabber.Size = new System.Drawing.Size(82, 38);
            this.imageBoxFrameGrabber.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imageBoxFrameGrabber.TabIndex = 19;
            this.imageBoxFrameGrabber.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.BirthdayLabel);
            this.panel2.Controls.Add(this.cmbtimestatus);
            this.panel2.Controls.Add(this.groupBox14);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txtrfidnumber);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(390, 217);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(431, 196);
            this.panel2.TabIndex = 69;
            // 
            // lblpercent
            // 
            this.lblpercent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblpercent.AutoSize = true;
            this.lblpercent.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblpercent.ForeColor = System.Drawing.Color.Yellow;
            this.lblpercent.Location = new System.Drawing.Point(116, 574);
            this.lblpercent.Name = "lblpercent";
            this.lblpercent.Size = new System.Drawing.Size(14, 17);
            this.lblpercent.TabIndex = 20;
            this.lblpercent.Text = "-";
            // 
            // FingerStatusLabel
            // 
            this.FingerStatusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.FingerStatusLabel.AutoSize = true;
            this.FingerStatusLabel.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FingerStatusLabel.ForeColor = System.Drawing.Color.White;
            this.FingerStatusLabel.Location = new System.Drawing.Point(12, 621);
            this.FingerStatusLabel.Name = "FingerStatusLabel";
            this.FingerStatusLabel.Size = new System.Drawing.Size(87, 34);
            this.FingerStatusLabel.TabIndex = 67;
            this.FingerStatusLabel.Text = "------";
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.LogoPictureBox);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.lblnoonstatus);
            this.panel1.Controls.Add(this.lblemployeename);
            this.panel1.Controls.Add(this.lbldepartment);
            this.panel1.Controls.Add(this.lblstatus);
            this.panel1.Controls.Add(this.EmployeePicture);
            this.panel1.Location = new System.Drawing.Point(296, 46);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(719, 479);
            this.panel1.TabIndex = 68;
            // 
            // LogoPictureBox
            // 
            this.LogoPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LogoPictureBox.Image = global::DailyTimeRecord.Properties.Resources.CTP_TRANSPARENT_LOGO_4;
            this.LogoPictureBox.Location = new System.Drawing.Point(109, 3);
            this.LogoPictureBox.Name = "LogoPictureBox";
            this.LogoPictureBox.Size = new System.Drawing.Size(499, 464);
            this.LogoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.LogoPictureBox.TabIndex = 22;
            this.LogoPictureBox.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Image = global::DailyTimeRecord.Properties.Resources.CTP_TRANSPARENT_LOGO_4;
            this.pictureBox1.Location = new System.Drawing.Point(112, 32);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(70, 76);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 74;
            this.pictureBox1.TabStop = false;
            // 
            // lblnoonstatus
            // 
            this.lblnoonstatus.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblnoonstatus.BackColor = System.Drawing.Color.Black;
            this.lblnoonstatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblnoonstatus.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblnoonstatus.ForeColor = System.Drawing.Color.White;
            this.lblnoonstatus.HideSelection = false;
            this.lblnoonstatus.Location = new System.Drawing.Point(53, 339);
            this.lblnoonstatus.Name = "lblnoonstatus";
            this.lblnoonstatus.ReadOnly = true;
            this.lblnoonstatus.Size = new System.Drawing.Size(612, 25);
            this.lblnoonstatus.TabIndex = 71;
            this.lblnoonstatus.TabStop = false;
            this.lblnoonstatus.Text = "(Noon Status)";
            this.lblnoonstatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblemployeename
            // 
            this.lblemployeename.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblemployeename.BackColor = System.Drawing.Color.Black;
            this.lblemployeename.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblemployeename.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblemployeename.ForeColor = System.Drawing.Color.White;
            this.lblemployeename.HideSelection = false;
            this.lblemployeename.Location = new System.Drawing.Point(53, 433);
            this.lblemployeename.Name = "lblemployeename";
            this.lblemployeename.ReadOnly = true;
            this.lblemployeename.Size = new System.Drawing.Size(612, 29);
            this.lblemployeename.TabIndex = 69;
            this.lblemployeename.TabStop = false;
            this.lblemployeename.Text = "(Name)";
            this.lblemployeename.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbldepartment
            // 
            this.lbldepartment.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbldepartment.BackColor = System.Drawing.Color.Black;
            this.lbldepartment.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbldepartment.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldepartment.ForeColor = System.Drawing.Color.White;
            this.lbldepartment.HideSelection = false;
            this.lbldepartment.Location = new System.Drawing.Point(106, 305);
            this.lbldepartment.Name = "lbldepartment";
            this.lbldepartment.ReadOnly = true;
            this.lbldepartment.Size = new System.Drawing.Size(506, 22);
            this.lbldepartment.TabIndex = 70;
            this.lbldepartment.TabStop = false;
            this.lbldepartment.Text = "(Department)";
            this.lbldepartment.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblstatus
            // 
            this.lblstatus.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblstatus.BackColor = System.Drawing.Color.Black;
            this.lblstatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblstatus.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblstatus.ForeColor = System.Drawing.Color.White;
            this.lblstatus.HideSelection = false;
            this.lblstatus.Location = new System.Drawing.Point(53, 386);
            this.lblstatus.Name = "lblstatus";
            this.lblstatus.ReadOnly = true;
            this.lblstatus.Size = new System.Drawing.Size(612, 29);
            this.lblstatus.TabIndex = 68;
            this.lblstatus.TabStop = false;
            this.lblstatus.Text = "----";
            this.lblstatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // EmployeePicture
            // 
            this.EmployeePicture.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.EmployeePicture.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.EmployeePicture.Location = new System.Drawing.Point(208, 3);
            this.EmployeePicture.Name = "EmployeePicture";
            this.EmployeePicture.Size = new System.Drawing.Size(291, 296);
            this.EmployeePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.EmployeePicture.TabIndex = 0;
            this.EmployeePicture.TabStop = false;
            // 
            // dgbday
            // 
            this.dgbday.AllowUserToAddRows = false;
            this.dgbday.AllowUserToDeleteRows = false;
            this.dgbday.AllowUserToOrderColumns = true;
            this.dgbday.BackgroundColor = System.Drawing.Color.Black;
            this.dgbday.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgbday.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgbday.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgbday.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgbday.ColumnHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Lime;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Lime;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgbday.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgbday.GridColor = System.Drawing.Color.Black;
            this.dgbday.Location = new System.Drawing.Point(6, 35);
            this.dgbday.MultiSelect = false;
            this.dgbday.Name = "dgbday";
            this.dgbday.ReadOnly = true;
            this.dgbday.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgbday.RowHeadersVisible = false;
            this.dgbday.RowHeadersWidth = 51;
            this.dgbday.RowTemplate.Height = 24;
            this.dgbday.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgbday.Size = new System.Drawing.Size(284, 138);
            this.dgbday.TabIndex = 70;
            this.dgbday.TabStop = false;
            // 
            // ResetTimer
            // 
            this.ResetTimer.Enabled = true;
            this.ResetTimer.Interval = 200;
            this.ResetTimer.Tick += new System.EventHandler(this.ResetTimer_Tick);
            // 
            // backuprfidreset
            // 
            this.backuprfidreset.Interval = 1000;
            this.backuprfidreset.Tick += new System.EventHandler(this.backuprfidreset_Tick);
            // 
            // facedetectiontimer
            // 
            this.facedetectiontimer.Interval = 200;
            this.facedetectiontimer.Tick += new System.EventHandler(this.facedetectiontimer_Tick);
            // 
            // FormulaBackup
            // 
            this.FormulaBackup.Tick += new System.EventHandler(this.FormulaBackup_Tick);
            // 
            // rfidstatustimer
            // 
            this.rfidstatustimer.Tick += new System.EventHandler(this.rfdistatustimer_Tick);
            // 
            // bw
            // 
            this.bw.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bw_DoWork_1);
            // 
            // DailyTimeRecord
            // 
            this.AcceptButton = this.authorize_btn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1348, 721);
            this.Controls.Add(this.groupBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DailyTimeRecord";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DailyTimeRecord";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DailyTimeRecord_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DailyTimeRecord_FormClosed);
            this.Load += new System.EventHandler(this.DailyTimeRecord_Load);
            this.groupBox10.ResumeLayout(false);
            this.formulabox.ResumeLayout(false);
            this.formulabox.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FingerPrintPicturebox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxFrameGrabber)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LogoPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmployeePicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgbday)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer TimeStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtrfidnumber;
        private System.Windows.Forms.PictureBox EmployeePicture;
        private System.Windows.Forms.Button btnenter;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dttimeout;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dttimein;
        private System.Windows.Forms.DateTimePicker dttodayin;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dttimeoutidentefier;
        private System.Windows.Forms.DateTimePicker dttodayout;
        private System.Windows.Forms.GroupBox formulabox;
        private System.Windows.Forms.DateTimePicker dtprevioustimein;
        private System.Windows.Forms.Label lblprevioustimein;
        private System.Windows.Forms.Label lbltotalhourstoday;
        private System.Windows.Forms.TextBox txttimeoutovertime;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Timer ResetTimer;
        private System.Windows.Forms.ProgressBar progressBar1;
        private Emgu.CV.UI.ImageBox imageBoxFrameGrabber;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label lblrfid;
        private System.Windows.Forms.Label lblcounter;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Timer backuprfidreset;
        private System.Windows.Forms.Timer facedetectiontimer;
        private System.Windows.Forms.Timer FormulaBackup;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.PictureBox LogoPictureBox;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.Label lblpercent;
        private System.Windows.Forms.Timer rfidstatustimer;
        private System.Windows.Forms.GroupBox groupBox14;
        private System.Windows.Forms.Label cmbtimestatus;
        private System.Windows.Forms.TextBox lblrfidstatus;
        public System.Windows.Forms.TextBox BirthdayLabel;
        private System.Windows.Forms.ComboBox FingerprintDriverText;
        private System.Windows.Forms.PictureBox FingerPrintPicturebox;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label FingerStatusLabel;
        private System.ComponentModel.BackgroundWorker bw;
        private System.Windows.Forms.ProgressBar LoadProgressBar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.TextBox lblnoonstatus;
        public System.Windows.Forms.TextBox lbldepartment;
        public System.Windows.Forms.TextBox lblemployeename;
        public System.Windows.Forms.TextBox lblstatus;
        private System.Windows.Forms.TextBox lbltime;
        private System.Windows.Forms.TextBox lbldate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgbday;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label BirthdayStatus;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox password_txt;
        private System.Windows.Forms.Button authorize_btn;
        private System.Windows.Forms.Button button3;
    }
}