using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
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
            if (result == DialogResult.Yes)
            {
                
                this.Hide();
                Form1 Form1 = new Form1(); 
                Form1.Show();
            }
        }

        private void bunifuCustomLabel1_Click(object sender, EventArgs e)
        {
            userControl01.Hide();
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
            userControl42.Show();
            userControl42.BringToFront();
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuCustomLabel5_Click(object sender, EventArgs e)
        {
           
            userControl01.Show();
            userControl01.BringToFront();   
        }

        private void bunifuCustomLabel6_Click(object sender, EventArgs e)
        {
            userControl42.Hide();
            userControl51.Show();
            userControl51.BringToFront();   
        }

        private void userControl51_Load(object sender, EventArgs e)
        {

        }

        private void userControl31_Load(object sender, EventArgs e)
        {

        }

        private void userControl01_Load(object sender, EventArgs e)
        {

        }

        private void userControl42_Load(object sender, EventArgs e)
        {

        }
    }
}
