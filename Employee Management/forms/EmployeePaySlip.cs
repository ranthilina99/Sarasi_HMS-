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
    public partial class EmployeePaySlip : Form
    {
        //unique instance 
        private static EmployeePaySlip uniqueInstance = null;
        //connection sql clinet
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBEntities1"].ConnectionString);

        public EmployeePaySlip()
        {
            InitializeComponent();
        }
        public static EmployeePaySlip getInstance()
        {
            if (uniqueInstance == null)
            {
                uniqueInstance = new EmployeePaySlip();
            }
            return uniqueInstance;
        }
        private void btnfind_Click(object sender, EventArgs e)
        {
            SqlDataAdapter dt = new SqlDataAdapter("Select * from Salary where Date= '" + dateTimePicker1.Value.ToString() + "' ", con);
            DataTable sd = new DataTable();
            dt.Fill(sd);
            salarydatagridview.DataSource = sd;
            // get the all employee details  according to the date

            if (cmbatt.Text == "All Employee")
            {
                SqlDataAdapter dt1 = new SqlDataAdapter("Select * from Salary where Date= '" + dateTimePicker1.Value.ToString() + "' ", con);
                DataTable sd1 = new DataTable();
                dt1.Fill(sd1);
                salarydatagridview.DataSource = sd1;
            }
            else if (cmbatt.Text == "Driver")
            {
                SqlDataAdapter dt1 = new SqlDataAdapter("Select * from Salary where Date= '" + dateTimePicker1.Value.ToString() + "'and EmpID like 'D%'", con);
                DataTable sd1 = new DataTable();
                dt1.Fill(sd1);
                salarydatagridview.DataSource = sd1;
            }
            else if (cmbatt.Text == "Cleaner")
            {
                SqlDataAdapter dt1 = new SqlDataAdapter("Select * from Salary where  Date= '" + dateTimePicker1.Value.ToString() + "'and EmpID like 'C%'", con);
                DataTable sd1 = new DataTable();
                dt1.Fill(sd1);
                salarydatagridview.DataSource = sd1;
            }
            else if (cmbatt.Text == "Reception")
            {
                SqlDataAdapter dt1 = new SqlDataAdapter("Select * from Salary where  Date= '" + dateTimePicker1.Value.ToString() + "''and EmpID like 'Rc%'", con);
                DataTable sd1 = new DataTable();
                dt1.Fill(sd1);
                salarydatagridview.DataSource = sd1;
            }
            else if (cmbatt.Text == "Head Chef")
            {
                SqlDataAdapter dt1 = new SqlDataAdapter("Select * from Salary where Date= '" + dateTimePicker1.Value.ToString() + "'and EmpID like 'hc%'", con);
                DataTable sd1 = new DataTable();
                dt1.Fill(sd1);
                salarydatagridview.DataSource = sd1;
            }
            else if (cmbatt.Text == "Manager")
            {
                SqlDataAdapter dt1 = new SqlDataAdapter("Select * from Salary where Date= '" + dateTimePicker1.Value.ToString() + "'and EmpID like 'M%'", con);
                DataTable sd1 = new DataTable();
                dt1.Fill(sd1);
                salarydatagridview.DataSource = sd1;
            }
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            EmployeeSalary em = EmployeeSalary.getInstance();
            em.Show();
            this.Hide();
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            EmployeeManagement em1 = EmployeeManagement.getInstance();
            em1.Show();
            this.Hide();
        }

        private void btnsalalldetails_Click(object sender, EventArgs e)
        {
            // all employee details
            if (cmbatt.Text == "All Employee")
            {
                SqlDataAdapter dt = new SqlDataAdapter("Select * from Salary ", con);
                DataTable sd = new DataTable();
                dt.Fill(sd);
                salarydatagridview.DataSource = sd;
            }
            else if (cmbatt.Text == "Driver")
            {
                SqlDataAdapter dt = new SqlDataAdapter("Select * from Salary where EmpID like 'D%'", con);
                DataTable sd = new DataTable();
                dt.Fill(sd);
                salarydatagridview.DataSource = sd;
            }
            else if (cmbatt.Text == "Cleaner")
            {
                SqlDataAdapter dt = new SqlDataAdapter("Select * from Salary where EmpID like 'C%'", con);
                DataTable sd = new DataTable();
                dt.Fill(sd);
                salarydatagridview.DataSource = sd;
            }
            else if (cmbatt.Text == "Reception")
            {
                SqlDataAdapter dt = new SqlDataAdapter("Select * from Salary where EmpID like 'Rc%'", con);
                DataTable sd = new DataTable();
                dt.Fill(sd);
                salarydatagridview.DataSource = sd;
            }
            else if (cmbatt.Text == "Head Chef")
            {
                SqlDataAdapter dt = new SqlDataAdapter("Select * from Salary where EmpID like 'hc%'", con);
                DataTable sd = new DataTable();
                dt.Fill(sd);
                salarydatagridview.DataSource = sd;
            }
            else if (cmbatt.Text == "Manager")
            {
                SqlDataAdapter dt = new SqlDataAdapter("Select * from Salary where EmpID like 'M%'", con);
                DataTable sd = new DataTable();
                dt.Fill(sd);
                salarydatagridview.DataSource = sd;
            }
        }

        //timer
        private void timer1_Tick(object sender, EventArgs e)
        {
            lbltime.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }
        
        //search employees salary
        private void txtsearch_TextChanged(object sender, EventArgs e)
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

        private void btnprint_Click(object sender, EventArgs e)
        {
            panel1.Show();
        }

        private void EmployeePaySlip_Load(object sender, EventArgs e)
        {
          
            // TODO: This line of code loads data into the 'eeDataSet.Salary' table. You can move, or remove it, as needed.
            this.salaryTableAdapter.Fill(this.eeDataSet.Salary);
            panel1.Hide();
            this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DataTable1TableAdapter.Fill(this.eeDataSet.DataTable1,comboBox1.Text);
            // TODO: This line of code loads data into the 'eeDataSet.Salary' table. You can move, or remove it, as needed.
            this.salaryTableAdapter.Fill(this.eeDataSet.Salary);
            this.reportViewer1.RefreshReport();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EmployeePaySlip empslip =  EmployeePaySlip.getInstance();
            empslip.Show();
            panel1.Hide();
        }
    }
}
