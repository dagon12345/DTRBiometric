using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DailyTimeRecord
{
    public partial class MainMenu : Form
    {
        ConnectionString cs = new ConnectionString();
        SqlConnection con = null;
        public MainMenu()
        {
            InitializeComponent();
            try
            { 


            con = new SqlConnection(cs.DBcon);
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

                DateTime dt1 = DateTime.Now;
                DateTime dt2 = DateTime.Parse("08/31/2021");
                DateTime dt3 = DateTime.Parse("08/31/2021");


                if (dt1.Date > dt2.Date)
                {
                    MessageBox.Show("Trial Version Expired Please buy the software to continue using!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Application.Exit();
                }
                else
                {
                    TimerToday.Start();
                    Timeinout.Start();

                    // MessageBox.Show("You are successfully connected to the server.", "Connection Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    if (dt1.Date == dt3.Date)
                    {
                        MessageBox.Show("The program will expire tomorrow please save your files or backup.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

            this.bw = new BackgroundWorker();
            this.bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            this.bw.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
            this.bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
            this.bw.WorkerReportsProgress = true;

            }
            catch (Exception)
            {
                MessageBox.Show("System detected a power change. Please close the system and open it again.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); 
                this.Close();
            }




       

        }
        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = (BackgroundWorker)sender;
            for (int i = 0; i < 100; ++i)
            {
                // report your progres
                worker.ReportProgress(i);

                // pretend like this a really complex calculation going on eating up CPU time
                System.Threading.Thread.Sleep(10);
            }
        }

        private void bw_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            LoadProgressBar.Value = e.ProgressPercentage;
        }
        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (Application.OpenForms.OfType<DailyTimeRecord>().Count() == 1) Application.OpenForms.OfType<DailyTimeRecord>().First().Close();
            {
                DailyTimeRecord dtr = new DailyTimeRecord();
                dtr.Show();
                LoadProgressBar.Value = 0;
            }
        }
            // CODE TO MOVE THE FORM NEEDS VARIABLES
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.Dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparm, int lpram);

      
        private void MainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

       
        
        public void samplebday()
        {
            SqlCommand cmd1 = con.CreateCommand();
            cmd1.CommandType = text;
            cmd1.CommandText = "Select FullName,Birthday FROM EmployeeDetails_db WHERE DATEADD(YEAR,DATEPART(YEAR,GETDATE()) - DATEPART(YEAR,Birthday), Birthday) BETWEEN CAST(GETDATE() AS DATE) AND CAST (DATEADD(WEEK,1, GETDATE()) AS DATE) ORDER BY DAY(Birthday), Fullname ";
            cmd1.ExecuteNonQuery();
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            da1.Fill(dt1);
            dgweekbefore.DataSource = dt1;
            dgweekbefore.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgweekbefore.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = text;
            cmd.CommandText = "Select FullName,Birthday FROM EmployeeDetails_db WHERE DATEADD(YEAR,DATEPART(YEAR,GETDATE()) - DATEPART(YEAR,Birthday), Birthday) BETWEEN CAST(GETDATE() AS DATE) AND CAST (DATEADD(DAY,0, GETDATE()) AS DATE) ORDER BY DAY(Birthday), Fullname ";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dgbday.DataSource = dt;
            this.dgbday.Columns["Birthday"].Visible = false;
            dgbday.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgbday.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }
            private void MainMenu_Load(object sender, EventArgs e)
        {
            //timein();

           
            //timeout();
            //samplebday();

        }

        private void MainMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void TabControlPictureBox_Click(object sender, EventArgs e)
        {
            
        }

        private void TopPanel_MouseDown(object sender, MouseEventArgs e)
        {
            // CODE TO MOVE THE FORM.
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void DTRRecordsButton_MouseHover(object sender, EventArgs e)
        {
            //VerticalPanel.Width = 220;
        }

        private void DTRRecordsButton_MouseLeave(object sender, EventArgs e)
        {
           
        }

        private void ActivityLogsButton_MouseHover(object sender, EventArgs e)
        {
            //VerticalPanel.Width = 220;
        }

        private void ActivityLogsButton_MouseLeave(object sender, EventArgs e)
        {
         
        }
      
        private void DTRRecordsButton_Click(object sender, EventArgs e)
        {
          
            if (Application.OpenForms.OfType<DTRRecordsHistory>().Count() == 1) Application.OpenForms.OfType<DTRRecordsHistory>().First().Close();
            {
                // Application.OpenForms.OfType<AddD//epartment>
                DTRRecordsHistory dtrr = new DTRRecordsHistory();
                dtrr.Show();
            }
        }

     
        private void ActivityLogsButton_Click(object sender, EventArgs e)
        { 
       
            if (Application.OpenForms.OfType<ActivityLogs_frm>().Count() == 1) Application.OpenForms.OfType<ActivityLogs_frm>().First().Close();
            {
                // Application.OpenForms.OfType<AddD//epartment>
                ActivityLogs_frm al = new ActivityLogs_frm();
                al.Show();
            }

        }

        private void NoTimeoutButton_Click(object sender, EventArgs e)
        {
        
        }

        private void noTimeoutEmployeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void DailyTimeRecordButton_Click(object sender, EventArgs e)
        {
            if (!this.bw.IsBusy)
            {
                this.bw.RunWorkerAsync();
            }
        }

        private void VerticalPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SliderButton_Click(object sender, EventArgs e)
        {
           /* if (VerticalPanel.Width == 230)
            {
                VerticalPanel.Width = 54;
            }
            else
            {
                VerticalPanel.Width = 230;
            }*/
        }
      

        private void RegisterEmployeesButton_Click(object sender, EventArgs e)
        {
          
            if (Application.OpenForms.OfType<Register>().Count() == 1) Application.OpenForms.OfType<Register>().First().Close();
            {
                // Application.OpenForms.OfType<AddD//epartment>
               Register r = new Register();
               r.Show();
            }
        }

        private void RegisterDepartmentsButton_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<AddDepartment>().Count() == 1) Application.OpenForms.OfType<AddDepartment>().First().Close();
            {
               // Application.OpenForms.OfType<AddD//epartment>
                AddDepartment ad = new AddDepartment();
                ad.Show();
            }
           
        }

        private void InsertIntoDTRButton_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<InsertIntoDTRRecords_frm>().Count() == 1) Application.OpenForms.OfType<InsertIntoDTRRecords_frm>().First().Close();
            {
                // Application.OpenForms.OfType<AddD//epartment>
                InsertIntoDTRRecords_frm id = new InsertIntoDTRRecords_frm();
                id.Show();
            }


          
        }

        private void NoTimeOutsButton_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<NoTimeOut_frm>().Count() == 1) Application.OpenForms.OfType<NoTimeOut_frm>().First().Close();
            {
                // Application.OpenForms.OfType<AddD//epartment>
                NoTimeOut_frm ntf = new NoTimeOut_frm();
                ntf.Show();
            }

        
        }

        private void TimerToday_Tick(object sender, EventArgs e)
        {
            TimeLabel.Text = DateTime.Now.ToLongTimeString();
            DateLabel.Text = DateTime.Now.ToLongDateString();

            txttodaysdate.Text = DateTime.Now.ToShortDateString(); ////// DATE TODAY covered in time in and timeout.

           


        }

        private void LogoutButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
                LoginForm lf = new LoginForm();
                lf.Show();

            }
        }

        private void readCardStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<ReadCard_frm>().Count() == 1) Application.OpenForms.OfType<ReadCard_frm>().First().Close();
            {
                // Application.OpenForms.OfType<AddDepartment>
                ReadCard_frm rdf = new ReadCard_frm();
                rdf.Show();
            }

            
        }

        private const CommandType text = CommandType.Text;
        private const CommandType text1 = CommandType.Text;
        public void timein()
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = text;
            cmd.CommandText = $"Select Date,IDNumber,FullName,TimedIn FROM TimeInStatus_db where Date like'{txttodaysdate.Text}'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dgtimein.DataSource = dt;
            this.dgtimein.Columns["Date"].Visible = false;
            this.dgtimein.Columns["IDNumber"].Visible = false;
            dgtimein.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgtimein.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgtimein.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            lblcounttimein.Text = dgtimein.RowCount.ToString();

            
                

            
        }
        public void timeout()
        {
          /*  SqlCommand cmd1 = con.CreateCommand();
            cmd1.CommandType = text1;
            cmd1.CommandText = $"Select Date,IDNumber,FullName,TimeOut FROM DTRRecords_db where Date like'{txttodaysdate.Text}'";
            cmd1.ExecuteNonQuery();
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            da1.Fill(dt1);
            dgtimeout.DataSource = dt1;
            this.dgtimeout.Columns["Date"].Visible = false;
            this.dgtimeout.Columns["IDNumber"].Visible = false;
            dgtimeout.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgtimeout.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgtimeout.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            lblcounttimeout.Text = dgtimeout.RowCount.ToString();*/



            SqlCommand cmd1 = con.CreateCommand();
            cmd1.CommandType = text;
            cmd1.CommandText = "Select Date,IDNumber,FullName,TimeOut FROM DTRRecords_db where Date Between '" + Convert.ToDateTime(txttodaysdate.Text) +"' AND '"+ Convert.ToDateTime(txttodaysdate.Text) + "'";
            cmd1.ExecuteNonQuery();
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            da1.Fill(dt1);
            dgtimeout.DataSource = dt1;
            this.dgtimeout.Columns["Date"].Visible = false;
            this.dgtimeout.Columns["IDNumber"].Visible = false;
            dgtimeout.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgtimeout.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgtimeout.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            lblcounttimeout.Text = dgtimeout.RowCount.ToString();
        }

        private void Lblcounttimein_TextChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

       
        private void txttodaysdate_TextChanged(object sender, EventArgs e)
        {
            timein();
            timeout();
        }

        private void dgtimein_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            //MessageBox.Show("aw");
        }

        private void dgtimein_CurrentCellChanged(object sender, EventArgs e)
        {
             //MessageBox.Show("aw");
        }

        private void dgtimein_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            
            
        }

        private void dgtimein_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
           // MessageBox.Show("aw");
        }

        private void dgtimein_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
          //  MessageBox.Show("aw");
        }

        public void Alert(string msg, Alert_frm.enmType type)
        {
            Alert_frm frm= new Alert_frm();
            frm.showAlert(msg, type);

        }
        //DailyTimeRecord dtr = new DailyTimeRecord();
        private void lblcounttimein_TextChanged_1(object sender, EventArgs e)
        {
           

            

            SqlCommand cmd1 = con.CreateCommand();
                cmd1.CommandType = text;
                cmd1.CommandText = "Select TOP (1) FullName FROM TimeInStatus_db ORDER BY id DESC";
                cmd1.ExecuteNonQuery();
                DataTable dt1 = new DataTable();
                SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                da1.Fill(dt1);
                dgtimein.DataSource = dt1;

                foreach (DataRow dr in dt1.Rows)
                {


                    this.Alert(dr["FullName"].ToString() + " has timed in.", Alert_frm.enmType.Timein);


                }
       
            
        }

        private void lblcounttimeout_TextChanged(object sender, EventArgs e)
        {
     
          
            
                SqlCommand cmd1 = con.CreateCommand();
                cmd1.CommandType = text;
                cmd1.CommandText = "Select TOP (1) FullName FROM DTRRecords_db ORDER BY id DESC";
                cmd1.ExecuteNonQuery();
                DataTable dt1 = new DataTable();
                SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                da1.Fill(dt1);
                dgtimeout.DataSource = dt1;
                foreach (DataRow dr in dt1.Rows)
                {

                    this.Alert(dr["FullName"].ToString() + " has timed out.", Alert_frm.enmType.Timeout);
                }
         
            
        }

        private void dgtimeout_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {

        }

        private void dgweekbefore_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgtimein_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void bw_DoWork_1(object sender, DoWorkEventArgs e)
        {

        }

        private void Timeinout_Tick(object sender, EventArgs e)
        {
            timein();
            timeout();
            samplebday();
        }

        private void dgtimein_MouseHover(object sender, EventArgs e)
        {
            Timeinout.Stop();
        }

        private void dgtimein_Leave(object sender, EventArgs e)
        {

        }

        private void dgtimein_MouseLeave(object sender, EventArgs e)
        {
            Timeinout.Start();
        }

        private void dgtimeout_MouseHover(object sender, EventArgs e)
        {
            Timeinout.Stop();
        }

        private void dgtimeout_MouseLeave(object sender, EventArgs e)
        {
            Timeinout.Start();
        }
    }
}
