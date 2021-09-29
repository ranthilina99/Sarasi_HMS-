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
    public partial class EmployeeAttendenceReport : Form
    {
        //unique instance
        private static EmployeeAttendenceReport uniqueInstance = null;
        //combo box list
        public static List<ComboBox> AddAttendenceEmployeeCombos = new List<ComboBox>();
        
        public EmployeeAttendenceReport()
        {
            InitializeComponent();
        }
        public static EmployeeAttendenceReport getInstance()
        {
            if (uniqueInstance == null)
            {
                uniqueInstance = new EmployeeAttendenceReport();
            }
            return uniqueInstance;
        }

        //sql connection string connect
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBEntities1"].ConnectionString);
        private void Brnfind_Click(object sender, EventArgs e)
        {
            //all employees get the values 
            if (cmbatt.Text == "All Employee")
            {
                SqlDataAdapter dt = new SqlDataAdapter("Select * from Attendence1 where Date between'" + dataform.Value.ToString() + "' and '" + datato.Value.ToString() + "'", conn);
                DataTable sd = new DataTable();
                dt.Fill(sd);
                empattdatagrid.DataSource = sd;
            }
            //all drivers get the date for the values
            else if (cmbatt.Text == "Driver")
            {
                SqlDataAdapter dt = new SqlDataAdapter("Select * from Attendence1 where Date between'" + dataform.Value.ToString() + "' and '" + datato.Value.ToString() + "'and EmpID like 'D%'", conn);
                DataTable sd = new DataTable();
                dt.Fill(sd);
                empattdatagrid.DataSource = sd;
            }
            // all cleaners get the date for the values
            else if (cmbatt.Text == "Cleaner")
            {
                SqlDataAdapter dt = new SqlDataAdapter("Select * from Attendence1 where Date between'" + dataform.Value.ToString() + "' and '" + datato.Value.ToString() + "'and EmpID like 'C%'", conn);
                DataTable sd = new DataTable();
                dt.Fill(sd);
                empattdatagrid.DataSource = sd;
            }
            // all Reception get the date for the values
            else if (cmbatt.Text == "Reception")
            {
                SqlDataAdapter dt = new SqlDataAdapter("Select * from Attendence1 where Date between'" + dataform.Value.ToString() + "' and '" + datato.Value.ToString() + "'and EmpID like 'Rc%'", conn);
                DataTable sd = new DataTable();
                dt.Fill(sd);
                empattdatagrid.DataSource = sd;
            }
            // all Head Chef get the date for the values
            else if (cmbatt.Text == "Head Chef")
            {
                SqlDataAdapter dt = new SqlDataAdapter("Select * from Attendence1 where Date between'" + dataform.Value.ToString() + "' and '" + datato.Value.ToString() + "'and EmpID like 'hc%'", conn);
                DataTable sd = new DataTable();
                dt.Fill(sd);
                empattdatagrid.DataSource = sd;
            }
            // all Manager get the date for the values
            else if (cmbatt.Text == "Manager")
            {
                SqlDataAdapter dt = new SqlDataAdapter("Select * from Attendence1 where Date between'" + dataform.Value.ToString() + "' and '" + datato.Value.ToString() + "'and EmpID like 'M%'", conn);
                DataTable sd = new DataTable();
                dt.Fill(sd);
                empattdatagrid.DataSource = sd;
            }
    
        }

        private void EmployeeAttendenceReport_Load(object sender, EventArgs e)
        {
          
            lbldate.Text = DateTime.Now.ToLongDateString();
            //input search
            searchbox("");
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            EmployeeManagement att = EmployeeManagement.getInstance();
            this.Hide();
            att.Show();
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            AttendenceEmp att = AttendenceEmp.getInstance();
            this.Hide();
            att.Show();
        }

        private void btngetallvalues_Click(object sender, EventArgs e)
        {
            // all employees get the grid view
            if (cmbatt.Text == "All Employee")
            {
                SqlDataAdapter dt = new SqlDataAdapter("Select * from Attendence1 ", conn);
                DataTable sd = new DataTable();
                dt.Fill(sd);
                empattdatagrid.DataSource = sd;
            }
            // all Driver get the grid view
            else if (cmbatt.Text == "Driver")
            {
                SqlDataAdapter dt = new SqlDataAdapter("Select * from Attendence1 where EmpID like 'D%'", conn);
                DataTable sd = new DataTable();
                dt.Fill(sd);
                empattdatagrid.DataSource = sd;
            }
            // all Cleaner get the grid view
            else if (cmbatt.Text == "Cleaner")
            {
                SqlDataAdapter dt = new SqlDataAdapter("Select * from Attendence1 where EmpID like 'C%'", conn);
                DataTable sd = new DataTable();
                dt.Fill(sd);
                empattdatagrid.DataSource = sd;
            }
            // all Reception get the grid view
            else if (cmbatt.Text == "Reception")
            {
                SqlDataAdapter dt = new SqlDataAdapter("Select * from Attendence1 where EmpID like 'Rc%'", conn);
                DataTable sd = new DataTable();
                dt.Fill(sd);
                empattdatagrid.DataSource = sd;
            }
            // all Head Chef get the grid view
            else if (cmbatt.Text == "Head Chef")
            {
                SqlDataAdapter dt = new SqlDataAdapter("Select * from Attendence1 where EmpID like 'hc%'", conn);
                DataTable sd = new DataTable();
                dt.Fill(sd);
                empattdatagrid.DataSource = sd;
            }
            // all Manager get the grid view
            else if (cmbatt.Text == "Manager")
            {
                SqlDataAdapter dt = new SqlDataAdapter("Select * from Attendence1 where EmpID like 'M%'", conn);
                DataTable sd = new DataTable();
                dt.Fill(sd);
                empattdatagrid.DataSource = sd;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //time
            lbldate.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }
        //search item
        private void searchbox(String valutosearch)
        {
            String query = "SELECT * FROM Attendence1 WHERE FirstName LIKE '%" + txtsearch.Text + "%'  OR LastName LIKE'%" + txtsearch.Text + "%' OR OutTime LIKE '%" + txtsearch.Text + "%' OR INtime  LIKE '%" + txtsearch.Text + "%' "; ;
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            empattdatagrid.DataSource = dt;
            conn.Close();
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //search button
            String valutosearch = txtsearch.Text.ToString();
            searchbox(valutosearch);
        }
    }

}
