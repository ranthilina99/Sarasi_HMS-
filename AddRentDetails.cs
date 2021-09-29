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
    public partial class AddRentDetails : Form
    {
        private static AddRentDetails uniqueInstance = null;
        public static String vehicleID;
        public static float rent;
        Vehicle vehimodel = new Vehicle();

        private Rent_2 rentModel = new Rent_2();

        private String fileName;
        private String status = "insert";




        public AddRentDetails()
        {
            InitializeComponent();
        }

        public void setvalues(String id,String type,String number, Image img)
        {
            textVehiID.Text = id;
            txtVehicleNo.Text = number;
            comboVCategory.Text = type;
            picBoxVehicleImage.Image = img;


        }
        public static AddRentDetails getInstance()
        {
            if (uniqueInstance == null)
            {
                uniqueInstance = new AddRentDetails();
            }
            return uniqueInstance;
        }

       
       

        private void btnBackfromAddVehicle_Click_1(object sender, EventArgs e)
        {
            VehicleManagementNew vm = new VehicleManagementNew();
            this.Hide();
            vm.Show();
        }

        private void btnSaveVehicleRe_Click(object sender, EventArgs e)
        {
            //add new rent


            rentModel.CustomerID = txtCID.Text;
            rentModel.CustomerName = txtCusNameR.Text;
            rentModel.phone = Int32.Parse(txtRPhone.Text);
            rentModel.vehicleID = textVehiID.Text;
            rentModel.type = comboVCategory.Text;
            rentModel.vehicleNo = txtVehicleNo.Text;
            rentModel.DriverID = txtDriverID.Text;
            rentModel.RentDate = dateTimePicker1.Value;
            rentModel.AfterDate = dateTimePicker2.Value;
            rentModel.VehicleImage = Util.convertImageToBinary(picBoxVehicleImage.Image);
            // vehimodel.vehicleID = txtVID.Text;
            //auto generated rent id 


            using (DBEntities db = new DBEntities())
            {
                if (status == "insert")
                {
                    rentModel.RentID = Util.generateKey("rent");


                    db.Rent_2.Add(rentModel);
                    MessageBox.Show(" New Rent added successfully");
                }
                else if (status == "update")
                {
                    rentModel.RentID = lblRentID.Text;
                    db.Entry(rentModel).State = EntityState.Modified;

                    MessageBox.Show("Rent Updated Successfully");
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

            VehicleManagement.vm_forms.RentalList vm =VehicleManagement.vm_forms.RentalList.getInstance();
            this.Hide();
            vm.Show();

        }
        public void editRent(String id)
        {
            //retreiv selected row
            using (DBEntities db = new DBEntities())
            {
                //setting status to update
                status = "update";
                btnSaveVehicleRe.Text = "update";

                rentModel = db.Rent_2.Where(x => x.RentID == id).FirstOrDefault();
                MessageBox.Show(rentModel.RentID);
                lblRentID.Text = id;
                //storing values
                textVehiID.Text = rentModel.vehicleID;
                txtCID.Text = rentModel.CustomerID;
                txtCusNameR.Text = rentModel.CustomerName;
                txtDriverID.Text = rentModel.DriverID;
                txtVehicleNo.Text = rentModel.vehicleNo.ToString();
                txtRPhone.Text = rentModel.phone.ToString();
                comboVCategory.SelectedItem = rentModel.type;
                dateTimePicker1.Value = rentModel.RentDate;
                dateTimePicker2.Value = (DateTime)rentModel.AfterDate;
                picBoxVehicleImage.Image = Util.convertBinaryToImage(rentModel.VehicleImage);

            }
        } //end edit

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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
