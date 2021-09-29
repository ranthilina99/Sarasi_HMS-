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
    public partial class VehicleNewList : Form
    {
        private static VehicleNewList uniqueInstance = null;
        private List<Vehicle> vCategoriesList = new List<Vehicle>();
        private List<VehicleManagement.user_controks.VcardEDAddVe> vcCardsList = new List<VehicleManagement.user_controks.VcardEDAddVe>();
        private VehicleManagement.user_controks.VcardEDAddVe vccard;
        private Vehicle vehi;

        private VehicleNewList()
        {
            InitializeComponent();
        }
        public static VehicleNewList getInstance()
        {
            if (uniqueInstance == null)
            {
                uniqueInstance = new VehicleNewList();
            }
            return uniqueInstance;
        }

        private void btnAddnewList_Click(object sender, EventArgs e)
        {
            AddnewVehicle anv = AddnewVehicle.getInstance();
            anv.Show();
            this.Hide();
        }
        //method to load the categories
        public void loadVehicleCategories()
        {
            //clear the card list
            vcCardsList.Clear();

            using (DBEntities db = new DBEntities())
            {
                vCategoriesList = db.Vehicles.ToList();

                foreach (Vehicle Item in vCategoriesList)
                {
                    //creating new Card

                    vccard = new user_controks.VcardEDAddVe();

                    vccard.vehicleId = Item.vehicleID;
                    vccard.rentPerDay = Item.RentPerDay.ToString();
                    vccard.rentPerKM = Item.RentPerkm.ToString();
                    vccard.vNumber = Item.vehicleNo;
                    vccard.vtype = Item.type;
                    vccard.vimage = Util.convertBinaryToImage(Item.VehicleImage);



                    //adding card to the list
                    vcCardsList.Add(vccard);


                }
            }

            //adding cards to the flow panel
            foreach (VehicleManagement.user_controks.VcardEDAddVe card in vcCardsList)
            {
                flowVehicleCategoryList.Controls.Add(card);

            }
        }
        private void VehicleNewList_Load(object sender, EventArgs e)
        {
            loadVehicleCategories();
        }
        public void clearCatgoryList()
        {
            flowVehicleCategoryList.Controls.Clear();
        }

        //method to delete a category 



        public void deleteVehicle(String id)
        {
            if (MessageBox.Show("Are you sure to Delete this record?", "Delete New Vehicle", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                using (DBEntities db = new DBEntities())
                {
                    //getting the object whichh need to be deleted 
                    vehi = db.Vehicles.Where(fc => fc.vehicleID == id).First();
                    //delete the object 
                    db.Vehicles.Remove(vehi);
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
                MessageBox.Show("Vehicle Removed Successfully!!!");

            }

            //refreshing......
            clearCatgoryList();
            loadVehicleCategories();
        }//end of delete category method *******************

        private void btnBacknewvehili_Click(object sender, EventArgs e)
        {
            VehicleManagementNew vm = new VehicleManagementNew();
            this.Hide();
            vm.Show();
        }

    }
}
