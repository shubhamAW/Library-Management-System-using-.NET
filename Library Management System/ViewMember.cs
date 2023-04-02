﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Management_System
{
    public partial class ViewMember : Form
    {
        public ViewMember()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchMemberName.Text != "")
            {
                //Image image = Image.FromFile("D:\\pratiti training\\Project\\Library Management System\\Library Management System\\icon and imgs\\search1.gif");
                //pictureBox1.Image = image;

                label1.Visible = false;



                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = "Data Source=localhost\\sqlexpress;Initial Catalog=LibraryDB21;Integrated Security=True;Pooling=False";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandText = "select ID , EnrollID , mName, mContact, mEmail, mState, mCity, mPinCode from NewMember where EnrollID LIKE '%" + txtSearchMemberName.Text + "%' OR mName LIKE '" + txtSearchMemberName.Text +"%' ";

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                da.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];

            }
            else
            {
                //Image image = Image.FromFile("D:\\pratiti training\\Project\\Library Management System\\Library Management System\\icon and imgs\\search.gif");
                //pictureBox1.Image = image;

                label1.Visible = true;


                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = "Data Source=localhost\\sqlexpress;Initial Catalog=LibraryDB21;Integrated Security=True;Pooling=False";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandText = "select ID , EnrollID , mName, mContact, mEmail, mState, mCity, mPinCode from NewMember";

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                da.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];
            }
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void ViewMember_Load(object sender, EventArgs e)
        {
            panel3.Visible = false;

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=localhost\\sqlexpress;Initial Catalog=LibraryDB21;Integrated Security=True;Pooling=False";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            cmd.CommandText = "select ID , EnrollID , mName, mContact, mEmail, mState, mCity, mPinCode from NewMember";

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            da.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];

        }

        int mid;
        Int64 rowid;

       
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0  && e.ColumnIndex >= 0 && dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null && dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString() != "")
            {
                           
                
                mid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());

          //      Image image = Image.FromFile("D:\\pratiti training\\Project\\Library Management System\\Library Management System\\icon and imgs\\search.gif");
             //   pictureBox1.Image = image;

                label1.Visible = true;

                panel3.Visible = true;


                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = "Data Source=localhost\\sqlexpress;Initial Catalog=LibraryDB21;Integrated Security=True;Pooling=False";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandText = "select ID , EnrollID , mName, mContact, mEmail, mState, mCity, mPinCode from NewMember where ID = " + mid + "";
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataSet ds = new DataSet();

                da.Fill(ds);

            

                rowid = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());

                txtenrollID.Text = ds.Tables[0].Rows[0][1].ToString();
                txtFullName.Text = ds.Tables[0].Rows[0][2].ToString();
                txtContact.Text = ds.Tables[0].Rows[0][3].ToString();
                txtEmail.Text = ds.Tables[0].Rows[0][4].ToString();
                txtState.Text = ds.Tables[0].Rows[0][5].ToString();
                txtCity.Text = ds.Tables[0].Rows[0][6].ToString();
                txtPincode.Text = ds.Tables[0].Rows[0][7].ToString();
            }
            //else
            //{
            //    MessageBox.Show("Please Click on Valid Cell!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            panel3.Visible=false;

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearchMemberName.Clear();
            panel3.Visible= false;

            ViewMember_Load(sender, e);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Data will be modified, Confirm?","Are you sure!", MessageBoxButtons.OK, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                String fullname = txtFullName.Text;
                Int64 contact = Int64.Parse(txtContact.Text);
                String email = txtEmail.Text;
                String state = txtState.Text;
                String city = txtCity.Text;
                Int64 pin = Int64.Parse(txtPincode.Text);

                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = "Data Source=localhost\\sqlexpress;Initial Catalog=LibraryDB21;Integrated Security=True;Pooling=False";

                SqlCommand cmd = conn.CreateCommand(); 
                cmd.Connection= conn;

                cmd.CommandText = "update NewMember set mName='" + fullname + "', mContact="+contact+", mEmail='"+email+"', mState='"+state+"', mCity='"+city+"', mPinCode="+pin+ " where ID = "+ rowid +" "; 

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                da.Fill(ds);


                MessageBox.Show("Data Updated Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ViewMember_Load(sender, e);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Data Will be Deleted. Confirm?", "Confirmation Dialog", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {

                String fullname = txtFullName.Text;
                Int64 contact = Int64.Parse(txtContact.Text);
                String email = txtEmail.Text;
                String state = txtState.Text;
                String city = txtCity.Text;
                Int64 pin = Int64.Parse(txtPincode.Text);

                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = "Data Source=localhost\\sqlexpress;Initial Catalog=LibraryDB21;Integrated Security=True;Pooling=False";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandText = "delete from NewMember where ID = " + rowid + " ";

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                MessageBox.Show("Data Deleted Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ViewMember_Load(sender, e);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }

}