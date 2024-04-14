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
using Microsoft.VisualBasic.Logging;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Microsoft.VisualBasic.Devices;
using System.Threading;
using Guna.UI2.WinForms.Suite;
using System.Text.RegularExpressions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using SYSTEM_GYM;
//using BCrypt.Net;
using System.Security.Cryptography;



namespace GYM_MEMBERSHIP_MANAGEMENT_SYSTEM
{

    public partial class Form1 : Form
    {
        MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=gym membership management;sslMode=none");
        MySqlCommand cmd;
        MySqlDataAdapter da;
        DataTable dt;
        string sql;
        public Form1()
        {
            InitializeComponent();


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            Form fr2 = new Form2();
            this.Hide();
            fr2.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
           
        }

        

        private void bunifuThinButton21_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void SignUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Form2 Form2 = new Form2();
            Form2.Show();
        }

        private void bunifuThinButton21_Click_1(object sender, EventArgs e)
        {

        }

        private void txtusername_Click(object sender, EventArgs e)
        {

        }

        private void guna2ToggleSwitch1_CheckedChanged(object sender, EventArgs e)
        {
            // Toggle password visibility
            if (txtpassword.PasswordChar == '*')
            {
                txtpassword.PasswordChar = '\0'; // Show password characters
            }
            else
            {
                txtpassword.PasswordChar = '*'; // Hide password characters
            }

            // Check if the username text box has the default text "Username"
            if (txtusername.Text == "Username")
            {
                txtusername.Text = ""; // Clear the default text
                txtusername.ForeColor = Color.White; // Change text color
            }
        }




        private void bunifuThinButton21_Click_2(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtusername.Text) || string.IsNullOrEmpty(txtpassword.Text))
            {
                MessageBox.Show("Please enter both username and password.", "Error");
                return;
            }

            try
            {
                con.Open();
                sql = "SELECT * FROM admin WHERE username = @username";
                cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@username", txtusername.Text);
                da = new MySqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    string passwordFromDatabase = dt.Rows[0]["password"].ToString();
                    if (txtpassword.Text == passwordFromDatabase)
                    {
                        MessageBox.Show("Admin Login Successful");
                        sql = "INSERT INTO login_history_admin (username, time_in) VALUES (@username, NOW())";
                        cmd = new MySqlCommand(sql, con);
                        cmd.Parameters.AddWithValue("@username", txtusername.Text);
                        cmd.ExecuteNonQuery();
                        this.Hide();
                        admin admin = new admin();
                        admin.Show();
                    }
                    else
                    {
                        MessageBox.Show("Incorrect Password. Please try again.");
                    }
                }
                else
                {
                    sql = "SELECT * FROM register WHERE username = @username";
                    cmd = new MySqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@username", txtusername.Text);
                    da = new MySqlDataAdapter(cmd);
                    dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        string passwordFromDatabase = dt.Rows[0]["password"].ToString();
                        if (txtpassword.Text == passwordFromDatabase)
                        {
                            MessageBox.Show("User Login Successful");
                            sql = "INSERT INTO login_history (username, time_in) VALUES (@username, NOW())";
                            cmd = new MySqlCommand(sql, con);
                            cmd.Parameters.AddWithValue("@username", txtusername.Text);
                            cmd.ExecuteNonQuery();
                            this.Hide();
                            userchoice userchoice = new userchoice();
                            userchoice.Show();
                        }
                        else
                        {
                            MessageBox.Show("Incorrect Password. Please try again.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Username not found. Please try again.");
                    }
                }
            }
            catch (Exception ex)
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
            // Generate a salt and hash the password
            return BCrypt.Net.BCrypt.HashPassword(input, BCrypt.Net.BCrypt.GenerateSalt());
        }*/

        private void picblack_Click(object sender, EventArgs e)
        {

        }

        private void picblack_MouseEnter(object sender, EventArgs e)
        {
            picblack.Visible = false;
            picorange.Visible = true;
        }

        private void picblack_MouseLeave(object sender, EventArgs e)
        {
            picblack.Visible = true;
            picorange.Visible = false;

        }

        private void passblack_MouseEnter(object sender, EventArgs e)
        {
            passblack.Visible = false;
            passorange.Visible = true;
        }

        private void passblack_MouseLeave(object sender, EventArgs e)
        {
            passblack.Visible = true;
            passorange.Visible = false;
        }

        private void bunifuThinButton21_MouseEnter(object sender, EventArgs e)
        {

        }

        private void Form1_MouseEnter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}
