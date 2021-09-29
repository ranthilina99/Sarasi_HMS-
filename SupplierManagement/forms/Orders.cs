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
    public partial class Orders : Form
    {
        DBAccess objDBAccess = new DBAccess();
        public static string model, oid;

        public Orders()
        {
            InitializeComponent();

            panel1.BackColor = Color.FromArgb(160, Color.Black);
        }

        DBAccess objDbaccess = new DBAccess();
        DataTable dtOrders = new DataTable();

        private void Orders_Load(object sender, EventArgs e)
        {

            lblDate.Text = DateTime.Now.ToLongDateString();
            lblTime.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();

            lblEmail.Text = Search.email;
            lblName.Text = Search.name;
            lblCategory.Text = Search.category;


            string query = "Select OID from Orders";

            objDbaccess.readDatathroughAdapter(query, dtOrders);


            //oid = dtOrders.Rows[0]["OID"].ToString();



            objDbaccess.closeConn();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            OrdersView ov = new OrdersView();
            ov.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            show shownow = new show();
            shownow.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
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

        private void btnSend_Click(object sender, EventArgs e)
        {
            model = txtModel.Text.ToString();
            string quantity = txtQuantity.Text;
            string exdate = txtExdate.Text;
            string other = txtOther.Text;


            if (model.Equals(""))
            {
                MessageBox.Show("Please eneter Model");
            }
            else if (quantity.Equals(""))
            {
                MessageBox.Show("Please eneter Quantity ");
            }
            else if (exdate.Equals(""))
            {
                MessageBox.Show("Please eneter Expecteddate ");
            }


            else
            {
                SqlCommand insertCommand = new SqlCommand("insert into Orders(Model,Quentity,ExpectedDate,Other,SID)  values(@Model,@Quantity,@ExpectedDate,@Other,@SID)");

                insertCommand.Parameters.AddWithValue("@Model", model);
                insertCommand.Parameters.AddWithValue("@Quantity", quantity);
                insertCommand.Parameters.AddWithValue("@ExpectedDate", exdate);
                insertCommand.Parameters.AddWithValue("@Other", other);
                insertCommand.Parameters.AddWithValue("@SID", Search.id);

                int row = objDBAccess.executeQuery(insertCommand);

                if (row == 1)
                {
                    MessageBox.Show("SEND MESSAGE SUCESSFULLY!");

                    /* this.Hide();
                    SupplierBills bill = new SupplierBills();
                    bill.Show();*/


                }
                else
                {
                    MessageBox.Show("Error!");
                }
            }
        }
    }
}
