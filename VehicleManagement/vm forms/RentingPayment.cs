using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sarasi_HMS.VehicleManagement.vm_forms
{
    public partial class RentingPayment : Form
    {
        //databse objects
        // Employee emp = new Employee();
        Rent Paym = new Rent();
        public RentingPayment()
        {
            InitializeComponent();
        }

        private void btnProductIDGenerate_Click(object sender, EventArgs e)
        {
            txtVID.Text = Util.generateKey("vehicle");
        }

        private void buttoncalculte_Click(object sender, EventArgs e)
        {
            float totprice, advance, balnce, rentPerkm;
            int noOfkm;


            noOfkm = int.Parse(textBoxnoOfKm.Text);
            advance = float.Parse(textBoxadvnce.Text);
            rentPerkm = float.Parse(txtrentPerKM.Text);


            //calculation 
            totprice = noOfkm * rentPerkm;
            balnce = totprice - advance;

            //set the text box
            textBoxTotPrice.Text = totprice.ToString();
            textBox2blnce.Text = balnce.ToString();
        }

        private void button1paygen_Click(object sender, EventArgs e)
        {
            textBoxpymntID.Text = Util.generateKey("rent1");
        }

        private void button2gendriID_Click(object sender, EventArgs e)
        {
            txtDriverID.Text = Util.generateKey("driver");
        }

        private void buttonbackPayment_Click(object sender, EventArgs e)
        {
            VehicleManagement.vm_forms.VehiclePOS vm = new VehicleManagement.vm_forms.VehiclePOS();
            this.Hide();
            vm.Show();
        }

        private void buttonsavepymnt_Click(object sender, EventArgs e)
        {
            Paym.Advance = float.Parse(textBoxadvnce.Text);
            Paym.NoOfKM = Int32.Parse(textBoxnoOfKm.Text);
            Paym.RentDate = dateTimePicker1.Value;
            Paym.AfterDate = dateTimePicker2.Value;
            Paym.Balance = float.Parse(textBox2blnce.Text);
            Paym.TotalPrice = float.Parse(textBoxTotPrice.Text);
            Paym.PaymentID = textBoxpymntID.Text;
            Paym.VehiID = txtVID.Text;
            Paym.DriverID = txtDriverID.Text;
            Paym.CusID = textBox1.Text;




            /*  using (DBEntities db = new DBEntities())
              {
                  if (Paym.PaymentID == 0)
                  {
                      db.payments.Add(Paym);
                  }
                  else
                      db.Entry(Paym).State = EntityState.Modified;
                  db.SaveChanges();

              }
              MessageBox.Show("Category Added Successfully");
             // populargridview();
              clearTexts();
              Paym.PaymentID = 0;
              //cmbempsal.Enabled = true;
          }*/

            using (DBEntities db = new DBEntities())
            {
                if (Paym.RentID == 0)
                {
                    db.Rents.Add(Paym);
                }
                else
                    db.Entry(Paym).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }

            MessageBox.Show("payment added successfully");
            // clearTexts();
            Paym.RentID = 0;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
