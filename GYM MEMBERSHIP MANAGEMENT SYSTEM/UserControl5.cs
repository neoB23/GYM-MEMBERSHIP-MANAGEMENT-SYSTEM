using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using BCrypt.Net;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace GYM_MEMBERSHIP_MANAGEMENT_SYSTEM
{
    public partial class UserControl5 : UserControl
    {

        MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=gym membership management;sslMode=none");
        MySqlCommand cmd;
        MySqlDataAdapter adapt;
        public UserControl5()
        {
            InitializeComponent();
            DisplayData();
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void DisplayData()
        {
            string sql = "SELECT Admin_id, adminName, adminPassword, adminEmail, adminFirstName, adminLastName, admin_CreatedDate, adminAddress, adminContactNumber FROM admin"; // Changed column names
            cmd = new MySqlCommand(sql, con);
            adapt = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            dataGridView2.DataSource = dt;
        }

        // Clears the Data  
        private void ClearData()
        {
            txtusername.Text = "";
            txtfirstname.Text = "";
            txtlastname.Text = "";
            txtemail.Text = "";
            txtpassword.Text = "";
            txtaddress.Text = "";
            txtcontactnumber.Text = "";
        }

        private void dataGridView2_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView2.Rows.Count)
            {
                txtfirstname.Text = dataGridView2.Rows[e.RowIndex].Cells["adminFirstName"].Value?.ToString() ?? "";
                txtlastname.Text = dataGridView2.Rows[e.RowIndex].Cells["adminLastName"].Value?.ToString();
                txtusername.Text = dataGridView2.Rows[e.RowIndex].Cells["adminName"].Value?.ToString();
                txtpassword.Text = dataGridView2.Rows[e.RowIndex].Cells["adminPassword"].Value?.ToString();
                txtemail.Text = dataGridView2.Rows[e.RowIndex].Cells["adminEmail"].Value?.ToString();
                txtcontactnumber.Text = dataGridView2.Rows[e.RowIndex].Cells["adminContactNumber"].Value?.ToString();
                txtaddress.Text = dataGridView2.Rows[e.RowIndex].Cells["adminAddress"].Value?.ToString();
            }
        }


        private void UserControl5_Load(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Check if all required fields are filled
            if (!string.IsNullOrWhiteSpace(txtfirstname.Text) &&
                !string.IsNullOrWhiteSpace(txtaddress.Text) &&
                !string.IsNullOrWhiteSpace(txtcontactnumber.Text) &&
                !string.IsNullOrWhiteSpace(txtusername.Text) &&
                !string.IsNullOrWhiteSpace(txtpassword.Text) &&
                !string.IsNullOrWhiteSpace(txtlastname.Text) &&
                !string.IsNullOrWhiteSpace(txtemail.Text))

            {
                try
                {
                    string sql = "UPDATE Admin SET adminName = @adminName, adminPassword = @adminPassword, adminEmail = @adminEmail, adminLastName = @adminLastName, adminAddress = @adminAddress, adminContactNumber = @adminContactNumber WHERE adminFirstName = @adminFirstName";
                    cmd = new MySqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@adminFirstName", txtfirstname.Text);
                    cmd.Parameters.AddWithValue("@adminLastName", txtlastname.Text);
                    cmd.Parameters.AddWithValue("@adminName", txtusername.Text);

                    // Hash the password before updating it
                    string hashedPassword = BCrypt.Net.BCrypt.HashPassword(txtpassword.Text);
                    cmd.Parameters.AddWithValue("@adminPassword", hashedPassword);

                    cmd.Parameters.AddWithValue("@adminEmail", txtemail.Text);
                    cmd.Parameters.AddWithValue("@adminAddress", txtaddress.Text);
                    cmd.Parameters.AddWithValue("@adminContactNumber", txtcontactnumber.Text);
                    cmd.Parameters.AddWithValue("@admin_CreatedDate", DateTime.Now); // Assuming admin_CreatedDate is the current date/time
                    con.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    con.Close();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Admin information updated successfully!", "UPDATE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DisplayData();
                        ClearData();
                    }
                    else
                    {
                        MessageBox.Show("No Admin found with this name!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Fill out all the information needed", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtfirstname.Text))
            {
                string sql = "DELETE FROM admin WHERE adminFirstName=@adminFirstName";
                cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@adminFirstName", txtfirstname.Text);
                try
                {
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }
                    int rowsAffected = cmd.ExecuteNonQuery();
                    con.Close();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("admin deleted successfully!", "DELETE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DisplayData();
                        ClearData();
                    }
                    else
                    {
                        MessageBox.Show("No admin found with this name!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Enter the name of the admin you want to delete", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtusername.Text) ||
                string.IsNullOrWhiteSpace(txtaddress.Text) ||
                string.IsNullOrWhiteSpace(txtcontactnumber.Text) ||
                string.IsNullOrWhiteSpace(txtpassword.Text) ||
                string.IsNullOrWhiteSpace(txtfirstname.Text) ||
                string.IsNullOrWhiteSpace(txtlastname.Text) ||
                string.IsNullOrWhiteSpace(txtemail.Text))
            {
                MessageBox.Show("Fill up all information", "Error");
                return;
            }

            try
            {
                // Open the connection
                con.Open();

                // Check if username already exists
                using (MySqlCommand cmd1 = new MySqlCommand("SELECT * FROM Admin WHERE adminFirstName = @adminFirstName", con))
                {
                    cmd1.Parameters.AddWithValue("@adminFirstName", txtfirstname.Text);
                    bool userExists = false;
                    using (var dr1 = cmd1.ExecuteReader())
                    {
                        userExists = dr1.Read();
                    }

                    if (userExists)
                    {
                        MessageBox.Show("Username not available!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // Hash the password before saving it
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(txtpassword.Text);

                // Insert new admin record into the database
                using (MySqlCommand cmd = new MySqlCommand("INSERT INTO Admin(adminName, adminPassword, adminEmail, adminFirstName, adminLastName, admin_CreatedDate, adminContactNumber, adminAddress) VALUES(@adminName, @adminPassword, @adminEmail, @adminFirstName, @adminLastName, @admin_CreatedDate, @adminContactNumber, @adminAddress)", con))
                {
                    cmd.Parameters.AddWithValue("@adminFirstName", txtfirstname.Text);
                    cmd.Parameters.AddWithValue("@adminLastName", txtlastname.Text);
                    cmd.Parameters.AddWithValue("@adminName", txtusername.Text);
                    cmd.Parameters.AddWithValue("@adminPassword", hashedPassword);
                    cmd.Parameters.AddWithValue("@adminEmail", txtemail.Text);
                    cmd.Parameters.AddWithValue("@adminAddress", txtaddress.Text);
                    cmd.Parameters.AddWithValue("@adminContactNumber", txtcontactnumber.Text);
                    cmd.Parameters.AddWithValue("@admin_CreatedDate", DateTime.Now);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Admin added successfully", "SAVE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DisplayData();
                        ClearData();
                    }
                    else
                    {
                        MessageBox.Show("Admin could not be added", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                // Close the connection
                con.Close();
            }
        }







        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        

        private void txtpassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
