using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GYM_MEMBERSHIP_MANAGEMENT_SYSTEM
{
    public partial class UserControl2 : UserControl
    {
        MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=gym membership management;sslMode=none");
        MySqlCommand cmd;
        MySqlDataAdapter adapt;
        public UserControl2()
        {
            InitializeComponent();
            DisplayData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {

        }

        private void UserControl2_Load(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }
        private void DisplayData()
        {
            string sql = "SELECT id, firstname, lastname, username, password, emailadress, address, phonenumber, gender, account_created, membershipplan FROM register"; // Changed column names
            cmd = new MySqlCommand(sql, con);
            adapt = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        // Clears the Data  
        private void ClearData()
        {
            txtusername.Text = "";
            txtfirstname.Text = "";
            txtlastname.Text = "";
            txtemailadd.Text = "";
            txtpassword.Text = "";
            txtgender.Text = "";
            txtphonenum.Text = "";
            txtadd.Text = "";
            timepicker.Value = DateTime.Now;
            cmbmembership.SelectedItem = null;
        }
    }
}
