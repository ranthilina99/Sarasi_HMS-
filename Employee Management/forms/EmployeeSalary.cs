using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;
using System.Configuration;

namespace Sarasi_HMS
{
    public partial class EmployeeSalary : Form
    {
        //unique instance 
        private static EmployeeSalary uniqueInstance = null;
        //combo box
        public static List<ComboBox> AddEmployeeSalCombos = new List<ComboBox>();
        //employee list
        public static List<EmployeeSalary> sal = new List<EmployeeSalary>();
        //sql connection string
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBEntities1"].ConnectionString);
        //databse objects
        Employee emp = new Employee();
        Salary salary = new Salary();

        public EmployeeSalary()
        {
            InitializeComponent();
            initialAdd();

            setEmpSalComboBox();
        }
        public static EmployeeSalary getInstance()
        {
            if (uniqueInstance == null)
            {
                uniqueInstance = new EmployeeSalary();
            }
            return uniqueInstance;
        }
        private void initialAdd()
        {
            AddEmployeeSalCombos.Add(cmbempsal);
        }
        //set employee id combo box
        private void setEmpSalComboBox()
        {
            cmbempsal.DataSource = getempCategoryList();
            cmbempsal.DisplayMember = "employeeId";

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
        //s et the an get the label names
        public void empnames(String id)
        {
            try
            {
                using (DBEntities db = new DBEntities())
                {
               
                 emp = db.Employees.Where(x => x.employeeId == id).FirstOrDefault();
               
                 txtfirstname.Text = emp.fname;
                 txtlname.Text = emp.lname;
                 txtbasicsalto.Text = emp.basicsalary.ToString();
               
                 }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Please select Employee ID", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        //calculate the salary
        private void btncalculate_Click(object sender, EventArgs e)
        {
            if (validateFormDetails())
            {
                float otr, oth, bo, du, all, etf, result, ded_total, ot_total;
                int noOfDays, b1;
                b1 = Int32.Parse(txtbasicsalto.Text);
                otr = float.Parse(txtotRate.Text);
                oth = Int32.Parse(txtOThours.Text);
                bo = float.Parse(txtbouns.Text);
                du = float.Parse(txtdeduction.Text);
                all = float.Parse(txtallowance.Text);
                etf = float.Parse(txtetf.Text);
                noOfDays = int.Parse(txtnoOfday.Text);
                //deduction total
                ded_total = du + etf;
                //ott total
                ot_total = otr * oth;

                //total
                result = (bo + all - ded_total + ot_total) * noOfDays + b1;

                //set the text box
                txtnetsalto.Text = result.ToString();
                txtbounsto.Text = txtbouns.Text;
                txtallowanceto.Text = txtallowance.Text;
                txtdedustionto.Text = txtdeduction.Text;
                txtetfto.Text = txtetf.Text;
                txtotRateto.Text = txtotRate.Text;
                txtOtHoursto.Text = txtOThours.Text;
            }
        }
        public bool validateFormDetails()
        {
            bool flag = false;
            if (String.IsNullOrEmpty(cmbempsal.Text.Trim()))
            {
                MessageBox.Show("please enter Employee ID", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (String.IsNullOrEmpty(txtbasicsalto.Text.Trim()))
            {
                MessageBox.Show("please enter Basicsalary", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (String.IsNullOrEmpty(txtotRate.Text.Trim()))
            {
                MessageBox.Show("please enter OT Rate ", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (String.IsNullOrEmpty(txtOThours.Text.Trim()))
            {
                MessageBox.Show("please enter OT Hours ", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (String.IsNullOrEmpty(txtbouns.Text.Trim()))
            {
                MessageBox.Show("please enter salary Bouns ", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (String.IsNullOrEmpty(txtdeduction.Text.Trim()))
            {
                MessageBox.Show("please enter Deduction  ", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (String.IsNullOrEmpty(txtallowance.Text.Trim()))
            {
                MessageBox.Show("please enter Allowance  ", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (String.IsNullOrEmpty(txtetf.Text.Trim()))
            {
                MessageBox.Show("please enter ETF ", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (String.IsNullOrEmpty(txtfirstname.Text.Trim()))
            {
                MessageBox.Show("please enter Employee Name ", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (String.IsNullOrEmpty(txtlname.Text.Trim()))
            {
                MessageBox.Show("please enter Employee Last Name ", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (String.IsNullOrEmpty(txtnoOfday.Text.Trim()))
            {
                MessageBox.Show("please enter NoOfDays ", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (String.IsNullOrEmpty(cmbsalstatus.Text.Trim()))
            {
                MessageBox.Show("please enter status ", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        private void btnback_Click(object sender, EventArgs e)
        {
            EmployeeManagement emp = EmployeeManagement.getInstance();
            this.Hide();
            emp.Show();
        }

        private void btnPayslip_Click(object sender, EventArgs e)
        {
            EmployeePaySlip em =EmployeePaySlip.getInstance();
            em.Show();
            this.Hide();
        }

        //save the data================================================================================
        private void btnsave_Click(object sender, EventArgs e)
        {
            if (validateFormDetails())
            {
                salary.EmpID = cmbempsal.Text;
                salary.Firstname = txtfirstname.Text;
                salary.LastName = txtlname.Text;
                salary.Date = dateTimePicker1.Value;
                salary.OThours = Int32.Parse(txtOThours.Text);
                salary.OTRate = float.Parse(txtotRate.Text);
                salary.Bouns = Int32.Parse(txtbouns.Text);
                salary.Allowance = Int32.Parse(txtallowance.Text);
                salary.Deduction = Int32.Parse(txtdeduction.Text);
                salary.ETF = Int32.Parse(txtetf.Text);
                salary.Netsal = float.Parse(txtnetsalto.Text);
                salary.Status = cmbsalstatus.Text;
                salary.NoOfDays = int.Parse(txtnoOfday.Text);




                using (DBEntities db = new DBEntities())
                {
                    if (salary.SalaryID == 0)
                    {
                        db.Salaries.Add(salary);
                    }
                    else
                        db.Entry(salary).State = EntityState.Modified;
                    db.SaveChanges();

                }
                MessageBox.Show("Category Added Successfully");
                populargridview();
                clearTexts();
                salary.SalaryID = 0;
                cmbempsal.Enabled = true;
            }

        }// end the save salry=========================================================================

        //detete salary ofor the employees==============================================================
        private void brndelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure this record deleted?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (DBEntities db = new DBEntities())
                    {
                        var entry = db.Entry(salary);
                        if (entry.State == EntityState.Detached)
                        {
                            db.Salaries.Attach(salary);
                            db.Salaries.Remove(salary);
                            db.SaveChanges();
                            populargridview();
                            clearTexts();
                            MessageBox.Show("This record Delete Successfully...:");
                        }
                    }
                }
            }
            //exception handling========================================================================
            catch (DbUpdateConcurrencyException)
            {
                MessageBox.Show("Please select the row", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            cmbempsal.Enabled = false;
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            clearTexts();
        }

        private void btnfind_Click(object sender, EventArgs e)
        {
            empnames(cmbempsal.Text);
        }

        //employee salary load==============================================================
        private void EmployeeSalary_Load(object sender, EventArgs e)
        {
            clearTexts();
            this.ActiveControl = txtfirstname;
            populargridview();
            textviewbutton();
            lbldate.Text = DateTime.Now.ToLongDateString();
        }
        //set the text box initiazed========================================================
        private void textviewbutton()
        {
            txtnetsalto.Text = "0";
            txtallowanceto.Text = "0";
            txtbasicsalto.Text = "0";
            txtbounsto.Text = "0";
            txtdedustionto.Text = "0";
            txtetfto.Text = "0";
            txtotRateto.Text = "0";
            txtOtHoursto.Text = "0";
        }
        //clear the text box==================================================================
        public void clearTexts()
        {
            cmbempsal.Text = txtfirstname.Text = txtlname.Text = txtotRate.Text = txtOThours.Text = txtotRateto.Text = txtOtHoursto.Text =
                txtbouns.Text = txtbounsto.Text = txtallowance.Text = txtallowanceto.Text = txtdeduction.Text = txtdedustionto.Text = txtetf.Text = txtetfto.Text =
                txtnetsalto.Text = cmbsalstatus.Text = txtbasicsalto.Text = txtnoOfday.Text = null;
            btnsave.Text = "Save";
        }
        //sho the grid view==================================================================
        void populargridview()
        {
            salarydatagridview.AutoGenerateColumns = false;
            using (DBEntities db = new DBEntities())
            {
                salarydatagridview.DataSource = db.Salaries.ToList<Salary>();
            }
        }

        //get the data in the gridview======================================================================
        private void salarydatagridview_DoubleClick(object sender, EventArgs e)
        {
           
            if (salarydatagridview.CurrentRow.Index != -1)
            {
                salary.SalaryID = Convert.ToInt32(salarydatagridview.CurrentRow.Cells["dgsalaryid"].Value);
                using (DBEntities db = new DBEntities())
                {
                    //set the text box get the data================================================
                   

                    salary = db.Salaries.Where(x => x.SalaryID == salary.SalaryID).FirstOrDefault();
                    txtfirstname.Text = salary.Firstname;
                    txtlname.Text = salary.LastName;
                    dateTimePicker1.Value = Convert.ToDateTime(salary.Date);
                    txtotRate.Text = salary.OTRate.ToString();
                    txtOThours.Text = salary.OThours.ToString();
                    txtbouns.Text = salary.Bouns.ToString();
                    txtallowance.Text = salary.Allowance.ToString();
                    txtdeduction.Text = salary.Deduction.ToString();
                    txtnetsalto.Text = salary.Netsal.ToString();
                    cmbsalstatus.Text = salary.Status;
                    txtetf.Text = salary.ETF.ToString();                   
                    cmbempsal.Text = salary.EmpID;
                    txtnoOfday.Text = salary.NoOfDays.ToString();

                }
                cmbempsal.Enabled = false;
                btnsave.Text = "update";
            }
        }

        //timer====================================================================================
        private void timer1_Tick(object sender, EventArgs e)
        {
            lbltime.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

        //search box==============================================================================
        private void cmbempsal_SelectedIndexChanged(object sender, EventArgs e)
        {
            String query = "select * from Salary where FirstName like '" + txtsearch.Text + "%'";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            salarydatagridview.DataSource = dt;
            con.Close();
        }
    }
}
