using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SYSTEM_GYM;

namespace GYM_MEMBERSHIP_MANAGEMENT_SYSTEM.UI
{
    public partial class formGold : Form
    {
        public formGold()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void bntperday_Click(object sender, EventArgs e)
        {
            if (!bunifuCheckbox1.Checked)
            {
                MessageBox.Show("Please agree to the terms and agreement before registering.", "Error");
                return;
            }
            DialogResult result = MessageBox.Show("Are you sure you want to avail this membership?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Hide();
                Form2 Form2 = new Form2();
                Form2.Show();
                this.Close();
            }
        }

        int i;
        public int parentX, parentY;
        private void formGold_Load(object sender, EventArgs e)
        {
            i = formMembership.parentX = 130;
            this.Location = new Point(formMembership.parentX + 100, formMembership.parentY + 130);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            formMembership formMembership = Application.OpenForms["FormMembership"] as formMembership;

            if (formMembership == null)
            {
                formMembership = new formMembership();
            }

            formMembership.Show();
            this.Hide();
        }

        private void formgold_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true; // Cancels the form closing event
                this.Hide(); // Hides the form instead of closing it
            }
        }

        private void bunifuCheckbox1_OnChange(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void goldtimer_Tick(object sender, EventArgs e)
        {
            if (Opacity >= 1)
            {
                goldtimer.Stop();
            }
            else
            {
                Opacity += .04;
            }

            int y = formMembership.parentY += 5;
            this.Location = new Point(formMembership.parentX + 65, y);
            if (y >= i)
            {
                goldtimer.Stop();
            }
        }
    }
}
