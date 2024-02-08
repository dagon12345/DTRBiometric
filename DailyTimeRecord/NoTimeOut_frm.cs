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
    public partial class NoTimeOut_frm : Form
    {
        ConnectionString cs = new ConnectionString();
        SqlConnection con = null;

        public NoTimeOut_frm()
        {
            InitializeComponent();
        }

        private void NoTimeOut_frm_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(cs.DBcon);
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            display();
            cmbdep();
        }
        public void display()
        {
            SqlCommand cmd1 = con.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "Select * from TimeInStatus_db ORDER BY FullName,id DESC";
            cmd1.ExecuteNonQuery();
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            da1.Fill(dt1);
            dataGridView1.DataSource = dt1;
            this.dataGridView1.Columns["id"].Visible = false;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            SqlCommand cmd1 = con.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "Select * from TimeInStatus_db where IDNumber like '"+ txtsearch.Text +"%' or FullName like'"+ txtsearch.Text +"%'";
            cmd1.ExecuteNonQuery();
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            da1.Fill(dt1);
            dataGridView1.DataSource = dt1;
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            display();
            txtsearch.Clear();
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("There is nothing to delete.", "Empty table", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (MessageBox.Show("Are you sure you want to delete this data? It cannot retrive any more. Continue?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    int id;
                    id = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "delete from TimeInStatus_db where id=" + id + "";
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Data successfully deleted!");
                   // display();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<InsertIntoDTRRecords_frm>().Count() == 1) Application.OpenForms.OfType<InsertIntoDTRRecords_frm>().First().Close();
            { 
                //Application.OpenForms.OfType<InsertIntoDTRRecords_frm>
                InsertIntoDTRRecords_frm iif = new InsertIntoDTRRecords_frm();
                iif.Show();
            }
            
            
           // idr.Show();


        }
        public void clear()
        {
            date_dt.ResetText();
            idnumber_cmb.Text = "";
            fullname_txt.Clear();

            add_btn.Enabled = true;
            update_btn.Enabled = false;

        }
        private void NoTimeOut_frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        private void add_btn_Click(object sender, EventArgs e)
        {
            if (idnumber_cmb.Text == "")
            {
                MessageBox.Show("Please select ID Number first before inserting.", "Insert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            { 
                int i = 0;
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from TimeInStatus_db where Date ='" + date_dt.Value.ToString("MM/dd/yyyy") + "' and IDNumber ='" + idnumber_cmb.Text + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                i = Convert.ToInt32(dt.Rows.Count.ToString());
                if (i == 0)
                {
                    if (MessageBox.Show("Are you sure you want to INSERT this data?", "INSERTING", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        SqlCommand cmd1 = con.CreateCommand();
                        cmd1.CommandType = CommandType.Text;
                        cmd1.CommandText = "INSERT INTO TimeInStatus_db values ('" + date_dt.Value.ToString("MM/dd/yyyy") + "','" + idnumber_cmb.Text + "','" + fullname_txt.Text + "','" + timein_dt.Value.ToString("MM/dd/yyyy hh:mm tt") + "')";
                        cmd1.ExecuteNonQuery();

                        clear();
                       // display();

                        MessageBox.Show("Data successfully Inserted", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }


                }
                else
                {
                    MessageBox.Show("Specific date and Employee ID already recorded in this form please try again.", "TRY AGAIN", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    clear();

                }
            }
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
        private void idnumber_cmb_SelectedIndexChanged(object sender, EventArgs e)
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

            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from TimeInStatus_db where id=" + i + "";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                date_dt.Text = dr["Date"].ToString();
                idnumber_cmb.Text = dr["IDNumber"].ToString();
                fullname_txt.Text = dr["FullName"].ToString();
                timein_dt.Text = dr["TimedIn"].ToString();

                update_btn.Enabled = true;
                add_btn.Enabled = false;
                
            }
        }

        private void update_btn_Click(object sender, EventArgs e)
        {
            if (fullname_txt.Text == "")
            {
                MessageBox.Show("Please select employee you want to update", "Select", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int id;
                id = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE TimeInStatus_db set Date='" + date_dt.Value.ToString("MM/dd/yyyy") + "',IDNumber='"+ idnumber_cmb.Text +"',FullName='"+ fullname_txt.Text +"',TimedIn='"+ timein_dt.Value.ToString("MM/dd/yyyy hh:mm tt") + "' WHERE id ='" + id + "'";
                cmd.ExecuteNonQuery();
                clear();
                //display();

                MessageBox.Show("Data successfully updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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

            }
        }

        private void Clear_btn_Click(object sender, EventArgs e)
        {
            clear();
        }
    }
}
