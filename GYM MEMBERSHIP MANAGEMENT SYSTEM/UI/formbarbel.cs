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
    public partial class formbarbel : Form
    {
        public formbarbel()
        {
            InitializeComponent();
        }
        int i;
        private void formbarbel_Load(object sender, EventArgs e)
        {
            i = formEquipment.parentX = 130;
            this.Location = new Point(formEquipment.parentX + 100, formEquipment.parentY + 145);
        }
       
        private void barbeleffect_Tick(object sender, EventArgs e)
        {
            if (Opacity >= 1)
            {
                barbeleffect.Stop();
            }
            else
            {
                Opacity += .04;
            }

            int y = formEquipment.parentY += 5;
            this.Location = new Point(formEquipment.parentX + 65, y);
            if (y >= i)
            {
                barbeleffect.Stop();
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
