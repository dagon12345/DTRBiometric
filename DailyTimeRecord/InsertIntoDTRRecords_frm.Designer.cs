namespace DailyTimeRecord
{
    partial class InsertIntoDTRRecords_frm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InsertIntoDTRRecords_frm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnrefresh = new System.Windows.Forms.Button();
            this.txtsearch = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.OvertimeHoursText = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.NoonStatusText = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtremarks = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.clear_btn = new System.Windows.Forms.Button();
            this.delete_btn = new System.Windows.Forms.Button();
            this.add_btn = new System.Windows.Forms.Button();
            this.totalhours_txt = new System.Windows.Forms.TextBox();
            this.timeout_dt = new System.Windows.Forms.DateTimePicker();
            this.timein_dt = new System.Windows.Forms.DateTimePicker();
            this.department_txt = new System.Windows.Forms.TextBox();
            this.fullname_txt = new System.Windows.Forms.TextBox();
            this.idnumber_cmb = new System.Windows.Forms.ComboBox();
            this.date_dt = new System.Windows.Forms.DateTimePicker();
            this.lblstatus = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.FormulaTimer = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnrefresh);
            this.groupBox1.Controls.Add(this.txtsearch);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(12, 443);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1059, 256);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnrefresh
            // 
            this.btnrefresh.Location = new System.Drawing.Point(344, 16);
            this.btnrefresh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnrefresh.Name = "btnrefresh";
            this.btnrefresh.Size = new System.Drawing.Size(181, 35);
            this.btnrefresh.TabIndex = 11;
            this.btnrefresh.Text = "Refresh";
            this.btnrefresh.UseVisualStyleBackColor = true;
            this.btnrefresh.Click += new System.EventHandler(this.btnrefresh_Click);
            // 
            // txtsearch
            // 
            this.txtsearch.Location = new System.Drawing.Point(94, 22);
            this.txtsearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtsearch.Name = "txtsearch";
            this.txtsearch.Size = new System.Drawing.Size(212, 22);
            this.txtsearch.TabIndex = 10;
            this.txtsearch.TextChanged += new System.EventHandler(this.txtsearch_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(14, 25);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(57, 17);
            this.label11.TabIndex = 9;
            this.label11.Text = "Search:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 74);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1040, 162);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.OvertimeHoursText);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.NoonStatusText);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtremarks);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.clear_btn);
            this.groupBox2.Controls.Add(this.delete_btn);
            this.groupBox2.Controls.Add(this.add_btn);
            this.groupBox2.Controls.Add(this.totalhours_txt);
            this.groupBox2.Controls.Add(this.timeout_dt);
            this.groupBox2.Controls.Add(this.timein_dt);
            this.groupBox2.Controls.Add(this.department_txt);
            this.groupBox2.Controls.Add(this.fullname_txt);
            this.groupBox2.Controls.Add(this.idnumber_cmb);
            this.groupBox2.Controls.Add(this.date_dt);
            this.groupBox2.Controls.Add(this.lblstatus);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(12, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1059, 434);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // OvertimeHoursText
            // 
            this.OvertimeHoursText.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OvertimeHoursText.Location = new System.Drawing.Point(695, 192);
            this.OvertimeHoursText.Name = "OvertimeHoursText";
            this.OvertimeHoursText.Size = new System.Drawing.Size(60, 22);
            this.OvertimeHoursText.TabIndex = 7;
            this.OvertimeHoursText.Text = "0";
            this.OvertimeHoursText.Leave += new System.EventHandler(this.OvertimeHoursText_Leave);
            this.OvertimeHoursText.MouseLeave += new System.EventHandler(this.OvertimeHoursText_MouseLeave);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(542, 192);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(135, 19);
            this.label10.TabIndex = 16;
            this.label10.Text = "OvertimeHours:";
            // 
            // NoonStatusText
            // 
            this.NoonStatusText.Location = new System.Drawing.Point(206, 186);
            this.NoonStatusText.Name = "NoonStatusText";
            this.NoonStatusText.ReadOnly = true;
            this.NoonStatusText.Size = new System.Drawing.Size(297, 22);
            this.NoonStatusText.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(19, 187);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(162, 19);
            this.label9.TabIndex = 14;
            this.label9.Text = "Noon Break Status:";
            // 
            // txtremarks
            // 
            this.txtremarks.Location = new System.Drawing.Point(668, 285);
            this.txtremarks.Multiline = true;
            this.txtremarks.Name = "txtremarks";
            this.txtremarks.Size = new System.Drawing.Size(251, 90);
            this.txtremarks.TabIndex = 8;
            this.txtremarks.Text = "NONE";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 394);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(291, 34);
            this.button1.TabIndex = 12;
            this.button1.Text = "View Employee\'s with no time-out";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // clear_btn
            // 
            this.clear_btn.Location = new System.Drawing.Point(206, 222);
            this.clear_btn.Name = "clear_btn";
            this.clear_btn.Size = new System.Drawing.Size(91, 26);
            this.clear_btn.TabIndex = 11;
            this.clear_btn.Text = "CLEAR";
            this.clear_btn.UseVisualStyleBackColor = true;
            this.clear_btn.Click += new System.EventHandler(this.clear_btn_Click);
            // 
            // delete_btn
            // 
            this.delete_btn.Location = new System.Drawing.Point(206, 325);
            this.delete_btn.Name = "delete_btn";
            this.delete_btn.Size = new System.Drawing.Size(144, 34);
            this.delete_btn.TabIndex = 10;
            this.delete_btn.Text = "DELETE";
            this.delete_btn.UseVisualStyleBackColor = true;
            this.delete_btn.Click += new System.EventHandler(this.delete_btn_Click);
            // 
            // add_btn
            // 
            this.add_btn.Location = new System.Drawing.Point(206, 285);
            this.add_btn.Name = "add_btn";
            this.add_btn.Size = new System.Drawing.Size(144, 34);
            this.add_btn.TabIndex = 9;
            this.add_btn.Text = "ADD";
            this.add_btn.UseVisualStyleBackColor = true;
            this.add_btn.Click += new System.EventHandler(this.add_btn_Click);
            // 
            // totalhours_txt
            // 
            this.totalhours_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalhours_txt.Location = new System.Drawing.Point(695, 120);
            this.totalhours_txt.Name = "totalhours_txt";
            this.totalhours_txt.Size = new System.Drawing.Size(60, 22);
            this.totalhours_txt.TabIndex = 6;
            this.totalhours_txt.Text = "8";
            this.totalhours_txt.TextChanged += new System.EventHandler(this.totalhours_txt_TextChanged);
            this.totalhours_txt.Leave += new System.EventHandler(this.totalhours_txt_Leave);
            // 
            // timeout_dt
            // 
            this.timeout_dt.CustomFormat = "MM/dd/yyyy hh:mm tt ";
            this.timeout_dt.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.timeout_dt.Location = new System.Drawing.Point(695, 79);
            this.timeout_dt.Name = "timeout_dt";
            this.timeout_dt.Size = new System.Drawing.Size(251, 22);
            this.timeout_dt.TabIndex = 6;
            this.timeout_dt.Value = new System.DateTime(2021, 6, 8, 0, 0, 0, 0);
            // 
            // timein_dt
            // 
            this.timein_dt.CustomFormat = "MM/dd/yyyy hh:mm tt ";
            this.timein_dt.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.timein_dt.Location = new System.Drawing.Point(695, 45);
            this.timein_dt.Name = "timein_dt";
            this.timein_dt.Size = new System.Drawing.Size(251, 22);
            this.timein_dt.TabIndex = 5;
            this.timein_dt.Value = new System.DateTime(2021, 6, 8, 0, 0, 0, 0);
            // 
            // department_txt
            // 
            this.department_txt.Location = new System.Drawing.Point(206, 154);
            this.department_txt.Name = "department_txt";
            this.department_txt.ReadOnly = true;
            this.department_txt.Size = new System.Drawing.Size(297, 22);
            this.department_txt.TabIndex = 3;
            // 
            // fullname_txt
            // 
            this.fullname_txt.Location = new System.Drawing.Point(206, 118);
            this.fullname_txt.Name = "fullname_txt";
            this.fullname_txt.ReadOnly = true;
            this.fullname_txt.Size = new System.Drawing.Size(297, 22);
            this.fullname_txt.TabIndex = 2;
            this.fullname_txt.TextChanged += new System.EventHandler(this.fullname_txt_TextChanged);
            // 
            // idnumber_cmb
            // 
            this.idnumber_cmb.FormattingEnabled = true;
            this.idnumber_cmb.Location = new System.Drawing.Point(206, 79);
            this.idnumber_cmb.Name = "idnumber_cmb";
            this.idnumber_cmb.Size = new System.Drawing.Size(297, 24);
            this.idnumber_cmb.TabIndex = 1;
            this.idnumber_cmb.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.idnumber_cmb.TextChanged += new System.EventHandler(this.idnumber_cmb_TextChanged);
            // 
            // date_dt
            // 
            this.date_dt.CalendarFont = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.date_dt.CustomFormat = "MMMM dd, yyyy";
            this.date_dt.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.date_dt.Location = new System.Drawing.Point(206, 44);
            this.date_dt.Name = "date_dt";
            this.date_dt.Size = new System.Drawing.Size(297, 22);
            this.date_dt.TabIndex = 0;
            this.date_dt.ValueChanged += new System.EventHandler(this.date_dt_ValueChanged);
            // 
            // lblstatus
            // 
            this.lblstatus.AutoSize = true;
            this.lblstatus.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblstatus.Location = new System.Drawing.Point(691, 151);
            this.lblstatus.Name = "lblstatus";
            this.lblstatus.Size = new System.Drawing.Size(64, 21);
            this.lblstatus.TabIndex = 2;
            this.lblstatus.Text = "(Status)";
            this.lblstatus.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(565, 285);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 19);
            this.label8.TabIndex = 2;
            this.label8.Text = "Remarks:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(580, 119);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 19);
            this.label7.TabIndex = 2;
            this.label7.Text = "TotalHours:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(597, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 19);
            this.label6.TabIndex = 2;
            this.label6.Text = "TimeOut:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(610, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 19);
            this.label5.TabIndex = 2;
            this.label5.Text = "TimeIn:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(72, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 19);
            this.label4.TabIndex = 2;
            this.label4.Text = "Department:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(90, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "FullName:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(84, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "IDNumber:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(129, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "Date:";
            // 
            // FormulaTimer
            // 
            this.FormulaTimer.Tick += new System.EventHandler(this.FormulaTimer_Tick);
            // 
            // InsertIntoDTRRecords_frm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1083, 711);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "InsertIntoDTRRecords_frm";
            this.Text = "InsertIntoDTRRecords_frm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.InsertIntoDTRRecords_frm_FormClosed);
            this.Load += new System.EventHandler(this.InsertIntoDTRRecords_frm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker date_dt;
        private System.Windows.Forms.DateTimePicker timein_dt;
        private System.Windows.Forms.TextBox department_txt;
        private System.Windows.Forms.TextBox fullname_txt;
        private System.Windows.Forms.ComboBox idnumber_cmb;
        private System.Windows.Forms.TextBox totalhours_txt;
        private System.Windows.Forms.DateTimePicker timeout_dt;
        private System.Windows.Forms.Button clear_btn;
        private System.Windows.Forms.Button delete_btn;
        private System.Windows.Forms.Button add_btn;
        private System.Windows.Forms.Timer FormulaTimer;
        private System.Windows.Forms.Label lblstatus;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtremarks;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox NoonStatusText;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox OvertimeHoursText;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnrefresh;
        private System.Windows.Forms.TextBox txtsearch;
        private System.Windows.Forms.Label label11;
    }
}