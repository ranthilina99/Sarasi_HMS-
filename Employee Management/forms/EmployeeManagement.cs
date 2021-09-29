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
using System.Configuration;

namespace Sarasi_HMS
{
    public partial class EmployeeManagement : Form
    {
        private OnlineUser onlineUser = OnlineUser.getInstance();
        //unique instance 
        private static EmployeeManagement uniqueInstance = null;
        private EmployeeManagement()
        {
            InitializeComponent();
            setDefaultValues();
        }

        public static EmployeeManagement getInstance()
        {
            if (uniqueInstance == null)
            {
                uniqueInstance = new EmployeeManagement();
            }
            return uniqueInstance;
        }

        private void Btnemployee_Click(object sender, EventArgs e)
        {
            AddEmployee addEmp = AddEmployee.getInstance();
            addEmp.savebutton();
            addEmp.clearTexts();
            this.Hide();
            addEmp.Show();
        }

        private void btndashboard_Click(object sender, EventArgs e)
        {
            EmployeePaySlip ems = EmployeePaySlip.getInstance();
            ems.Show();
            this.Hide();
        }

        private void btnattendence_Click(object sender, EventArgs e)
        {
            AttendenceEmp att = AttendenceEmp.getInstance();
            this.Hide();
            att.Show();
        }
        //load the count details
        private void EmployeeManagement_Load(object sender, EventArgs e)
        {
            Loadchart();
            count_details();
            setOnlineUserDetails();

        }

        private void Loadchart()
        {
            //chart1.DataSource = Getdata();
            //chart1.Series["Series1"].XValueMember = "Month";
            //chart1.Series["Series1"].YValueMembers = "Employees";

            chart1.Series.Clear();
            chart1.DataBindCrossTable(Getdata().DefaultView, "status", "Month", "Employees", "Label=Employees");

        }

        //show the online user icon
        public void setOnlineUserDetails()
        {
            Employee emp = new Employee();
            emp = onlineUser.getAvailableEmployee();
            picBoxUserImage.Image = Util.convertBinaryToImage(emp.image);
            llblUserName.Text = emp.fname + " " + emp.lname;
        }


        private DataTable Getdata()
        {
            DataTable dt = new DataTable();
            using(SqlConnection conn=new SqlConnection(ConfigurationManager.ConnectionStrings["DBEntities1"].ConnectionString))
            {
                using(SqlCommand cmd=new SqlCommand("attenSummery", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    dt.Load(reader);
                }
            }
            return dt;
        }

        //set the time values
        private void setDefaultValues()
        {
            DateTime time = DateTime.Now.ToLocalTime();
            lblDateTime.Text = time.ToString();
        }

        private void btnsalary_Click(object sender, EventArgs e)
        {
            EmployeeSalary emp =EmployeeSalary.getInstance();
            emp.Show();
            this.Hide();
        }
        //find the count sql statement
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBEntities1"].ConnectionString);
        SqlCommand cmd, cmd2;
        SqlCommand cmd1;
        //sql query 
        String query = "SELECT COUNT(*) FROM Employee";
        String query1 = "select count(*) from Attendence1 where Status = 'Present'";
        String query2 = "select count(*) from Attendence1 where Status = 'Absent'";

        private void EmployeeManagement_Activated(object sender, EventArgs e)
        {
            //refersh panel
            panelprese.Refresh();
            panelallemp.Refresh();
            panelabsen.Refresh();
            count_details();
            chartpanel.Refresh();
            Loadchart();
        }

        private void btnallEmployess_Click(object sender, EventArgs e)
        {
            EmployeeMangementDetailsList emplist = EmployeeMangementDetailsList.getInstance();
            emplist.Show();
            this.Hide();
        }

        private void btnBackStock_Click(object sender, EventArgs e)
        {
            AdminPanelForm admin = AdminPanelForm.getInstance();
            admin.Show();
            this.Hide();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = Login.getInstance();
            login.Show();
        }

        //find the count deatils
        public void count_details()
        {
            try
            {
                con.Open();
                cmd = new SqlCommand(query, con);
                cmd1 = new SqlCommand(query1, con);
                cmd2 = new SqlCommand(query2, con);
                Int32 rows_count2 = Convert.ToInt32(cmd2.ExecuteScalar());
                Int32 rows_count1 = Convert.ToInt32(cmd1.ExecuteScalar());
                Int32 rows_count = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
                con.Close();

                lblempallemp.Text = rows_count.ToString();
                lblprsents.Text = rows_count1.ToString();
                lblabsence.Text = rows_count2.ToString();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }//*********************end the employee management**********************

    }
}
