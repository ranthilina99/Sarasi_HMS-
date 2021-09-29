using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sarasi_HMS
{
    public partial class employeecard : UserControl
    {
        public employeecard()
        {
            InitializeComponent();
        }
        public Image EmpImage
        {
            get { return emppicture.Image; }
            set { emppicture.Image = value; }
        }
        public String FirstName
        {
            get { return lblfirstname.Text; }
            set { lblfirstname.Text = value; }
        }
        public String LastName
        {
            get { return lbllastname.Text; }
            set { lbllastname.Text = value; }
        }
        public String Gender
        {
            get { return lblGender.Text; }
            set { lblGender.Text = value; }
        }
        public String Basicsalary
        {
            get { return lblbasicsalary.Text; }
            set { lblbasicsalary.Text = value; }
        }
        public String NIC
        {
            get { return lblnic.Text; }
            set { lblnic.Text = value; }
        }
        public String Destination
        {
            get { return lbldestination.Text; }
            set { lbldestination.Text = value; }
        }
        public String cardid
        {
            get { return lblcardid.Text; }
            set { lblcardid.Text = value; }
        }

        private void btnEditempCard_Click(object sender, EventArgs e)
        {
            //getting the card id 
            String cardID = this.cardid;
            AddEmployee emp = AddEmployee.getInstance();
            emp.editemployee(cardID);
            emp.Show();
            this.Hide();
        }

        private void btndeleteempCard_Click(object sender, EventArgs e)
        {
            String cardID = this.lblcardid.Text;

            EmployeeMangementDetailsList em = new EmployeeMangementDetailsList();
            em.deleteEmp(cardID);
        }

        private void emppicture_Click(object sender, EventArgs e)
        {
            //what to do when click on the card picture 
            MessageBox.Show("card clicked - id = " + cardid);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            String cardID = this.lblcardid.Text;
            EmployeeUserProfile profile =EmployeeUserProfile.getInstance();
            EmployeeMangementDetailsList em = new EmployeeMangementDetailsList();
            profile.Show();
            em.Hide();
            profile.GetemployeeDetails(cardID);
        }
    }
}
