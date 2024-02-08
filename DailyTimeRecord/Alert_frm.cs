using DailyTimeRecord.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DailyTimeRecord
{
    public partial class Alert_frm : Form
    {
        public Alert_frm()
        {
            InitializeComponent();
        }

        private void Alert_frm_Load(object sender, EventArgs e)
        {

        }
        public enum enmAction
        {
            wait,
            start,
            close
        }

        public enum enmType
        {
            Timein,
            Timeout,
            Delete

        }
        private Alert_frm.enmAction action;

        private int x, y;

        private void timer1_Tick(object sender, EventArgs e)
        {
            switch (this.action)
            {
                case enmAction.wait:
                    timer1.Interval = 1000;
                    action = enmAction.close;
                    break;
                case enmAction.start:
                    timer1.Interval = 1;
                    this.Opacity += 0.1;
                    if (this.x < this.Location.X)
                    {
                        this.Left--;

                    }
                    else
                    {
                        if (this.Opacity == 1.0)
                        {
                            action = enmAction.wait;
                        }
                    }
                    break;
                case enmAction.close:
                    timer1.Interval = 1;
                    this.Opacity -= 0.1;

                    this.Left -= 3;

                    if (base.Opacity == 0.0)
                    {
                        base.Close();
                    }
                    break;

            }
        }

        private void Alert_frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //this.Close();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void showAlert(string msg, enmType type)
        {
            this.Opacity = 0.0;
            this.StartPosition = FormStartPosition.Manual;
            string fname;

            for (int i = 1; i < 10; i++)
            {
                fname = "alert" + i.ToString();
                Alert_frm frm = (Alert_frm)Application.OpenForms[fname];

                if (frm == null)
                {
                    this.Name = fname;
                    this.x = Screen.PrimaryScreen.WorkingArea.Width - this.Width + 15;
                    this.y = Screen.PrimaryScreen.WorkingArea.Height - this.Height * i - 5 * i;
                    this.Location = new Point(this.x, this.y);
                    break;

                }


            }

            this.x = Screen.PrimaryScreen.WorkingArea.Width - base.Width - 5;



            switch (type)
            {
                case enmType.Timein:
                    this.pictureBox1.Image = Resources.iconfinder_v_31_3162614;
                    this.BackColor = Color.SeaGreen;
                    break;
               case enmType.Timeout:
                    this.pictureBox1.Image = Resources.iconfinder_v_31_3162614;
                    this.BackColor = Color.Olive;
                    break;
                    /*   case enmType.Delete:
                        this.pictureBox1.Image = Resources.iconfinder_basics_22_296812;
                        this.BackColor = Color.Crimson;
                        break;*/
            }


            this.lblmessage.Text = msg;
            this.Show();
            this.action = enmAction.start;


            this.timer1.Interval = 1;
            timer1.Start();

        }
    }
}
