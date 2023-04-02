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
    public partial class UserLogin : Form
    {
        public UserLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string userId = txtuserID.Text;
            string password = txtPassword.Text;

            if(IsValidUser(userId, password))
            {
                // Instantiate the next form
                
                MainUserForm mainForm = new MainUserForm(userId);

                // Show the next form as a dialog box
               
                mainForm.ShowDialog();

            }
            else
            {
                MessageBox.Show("Invalid username or password!");
            }
        }

        bool IsValidUser(string userId, string password)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "data source=localhost\\sqlexpress; database=LibraryDB21; integrated security=True;";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            conn.Open();
            cmd.CommandText= "select * from NewMember where EnrollID='"+userId+"' and mPassword='"+password+"'";

      
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);


            if (ds.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddMember addmember=new AddMember();
            addmember.Show();
        }
    }
}
