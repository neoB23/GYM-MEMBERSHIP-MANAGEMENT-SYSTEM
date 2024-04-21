using GYM_MEMBERSHIP_MANAGEMENT_SYSTEM;
using GYM_MEMBERSHIP_MANAGEMENT_SYSTEM.UI;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using System.Windows.Forms;

namespace SYSTEM_GYM
{
    public partial class userchoice : Form
    {
        Form4 homepage;
        CoachLilli lilli;
        CoachJames james;
        CoachAlex alex;
        formMembership membership;
        formSchedule schedule;
        formEquipment equipment;
        About_us about_Us;
        formperday perday;
        formbronze bronze;
        formsilver silver;
        formGold gold;
        

        private Size formOriginalSize;
        public userchoice()
        {
            InitializeComponent();
            this.Resize += Userchoice_Resize;
            formOriginalSize = this.Size;
        }

        private void Userchoice_Resize(object sender, EventArgs e)
        {
            float widthRatio = (float)this.Width / (float)formOriginalSize.Width;
            float heightRatio = (float)this.Height / (float)formOriginalSize.Height;

            ResizeControl(coachContainer, widthRatio, heightRatio);
            ResizeControl(slidebar, widthRatio, heightRatio);
            ResizeControl(panel1, widthRatio, heightRatio);

            formOriginalSize = this.Size;
        }

        bool coachExpand = false;
        bool planExpand = false;

