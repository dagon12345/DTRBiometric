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
    public partial class DTRRecordsHistory : Form
    {
        ConnectionString cs = new ConnectionString();
        SqlConnection con = null;
        string query;

        public DTRRecordsHistory()
        {
            InitializeComponent();

            con = new SqlConnection(cs.DBcon);
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            clear();
        }

        private void DTRRecordsHistory_Load(object sender, EventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string startdate;
            string enddate;

            startdate = dtStart.Value.ToString("MM/dd/yyyy");
            enddate = dtEnd.Value.ToString("MM/dd/yyyy");


            SqlCommand cmd1 = con.CreateCommand();
            cmd1.CommandType = CommandType.Text;
      //ORIGINAL      //cmd1.CommandText = "Select id,Date,IDNumber,FullName,Department,TimeIn,TimeOut,TotalHours,OverTimeHours, SUM(TotalHours) OVER (PARTITION BY IDNUMBER,Department ORDER by IDNUMBER,Department)[Total Working Hours], SUM(OverTimeHours) OVER (PARTITION BY IDNUMBER,Department ORDER by FullName,Department)[Total OT Hours] FROM DTRRecords_db  where Date>='" + startdate.ToString() + "' AND Date<='" + enddate.ToString() + "'  ORDER by IDNUMBER,Department";
           //PREFRED FUNCTION HERE// cmd1.CommandText = "Select id,Date,IDNumber,FullName,Department,TimeIn,TimeOut,TotalHours,OverTimeHours, SUM(TotalHours) OVER (PARTITION BY IDNUMBER ORDER by IDNUMBER ROWS BETWEEN UNBOUNDED PRECEDING AND CURRENT ROW)AS [Total Working Hours], SUM(OvertimeHours) OVER (PARTITION BY IDNUMBER ORDER by IDNUMBER ROWS BETWEEN UNBOUNDED PRECEDING AND CURRENT ROW)AS [Total OT Hours] FROM DTRRecords_db  where Date>='" + startdate.ToString() + "' AND Date<='" + enddate.ToString() + "' ";
            //cmd1.CommandText = "Select id,Date,IDNumber,FullName,Department,TimeIn,TimeOut,TotalHours,OverTimeHours FROM DTRRercords_db";
            cmd1.CommandText = "Select id,Date,IDNumber,FullName,Department,TimeIn,TimeOut,TotalHours,OverTimeHours,Remarks FROM DTRRecords_db where Date BETWEEN '" + startdate.ToString() + "' AND '" + enddate.ToString() + "' ORDER BY FullName,Date ASC";
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
            dataGridView1.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //ORIGINAL      // query = "Select id,Date,IDNumber,FullName,Department,TimeIn,TimeOut,TotalHours,OverTimeHours, SUM(TotalHours) OVER (PARTITION BY IDNUMBER,Department ORDER by IDNUMBER,Department)[Total Working Hours], SUM(OverTimeHours) OVER (PARTITION BY IDNUMBER,Department ORDER by FullName,Department)[Total OT Hours] FROM DTRRecords_db  where Date>='" + startdate.ToString() + "' AND Date<='" + enddate.ToString() + "'  ORDER by IDNUMBER,Department";
           //PREFERED query = "Select id,Date,IDNumber,FullName,Department,TimeIn,TimeOut,TotalHours,OverTimeHours, SUM(TotalHours) OVER (PARTITION BY IDNUMBER ORDER by IDNUMBER ROWS BETWEEN UNBOUNDED PRECEDING AND CURRENT ROW)AS [Total Working Hours], SUM(OvertimeHours) OVER (PARTITION BY IDNUMBER ORDER by IDNUMBER ROWS BETWEEN UNBOUNDED PRECEDING AND CURRENT ROW)AS [Total OT Hours] FROM DTRRecords_db  where Date>='" + startdate.ToString() + "' AND Date<='" + enddate.ToString() + "' ";
            query = "Select id,Date,IDNumber,FullName,Department,TimeIn,TimeOut,TotalHours,OverTimeHours,Remarks FROM DTRRecords_db where Date BETWEEN '" + startdate.ToString() + "' AND '" + enddate.ToString() + "' ORDER BY FullName,Date ASC";
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
        
        }
        public void clear()
        {
            lbldate.Text = "(Date)";
            lblidnumber.Text = "(ID Number)";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("There is nothing to delete", "Empty",MessageBoxButtons.OK,MessageBoxIcon.Error);

            }
            else if(lbldate.Text == "(Date)" || lblidnumber.Text == "(ID Number)")
            {
                MessageBox.Show("Select data you want to delete", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (MessageBox.Show("Are you sure you want to delete this HIGHLIGHTED data?", "Delete Data", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                int id;
                id = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "delete from DTRRecords_db where id=" + id + "";
                cmd.ExecuteNonQuery();

                
                SqlCommand cmd1 = con.CreateCommand();
                cmd1.CommandText = "delete from TimeIn_db where Date='" + lbldate.Text + "' and IDNumber='" + lblidnumber.Text +"'";
                cmd1.ExecuteNonQuery();




                ////// IF DELETED THE DATA WIL STILL THERE
                string startdate;
                string enddate;

                startdate = dtStart.Value.ToString("MM/dd/yyyy");
                enddate = dtEnd.Value.ToString("MM/dd/yyyy");


                SqlCommand cmd2 = con.CreateCommand();
                cmd2.CommandType = CommandType.Text;
                cmd2.CommandText = cmd1.CommandText = "Select id,Date,IDNumber,FullName,Department,TimeIn,TimeOut,TotalHours,OverTimeHours,Remarks FROM DTRRecords_db where Date>='" + startdate.ToString() + "' AND Date<='" + enddate.ToString() + "' ORDER BY IDNumber ASC ";
                cmd2.ExecuteNonQuery();
                DataTable dt1 = new DataTable();
                SqlDataAdapter da1 = new SqlDataAdapter(cmd2);
                da1.Fill(dt1);
                dataGridView1.DataSource = dt1;
                dataGridView1.Columns["id"].Visible = false;
                dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                query = cmd1.CommandText = "Select id,Date,IDNumber,FullName,Department,TimeIn,TimeOut,TotalHours,OverTimeHours,Remarks FROM DTRRecords_db where Date>='" + startdate.ToString() + "' AND Date<='" + enddate.ToString() + "' ORDER BY IDNumber ASC ";


                clear();
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

                    lbldate.Text = dr["Date"].ToString();
                    lblidnumber.Text = dr["IDNumber"].ToString();

                }
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("There Is Nothing To Be Printed", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                PrintPreview_frm ppf = new PrintPreview_frm();
                ppf.get_value(query.ToString());
                ppf.Show();
            }
        }

        private void DTRRecordsHistory_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }
    }
}
