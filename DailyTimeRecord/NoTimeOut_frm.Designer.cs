namespace DailyTimeRecord
{
    partial class NoTimeOut_frm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NoTimeOut_frm));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtsearch = new System.Windows.Forms.TextBox();
            this.btndelete = new System.Windows.Forms.Button();
            this.btnrefresh = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.timein_dt = new System.Windows.Forms.DateTimePicker();
            this.fullname_txt = new System.Windows.Forms.TextBox();
            this.idnumber_cmb = new System.Windows.Forms.ComboBox();
            this.date_dt = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.update_btn = new System.Windows.Forms.Button();
            this.add_btn = new System.Windows.Forms.Button();
            this.Clear_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
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
            this.dataGridView1.Location = new System.Drawing.Point(14, 307);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(754, 273);
            this.dataGridView1.TabIndex = 9;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 240);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Search:";
            // 
            // txtsearch
            // 
            this.txtsearch.Location = new System.Drawing.Point(92, 237);
            this.txtsearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtsearch.Name = "txtsearch";
            this.txtsearch.Size = new System.Drawing.Size(212, 26);
            this.txtsearch.TabIndex = 7;
            this.txtsearch.TextChanged += new System.EventHandler(this.txtsearch_TextChanged);
            // 
            // btndelete
            // 
            this.btndelete.Location = new System.Drawing.Point(458, 121);
            this.btndelete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(158, 41);
            this.btndelete.TabIndex = 7;
            this.btndelete.Text = "Delete";
            this.btndelete.UseVisualStyleBackColor = true;
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // btnrefresh
            // 
            this.btnrefresh.Location = new System.Drawing.Point(92, 268);
            this.btnrefresh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnrefresh.Name = "btnrefresh";
            this.btnrefresh.Size = new System.Drawing.Size(181, 35);
            this.btnrefresh.TabIndex = 8;
            this.btnrefresh.Text = "Refresh";
            this.btnrefresh.UseVisualStyleBackColor = true;
            this.btnrefresh.Click += new System.EventHandler(this.btnrefresh_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(14, 591);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(181, 41);
            this.button1.TabIndex = 4;
            this.button1.Text = "Insert into dtr records";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // timein_dt
            // 
            this.timein_dt.CustomFormat = "MM/dd/yyyy hh:mm tt";
            this.timein_dt.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.timein_dt.Location = new System.Drawing.Point(131, 136);
            this.timein_dt.Name = "timein_dt";
            this.timein_dt.Size = new System.Drawing.Size(297, 26);
            this.timein_dt.TabIndex = 3;
            this.timein_dt.Value = new System.DateTime(2021, 6, 8, 0, 0, 0, 0);
            // 
            // fullname_txt
            // 
            this.fullname_txt.Location = new System.Drawing.Point(131, 95);
            this.fullname_txt.Name = "fullname_txt";
            this.fullname_txt.ReadOnly = true;
            this.fullname_txt.Size = new System.Drawing.Size(297, 26);
            this.fullname_txt.TabIndex = 2;
            // 
            // idnumber_cmb
            // 
            this.idnumber_cmb.FormattingEnabled = true;
            this.idnumber_cmb.Location = new System.Drawing.Point(131, 56);
            this.idnumber_cmb.Name = "idnumber_cmb";
            this.idnumber_cmb.Size = new System.Drawing.Size(297, 28);
            this.idnumber_cmb.TabIndex = 1;
            this.idnumber_cmb.SelectedIndexChanged += new System.EventHandler(this.idnumber_cmb_SelectedIndexChanged);
            this.idnumber_cmb.TextChanged += new System.EventHandler(this.idnumber_cmb_TextChanged);
            // 
            // date_dt
            // 
            this.date_dt.CalendarFont = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.date_dt.CustomFormat = "MMMM dd, yyyy";
            this.date_dt.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.date_dt.Location = new System.Drawing.Point(131, 21);
            this.date_dt.Name = "date_dt";
            this.date_dt.Size = new System.Drawing.Size(297, 26);
            this.date_dt.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(39, 141);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 19);
            this.label5.TabIndex = 9;
            this.label5.Text = "TimeIn:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 19);
            this.label3.TabIndex = 10;
            this.label3.Text = "FullName:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 19);
            this.label2.TabIndex = 11;
            this.label2.Text = "IDNumber:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(54, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 19);
            this.label4.TabIndex = 12;
            this.label4.Text = "Date:";
            // 
            // update_btn
            // 
            this.update_btn.Enabled = false;
            this.update_btn.Location = new System.Drawing.Point(458, 71);
            this.update_btn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.update_btn.Name = "update_btn";
            this.update_btn.Size = new System.Drawing.Size(158, 41);
            this.update_btn.TabIndex = 6;
            this.update_btn.Text = "Update";
            this.update_btn.UseVisualStyleBackColor = true;
            this.update_btn.Click += new System.EventHandler(this.update_btn_Click);
            // 
            // add_btn
            // 
            this.add_btn.Location = new System.Drawing.Point(458, 22);
            this.add_btn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.add_btn.Name = "add_btn";
            this.add_btn.Size = new System.Drawing.Size(158, 41);
            this.add_btn.TabIndex = 5;
            this.add_btn.Text = "INSERT";
            this.add_btn.UseVisualStyleBackColor = true;
            this.add_btn.Click += new System.EventHandler(this.add_btn_Click);
            // 
            // Clear_btn
            // 
            this.Clear_btn.Location = new System.Drawing.Point(131, 171);
            this.Clear_btn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Clear_btn.Name = "Clear_btn";
            this.Clear_btn.Size = new System.Drawing.Size(158, 41);
            this.Clear_btn.TabIndex = 4;
            this.Clear_btn.Text = "Clear";
            this.Clear_btn.UseVisualStyleBackColor = true;
            this.Clear_btn.Click += new System.EventHandler(this.Clear_btn_Click);
            // 
            // NoTimeOut_frm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(781, 645);
            this.Controls.Add(this.Clear_btn);
            this.Controls.Add(this.add_btn);
            this.Controls.Add(this.update_btn);
            this.Controls.Add(this.timein_dt);
            this.Controls.Add(this.fullname_txt);
            this.Controls.Add(this.idnumber_cmb);
            this.Controls.Add(this.date_dt);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnrefresh);
            this.Controls.Add(this.btndelete);
            this.Controls.Add(this.txtsearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "NoTimeOut_frm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "No time-out";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.NoTimeOut_frm_FormClosed);
            this.Load += new System.EventHandler(this.NoTimeOut_frm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtsearch;
        private System.Windows.Forms.Button btndelete;
        private System.Windows.Forms.Button btnrefresh;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker timein_dt;
        private System.Windows.Forms.TextBox fullname_txt;
        private System.Windows.Forms.ComboBox idnumber_cmb;
        private System.Windows.Forms.DateTimePicker date_dt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button update_btn;
        private System.Windows.Forms.Button add_btn;
        private System.Windows.Forms.Button Clear_btn;
    }
}