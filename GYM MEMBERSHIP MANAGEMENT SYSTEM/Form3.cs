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
using BCrypt.Net;

namespace GYM_MEMBERSHIP_MANAGEMENT_SYSTEM
{
    public partial class Form3 : Form
    {
        MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=gym membership management;sslMode=none");
        public Form3()
        {
            InitializeComponent();
        }

        private void BntRegister_Click(object sender, EventArgs e)
        {
            string passwordPattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$";
            int minimumUsernameLength = 6;
            int minimumPasswordLength = 8;

            if (string.IsNullOrWhiteSpace(txtusername.Text) || string.IsNullOrWhiteSpace(txtpassword.Text) || string.IsNullOrWhiteSpace(txtconfirmpass.Text))
            {
                MessageBox.Show("Fill up all information", "Error");
                return;
            }

            if (!txtpassword.Text.Equals(txtconfirmpass.Text))
            {
                errorProvider1.SetError(txtconfirmpass, "Passwords do not match");
                MessageBox.Show("Passwords do not match", "Error");
                return;
            }

            if (!Regex.IsMatch(txtpassword.Text, passwordPattern))
            {
                errorProvider1.SetError(txtpassword, "Password must contain at least one uppercase letter, one lowercase letter, one special character, one number, and be at least 8 characters long");
                MessageBox.Show("Password must contain at least one uppercase letter, one lowercase letter, one special character, one number, and be at least 8 characters long", "Error");
                return;
            }

            if (txtusername.Text.Length < minimumUsernameLength)
            {
                errorProvider1.SetError(txtusername, $"Username must be at least {minimumUsernameLength} characters long");
                MessageBox.Show($"Username must be at least {minimumUsernameLength} characters long", "Error");
                return;
            }

            if (txtpassword.Text.Length < minimumPasswordLength)
            {
                errorProvider1.SetError(txtpassword, $"Password must be at least {minimumPasswordLength} characters long");
                MessageBox.Show($"Password must be at least {minimumPasswordLength} characters long", "Error");
                return;
            }
            try
            {
                con.Open();

                // Check if username exists
                string checkUsernameQuery = "SELECT COUNT(*) FROM user_account WHERE userUserName = @userUserName";
                MySqlCommand checkUsernameCmd = new MySqlCommand(checkUsernameQuery, con);
                checkUsernameCmd.Parameters.AddWithValue("@userUserName", txtusername.Text);
                int usernameCount = Convert.ToInt32(checkUsernameCmd.ExecuteScalar());

                if (usernameCount > 0)
                {
                    MessageBox.Show("Username already taken", "Error");
                    return;
                }

                // Hash the password before saving it
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(txtpassword.Text);

                string insertQuery = "INSERT INTO user_account (userUserName, userPassword) VALUES (@userUserName, @userPassword)";
                MySqlCommand cmd = new MySqlCommand(insertQuery, con);
                cmd.Parameters.AddWithValue("@userUserName", txtusername.Text);
                cmd.Parameters.AddWithValue("@userPassword", hashedPassword);
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
        private void pictureBox12_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void bntview_Click(object sender, EventArgs e)
        {
            
        }
        private void bntview_Click_1(object sender, EventArgs e)
        {
            if (txtpassword.PasswordChar == '\0')
            {
                bnthide.BringToFront();
                txtpassword.PasswordChar = '*';
            }
        }
        private void bnthide_Click(object sender, EventArgs e)
        {
            if (txtpassword.PasswordChar == '*')
            {
                bntview.BringToFront();
                txtpassword.PasswordChar = '\0';
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (txtconfirmpass.PasswordChar == '*')
            {
                pictureBox3.BringToFront();
                txtconfirmpass.PasswordChar = '\0';
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (txtconfirmpass.PasswordChar == '\0')
            {
                pictureBox2.BringToFront();
                txtconfirmpass.PasswordChar = '*';
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
