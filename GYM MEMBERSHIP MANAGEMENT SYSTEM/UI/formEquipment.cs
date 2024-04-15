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
        bool picture1Expand = false;
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
        private void bntlegpress_Click(object sender, EventArgs e)
        {
            Form modalBackground= new Form();
            using (formlegpress legpress = new formlegpress()) 
            {
                modalBackground.StartPosition = FormStartPosition.Manual;
                modalBackground.FormBorderStyle = FormBorderStyle.None;
                modalBackground.Opacity = .50d;
                modalBackground.BackColor = Color.Black;
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
