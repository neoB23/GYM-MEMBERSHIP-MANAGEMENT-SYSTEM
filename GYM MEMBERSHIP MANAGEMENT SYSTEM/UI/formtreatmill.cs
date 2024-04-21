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
    public partial class formtreatmill : Form
    {
        public formtreatmill()
        {
            InitializeComponent();
        }

        private void bntbackbarbel_Click(object sender, EventArgs e)
        {
            formEquipment formEquipment = Application.OpenForms["FormEquipment"] as formEquipment;

            if (formEquipment == null)
            {
                formEquipment = new formEquipment();
            }

            formEquipment.Show();
            this.Hide();
        }


        private void treatmilleffect_Tick(object sender, EventArgs e)
        {
            
            if (Opacity >= 1)
            {
                treatmilleffect.Stop();
            }
            else
            {
                Opacity += .04;
            }

            int y = formEquipment.parentY += 5;
            this.Location = new Point(formEquipment.parentX + 65, y);
            if (y >= i)
            {
                treatmilleffect.Stop();
            }
        }
        int i;
        private void formtreatmill_Load(object sender, EventArgs e)
        {

            i = formEquipment.parentX = 130;
            this.Location = new Point(formEquipment.parentX + 100, formEquipment.parentY + 145);


            int centerX = (Screen.PrimaryScreen.Bounds.Width - this.Width) / 1;
            int centerY = (Screen.PrimaryScreen.Bounds.Height - this.Height) / 300;

            // Set the form's location to the center
            this.Location = new Point(centerX, centerY);
        }
    }
}
