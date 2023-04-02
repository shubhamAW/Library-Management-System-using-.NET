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

namespace Library_Management_System
{
    
    public partial class Dashboard : Form
    {
        private string username;
        public Dashboard(string username)
        {
            InitializeComponent();
            this.username = username;
        }

        

        private void MemberToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


       

        private void Dashboard_Load(object sender, EventArgs e)
        {
            welcomeLabel.Text = $"Welcome, {username}!";
            timer1.Enabled = true;


            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=localhost\\sqlexpress;Initial Catalog=LibraryDB21;Integrated Security=True;Pooling=False";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            cmd.CommandText = "SELECT RANK() OVER(ORDER BY Books_Read DESC) AS Rank, EnrollID, Member_Name, Books_Read FROM ( SELECT EnrollID, Member_Name, COUNT(*) AS Books_Read   FROM IssueReturnBook  GROUP BY EnrollID, Member_Name) AS BookCount ORDER BY Rank";

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count != 0)
            {
                dataGridView1.DataSource = ds.Tables[0];
            }
          

            SqlCommand cmd1 = new SqlCommand();
            cmd1.Connection = conn;

            cmd1.CommandText = "SELECT RANK() OVER(ORDER BY Times_Issued DESC) AS Rank, Book_Name, Times_Issued FROM ( SELECT Book_Name, COUNT(*) AS Times_Issued FROM IssueReturnBook  GROUP BY Book_Name) AS BookCount ORDER BY Rank";

            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);

            if (ds1.Tables[0].Rows.Count != 0)
            {
                dataGridView2.DataSource = ds1.Tables[0];
            }
        }

        private void vewToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to Exit?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {

                Application.Exit();
            }
        }

        public static int restrict = 0;
        private void addNewBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(restrict == 0)
            {
                restrict++;
                AddBooks abs = new AddBooks();
                abs.Show();
                abs.TopMost= true;
            }
            else
            {
                MessageBox.Show("Add New Books Form is already opened!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void viewBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewBook vb = new ViewBook();
            vb.Show();
        }


        public static int memRestrict = 0;
        private void addMemberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(memRestrict == 0)
            {

                AddMember addMember = new AddMember();
                addMember.Show();
                memRestrict++;
            }
            else
            {
                MessageBox.Show("Form is already Opened.", "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void viewMemberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewMember vm = new ViewMember();
            vm.ShowDialog();
        }

        public static int issueBookRestrict = 0;
        private void issueBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(issueBookRestrict == 0)
            {
                issueBookRestrict++;
                IssueBook ib = new IssueBook();
                ib.Show();
                //ib.TopMost = true;
            }
            else
            {
                MessageBox.Show("Form is already Opened!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void returnBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Return_Book rb = new Return_Book();
            rb.Show();
        }

        private void completeBookDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CompleteBookDetails cbd = new CompleteBookDetails();
            cbd.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString("hh:mm:ss tt");

        }
    }
}
