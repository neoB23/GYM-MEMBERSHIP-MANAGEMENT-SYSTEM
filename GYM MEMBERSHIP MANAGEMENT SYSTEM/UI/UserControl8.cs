using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GYM_MEMBERSHIP_MANAGEMENT_SYSTEM.UI
{
    public partial class UserControl8 : UserControl
    {
        public UserControl8()
        {
            InitializeComponent();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            UserControl8 UserControl8 = new UserControl8();
            this.Hide();
            UserControl8.Show();
        }

        private void UserControl8_Load(object sender, EventArgs e)
        {

        }
    }
}
