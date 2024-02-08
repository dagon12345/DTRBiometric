using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DailyTimeRecord.Properties;

namespace DailyTimeRecord
{
    public partial class SplashScreen_frm : Form
    {
        public SplashScreen_frm()
        {
            InitializeComponent();
        }
       

        private void SplashScreen_frm_Load(object sender, EventArgs e)
        {
           
        }
       


        
        private void Timer_Tick(object sender, EventArgs e)
        {
            progressBar1.Increment(3);
            if (progressBar1.Value == 100)
            {
                Timer.Stop();
                this.Close();
                DailyTimeRecord dtr = new DailyTimeRecord();
                dtr.Show();
                //fd.txtidnumber.Focus();
               // this.Hide();

            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnenter_Click(object sender, EventArgs e)
        {
  
        }

        private void SplashScreen_frm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
