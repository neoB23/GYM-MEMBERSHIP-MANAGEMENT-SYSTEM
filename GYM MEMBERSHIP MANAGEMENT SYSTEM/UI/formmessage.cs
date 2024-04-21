using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SYSTEM_GYM;

namespace GYM_MEMBERSHIP_MANAGEMENT_SYSTEM.UI
{
    public partial class formmessage : Form
    {
        public string stdName { get; set; }
        public string stdMembership {  get; set; }

        public formmessage()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            formMembership formMembership = Application.OpenForms["formMembership"] as formMembership;

            if (formMembership == null)
            {
                formMembership = new formMembership();
            }

            formMembership.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
           
        }

        private void label6_Click_1(object sender, EventArgs e)
        {
            
        }

        private void label5_Click(object sender, EventArgs e)
        {
           
        }

        private void label7_Click(object sender, EventArgs e)
        {
            label7.Text = stdName;
        }

        private void label6_Click_2(object sender, EventArgs e)
        {
            label6.Text = stdMembership;
        }
    }
}
