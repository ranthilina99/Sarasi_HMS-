using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sarasi_HMS
{
    public partial class EmployeeUserProfile : Form
    {

        //unique instance
        private static EmployeeUserProfile uniqueInstance = null;

        //Employees - table Object ======================================== 
        Employee employeeModel = new Employee();
        Driver driverModel = new Driver();
        Cleaner cleanerModel = new Cleaner();
        Reception receptionModel = new Reception();
        HeadChef HeadchefModel = new HeadChef();
        Manager ManagerModel = new Manager();
        public EmployeeUserProfile()
        {
            InitializeComponent();
        }
        public static EmployeeUserProfile getInstance()
        {
            if (uniqueInstance == null)
            {
                uniqueInstance = new EmployeeUserProfile();
            }
            return uniqueInstance;
        }
        public void GetemployeeDetails(String id)
        {
            
            using (DBEntities db = new DBEntities())
            {
                employeeModel = db.Employees.Where(x => x.employeeId == id).FirstOrDefault();
                MessageBox.Show(employeeModel.employeeId, "Access the User Profile");

                txtempid.Text = employeeModel.employeeId;
                txtfname.Text = employeeModel.fname;
                txtlname.Text = employeeModel.lname;
                txtaddress.Text = employeeModel.address;
                txtemail.Text = employeeModel.email;
                txtdob.Value = Convert.ToDateTime(employeeModel.dob.ToString());
                txtconatcno.Text = employeeModel.contactno.ToString();
                txtbasicsal.Text = employeeModel.basicsalary.ToString();
                txtnationality.Text = employeeModel.nationality;
                txtmatrialststus.Text = employeeModel.matrialstatus;
                txtnic.Text = employeeModel.nic;
                cmbgender.Text = employeeModel.gender;
               


                picBoxEmp.Image = Util.convertBinaryToImage(employeeModel.image);

                if (id.StartsWith("D"))
                {
                    driverModel = db.Drivers.Where(x => x.driverid == id).FirstOrDefault();                    
                    cmbDriverSerivice.Text = driverModel.service;
                    txtlicenceno.Text = driverModel.licenceNo.ToString();
                    cmbdrivertype.Text = driverModel.type;
                    rbdriver.Checked = true;

                }
                else if (id.StartsWith("C"))
                {
                    cleanerModel = db.Cleaners.Where(x => x.cleanerid == id).FirstOrDefault();                   
                    txtclenertype.Text = cleanerModel.ctype;
                    rbcleaner.Checked = true;
                }
                else if (id.StartsWith("hc"))
                {
                    HeadchefModel = db.HeadChefs.Where(x => x.headchefid == id).FirstOrDefault();                    
                    txtservice.Text = HeadchefModel.service;
                    rbheadchef.Checked = true;
                }
                else if (id.StartsWith("M"))
                {
                    ManagerModel = db.Managers.Where(x => x.Managerid == id).FirstOrDefault();                 
                    cmbexperiecnce.Text = ManagerModel.experience;
                    rbmanager.Checked = true;
                }
                else if (id.StartsWith("Rc"))
                {
                    receptionModel = db.Receptions.Where(x => x.receptionid == id).FirstOrDefault();
                    cmblanguage.Text = receptionModel.language;
                    rbreception.Checked = true;
                }
            }
        }

        private void rbdriver_CheckedChanged(object sender, EventArgs e)
        {
           
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            groupBox4.Visible = true;
            groupBox5.Visible = false;
            groupBox4.BringToFront();
            TabPage t = tabControl1.TabPages[0];      
            tabControl1.SelectTab(t);
           
        }

        private void rbmanager_CheckedChanged(object sender, EventArgs e)
        {
           
            groupBox1.Visible = false;
            groupBox2.Visible = true;
            groupBox3.Visible = false;
            groupBox4.Visible = false;
            groupBox5.Visible = false;
            groupBox2.BringToFront();
            TabPage t = tabControl1.TabPages[1];
            tabControl1.SelectTab(t);
        }

        private void rbcleaner_CheckedChanged(object sender, EventArgs e)
        {
            
            groupBox1.Visible = true;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            groupBox4.Visible = false;
            groupBox5.Visible = false;
            groupBox1.BringToFront();
            TabPage t = tabControl1.TabPages[2];
            tabControl1.SelectTab(t);
        }

        private void rbreception_CheckedChanged(object sender, EventArgs e)
        {
            
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = true;
            groupBox4.Visible = false;
            groupBox5.Visible = false;
            groupBox3.BringToFront();
            TabPage t = tabControl1.TabPages[3];
            tabControl1.SelectTab(t);
        }

        private void rbheadchef_CheckedChanged(object sender, EventArgs e)
        {
            
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            groupBox4.Visible = false;
            groupBox5.Visible = true;
            groupBox5.BringToFront();
            TabPage t = tabControl1.TabPages[4];
            tabControl1.SelectTab(t);
        }

        private void EmployeeUserProfile_Load(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            groupBox4.Visible = false;
            groupBox5.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EmployeeMangementDetailsList emplist = EmployeeMangementDetailsList.getInstance();
            emplist.Show();
            this.Hide();
        }
    }
  

}
