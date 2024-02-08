namespace DailyTimeRecord
{
    partial class ActivityLogs_frm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ActivityLogs_frm));
            this.dglogs = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.AutoRefresh = new System.Windows.Forms.Timer(this.components);
            this.btndelete = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dglogs)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dglogs
            // 
            this.dglogs.AllowUserToAddRows = false;
            this.dglogs.AllowUserToDeleteRows = false;
            this.dglogs.AllowUserToOrderColumns = true;
            this.dglogs.BackgroundColor = System.Drawing.Color.White;
            this.dglogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dglogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dglogs.Location = new System.Drawing.Point(3, 22);
            this.dglogs.Name = "dglogs";
            this.dglogs.ReadOnly = true;
            this.dglogs.RowHeadersWidth = 51;
            this.dglogs.RowTemplate.Height = 24;
            this.dglogs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dglogs.Size = new System.Drawing.Size(877, 489);
            this.dglogs.TabIndex = 0;
            this.dglogs.SelectionChanged += new System.EventHandler(this.dglogs_SelectionChanged);
            this.dglogs.MouseLeave += new System.EventHandler(this.dglogs_MouseLeave);
            this.dglogs.MouseHover += new System.EventHandler(this.dglogs_MouseHover);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.dglogs);
            this.groupBox2.Location = new System.Drawing.Point(6, 87);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(883, 514);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // AutoRefresh
            // 
            this.AutoRefresh.Tick += new System.EventHandler(this.AutoRefresh_Tick);
            // 
            // btndelete
            // 
            this.btndelete.Location = new System.Drawing.Point(6, 19);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(166, 34);
            this.btndelete.TabIndex = 3;
            this.btndelete.Text = "Delete";
            this.btndelete.UseVisualStyleBackColor = true;
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(6, 60);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(127, 22);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "Clear all logs";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // ActivityLogs_frm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(903, 615);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.btndelete);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(921, 662);
            this.MinimumSize = new System.Drawing.Size(921, 662);
            this.Name = "ActivityLogs_frm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ActivityLogs_frm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ActivityLogs_frm_FormClosed);
            this.Load += new System.EventHandler(this.ActivityLogs_frm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dglogs)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dglogs;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Timer AutoRefresh;
        private System.Windows.Forms.Button btndelete;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}