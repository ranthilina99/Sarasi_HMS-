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
    public partial class Cal : Form
    {
        public Cal()
        {
            InitializeComponent();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Notify form3 = new Notify();
            form3.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCal_Click(object sender, EventArgs e)
        {
            String stringPrecentage = precentageTxt.Text.Trim().ToString();
            String stringValue = valueTxt.Text.Trim().ToString();

            if (!string.IsNullOrEmpty(stringPrecentage) && !string.IsNullOrEmpty(stringValue))
            {
                int intPrecntage = 0;
                double doubleValue = 0.0;

                if (int.TryParse(stringPrecentage, out intPrecntage) && double.TryParse(stringValue, out doubleValue))
                {
                    double doubleResult = (doubleValue * intPrecntage) / 100;
                    resultLabel.Text = "Discount : Rs " + doubleResult.ToString("#,#00.00");
                }
                else
                {
                    MessageBox.Show("Attempt conversion of " + stringPrecentage + " or " + stringValue + "failed.",
                        "c# :precentage calculator", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
