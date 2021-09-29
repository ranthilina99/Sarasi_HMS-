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
    public partial class SupplierAdd : Form
    {
        DBAccess objDBAccess = new DBAccess();

        public SupplierAdd()
        {
            InitializeComponent();
            panel1.BackColor = Color.FromArgb(160, Color.Black);
        }

        private void SupplierAdd_Load(object sender, EventArgs e)
        {
            timer1.Start();
            lblDate.Text = DateTime.Now.ToLongDateString();
            lblTime.Text = DateTime.Now.ToLongTimeString();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string SupplierName = txtName.Text;
            string SupplierAddress = txtAddress.Text;
            string SupplierPhone = txtPhone.Text;
            string SupplierEmail = txtEmail.Text;
            string SupplierCategory = txtCategory.Text;
            string Description = txtDescription.Text;

            if (SupplierName.Equals(""))
            {
                MessageBox.Show("Please eneter Supplier name ");
            }
            else if (SupplierAddress.Equals(""))
            {
                MessageBox.Show("Please eneter Supplier address ");
            }
            else if (SupplierPhone.Equals(""))
            {
                MessageBox.Show("Please eneter Supplier phone ");
            }
            else if (SupplierEmail.Equals(""))
            {
                MessageBox.Show("Please eneter Supplier email ");
            }
            else if (SupplierCategory.Equals(""))
            {
                MessageBox.Show("Please eneter Supplier category ");
            }
            else
            {
                SqlCommand insertCommand = new SqlCommand("insert into Suppliers(Name,Address,Phone,Email,Category,Description)  values(@SupplierName,@SupplierAddress,@SupplierPhone,@SupplierEmail,@SupplierCategory,@Description)");

                insertCommand.Parameters.AddWithValue("@SupplierName", SupplierName);
                insertCommand.Parameters.AddWithValue("@SupplierAddress", SupplierAddress);
                insertCommand.Parameters.AddWithValue("@SupplierPhone", SupplierPhone);
                insertCommand.Parameters.AddWithValue("@SupplierEmail", SupplierEmail);
                insertCommand.Parameters.AddWithValue("@SupplierCategory", SupplierCategory);
                insertCommand.Parameters.AddWithValue("@Description", Description);

                int row = objDBAccess.executeQuery(insertCommand);

                if (row == 1)
                {
                    MessageBox.Show("account created sucessfully");

                    this.Hide();
                    Search search = new Search();
                    search.Show();


                }
                else
                {
                    MessageBox.Show("Error!");
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            lblTime.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {

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

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Search search = new Search();
            search.Show();
        }
    }
}
