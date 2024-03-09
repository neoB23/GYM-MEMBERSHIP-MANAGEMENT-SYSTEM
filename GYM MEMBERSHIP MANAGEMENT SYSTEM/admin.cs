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
    public partial class admin : Form
    {
        public admin()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to log out?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Check if the user confirms the logout
            if (result == DialogResult.Yes)
            {
                // Perform logout action
                // For example, you can hide the current form and show the login form
                this.Hide();
                Form1 Form1 = new Form1(); // Replace LoginForm with the actual name of your login form
                Form1.Show();
            }
        }

        private void bunifuCustomLabel1_Click(object sender, EventArgs e)
        {

            userControl11.Show();
            userControl11.BringToFront();
        }

        private void bunifuCustomLabel2_Click(object sender, EventArgs e)
        {
            userControl11.Hide();
            userControl21.Show();
            userControl21.BringToFront();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuCustomLabel4_Click(object sender, EventArgs e)
        {
            userControl31.Hide();
            userControl41.Show();
            userControl41.BringToFront();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            

        }

        private void bunifuCustomLabel3_Click(object sender, EventArgs e)
        {
            userControl21.Hide();
            userControl31.Show();
            userControl31.BringToFront();
        }

        private void userControl11_Load(object sender, EventArgs e)
        {

        }

        private void userControl41_Load(object sender, EventArgs e)
        {

        }
    }
}
