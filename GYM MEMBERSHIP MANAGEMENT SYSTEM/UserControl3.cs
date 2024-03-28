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

namespace GYM_MEMBERSHIP_MANAGEMENT_SYSTEM
{
    public partial class UserControl3 : UserControl
    {
        MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=gym membership management;sslMode=none");
        MySqlCommand cmd;
        MySqlDataAdapter adapt;
        public UserControl3()
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
        private void UserControl3_Load(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void DisplayData()
        {
            string sql = "SELECT id, membership, duration, goal, cost FROM membership"; 
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
            txtduration.Text= "";
            txtgoal.Text = "";
            txtcost.Text = "";
           


        }
        private void dataGridView2_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView2.Rows.Count)
            {
                txtusername.Text = dataGridView2.Rows[e.RowIndex].Cells["username"].Value?.ToString() ?? "";
                txtduration.Text = dataGridView2.Rows[e.RowIndex].Cells["duration"].Value?.ToString();
                txtgoal.Text = dataGridView2.Rows[e.RowIndex].Cells["goal"].Value?.ToString();
                txtcost.Text = dataGridView2.Rows[e.RowIndex].Cells["cost"].Value?.ToString();
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtusername.Text) ||
               string.IsNullOrWhiteSpace(txtduration.Text) ||
               string.IsNullOrWhiteSpace(txtgoal.Text) ||
               string.IsNullOrWhiteSpace(txtcost.Text) )
               
            {
                MessageBox.Show("Fill up all information", "Error");
                return;
            }

            MySqlCommand cmd1 = new MySqlCommand("SELECT * FROM register WHERE FirstName = @firstname", con); // Changed column name in the query
            cmd1.Parameters.AddWithValue("@membership", txtusername.Text);
            con.Open();
            bool userExists = false;
            using (var dr1 = cmd1.ExecuteReader())
            {
                userExists = dr1.HasRows;
                if (userExists)
                {
                    MessageBox.Show("Username not available!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    con.Close();
                    return;
                }
            }
            con.Close();
            
            //address min input wala pa pati sa email add
            int minimumUsernameLength = 6;
            int minimumDurationLength = 2;
            int minimumGoalLength = 4;
            int minimumcostLength = 3;
            

           if (txtusername.Text.Length> minimumUsernameLength)
            {
                MessageBox.Show($"Membership must be at least {minimumUsernameLength} characters long", "Error");
            }
            if (txtduration.Text.Length < minimumDurationLength)
            {
                MessageBox.Show($"Duration must be at least {minimumDurationLength} characters long", "Error");
            }
            if (txtgoal.Text.Length < minimumGoalLength)
            {
                MessageBox.Show($"Goal must be at least {minimumGoalLength} characters long", "Error");
            }
            if (txtcost.Text.Length < minimumcostLength)
            {
                MessageBox.Show($"cost must be at least {minimumcostLength} characters long", "Error");
            }
            if (!IsNumeric(txtcost.Text))
            {
                MessageBox.Show("cost should contain only numeric characters", "Error");
                return; // Return without further processing if phone number is not numeric
            }

           

            // Adds a User in the Database
            MySqlCommand cmd = new MySqlCommand("INSERT INTO membership(membership, duration, goal, cost) VALUES(@membership, @duration, @goal, @cost)", con);
            con.Open();
            cmd.Parameters.AddWithValue("@firstname", txtusername.Text);
            cmd.Parameters.AddWithValue("@lastname", txtduration.Text);
            cmd.Parameters.AddWithValue("@username", txtgoal.Text);
            cmd.Parameters.AddWithValue("@password", txtcost.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Member added successfully", "SAVE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DisplayData();
            ClearData();
        }
    }
}
