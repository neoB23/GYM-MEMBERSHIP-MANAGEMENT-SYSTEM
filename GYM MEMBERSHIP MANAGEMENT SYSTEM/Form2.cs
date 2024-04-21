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
using GYM_MEMBERSHIP_MANAGEMENT_SYSTEM.UI;
using SYSTEM_GYM;

namespace GYM_MEMBERSHIP_MANAGEMENT_SYSTEM
{
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
        }

        private string Hash(string input)
        {
            return BCrypt.Net.BCrypt.HashPassword(input, BCrypt.Net.BCrypt.GenerateSalt());
        }


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


        }

        private void pictureBox5_MouseLeave_1(object sender, EventArgs e)
        {

        }

        private void pictureBox13_MouseEnter(object sender, EventArgs e)
        {

        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {

        }

        private void pictureBox6_MouseEnter(object sender, EventArgs e)
        {

        }

        private void pictureBox7_MouseEnter(object sender, EventArgs e)
        {


        }

        private void pictureBox7_MouseLeave(object sender, EventArgs e)
        {

        }

        private void pictureBox8_MouseEnter(object sender, EventArgs e)
        {

        }

        private void pictureBox8_MouseLeave(object sender, EventArgs e)
        {

        }

        private void pictureBox11_MouseEnter(object sender, EventArgs e)
        {

        }

        private void pictureBox11_MouseLeave(object sender, EventArgs e)
        {

        }

        private void pictureBox10_MouseEnter(object sender, EventArgs e)
        {

        }

        private void pictureBox10_MouseLeave(object sender, EventArgs e)
        {

        }

        private void pictureBox9_MouseEnter(object sender, EventArgs e)
        {

        }

        private void pictureBox9_MouseLeave(object sender, EventArgs e)
        {

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



        private void BntRegister_Click(object sender, EventArgs e)
        {

            int minimumEmailLength = 5;
            int minimumPhoneNumLength = 11; // Updated minimum phone number length
            int minimumFirstNameLength = 3;
            int minimumLastNameLength = 3;
            int minimumAddressLength = 10;

            errorProvider1.Clear();

            if (string.IsNullOrWhiteSpace(txtemailadd.Text) || string.IsNullOrWhiteSpace(txtphonenum.Text) || string.IsNullOrWhiteSpace(txtfirstname.Text) || string.IsNullOrWhiteSpace(txtlastname.Text) || string.IsNullOrWhiteSpace(cmbgender.Text) || string.IsNullOrWhiteSpace(txtadd.Text))
            {
                MessageBox.Show("Fill up all information", "Error");
                return;
            }

            if (!bunifuCheckbox1.Checked)
            {
                MessageBox.Show("Please agree to the terms and agreement before registering.", "Error");
                return;
            }

            if (!Regex.IsMatch(txtphonenum.Text, @"^\d{11}$")) // Check if phone number is exactly 11 digits
            {
                errorProvider1.SetError(txtphonenum, "Phone number should contain exactly 11 numeric characters");
                MessageBox.Show("Phone number should contain exactly 11 numeric characters", "Error");
                return;
            }

            if (!txtemailadd.Text.EndsWith("@gmail.com", StringComparison.OrdinalIgnoreCase))
            {
                errorProvider1.SetError(txtemailadd, "Email address should end with '@gmail.com'");
                MessageBox.Show("Email address should end with '@gmail.com'", "Error");
                return;
            }

            if (txtphonenum.Text.Length < minimumPhoneNumLength)
            {
                errorProvider1.SetError(txtphonenum, $"Phone number must be exactly {minimumPhoneNumLength} characters long");
                MessageBox.Show($"Phone number must be exactly {minimumPhoneNumLength} characters long", "Error");
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
                string sql = "INSERT INTO user_information (userFirstName, userLastName, userEmail, userAddress, userPhoneNumber, userGender, membershipplan, userCoach) VALUES (@userFirstName, @userLastName, @userEmail, @userAddress, @userPhoneNumber, @userGender, @membershipplan, @userCoach)";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@userFirstName", txtfirstname.Text);
                cmd.Parameters.AddWithValue("@userLastName", txtlastname.Text);
                cmd.Parameters.AddWithValue("@userEmail", txtemailadd.Text);
                cmd.Parameters.AddWithValue("@userAddress", txtadd.Text);
                cmd.Parameters.AddWithValue("@userPhoneNumber", txtphonenum.Text);
                cmd.Parameters.AddWithValue("@userGender", cmbgender.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@membershipplan", cmbmembership.SelectedItem != null ? cmbmembership.SelectedItem.ToString() : string.Empty); // Check if cmbmembership.SelectedItem is not null
                cmd.Parameters.AddWithValue("@userCoach", cmbcoach.SelectedItem != null ? cmbcoach.SelectedItem.ToString() : string.Empty); // Check if cmbcoach.SelectedItem is not null
                cmd.ExecuteNonQuery();
                MessageBox.Show("Applied to Membership Successfully");
                this.Hide();
                formmessage formmessage = new formmessage();
                formmessage.stdName = txtfirstname.Text;
                formmessage.stdMembership = cmbmembership.Text;
                formmessage.ShowDialog();

                this.Hide();
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


            private void bunifuCheckbox1_OnChange_1(object sender, EventArgs e)
        {

        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            formMembership formMembership = Application.OpenForms["FormMembership"] as formMembership;

            if (formMembership == null)
            {
                formMembership = new formMembership();
            }

            formMembership.Show();
            this.Hide();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true; // Cancels the form closing event
                this.Hide(); // Hides the form instead of closing it
            }
        }

        private void bnthide_Click(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbmembership_Click(object sender, EventArgs e)
        {

        }
    }
}

