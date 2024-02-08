
namespace DailyTimeRecord
{
    partial class ReadCard_frm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReadCard_frm));
            this.txtrfidnumber = new System.Windows.Forms.TextBox();
            this.EmployeePicture = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblemployeename = new System.Windows.Forms.Label();
            this.lbldepartment = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ReadCardButton = new System.Windows.Forms.Button();
            this.ClearButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.EmployeePicture)).BeginInit();
            this.SuspendLayout();
            // 
            // txtrfidnumber
            // 
            this.txtrfidnumber.BackColor = System.Drawing.Color.Black;
            this.txtrfidnumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtrfidnumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtrfidnumber.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtrfidnumber.ForeColor = System.Drawing.Color.Yellow;
            this.txtrfidnumber.Location = new System.Drawing.Point(12, 12);
            this.txtrfidnumber.Name = "txtrfidnumber";
            this.txtrfidnumber.ReadOnly = true;
            this.txtrfidnumber.Size = new System.Drawing.Size(585, 37);
            this.txtrfidnumber.TabIndex = 1;
            this.txtrfidnumber.TabStop = false;
            this.txtrfidnumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // EmployeePicture
            // 
            this.EmployeePicture.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.EmployeePicture.Location = new System.Drawing.Point(12, 73);
            this.EmployeePicture.Name = "EmployeePicture";
            this.EmployeePicture.Size = new System.Drawing.Size(173, 147);
            this.EmployeePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.EmployeePicture.TabIndex = 2;
            this.EmployeePicture.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(191, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 21);
            this.label5.TabIndex = 3;
            this.label5.Text = "Name";
            // 
            // lblemployeename
            // 
            this.lblemployeename.AutoSize = true;
            this.lblemployeename.BackColor = System.Drawing.Color.White;
            this.lblemployeename.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblemployeename.ForeColor = System.Drawing.Color.Green;
            this.lblemployeename.Location = new System.Drawing.Point(191, 101);
            this.lblemployeename.Name = "lblemployeename";
            this.lblemployeename.Size = new System.Drawing.Size(86, 23);
            this.lblemployeename.TabIndex = 4;
            this.lblemployeename.Text = "(Name)";
            // 
            // lbldepartment
            // 
            this.lbldepartment.AutoSize = true;
            this.lbldepartment.BackColor = System.Drawing.Color.White;
            this.lbldepartment.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldepartment.ForeColor = System.Drawing.Color.Green;
            this.lbldepartment.Location = new System.Drawing.Point(191, 157);
            this.lbldepartment.Name = "lbldepartment";
            this.lbldepartment.Size = new System.Drawing.Size(141, 23);
            this.lbldepartment.TabIndex = 5;
            this.lbldepartment.Text = "(Department)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(191, 129);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 21);
            this.label6.TabIndex = 6;
            this.label6.Text = "Department";
            // 
            // ReadCardButton
            // 
            this.ReadCardButton.BackColor = System.Drawing.Color.SeaGreen;
            this.ReadCardButton.FlatAppearance.BorderSize = 0;
            this.ReadCardButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ReadCardButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReadCardButton.ForeColor = System.Drawing.Color.White;
            this.ReadCardButton.Location = new System.Drawing.Point(12, 254);
            this.ReadCardButton.Name = "ReadCardButton";
            this.ReadCardButton.Size = new System.Drawing.Size(173, 47);
            this.ReadCardButton.TabIndex = 7;
            this.ReadCardButton.Text = "Read Card";
            this.ReadCardButton.UseVisualStyleBackColor = false;
            this.ReadCardButton.Click += new System.EventHandler(this.ReadCardButton_Click);
            // 
            // ClearButton
            // 
            this.ClearButton.BackColor = System.Drawing.Color.SeaGreen;
            this.ClearButton.FlatAppearance.BorderSize = 0;
            this.ClearButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClearButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearButton.ForeColor = System.Drawing.Color.White;
            this.ClearButton.Location = new System.Drawing.Point(12, 313);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(173, 47);
            this.ClearButton.TabIndex = 8;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = false;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // ReadCard_frm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(609, 372);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.ReadCardButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblemployeename);
            this.Controls.Add(this.lbldepartment);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.EmployeePicture);
            this.Controls.Add(this.txtrfidnumber);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(627, 419);
            this.MinimumSize = new System.Drawing.Size(627, 419);
            this.Name = "ReadCard_frm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReadCard_frm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ReadCard_frm_FormClosed);
            this.Load += new System.EventHandler(this.ReadCard_frm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.EmployeePicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtrfidnumber;
        private System.Windows.Forms.PictureBox EmployeePicture;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label lblemployeename;
        private System.Windows.Forms.Label lbldepartment;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button ReadCardButton;
        private System.Windows.Forms.Button ClearButton;
    }
}