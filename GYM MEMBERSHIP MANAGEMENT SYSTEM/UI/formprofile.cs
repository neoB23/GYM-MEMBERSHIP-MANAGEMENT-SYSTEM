using Guna.UI2.WinForms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;


namespace SYSTEM_GYM
{
   
    public partial class formprofile : Form
    {
        private int userId; // Declare userId at the class level to make it accessible in different methods

        public formprofile(int userId = -1)
        {
            InitializeComponent();
            this.userId = userId; // Assign the parameter value to the class-level variable
            this.Load += Formprofile_Load; // Attach the event handler
        }

        private void Formprofile_Load(object sender, EventArgs e)
        {
            LoadUserData(); // Load user data when the form is loaded
        }
        private void LoadUserData()
        {
            string username = GetLoggedInUsername(); // Use the username to load user data
            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("No user is currently logged in.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            UserData userData = GetUserData(username);
            if (userData != null)
            {
                txtfirstname.Text = userData.FirstName;
                txtLastName.Text = userData.LastName;
                // Populate other textboxes with user data...
            }
            else
            {
                MessageBox.Show("User data not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static class SessionManager
        {
            private static Dictionary<string, string> _sessions = new Dictionary<string, string>();

            public static void SetLoggedInUsername(string username)
            {
                _sessions[username] = username;
            }

            public static string GetLoggedInUsername()
            {
                // Assuming you want to retrieve the first logged-in username
                // This is a simple approach and might need adjustment based on your application's requirements
                return _sessions.Count > 0 ? _sessions.Keys.FirstOrDefault() : null;
            }
        }


        private UserData GetUserData(string username)
        {
            UserData userData = null;
            try
            {
                string connectionString = "Server=localhost;User ID=root;Database=gym membership management;SslMode=none;";
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM user WHERE userUserName = @username";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@username", username);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            userData = new UserData
                            {
                                FirstName = reader["userFirstName"].ToString(),
                                LastName = reader["userLastName"].ToString(),
                                // Populate other properties with user data...
                            };
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
            return userData;
        }
        public class UserData
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            // Add other properties as needed (e.g., username, email, etc.)
        }
        public static class UserSession
        {
            public static string LoggedInUsername { get; set; }
        }

        private string GetLoggedInUsername()
        {
            return SessionManager.GetLoggedInUsername();
        }



        private void SetUserId(int id)
        {
            userId = id;
        }
        private void LoadUserData(string username)
        {
            try
            {
                string connectionString = "Server=localhost;User ID=root;Database=gym membership management;SslMode=none;";
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM user WHERE userUserName = @username"; // Updated query to select based on username
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@username", username); // Use the provided username parameter
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Retrieve user data from the reader
                            txtfirstname.Text = reader["userFirstName"].ToString();
                            txtLastName.Text = reader["userLastName"].ToString();
                            txtusername.Text = reader["userUserName"].ToString();
                            txtpassword.Text = reader["userPassword"].ToString();
                            txtemail.Text = reader["userEmail"].ToString();
                            txtaddress.Text = reader["userAddress"].ToString();
                            txtcontactnumber.Text = reader["userPhoneNumber"].ToString();
                            txtgender.Text = reader["userGender"].ToString();
                            txtmembership.Text = reader["membershipplan"].ToString();

                            // Display user profile image if available
                            if (reader["userProfile"] != DBNull.Value)
                            {
                                byte[] imageData = (byte[])reader["userProfile"];
                                using (MemoryStream ms = new MemoryStream(imageData))
                                {
                                    guna2CirclePictureBox2.Image = Image.FromStream(ms);
                                }
                            }
                            else
                            {
                                guna2CirclePictureBox2.Image = null; // Clear the image if no profile image is available
                            }
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



        private void formMenu_Load(object sender, EventArgs e)
        {

        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                guna2CirclePictureBox2.Image = new Bitmap(openFileDialog.FileName);

                byte[] imageData;
                using (MemoryStream ms = new MemoryStream())
                {
                    guna2CirclePictureBox2.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    imageData = ms.ToArray();
                }

                try
                {
                    string connectionString = "Server=localhost;User ID=root;Database=gym membership management;SslMode=none;";
                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();
                        string updateQuery = "UPDATE user SET userProfile = @userProfile WHERE userUserName = @userUserName";
                        MySqlCommand updateCommand = new MySqlCommand(updateQuery, connection);
                        updateCommand.Parameters.AddWithValue("@userProfile", imageData);
                        updateCommand.Parameters.AddWithValue("@userUserName", txtusername.Text);
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



        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            LoadUserData("YuJinn");
        }

        private void guna2CirclePictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            LoadUserData("YuJinn");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
