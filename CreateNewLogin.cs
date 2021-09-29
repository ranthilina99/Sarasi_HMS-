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
    public partial class CreateNewLogin : Form
    {
        private static CreateNewLogin uniqueInstance = null;
        private List<Employee> employeeIdsList = new List<Employee>();

        private UserLogin userLoginModel = new UserLogin(); //raw object 

        
        private CreateNewLogin()
        {
            InitializeComponent();
        }

        public static CreateNewLogin getInstance()
        {
            if(uniqueInstance== null)
            {
                uniqueInstance = new CreateNewLogin();
            }
            return uniqueInstance;
        }

        public void loadEmplIdsToCombo()
        {
            using(DBEntities db = new DBEntities())
            {
              employeeIdsList = db.Employees.Where(x => x.employeeId.StartsWith("M") || x.employeeId.StartsWith("hc") || x.employeeId.StartsWith("Rc")).ToList();
            }

            comboEmpID.DataSource = employeeIdsList;
            comboEmpID.DisplayMember = "employeeId";

        }

        private void CreateNewLogin_Load(object sender, EventArgs e)
        {
            loadEmplIdsToCombo();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            directToEmployeeList();
            
        }

        private void btnCrreate_Click(object sender, EventArgs e)
        {
            userLoginModel.loginID = comboEmpID.Text;
            userLoginModel.username = txtUserName.Text;
            userLoginModel.password = txtPassword.Text;

            using(DBEntities db = new DBEntities())
            {
                db.UserLogins.Add(userLoginModel);

                try
                {
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("This employee Already have a Login !!!" + ex.Message);
                    
                }
                
            }
            MessageBox.Show("Login Created Successfully");
            clear();
            directToEmployeeList();
        }

        public void clear()
        {
            comboEmpID.Text = txtPassword.Text = txtUserName.Text = "";
        }

        public void directToEmployeeList()
        {
            EmployeeMangementDetailsList empList = EmployeeMangementDetailsList.getInstance();
            this.Hide();
            empList.Show();
        }
    }
}
