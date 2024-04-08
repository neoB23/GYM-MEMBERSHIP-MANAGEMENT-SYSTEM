using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Bunifu.Framework.UI;
using Guna.UI2.WinForms.Suite;
using MySql.Data.MySqlClient;

namespace GYM_MEMBERSHIP_MANAGEMENT_SYSTEM
{
    //missing function:
    //bawal pareparehas password
    public partial class Form2 : Form
    {
        MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=gym membership management;sslMode=none");
        public Form2()
        {
            InitializeComponent();
           
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
        //mali position mo boi
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form termsagreement = new termsagreement();
            this.Hide();
            termsagreement.Show();
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
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            // for special characters
            string passwordPattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$";
            // Minimum length for infos
            int minimumUsernameLength = 6;
            int minimumPasswordLength = 8;
            int minimumEmailLength = 5; // add function at deny user kapag he/she doesnt input "@"
            int minimumPhoneNumLength = 11; 
            int minimumFirstNameLength = 3;
            int minimumLastNameLength = 3;
            int minimumAddressLength = 10;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtusername.Text) || string.IsNullOrEmpty(txtpassword.Text) || string.IsNullOrEmpty(txtemailadd.Text) || string.IsNullOrEmpty(txtphonenum.Text) || string.IsNullOrEmpty(txtfirstname.Text) || string.IsNullOrEmpty(txtlastname.Text) || string.IsNullOrEmpty(txtgender.Text) || string.IsNullOrEmpty(txtadd.Text))
            {
                // Display error messages and error provider for empty fields 

                if (string.IsNullOrEmpty(txtusername.Text))
                    errorProvider1.SetError(txtusername, "Please enter your username");

                if (string.IsNullOrEmpty(txtpassword.Text))
                    errorProvider1.SetError(txtpassword, "Please enter your password");

                if (string.IsNullOrEmpty(txtemailadd.Text))
                    errorProvider1.SetError(txtemailadd, "Please enter your email address");

                if (string.IsNullOrEmpty(txtphonenum.Text))
                    errorProvider1.SetError(txtphonenum, "Please enter your phone number");

                if (string.IsNullOrEmpty(txtfirstname.Text))
                    errorProvider1.SetError(txtfirstname, "Please enter your first name");

                if (string.IsNullOrEmpty(txtlastname.Text))
                    errorProvider1.SetError(txtlastname, "Please enter your last name");

                if (string.IsNullOrEmpty(txtgender.Text))
                    errorProvider1.SetError(txtgender, "Please select your gender");

                if (string.IsNullOrEmpty(txtadd.Text))
                    errorProvider1.SetError(txtadd, "Please enter your address");

                MessageBox.Show("Fill up all information", "Error");
                return;
            }
            //terms and agreement
            if (!bunifuCheckbox1.Checked)
            {
                MessageBox.Show("Please agree to the terms and agreement before registering.", "Error");
                return;
            }
            // Check if contact number contains only numeric characters
            if (!IsNumeric(txtphonenum.Text))
            {
                errorProvider1.SetError(txtphonenum, "Phone number should contain only numeric characters");
                MessageBox.Show("Phone number should contain only numeric characters", "Error");
                return; // Return without further processing if phone number is not numeric
            }
            if (!txtemailadd.Text.Contains("@gmail.com"))
            {
                errorProvider1.SetError(txtemailadd, "Email address should contain '@' symbol");
                MessageBox.Show("Email address should contain '@gmail' symbol", "Error");
                return; // Return without further processing if email address does not contain '@' symbol
            }
            // Check other validations if all fields are filled and phone number is numeric
            if (txtusername.Text.Length < minimumUsernameLength)
            {
                // Display error message if username length is less than minimum
                errorProvider1.SetError(txtusername, $"Username must be at least {minimumUsernameLength} characters long");
                MessageBox.Show($"Username must be at least {minimumUsernameLength} characters long", "Error");
                return;
            }
            else if (txtpassword.Text.Length < minimumPasswordLength)
            {
                // Display error message if password length is less than minimum
                errorProvider1.SetError(txtpassword, $"Password must be at least {minimumPasswordLength} characters long");
                MessageBox.Show($"Password must be at least {minimumPasswordLength} characters long", "Error");
                return;
            }
            else if (!Regex.IsMatch(txtpassword.Text, passwordPattern))
            {
                // Display error message if password format is incorrect
                errorProvider1.SetError(txtpassword, "Password must contain at least one uppercase letter, one lowercase letter, one special character, one number, and be at least 8 characters long");
                MessageBox.Show("Password must contain at least one uppercase letter, one lowercase letter, one special character, one number, and be at least 8 characters long", "Error");
                return;
            }
            else if (txtphonenum.Text.Length < minimumPhoneNumLength)
            {
                // Display error message if phone number length is less than minimum
                errorProvider1.SetError(txtphonenum, $"Phone number must be at least {minimumPhoneNumLength} characters long");
                MessageBox.Show($"Phone number must be at least {minimumPhoneNumLength} characters long", "Error");
                return;
            }

