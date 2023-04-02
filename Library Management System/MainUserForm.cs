using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Library_Management_System
{
    public partial class MainUserForm : Form
    {
        private string username;

        public MainUserForm(string username)
        {
            InitializeComponent();
            
            this.username = username;
        }

        private void MainUserForm_Load(object sender, EventArgs e)
        {
            welcomeLabel.Text = $"Welcome, {username}!";

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=localhost\\sqlexpress;Initial Catalog=LibraryDB21;Integrated Security=True;Pooling=False";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            cmd.CommandText = "select EnrollID,Member_Name,Book_Name,Book_Issue_Date from IssueReturnBook where EnrollID='" + username + "' and Book_Return_Date is NULL";

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count != 0)
            {
                dataGridView1.DataSource = ds.Tables[0];
            }
           

            SqlCommand cmd1 = new SqlCommand();
            cmd1.Connection = conn;

            cmd1.CommandText = "select EnrollID,Member_Name,Book_Name,Book_Issue_Date,Book_Return_Date from IssueReturnBook where EnrollID='" + username + "' and Book_Return_Date is NOT NULL";

            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);

            if (ds1.Tables[0].Rows.Count != 0)
            {
                dataGridView2.DataSource = ds1.Tables[0];
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnSignOut_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to Sign out", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Close();
            }

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
