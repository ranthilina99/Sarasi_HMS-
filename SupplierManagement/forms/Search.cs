using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sarasi_HMS
{
    public partial class Search : Form
    {

        DBAccess objDBAccess = new DBAccess();
        DataTable dtusers = new DataTable();

        public static string id, name, address, phone, email, category, description;

        private void lblViewOrder_Click(object sender, EventArgs e)
        {
            this.Hide();
            OrdersView ov = new OrdersView();
            ov.Show();

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string SCategory = txtSearch.Text;

            if (SCategory.Equals(""))
            {

            }
            else
            {
                string query = "Select* from Suppliers Where Category ='" + SCategory + "'";

                objDbaccess.readDatathroughAdapter(query, dtSuppliers);

                if (dtSuppliers.Rows.Count == 1)
                {
                    id = dtSuppliers.Rows[0]["SID"].ToString();
                    name = dtSuppliers.Rows[0]["Name"].ToString();
                    address = dtSuppliers.Rows[0]["Address"].ToString();
                    phone = dtSuppliers.Rows[0]["Phone"].ToString();
                    email = dtSuppliers.Rows[0]["Email"].ToString();
                    category = dtSuppliers.Rows[0]["Category"].ToString();
                    description = dtSuppliers.Rows[0]["Description"].ToString();

                    MessageBox.Show("Supplier founded");
                    objDbaccess.closeConn();

                    this.Hide();
                    show showpg = new show();
                    showpg.Show();
                }
                else
                {
                    MessageBox.Show("supplier id not found!");
                }

            }
        }

        private void LblNew_Click(object sender, EventArgs e)
        {
            this.Hide();
            SupplierAdd sa = new SupplierAdd();
            sa.Show();
        }

        public Search()
        {
            InitializeComponent();
        }

        private void Search_Load(object sender, EventArgs e)
        {
            timer1.Start();
            lblDate.Text = DateTime.Now.ToLongDateString();
            lblTime.Text = DateTime.Now.ToLongTimeString();

            string query = "select*from suppliers";

            objDbaccess.readDatathroughAdapter(query, dtusers);
            dataGridView1.DataSource = dtusers;
            objDbaccess.closeConn();
        }
        DBAccess objDbaccess = new DBAccess();
        DataTable dtSuppliers = new DataTable();
    }
}
