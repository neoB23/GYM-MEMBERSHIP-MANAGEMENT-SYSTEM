using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        private bool IsNumeric(string text)
        {
            foreach (char c in text)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
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
            dataGridView2.DataSource = dt;
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
        private void dataGridView2_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView2.Rows.Count)
            {
                txtfirstname.Text = dataGridView2.Rows[e.RowIndex].Cells["firstname"].Value?.ToString() ?? "";
                txtlastname.Text = dataGridView2.Rows[e.RowIndex].Cells["lastname"].Value?.ToString();
                txtusername.Text = dataGridView2.Rows[e.RowIndex].Cells["username"].Value?.ToString();
                txtpassword.Text = dataGridView2.Rows[e.RowIndex].Cells["password"].Value?.ToString();
                txtemail.Text = dataGridView2.Rows[e.RowIndex].Cells["email"].Value?.ToString();
            }
        }

        private void UserControl5_Load(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //may error sa pag update ng username
            // Check if all required fields are filled
            if (!string.IsNullOrWhiteSpace(txtfirstname.Text) &&
                !string.IsNullOrWhiteSpace(txtusername.Text) &&
                !string.IsNullOrWhiteSpace(txtpassword.Text) &&
                !string.IsNullOrWhiteSpace(txtlastname.Text) &&
                !string.IsNullOrWhiteSpace(txtemail.Text))
                
            {
                string sql = "UPDATE admin SET username = @username, password = @password, email = @email, lastname = @lastname WHERE firstname = @FirstName";
                cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@FirstName", txtfirstname.Text);
                cmd.Parameters.AddWithValue("@LastName", txtlastname.Text);
                cmd.Parameters.AddWithValue("@username", txtusername.Text);
                cmd.Parameters.AddWithValue("@password", txtpassword.Text);
                cmd.Parameters.AddWithValue("@email", txtemail.Text);
                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                con.Close();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Admin information updated successfully!", "UPDATE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DisplayData();
                    ClearData();
                }
                else
                {
                    MessageBox.Show("No Admin found with this name!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Fill out all the information needed", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtfirstname.Text))
            {
                string sql = "DELETE FROM admin WHERE firstname=@firstname";
                cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@firstname", txtfirstname.Text);
                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                con.Close();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("admin deleted successfully!", "DELETE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DisplayData();
                    ClearData();
                }
                else
                {
                    MessageBox.Show("No admin found with this name!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Enter the name of the admin you want to delete", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtusername.Text) ||
                string.IsNullOrWhiteSpace(txtpassword.Text) ||
                string.IsNullOrWhiteSpace(txtfirstname.Text) ||
                string.IsNullOrWhiteSpace(txtlastname.Text) ||
                string.IsNullOrWhiteSpace(txtemail.Text))
                
            {
                MessageBox.Show("Fill up all information", "Error");
                return;
            }

            MySqlCommand cmd1 = new MySqlCommand("SELECT * FROM admin WHERE FirstName = @firstname", con); // Changed column name in the query
            cmd1.Parameters.AddWithValue("@firstname", txtfirstname.Text);
            con.Open();
            bool userExists = false;
            using (var dr1 = cmd1.ExecuteReader())
            {
                userExists = dr1.HasRows;
                if (userExists)
                {
                    MessageBox.Show("Username not available!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    con.Close();
                    return;
                }
            }
            con.Close();
            string passwordPattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$";
            //address min input wala pa pati sa email add
            
            int minimumUsernameLength = 6;
            int minimumPasswordLength = 8;
            int minimumFirstNameLength = 3;
            int minimumLastNameLength = 3;
            int minimumEmailadLength = 4;

            if (!txtemail.Text.Contains("@gmail.com"))
            {
                MessageBox.Show("Email address should contain '@gmail' symbol", "Error");
                return;
            }
            if (txtemail.Text.Length < minimumEmailadLength)
            {
                MessageBox.Show($"Email address must be at least {minimumEmailadLength} characters long", "Error");
            }
            // Check other validations if all fields are filled and phone number is numeric
            if (txtusername.Text.Length < minimumUsernameLength)
            {
                // Display error message if username length is less than minimum
                MessageBox.Show($"Username must be at least {minimumUsernameLength} characters long", "Error");
                return;
            }
            else if (txtpassword.Text.Length < minimumPasswordLength)
            {
                // Display error message if password length is less than minimum
                MessageBox.Show($"Password must be at least {minimumPasswordLength} characters long", "Error");
                return;
            }
            else if (!Regex.IsMatch(txtpassword.Text, passwordPattern))
            {
                // Display error message if password format is incorrect
                MessageBox.Show("Password must contain at least one uppercase letter, one lowercase letter, one special character, one number, and be at least 8 characters long", "Error");
                return;
            }
            else if (txtfirstname.Text.Length < minimumFirstNameLength || txtlastname.Text.Length < minimumLastNameLength)
            {
                // Display error message if first name or last name length is less than minimum
                MessageBox.Show($"First name and Last name must be at least {minimumFirstNameLength} characters long", "Error");
                return;
            }
            MySqlCommand cmd = new MySqlCommand("INSERT INTO Admin(username, password, email, firstname, lastname) VALUES(@username, @password, @email, @firstname, @lastname)", con);
            con.Open();
            cmd.Parameters.AddWithValue("@firstname", txtfirstname.Text);
            cmd.Parameters.AddWithValue("@lastname", txtlastname.Text);
            cmd.Parameters.AddWithValue("@username", txtusername.Text);
            cmd.Parameters.AddWithValue("@password", txtpassword.Text);
            cmd.Parameters.AddWithValue("@email", txtemail.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Admin added successfully", "SAVE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DisplayData();
            ClearData();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
