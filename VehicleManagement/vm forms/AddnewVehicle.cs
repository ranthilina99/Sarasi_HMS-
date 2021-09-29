using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sarasi_HMS
{
    public partial class AddnewVehicle : Form
    {
        private static AddnewVehicle uniqueInstance = null;
        Vehicle vehimodel = new Vehicle();
        String fileName;

        private String status = "insert";
        private AddnewVehicle()
        {
            InitializeComponent();
        }

        public static AddnewVehicle getInstance()
        {
            if (uniqueInstance == null)
            {
                uniqueInstance = new AddnewVehicle();
            }
            return uniqueInstance;
        }

        private void btnProductIDGenerate_Click(object sender, EventArgs e)
        {
            txtVID.Text = Util.generateKey("vehicle");
        }

        private void btnSaveVehicle_Click(object sender, EventArgs e)
        {
            
                vehimodel.vehicleID = txtVID.Text;
                vehimodel.vehicleNo = txtVno.Text;
                vehimodel.type = comboVCategory.Text;
                vehimodel.model = txtModel.Text;
                vehimodel.brand = txtbrand.Text;
                vehimodel.InsuaranceType = txtVInsuarancetype.Text;


                double rentPerday;
                bool result1 = Double.TryParse(txtRentPerday.Text, out rentPerday);
                if (result1 == false)
                {
                    MessageBox.Show("Please enter Rent per day");
                }
                else
                {
                    vehimodel.RentPerDay = (float)rentPerday;
                }

                double rentPerKM;
                bool result2 = Double.TryParse(txtrentPerKM.Text, out rentPerKM);
                if (result1 == false)
                {
                    MessageBox.Show("Please enter Rent per KM");
                }
                else
                {
                    vehimodel.RentPerkm = (float)rentPerKM;
                }

                vehimodel.VehicleImage = Util.convertImageToBinary(picBoxVehicleImage.Image);

                using (DBEntities db = new DBEntities())
                {
                    if (status == "insert")
                    {
                        db.Vehicles.Add(vehimodel);

                        MessageBox.Show("Vehicle category added successfully");
                    }
                    else if (status == "update")
                    {
                        db.Entry(vehimodel).State = EntityState.Modified;

                        MessageBox.Show("Vehicle Category Updated Successfully");
                    }

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

                VehicleManagement.vm_forms.VehicleNewList vm = VehicleManagement.vm_forms.VehicleNewList.getInstance();
                this.Hide();
                vm.Show();
            
        }
        public bool validateFormDetails()
        {
            bool flag = false;
            if (String.IsNullOrEmpty(txtVID.Text.Trim()))
            {
                MessageBox.Show("please enter Vehicle Id ", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else if (String.IsNullOrEmpty(txtVno.Text.Trim()))
            {
                MessageBox.Show("please enter Vehicle No ", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (String.IsNullOrEmpty(comboVCategory.Text.Trim()))
            {
                MessageBox.Show("please enter Vehicle Type ", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (String.IsNullOrEmpty(txtModel.Text.Trim()))
            {
                MessageBox.Show("please enter Vehicle Model  ", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (String.IsNullOrEmpty(txtbrand.Text.Trim()))
            {
                MessageBox.Show("please enter vehicle Brand  ", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (String.IsNullOrEmpty(txtVInsuarancetype.Text.Trim()))
            {
                MessageBox.Show("please enter Insurance Type  ", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (String.IsNullOrEmpty(txtRentPerday.Text.Trim()))
            {
                MessageBox.Show("please enter Vehicle Perday ", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (String.IsNullOrEmpty(txtrentPerKM.Text.Trim()))
            {
                MessageBox.Show("please enter Vehicle Rent ", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


            return flag;
        }

        private void btnbrowseImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "JPEG|*.jpg", ValidateNames = true, Multiselect = false })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    fileName = ofd.FileName;
                    picBoxVehicleImage.Image = Image.FromFile(fileName);
                }
            }
        }

        private void btnBackfromAddVehicle_Click(object sender, EventArgs e)
        {
            VehicleManagementNew vm = new VehicleManagementNew();
            this.Hide();
            vm.Show();
        }
        public void editVehicle(String id)
        {
            //retreiving selected row 
            using (DBEntities db = new DBEntities())
            {
                //setting status to update
                status = "update";
                btnSaveVehicle.Text = "Update";

                vehimodel = db.Vehicles.Where(x => x.vehicleID == id).FirstOrDefault();
                MessageBox.Show(vehimodel.vehicleID);

                //storing values to the textboxes

                txtVID.Text = vehimodel.vehicleID;
                txtrentPerKM.Text = vehimodel.RentPerkm.ToString();
                txtRentPerday.Text = vehimodel.RentPerDay.ToString();
                txtbrand.Text = vehimodel.brand;
                txtVInsuarancetype.Text = vehimodel.InsuaranceType;
                comboVCategory.SelectedItem = vehimodel.type;
                txtVno.Text = vehimodel.vehicleNo;
                txtModel.Text = vehimodel.model;
                picBoxVehicleImage.Image = Util.convertBinaryToImage(vehimodel.VehicleImage);

            }
        }//end of edit item category method

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
