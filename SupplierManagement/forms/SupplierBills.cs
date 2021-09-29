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
    public partial class SupplierBills : Form
    {
        DBAccess objDBAccess = new DBAccess();

        public static string orderNo, model;
        string qty, unitPrice, balance;

        private void button1_Click(object sender, EventArgs e)
        {

            qty = txtQuantity.Text;
            unitPrice = txtUnitPrice.Text;

            int parseqty = int.Parse(qty);
            int parseunitPrice = int.Parse(unitPrice);

            int total = (parseqty * parseunitPrice);

            balance = Convert.ToString(total);

            txtbalance.Text = lblTot.Text = balance;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {


            lblTime.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            OrdersView ov = new OrdersView();
            ov.Show();
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;

                MessageBox.Show("ENETER VALIED VALUE", "Please give a number", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtUnitPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;

                MessageBox.Show("ENETER VALIED VALUE", "Please give a number", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPaid_Click(object sender, EventArgs e)
        {

            string quantity = txtQuantity.Text;
            string unitprice = txtUnitPrice.Text;
            string total = txtbalance.Text;
            string des = txtDes.Text;



            if (quantity.Equals(""))
            {
                MessageBox.Show("Please eneter Quantity");
            }
            else if (unitprice.Equals(""))
            {
                MessageBox.Show("Please eneter Unit Price ");
            }
            else if (total.Equals(""))
            {
                MessageBox.Show("Please eneter Total ");
            }


            else
            {
                SqlCommand insertCommand = new SqlCommand("insert into SupplierBill(Quantity,Unitprice,Total,OID,Des)  values(@Quantity,@Unitprice,@Total,@OID,@Des)");

                insertCommand.Parameters.AddWithValue("@Quantity", quantity);
                insertCommand.Parameters.AddWithValue("@Unitprice", unitprice);
                insertCommand.Parameters.AddWithValue("@Total", total);
                insertCommand.Parameters.AddWithValue("@OID", OrdersView.oid);
                insertCommand.Parameters.AddWithValue("@Des", des);

                int row = objDBAccess.executeQuery(insertCommand);

                if (row == 1)
                {
                    MessageBox.Show(" SUCESSFULLY!");

                    // this.Hide();
                    //SupplierBills bill = new SupplierBills();
                    // bill.Show();


                }
                else
                {
                    MessageBox.Show("Error!");
                }
            }
        }

        public SupplierBills()
        {
            InitializeComponent();
            panel2.BackColor = Color.FromArgb(160, Color.Black);
        }

        private void SupplierBills_Load(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.ToLongDateString();
            lblTime.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();



            //lblCategory.Text = Search.category;
            lblModel.Text = OrdersView.model;
            lblOrderNo.Text = OrdersView.oid;
            txtQuantity.Text = OrdersView.qty;
        }
    }
}