        private void userchoice_Load(object sender, EventArgs e)
        {
            
        }
        private void ResizeControl(Control control, float widthRatio, float heightRatio)
        {
            control.Width = (int)(control.Width * widthRatio);
            control.Height = (int)(control.Height * heightRatio);

            control.Left = (int)(control.Left * widthRatio);
            control.Top = (int)(control.Top * heightRatio);
        }
        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to log out?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Form1 form1 = new Form1();
                this.Hide();
                form1.Show();
            }
        }

        private void flowLayoutPanel2_Paint_1(object sender, PaintEventArgs e)
        {

        }
        private void coachTransition_Tick(object sender, EventArgs e)
        {
            if(coachExpand == false)
            {
                coachContainer.Height += 10;
                if (coachContainer.Height >= 244) {

                    coachTransition.Stop();
                    coachExpand = true;
                }
            }
            else
            {
                coachContainer.Height -= 10;
                if(coachContainer.Height <= 61)
                {
                    coachTransition.Stop();
                    coachExpand = false; 
                }
            }
        }
        private void bntcoach_Click(object sender, EventArgs e)
        {
            coachTransition.Start();
            label2.Text = "Coach";   
        }

        bool SidebarExpand = true;
        private void SidebarTransition_Tick(object sender, EventArgs e)
        {

        }
        private void slidebar_Paint(object sender, PaintEventArgs e)
        {

        }
        private void bntham_Click(object sender, EventArgs e)
        {
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (homepage == null)
            {
                homepage = new Form4();
                homepage.FormClosed += homepage_FormClosed;
                homepage.MdiParent = this;
                homepage.Dock = DockStyle.Fill;
                homepage.Show();
            }
            else
            {
                homepage.Activate();
            }
        }
        private void homepage_FormClosed(object sender, FormClosedEventArgs e)
        {
            homepage = null;
        }

        private void Profile_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }

        private void bntcoachlilli_Click(object sender, EventArgs e)
        {
            if (lilli == null)
            {
                lilli = new CoachLilli();
                lilli.FormClosed += Lilli_FormClosed;
                lilli.MdiParent = this;
                lilli.Dock = DockStyle.Fill;
                lilli.Show();
            }
            else
            {
                lilli.Activate();
            }
        }

        private void Lilli_FormClosed(object sender, FormClosedEventArgs e)
        {
            lilli = null;
        }

        private void bntcoachjames_Click(object sender, EventArgs e)
        {
            if (james == null)
            {
                james = new CoachJames();
                james.FormClosed += James_FormClosed;
                james.MdiParent = this;
                james.Dock = DockStyle.Fill;
                james.Show();
            }
            else
            {
                james.Activate();
            }
        }

        private void James_FormClosed(object sender, FormClosedEventArgs e)
        {
            james.Activate();
        }

        private void bntcoachAlex_Click(object sender, EventArgs e)
        {
            if (alex == null)
            {
                alex = new CoachAlex();
                alex.FormClosed += Alex_FormClosed;
                alex.MdiParent = this;
                alex.Dock = DockStyle.Fill;
                alex.Show();
            }
            else
            {
                alex.Activate();
            }
        }

        private void Alex_FormClosed(object sender, FormClosedEventArgs e)
        {
            alex.Activate();
        }

        private void bntMembership_Click(object sender, EventArgs e)
        {
            if(membership == null)
            {
                membership = new formMembership();
                membership.FormClosed += Membership_FormClosed;
                membership.MdiParent = this;
                membership.Dock = DockStyle.Fill;
                membership.Show();
            }
            else
            {
                membership.Activate();
            }
            label2.Text = "Membership";
        }

        private void Membership_FormClosed(object sender, FormClosedEventArgs e)
        {
            membership = null;
        }

        private void bntschedule_Click(object sender, EventArgs e)
        {
            if (schedule == null)
            {
                schedule = new formSchedule();
                schedule.FormClosed += Schedule_FormClosed;
                schedule.MdiParent = this;
                schedule.Dock = DockStyle.Fill;
                schedule.Show();
            }
            else
            {
                schedule.Activate();

            }
            label2.Text = "Schedule";
        }

        private void Schedule_FormClosed(object sender, FormClosedEventArgs e)
        {
            schedule = null;
        }

        private void bntequipment_Click(object sender, EventArgs e)
        {
            if (equipment == null)
            {
                equipment = new formEquipment();
                equipment.FormClosed += Equipment_FormClosed;
                equipment.MdiParent = this;
                equipment.Dock = DockStyle.Fill;
                equipment.Show();
            }
            else
            {
                equipment.Activate();
            }
            label2.Text = "Equipment";
        }

        private void Equipment_FormClosed(object sender, FormClosedEventArgs e)
        {
            equipment = null;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {


        }

        private void membership1_Load(object sender, EventArgs e)
        {

        }

        private void bunifuTileButton1_Click(object sender, EventArgs e)
        {
           
        }
        private void Profile1_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {

        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (about_Us == null)
            {
                about_Us = new About_us();
                about_Us.FormClosed += About_us_FormClosed;
                about_Us.MdiParent = this;
                about_Us.Dock = DockStyle.Fill;
                about_Us.Show();
            }
            else
            {
                about_Us.Activate();
            }
            label2.Text = "About Us";
        }
        private void About_us_FormClosed(object sender, FormClosedEventArgs e)
        {
            about_Us = null;
        }

        private void bntbronze_Click(object sender, EventArgs e)
        {
        }

        private void Bronze_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void planTransition_Tick(object sender, EventArgs e)
        {
           
        }

        private void bntmembership_Click_1(object sender, EventArgs e)
        {
            planTransition.Start();

            if ( membership == null)
            {
                membership = new formMembership();
                membership.FormClosed += Membership_FormClosed1;
                membership.MdiParent = this;
                membership.Dock = DockStyle.Fill;
                membership.Show();
            }
            else
            {
                membership.Activate();
            }
            label2.Text = "Membership";

        }

        private void Membership_FormClosed1(object sender, FormClosedEventArgs e)
        {
            membership = null;
        }

        private void bntday_Click(object sender, EventArgs e)
        {
            
        }

        private void Perday_FormClosed(object sender, FormClosedEventArgs e)
        {
            perday = null;
        }

        private void bntbro_Click(object sender, EventArgs e)
        {
           
        }

        private void Bronze_FormClosed1(object sender, FormClosedEventArgs e)
        {
            bronze = null;
        }

        private void bntsil_Click(object sender, EventArgs e)
        {
            
        }

        private void Silver_FormClosed(object sender, FormClosedEventArgs e)
        {
            silver = null;
        }

        private void bntgo_Click(object sender, EventArgs e)
        {
           
        }

        private void Gold_FormClosed(object sender, FormClosedEventArgs e)
        {
            gold = null;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }   
}
