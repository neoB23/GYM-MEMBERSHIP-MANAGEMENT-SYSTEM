using GYM_MEMBERSHIP_MANAGEMENT_SYSTEM.UI;
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
    public partial class formEquipment : Form
    {
        public formEquipment()
        {
            InitializeComponent();
        }
        
        private void formEquipment_Load(object sender, EventArgs e)
        {

        }

        private void picture1Container_MouseEnter(object sender, EventArgs e)
        {

        }


        private void picture1Transition_Tick(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
        public static int parentX, parentY;

        private void bnttreatmill_Click(object sender, EventArgs e)
        {
            Form modalBackground = new Form();
            using (formtreatmill treatmill = new formtreatmill())
            {
                modalBackground.StartPosition = FormStartPosition.Manual;
                modalBackground.FormBorderStyle = FormBorderStyle.None;
                modalBackground.Opacity = .50d;
                modalBackground.BackColor = Color.Black;
                modalBackground.Size = this.Size;
                modalBackground.Location = this.Location;
                modalBackground.ShowInTaskbar = false;
                modalBackground.Show();
                treatmill.Owner = modalBackground;

                parentX = this.Location.X;
                parentY = this.Location.Y;

                treatmill.ShowDialog();
                modalBackground.Dispose();
            }
        }

       
        private void bntbarbel_Click(object sender, EventArgs e)
        {
            Form barbelBackground = new Form();
            using (formbarbel barbel= new formbarbel())
            {
                barbelBackground.StartPosition = FormStartPosition.Manual;
                barbelBackground.FormBorderStyle = FormBorderStyle.None;
                barbelBackground.Opacity = .50d;
                barbelBackground.BackColor = Color.Black;
                barbelBackground.Size = this.Size;
                barbelBackground.Location = this.Location;
                barbelBackground.ShowInTaskbar = false;
                barbelBackground.Show();
                barbel.Owner = barbelBackground;

                parentX = this.Location.X;
                parentY = this.Location.Y;

                barbel.ShowDialog();
                barbelBackground.Dispose();

            }
        }

        private void bntpulldown_Click(object sender, EventArgs e)
        {
            Form modalBackground = new Form();
            using (formlatputdown latputdown= new formlatputdown())
            {
                modalBackground.StartPosition = FormStartPosition.Manual;
                modalBackground.FormBorderStyle = FormBorderStyle.None;
                modalBackground.Opacity = .50d;
                modalBackground.BackColor = Color.Black;
                modalBackground.Size = this.Size;
                modalBackground.Location = this.Location;
                modalBackground.ShowInTaskbar = false;
                modalBackground.Show();
                latputdown.Owner = modalBackground;

                parentX = this.Location.X;
                parentY = this.Location.Y;

                latputdown.ShowDialog();
                modalBackground.Dispose();

            }
        }

        private void bntlegpress_Click(object sender, EventArgs e)
        {
            Form modalBackground= new Form();
            using (formlegpress legpress = new formlegpress()) 
            {
                modalBackground.StartPosition = FormStartPosition.Manual;
                modalBackground.FormBorderStyle = FormBorderStyle.None;
                modalBackground.Opacity = .0d;
                modalBackground.Size = this.Size;
                modalBackground.Location = this.Location;
                modalBackground.ShowInTaskbar = false;
                modalBackground.Show();
                legpress.Owner = modalBackground;

                parentX = this.Location.X;
                parentY = this.Location.Y;

                legpress.ShowDialog();
                modalBackground.Dispose();

               
            }
        }
    }

}
