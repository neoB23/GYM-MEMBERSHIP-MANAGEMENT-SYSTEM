using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace GYM_MEMBERSHIP_MANAGEMENT_SYSTEM
{
   
    public partial class UserControl1 : UserControl
    {
        MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=gym membership management;sslMode=none");
        MySqlCommand cmd;
        MySqlDataAdapter adapt;
        public UserControl1()
        {
            InitializeComponent();
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {

        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            // Checks if Username Exists
            MySqlCommand cmd1 = new MySqlCommand("SELECT * FROM coach WHERE FirstName = @firstname", con); // Changed column name in the query
            cmd1.Parameters.AddWithValue("@firstname", txtfirstname.Text);
            con.Open();
            bool userExists = false;
            using (var dr1 = cmd1.ExecuteReader())
            {
                userExists = dr1.HasRows;
                if (userExists)
                {
                    MessageBox.Show("Username not available!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            con.Close();

            if (!userExists)
            {
                // Adds a User in the Database
                if (!string.IsNullOrWhiteSpace(txtfirstname.Text) && !string.IsNullOrWhiteSpace(txtlastname.Text) && !string.IsNullOrWhiteSpace(txtpassword.Text) && timepicker.Value != null && !string.IsNullOrWhiteSpace(txtphonenumber.Text) && !string.IsNullOrWhiteSpace(txtexp.Text) && cmbgender.SelectedItem != null)
                {
                    MySqlCommand cmd = new MySqlCommand("INSERT INTO coach(FirstName, LastName, UserName, Password, DateofBirth, `contactnumber`, Experience, Gender) VALUES(@FirstName, @LastName, @username, @password, @dateofbirth, @contactnum, @exp, @gender)", con); // Changed column names in the query
                    con.Open();
                    cmd.Parameters.AddWithValue("@FirstName", txtfirstname.Text);
                    cmd.Parameters.AddWithValue("@LastName", txtlastname.Text);
                    cmd.Parameters.AddWithValue("@username", txtusername.Text);
                    cmd.Parameters.AddWithValue("@password", txtpassword.Text);
                    cmd.Parameters.AddWithValue("@dateofbirth", timepicker.Value);
                    cmd.Parameters.AddWithValue("@contactnum", txtphonenumber.Text);
                    cmd.Parameters.AddWithValue("@exp", txtexp.Text);
                    cmd.Parameters.AddWithValue("@gender", cmbgender.SelectedItem.ToString());
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("You have successfully rented a car", "SAVE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DisplayData();
                    ClearData();
                }
                else
                {
                    MessageBox.Show("Fill out all the information needed", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtfirstname.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtlastname.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtusername.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtpassword.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString(); // Changed index to match the correct column
            timepicker.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[4].Value); // Convert string to DateTime
            txtphonenumber.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString(); // Changed index to match the correct column
            txtexp.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            cmbgender.SelectedItem = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();

        }
        private void DisplayData()
        {
            string sql = "SELECT firstname, lastname, username, password, dateofbirth, contactnumber, experience FROM coach"; // Changed column names
            cmd = new MySqlCommand(sql, con);
            adapt = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        // Clears the Data  
        private void ClearData()
        {
            txtfirstname.Text = "";
            txtlastname.Text = "";
            txtpassword.Text = "";
            timepicker.Value = DateTime.Now; // Reset timepicker to current time
            txtphonenumber.Text = "";
            txtexp.Text = "";
            cmbgender.SelectedItem = null;
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
