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
    }
}
