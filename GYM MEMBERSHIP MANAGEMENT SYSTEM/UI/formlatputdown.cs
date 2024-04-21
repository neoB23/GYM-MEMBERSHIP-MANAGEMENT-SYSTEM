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
    public partial class formlatputdown : Form
    {
        public formlatputdown()
        {
            InitializeComponent();
        }

        private void bntbackdown_Click(object sender, EventArgs e)
        {

        }
        int i;
        private void formlatputdown_Load(object sender, EventArgs e)
        {
            i = formEquipment.parentX = 130;
            this.Location = new Point(formEquipment.parentX + 100, formEquipment.parentY + 145);
        }

        private void laputeffect_Tick(object sender, EventArgs e)
        {
            if (Opacity >= 1)
            {
                laputeffect.Stop();
            }
            else
            {
                Opacity += .04;
            }

            int y = formEquipment.parentY += 5;
            this.Location = new Point(formEquipment.parentX + 65, y);
            if (y >= i)
            {
                laputeffect.Stop();
            }
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
    }
}
