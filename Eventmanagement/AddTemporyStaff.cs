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
    public partial class AddTemporyStaff : Form
    {
        OnlineUser onlineUser = OnlineUser.getInstance();
        TempStaff ts1 = new TempStaff();
        private static String status = "insert";
        public AddTemporyStaff()
        {
            InitializeComponent();
            setDefaultValues();
        }
        //clear method
        void Clear()
        {
            txtETSid.Text = txtETSfname.Text = txtETSlname.Text = combETSgender.Text = txtETScontact.Text = txtETSemail.Text = txtETSdailySal.Text = txtETSemail.Text = combETStype.Text = "";
            btnETSsave.Text = "Save";


        }

        private void btnTSgenarate_Click(object sender, EventArgs e)
        {
            String result = Util.generateKey("TempStaff");
            MessageBox.Show(result);
            txtETSid.Text = result;
        }

        private void setDefaultValues()
        {
            DateTime time = DateTime.Now.ToLocalTime();
            lblDateTime.Text = time.ToString();
        }

        public void setOnlineUserDetails()
        {
            Employee emp = new Employee();
            emp = onlineUser.getAvailableEmployee();
            picBoxUserImage.Image = Util.convertBinaryToImage(emp.image);
            llblUserName.Text = emp.fname + " " + emp.lname;
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

        private void btnEventBack_Click(object sender, EventArgs e)
        {
            EventManagementDashboard emd = new EventManagementDashboard();
            this.Hide();
            emd.Show();
        }

        private void btnETSsave_Click(object sender, EventArgs e)
        {
            //asssign to table
            ts1.staffID = txtETSid.Text.Trim();
            ts1.fName = txtETSfname.Text.Trim();
            ts1.lName = txtETSlname.Text.Trim();
            ts1.gender = combETSgender.Text;
            ts1.contact = Int32.Parse(txtETScontact.Text);
            ts1.email = txtETSemail.Text.Trim();
            double dailySal;
            bool Results = double.TryParse(txtETSdailySal.Text, out dailySal);
            if (!Results)
            {
                MessageBox.Show("Please enter real numbers");

            }
            else
            {
                ts1.dailySal = (float)dailySal;
            }
            ts1.type = combETStype.Text;




            using (DBEntities db = new DBEntities())
            {
                if (status == "insert")
                {
                    db.TempStaffs.Add(ts1);

                    MessageBox.Show("Successfully saved");
                }
                else if (status == "update")
                {
                    //updating the database 
                    db.Entry(ts1).State = EntityState.Modified;

                    MessageBox.Show("Staff Updated Successfully");

                }
                db.SaveChanges();
            }
            Clear();
        }

        public void editTempStaff(String id)
        {

            //retreiving selected raw
            using (DBEntities db = new DBEntities())
            {
                //setting status to update 
                status = "update";
                btnETSsave.Text = "Update";

                ts1 = db.TempStaffs.Where(x => x.staffID == id).FirstOrDefault();
                MessageBox.Show(ts1.staffID);
                btnTSgenarate.Visible = false;

                //set values to the textboxess
                this.txtETSid.Text = ts1.staffID;
                txtETSfname.Text = ts1.fName;
                txtETSlname.Text = ts1.lName;
                combETSgender.Text = ts1.gender;
                txtETScontact.Text = ts1.contact.ToString();
                txtETSemail.Text = ts1.email;
                txtETSdailySal.Text = ts1.dailySal.ToString();
                combETStype.Text = ts1.type;


                // MessageBox.Show("end of method");



            }
        }

        private void btnETSreset_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void AddTemporyStaff_Load(object sender, EventArgs e)
        {
            setOnlineUserDetails();
        }

       

        private void btnViewTS_Click(object sender, EventArgs e)
        {
            TemporyStaffViews ev = new TemporyStaffViews();
            ev.Show();
            this.Hide();
        }
    }
}
