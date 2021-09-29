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

namespace Sarasi_HMS.VehicleManagement.vm_forms
{
    public partial class RentalList : Form
    {
        private static RentalList uniqueInstance = null;
        private List<Rent_2> vCategoriesList = new List<Rent_2>();
        private List<VehicleManagement.user_controks.RentCard> vcCardsList = new List<VehicleManagement.user_controks.RentCard>();
        private VehicleManagement.user_controks.RentCard vccard;

        private Rent_2 re;

        private RentalList()
        {
            InitializeComponent();
        }
        public static RentalList getInstance()
        {
            if (uniqueInstance == null)
            {
                uniqueInstance = new RentalList();
            }
            return uniqueInstance;
        }
        //method to load categ
        public void loadVehicleCategories()
        {
            //clear the crd list
            vcCardsList.Clear();
            flowVehicleCategoryList.Controls.Clear();

            using (DBEntities db = new DBEntities())
            {
                vCategoriesList = db.Rent_2.ToList();

                foreach (Rent_2 Item in vCategoriesList)
                {
                    //create new crd

                    vccard = new VehicleManagement.user_controks.RentCard();
                    vccard.RentID = Item.RentID;
                    vccard.vimage = Util.convertBinaryToImage(Item.VehicleImage);
                    vccard.vehicleId = Item.vehicleID;
                    vccard.vtype = Item.type;
                    vccard.vNumber = Item.vehicleNo;
                    vccard.CustomerName = Item.CustomerName;
                    vccard.RentDate = Item.RentDate.ToString();


                    //adding crd to the list
                    vcCardsList.Add(vccard);
                }

            }

            //adding cards to the flow panel
            foreach (VehicleManagement.user_controks.RentCard card in vcCardsList)
            {
                flowVehicleCategoryList.Controls.Add(card);
            }
        }



        //method to delete a category 

        public void deleteRent(String id)
        {
            if (MessageBox.Show("Are you sure to Delete this record?", "Delete New Rent", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                using (DBEntities db = new DBEntities())
                {
                    //getting the object which need to be deleted 
                    re = db.Rent_2.Where(fc => fc.RentID == id).First();
                    //delete the object 
                    db.Rent_2.Remove(re);
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
                MessageBox.Show("Rent Removed Successfully!!!");
              

            }
            //refreshing......
            clearCategoryList();
            loadVehicleCategories();
        }//end of delete category method *******************

        private void btnBack_Click(object sender, EventArgs e)
        {
            VehicleManagementNew vm = new VehicleManagementNew();
            this.Hide();
            vm.Show();
        }

        private void RentalList_Load(object sender, EventArgs e)
        {
            loadVehicleCategories();
        }
        public void clearCategoryList()
        {
            flowVehicleCategoryList.Controls.Clear();
        }

        private void RentalList_Activated(object sender, EventArgs e)
        {
            loadVehicleCategories();
        }
    }
}
