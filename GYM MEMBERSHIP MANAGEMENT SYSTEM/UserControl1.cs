using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace GYM_MEMBERSHIP_MANAGEMENT_SYSTEM
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {

        }






        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //txtName.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
           // txtContactNumber.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            //txtAge.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
           // cmbSex.SelectedItem = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();

        }
        private void DisplayData()
        {
            //string sql = "SELECT Name, `contact number`, Age, Sex FROM rent";
           // cmd = new MySqlCommand(sql, con);
           // adapt = new MySqlDataAdapter(cmd);
           // DataTable dt = new DataTable();
           // adapt.Fill(dt);
           // dataGridView1.DataSource = dt;
        }
        // Clears the Data  
        private void ClearData()
        {
           // txtName.Text = "";
           // txtAge.Text = "";
           // txtContactNumber.Text = "";
           // cmbSex.SelectedItem = null;


        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
           
        }
    }
}
