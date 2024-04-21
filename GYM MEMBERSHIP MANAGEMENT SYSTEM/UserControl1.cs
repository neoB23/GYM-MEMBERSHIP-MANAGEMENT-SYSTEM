using MySql.Data.MySqlClient;
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
            if (!string.IsNullOrEmpty(txtfirstname.Text))
            {
                string sql = "DELETE FROM coach WHERE coachFirstName=@coachFirstNam";
                cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@coachFirstNam", txtfirstname.Text);
                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                con.Close();
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
            // Check if all required fields are filled
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
                return;
            }

            // Validate password complexity and length
            string passwordPattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$";
            int minimumPasswordLength = 8;
            if (!Regex.IsMatch(txtpassword.Text, passwordPattern) || txtpassword.Text.Length < minimumPasswordLength)
            {
                MessageBox.Show("Password must be at least 8 characters long and contain at least one uppercase letter, one lowercase letter, one special character, and one number.", "Error");
                return;
            }

            // Hash the password
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(txtpassword.Text);

            // Insert coach data into the coach table
            MySqlCommand cmd = new MySqlCommand("INSERT INTO Coach(coachFirstName, coachLastName, coachUsername, coachPassword, coachDateofBirth, coachContactnumber, coachExperience, coachGender) VALUES(@coachFirstName, @coachLastName, @coachUsername, @coachPassword, @coachDateofBirth, @coachContactnumber, @coachExperience, @coachGender)", con);
            con.Open();
            cmd.Parameters.AddWithValue("@coachFirstName", txtfirstname.Text);
            cmd.Parameters.AddWithValue("@coachLastName", txtlastname.Text);
            cmd.Parameters.AddWithValue("@coachUsername", txtusername.Text);
            cmd.Parameters.AddWithValue("@coachPassword", hashedPassword);
            cmd.Parameters.AddWithValue("@coachDateofBirth", timepicker.Value);
            cmd.Parameters.AddWithValue("@coachContactnumber", txtphonenumber.Text);
            cmd.Parameters.AddWithValue("@coachExperience", txtexp.Text);
            cmd.Parameters.AddWithValue("@coachGender", cmbgender.SelectedItem.ToString());
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
                txtfirstname.Text = dataGridView2.Rows[e.RowIndex].Cells["coachFirstName"].Value?.ToString() ?? "";
                txtlastname.Text = dataGridView2.Rows[e.RowIndex].Cells["coachLastName"].Value?.ToString();
                txtusername.Text = dataGridView2.Rows[e.RowIndex].Cells["coachUsername"].Value?.ToString();
                txtpassword.Text = dataGridView2.Rows[e.RowIndex].Cells["coachPassword"].Value?.ToString();

                if (DateTime.TryParse(dataGridView2.Rows[e.RowIndex].Cells["coachDateofBirth"].Value?.ToString(), out DateTime dob))
                    timepicker.Value = dob;
                txtphonenumber.Text = dataGridView2.Rows[e.RowIndex].Cells["coachContactnumber"].Value?.ToString();
                txtexp.Text = dataGridView2.Rows[e.RowIndex].Cells["coachExperience"].Value?.ToString();

                if (dataGridView2.Columns.Contains("coachGender") && dataGridView2.Rows[e.RowIndex].Cells["coachGender"].Value != null)
                    cmbgender.SelectedItem = dataGridView2.Rows[e.RowIndex].Cells["coachGender"].Value.ToString();
                else
                    cmbgender.SelectedItem = null;
            }
        }

        private void DisplayData()
        {
            string sql = "SELECT coachFirstName, coachLastName, coachUsername, coachPassword, coachDateofBirth, coachContactnumber, coachExperience, coachGender FROM Coach";
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
            // Check if all required fields are filled
            if (!string.IsNullOrWhiteSpace(txtfirstname.Text) &&
                !string.IsNullOrWhiteSpace(txtlastname.Text) &&
                !string.IsNullOrWhiteSpace(txtpassword.Text) &&
                timepicker.Value != null &&
                !string.IsNullOrWhiteSpace(txtphonenumber.Text) &&
                !string.IsNullOrWhiteSpace(txtexp.Text) &&
                cmbgender.SelectedItem != null)
            {
                string sql = "UPDATE coach SET coachLastName = @coachLastName, coachUsername = @coachUsername, coachPassword = @coachPassword, coachDateofBirth = @coachDateofBirth, coachContactnumber = @coachContactnumber, coachExperience = @coachExperience, coachGender = @coachGender WHERE coachFirstName = @coachFirstName";
                cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@coachLastName", txtlastname.Text); // Set last name first
                cmd.Parameters.AddWithValue("@coachUsername", txtusername.Text);
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(txtpassword.Text);
                cmd.Parameters.AddWithValue("@coachPassword", hashedPassword);
                cmd.Parameters.AddWithValue("@coachDateofBirth", timepicker.Value);
                cmd.Parameters.AddWithValue("@coachContactnumber", txtphonenumber.Text);
                cmd.Parameters.AddWithValue("@coachExperience", txtexp.Text);
                cmd.Parameters.AddWithValue("@coachGender", cmbgender.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@coachFirstName", txtfirstname.Text); // Set first name last
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



        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtfirstname_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtexp_TextChanged(object sender, EventArgs e)
        {

        }

        private void timepicker_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cmbgender_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtpassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuTextbox1_OnTextChange(object sender, EventArgs e)
        {
            string searchText = bunifuTextbox1.text.Trim();
            SearchData(searchText);
        }

        private void bunifuTextbox1_KeyPress(object sender, EventArgs e)
        {

        }
        private void SearchData(string searchText)
        {
            string sql = "SELECT coachFirstName, coachLastName, coachUsername, coachPassword, coachDateofBirth, coachContactnumber, coachExperience, coachGender FROM Coach WHERE coachFirstName LIKE @searchText OR coachLastName LIKE @searchText OR coachUsername LIKE @searchText";
            cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@searchText", "%" + searchText + "%");
            adapt = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            dataGridView2.DataSource = dt;
        }

        private void bunifuTextbox1_Enter(object sender, EventArgs e)
        {
            if (bunifuTextbox1.Text == "Search for username")
            {
                bunifuTextbox1.Text = "";
                bunifuTextbox1.ForeColor = Color.Orange;
            }
        }

        private void bunifuTextbox1_Leave(object sender, EventArgs e)
        {
            // Check if the search box is currently empty
            if (string.IsNullOrWhiteSpace(bunifuTextbox1.Text))
            {
                // If it's empty, restore the default search text and change the color to silver
                bunifuTextbox1.Text = "Search for username";
                bunifuTextbox1.ForeColor = Color.Silver;
            }
        }

        /* private string Hash(string input)
{
// Generate a salt and hash the password
return BCrypt.Net.BCrypt.HashPassword(input, BCrypt.Net.BCrypt.GenerateSalt());
}*/
    }
}
