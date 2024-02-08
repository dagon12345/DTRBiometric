namespace DailyTimeRecord
{
    partial class Register
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Register));
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnCameraOn = new System.Windows.Forms.Button();
            this.LabelRFID = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblcounter = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.LabelStatus = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.imageBox1 = new Emgu.CV.UI.ImageBox();
            this.imageBoxFrameGrabber = new Emgu.CV.UI.ImageBox();
            this.btnstatus = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SearchTextbox = new System.Windows.Forms.TextBox();
            this.btndelete = new System.Windows.Forms.Button();
            this.btnupdate = new System.Windows.Forms.Button();
            this.btnadd = new System.Windows.Forms.Button();
            this.btnupload = new System.Windows.Forms.Button();
            this.btnclear = new System.Windows.Forms.Button();
            this.status = new System.Windows.Forms.Timer(this.components);
            this.dttimeout = new System.Windows.Forms.DateTimePicker();
            this.dttimein = new System.Windows.Forms.DateTimePicker();
            this.cmbdepartment = new System.Windows.Forms.ComboBox();
            this.txtfullname = new System.Windows.Forms.TextBox();
            this.txtidnumber = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblcardcode = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblcardstatus = new System.Windows.Forms.Label();
            this.btnclose = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.dtbday = new System.Windows.Forms.DateTimePicker();
            this.rbwith = new System.Windows.Forms.RadioButton();
            this.rbwithout = new System.Windows.Forms.RadioButton();
            this.label15 = new System.Windows.Forms.Label();
            this.txtnoon = new System.Windows.Forms.TextBox();
            this.Automatic = new System.Windows.Forms.Timer(this.components);
            this.StopCaptureButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ClearButton = new System.Windows.Forms.Button();
            this.MissingCardCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.FingerStatusLabel = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.StopButton = new System.Windows.Forms.Button();
            this.FingerprintDriverText = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.FingerPrintButton = new System.Windows.Forms.Button();
            this.FingerPrintPicturebox = new System.Windows.Forms.PictureBox();
            this.label17 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.UniqueIDLabel = new System.Windows.Forms.Label();
            this.SearchedListBox = new System.Windows.Forms.ListBox();
            this.SearchButton = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxFrameGrabber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FingerPrintPicturebox)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(176, 16);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(120, 17);
            this.label11.TabIndex = 50;
            this.label11.Text = "Captured Image";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(9, 27);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(167, 18);
            this.label10.TabIndex = 17;
            this.label10.Text = "Person\'s RFID Number:";
            this.label10.Visible = false;
            // 
            // btnCameraOn
            // 
            this.btnCameraOn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCameraOn.Location = new System.Drawing.Point(16, 143);
            this.btnCameraOn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnCameraOn.Name = "btnCameraOn";
            this.btnCameraOn.Size = new System.Drawing.Size(147, 42);
            this.btnCameraOn.TabIndex = 10;
            this.btnCameraOn.Text = "Auto Capture On";
            this.btnCameraOn.UseVisualStyleBackColor = true;
            this.btnCameraOn.Click += new System.EventHandler(this.btnCameraOn_Click);
            // 
            // LabelRFID
            // 
            this.LabelRFID.AutoSize = true;
            this.LabelRFID.BackColor = System.Drawing.Color.White;
            this.LabelRFID.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelRFID.ForeColor = System.Drawing.Color.Black;
            this.LabelRFID.Location = new System.Drawing.Point(9, 54);
            this.LabelRFID.Name = "LabelRFID";
            this.LabelRFID.Size = new System.Drawing.Size(38, 18);
            this.LabelRFID.TabIndex = 16;
            this.LabelRFID.Text = "-----";
            this.LabelRFID.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.LabelRFID);
            this.groupBox2.Controls.Add(this.lblcounter);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(938, 443);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(236, 261);
            this.groupBox2.TabIndex = 48;
            this.groupBox2.TabStop = false;
            this.groupBox2.Visible = false;
            // 
            // lblcounter
            // 
            this.lblcounter.AutoSize = true;
            this.lblcounter.BackColor = System.Drawing.Color.White;
            this.lblcounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcounter.ForeColor = System.Drawing.Color.Black;
            this.lblcounter.Location = new System.Drawing.Point(9, 122);
            this.lblcounter.Name = "lblcounter";
            this.lblcounter.Size = new System.Drawing.Size(19, 20);
            this.lblcounter.TabIndex = 15;
            this.lblcounter.Text = "0";
            this.lblcounter.Visible = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(9, 88);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(209, 18);
            this.label12.TabIndex = 14;
            this.label12.Text = "Number of faces detected: ";
            this.label12.Visible = false;
            // 
            // LabelStatus
            // 
            this.LabelStatus.AutoSize = true;
            this.LabelStatus.BackColor = System.Drawing.Color.White;
            this.LabelStatus.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelStatus.ForeColor = System.Drawing.Color.Black;
            this.LabelStatus.Location = new System.Drawing.Point(301, 46);
            this.LabelStatus.Name = "LabelStatus";
            this.LabelStatus.Size = new System.Drawing.Size(44, 19);
            this.LabelStatus.TabIndex = 19;
            this.LabelStatus.Text = "-----";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(301, 18);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(118, 18);
            this.label16.TabIndex = 18;
            this.label16.Text = "Camera Status:";
            // 
            // imageBox1
            // 
            this.imageBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.imageBox1.Location = new System.Drawing.Point(179, 37);
            this.imageBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.imageBox1.Name = "imageBox1";
            this.imageBox1.Size = new System.Drawing.Size(109, 100);
            this.imageBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imageBox1.TabIndex = 46;
            this.imageBox1.TabStop = false;
            // 
            // imageBoxFrameGrabber
            // 
            this.imageBoxFrameGrabber.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.imageBoxFrameGrabber.Location = new System.Drawing.Point(16, 37);
            this.imageBoxFrameGrabber.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.imageBoxFrameGrabber.Name = "imageBoxFrameGrabber";
            this.imageBoxFrameGrabber.Size = new System.Drawing.Size(148, 100);
            this.imageBoxFrameGrabber.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.imageBoxFrameGrabber.TabIndex = 47;
            this.imageBoxFrameGrabber.TabStop = false;
            // 
            // btnstatus
            // 
            this.btnstatus.BackColor = System.Drawing.Color.Green;
            this.btnstatus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnstatus.FlatAppearance.BorderSize = 0;
            this.btnstatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnstatus.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnstatus.ForeColor = System.Drawing.Color.White;
            this.btnstatus.Location = new System.Drawing.Point(4, 11);
            this.btnstatus.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnstatus.Name = "btnstatus";
            this.btnstatus.Size = new System.Drawing.Size(140, 41);
            this.btnstatus.TabIndex = 0;
            this.btnstatus.Text = "Verify";
            this.btnstatus.UseVisualStyleBackColor = false;
            this.btnstatus.Click += new System.EventHandler(this.btnstatus_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(14, 18);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(120, 17);
            this.label8.TabIndex = 44;
            this.label8.Text = "Camera Preview";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(87, 20);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 17);
            this.label3.TabIndex = 40;
            this.label3.Text = "Search:";
            // 
            // SearchTextbox
            // 
            this.SearchTextbox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.SearchTextbox.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchTextbox.Location = new System.Drawing.Point(152, 17);
            this.SearchTextbox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.SearchTextbox.Name = "SearchTextbox";
            this.SearchTextbox.Size = new System.Drawing.Size(260, 28);
            this.SearchTextbox.TabIndex = 43;
            this.SearchTextbox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.SearchTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SearchTextbox_KeyDown);
            this.SearchTextbox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SearchTextbox_KeyUp);
            this.SearchTextbox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.SearchTextbox_MouseDoubleClick);
            // 
            // btndelete
            // 
            this.btndelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btndelete.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndelete.Location = new System.Drawing.Point(55, 192);
            this.btndelete.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(108, 34);
            this.btndelete.TabIndex = 14;
            this.btndelete.Text = "DELETE";
            this.btndelete.UseVisualStyleBackColor = true;
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // btnupdate
            // 
            this.btnupdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnupdate.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnupdate.Location = new System.Drawing.Point(55, 147);
            this.btnupdate.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnupdate.Name = "btnupdate";
            this.btnupdate.Size = new System.Drawing.Size(108, 34);
            this.btnupdate.TabIndex = 13;
            this.btnupdate.Text = "UPDATE";
            this.btnupdate.UseVisualStyleBackColor = true;
            this.btnupdate.Click += new System.EventHandler(this.btnupdate_Click);
            // 
            // btnadd
            // 
            this.btnadd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnadd.Enabled = false;
            this.btnadd.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnadd.Location = new System.Drawing.Point(55, 103);
            this.btnadd.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(108, 34);
            this.btnadd.TabIndex = 12;
            this.btnadd.Text = "ADD";
            this.btnadd.UseVisualStyleBackColor = true;
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // btnupload
            // 
            this.btnupload.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnupload.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnupload.Location = new System.Drawing.Point(400, 272);
            this.btnupload.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnupload.Name = "btnupload";
            this.btnupload.Size = new System.Drawing.Size(155, 34);
            this.btnupload.TabIndex = 11;
            this.btnupload.Text = "UPLOAD";
            this.btnupload.UseVisualStyleBackColor = true;
            this.btnupload.Click += new System.EventHandler(this.btnupload_Click);
            // 
            // btnclear
            // 
            this.btnclear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnclear.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnclear.Location = new System.Drawing.Point(55, 288);
            this.btnclear.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnclear.Name = "btnclear";
            this.btnclear.Size = new System.Drawing.Size(108, 34);
            this.btnclear.TabIndex = 15;
            this.btnclear.Text = "CLEAR";
            this.btnclear.UseVisualStyleBackColor = true;
            this.btnclear.Click += new System.EventHandler(this.btnclear_Click);
            // 
            // status
            // 
            this.status.Tick += new System.EventHandler(this.status_Tick);
            // 
            // dttimeout
            // 
            this.dttimeout.CustomFormat = "hh:mm tt";
            this.dttimeout.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dttimeout.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dttimeout.Location = new System.Drawing.Point(152, 280);
            this.dttimeout.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dttimeout.Name = "dttimeout";
            this.dttimeout.Size = new System.Drawing.Size(204, 23);
            this.dttimeout.TabIndex = 6;
            this.dttimeout.Value = new System.DateTime(2021, 3, 5, 17, 0, 0, 0);
            // 
            // dttimein
            // 
            this.dttimein.CustomFormat = "hh:mm tt";
            this.dttimein.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dttimein.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dttimein.Location = new System.Drawing.Point(152, 247);
            this.dttimein.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dttimein.Name = "dttimein";
            this.dttimein.Size = new System.Drawing.Size(204, 23);
            this.dttimein.TabIndex = 5;
            this.dttimein.Value = new System.DateTime(2021, 3, 5, 8, 0, 0, 0);
            // 
            // cmbdepartment
            // 
            this.cmbdepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbdepartment.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbdepartment.FormattingEnabled = true;
            this.cmbdepartment.Location = new System.Drawing.Point(152, 213);
            this.cmbdepartment.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cmbdepartment.Name = "cmbdepartment";
            this.cmbdepartment.Size = new System.Drawing.Size(204, 24);
            this.cmbdepartment.TabIndex = 4;
            this.cmbdepartment.SelectedIndexChanged += new System.EventHandler(this.cmbdepartment_SelectedIndexChanged);
            this.cmbdepartment.MouseHover += new System.EventHandler(this.cmbdepartment_MouseHover);
            // 
            // txtfullname
            // 
            this.txtfullname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtfullname.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtfullname.Location = new System.Drawing.Point(152, 145);
            this.txtfullname.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtfullname.Name = "txtfullname";
            this.txtfullname.Size = new System.Drawing.Size(204, 23);
            this.txtfullname.TabIndex = 2;
            this.txtfullname.TextChanged += new System.EventHandler(this.txtfullname_TextChanged);
            // 
            // txtidnumber
            // 
            this.txtidnumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtidnumber.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtidnumber.Location = new System.Drawing.Point(152, 111);
            this.txtidnumber.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtidnumber.Name = "txtidnumber";
            this.txtidnumber.Size = new System.Drawing.Size(204, 23);
            this.txtidnumber.TabIndex = 1;
            this.txtidnumber.TextChanged += new System.EventHandler(this.txtidnumber_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(360, 104);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 17);
            this.label7.TabIndex = 32;
            this.label7.Text = "Photo";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(400, 111);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(155, 160);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 30;
            this.pictureBox1.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(27, 280);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(111, 17);
            this.label6.TabIndex = 26;
            this.label6.Text = "Desg Time Out:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(33, 247);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 17);
            this.label5.TabIndex = 28;
            this.label5.Text = "Desg. Time in:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(41, 213);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 17);
            this.label4.TabIndex = 27;
            this.label4.Text = "Department:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(50, 145);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 17);
            this.label2.TabIndex = 25;
            this.label2.Text = "Full Name:";
            // 
            // lblcardcode
            // 
            this.lblcardcode.AutoSize = true;
            this.lblcardcode.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcardcode.ForeColor = System.Drawing.Color.Black;
            this.lblcardcode.Location = new System.Drawing.Point(305, 18);
            this.lblcardcode.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblcardcode.Name = "lblcardcode";
            this.lblcardcode.Size = new System.Drawing.Size(45, 20);
            this.lblcardcode.TabIndex = 22;
            this.lblcardcode.Text = "------";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(153, 47);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(111, 20);
            this.label9.TabIndex = 24;
            this.label9.Text = "Card Status:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(36, 111);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 17);
            this.label1.TabIndex = 23;
            this.label1.Text = "RFID Number:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(153, 18);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(125, 20);
            this.label13.TabIndex = 51;
            this.label13.Text = "Card Number:";
            // 
            // lblcardstatus
            // 
            this.lblcardstatus.AutoSize = true;
            this.lblcardstatus.BackColor = System.Drawing.Color.White;
            this.lblcardstatus.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcardstatus.ForeColor = System.Drawing.Color.Black;
            this.lblcardstatus.Location = new System.Drawing.Point(305, 47);
            this.lblcardstatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblcardstatus.Name = "lblcardstatus";
            this.lblcardstatus.Size = new System.Drawing.Size(45, 20);
            this.lblcardstatus.TabIndex = 22;
            this.lblcardstatus.Text = "------";
            // 
            // btnclose
            // 
            this.btnclose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnclose.BackColor = System.Drawing.Color.Crimson;
            this.btnclose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnclose.FlatAppearance.BorderSize = 0;
            this.btnclose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnclose.Font = new System.Drawing.Font("Arial Rounded MT Bold", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnclose.ForeColor = System.Drawing.Color.White;
            this.btnclose.Location = new System.Drawing.Point(1172, 1);
            this.btnclose.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(22, 27);
            this.btnclose.TabIndex = 52;
            this.btnclose.Text = "X";
            this.btnclose.UseVisualStyleBackColor = false;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(52, 177);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(65, 17);
            this.label14.TabIndex = 53;
            this.label14.Text = "Birthday:";
            // 
            // dtbday
            // 
            this.dtbday.CustomFormat = "MMMM dd, yyyy";
            this.dtbday.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtbday.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtbday.Location = new System.Drawing.Point(152, 177);
            this.dtbday.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dtbday.Name = "dtbday";
            this.dtbday.Size = new System.Drawing.Size(204, 23);
            this.dtbday.TabIndex = 3;
            // 
            // rbwith
            // 
            this.rbwith.AutoSize = true;
            this.rbwith.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbwith.ForeColor = System.Drawing.Color.Black;
            this.rbwith.Location = new System.Drawing.Point(152, 314);
            this.rbwith.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.rbwith.Name = "rbwith";
            this.rbwith.Size = new System.Drawing.Size(139, 21);
            this.rbwith.TabIndex = 7;
            this.rbwith.TabStop = true;
            this.rbwith.Text = "With noon break";
            this.rbwith.UseVisualStyleBackColor = true;
            this.rbwith.CheckedChanged += new System.EventHandler(this.rbwith_CheckedChanged);
            // 
            // rbwithout
            // 
            this.rbwithout.AutoSize = true;
            this.rbwithout.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbwithout.ForeColor = System.Drawing.Color.Black;
            this.rbwithout.Location = new System.Drawing.Point(152, 342);
            this.rbwithout.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.rbwithout.Name = "rbwithout";
            this.rbwithout.Size = new System.Drawing.Size(150, 21);
            this.rbwithout.TabIndex = 8;
            this.rbwithout.TabStop = true;
            this.rbwithout.Text = "W/out noon break";
            this.rbwithout.UseVisualStyleBackColor = true;
            this.rbwithout.CheckedChanged += new System.EventHandler(this.rbwithout_CheckedChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(11, 314);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(132, 17);
            this.label15.TabIndex = 26;
            this.label15.Text = "Noon break status:";
            // 
            // txtnoon
            // 
            this.txtnoon.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtnoon.Location = new System.Drawing.Point(152, 366);
            this.txtnoon.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtnoon.Name = "txtnoon";
            this.txtnoon.ReadOnly = true;
            this.txtnoon.Size = new System.Drawing.Size(204, 22);
            this.txtnoon.TabIndex = 9;
            // 
            // Automatic
            // 
            this.Automatic.Tick += new System.EventHandler(this.Automatic_Tick);
            // 
            // StopCaptureButton
            // 
            this.StopCaptureButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.StopCaptureButton.Enabled = false;
            this.StopCaptureButton.Location = new System.Drawing.Point(178, 143);
            this.StopCaptureButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.StopCaptureButton.Name = "StopCaptureButton";
            this.StopCaptureButton.Size = new System.Drawing.Size(110, 42);
            this.StopCaptureButton.TabIndex = 54;
            this.StopCaptureButton.Text = "Stop Capture";
            this.StopCaptureButton.UseVisualStyleBackColor = true;
            this.StopCaptureButton.Click += new System.EventHandler(this.StopCaptureButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.Controls.Add(this.ClearButton);
            this.groupBox1.Controls.Add(this.MissingCardCheckBox);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.lblcardstatus);
            this.groupBox1.Controls.Add(this.lblcardcode);
            this.groupBox1.Controls.Add(this.btnstatus);
            this.groupBox1.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(69, 12);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox1.Size = new System.Drawing.Size(860, 105);
            this.groupBox1.TabIndex = 55;
            this.groupBox1.TabStop = false;
            // 
            // ClearButton
            // 
            this.ClearButton.BackColor = System.Drawing.Color.Crimson;
            this.ClearButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ClearButton.FlatAppearance.BorderSize = 0;
            this.ClearButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClearButton.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearButton.ForeColor = System.Drawing.Color.White;
            this.ClearButton.Location = new System.Drawing.Point(4, 58);
            this.ClearButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(140, 41);
            this.ClearButton.TabIndex = 58;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = false;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // MissingCardCheckBox
            // 
            this.MissingCardCheckBox.AutoSize = true;
            this.MissingCardCheckBox.Enabled = false;
            this.MissingCardCheckBox.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MissingCardCheckBox.ForeColor = System.Drawing.Color.Black;
            this.MissingCardCheckBox.Location = new System.Drawing.Point(152, 77);
            this.MissingCardCheckBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MissingCardCheckBox.Name = "MissingCardCheckBox";
            this.MissingCardCheckBox.Size = new System.Drawing.Size(115, 21);
            this.MissingCardCheckBox.TabIndex = 57;
            this.MissingCardCheckBox.Text = "Missing card";
            this.MissingCardCheckBox.UseVisualStyleBackColor = true;
            this.MissingCardCheckBox.CheckedChanged += new System.EventHandler(this.MissingCardCheckBox_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox4.Controls.Add(this.groupBox6);
            this.groupBox4.Controls.Add(this.groupBox5);
            this.groupBox4.Controls.Add(this.UniqueIDLabel);
            this.groupBox4.Controls.Add(this.SearchedListBox);
            this.groupBox4.Controls.Add(this.SearchTextbox);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.SearchButton);
            this.groupBox4.Controls.Add(this.dttimeout);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.dttimein);
            this.groupBox4.Controls.Add(this.btnupload);
            this.groupBox4.Controls.Add(this.pictureBox1);
            this.groupBox4.Controls.Add(this.cmbdepartment);
            this.groupBox4.Controls.Add(this.txtnoon);
            this.groupBox4.Controls.Add(this.txtfullname);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.txtidnumber);
            this.groupBox4.Controls.Add(this.rbwithout);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.rbwith);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.dtbday);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Enabled = false;
            this.groupBox4.Location = new System.Drawing.Point(69, 117);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox4.Size = new System.Drawing.Size(864, 599);
            this.groupBox4.TabIndex = 55;
            this.groupBox4.TabStop = false;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.StatusLabel);
            this.groupBox6.Controls.Add(this.label21);
            this.groupBox6.Controls.Add(this.FingerStatusLabel);
            this.groupBox6.Controls.Add(this.label20);
            this.groupBox6.Controls.Add(this.StopButton);
            this.groupBox6.Controls.Add(this.FingerprintDriverText);
            this.groupBox6.Controls.Add(this.label18);
            this.groupBox6.Controls.Add(this.FingerPrintButton);
            this.groupBox6.Controls.Add(this.FingerPrintPicturebox);
            this.groupBox6.Controls.Add(this.label17);
            this.groupBox6.Location = new System.Drawing.Point(507, 320);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(352, 267);
            this.groupBox6.TabIndex = 63;
            this.groupBox6.TabStop = false;
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.BackColor = System.Drawing.Color.White;
            this.StatusLabel.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusLabel.ForeColor = System.Drawing.Color.Black;
            this.StatusLabel.Location = new System.Drawing.Point(157, 149);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(44, 19);
            this.StatusLabel.TabIndex = 68;
            this.StatusLabel.Text = "-----";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.Black;
            this.label21.Location = new System.Drawing.Point(158, 131);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(53, 18);
            this.label21.TabIndex = 67;
            this.label21.Text = "Status:";
            // 
            // FingerStatusLabel
            // 
            this.FingerStatusLabel.AutoSize = true;
            this.FingerStatusLabel.BackColor = System.Drawing.Color.White;
            this.FingerStatusLabel.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FingerStatusLabel.ForeColor = System.Drawing.Color.Black;
            this.FingerStatusLabel.Location = new System.Drawing.Point(157, 105);
            this.FingerStatusLabel.Name = "FingerStatusLabel";
            this.FingerStatusLabel.Size = new System.Drawing.Size(44, 19);
            this.FingerStatusLabel.TabIndex = 66;
            this.FingerStatusLabel.Text = "-----";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.Black;
            this.label20.Location = new System.Drawing.Point(157, 77);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(132, 18);
            this.label20.TabIndex = 65;
            this.label20.Text = "FingerPrint Status:";
            // 
            // StopButton
            // 
            this.StopButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.StopButton.Enabled = false;
            this.StopButton.Location = new System.Drawing.Point(8, 222);
            this.StopButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(108, 42);
            this.StopButton.TabIndex = 64;
            this.StopButton.Text = "Stop Capture";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // FingerprintDriverText
            // 
            this.FingerprintDriverText.Enabled = false;
            this.FingerprintDriverText.FormattingEnabled = true;
            this.FingerprintDriverText.Location = new System.Drawing.Point(129, 15);
            this.FingerprintDriverText.Name = "FingerprintDriverText";
            this.FingerprintDriverText.Size = new System.Drawing.Size(210, 24);
            this.FingerprintDriverText.TabIndex = 63;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.Black;
            this.label18.Location = new System.Drawing.Point(5, 16);
            this.label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(119, 17);
            this.label18.TabIndex = 62;
            this.label18.Text = "Fingerprint driver";
            // 
            // FingerPrintButton
            // 
            this.FingerPrintButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FingerPrintButton.Location = new System.Drawing.Point(8, 174);
            this.FingerPrintButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.FingerPrintButton.Name = "FingerPrintButton";
            this.FingerPrintButton.Size = new System.Drawing.Size(108, 42);
            this.FingerPrintButton.TabIndex = 58;
            this.FingerPrintButton.Text = "Capture Finger";
            this.FingerPrintButton.UseVisualStyleBackColor = true;
            this.FingerPrintButton.Click += new System.EventHandler(this.FingerPrintButton_Click);
            // 
            // FingerPrintPicturebox
            // 
            this.FingerPrintPicturebox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.FingerPrintPicturebox.Location = new System.Drawing.Point(8, 68);
            this.FingerPrintPicturebox.Name = "FingerPrintPicturebox";
            this.FingerPrintPicturebox.Size = new System.Drawing.Size(108, 100);
            this.FingerPrintPicturebox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.FingerPrintPicturebox.TabIndex = 59;
            this.FingerPrintPicturebox.TabStop = false;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(5, 43);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(145, 17);
            this.label17.TabIndex = 60;
            this.label17.Text = "Captured Fingerprint";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Controls.Add(this.imageBoxFrameGrabber);
            this.groupBox5.Controls.Add(this.LabelStatus);
            this.groupBox5.Controls.Add(this.btnCameraOn);
            this.groupBox5.Controls.Add(this.imageBox1);
            this.groupBox5.Controls.Add(this.label16);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.StopCaptureButton);
            this.groupBox5.Location = new System.Drawing.Point(9, 388);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(496, 199);
            this.groupBox5.TabIndex = 62;
            this.groupBox5.TabStop = false;
            this.groupBox5.Visible = false;
            // 
            // UniqueIDLabel
            // 
            this.UniqueIDLabel.AutoSize = true;
            this.UniqueIDLabel.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UniqueIDLabel.ForeColor = System.Drawing.Color.LightGreen;
            this.UniqueIDLabel.Location = new System.Drawing.Point(134, 111);
            this.UniqueIDLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.UniqueIDLabel.Name = "UniqueIDLabel";
            this.UniqueIDLabel.Size = new System.Drawing.Size(14, 17);
            this.UniqueIDLabel.TabIndex = 57;
            this.UniqueIDLabel.Text = "-";
            // 
            // SearchedListBox
            // 
            this.SearchedListBox.FormattingEnabled = true;
            this.SearchedListBox.ItemHeight = 16;
            this.SearchedListBox.Location = new System.Drawing.Point(152, 44);
            this.SearchedListBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.SearchedListBox.Name = "SearchedListBox";
            this.SearchedListBox.Size = new System.Drawing.Size(260, 52);
            this.SearchedListBox.TabIndex = 56;
            this.SearchedListBox.Visible = false;
            this.SearchedListBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SearchedListBox_MouseClick);
            this.SearchedListBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SearchedListBox_KeyDown);
            // 
            // SearchButton
            // 
            this.SearchButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SearchButton.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchButton.Location = new System.Drawing.Point(416, 17);
            this.SearchButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(79, 28);
            this.SearchButton.TabIndex = 55;
            this.SearchButton.Text = "Search";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox3.Controls.Add(this.btnadd);
            this.groupBox3.Controls.Add(this.btnclear);
            this.groupBox3.Controls.Add(this.btnupdate);
            this.groupBox3.Controls.Add(this.btndelete);
            this.groupBox3.Enabled = false;
            this.groupBox3.Location = new System.Drawing.Point(938, 13);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox3.Size = new System.Drawing.Size(219, 424);
            this.groupBox3.TabIndex = 56;
            this.groupBox3.TabStop = false;
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1196, 728);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnclose);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("Arial Narrow", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "Register";
            this.Text = "Register";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Register_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Register_FormClosed);
            this.Load += new System.EventHandler(this.Register_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxFrameGrabber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FingerPrintPicturebox)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnCameraOn;
        private System.Windows.Forms.Label LabelRFID;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblcounter;
        private System.Windows.Forms.Label label12;
        private Emgu.CV.UI.ImageBox imageBox1;
        private Emgu.CV.UI.ImageBox imageBoxFrameGrabber;
        private System.Windows.Forms.Button btnstatus;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox SearchTextbox;
        private System.Windows.Forms.Button btndelete;
        private System.Windows.Forms.Button btnupdate;
        private System.Windows.Forms.Button btnadd;
        private System.Windows.Forms.Button btnupload;
        private System.Windows.Forms.Button btnclear;
        private System.Windows.Forms.Timer status;
        private System.Windows.Forms.DateTimePicker dttimeout;
        private System.Windows.Forms.DateTimePicker dttimein;
        private System.Windows.Forms.ComboBox cmbdepartment;
        private System.Windows.Forms.TextBox txtfullname;
        private System.Windows.Forms.TextBox txtidnumber;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblcardcode;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblcardstatus;
        private System.Windows.Forms.Button btnclose;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DateTimePicker dtbday;
        private System.Windows.Forms.RadioButton rbwith;
        private System.Windows.Forms.RadioButton rbwithout;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtnoon;
        private System.Windows.Forms.Timer Automatic;
        private System.Windows.Forms.Label LabelStatus;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button StopCaptureButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.ListBox SearchedListBox;
        private System.Windows.Forms.CheckBox MissingCardCheckBox;
        private System.Windows.Forms.Label UniqueIDLabel;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.PictureBox FingerPrintPicturebox;
        private System.Windows.Forms.Button FingerPrintButton;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ComboBox FingerprintDriverText;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.Label FingerStatusLabel;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label StatusLabel;
    }
}