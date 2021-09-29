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
    public partial class AddCustomer : Form
    {
         ContactCustomer c = new ContactCustomer();
        
        public AddCustomer()
        {
            InitializeComponent();
        }

        private void AddCustomer_Load(object sender, EventArgs e)
        {
            DataTable dt = c.Select();
            dgvContactList.DataSource = dt;
        }

        private void reviewBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Reviews form2 = new Reviews();
            form2.Show();
        }

        private void notifyBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Notify form3 = new Notify();
            form3.Show();
        }

        private void manageBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You are already in the 'customer management'");
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                //get input values 
                c.CustomerName = textBoxName.Text;
                c.ContactNo = textBoxContact.Text;
                c.Email = textBoxEmail.Text;

                //into db
                bool success = c.Insert(c);
                if (success == true)
                {
                    MessageBox.Show("New Customer Added Successfully!");
                    //clear method
                    Clear();
                }
                else
                {
                    MessageBox.Show("Try Again!");
                }

                //Load data into table
                DataTable dt = c.Select();
                dgvContactList.DataSource = dt;
            }
        }
        private bool IsValid()
        {
            if (textBoxName.Text == string.Empty)
            {
                MessageBox.Show("Enter Name");
                return false;
            }
            else if (textBoxContact.Text == string.Empty)
            {
                MessageBox.Show("Enter Contact");
                return false;
            }
            return true;
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {

            //data from txtboxes
            c.CustomerID = int.Parse(textBoxCID.Text);
            c.CustomerName = textBoxName.Text;
            c.ContactNo = textBoxContact.Text;
            c.Email = textBoxEmail.Text;
            //db update
            bool success = c.Update(c);
            if (success == true)
            {
                //msg box
                MessageBox.Show("Updated Successfully!");

                DataTable dt = c.Select();
                dgvContactList.DataSource = dt;

                //clear
                Clear();
            }
            else
            {
                MessageBox.Show("Update Faild!");
            }


        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            c.CustomerID = Convert.ToInt32(textBoxCID.Text);
            bool success = c.Delete(c);
            if (success == true)
            {
                //Deleted
                MessageBox.Show("Deleted Successfully!");
                DataTable dt = c.Select();
                dgvContactList.DataSource = dt;
                Clear();
            }
            else
            {
                //Not Done
                MessageBox.Show("Error!");
            }
        }
        static string myconnstrng = ConfigurationManager.ConnectionStrings["DBEntities1"].ConnectionString;

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = textBoxSearch.Text;

            SqlConnection conn = new SqlConnection(myconnstrng);
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM tblContact WHERE CustomerName LIKE '%" + keyword + "%' OR ContactNo LIKE '%" + keyword + "%' OR Email LIKE '%" + keyword + "%'", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dgvContactList.DataSource = dt;
        }

        private void dgvContactList_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            textBoxCID.Text = dgvContactList.Rows[rowIndex].Cells[0].Value.ToString();
            textBoxName.Text = dgvContactList.Rows[rowIndex].Cells[1].Value.ToString();
            textBoxContact.Text = dgvContactList.Rows[rowIndex].Cells[2].Value.ToString();
            textBoxEmail.Text = dgvContactList.Rows[rowIndex].Cells[3].Value.ToString();
        }
        public void Clear()
        {
            textBoxCID.Text = "";
            textBoxName.Text = "";
            textBoxContact.Text = "";
            textBoxEmail.Text = "";
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btngen_Click(object sender, EventArgs e)
        {
            textBoxCID.Text = Util.generateKey("customer");
        }
    }

}
