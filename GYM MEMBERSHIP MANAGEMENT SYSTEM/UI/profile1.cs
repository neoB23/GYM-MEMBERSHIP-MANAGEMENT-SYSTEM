using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;

namespace GYM_MEMBERSHIP_MANAGEMENT_SYSTEM.UI
{
    public partial class profile1 : Form
    {
        private int userId; // Declare userId at the class level to make it accessible in different methods

        public profile1(int userId = 70)
        {
            InitializeComponent();
            this.userId = userId; // Assign the parameter value to the class-level variable
            LoadUserData("Josieree"); // Replace "actual_username_here" with the actual username
        }

        private void SetUserId(int id)
        {
            userId = id;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
          LoadUserData("Josieree");

        }

        private void profile1_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                guna2CirclePictureBox1.Image = new Bitmap(openFileDialog.FileName);

                // Convert the image to a byte array
                byte[] imageData;
                using (MemoryStream ms = new MemoryStream())
                {
                    guna2CirclePictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    imageData = ms.ToArray();
                }

                // Update the image data in the database
                try
                {
                    string connectionString = "Server=localhost;User ID=root;Database=gym membership management;SslMode=none;";
                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();
                        string updateQuery = "UPDATE register SET img = @img WHERE username = @username";
                        MySqlCommand updateCommand = new MySqlCommand(updateQuery, connection);
                        updateCommand.Parameters.AddWithValue("@img", imageData);
                        updateCommand.Parameters.AddWithValue("@username", txtUsername.Text);
                        updateCommand.ExecuteNonQuery();
                    }
                    MessageBox.Show("Image updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating image: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadUserData(string username)
        {
            try
            {
                string connectionString = "Server=localhost;User ID=root;Database=gym membership management;SslMode=none;";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM register WHERE username = @username";

                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@username", username);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtFirstName.Text = reader["firstname"].ToString();
                            txtLastName.Text = reader["lastname"].ToString();
                            txtUsername.Text = reader["username"].ToString();
                            txtPassword.Text = reader["password"].ToString();
                            txtEmail.Text = reader["emailadress"].ToString();
                            txtAddress.Text = reader["address"].ToString();
                            txtPhoneNumber.Text = reader["phonenumber"].ToString();
                            txtGender.Text = reader["gender"].ToString();
                            txtMembershipPla.Text = reader["membershipplan"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("User not found in the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading user data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void guna2Button1_Click(object sender, EventArgs e)
        {
            LoadUserData("Josieree");
        }
    }
}
