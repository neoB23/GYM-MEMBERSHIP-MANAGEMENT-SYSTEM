using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace GYM_MEMBERSHIP_MANAGEMENT_SYSTEM
{
    public partial class UserControl0 : UserControl
    {
        private MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=gym membership management;sslMode=none");
        private Timer timer;

        public UserControl0()
        {
            InitializeComponent();
            timer = new Timer();
            timer.Interval = 5000; 
            timer.Tick += Timer_Tick;
            timer.Start();
            LoadRegisteredMemberCount();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            LoadRegisteredMemberCount();
        }

        private void LoadRegisteredMemberCount()
        {
            try
            {
                con.Open();

                // Count members
                string memberSql = "SELECT COUNT(*) FROM coach";
                MySqlCommand memberCmd = new MySqlCommand(memberSql, con);
                int memberCount = Convert.ToInt32(memberCmd.ExecuteScalar());

                // Count coaches
                string coachSql = "SELECT COUNT(*) FROM user_information";
                MySqlCommand coachCmd = new MySqlCommand(coachSql, con);
                int coachCount = Convert.ToInt32(coachCmd.ExecuteScalar());

                // Count admins
                string adminSql = "SELECT COUNT(*) FROM admin";
                MySqlCommand adminCmd = new MySqlCommand(adminSql, con);
                int adminCount = Convert.ToInt32(adminCmd.ExecuteScalar());
                con.Close();

                // Update labels with counts
                label5.Text = $"Total: {memberCount}";
                label6.Text = $"Total: {coachCount}";
                label7.Text = $"Total: {adminCount}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            //for member
        }

        private void label5_Click(object sender, EventArgs e)
        {
            //for coach
        }

        private void label7_Click(object sender, EventArgs e)
        {
            //for admin
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void UserControl0_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
