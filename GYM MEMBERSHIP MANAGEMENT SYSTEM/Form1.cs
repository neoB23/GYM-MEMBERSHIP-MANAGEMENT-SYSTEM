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
            // Check if username or password is empty
            if (string.IsNullOrEmpty(txtusername.Text) || string.IsNullOrEmpty(txtpassword.Text))
            {
                // Display warning message for empty fields
                if (string.IsNullOrEmpty(txtusername.Text))
                {
                    MessageBox.Show("Please enter your username", "Error");
                    errorProvider1.SetError(txtusername, "Please enter your username");
                }

                if (string.IsNullOrEmpty(txtpassword.Text))
                {
                    MessageBox.Show("Please enter your password", "Error");
                    errorProvider1.SetError(txtpassword, "Please enter your password");
                }
            }
            else
            {
                try
                {
                    con.Open();
                    // Query for checking if the user is an admin
                    sql = "SELECT * FROM Admin WHERE username = @username AND password = @password";
                    cmd = new MySqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@username", txtusername.Text);
                    cmd.Parameters.AddWithValue("@password", txtpassword.Text); // No need to hash for admin login
                    da = new MySqlDataAdapter(cmd);
                    dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        // Admin login, direct to admin form
                        MessageBox.Show("Admin Login Successful");
                        this.Hide();
                        admin admin = new admin();
                        admin.Show();
                    }
                    else
                    {
                        // Regular user login, direct to user form
                        sql = "SELECT * FROM register WHERE username = @username AND password = @password";
                        cmd = new MySqlCommand(sql, con);
                        cmd.Parameters.AddWithValue("@username", txtusername.Text);
                        cmd.Parameters.AddWithValue("@password", txtpassword.Text);
                        da = new MySqlDataAdapter(cmd);
                        dt = new DataTable();
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            // Regular user login
                            MessageBox.Show("User Login Successful");
                            this.Hide();
                            Form3 Form3 = new Form3();
                            Form3.Show();
                        }
                        else
                        {
                            MessageBox.Show("Incorrect Login Information. Please try again.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    da.Dispose();
                    con.Close();
                }
            }
        }

        private void guna2ToggleSwitch1_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2ToggleSwitch1.Checked)
            {
                // If checked, show the password
                txtpassword.PasswordChar = '\0';
            }
            else
            {
                // If unchecked, hide the password
                txtpassword.PasswordChar = '*';
            }
        }

        private void bunifuThinButton21_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}
