using Sarasi_HMS.BLL;
using Sarasi_HMS.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sarasi_HMS.Acommodation
{
    public partial class AddGuest : Form
    {
        private OnlineUser onlineUser = OnlineUser.getInstance();

        private static AddGuest uniqueInstance = null;
        public AddGuest()
        {
            InitializeComponent();
        }

        public static AddGuest getInstance()
        {
            if (uniqueInstance == null)
            {
                uniqueInstance = new AddGuest();
            }
            return uniqueInstance;
        }

        Guest_bll g = new Guest_bll();
        Guest_dal dal = new Guest_dal();
        Room_bll u = new Room_bll();
        Room_dal Rdal = new Room_dal();
        public string roonum;

        public string get_GusetID;

        static string myconnstrng = ConfigurationManager.ConnectionStrings["DBEntities1"].ConnectionString;

        private string startLetter = "G";
        private int randomnumber;
        private static String key;
        Random random = new Random();


        private void GenarateAutoID_FOR_Guest()
        {
           


            randomnumber = random.Next(0, 10000);
            key = startLetter + randomnumber.ToString();
            TxtGuestID.Text = key;

        }


        private void clear()
        {
            TxtGuestID.Text = " ";
            txtRecepID.Text = " ";
            txtguesName.Text = " ";
            txtAddress.Text = " ";
            txtNic.Text = " ";
            combogrnder.Text = " ";
            txtmobile.Text = " ";
            txtCountry.Text = " ";
            txtpassport.Text = " ";
            txtRoom_no.Text = " ";



        }


        private void btnSaveGuest_Click_1(object sender, EventArgs e)
        {
            if (validateFormDetails())
            {

                Employee emp = new Employee();
                emp = onlineUser.getAvailableEmployee();
                //getting data from ui
                g.guest_id = TxtGuestID.Text;
                g.recepID = emp.employeeId;
                g.Name = txtguesName.Text;
                g.address_ = txtAddress.Text;
                g.NIC = txtNic.Text;
                g.Gender = combogrnder.Text;
                g.ContacNo = txtmobile.Text;
                g.Country = txtCountry.Text;
                g.PassportNo = txtpassport.Text;
                g.available = "1";
                g.Room_No = txtRoom_no.Text;

                //get room number (ID)
                roonum = txtRoom_no.Text;
                bool success = dal.InsertGuest(g);

                u.RoomNo = txtRoom_no.Text;

                u.available = "0";

                bool success1 = dal.RoomtableUpdate(u, roonum);



                if (success == true && success1 == true)
                {
                    MessageBox.Show("Guest successfully created");

                    clear();
                }
                else
                {
                    MessageBox.Show("Failed to add new guest");
                }

                // refreshing Data table
                DataTable dt = dal.Select();
                gridGuest.DataSource = dt;
                clear();
            }
        }
        public bool validateFormDetails()
        {
            bool flag = false;
            if (String.IsNullOrEmpty(TxtGuestID.Text.Trim()))
            {
                MessageBox.Show("please enter Guest Id ", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else if (String.IsNullOrEmpty(txtguesName.Text.Trim()))
            {
                MessageBox.Show("please enter Guest Name  ", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (String.IsNullOrEmpty(txtAddress.Text.Trim()))
            {
                MessageBox.Show("please enter Address   ", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (String.IsNullOrEmpty(txtNic.Text.Trim()))
            {
                MessageBox.Show("please enter Guest NIC  ", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (String.IsNullOrEmpty(combogrnder.Text.Trim()))
            {
                MessageBox.Show("please enter Gender   ", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (String.IsNullOrEmpty(txtmobile.Text.Trim()))
            {
                MessageBox.Show("please enter Guest mobile  ", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (String.IsNullOrEmpty(txtCountry.Text.Trim()))
            {
                MessageBox.Show("please enter Country  ", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (String.IsNullOrEmpty(txtpassport.Text.Trim()))
            {
                MessageBox.Show("please enter Guest passport ", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (String.IsNullOrEmpty(txtRoom_no.Text.Trim()))
            {
                MessageBox.Show("please enter  Room_no ", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void btnleaveGuest_Click(object sender, EventArgs e)
        {
            g.guest_id = TxtGuestID.Text;
            g.available = "0";

            u.RoomNo = txtRoom_no.Text;
            u.available = "1";

            bool success = dal.leaving(g);

            bool success1 = dal.RoomtableUpdate(u, roonum);
            if (success == true)
            {
                MessageBox.Show("Guest successfully leave");

                clear();
            }
            else
            {
                MessageBox.Show("Failed to leave");
            }

            // refreshing Data table
            DataTable dt = dal.Select();
            gridGuest.DataSource = dt;
        }

        private void btneditGuest_Click(object sender, EventArgs e)
        {

            Employee emp = new Employee();
            emp = onlineUser.getAvailableEmployee();

            g.guest_id = TxtGuestID.Text;
            g.recepID = emp.employeeId;
            g.Name = txtguesName.Text;
            g.address_ = txtAddress.Text;
            g.NIC = txtNic.Text;
            g.Gender = combogrnder.Text;
            g.ContacNo = txtmobile.Text;
            g.Country = txtCountry.Text;
            g.PassportNo = txtpassport.Text;
            g.Room_No = txtRoom_no.Text;

            bool success = dal.UpdateGuest(g);

            if (success == true)
            {
                MessageBox.Show(" successfully ");
            }
            else
            {
                MessageBox.Show("Failed to update guest ");
            }
            // refreshing Data table
            DataTable dt = dal.Select();
            gridGuest.DataSource = dt;

        }

        private void btndeleteguest_Click(object sender, EventArgs e)
        {
            // refreshing Data table
            // DataTable dt = dal.DeleteGuest();
            g.guest_id = TxtGuestID.Text;
            bool success = dal.DeleteGuest(g);
            // if data is updated successfully then the value of success will be true else it will false


            if (success == true)
            {

                MessageBox.Show("Guest deleted successfully");
                clear();

            }
            else
            {
                MessageBox.Show("Failed to delete Guest details");


            }

            // referesing datagrid view

            DataTable dt = dal.Select();
            gridGuest.DataSource = dt;
        }

        private void btn_getGuest_id_Click_1(object sender, EventArgs e)
        {
            GenarateAutoID_FOR_Guest();
        }

        private void AddGuest_Load(object sender, EventArgs e)
        {

            Employee emp = new Employee();
            emp = onlineUser.getAvailableEmployee();
            // refreshing Data table
            DataTable dt = dal.Select();
            gridGuest.DataSource = dt;
            setOnlineUserDetails();
            txtRecepID.Text = emp.employeeId;
        }

    

        private void gridGuest_RowHeaderMouseClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            // get index of row
            int rowIndex = e.RowIndex;
            TxtGuestID.Text = gridGuest.Rows[rowIndex].Cells[0].Value.ToString();
            txtRecepID.Text = gridGuest.Rows[rowIndex].Cells[1].Value.ToString();
            txtguesName.Text = gridGuest.Rows[rowIndex].Cells[2].Value.ToString();

            txtAddress.Text = gridGuest.Rows[rowIndex].Cells[3].Value.ToString();
            txtNic.Text = gridGuest.Rows[rowIndex].Cells[4].Value.ToString();
            combogrnder.Text = gridGuest.Rows[rowIndex].Cells[5].Value.ToString();
            txtmobile.Text = gridGuest.Rows[rowIndex].Cells[6].Value.ToString();
            txtCountry.Text = gridGuest.Rows[rowIndex].Cells[7].Value.ToString();
            txtpassport.Text = gridGuest.Rows[rowIndex].Cells[8].Value.ToString();
            txtRoom_no.Text = gridGuest.Rows[rowIndex].Cells[9].Value.ToString();
        }

        private void btnBack2tomange_Click(object sender, EventArgs e)
        {
            Guest_manage1 fm = Guest_manage1.getInstance();
            fm.Show();
            this.Hide();
           
        }

        public void setOnlineUserDetails()
        {
            Employee emp = new Employee();
            emp = onlineUser.getAvailableEmployee();
            picBoxUserImage.Image = Util.convertBinaryToImage(emp.image);
            llblUserName.Text = emp.fname + " " + emp.lname;
        }

        private void gridGuest_DoubleClick(object sender, EventArgs e)
        {
            {

                using (BillCalculate billc = new BillCalculate())
                {

                    int rowIndex = gridGuest.CurrentRow.Index;
                    billc.get_GusetID = gridGuest.Rows[rowIndex].Cells[0].Value.ToString();

                    billc.ShowDialog();
                    
                }
                this.Hide();
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = Login.getInstance();
            login.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            // get keyword from text box

            string keywords = textBox11.Text;
            // check if keywords has value or not

            if (keywords != null)
            {
                // show user batabase on keyword
                DataTable dt = dal.Search_guest(keywords);

                gridGuest.DataSource = dt;
            }
            else
            {
                // show all users from database
                DataTable dt = dal.Select();
                gridGuest.DataSource = dt;
            }
        }
    }
}
