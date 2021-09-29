using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sarasi_HMS
{
    public partial class AttendenceEmp : Form
    {
        //unique instance
        private static AttendenceEmp uniqueInstance = null;

        public static List<ComboBox> AddEmployeeCombos = new List<ComboBox>();
        Employee emp = new Employee();


        attendence1 attendence = new attendence1();
        public AttendenceEmp()
        {
            InitializeComponent();
            initialAdd();

            setCategoryComboBox();
        }
        public static AttendenceEmp getInstance()
        {
            if (uniqueInstance == null)
            {
                uniqueInstance = new AttendenceEmp();
            }
            return uniqueInstance;
        }
        private void initialAdd()
        {
            AddEmployeeCombos.Add(combocategory);
        }
        private void setCategoryComboBox()
        {
            combocategory.DataSource = getempCategoryList();
            combocategory.DisplayMember = "employeeId";

        }
        private List<Employee> getempCategoryList()
        {   //creating new List 
            List<Employee> fclist = new List<Employee>();

            using (DBEntities db = new DBEntities())
            {
                fclist = db.Employees.ToList();

            }
            return fclist;
        }
        public void empnames(String id)
        {
            using (DBEntities db = new DBEntities())
            {
                emp = db.Employees.Where(x => x.employeeId == id).FirstOrDefault();
               
                    txtfname.Text = emp.fname;
                    txtlname.Text = emp.lname;
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            empnames(combocategory.Text);
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            EmployeeManagement em = EmployeeManagement.getInstance();
            em.Show();
            this.Hide();
        }

        private void btnreport_Click(object sender, EventArgs e)
        {
            EmployeeAttendenceReport empreport = new EmployeeAttendenceReport();
            empreport.Show();
            this.Hide();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateFormDetails())
            {
                attendence.EmpID = combocategory.Text;
                attendence.FirstName = txtfname.Text;
                attendence.LastName = txtlname.Text;
                attendence.Status = cmbstatus.Text;
                attendence.INtime = txttime.Text;
                attendence.OutTime = txtouttime.Text;
                attendence.Date = dateTimePicker1.Value;

                using (DBEntities db = new DBEntities())
                {
                    if (attendence.AttendenceID == 0)
                    {
                        db.attendence1.Add(attendence);
                    }
                    else
                        db.Entry(attendence).State = EntityState.Modified;
                    db.SaveChanges();

                }
                MessageBox.Show("Attendence Added Successfully");
                populargridview();
                clearTexts();
                attendence.AttendenceID = 0;
            }
            combocategory.Enabled = true;
            timedesign();
        }

        private void btnddelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure this record deleted?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (DBEntities db = new DBEntities())
                    {
                        var entry = db.Entry(attendence);
                        if (entry.State == EntityState.Detached)
                        {
                            db.attendence1.Attach(attendence);
                            db.attendence1.Remove(attendence);
                            db.SaveChanges();
                            populargridview();
                            clearTexts();
                            MessageBox.Show("This record Delete Successfully...:");
                        }
                    }
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                MessageBox.Show("Please select the row", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
        public bool validateFormDetails()
        {
            bool flag = false;
            if (String.IsNullOrEmpty(combocategory.Text.Trim()))
            {
                MessageBox.Show("please enter Employee ID ", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else if (String.IsNullOrEmpty(txtfname.Text.Trim()))
            {
                MessageBox.Show("please enter Employee Firstname name ", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (String.IsNullOrEmpty(txtlname.Text.Trim()))
            {
                MessageBox.Show("please enter Employee Last name ", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (String.IsNullOrEmpty(cmbstatus.Text.Trim()))
            {
                MessageBox.Show("please enter Status  ", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (String.IsNullOrEmpty(txttime.Text.Trim()))
            {
                MessageBox.Show("please enter IN time  ", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (String.IsNullOrEmpty(txtouttime.Text.Trim()))
            {
                MessageBox.Show("please enter Out Time  ", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            

            else
            {
                //if (Int32.TryParse(txtbasicsal.Text, out int res))
                //{
                //    MessageBox.Show("Employee BasicSalary cannot be a number", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //}


                {
                    flag = true;
                }
            }
            return flag;
        }
        private void btncancel_Click(object sender, EventArgs e)
        {
            clearTexts();
            combocategory.Enabled = true;
        }

        private void AttendenceEmp_Load(object sender, EventArgs e)
        {
            combocategory.Enabled = true;
            clearTexts();
            this.ActiveControl = txtfname;
            populargridview();
            timedesign();
            lbldate.Text = DateTime.Now.ToLongDateString();
        }
        public void btnenable()
        {
            combocategory.Enabled = true;
        }
        private void timedesign()
        {
            txtouttime.Text = "0:00";
            txttime.Text = "0:00";
        }
        public void clearTexts()
        {
            combocategory.Text = txtfname.Text = txtlname.Text = txttime.Text = txtouttime.Text = "";
            btnSave.Text = "Save";
        }
        void populargridview()
        {
            employeeGridView.AutoGenerateColumns = false;
            using (DBEntities db = new DBEntities())
            {
                employeeGridView.DataSource = db.attendence1.ToList<attendence1>();
            }
        }

        private void employeeGridView_DoubleClick(object sender, EventArgs e)
        {
            if (employeeGridView.CurrentRow.Index != -1)
            {
                attendence.AttendenceID = Convert.ToInt32(employeeGridView.CurrentRow.Cells["dgattendenceID"].Value);
                using (DBEntities db = new DBEntities())
                {
                    attendence = db.attendence1.Where(x => x.AttendenceID == attendence.AttendenceID).FirstOrDefault();
                    txtfname.Text = attendence.FirstName;
                    txtlname.Text = attendence.LastName;
                    txtouttime.Text = attendence.OutTime;
                    txttime.Text = attendence.INtime;
                    cmbstatus.Text = attendence.Status;
                    dateTimePicker1.Value = Convert.ToDateTime(attendence.Date);
                    combocategory.Text = attendence.EmpID;

                }
                btnSave.Text = "update";
                combocategory.Enabled = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbltime.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }
    }
}
