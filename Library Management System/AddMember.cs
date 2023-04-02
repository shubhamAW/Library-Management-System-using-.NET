using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Microsoft.VisualBasic;
using MailKit.Net.Smtp;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;
using MimeKit;

namespace Library_Management_System
{
    public partial class AddMember : Form
    {
        public AddMember()
        {
            InitializeComponent();
        }

        
        private void btnExit_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Confirm?", "Alert",MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {

                this.Close();
                Dashboard.memRestrict = 0;
            }
        }

        private void AddMember_Load(object sender, EventArgs e)
        {
            ControlBox = false;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtFullName.Clear();
            txtContactNum.Clear();
            txtEmilid.Clear();
            txtcityName.Clear();
            txtpinCode.Clear(); //or txtpinCode.Text = "";

            combostate.SelectedItem = null;
            

        }

        private void btnSaveInfo_Click(object sender, EventArgs e)
        {
            if(txtFullName.Text != "" && txtContactNum.Text != "" && txtEmilid.Text != "" && combostate.Text != "" && txtcityName.Text != "" && txtpinCode.Text != "")
            {

                String name = txtFullName.Text;
                Int64 contact = Int64.Parse(txtContactNum.Text);
                String email = txtEmilid.Text;
                String state = combostate.Text;
                String city = txtcityName.Text;
                Int64 pincode = Int64.Parse(txtpinCode.Text);
                string mpassword = txtPassword.Text;
                string confirmPassword = txtConfirmPass.Text;

                String userId = string.Empty;

                if(mpassword != confirmPassword)
                {
                    MessageBox.Show("check confirm password" ,"Password and confirm password is not matched", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {

                    //try
                    //{
                    //    // Validate the email address
                    //    MailAddress Email = new MailAddress(email);

                    //    // Generate a random 6-digit OTP
                    //    Random random = new Random();
                    //    int otp = random.Next(100000, 999999);

                    //    // Send the OTP to the email address
                    //    // You can use a third-party library or an email API to send the email

                    //    // MailKit configuration
                    //    string emailFrom = "waykarshubham2025@gmail.com";
                    //    string password = "Waykar2025$";
                    //    string emailTo = Email.Address;
                    //    string subject = "Your OTP";
                    //    string body = $"Your OTP is {otp}";

                    //    // SMTP client
                    //    using (SmtpClient client = new SmtpClient())
                    //    {
                    //        client.Connect("smtp.example.com", 587, false); // replace with your SMTP server address and port
                    //        client.Authenticate(emailFrom, password);

                    //        // create and send the message
                    //        MimeMessage message = new MimeMessage();
                    //        message.From.Add(new MailboxAddress("", emailFrom));
                    //        message.To.Add(new MailboxAddress("", emailTo));
                    //        message.Subject = subject;
                    //        message.Body = new TextPart("plain") { Text = body };
                    //        client.Send(message);

                    //        client.Disconnect(true);
                    //    }


                    //    // Prompt the user to enter the OTP
                    //    string enteredOtp = Microsoft.VisualBasic.Interaction.InputBox("Please enter the 6-digit OTP sent to your email address.", "OTP Validation");
                  

                    //    // Validate the entered OTP
                    //    if (enteredOtp == otp.ToString())
                    //    {
                    //        // OTP is valid, do something
                    //        MessageBox.Show("OTP is valid!");

                            SqlConnection conn = new SqlConnection();
                            conn.ConnectionString = "Data Source=localhost\\sqlexpress;Initial Catalog=LibraryDB21;Integrated Security=True;Pooling=False";

                            SqlCommand cmd = conn.CreateCommand();
                            cmd.Connection = conn;

                            conn.Open();
                            cmd.CommandText = "insert into NewMember (mName,mContact,mEmail,mState,mCity,mPinCode , mPassword) values ('" + name + "'," + contact + ",'" + email + "','" + state + "','" + city + "'," + pincode + " , '" + mpassword + "')";
                            cmd.ExecuteNonQuery();

                            SqlCommand cmd2 = new SqlCommand("SELECT TOP 1 EnrollId FROM NewMember ORDER BY ID DESC", conn);
                            SqlDataReader dr = cmd2.ExecuteReader();

                            if (dr.Read())
                            {
                                string message = string.Format("Your UserID is: {0}", dr[0].ToString());

                                MessageBox.Show(message, "Data Saved Successfully! Remember UserID for Login..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            dr.Close();


                            conn.Close();

                            //MessageBox.Show("Data Saved.","Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //    }
                    //    else
                    //    {
                    //        // OTP is not valid, show an error message
                    //        MessageBox.Show("OTP is not valid.");
                    //    }
                    //}
                    //catch (FormatException)
                    //{
                    //    // Email is not valid, show an error message
                    //    MessageBox.Show("Please enter a valid email address.");
                    //}

                }


            }
            else
            {
                MessageBox.Show("Please Fill Empty Fields","Suggest",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void combostate_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
