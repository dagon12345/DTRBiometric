using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DailyTimeRecord
{
    public partial class InsertIntoDTRRecords_frm : Form
    {
        ConnectionString cs = new ConnectionString();
        SqlConnection con = null;
        public InsertIntoDTRRecords_frm()
        {
            InitializeComponent();
            con = new SqlConnection(cs.DBcon);
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            display();
            cmbdep();
            //FormulaTimer.Start();
        }

        private void InsertIntoDTRRecords_frm_Load(object sender, EventArgs e)
        {
          
        }
        public void display()
        {
            SqlCommand cmd1 = con.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "Select id,Date,IDNumber,FullName,Department,TimeIn,Timeout,TotalHours,OverTimeHours,Remarks FROM DTRRecords_db ORDER BY IDNumber,id ASC";
            cmd1.ExecuteNonQuery();
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            da1.Fill(dt1);
            dataGridView1.DataSource = dt1;
            dataGridView1.Columns["id"].Visible = false;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

        }
        public void cmbdep()
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select RFIDNumber,FullName,Department From EmployeeDetails_db";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                idnumber_cmb.Items.Add(dr["RFIDNumber"].ToString());

            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select RFIDNumber,FullName,Department,NoonStatus from EmployeeDetails_db where RFIDNumber='" + idnumber_cmb.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {

                idnumber_cmb.Text = dr["RFIDNumber"].ToString();
                fullname_txt.Text = dr["FullName"].ToString();
                department_txt.Text = dr["Department"].ToString();
                NoonStatusText.Text = dr["NoonStatus"].ToString();

            }
        }

        private void FormulaTimer_Tick(object sender, EventArgs e)
        {
            /*
            var timein = DateTime.Parse(timein_dt.Value.ToString("MM/dd/yyyy hh:mm tt"));
            var timeout = DateTime.Parse(timeout_dt.Value.ToString("MM/dd/yyyy hh:mm tt"));

            if (NoonStatusText.Text == "WITH NOON BREAK")
            {
                totalhours_txt.Text = (timeout.Hour - timein.Hour) - 1 + ""; //// ------- >> TOTAL HOURS ONLY WHOLE NUMBER
            }
            else if (NoonStatusText.Text == "WITHOUT NOON BREAK")
            {
                totalhours_txt.Text = (timeout.Hour - timein.Hour) + ""; //// ------- >> TOTAL HOURS ONLY WHOLE NUMBER
            }
            
            
            
            
            
            
            
            if (totalhours_txt.Text == "-1")
            {
                totalhours_txt.Text = "0";
            }
            /////////////////////////


           
            //////////////////////
    

            ///////////// IF TOTAL HOURS WILL EXCEED ABOVE 8 IT WILL STAY 8
            if (Double.Parse(totalhours_txt.Text) > 8)
            {
                totalhours_txt.Text = "8";
                lblstatus.Visible = true;
                lblstatus.Text = "Not less than 8 hours is acceptable";
            }
           /* else if (Double.Parse(totalhours_txt.Text) < 8)
            {
                totalhours_txt.Text = "8";
                lblstatus.Visible = true;
                lblstatus.Text = "Not less than 8 hours is only acceptable";
                
            }
            else
            {
                //totalhours_txt.Text = "8";
                lblstatus.Visible = false;
            }

            //////////////////

            
            */


        }

        public void clear()
        {
           // date_dt.ResetText();
            idnumber_cmb.Text = "";
            fullname_txt.Text = "";
            department_txt.Text = "";
            //timein_dt.Text = "8:00 am";
            //timeout_dt.Text = "5:00 pm";
            totalhours_txt.Text = "8";
            NoonStatusText.Clear();
            txtremarks.Text = "NONE";
            OvertimeHoursText.Text = "0";
            add_btn.Text = "ADD";
            idnumber_cmb.Enabled = true;
            idnumber_cmb.Focus();

        }
        private void clear_btn_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void add_btn_Click(object sender, EventArgs e)
        {
            var timein = DateTime.Parse(timein_dt.Value.ToString("hh:mm:ss tt"));
            var timeout = DateTime.Parse(timeout_dt.Value.ToString("hh:mm:ss tt"));
            int j = 0;

            if (idnumber_cmb.Text == "")
            {
                MessageBox.Show("Please fill the fields before adding", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtremarks.Text == "")
            {
                MessageBox.Show("Please input remarks before adding", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (OvertimeHoursText.Text == "")
            {
                MessageBox.Show("Please set overtime hours to zero before udpating or adding", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if(timein > timeout)
            {
                MessageBox.Show("Invalid time entered. Please review the time you've entered", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Double.Parse(totalhours_txt.Text) < 0)
            {
                MessageBox.Show("You cannot enter negative value in total hours, please try again", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(add_btn.Text == "ADD")
            {
                int i = 0;
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from DTRRecords_db where Date ='" + date_dt.Value.ToString("MM/dd/yyyy") + "' and IDNumber ='" + idnumber_cmb.Text + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                i = Convert.ToInt32(dt.Rows.Count.ToString());
                if (i == 0)
                {
                    if (MessageBox.Show("Are you sure you want to add this data?", "ADDING", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        SqlCommand cmd1 = con.CreateCommand();
                        cmd1.CommandType = CommandType.Text;
                        cmd1.CommandText = "INSERT INTO DTRRecords_db (Date,IDNumber,FullName,Department,TimeIn,TimeInOvertimeHours,Timeout,TimeoutOvertimeHours,TotalHours,OverTimeHours,Remarks)values ('" + date_dt.Value.ToString("MM/dd/yyyy") + "','" + idnumber_cmb.Text + "','" + fullname_txt.Text + "','" + department_txt.Text + "','" + timein_dt.Value.ToString("MM/dd/yyyy hh:mm tt") + "','" + 0 + "','" + timeout_dt.Value.ToString("MM/dd/yyyy hh:mm tt") + "','" + 0 + "','" + totalhours_txt.Text + "','" + OvertimeHoursText.Text + "','" + txtremarks.Text +"')";
                        cmd1.ExecuteNonQuery();

                        clear();
                       // display();

                        MessageBox.Show("Data successfully added", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }


                }
                else
                {
                    MessageBox.Show("Specific date and Employee ID already recorded in this system please try again.", "TRY AGAIN", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    clear();

                }

            }
            else if(add_btn.Text == "UPDATE")
            {
                if(fullname_txt.Text == "")
                {
                    MessageBox.Show("Please select employee you want to update", "Select", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (OvertimeHoursText.Text == "")
                {
                    MessageBox.Show("Please set overtime hours to zero before udpating or adding", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    int id;
                    id = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "UPDATE DTRRecords_db set TotalHours='"+ totalhours_txt.Text +"', OverTimeHours = '"+ OvertimeHoursText.Text +"',TimeIn = '"+ timein_dt.Value.ToString("MM/dd/yyyy hh:mm tt") +"', TimeOut='" + timeout_dt.Value.ToString("MM/dd/yyyy hh:mm tt") + "',Remarks = '" + txtremarks.Text +"' WHERE id ='"+  id +"'";
                    cmd.ExecuteNonQuery();
                    clear();
                   // display();

                    MessageBox.Show("Data successfully updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from DTRRecords_db where id=" + i + "";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                date_dt.Text = dr["Date"].ToString();
                idnumber_cmb.Text = dr["IDNumber"].ToString();
                fullname_txt.Text = dr["FullName"].ToString();
                department_txt.Text = dr["Department"].ToString();
                totalhours_txt.Text = dr["TotalHours"].ToString();
                timein_dt.Text = dr["TimeIn"].ToString();
                timeout_dt.Text = dr["TimeOut"].ToString();
                txtremarks.Text = dr["Remarks"].ToString();
                OvertimeHoursText.Text = dr["OverTimeHours"].ToString();
                add_btn.Text = "UPDATE";
                idnumber_cmb.Enabled = false;
            }

            SqlCommand cmd1 = con.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "select RFIDNumber,FullName,Department,NoonStatus from EmployeeDetails_db where RFIDNumber='" + idnumber_cmb.Text + "'";
            cmd1.ExecuteNonQuery();
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            da1.Fill(dt1);
            foreach (DataRow dr in dt1.Rows)
            {

               // idnumber_cmb.Text = dr["RFIDNumber"].ToString();
                //fullname_txt.Text = dr["FullName"].ToString();
                //department_txt.Text = dr["Department"].ToString();
                NoonStatusText.Text = dr["NoonStatus"].ToString();

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<NoTimeOut_frm>().Count() == 1) Application.OpenForms.OfType<NoTimeOut_frm>().First().Close();
            {
                //Application.OpenForms.OfType<InsertIntoDTRRecords_frm>
                NoTimeOut_frm ntf = new NoTimeOut_frm();
                ntf.Show();
            }
        }

        private void date_dt_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("There is nothing to delete", "Empty",MessageBoxButtons.OK,MessageBoxIcon.Error);

            }
            else if (MessageBox.Show("Are you sure you want to delete this HIGHLIGHTED data?", "Delete Data", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                int id;
                id = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "delete from DTRRecords_db where id=" + id + "";
                cmd.ExecuteNonQuery();
                clear();
               // display();
            }
        }

        private void totalhours_txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void OvertimeHoursText_MouseLeave(object sender, EventArgs e)
        {
            if(OvertimeHoursText.Text == "")
            {
                OvertimeHoursText.Text = "0";
            }
        }

        private void InsertIntoDTRRecords_frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        private void totalhours_txt_Leave(object sender, EventArgs e)
        {
            if (totalhours_txt.Text == "")
            {
                totalhours_txt.Text = "0";
            }
        }

        private void fullname_txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void idnumber_cmb_TextChanged(object sender, EventArgs e)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select RFIDNumber,FullName,Department,NoonStatus from EmployeeDetails_db where RFIDNumber='" + idnumber_cmb.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {

                idnumber_cmb.Text = dr["RFIDNumber"].ToString();
                fullname_txt.Text = dr["FullName"].ToString();
                department_txt.Text = dr["Department"].ToString();
                NoonStatusText.Text = dr["NoonStatus"].ToString();

            }
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            display();
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            SqlCommand cmd1 = con.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "Select id,Date,IDNumber,FullName,Department,TimeIn,Timeout,TotalHours,OverTimeHours,Remarks from  DTRRecords_db where IDNumber like '" + txtsearch.Text + "%' or FullName like'" + txtsearch.Text + "%'";
            cmd1.ExecuteNonQuery();
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            da1.Fill(dt1);
            dataGridView1.DataSource = dt1;
            dataGridView1.Columns["id"].Visible = false;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void OvertimeHoursText_Leave(object sender, EventArgs e)
        {
            if (OvertimeHoursText.Text == "")
            {
                OvertimeHoursText.Text = "0";
            }
        }
    }
}