            else if (txtemailadd.Text.Length < minimumEmailLength)
            {
                // Display error message if email length is less than minimum
                errorProvider1.SetError(txtemailadd, $"Email address must be at least {minimumEmailLength} characters long");
                MessageBox.Show($"Email address must be at least {minimumEmailLength} characters long", "Error");
                return;
            }
            else if (txtfirstname.Text.Length < minimumFirstNameLength || txtlastname.Text.Length < minimumLastNameLength)
            {
                // Display error message if first name or last name length is less than minimum
                errorProvider1.SetError(txtfirstname, $"First name must be at least {minimumFirstNameLength} characters long");
                errorProvider1.SetError(txtlastname, $"Last name must be at least {minimumLastNameLength} characters long");
                MessageBox.Show($"First name and Last name must be at least {minimumFirstNameLength} characters long", "Error");
                return;
            }
            else if (txtadd.Text.Length < minimumAddressLength)
            {
                // Display error message if address length is less than minimum
                errorProvider1.SetError(txtadd, $"Address must be at least {minimumAddressLength} characters long");
                MessageBox.Show($"Address must be at least {minimumAddressLength} characters long", "Error");
                return;
            }
            else if (txtusername.Text.Contains("'") || txtpassword.Text.Contains("'"))
            {
                // Display error message if username or password contains invalid characters
                errorProvider1.SetError(txtusername, "Please enter valid characters for username");
                errorProvider1.SetError(txtpassword, "Please enter valid characters");
                return;
            }
            try
            {
                using (MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=gym membership management;sslMode=none"))
                {
                    con.Open(); string sql = "INSERT INTO register (username, password, emailadress, phonenumber, firstname, lastname, gender, address) VALUES (@username, @password, @email, @phone, @firstname, @lastname, @gender, @address)";

                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@username", txtusername.Text);
                    cmd.Parameters.AddWithValue("@password", Hash(txtpassword.Text)); // Hashing the password
                    cmd.Parameters.AddWithValue("@email", txtemailadd.Text);
                    cmd.Parameters.AddWithValue("@phone", txtphonenum.Text);
                    cmd.Parameters.AddWithValue("@firstname", txtfirstname.Text);
                    cmd.Parameters.AddWithValue("@lastname", txtlastname.Text);
                    cmd.Parameters.AddWithValue("@gender", txtgender.Text);
                    cmd.Parameters.AddWithValue("@address", txtadd.Text);
                    cmd.ExecuteNonQuery();
                    this.Hide();
                    Form1 Frm1 = new Form1();
                    Frm1.Show();
                    MessageBox.Show("Registered Successfully");
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void Form2_Load(object sender, EventArgs e)
        {

        }
        // Function to hash the password
        //may error sa hash pero pag tinangal gagana ulet
        private string Hash(string input)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
        private void bunifuCheckbox1_OnChange(object sender, EventArgs e)
        {
            
        }

        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {
            pictureBox4.Visible = false;
            pictureBox3.Visible = true;
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            pictureBox4.Visible = true;
            pictureBox3.Visible = false;
        }
        
        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void txtfirstname_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox5_MouseEnter_1(object sender, EventArgs e)
        {
            pictureBox5.Visible = false;
            pictureBox12.Visible = true;
            
        }

        private void pictureBox5_MouseLeave_1(object sender, EventArgs e)
        {
            pictureBox5.Visible = true;
            pictureBox12.Visible = false;
        }

        private void pictureBox13_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            pictureBox6.Visible = true;
            pictureBox13.Visible = false;
        }

        private void pictureBox6_MouseEnter(object sender, EventArgs e)
        {
            pictureBox6.Visible = false;
            pictureBox13.Visible = true;
        }

        private void pictureBox7_MouseEnter(object sender, EventArgs e)
        {
            pictureBox7.Visible = false;
            pictureBox14.Visible = true;

        }

        private void pictureBox7_MouseLeave(object sender, EventArgs e)
        {
            pictureBox7.Visible = true;
            pictureBox14.Visible = false;
        }

        private void pictureBox8_MouseEnter(object sender, EventArgs e)
        {
            pictureBox8.Visible = false;
            pictureBox15.Visible = true;
        }

        private void pictureBox8_MouseLeave(object sender, EventArgs e)
        {
            pictureBox8.Visible = true;
            pictureBox15.Visible = false;
        }

        private void pictureBox11_MouseEnter(object sender, EventArgs e)
        {
            pictureBox11.Visible = false;
            pictureBox16.Visible = true;
        }

        private void pictureBox11_MouseLeave(object sender, EventArgs e)
        {
            pictureBox11.Visible = true;
            pictureBox16.Visible = false;
        }

        private void pictureBox10_MouseEnter(object sender, EventArgs e)
        {
            pictureBox10.Visible = false;
            pictureBox17.Visible = true;
        }

        private void pictureBox10_MouseLeave(object sender, EventArgs e)
        {
            pictureBox10.Visible = true;
            pictureBox17.Visible = false;
        }

        private void pictureBox9_MouseEnter(object sender, EventArgs e)
        {
            pictureBox9.Visible = false;
            pictureBox18.Visible = true;
        }

        private void pictureBox9_MouseLeave(object sender, EventArgs e)
        {
            pictureBox9.Visible = true;
            pictureBox18.Visible = false;
        }
    }
}
