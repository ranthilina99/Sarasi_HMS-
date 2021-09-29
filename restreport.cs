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
    public partial class restreport : Form
    {
        public restreport()
        {
            InitializeComponent();
        }

        private void restreport_Load(object sender, EventArgs e)
        {
            

            this.reportViewer1.RefreshReport();
        }

        public  void  setOrderID(String orderid)
        {
            txtOrderID.Text = orderid;
        }

        private void Details_Click(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'eeDataSet.DataTable2' table. You can move, or remove it, as needed.
            this.DataTable2TableAdapter.Fill(this.eeDataSet.DataTable2,txtOrderID.Text);
            this.reportViewer1.RefreshReport();
        }
    }
}
