using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sarasi_HMS.Eventmanagement
{

    public partial class hChefAddOrderList : Form
    {
        EventPackage mod1 = new EventPackage(); //database table name
        BookedEvent ABE = new BookedEvent();
        expOrder exp = new expOrder();
        private static String status = "insert";
        public hChefAddOrderList()
        {
            InitializeComponent();
            setDefaultValues();
        }
        private void setDefaultValues()
        {
            DateTime time = DateTime.Now.ToLocalTime();
            lblDateTime.Text = time.ToString();
        }
        void Clear()
        {
            txtEexpOrderId.Text = richTxtEexplist.Text = txteventID.Text = txteventName.Text = txteventDate.Text = txteventTime.Text = txtpackageName.Text = txtNoOfParti.Text = "";
            btnEFPsave.Text = "Save";




        }


        public void viewDetails(String id)
        {

            //retreiving selected raw
            using (DBEntities db = new DBEntities())
            {
                //setting status to update 



                ABE = db.BookedEvents.Where(x => x.eventID == id).FirstOrDefault();
                MessageBox.Show(ABE.eventID);



                //set values to the textboxess
                this.txteventID.Text = ABE.eventID;
                txteventDate.Text = ABE.eventDate.ToString("dd/MM/yyyy");
                txteventTime.Text = ABE.eventTime.ToString();
                txteventName.Text = ABE.eventName;
                txtNoOfParti.Text = ABE.noOfParticipants.ToString();
                string ID = ABE.foodPckage;
                mod1 = db.EventPackages.Where(x => x.packageID == ID).FirstOrDefault();
                txtpackageName.Text = mod1.Name;




            }
        }

        private void btnOLgenarate_Click(object sender, EventArgs e)
        {
            String result = Util.generateKey("expOrder");
            MessageBox.Show(result);
            txtEexpOrderId.Text = result;
        }

        private void btnEFPsave_Click(object sender, EventArgs e)
        {

            //asssign to table
            exp.expOrderID = txtEexpOrderId.Text.Trim();
            exp.eventID = txteventID.Text.Trim();

            exp.list = richTxtEexplist.Text.Trim();


            using (DBEntities db = new DBEntities())
            {
                if (status == "insert")
                {
                    db.expOrders.Add(exp);

                    MessageBox.Show("Successfully saved");



                }
                else if (status == "update")
                {
                    //updating the database 
                    db.Entry(exp).State = EntityState.Modified;

                    MessageBox.Show("Order LIst Updated Successfully");
                }
                db.SaveChanges();




            }
            Clear();
        }

        public void editexpOrder(String id)
        {

            //retreiving selected raw
            using (DBEntities db = new DBEntities())
            {
                //setting status to update 
                status = "update";
                btnEFPsave.Text = "Update";

                exp = db.expOrders.Where(x => x.expOrderID == id).FirstOrDefault();
                MessageBox.Show(exp.expOrderID);

                //btnOLgenarate.Enabled = false;
                btnOLgenarate.Visible = false;

                //set values to the textboxess

                this.txtEexpOrderId.Text = exp.expOrderID;
                txtEexpOrderId.Enabled = false;
                txteventID.Text = exp.eventID;
                richTxtEexplist.Text = exp.list;

                ABE = db.BookedEvents.Where(x => x.eventID == exp.eventID).FirstOrDefault();


                txteventDate.Text = ABE.eventDate.ToString("dd/MM/yyyy");
                txteventTime.Text = ABE.eventTime.ToString();

                txteventName.Text = ABE.eventName;

                txtNoOfParti.Text = ABE.noOfParticipants.ToString();


                mod1 = db.EventPackages.Where(x => x.packageID == ABE.foodPckage).FirstOrDefault();

                txtpackageName.Text = mod1.Name;


            }
        }

        private void btnEFPview_Click(object sender, EventArgs e)
        {
            chefEventExpectedOrdersView managerB = new chefEventExpectedOrdersView();
            managerB.Show();
            this.Hide();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEventBack_Click(object sender, EventArgs e)
        {
            headChefBookedEventViews emd = new headChefBookedEventViews();
            this.Hide();
            emd.Show();
        }
    }
}
