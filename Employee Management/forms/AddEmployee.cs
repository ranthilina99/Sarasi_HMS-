using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sarasi_HMS
{
    public partial class AddEmployee : Form
    {
        //unique instance
        private static AddEmployee uniqueInstance = null;
        //add or update
        private String status = "insert";
        //employee type
        private static String empType = "none";
        //browse file object
        String fileName;

        //Employees - table Object ======================================== 
        Employee employeeModel = new Employee();
        Driver driverModel = new Driver();
        Cleaner cleanerModel = new Cleaner();
        Reception receptionModel = new Reception();
        HeadChef HeadchefModel = new HeadChef();
        Manager ManagerModel = new Manager();
        //===================================================================

        public AddEmployee()
        {
            InitializeComponent();
        }
        public static AddEmployee getInstance()
        {
            if (uniqueInstance == null)
            {
                uniqueInstance = new AddEmployee();
            }
            return uniqueInstance;
        }    

        private void btnGenerate_Click_1(object sender, EventArgs e)
        {
            String key = Util.generateKey(empType);
            MessageBox.Show(key);
            txtempid.Text = key;
        }
        //save employee details database
        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (validateFormDetails())
            {
                try
                {

                    //text boxes
                    employeeModel.employeeId = txtempid.Text;
                    employeeModel.fname = txtfname.Text;
                    employeeModel.lname = txtlname.Text;
                    employeeModel.dob = txtdob.Value;
                    employeeModel.contactno = int.Parse(txtconatcno.Text);
                    employeeModel.nic = txtnic.Text;
                    employeeModel.matrialstatus = txtmatrialststus.Text;
                    employeeModel.email = txtemail.Text;
                    employeeModel.basicsalary = Int32.Parse(txtbasicsal.Text);
                    employeeModel.gender = cmbgender.Text;
                    employeeModel.nationality = txtnationality.Text;
                    employeeModel.address = txtaddress.Text;
                    employeeModel.designation = empType;

                    if (empType == "driver")
                    {
                        //textboxes and combo box driver
                        driverModel.driverid = txtempid.Text;
                        driverModel.licenceNo = Int32.Parse(txtlicenceno.Text);
                        driverModel.service = cmbDriverSerivice.Text;
                        driverModel.type = cmbdrivertype.Text;
                    }

                    if (empType == "cleaner")
                    {
                        //combo box cleaner
                        cleanerModel.ctype = txtclenertype.Text;
                        cleanerModel.cleanerid = txtempid.Text;
                    }
                    if (empType == "receptionist")
                    {
                        //combo box receptions
                        receptionModel.receptionid = txtempid.Text;
                        receptionModel.language = cmblanguage.Text;
                    }
                    if (empType == "manager")
                    {
                        //combo boc manager
                        ManagerModel.Managerid = txtempid.Text;
                        ManagerModel.experience = cmbexperiecnce.Text;
                    }
                    if (empType == "headChef")
                    {
                        //combo box mheadchef
                        HeadchefModel.headchefid = txtempid.Text;
                        HeadchefModel.service = txtservice.Text;
                    }

                    //imagee 
                    employeeModel.image = Util.convertImageToBinary(picBoxEmp.Image);
                }
                //exception handling
                catch (NullReferenceException)
                {
                    MessageBox.Show("Please fill the text box and Image", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (FormatException)
                {
                    MessageBox.Show("please fill the integer number","Invalid",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
                using (DBEntities db = new DBEntities())
                {

                    if (status == "insert")
                    {
                        //adding the employee 
                        db.Employees.Add(employeeModel);
                    }
                    else if (status == "update")
                    {
                        db.Entry(employeeModel).State = EntityState.Modified;
                    }

                    if (empType == "driver")
                    {

                        if (status == "insert")
                        {
                            //adding the driver 
                            db.Drivers.Add(driverModel);
                            MessageBox.Show("Driver added Successfully!!!");
                        }
                        else if (status == "update")
                        {
                            //update the table
                            db.Entry(driverModel).State = EntityState.Modified;

                            MessageBox.Show("driver Updated Successfully");
                        }
                        clearTexts();
                        // db.SaveChanges();


                    }
                    else if (empType == "cleaner")
                    {

                        if (status == "insert")
                        {
                            //adding the cleaner 
                            db.Cleaners.Add(cleanerModel);
                            MessageBox.Show("Cleaner added Successfully!!!");
                        }
                        else if (status == "update")
                        {
                            //update the table
                            db.Entry(cleanerModel).State = EntityState.Modified;

                            MessageBox.Show("Cleaner Updated Successfully");
                        }
                        clearTexts();
                        //db.SaveChanges();
                    }
                    else if (empType == "receptionist")
                    {

                        if (status == "insert")
                        {
                            //adding the receptionist 
                            db.Receptions.Add(receptionModel);
                            MessageBox.Show("receptionist added Successfully!!!");
                        }
                        else if (status == "update")
                        {
                            //update the table
                            db.Entry(receptionModel).State = EntityState.Modified;

                            MessageBox.Show("receptionist Updated Successfully");
                        }
                        clearTexts();
                        // db.SaveChanges();
                    }
                    else if (empType == "manager")
                    {

                        if (status == "insert")
                        {
                            //adding the manager 
                            db.Managers.Add(ManagerModel);
                            MessageBox.Show("Manager added Successfully!!!");
                        }
                        else if (status == "update")
                        {
                            //update the table
                            db.Entry(ManagerModel).State = EntityState.Modified;

                            MessageBox.Show("Manager Updated Successfully");
                        }

                        // db.SaveChanges();
                        clearTexts();
                    }
                    else if (empType == "headChef")
                    {

                        if (status == "insert")
                        {
                            //adding the headchef 
                            db.HeadChefs.Add(HeadchefModel);
                            MessageBox.Show("headChef added Successfully!!!");
                        }
                        else if (status == "update")
                        {
                            //update the table
                            db.Entry(HeadchefModel).State = EntityState.Modified;

                            MessageBox.Show("headChef Updated Successfully");
                        }

                        //db.SaveChanges();
                        clearTexts();

                    }
                    try
                    {
                        db.SaveChanges();
                    }
                    catch (DbUpdateException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    catch (DbEntityValidationException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
                EmployeeMangementDetailsList em = EmployeeMangementDetailsList.getInstance();
                em.Show();
                this.Hide();
                em.clearempcardpanel();
                em.loadEmployees();
                Refresh();

            }

        }//end of save event==============================================================
        public bool validateFormDetails()
        {
            bool flag = false;
            if (String.IsNullOrEmpty(txtempid.Text.Trim()))
            {
                MessageBox.Show("please enter Employee Id ", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else if (String.IsNullOrEmpty(txtfname.Text.Trim()))
            {
                MessageBox.Show("please enter Employee Firstname name ", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (String.IsNullOrEmpty(txtlname.Text.Trim()))
            {
                MessageBox.Show("please enter Employee Last name ", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (String.IsNullOrEmpty(txtnic.Text.Trim()))
            {
                MessageBox.Show("please enter Employee NIC  ", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (String.IsNullOrEmpty(txtmatrialststus.Text.Trim()))
            {
                MessageBox.Show("please enter Employee matrialststus  ", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (String.IsNullOrEmpty(txtemail.Text.Trim()))
            {
                MessageBox.Show("please enter Employee Email  ", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (String.IsNullOrEmpty(cmbgender.Text.Trim()))
            {
                MessageBox.Show("please enter Employee Gender ", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (String.IsNullOrEmpty(txtnationality.Text.Trim()))
            {
                MessageBox.Show("please enter Employee Nationality ", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (String.IsNullOrEmpty(txtaddress.Text.Trim()))
            {
                MessageBox.Show("please enter Employee Address ", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (String.IsNullOrEmpty(txtbasicsal.Text.Trim()))
            {
                MessageBox.Show("please enter Employee basicsalary ", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (String.IsNullOrEmpty(txtconatcno.Text.Trim()))
            {
                MessageBox.Show("please enter Employee contact no ", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
         
            else
            {
                //if (Int32.TryParse(txtbasicsal.Text, out var res))
                //{
                //    MessageBox.Show("Employee BasicSalary cannot be a number", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //}

                //else
                //{
                  flag = true;
                //}
            }
            return flag;
        }
        public void savebutton()
        {
            status = "insert";
            btnSave.Text = "Save";
        }

        //driver radio button
        private void rbdriver_CheckedChanged(object sender, EventArgs e)
        {
            empType = "driver";
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            groupBox4.Visible = true;
            groupBox5.Visible = false;
            groupBox4.BringToFront();
            TabPage t = tabControl1.TabPages[0];
            tabControl1.SelectTab(t);
        }

        //manager radio button
        private void rbmanager_CheckedChanged(object sender, EventArgs e)
        {
            empType = "manager";
            groupBox1.Visible = false;
            groupBox2.Visible = true;
            groupBox3.Visible = false;
            groupBox4.Visible = false;
            groupBox5.Visible = false;
            groupBox2.BringToFront();
            TabPage t = tabControl1.TabPages[1];
            tabControl1.SelectTab(t);
        }

        //cleaner radio button
        private void rbcleaner_CheckedChanged(object sender, EventArgs e)
        {
            empType = "cleaner";
            //tab box
            groupBox1.Visible = true;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            groupBox4.Visible = false;
            groupBox5.Visible = false;
            groupBox1.BringToFront();
            TabPage t = tabControl1.TabPages[2];
            tabControl1.SelectTab(t);
        }

        //receptionist radio buttion
        private void rbreception_CheckedChanged(object sender, EventArgs e)
        {
            empType = "receptionist";
            //tab box
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = true;
            groupBox4.Visible = false;
            groupBox5.Visible = false;
            groupBox3.BringToFront();
            TabPage t = tabControl1.TabPages[3];
            tabControl1.SelectTab(t);
        }
        //headchef radio button
        private void rbheadchef_CheckedChanged(object sender, EventArgs e)
        {
            
            empType = "headChef";
            //tab box
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            groupBox4.Visible = false;
            groupBox5.Visible = true;
            groupBox5.BringToFront();
            TabPage t = tabControl1.TabPages[4];
            tabControl1.SelectTab(t);
        }

        private void Empdet_Click(object sender, EventArgs e)
        {
            EmployeeMangementDetailsList em = EmployeeMangementDetailsList.getInstance();
            this.Hide();
            em.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EmployeeManagement emplist = EmployeeManagement.getInstance();
            emplist.Show();
            this.Hide();
        }

        private void btnbrowser_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "JPEG|*.jpg", ValidateNames = true, Multiselect = false })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    fileName = ofd.FileName;
                    picBoxEmp.Image = Image.FromFile(fileName);
                }


            }
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            EmployeeManagement em = EmployeeManagement.getInstance();
            em.Show();
            this.Hide();
        }
        //edit employees ==================================================
        public void editemployee(String id)
        {
            status = "update";
            btnSave.Text = "Update";
            using (DBEntities db = new DBEntities())
            {
                employeeModel = db.Employees.Where(x => x.employeeId == id).FirstOrDefault();
                MessageBox.Show(employeeModel.employeeId,"Employee Access update");

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
                    MessageBox.Show(driverModel.driverid,"Driver Access update");
                    cmbDriverSerivice.Text = driverModel.service;
                    txtlicenceno.Text = driverModel.licenceNo.ToString();
                    cmbdrivertype.Text = driverModel.type;
                    rbdriver.Checked = true;

                }
                else if (id.StartsWith("C"))
                {
                    cleanerModel = db.Cleaners.Where(x => x.cleanerid == id).FirstOrDefault();
                    MessageBox.Show(cleanerModel.cleanerid, "Cleaners Access update");
                    txtclenertype.Text = cleanerModel.ctype;
                    rbcleaner.Checked = true;
                }
                else if (id.StartsWith("hc"))
                {
                    HeadchefModel = db.HeadChefs.Where(x => x.headchefid == id).FirstOrDefault();
                    MessageBox.Show(HeadchefModel.headchefid, "HeadChefs Access update");
                    txtservice.Text = HeadchefModel.service;
                    rbheadchef.Checked = true;
                }
                else if (id.StartsWith("M"))
                {
                    ManagerModel = db.Managers.Where(x => x.Managerid == id).FirstOrDefault();
                    MessageBox.Show(ManagerModel.Managerid, "Managers Access update");
                    cmbexperiecnce.Text = ManagerModel.experience;
                    rbmanager.Checked = true;
                }
                else if (id.StartsWith("Rc"))
                {
                    receptionModel = db.Receptions.Where(x => x.receptionid == id).FirstOrDefault();
                    MessageBox.Show(receptionModel.receptionid, "Receptions Access update");
                    cmblanguage.Text = receptionModel.language;
                    rbreception.Checked = true;
                }





            }

        }// end the edit details===================================================

        //clear text boxes===========================
        public void clearTexts()
        {
            txtempid.Text = txtfname.Text = txtlname.Text = txtaddress.Text = txtconatcno.Text = txtnic.Text = txtmatrialststus.Text = txtemail.Text = txtbasicsal.Text = cmbgender.Text = txtnationality.Text = cmblanguage.
                Text = txtlicenceno.Text = txtservice.Text = txtservice.Text = cmbdrivertype.Text = cmbexperiecnce.Text = txtclenertype.Text = cmbDriverSerivice.Text = "";
               // rbcleaner.Checked=rbdriver.Checked = rbheadchef.Checked = rbmanager.Checked = rbreception.Checked =false;
            picBoxEmp.Image = null;
            status = "insert";
            btnSave.Text = "Save";
        }

        private void AddEmployee_Load(object sender, EventArgs e)
        {
            //hidding the group box panel hidding
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            groupBox4.Visible = false;
            groupBox5.Visible = false;

            lbldate.Text = DateTime.Now.ToLongDateString();
        }

        private void txtfname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        // timer
        private void timer1_Tick(object sender, EventArgs e)
        {
            lbltime.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }
    }
    
}
