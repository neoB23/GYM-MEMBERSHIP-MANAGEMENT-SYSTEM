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
using System.Xml.Linq;

namespace GYM_MEMBERSHIP_MANAGEMENT_SYSTEM
{
    public partial class UserControl5 : UserControl
    {
        MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=gym membership management;sslMode=none");
        MySqlCommand cmd;
        MySqlDataAdapter adapt;
        public UserControl5()
        {
            InitializeComponent();
            DisplayData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void DisplayData()
        {
            string sql = "SELECT id, username, password, email, firstname, lastname, createdat FROM admin"; // Changed column names
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
            txtemail.Text = "";
            txtpassword.Text = "";
            
            
        }

        private void UserControl5_Load(object sender, EventArgs e)
        {

        }
    }
}
