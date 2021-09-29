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
    public partial class accomadationreport : Form
    {
        public accomadationreport()
        {
            InitializeComponent();
        }

        private void accomadationreport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'eeDataSet.BillPayment1' table. You can move, or remove it, as needed.
            this.billPayment1TableAdapter.Fill(this.eeDataSet.BillPayment1);

            this.reportViewer1.RefreshReport();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BillItemRow bill = new BillItemRow();
            bill.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.BillPayment11TableAdapter.Fill(this.eeDataSet.BillPayment11,comboBox1.Text);

            this.reportViewer1.RefreshReport();
        }
    }
}
