using Bunifu.Framework.UI;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using System.Web.UI;
using System.Windows.Forms;
using System.Xml.Linq;
using static GYM_MEMBERSHIP_MANAGEMENT_SYSTEM.UserControl3;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;


namespace GYM_MEMBERSHIP_MANAGEMENT_SYSTEM
{
   
    public partial class UserControl4 : System.Windows.Forms.UserControl
    {
        // Event handler for when a membership is updated
        
        MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=gym membership management;sslMode=none");
        MySqlCommand cmd;
        MySqlDataAdapter adapt;
        public UserControl4()
        {
            InitializeComponent();
            DisplayData();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void DisplayData()
        {
            try
            {
                string sql = "SELECT receiptUserName AS UserName, receiptMembership AS Membership, receiptPrice AS Price FROM receipt";
                using (cmd = new MySqlCommand(sql, con))
                {
                    adapt = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapt.Fill(dt);
                    bunifuCustomDataGrid1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        // Clears the Data  
        private void ClearData()
        {
            txtname.Text = "";
            cmbmembership.Text = "";
            txtprice.Text = "";
        }

        private void UserControl4_Load(object sender, EventArgs e)
        {

        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(cmbmembership.Text) || string.IsNullOrWhiteSpace(txtprice.Text) || string.IsNullOrWhiteSpace(txtname.Text))
                {
                    MessageBox.Show("Fill up all information", "Error");
                    return;
                }

                using (con)
                {
                    con.Open();

                    // Check if the username already exists in the 'receipt' table
                    using (MySqlCommand cmd1 = new MySqlCommand("SELECT * FROM receipt WHERE receiptUserName = @receiptUserName", con))
                    {
                        cmd1.Parameters.AddWithValue("@receiptUserName", txtname.Text);
                        bool userExists = cmd1.ExecuteScalar() != null;

                        if (userExists)
                        {
                            MessageBox.Show("Username already exists!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Insert membership data into the 'receipt' table
                    using (MySqlCommand cmd = new MySqlCommand("INSERT INTO receipt (receiptUserName, receiptMembership, receiptPrice) VALUES(@receiptUserName, @receiptMembership, @receiptPrice)", con))
                    {
                        cmd.Parameters.AddWithValue("@receiptUserName", txtname.Text);
                        cmd.Parameters.AddWithValue("@receiptMembership", cmbmembership.Text);
                        cmd.Parameters.AddWithValue("@receiptPrice", txtprice.Text);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Membership added successfully", "SAVE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                DisplayData();
                ClearData();
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //may error sa pag update ng username
            // Check if all required fields are filled
            if (!string.IsNullOrWhiteSpace(cmbmembership.Text) &&
                !string.IsNullOrWhiteSpace(txtname.Text) &&
                !string.IsNullOrWhiteSpace(txtprice.Text))
            {
                string sql = "UPDATE receipt SET receiptMembership = @receiptMembership, receiptPrice = @receiptPrice WHERE receiptUserName = @receiptUserName";
                cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@receiptMembership", cmbmembership.Text);
                cmd.Parameters.AddWithValue("@receiptUserName", txtname.Text);
                cmd.Parameters.AddWithValue("@receiptPrice", txtprice.Text);
                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                con.Close();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Membership information updated successfully!", "UPDATE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DisplayData();
                    ClearData();
                }
                else
                {
                    MessageBox.Show("No user found with this name!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Fill out all the information needed", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bunifuCustomDataGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        
        private void cmbmembership_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(cmbmembership.Text))
            {
                string selectedMembership = cmbmembership.Text;

                try
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = con;
                        cmd.CommandText = "SELECT membershipPrice FROM membership WHERE membership = @membership";
                        cmd.Parameters.AddWithValue("@membership", selectedMembership);

                        con.Open();
                        object result = cmd.ExecuteScalar();
                        con.Close(); // Close the connection after executing the query

                        if (result != null)
                        {
                            txtprice.Text = result.ToString();
                        }
                        else
                        {
                            MessageBox.Show("Price not found for the selected membership", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtprice.Text = ""; // Clear the price textbox if no price is found
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error fetching membership price: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    con.Close(); // Ensure the connection is closed in case of an exception
                }
            }
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            // Check if all required fields are filled
            if (!string.IsNullOrWhiteSpace(cmbmembership.Text) &&
                !string.IsNullOrWhiteSpace(txtname.Text) &&
                !string.IsNullOrWhiteSpace(txtprice.Text))
            {
                // Show print preview dialog
                PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
                printPreviewDialog.Document = new PrintDocument();
                printPreviewDialog.Document.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
                printPreviewDialog.ShowDialog();

                // Print the document if the user chooses to print
                PrintDocument pd = new PrintDocument();
                pd.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
                pd.Print();
            }
            else
            {
                MessageBox.Show("Fill out all the information needed", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void bunifuCustomDataGrid1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < bunifuCustomDataGrid1.Rows.Count)
            {
                txtname.Text = bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["UserName"].Value?.ToString() ?? "";
                cmbmembership.Text = bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["Membership"].Value?.ToString();
                txtprice.Text = bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["Price"].Value?.ToString();
            }
        }

        private void dataGridView2_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtname.Text))
            {
                string sql = "DELETE FROM receipt WHERE receiptUserName=@receiptUserName";
                cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@receiptUserName", txtname.Text);
                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                con.Close();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Membership deleted successfully!", "DELETE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DisplayData();
                    ClearData();
                }
                else
                {
                    MessageBox.Show("No user found with this name!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Enter the name of the user you want to delete", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics graphic = e.Graphics;

            Font font = new Font("Courier New", 12); // Define font
            float fontHeight = font.GetHeight();

            int startY = e.MarginBounds.Top + 20; // Start drawing from the top margin with some extra spacing
            int maxWidth = e.MarginBounds.Width; // Maximum width within the printable area
            int offset = 0;

            // Draw logo
            Image logo = Image.FromFile(@"C:\Users\Parlan\Desktop\FINALS 2024\GYM MEMBERSHIP MANAGEMENT SYSTEM\Red Black Minimalist Fitness Logo .png");
            int logoWidth = 200; // Adjust width as needed
            int logoHeight = 200; // Adjust height as needed
            int logoX = e.MarginBounds.Left + (maxWidth - logoWidth) / 2; // Center horizontally
            int logoY = startY; // Start drawing logo at the top
            graphic.DrawImage(logo, logoX, logoY, logoWidth, logoHeight);

            // Update startY to start drawing text below the logo
            startY += logoHeight + 20;

            // Drawing text on the receipt
            string[] lines = {
        "GYM FITNESS",
        "OWNED AND OPERATED BY",
        "JUSTIN AND YASMIN",
        "", // Add space below this
        "3RD LEVEL BLDG 3 STA LCUAI MALL MARCOS",
        "HIGHWAY COR, FELIX AVE. SAN ISIDRO 1900",
        "CAINTA RIZAL PHILIPPINES",
        "", // Add space below this
        "OFFICIAL RECEIPT",
        "", // Add space below this
        "Date: " + DateTime.Now.ToString("MM/dd/yyyy") + "   Time: " + DateTime.Now.ToString("HH:mm:ss"),
        "Receipt Number: 1234567890",
        "Username: " + txtname.Text,
        "Membership: " + cmbmembership.Text,
        "Price: $" + txtprice.Text,
        "", // Add space below this
        "THIS DOCUMENT IS NOT VALID FOR",
        "CLAIM OF INPUT TAX",
        "", // Add space below this
        "THIS SERVE AS AN OFFICIAL RECEIPT",
        "Date Issued: " + DateTime.Now.ToString("MM/dd/yyyy")
    };

            foreach (string line in lines)
            {
                SizeF stringSize = graphic.MeasureString(line, font);
                int stringWidth = (int)stringSize.Width;

                int startX = (maxWidth - stringWidth) / 2 + e.MarginBounds.Left; // Center horizontally within the printable area

                graphic.DrawString(line, font, new SolidBrush(Color.Black), startX, startY + offset);
                offset += (int)fontHeight + 5;
            }
        }
        private void txtprice_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtname_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }
    }
}
