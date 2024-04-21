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
    public partial class formsilver : Form
    {
        public formsilver()
        {
            InitializeComponent();
        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
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

                Form2 Form2 = new Form2();
                Form2.Show();
                this.Close();
            }
        }

        private void silvertimer_Tick(object sender, EventArgs e)
        {
            if (Opacity >= 1)
            {
                silvertimer.Stop();
            }
            else
            {
                Opacity += .04;
            }

            int y = formMembership.parentY += 5;
            this.Location = new Point(formMembership.parentX + 65, y);
            if (y >= i)
            {
                silvertimer.Stop();
            }
        }
        int i;

        public int parentX, parentY;

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
        private void formsilver_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
            }
        }

        private void formsilver_Load(object sender, EventArgs e)
        {
            i = formMembership.parentX = 130;
            this.Location = new Point(formMembership.parentX + 100, formMembership.parentY + 130);
        }
    }
}
