using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace Sarasi_HMS
{
    public partial class show : Form
    {

        DBAccess objDBAccess = new DBAccess();

        public show()
        {
            InitializeComponent();
            panel1.BackColor = Color.FromArgb(160, Color.Black);
        }

        private void show_Load(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.ToLongDateString();
            lblTime.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();

            txtName.Text = Search.name;
            txtAddress.Text = Search.address;
            txtPhone.Text = Search.phone;
            txtEmail.Text = Search.email;
            txtCategory.Text = Search.category;
            txtDescription.Text = Search.description;

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string newSupplierName = txtName.Text;
            string newSupplierAddress = txtAddress.Text;
            string newSupplierPhone = txtPhone.Text;
            string newSupplierEmail = txtEmail.Text;
            string newSupplierCategory = txtCategory.Text;
            string newSupplierDescription = txtDescription.Text;

            if (newSupplierName.Equals(""))
            {
                MessageBox.Show("Please enter your name..");
            }
            else if (newSupplierAddress.Equals(""))
            {
                MessageBox.Show("please enter your Address");
            }
            else if (newSupplierPhone.Equals(""))
            {
                MessageBox.Show("please enter your Phone..");
            }
            else if (newSupplierEmail.Equals(""))
            {
                MessageBox.Show("Please choose your Email");
            }
            else if (newSupplierCategory.Equals(""))
            {
                MessageBox.Show("Please choose your Category");
            }
            else if (newSupplierDescription.Equals(""))
            {
                MessageBox.Show("Please choose your Description");
            }
            else
            {
                string query = "Update Suppliers SET Name='" + @newSupplierName + "',Address='" + @newSupplierAddress + "',Phone='" + @newSupplierPhone + "',Email='" + @newSupplierEmail + "',Category='" + @newSupplierCategory + "',Description='" + @newSupplierDescription + "' Where SID ='" + Search.id + "'";

                SqlCommand updateCommand = new SqlCommand(query);
                updateCommand.Parameters.AddWithValue("@SupplierName", @newSupplierName);
                updateCommand.Parameters.AddWithValue("@SupplierAddress", @newSupplierAddress);
                updateCommand.Parameters.AddWithValue("@SupplierPhone", @newSupplierPhone);
                updateCommand.Parameters.AddWithValue("@SupplierEmail", @newSupplierEmail);
                updateCommand.Parameters.AddWithValue("@SupplierCategory", @newSupplierCategory);
                updateCommand.Parameters.AddWithValue("@Description", @newSupplierDescription);


                int row = objDBAccess.executeQuery(updateCommand);

                if (row == 1)
                {
                    MessageBox.Show("Update sucessfully");

                    // this.Hide();
                    // SingIn sign = new SingIn();
                    // sign.Show();
                }
                else
                {
                    MessageBox.Show("Error!");
                }

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Are your sure?", "Delete Supplier Account", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialog == DialogResult.Yes)
            {
                string query = "DELETE from Suppliers Where SID='" + Search.id + "'";
                SqlCommand deleteCommand = new SqlCommand(query);

                int row = objDBAccess.executeQuery(deleteCommand);

                if (row == 1)
                {
                    MessageBox.Show("Delete sucessfully");

                    //this.Hide();
                    //SingIn sign = new SingIn();
                    //sign.Show();
                }
                else
                {
                    MessageBox.Show("Error!");
                }
            }
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {


            this.Hide();
           Orders orders = new Orders();
           orders.Show();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            lblTime.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {

            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;

                MessageBox.Show("ENETER VALIED VALUE", "Please give a number", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Search search = new Search();
            search.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Search search = new Search();
            search.Show();
        }
    }
}
