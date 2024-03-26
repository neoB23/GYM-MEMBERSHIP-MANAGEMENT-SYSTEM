﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
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
            DisplayData();
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {

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

        private void btnDelete_Click(object sender, EventArgs e)
        {
           
            // Check if the user name is entered
            if (!string.IsNullOrEmpty(txtfirstname.Text))
            {
                // Create a command to delete the user
                string sql = "DELETE FROM coach WHERE firstname=@firstname";
                cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@firstname", txtfirstname.Text); // Use @firstname instead of @name

                // Open the connection and execute the command
                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                con.Close();

                // Check if any row was affected
                if (rowsAffected > 0)
                {
                    MessageBox.Show("User deleted successfully!", "DELETE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DisplayData();
                    ClearData();
                }
                else
                {
                    MessageBox.Show("No user found with this name!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Enter the name of the user you want to delete", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            // Check if any of the required fields are empty
            if (string.IsNullOrWhiteSpace(txtusername.Text) ||
                string.IsNullOrWhiteSpace(txtpassword.Text) ||
                string.IsNullOrWhiteSpace(txtfirstname.Text) ||
                string.IsNullOrWhiteSpace(txtlastname.Text) ||
                timepicker.Value == null ||
                string.IsNullOrWhiteSpace(txtphonenumber.Text) ||
                string.IsNullOrWhiteSpace(txtexp.Text) ||
                cmbgender.SelectedItem == null)
            {
                MessageBox.Show("Fill up all information", "Error");
                return; // Return without further processing if any field is empty
            }

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
                    con.Close();
                    return;
                }
            }
            con.Close();
            string passwordPattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$";
            int minimumUsernameLength = 6;
            int minimumPasswordLength = 8;
            int minimumPhoneNumLength = 11;
            int minimumFirstNameLength = 3;
            int minimumLastNameLength = 3;

            if (!IsNumeric(txtphonenumber.Text))
            {
                MessageBox.Show("Phone number should contain only numeric characters", "Error");
                return; 
            }
            if (txtusername.Text.Length < minimumUsernameLength)
            {
                MessageBox.Show($"Username must be at least {minimumUsernameLength} characters long", "Error");
                return;
            }
            else if (txtpassword.Text.Length < minimumPasswordLength)
            {
                MessageBox.Show($"Password must be at least {minimumPasswordLength} characters long", "Error");
                return;
            }
            else if (!Regex.IsMatch(txtpassword.Text, passwordPattern))
            {
                MessageBox.Show("Password must contain at least one uppercase letter, one lowercase letter, one special character, one number, and be at least 8 characters long", "Error");
                return;
            }
            else if (txtphonenumber.Text.Length < minimumPhoneNumLength)
            {
                MessageBox.Show($"Phone number must be at least {minimumPhoneNumLength} characters long", "Error");
                return;
            }
            else if (txtfirstname.Text.Length < minimumFirstNameLength || txtlastname.Text.Length < minimumLastNameLength)
            {
                MessageBox.Show($"First name and Last name must be at least {minimumFirstNameLength} characters long", "Error");
                return;
            }
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
            MessageBox.Show("Coach added successfully", "SAVE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DisplayData();
            ClearData();
        }
        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView2.Rows.Count)
            {
                txtfirstname.Text = dataGridView2.Rows[e.RowIndex].Cells["firstname"].Value?.ToString() ?? "";
                txtlastname.Text = dataGridView2.Rows[e.RowIndex].Cells["lastname"].Value?.ToString();
                txtusername.Text = dataGridView2.Rows[e.RowIndex].Cells["username"].Value?.ToString();
                txtpassword.Text = dataGridView2.Rows[e.RowIndex].Cells["password"].Value?.ToString();

                if (DateTime.TryParse(dataGridView2.Rows[e.RowIndex].Cells["dateofbirth"].Value?.ToString(), out DateTime dob))
                    timepicker.Value = dob;
                txtphonenumber.Text = dataGridView2.Rows[e.RowIndex].Cells["contactnumber"].Value?.ToString();
                txtexp.Text = dataGridView2.Rows[e.RowIndex].Cells["experience"].Value?.ToString();

                if (dataGridView2.Columns.Contains("gender") && dataGridView2.Rows[e.RowIndex].Cells["gender"].Value != null)
                    cmbgender.SelectedItem = dataGridView2.Rows[e.RowIndex].Cells["gender"].Value.ToString();
                else
                    cmbgender.SelectedItem = null;
            }
        }
        private void DisplayData()
        {
            string sql = "SELECT firstname, lastname, username, password, dateofbirth, contactnumber, experience, gender FROM coach"; // Changed column names
            cmd = new MySqlCommand(sql, con);
            adapt = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            dataGridView2.DataSource = dt;
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //may error sa pag update ng username
            if (!string.IsNullOrWhiteSpace(txtfirstname.Text) &&
                !string.IsNullOrWhiteSpace(txtlastname.Text) &&
                !string.IsNullOrWhiteSpace(txtpassword.Text) &&
                timepicker.Value != null &&
                !string.IsNullOrWhiteSpace(txtphonenumber.Text) &&
                !string.IsNullOrWhiteSpace(txtexp.Text) &&
                cmbgender.SelectedItem != null)
            {
                string sql = "UPDATE coach SET lastname = @LastName, username = @username, password = @password, dateofbirth = @dateofbirth, contactnumber = @contactnum, experience = @exp, gender = @gender WHERE firstname = @FirstName";
                cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@FirstName", txtfirstname.Text);
                cmd.Parameters.AddWithValue("@LastName", txtlastname.Text);
                cmd.Parameters.AddWithValue("@username", txtusername.Text);
                cmd.Parameters.AddWithValue("@password", txtpassword.Text);
                cmd.Parameters.AddWithValue("@dateofbirth", timepicker.Value);
                cmd.Parameters.AddWithValue("@contactnum", txtphonenumber.Text);
                cmd.Parameters.AddWithValue("@exp", txtexp.Text);
                cmd.Parameters.AddWithValue("@gender", cmbgender.SelectedItem.ToString());
                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                con.Close();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("User information updated successfully!", "UPDATE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DisplayData();
                    ClearData();
                }
                else
                {
                    MessageBox.Show("No user found with this name!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Fill out all the information needed", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
