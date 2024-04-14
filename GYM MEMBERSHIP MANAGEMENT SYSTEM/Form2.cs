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
//using BCrypt.Net;

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
            string passwordPattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$";
            int minimumUsernameLength = 6;
            int minimumPasswordLength = 8;
            int minimumEmailLength = 5;
            int minimumPhoneNumLength = 11;
            int minimumFirstNameLength = 3;
            int minimumLastNameLength = 3;
            int minimumAddressLength = 10;

            errorProvider1.Clear();

            if (string.IsNullOrEmpty(txtusername.Text) || string.IsNullOrEmpty(txtpassword.Text) || string.IsNullOrEmpty(txtemailadd.Text) || string.IsNullOrEmpty(txtphonenum.Text) || string.IsNullOrEmpty(txtfirstname.Text) || string.IsNullOrEmpty(txtlastname.Text) || string.IsNullOrEmpty(txtgender.Text) || string.IsNullOrEmpty(txtadd.Text))
            {
                MessageBox.Show("Fill up all information", "Error");
                return;
            }

            if (!bunifuCheckbox1.Checked)
            {
                MessageBox.Show("Please agree to the terms and agreement before registering.", "Error");
                return;
            }

            if (!IsNumeric(txtphonenum.Text))
            {
                errorProvider1.SetError(txtphonenum, "Phone number should contain only numeric characters");
                MessageBox.Show("Phone number should contain only numeric characters", "Error");
                return;
            }

            if (!txtemailadd.Text.Contains("@gmail.com"))
            {
                errorProvider1.SetError(txtemailadd, "Email address should contain '@' symbol");
                MessageBox.Show("Email address should contain '@gmail' symbol", "Error");
                return;
            }

            if (txtusername.Text.Length < minimumUsernameLength)
            {
                errorProvider1.SetError(txtusername, $"Username must be at least {minimumUsernameLength} characters long");
                MessageBox.Show($"Username must be at least {minimumUsernameLength} characters long", "Error");
                return;
            }

            if (txtpassword.Text.Length < minimumPasswordLength || !Regex.IsMatch(txtpassword.Text, passwordPattern))
            {
                errorProvider1.SetError(txtpassword, "Password must contain at least one uppercase letter, one lowercase letter, one special character, one number, and be at least 8 characters long");
                MessageBox.Show("Password must contain at least one uppercase letter, one lowercase letter, one special character, one number, and be at least 8 characters long", "Error");
                return;
            }

            if (txtphonenum.Text.Length < minimumPhoneNumLength)
            {
                errorProvider1.SetError(txtphonenum, $"Phone number must be at least {minimumPhoneNumLength} characters long");
                MessageBox.Show($"Phone number must be at least {minimumPhoneNumLength} characters long", "Error");
                return;
            }

            if (txtemailadd.Text.Length < minimumEmailLength)
            {
                errorProvider1.SetError(txtemailadd, $"Email address must be at least {minimumEmailLength} characters long");
                MessageBox.Show($"Email address must be at least {minimumEmailLength} characters long", "Error");
                return;
            }

            if (txtfirstname.Text.Length < minimumFirstNameLength || txtlastname.Text.Length < minimumLastNameLength)
            {
                errorProvider1.SetError(txtfirstname, $"First name must be at least {minimumFirstNameLength} characters long");
                errorProvider1.SetError(txtlastname, $"Last name must be at least {minimumLastNameLength} characters long");
                MessageBox.Show($"First name and Last name must be at least {minimumFirstNameLength} characters long", "Error");
                return;
            }

            if (txtadd.Text.Length < minimumAddressLength)
            {
                errorProvider1.SetError(txtadd, $"Address must be at least {minimumAddressLength} characters long");
                MessageBox.Show($"Address must be at least {minimumAddressLength} characters long", "Error");
                return;
            }

            try
            {
                con.Open();
                string sql = "INSERT INTO register (username, password, emailadress, phonenumber, firstname, lastname, gender, address) VALUES (@username, @password, @email, @phone, @firstname, @lastname, @gender, @address)";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@username", txtusername.Text);
                cmd.Parameters.AddWithValue("@password", (txtpassword.Text));
                cmd.Parameters.AddWithValue("@email", txtemailadd.Text);
                cmd.Parameters.AddWithValue("@phone", txtphonenum.Text);
                cmd.Parameters.AddWithValue("@firstname", txtfirstname.Text);
                cmd.Parameters.AddWithValue("@lastname", txtlastname.Text);
                cmd.Parameters.AddWithValue("@gender", txtgender.Text);
                cmd.Parameters.AddWithValue("@address", txtadd.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Registered Successfully");

                this.Hide();
                Form1 Frm1 = new Form1();
                Frm1.Show();
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

        /*private string Hash(string input)
        {
            return BCrypt.Net.BCrypt.HashPassword(input, BCrypt.Net.BCrypt.GenerateSalt());
        }*/


        private void Form2_Load(object sender, EventArgs e)
        {

        }
        /*private string Hash(string input)
        {
            return BCrypt.Net.BCrypt.HashPassword(input);
        }*/


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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton21_MouseEnter(object sender, EventArgs e)
        {

        }
    }
}
