﻿using Guna.UI2.WinForms.Suite;
using Microsoft.VisualBasic.ApplicationServices;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GYM_MEMBERSHIP_MANAGEMENT_SYSTEM
{
    public partial class profile : UserControl
    {

        private int userId; // Declare userId at the class level to make it accessible in different methods

        public profile(int userId = 0)
        {
            InitializeComponent();
            this.userId = userId; // Assign the parameter value to the class-level variable
            LoadUserData();
        }

        private void SetUserId(int id)
        {
            userId = id;
        }
        private void guna2Button4_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "jpg files (*.jpg)|*.jpg|PNG files (*.png)|*.png|All Files (*.*)|*.*";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string imageLocation = dialog.FileName;

                    // Read the new image file into a byte array
                    byte[] newImageData;
                    using (FileStream fs = new FileStream(imageLocation, FileMode.Open, FileAccess.Read))
                    {
                        newImageData = new byte[fs.Length];
                        fs.Read(newImageData, 0, (int)fs.Length);
                    }

                    // Update the image data in the database
                    string connectionString = "Server=localhost;User ID=root;Database=gym membership management;SslMode=none;";
                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();
                        string updateQuery = "UPDATE register SET img = @newImg WHERE id = @id";
                        MySqlCommand updateCommand = new MySqlCommand(updateQuery, connection);
                        updateCommand.Parameters.AddWithValue("@newImg", newImageData);
                        updateCommand.Parameters.AddWithValue("@id", userId); // Use the user ID obtained earlier
                        updateCommand.ExecuteNonQuery();
                    }

                    // Display the updated image in the PictureBox
                    using (MemoryStream ms = new MemoryStream(newImageData))
                    {
                        Image newImage = Image.FromStream(ms);
                        guna2CirclePictureBox1.Image = newImage;
                    }

                    MessageBox.Show("Image updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while updating the profile image: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void LoadUserData()
        {
            try
            {
                string connectionString = "Server=localhost;User ID=root;Database=gym membership management;SslMode=none;";
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM register WHERE id = @id";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@id", userId);
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

        private void UpdateUserData()
        {
            try
            {
                string connectionString = "Server=localhost;User ID=root;Database=gym membership management;SslMode=none;";
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string updateQuery = "UPDATE register SET firstname = @firstname, lastname = @lastname, username = @username, password = @password, email_address = @email, address = @address, phone_number = @phone, gender = @gender, membership_plan = @plan WHERE id = @id";
                    MySqlCommand updateCommand = new MySqlCommand(updateQuery, connection);
                    updateCommand.Parameters.AddWithValue("@firstname", txtFirstName.Text);
                    updateCommand.Parameters.AddWithValue("@lastname", txtLastName.Text);
                    updateCommand.Parameters.AddWithValue("@username", txtUsername.Text);
                    updateCommand.Parameters.AddWithValue("@password", txtPassword.Text);
                    updateCommand.Parameters.AddWithValue("@email", txtEmail.Text);
                    updateCommand.Parameters.AddWithValue("@address", txtAddress.Text);
                    updateCommand.Parameters.AddWithValue("@phone", txtPhoneNumber.Text);
                    updateCommand.Parameters.AddWithValue("@gender", txtGender.Text);
                    updateCommand.Parameters.AddWithValue("@plan", txtMembershipPla.Text);
                    updateCommand.Parameters.AddWithValue("@id", userId);
                    updateCommand.ExecuteNonQuery();

                    MessageBox.Show("User data updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while updating user data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            LoadUserData();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            LoadUserData();
        }

        private void profile_Load(object sender, EventArgs e)
        {

        }
    }
}

