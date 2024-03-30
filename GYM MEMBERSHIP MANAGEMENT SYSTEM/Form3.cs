using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GYM_MEMBERSHIP_MANAGEMENT_SYSTEM
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to log out?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Hide();
                Form1 Form1 = new Form1(); 
                Form1.Show();
            }
        }
        private void bunifuCustomLabel1_Click(object sender, EventArgs e)
        {
            //profile1.Hide();
            aboutus1.Show();
            aboutus1.BringToFront();
        }

        private void bunifuCustomLabel2_Click(object sender, EventArgs e)
        {
           // profile1.Hide();
            aboutus1.Hide();
            coach1.Show();
            coach1.BringToFront();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void bunifuCustomLabel3_Click(object sender, EventArgs e)
        {
            //profile1.Hide();
            coach1.Hide();
            schedule1.Show();
            schedule1.BringToFront();
        }
        private void bunifuCustomLabel4_Click(object sender, EventArgs e)
        {
            //profile1.Hide();
            schedule1.Hide();
            membership1.Show();
            membership1.BringToFront();
        }
        private void bunifuTileButton1_Click(object sender, EventArgs e)
        {
            membership1.Hide();
           // profile1.Show();
            //profile1.BringToFront();
        }
    }
}
