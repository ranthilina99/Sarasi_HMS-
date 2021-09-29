using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sarasi_HMS
{
    public partial class EmployeeMangementDetailsList : Form
    {
        //unique istence
        private static EmployeeMangementDetailsList uniqueInstance = null;
        //employee list to array
        private static List<Employee> employeelist = new List<Employee>();
        //card list to array
        private static List<employeecard> empCardList = new List<employeecard>();
        //design objects
        private employeecard empcard;
        private Employee emp;
        private Cleaner cleaner;
        private HeadChef hf;
        private Driver driver;
        private Reception reception;
        private Manager manager;
        public EmployeeMangementDetailsList()
        {
            InitializeComponent();
        }

        public static EmployeeMangementDetailsList getInstance()
        {
            if (uniqueInstance == null)
            {
                uniqueInstance = new EmployeeMangementDetailsList();
            }
            return uniqueInstance;
        }
        //load employee cards-----------------------------------------------------------------------------------------
        public void loadEmployees()
        {
            empCardList.Clear();

            using (DBEntities db = new DBEntities())
            {
                employeelist = db.Employees.ToList();
                //Employee Card
                foreach (Employee item in employeelist)
                {
                    empcard = new employeecard();
                    empcard.cardid = item.employeeId;
                    empcard.FirstName = item.fname;
                    empcard.LastName = item.lname;
                    empcard.NIC = item.nic;
                    empcard.Destination = item.designation;
                    empcard.Basicsalary = item.basicsalary.ToString();
                    empcard.EmpImage = Util.convertBinaryToImage(item.image);


                    //last line
                    empCardList.Add(empcard);
                }
            }//------------------------------------------------------------------------------------------------------------
            //all card item generater for loop
            foreach (employeecard card in empCardList)
            {
                flowEmployeesPanel.Controls.Add(card);
            }
        }

        private void btnAddnewCategory_Click(object sender, EventArgs e)
        {
            AddEmployee amp = AddEmployee.getInstance();
            amp.savebutton();
            amp.Show();
            this.Hide();
        }
        //Delete Employees employee management list----------------------------------------------------------------------------------------------------
        public void deleteEmp(String id)
        {
            try
            {
                if (MessageBox.Show("Are you sure to Delete this record?", "Delete Category", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    using (DBEntities db = new DBEntities())
                    {


                        if (id.StartsWith("D"))
                        {
                            driver = db.Drivers.Where(x => x.driverid == id).First();
                            db.Drivers.Remove(driver);
                            db.SaveChanges();
                        }
                        else if (id.StartsWith("C"))
                        {
                            cleaner = db.Cleaners.Where(x => x.cleanerid == id).First();
                            db.Cleaners.Remove(cleaner);
                            db.SaveChanges();
                        }
                        else if (id.StartsWith("hc"))
                        {
                            hf = db.HeadChefs.Where(x => x.headchefid == id).First();
                            db.HeadChefs.Remove(hf);
                            db.SaveChanges();
                        }
                        else if (id.StartsWith("M"))
                        {
                            manager = db.Managers.Where(x => x.Managerid == id).First();
                            db.Managers.Remove(manager);
                            db.SaveChanges();
                        }
                        else if (id.StartsWith("Rc"))
                        {
                            reception = db.Receptions.Where(x => x.receptionid == id).First();
                            db.Receptions.Remove(reception);
                            db.SaveChanges();
                        }

                        emp = db.Employees.Where(x => x.employeeId == id).First();
                        db.Employees.Remove(emp);
                        db.SaveChanges();
                    }
                    MessageBox.Show("Category Removed Successfully!!!");
                    clearempcardpanel();
                    Refresh();

                }

                loadEmployees();
            }
            //Exception handling
            catch (DbUpdateException)
            {
                MessageBox.Show("Forignkey supported no delete please salary and attendendence select user deletails delete", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("InvalidOperation", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }//----------------------------------------------------------------------------------------------------------------------------------------------------------------------

        private void button1_Click(object sender, EventArgs e)
        {
            EmployeeManagement em = EmployeeManagement.getInstance();
            em.Show();
            this.Hide();
        }
        //clear panel employee list
        public void clearempcardpanel()
        {
            flowEmployeesPanel.Controls.Clear();
        }

        //timer
        private void timer1_Tick(object sender, EventArgs e)
        {
            lbltime.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

        //employee panel activated and refrsh panel
        private void EmployeeMangementDetailsList_Activated(object sender, EventArgs e)
        {
            clearempcardpanel();

            loadEmployees();
        }

        //load the forms
        private void EmployeeMangementDetailsList_Load(object sender, EventArgs e)
        {
            loadEmployees();

            //date
            lbldate.Text = DateTime.Now.ToLongDateString();
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            AddEmployee addEmployee = AddEmployee.getInstance();
            addEmployee.Show();
            this.Hide();
        }

        private void btnCreateLogin_Click(object sender, EventArgs e)
        {
            CreateNewLogin cl = CreateNewLogin.getInstance();
            this.Hide();
            cl.Show();
        }
    }//****************end the emploayee panel********************************

}
