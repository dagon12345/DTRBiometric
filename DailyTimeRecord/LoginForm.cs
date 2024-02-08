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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            
        }

        private void DTRButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenu mm = new MainMenu();
            mm.Show();
            mm.groupBox3.Visible = false;
            mm.featuresToolStripMenuItem.Visible = false;

        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            if(UsernameText.Text == "ADMINHR" && PasswordText.Text == "ADMIN")
            {
                this.Hide();
                MainMenu mm = new MainMenu();
                mm.Show();
            }
            else if(UsernameText.Text == "" || PasswordText.Text == "")
            {
                UsernameText.Focus();
                MessageBox.Show("Please fill up the fields.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Invalid Login details.","Invalid",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            UsernameText.Focus();
            //DailyTimeRecord dtr = new DailyTimeRecord();
        }
    }
}
