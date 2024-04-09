using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SYSTEM_GYM
{
    public partial class formMembership : Form
    {
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


        private void picoradayone_MouseLeave(object sender, EventArgs e)
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

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {
           // pictureBox4.Visible = false;
            //pictureBox3.Visible = true;
        }

        private void picboxwhite_Click(object sender, EventArgs e)
        {
            userControl61.Show();
            userControl61.BringToFront();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            userControl61.Hide();
            userControl71.Show();
            userControl71.BringToFront();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            userControl71.Hide();
            userControl81.Show();
            userControl81.BringToFront();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            userControl81.Hide();
            userControl91.Show();
            userControl91.BringToFront();
        }
    }
}
