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
    public partial class AddDepartment : Form
    {
        ConnectionString cs = new ConnectionString();
        SqlConnection con = null;
        public AddDepartment()
        {
            InitializeComponent();
        }

        private void AddDepartment_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(cs.DBcon);
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            display();
        }

        public void display()
        {

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Department_db ORDER BY id DESC";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            dataGridView1.DataSource = dt;
            da.Fill(dt);
            this.dataGridView1.Columns["id"].Visible = false;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        public void clear()
        {

            txtdepartment.Clear();
            txtdepartment.Focus();
        }
        private void btnadd_Click(object sender, EventArgs e)
        {
            if(txtdepartment.Text == "")
            {
                MessageBox.Show("Please fill the field","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            else
            {
                int i = 0;
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Department_db where DepartmentName ='" + txtdepartment.Text + "' ";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                i = Convert.ToInt32(dt.Rows.Count.ToString());
                if (i == 0)
                {
                    SqlCommand cmd1 = con.CreateCommand();
                    cmd1.CommandType = CommandType.Text;
                    cmd1.CommandText = "INSERT INTO Department_db values('"+ txtdepartment.Text +"')";
                    cmd1.ExecuteNonQuery();

                    clear();
                    display();

                    MessageBox.Show("Data successfully added", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            

                int i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Department_db where id=" + i + "";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {

                    txtdepartment.Text = dr["DepartmentName"].ToString();
                }
            }

        private void txtdepartment_DoubleClick(object sender, EventArgs e)
        {
            txtdepartment.Clear();
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            //DELETE USERS FROM DATABASE.
            if (txtdepartment.Text == "")
            {
                MessageBox.Show("Select data you want to delete", "Select", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (MessageBox.Show("Are you sure you want to delete this data?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    int id;
                    id = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "delete from Department_db where id=" + id + "";
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Data successfully deleted!","Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clear();
                    display();

                }
                catch (Exception)
                {
                    MessageBox.Show("Empty Column");
                }
            }
        }

        private void AddDepartment_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }
    }
    }

