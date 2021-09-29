using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sarasi_HMS.Eventmanagement
{
    public partial class AddEventFoodPackage : Form
    {
        EventPackage mod1 = new EventPackage(); //database table name
        private static String status = "insert";
        String fileName;
        OnlineUser onlineUser = OnlineUser.getInstance();
        public AddEventFoodPackage()
        {
            InitializeComponent();
            setDefaultValues(); //setting up the default aspects 
        }

        private void btnFPgenarate_Click(object sender, EventArgs e)
        {
            String result = Util.generateKey("EventPackage");
            MessageBox.Show(result);
            txtEFPpackageId.Text = result;
        }
        void Clear()
        {
            txtEFPpackageId.Text = txtEFPname.Text = txtEFPpriceper.Text = txtEFPnoOfcurries.Text = richTxtEFPdesc.Rtf = "";
            btnEFPsave.Text = "Save";
            EFPpictureBox1.Image = null;
            EFPpictureBox2.Image = null;


        }

        private void btnEFPsave_Click(object sender, EventArgs e)
        {
            //asssign to table
            mod1.packageID = txtEFPpackageId.Text.Trim();
            mod1.Name = txtEFPname.Text.Trim();
            double platePrice;
            //checkk price
            bool Results = double.TryParse(txtEFPpriceper.Text, out platePrice);
            if (!Results)
            {
                MessageBox.Show("Invalid pattern. Please enter per plate price ");
            }
            else
            {
                mod1.plate_price = (float)platePrice;
            }
            mod1.noOfCurries = Int16.Parse(txtEFPnoOfcurries.Text);
            mod1.description = richTxtEFPdesc.Text.Trim();
            // mod1.mainMeal = EFPpictureBox1.Image
            mod1.mainMeal = convertImageToBinary(EFPpictureBox1.Image);
            mod1.desert = convertImageToBinary(EFPpictureBox2.Image);
            using (DBEntities db = new DBEntities())
            {
                if (status == "insert")
                {
                    db.EventPackages.Add(mod1);

                    MessageBox.Show("Successfully saved");
                }
                else if (status == "update")
                {
                    //updating the database 
                    db.Entry(mod1).State = EntityState.Modified;

                    MessageBox.Show("Category Updated Successfully");
                }
                db.SaveChanges();
            }
            Clear();
        }
        //method to convert the image into an byte array
        public static byte[] convertImageToBinary(Image img)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }

        }

        //Method for convert an byte array to an image 
        public static Image convertBinaryToImage(byte[] data)
        {
            using (MemoryStream ms = new MemoryStream(data))
            {
                return Image.FromStream(ms);
            }
        }

        private void btnEFPbrowse1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "JPEG|*.jpg", ValidateNames = true, Multiselect = false })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    fileName = ofd.FileName;
                    EFPpictureBox1.Image = Image.FromFile(fileName);
                }
            }
        }

        private void btnEFPbrowse2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "JPEG|*.jpg", ValidateNames = true, Multiselect = false })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    fileName = ofd.FileName;
                    EFPpictureBox2.Image = Image.FromFile(fileName);
                }
            }
        }

        private void btnEFPreset_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnEventBack_Click(object sender, EventArgs e)
        {
            EventManagementDashboard emd = new EventManagementDashboard();
            this.Hide();
            emd.Show();
        }

      

        private void logoutbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = Login.getInstance();
            login.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void setOnlineUserDetails()
        {
            Employee emp = new Employee();
            emp = onlineUser.getAvailableEmployee();
            picBoxUserImage.Image = Util.convertBinaryToImage(emp.image);
            llblUserName.Text = emp.fname + " " + emp.lname;
        }

        private void AddEventFoodPackage_Load(object sender, EventArgs e)
        {
            setOnlineUserDetails();
        }
        private void setDefaultValues()
        {
            DateTime time = DateTime.Now.ToLocalTime();
            lblDateTime.Text = time.ToString();
        }
        public void editEFoodPackage(String id)
        {

            //retreiving selected raw
            using (DBEntities db = new DBEntities())
            {
                //setting status to update 
                status = "update";
                btnEFPsave.Text = "Update";

                mod1 = db.EventPackages.Where(x => x.packageID == id).FirstOrDefault();
                MessageBox.Show(mod1.packageID);
                btnFPgenarate.Visible = false;

                //set values to the textboxess
                this.txtEFPpackageId.Text = mod1.packageID;
                txtEFPname.Text = mod1.Name;
                txtEFPpriceper.Text = mod1.plate_price.ToString();
                txtEFPnoOfcurries.Text = mod1.noOfCurries.ToString();
                richTxtEFPdesc.Text = mod1.description;

                EFPpictureBox1.Image = AddEventFoodPackage.convertBinaryToImage(mod1.mainMeal);
                EFPpictureBox2.Image = AddEventFoodPackage.convertBinaryToImage(mod1.desert);

                MessageBox.Show("end of method");



            }
        }

        private void btnEFPview_Click(object sender, EventArgs e)
        {
            EventPackageViews ev = new EventPackageViews();
            ev.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void picBoxUserImage_Click(object sender, EventArgs e)
        {

        }

        private void llblUserName_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
