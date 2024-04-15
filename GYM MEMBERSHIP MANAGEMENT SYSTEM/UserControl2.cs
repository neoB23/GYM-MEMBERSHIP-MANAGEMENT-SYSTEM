using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Linq;

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
        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtusername.Text) ||
                string.IsNullOrWhiteSpace(txtpassword.Text) ||
                string.IsNullOrWhiteSpace(txtfirstname.Text) ||
                string.IsNullOrWhiteSpace(txtlastname.Text) ||
                timepicker.Value == null ||
                string.IsNullOrWhiteSpace(txtphonenum.Text) ||
                string.IsNullOrWhiteSpace(txtemailadd.Text) ||
                string.IsNullOrWhiteSpace(txtadd.Text) ||
                cmbgender.SelectedItem == null ||
                cmbmembership.SelectedItem == null)
            {
                MessageBox.Show("Fill up all information", "Error");
                return;
            }

            MySqlCommand cmd1 = new MySqlCommand("SELECT * FROM user WHERE FirstName = @firstname", con); // Changed column name in the query
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
            int minimumPhoneNumLength = 11;
            int minimumFirstNameLength = 3;
            int minimumLastNameLength = 3;
            int minimumAddressLength = 6;
            int minimumEmailadLength = 4;

            if (!txtemailadd.Text.Contains("@gmail.com"))
            {
                MessageBox.Show("Email address should contain '@gmail' symbol", "Error");
                return;
            }
            if (txtemailadd.Text.Length < minimumEmailadLength)
            {
                MessageBox.Show($"Email address must be at least {minimumEmailadLength} characters long", "Error");
            }
            if (txtadd.Text.Length < minimumAddressLength)
            {
                MessageBox.Show($"Address must be at least {minimumAddressLength} characters long", "Error");
            }
            if (!IsNumeric(txtphonenum.Text))
            {
                MessageBox.Show("Phone number should contain only numeric characters", "Error");
                return; // Return without further processing if phone number is not numeric
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
            else if (txtphonenum.Text.Length < minimumPhoneNumLength)
            {
                // Display error message if phone number length is less than minimum
                MessageBox.Show($"Phone number must be at least {minimumPhoneNumLength} characters long", "Error");
                return;
            }
            else if (txtfirstname.Text.Length < minimumFirstNameLength || txtlastname.Text.Length < minimumLastNameLength)
            {
                // Display error message if first name or last name length is less than minimum
                MessageBox.Show($"First name and Last name must be at least {minimumFirstNameLength} characters long", "Error");
                return;
            }
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(txtpassword.Text);
            // Adds a User in the Database
            MySqlCommand cmd = new MySqlCommand("INSERT INTO user(firstname, lastname, username, password, emailadress, address, phonenumber, gender, membershipplan) VALUES(@firstname, @lastname, @username, @password, @emailadress, @address, @phonenumber, @gender, @membershipplan)", con); 
            con.Open();
            cmd.Parameters.AddWithValue("@firstname", txtfirstname.Text);
            cmd.Parameters.AddWithValue("@lastname", txtlastname.Text);
            cmd.Parameters.AddWithValue("@username", txtusername.Text);
            cmd.Parameters.AddWithValue("@password", hashedPassword);
            cmd.Parameters.AddWithValue("@dateofbirth", timepicker.Value);
            cmd.Parameters.AddWithValue("@phonenumber", txtphonenum.Text);
            cmd.Parameters.AddWithValue("@address", txtadd.Text);
            cmd.Parameters.AddWithValue("@emailadress", txtemailadd.Text);
            cmd.Parameters.AddWithValue("@membershipplan", cmbmembership.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@gender", cmbgender.SelectedItem.ToString());
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Member added successfully", "SAVE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DisplayData();
            ClearData();
        }
        private void UserControl2_Load(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Check if all required fields are filled
            if (!string.IsNullOrWhiteSpace(txtfirstname.Text) &&
                !string.IsNullOrWhiteSpace(txtusername.Text) &&
                !string.IsNullOrWhiteSpace(txtadd.Text) &&
                !string.IsNullOrWhiteSpace(txtlastname.Text) &&
                !string.IsNullOrWhiteSpace(txtemailadd.Text) &&
                !string.IsNullOrWhiteSpace(txtpassword.Text) &&
                timepicker.Value != null &&
                !string.IsNullOrWhiteSpace(txtphonenum.Text) &&
                cmbgender.SelectedItem != null &&
                cmbmembership.SelectedItem != null)
            {
                string sql = "UPDATE user SET lastname = @lastname, username = @username, password = @password, emailadress = @emailadress, address = @address, phonenumber = @phonenumber, gender = @gender, membershipplan = @membershipplan WHERE firstname = @FirstName";
                cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@lastname", txtlastname.Text);
                cmd.Parameters.AddWithValue("@username", txtusername.Text);
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(txtpassword.Text);
                cmd.Parameters.AddWithValue("@password", hashedPassword);
                cmd.Parameters.AddWithValue("@emailadress", txtemailadd.Text);
                cmd.Parameters.AddWithValue("@address", txtadd.Text);
                cmd.Parameters.AddWithValue("@phonenumber", txtphonenum.Text);
                cmd.Parameters.AddWithValue("@gender", cmbgender.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@membershipplan", cmbmembership.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@FirstName", txtfirstname.Text); // Set first name last
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


        private void DisplayData()
        {
            string sql = "SELECT id, firstname, lastname, username, password, emailadress, address, phonenumber, gender, account_created, membershipplan, img FROM user";
            cmd = new MySqlCommand(sql, con);
            adapt = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            dataGridView2.DataSource = dt;
        }


        private void ClearData()
        {
            txtusername.Text = "";
            txtfirstname.Text = "";
            txtlastname.Text = "";
            txtemailadd.Text = "";
            txtpassword.Text = "";
            cmbgender.Text = "";
            txtphonenum.Text = "";
            txtadd.Text = "";
            timepicker.Value = DateTime.Now;
            cmbmembership.SelectedItem = null;
        }
        private void dataGridView2_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView2.Rows.Count)
            {
                txtfirstname.Text = dataGridView2.Rows[e.RowIndex].Cells["firstname"].Value?.ToString() ?? "";
                txtlastname.Text = dataGridView2.Rows[e.RowIndex].Cells["lastname"].Value?.ToString();
                txtusername.Text = dataGridView2.Rows[e.RowIndex].Cells["username"].Value?.ToString();
                txtpassword.Text = dataGridView2.Rows[e.RowIndex].Cells["password"].Value?.ToString();
                txtemailadd.Text = dataGridView2.Rows[e.RowIndex].Cells["emailadress"].Value?.ToString();
                txtadd.Text = dataGridView2.Rows[e.RowIndex].Cells["address"].Value?.ToString();
                txtphonenum.Text = dataGridView2.Rows[e.RowIndex].Cells["phonenumber"].Value?.ToString();
                if (dataGridView2.Columns.Contains("gender") && dataGridView2.Rows[e.RowIndex].Cells["gender"].Value != null)
                    cmbgender.SelectedItem = dataGridView2.Rows[e.RowIndex].Cells["gender"].Value.ToString();
                else
                    cmbgender.SelectedItem = null;
                if (dataGridView2.Columns.Contains("membershipplan") && dataGridView2.Rows[e.RowIndex].Cells["membershipplan"].Value != null)
                    cmbmembership.SelectedItem = dataGridView2.Rows[e.RowIndex].Cells["membershipplan"].Value.ToString();
                else
                    cmbmembership.SelectedItem = null;
            }
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtfirstname.Text))
            {
                string sql = "DELETE FROM user WHERE firstname=@firstname";
                cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@firstname", txtfirstname.Text); 
                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                con.Close();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Member deleted successfully!", "DELETE", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void bunifuCustomDataGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        

        private void txtemailadd_TextChanged(object sender, EventArgs e)
        {

        }


        private void cmbmembership_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtpassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
