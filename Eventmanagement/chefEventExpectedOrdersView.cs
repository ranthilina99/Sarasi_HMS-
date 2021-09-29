using Sarasi_HMS.Eventmanagement.userControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sarasi_HMS.Eventmanagement
{
    public partial class chefEventExpectedOrdersView : Form
    {
        //create eventfoodpackages list for insert data from sql table.
        List<expOrder> ExpOrdersList = new List<expOrder>();

        //create EFoodPackageCardList for insert cards to one list
        List<eventExpectedOrdersCard> eventExpectedOrdersCardList = new List<eventExpectedOrdersCard>();

        //create reference (instance variable) to create new card reference
        private eventExpectedOrdersCard ExpectedOrdersCard;

        private EventPackage mod1 = new EventPackage(); //database table name
        private BookedEvent ABE = new BookedEvent();

        private expOrder expO;
        public chefEventExpectedOrdersView()
        {
            InitializeComponent();
            setDefaultValues();
        }
        private void setDefaultValues()
        {
            DateTime time = DateTime.Now.ToLocalTime();
            lblDateTime.Text = time.ToString();
        }
        //Create a methods for show all cards
        public void DisplayExpectedOrders()
        {
            eventExpectedOrdersCardList.Clear();
            using (DBEntities db = new DBEntities())
            {
                ExpOrdersList = db.expOrders.ToList(); //get details from sql and add to this list

                foreach (expOrder expOr in ExpOrdersList) //booked event  is one raw
                                                          //Iterarte raw by raw and insert to card list
                {
                    ExpectedOrdersCard = new eventExpectedOrdersCard();

                    ExpectedOrdersCard.OrderID = expOr.expOrderID;
                    ExpectedOrdersCard.BookedID = expOr.eventID;
                    ExpectedOrdersCard.OrderList = expOr.list;

                    ABE = db.BookedEvents.Where(x => x.eventID == expOr.eventID).FirstOrDefault();


                    ExpectedOrdersCard.EventDate = ABE.eventDate.ToString("dd/MM/yyyy");
                    ExpectedOrdersCard.EventTime = ABE.eventTime.ToString();

                    ExpectedOrdersCard.EventName = ABE.eventName;

                    ExpectedOrdersCard.NoOfParti = ABE.noOfParticipants.ToString();

                    mod1 = db.EventPackages.Where(x => x.packageID == ABE.foodPckage).FirstOrDefault();

                    ExpectedOrdersCard.FoodPackage = mod1.Name;






                    eventExpectedOrdersCardList.Add(ExpectedOrdersCard);
                }


            }
            foreach (eventExpectedOrdersCard card in eventExpectedOrdersCardList)
            {
                flowLayoutExpectedOrdersView.Controls.Add(card);
            }
        }

        public void clearExpecteOrderList()
        {
            flowLayoutExpectedOrdersView.Controls.Clear();
        }

        private void chefEventExpectedOrdersView_Load(object sender, EventArgs e)
        {
            DisplayExpectedOrders();
        }

        public void deleteExpOrder(String id)
        {
            if ((MessageBox.Show("Are you sure to Delete this record?", "Delete exp order", MessageBoxButtons.YesNo) == DialogResult.Yes))
            {

                using (DBEntities db = new DBEntities())
                {
                    expO = db.expOrders.Where(x => x.expOrderID == id).FirstOrDefault();
                    MessageBox.Show(expO.expOrderID);

                    db.expOrders.Remove(expO);
                    try
                    {
                        db.SaveChanges();
                    }
                    catch (DbEntityValidationException ex)
                    {
                        foreach (var entityValidationErrors in ex.EntityValidationErrors)
                        {
                            foreach (var validationError in entityValidationErrors.ValidationErrors)
                            {
                                MessageBox.Show("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                            }
                        }
                    }


                }
                MessageBox.Show("exp order Removed Successfully!!!");


            }
            //refreshing......
            clearExpecteOrderList();
            DisplayExpectedOrders();
        }// end of delete

        private void btnEventBack_Click(object sender, EventArgs e)
        {
            hChefAddOrderList emd = new hChefAddOrderList();
            this.Hide();
            emd.Show();
        }
    }
}
