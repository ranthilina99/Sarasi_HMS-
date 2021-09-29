using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace Sarasi_HMS
{
    public partial class OrdersView : Form
    {
        public OrdersView()
        {
            InitializeComponent();
        }

        public static string model, oid, category, qty;

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-GD6AQRD\LAHIRUSQL;Initial Catalog=Sarasi;Integrated Security=True");

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            OrderId = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells[0].Value);
            oid = lblOid.Text = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
            model = txtModel.Text = dataGridView2.SelectedRows[0].Cells[1].Value.ToString();
            qty = txtQuantity.Text = dataGridView2.SelectedRows[0].Cells[2].Value.ToString();
            txtExdate.Text = dataGridView2.SelectedRows[0].Cells[3].Value.ToString();
            txtDes.Text = dataGridView2.SelectedRows[0].Cells[4].Value.ToString();
            lblSid.Text = dataGridView2.SelectedRows[0].Cells[5].Value.ToString();
        }

        private void btnPaid_Click(object sender, EventArgs e)
        {
            if (OrderId > 0)
            {
                SqlCommand cmd = new SqlCommand("UPDATE Orders SET Model=@Model, Quentity=@quentity, ExpectedDate=@ExpectedDate, Other= @Other, SID= @SID WHERE OID=@ID", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@model", txtModel.Text);
                cmd.Parameters.AddWithValue("@quentity", txtQuantity.Text);
                cmd.Parameters.AddWithValue("@ExpectedDate", txtExdate.Text);
                cmd.Parameters.AddWithValue("@Other", txtDes.Text);
                cmd.Parameters.AddWithValue("@SID", lblSid.Text);
                cmd.Parameters.AddWithValue("@ID", this.OrderId);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Order update sucessfully!", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);

                getOrdersRecord();

            }
            else
            {
                MessageBox.Show("Order update fail please select Order!", "Select?", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (OrderId > 0)
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Orders WHERE OID=@ID", con);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@ID", this.OrderId);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Order REMOVE sucessfully!", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                getOrdersRecord();

                txtDes.Clear();
                txtExdate.Clear();
                txtModel.Clear();
                txtQuantity.Clear();



            }
            else
            {
                MessageBox.Show("Order Delete fail");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {


            if (IsValid())
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Orders VALUES (@Model, @quentity, @ExpectedDate, @Other, @SID) ", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@model", txtModel.Text);
                cmd.Parameters.AddWithValue("@quentity", txtQuantity.Text);
                cmd.Parameters.AddWithValue("@ExpectedDate", txtExdate.Text);
                cmd.Parameters.AddWithValue("@Other", txtDes.Text);
                cmd.Parameters.AddWithValue("@SID", lblSid.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public int OrderId;

        private void button3_Click(object sender, EventArgs e)
        {

            this.Hide();
            SupplierBills bill = new SupplierBills();
            bill.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            this.Hide();
            Orders os = new Orders();
            os.Show();
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

        private void OrdersView_Load(object sender, EventArgs e)
        {

            lblDate.Text = DateTime.Now.ToLongDateString();
            lblTime.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();

            getOrdersRecord();
        }

        private void getOrdersRecord()
        {

            SqlCommand cmd = new SqlCommand("select * from Orders", con);
            DataTable dt = new DataTable();

            con.Open();

            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();

            dataGridView2.DataSource = dt;
        }

        private bool IsValid()
        {
            if (txtModel.Text == string.Empty)
            {
                MessageBox.Show("fail");
                return false;
            }
            return true;
        }
    }
}
