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
    public partial class Reviews : Form
    {
        static Reviews f; //mail
        public Reviews()
        {
            InitializeComponent();
        }

        private void manageBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddCustomer form1 = new AddCustomer();
            form1.Show();
        }

        private void notifyBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Notify form3 = new Notify();
            form3.Show();
        }

        private void reviewBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You are already in the 'customer reviews'");

        }

    }
}
