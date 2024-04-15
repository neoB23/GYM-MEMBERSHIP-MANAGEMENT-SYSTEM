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
    public partial class formlegpress : Form
    {
        public formlegpress()
        {
            InitializeComponent();
        }

        private void modaleffecttimer_Tick(object sender, EventArgs e)
        {
            if (Opacity >= 1)
            {
                modaleffecttimer.Stop();
            }
            else
            {
                Opacity += .03;
            }

            int y = formEquipment.parentY += 3;
            this.Location = new Point(formEquipment.parentX + 400, y);
            if ( y >= i)
            {
                modaleffecttimer.Stop();
            }
        }
        int i;
        private void formlegpress_Load(object sender, EventArgs e)
        {
            i = formEquipment.parentX = 250;
            this.Location = new Point(formEquipment.parentX + 300, formEquipment.parentY + 300);
        }

        private void bntperday_Click(object sender, EventArgs e)
        {

        }

        private void bntlegpress_Click(object sender, EventArgs e)
        {

        }
    }
}
