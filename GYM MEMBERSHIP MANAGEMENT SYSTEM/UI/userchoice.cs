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
    public partial class userchoice : Form
    {

        formMenu menu;
        CoachLilli lilli;
        CoachJames james;
        CoachAlex alex;
        formMembership membership;
        formSchedule schedule;
        formEquipment equipment;
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
                this.Hide();
                Form Form1 = new Form();
                Form1.Show();
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
                if (coachContainer.Height >= 243) {

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
        }

        bool SidebarExpand = true;
        private void SidebarTransition_Tick(object sender, EventArgs e)
        {
            if (SidebarExpand)
            {
                slidebar.Width -= 20;
                if (slidebar.Width <= 63)
                {
                    SidebarExpand = false;
                    SidebarTransition.Stop();

                    pnMenu.Width = slidebar.Width;
                    coachContainer.Width = slidebar.Width;
                    pnMembership.Width = slidebar.Width;
                    pnschedule.Width = slidebar.Width;
                    pnEquipment.Width = slidebar.Width;
                    pnLogout.Width = slidebar.Width;
                }
            }
            else
            {
                slidebar.Width += 20;
                if (slidebar.Width >= 234)
                {
                    SidebarExpand = true;
                    SidebarTransition.Stop();

                    pnMenu.Width = slidebar.Width;
                    coachContainer.Width = slidebar.Width;
                    pnMembership.Width = slidebar.Width;
                    pnschedule.Width = slidebar.Width;
                    pnEquipment.Width = slidebar.Width;
                    pnLogout.Width = slidebar.Width;
                }
            }
        }

        private void slidebar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bntham_Click(object sender, EventArgs e)
        {
            SidebarTransition.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (menu == null)
            {
                menu = new formMenu();
                menu.FormClosed += Menu_FormClosed;
                menu.MdiParent = this;
                menu.Dock = DockStyle.Fill;
                menu.Show();

            }
            else
            {
                menu.Activate();
            }
        }

        private void Menu_FormClosed(object sender, FormClosedEventArgs e)
        {
            menu = null;
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
        }

        private void Equipment_FormClosed(object sender, FormClosedEventArgs e)
        {
            equipment = null;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {


        }
            
    }
}
