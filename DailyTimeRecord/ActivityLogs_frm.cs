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
    public partial class ActivityLogs_frm : Form
    {
        ConnectionString cs = new ConnectionString();
        SqlConnection con = null;

        public ActivityLogs_frm()
        {
            InitializeComponent();
        }

        private void ActivityLogs_frm_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(cs.DBcon);
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            display();
            //AutoRefresh.Start();
        }

        public void display()
        {
            SqlCommand cmd1 = con.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "Select * from ActivityLogs_db ORDER BY EmployeeName,id DESC";
            cmd1.ExecuteNonQuery();
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            da1.Fill(dt1);
            dglogs.DataSource = dt1;
            this.dglogs.Columns["id"].Visible = false;
            this.dglogs.Columns["ClearId"].Visible = false;
            dglogs.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dglogs.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dglogs.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dglogs.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dglogs.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dglogs.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void dglogs_SelectionChanged(object sender, EventArgs e)
        {
            //this.dglogs.ClearSelection();
        }

        private void AutoRefresh_Tick(object sender, EventArgs e)
        {
            display();
        }

        private void dglogs_MouseHover(object sender, EventArgs e)
        {
            //AutoRefresh.Stop();
        }

        private void dglogs_MouseLeave(object sender, EventArgs e)
        {
            //AutoRefresh.Start();
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            //DELETE USERS FROM DATABASE.

            if (checkBox1.Checked == false)
            {
                if (dglogs.Rows.Count == 0)
                {
                    MessageBox.Show("There is nothing to delete.", "Empty table", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (MessageBox.Show("Are you sure you want to delete this data?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        int id;
                        id = Convert.ToInt32(dglogs.SelectedCells[0].Value.ToString());
                        SqlCommand cmd = con.CreateCommand();
                        cmd.CommandText = "delete from ActivityLogs_db where id=" + id + "";
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Data successfully deleted!");
                        display();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else if (checkBox1.Checked == true)
            {
                if (dglogs.Rows.Count == 0)
                {
                    MessageBox.Show("There is nothing to delete.","Empty table",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                else if (MessageBox.Show("Are you sure you want to delete the whole data?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        int id = 1;

                        SqlCommand cmd = con.CreateCommand();
                        cmd.CommandText = "delete from ActivityLogs_db where ClearID=" + id + "";
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Data successfully deleted!");
                        display();
                        checkBox1.Checked = false;

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
            }
        }

        private void ActivityLogs_frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }
    }
}

