﻿using System;
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
    public partial class printreportStock : Form
    {
        public printreportStock()
        {
            InitializeComponent();
        }

        private void printreportStock_Load(object sender, EventArgs e)
        {
           
            // TODO: This line of code loads data into the 'eeDataSet.StockAudit' table. You can move, or remove it, as needed.
            this.stockAuditTableAdapter.Fill(this.eeDataSet.StockAudit);

            this.reportViewer1.RefreshReport();
        }

        private void stockdetails_Click(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'eeDataSet.StockAudit1' table. You can move, or remove it, as needed.
            this.StockAudit1TableAdapter.Fill(this.eeDataSet.StockAudit1,comboBox1.Text);
            this.reportViewer1.RefreshReport();
        }
    }
}
