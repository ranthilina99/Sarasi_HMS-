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
    public partial class EventPackageViews : Form
    {
        //create eventfoodpackages list for insert data from sql table.
        List<EventPackage> EventFoodPackagesList = new List<EventPackage>();

        //create EFoodPackageCardList for insert cards to one list
        List<EFoodPackageCard> EFoodPackageCardList = new List<EFoodPackageCard>();

        //create reference (instance variable) to create new card reference
        private EFoodPackageCard eFoodPackageCard;

        private EventPackage ev2;

        public EventPackageViews()
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
        public void DisplayEventFoodPackages()
        {
            EFoodPackageCardList.Clear();
            using (DBEntities db = new DBEntities())
            {
                EventFoodPackagesList = db.EventPackages.ToList(); //get details from sql and add to this list

                foreach (EventPackage ePackage in EventFoodPackagesList) //eventPackage is one raw
                                                                         //Iterarte raw by raw and insert to card list
                {
                    eFoodPackageCard = new EFoodPackageCard();
                    eFoodPackageCard.packageID = ePackage.packageID;
                    eFoodPackageCard.packageName = ePackage.Name;
                    eFoodPackageCard.pricePerPlate = ePackage.plate_price.ToString();
                    eFoodPackageCard.noOfCurries = ePackage.noOfCurries.ToString();
                    eFoodPackageCard.mainMeal = AddEventFoodPackage.convertBinaryToImage(ePackage.mainMeal);
                    eFoodPackageCard.desert = AddEventFoodPackage.convertBinaryToImage(ePackage.desert);

                    EFoodPackageCardList.Add(eFoodPackageCard);
                }


            }
            foreach (EFoodPackageCard card in EFoodPackageCardList)
            {
                flowLayoutFoodPackagesView.Controls.Add(card);
            }
        }

        private void EventPackageViews_Load(object sender, EventArgs e)
        {
            DisplayEventFoodPackages();
        }

        public void deleteEPackage(String id)
        {
            if ((MessageBox.Show("Are you sure to Delete this record?", "Delete Event Package", MessageBoxButtons.YesNo) == DialogResult.Yes))
            {

                using (DBEntities db = new DBEntities())
                {
                    ev2 = db.EventPackages.Where(x => x.packageID == id).FirstOrDefault();
                    MessageBox.Show(ev2.packageID);

                    db.EventPackages.Remove(ev2);
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
                MessageBox.Show("Category Removed Successfully!!!");


            }
            //refreshing......
            clearFoodPackageList();
            DisplayEventFoodPackages();
        }// end of deleteCategory

        public void clearFoodPackageList()
        {
            flowLayoutFoodPackagesView.Controls.Clear();
        }

        private void btnEventBack_Click(object sender, EventArgs e)
        {
            AddEventFoodPackage ed = new AddEventFoodPackage();
            ed.Show();
            this.Hide();
        }

        private void btnEFPaddNew_Click(object sender, EventArgs e)
        {
            AddEventFoodPackage adv = new AddEventFoodPackage();
            adv.Show();
            this.Hide();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
