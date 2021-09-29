using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sarasi_HMS
{
    public partial class Notify : Form
    {
        SendEmail s = new SendEmail();
        public Notify()
        {
            InitializeComponent();
        }

        private void manageBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddCustomer form1 = new AddCustomer();
            form1.Show();
        }

        private void reviewBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Reviews form2 = new Reviews();
            form2.Show();
        }

        private void notifyBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You are already in the 'notify customers'");
        }
        //sql connection string connect
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBEntities1"].ConnectionString);
        private void Notify_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SELECT * from tblSendEmail", con);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            con.Open();
            DataTable dt = new DataTable();
            dgvSendList.DataSource = dt;

            adapter.Fill(dt);
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Cal form4 = new Cal();
            form4.Show();
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                //get input values 
                s.Date = TextBoxDate.Text;
                s.Subject = textBoxSubject.Text;
                s.Message = textBoxMessage.Text;

                //into db
                bool success = s.Insert(s);
                if (success == true)
                {
                    MessageBox.Show("Send Successfully!");

                    //====================Email Implemetation================
                    /*
                     var message = new MailMessage(textBoxEmail.Text, textBoxRecipient.Text);
                     message.Subject = textBoxSubject.Text;
                     message.Body = textBoxMessage.Text;

                     using (SmtpClient mailer = new SmtpClient("smtp.google.com", 587))
                     {
                         mailer.Credentials = new NetworkCredential(textBoxEmail.Text, textBoxPassword.Text);
                         mailer.EnableSsl = true;
                        mailer.Send(message);
                     }
                     */

                    //clear method
                    Clear();
                }
                else
                {
                    MessageBox.Show("Try Again!");
                }

                //Load data into table
                DataTable dt2 = s.Select();
                dgvSendList.DataSource = dt2;
            }
        }
        private bool IsValid()
        {
            if (textBoxSubject.Text == string.Empty)
            {
                MessageBox.Show("Enter Subject");
                return false;
            }
            else if (textBoxMessage.Text == string.Empty)
            {
                MessageBox.Show("Enter Message");
                return false;
            }
            return true;
        }

        private void buttonClear2_Click(object sender, EventArgs e)
        {
            Clear();
        }
        public void Clear()
        {
            TextBoxDate.Text = "";
            textBoxSubject.Text = "";
            textBoxMessage.Text = "";
        }

        private void dgvSendList_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            textBoxSubject.Text = dgvSendList.Rows[rowIndex].Cells[2].Value.ToString();
            textBoxMessage.Text = dgvSendList.Rows[rowIndex].Cells[3].Value.ToString();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox1.Checked)
            {
                textBoxPassword.UseSystemPasswordChar = false;
            }
            else
            {
                textBoxPassword.UseSystemPasswordChar = true;
            }
        }
    }

}
