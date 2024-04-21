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
            dataGridView2.DataError += dataGridView2_DataError;
           
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
            // Check if all required fields are filled
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

            // Check if username already exists
            MySqlCommand cmd1 = new MySqlCommand("SELECT * FROM user_information ui " +
                                                 "LEFT JOIN user_account ua ON ui.User_id = ua.id " +
                                                 "WHERE ua.userUserName = @userUserName", con);
            cmd1.Parameters.AddWithValue("@userUserName", txtusername.Text);
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

            // Insert the new user into the database
            MySqlCommand cmd = new MySqlCommand("INSERT INTO user_information(userFirstName, userLastName, userEmail, userAddress, userPhoneNumber, userGender, userCreatedDate, membershipplan) VALUES(@userFirstName, @userLastName, @userEmail, @userAddress, @userPhoneNumber, @userGender, @userCreatedDate, @membershipplan)", con);
            con.Open();
            cmd.Parameters.AddWithValue("@userFirstName", txtfirstname.Text);
            cmd.Parameters.AddWithValue("@userLastName", txtlastname.Text);
            cmd.Parameters.AddWithValue("@userEmail", txtemailadd.Text);
            cmd.Parameters.AddWithValue("@userAddress", txtadd.Text);
            cmd.Parameters.AddWithValue("@userPhoneNumber", txtphonenum.Text);
            cmd.Parameters.AddWithValue("@userGender", cmbgender.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@userCreatedDate", timepicker.Value);
            cmd.Parameters.AddWithValue("@membershipplan", cmbmembership.SelectedItem.ToString());
            cmd.ExecuteNonQuery();

            // Retrieve the user ID of the newly inserted user
            long userId = cmd.LastInsertedId;

            // Insert username and hashed password into user_account table
            MySqlCommand cmd2 = new MySqlCommand("INSERT INTO user_account( userUserName, userPassword) VALUES(@userUserName, @userPassword)", con);
            cmd2.Parameters.AddWithValue("@userUserName", txtusername.Text);
            cmd2.Parameters.AddWithValue("@userPassword", hashedPassword);
            cmd2.ExecuteNonQuery();

            con.Close();

            // Display success message and refresh data
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
                string sql = "UPDATE user_information AS ui " +
             "LEFT JOIN user_account AS ua ON ui.User_id = ua.id " +
             "SET ui.userLastName = @userLastName, " +
             "    ua.userUserName = @userUserName, " +
             "    ua.userPassword = @userPassword, " +
             "    ui.userEmail = @userEmail, " +
             "    ui.userAddress = @userAddress, " +
             "    ui.userPhoneNumber = @userPhoneNumber, " +
             "    ui.userGender = @userGender, " +
             "    ui.userCreatedDate = @userCreatedDate, " +
             "    ui.membershipplan = @membershipplan " +
             "WHERE ui.userFirstName = @userFirstName";

                cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@userFirstName", txtfirstname.Text);
                cmd.Parameters.AddWithValue("@userLastName", txtlastname.Text);
                cmd.Parameters.AddWithValue("@userUserName", txtusername.Text);
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(txtpassword.Text);
                cmd.Parameters.AddWithValue("@userPassword", hashedPassword);
                cmd.Parameters.AddWithValue("@userCreatedDate", timepicker.Value);
                cmd.Parameters.AddWithValue("@userPhoneNumber", txtphonenum.Text);
                cmd.Parameters.AddWithValue("@userAddress", txtadd.Text);
                cmd.Parameters.AddWithValue("@userEmail", txtemailadd.Text);
                cmd.Parameters.AddWithValue("@membershipplan", cmbmembership.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@userGender", cmbgender.SelectedItem.ToString());
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
            try
            {
                con.Open();
                string sql = @"
            SELECT ui.userFirstName AS `First Name`, ui.userLastName AS `Last Name`, ua.userUserName AS `Username`,
                   ua.userPassword AS `Password`, ui.userEmail AS `Email`, ui.userAddress AS `Address`,
                   ui.userPhoneNumber AS `Phone Number`, ui.userGender AS `Gender`, ui.userCreatedDate AS `Created Account`,
                   ui.membershipplan AS `Membership Plan`
            FROM user_information ui
            LEFT JOIN user_account ua ON ui.User_id = ua.id
        ";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                adapt = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapt.Fill(dt);
                dataGridView2.DataSource = dt;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
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
            try
            {
                if (e.RowIndex >= 0 && e.RowIndex < dataGridView2.Rows.Count)
                {
                    txtfirstname.Text = dataGridView2.Rows[e.RowIndex].Cells["First Name"].Value?.ToString() ?? "";
                    txtlastname.Text = dataGridView2.Rows[e.RowIndex].Cells["Last Name"].Value?.ToString();
                    txtusername.Text = dataGridView2.Rows[e.RowIndex].Cells["Username"].Value?.ToString();
                    txtpassword.Text = dataGridView2.Rows[e.RowIndex].Cells["Password"].Value?.ToString();
                    txtemailadd.Text = dataGridView2.Rows[e.RowIndex].Cells["Email"].Value?.ToString();
                    txtadd.Text = dataGridView2.Rows[e.RowIndex].Cells["Address"].Value?.ToString();
                    txtphonenum.Text = dataGridView2.Rows[e.RowIndex].Cells["Phone Number"].Value?.ToString();
                    if (dataGridView2.Columns.Contains("Gender") && dataGridView2.Rows[e.RowIndex].Cells["Gender"].Value != null)
                        cmbgender.SelectedItem = dataGridView2.Rows[e.RowIndex].Cells["Gender"].Value.ToString();
                    else
                        cmbgender.SelectedItem = null;
                    if (dataGridView2.Columns.Contains("Membership Plan") && dataGridView2.Rows[e.RowIndex].Cells["Membership Plan"].Value != null)
                        cmbmembership.SelectedItem = dataGridView2.Rows[e.RowIndex].Cells["Membership Plan"].Value.ToString();
                    else
                        cmbmembership.SelectedItem = null;
                }
                else
                {
                    MessageBox.Show("Invalid row index", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtfirstname.Text))
            {
                string sql = "DELETE FROM user_information WHERE userFirstName=@userFirstName";
                cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@userFirstName", txtfirstname.Text); 
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
            try
            {
                // Add code here if needed
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void bunifuTextbox1_OnTextChange(object sender, EventArgs e)
        {
            string searchText = bunifuTextbox1.text.Trim();
            SearchData(searchText);
        }
        private void SearchData(string searchText)
        {
            string sql = "SELECT ui.userFirstName AS `First Name`, ui.userLastName AS `Last Name`, ua.userUserName AS `Username`, ua.userPassword AS `Password`, ui.userCreatedDate AS `Created Date`, ui.userPhoneNumber AS `Phone Number`, ui.userEmail AS `Email`, ui.userAddress AS `Address`, ui.userGender AS `Gender`, ui.membershipplan AS `Membership Plan` FROM user_information ui LEFT JOIN user_account ua ON ui.User_id = ua.id WHERE ui.userFirstName LIKE @searchText OR ui.userLastName LIKE @searchText OR ua.userUserName LIKE @searchText";
            cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@searchText", "%" + searchText + "%");
            adapt = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            dataGridView2.DataSource = dt;
        }


        private void dataGridView2_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception is ArgumentException && e.Context == DataGridViewDataErrorContexts.Formatting)
            {
                MessageBox.Show($"An error occurred while processing data: {e.Exception.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.ThrowException = false; // Prevent DataGridView from throwing the exception
            }
            else
            {
                MessageBox.Show("An error occurred while processing data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtusername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
