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
    public partial class PrintPreview_frm : Form
    {
        ConnectionString cs = new ConnectionString();
        SqlConnection con = null;
        //DailyTimeRecord dtr = new DailyTimeRecord();
        Double tot = 0;

        string j;
        string s;
        public void get_value(string i)
        {

            j = i;
        }


        public PrintPreview_frm()
        {
            InitializeComponent();
        }

        private void PrintPreview_frm_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(cs.DBcon);
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            PrintTotalHours ds = new PrintTotalHours();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = j;
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds.DataTable1);
            da.Fill(dt);

            DTRCrystal myreport = new DTRCrystal();
            myreport.SetDataSource(ds);
            crystalReportViewer1.ReportSource = myreport;
        }

        private void PrintPreview_frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }
    }
}
