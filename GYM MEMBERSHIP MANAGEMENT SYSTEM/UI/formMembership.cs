using GYM_MEMBERSHIP_MANAGEMENT_SYSTEM;
using GYM_MEMBERSHIP_MANAGEMENT_SYSTEM.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SYSTEM_GYM
{
    public partial class formMembership : Form
    {

        formperday perday;
        formbronze bronze;
        formsilver silver;
        formGold gold;


        private Timer toggleTimer;
        public formMembership()
        {
            InitializeComponent();
            InitializedTimer();
        }
        private void InitializedTimer()
        {
            toggleTimer = new Timer();
            toggleTimer.Interval = 100;
            toggleTimer.Tick += ToggleTimer_Tick;
        }

        private void ToggleTimer_Tick(object sender, EventArgs e)
        {

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void picboxwhite_MouseEnter(object sender, EventArgs e)
        {
            // picboxwhite.Visible = false;
            //  picboxrange.Visible = true;
        }

        private void picboxwhite_MouseLeave(object sender, EventArgs e)
        {
            // picboxwhite.Visible = true;
            // picboxrange.Visible = false;
        }

        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {
            // pictureBox4.Visible = false;
            //pictureBox3.Visible = true;
        }

        private void picboxwhite_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }

        private void userControl61_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void picboxrange_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void formMembership_Load(object sender, EventArgs e)
        {

        }
        public static int parentX, parentY;
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Form modalBackground = new Form();
            using (formperday perday = new formperday())
            {
                modalBackground.StartPosition = FormStartPosition.Manual;
                modalBackground.FormBorderStyle = FormBorderStyle.None;
                modalBackground.Opacity = .0d;
                modalBackground.Size = this.Size;
                modalBackground.Location = this.Location;
                modalBackground.ShowInTaskbar = false;
                modalBackground.Show();
                perday.Owner = modalBackground;

                parentX = this.Location.X;
                parentY = this.Location.Y;

                perday.ShowDialog();
                modalBackground.Dispose();


            }

        }

        private void Perday_FormClosed1(object sender, FormClosedEventArgs e)
        {

        }

        private void Perday_FormClosed(object sender, FormClosedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void bntbronze_Click(object sender, EventArgs e)
        {
            Form modalBackground = new Form();
            using (formbronze bronze = new formbronze())
            {
                modalBackground.StartPosition = FormStartPosition.Manual;
                modalBackground.FormBorderStyle = FormBorderStyle.None;
                modalBackground.Opacity = .0d;
                modalBackground.Size = this.Size;
                modalBackground.Location = this.Location;
                modalBackground.ShowInTaskbar = false;
                modalBackground.Show();
                bronze.Owner = modalBackground;

                parentX = this.Location.X;
                parentY = this.Location.Y;

                bronze.ShowDialog();
                modalBackground.Dispose();


            }
        }



        private void bntsilver_Click(object sender, EventArgs e)
        {
            Form modalBackground = new Form();
            using (formsilver silver = new formsilver())
            {
                modalBackground.StartPosition = FormStartPosition.Manual;
                modalBackground.FormBorderStyle = FormBorderStyle.None;
                modalBackground.Opacity = .0d;
                modalBackground.Size = this.Size;
                modalBackground.Location = this.Location;
                modalBackground.ShowInTaskbar = false;
                modalBackground.Show();
                silver.Owner = modalBackground;

                parentX = this.Location.X;
                parentY = this.Location.Y;

                silver.ShowDialog();
                modalBackground.Dispose();


            }
        }

        private void Silver_FormClosed(object sender, FormClosedEventArgs e)
        {
            silver = null;
        }

        private void bntgold_Click(object sender, EventArgs e)
        {
            Form modalBackground = new Form();
            using (formGold gold = new formGold())
            {
                modalBackground.StartPosition = FormStartPosition.Manual;
                modalBackground.FormBorderStyle = FormBorderStyle.None;
                modalBackground.Opacity = .0d;
                modalBackground.Size = this.Size;
                modalBackground.Location = this.Location;
                modalBackground.ShowInTaskbar = false;
                modalBackground.Show();
                gold.Owner = modalBackground;

                parentX = this.Location.X;
                parentY = this.Location.Y;

                gold.ShowDialog();
                modalBackground.Dispose();


            }


        }
    }
}

