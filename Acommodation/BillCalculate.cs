using Sarasi_HMS.BLL;
using Sarasi_HMS.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sarasi_HMS.Acommodation
{
    public partial class BillCalculate : Form
    {
        private static BillCalculate uniqueInstance = null;
        public string get_GusetID;

        private int num_of_days;
        private int num_of_room;
        private float discount;
        private float Tax;
        private float total1;
        private float Discount_avl;
        private float Final_total1;


        private string startLetter = "BI";
        private int randomnumber;
        private static String key;
        Random random = new Random();
        public BillCalculate()
        {
            InitializeComponent();
        }

        public static BillCalculate getInstance()
        {
            if (uniqueInstance == null)
            {
                uniqueInstance = new BillCalculate();
            }
            return uniqueInstance;
        }
        BillP_bll bill = new BillP_bll();
        BillP_dal dal = new BillP_dal();
        private OnlineUser onlineUser = OnlineUser.getInstance();

        private void BillCalculate_Load(object sender, EventArgs e)
        {
            Employee emp = new Employee();
            emp = onlineUser.getAvailableEmployee();
            txtRecep_id_bill.Text = emp.employeeId;
            // txt_GusetID.
            txt_GusetID_bill.Text = get_GusetID;
            setCleanerIDComboBox();

            // refreshing Data table
            DataTable dt = dal.SelectBill();
            gridbill.DataSource = dt;
            setOnlineUserDetails();
        }

        private void setCleanerIDComboBox()
        {

            comboCleanerIDS.DataSource = getCleanersID();
            comboCleanerIDS.DisplayMember = "cleanerid";
        }

        private List<Cleaner> getCleanersID()
        {   //creating new List 
            List<Cleaner> CleanerIDlist = new List<Cleaner>();

            using (DBEntities db = new DBEntities())
            {
                CleanerIDlist = db.Cleaners.ToList();

            }
            return CleanerIDlist;
        }

        private void btn_getGuest_id_Click(object sender, EventArgs e)
        {
            GenarateAutoID_FOR_Bill();
        }

        private void GenarateAutoID_FOR_Bill()
        {
          


            randomnumber = random.Next(0, 10000);
            key = startLetter + randomnumber.ToString();
            txt_resvation_Bill_id.Text = key;

        }

        private void total_calculate()
        {
            if (validateFormDetails())
            {
                num_of_days = Int32.Parse(txt_stayed.Text);
                num_of_room = Int32.Parse(txtNum_room_bill.Text);
                discount = float.Parse(txtDiscount.Text);
                Tax = float.Parse(txtTax_tot.Text);

                if (comboRoom_type_bill.Text == "A/C")
                {
                    total1 = (3000 + Tax) * num_of_days * num_of_room;
                    Discount_avl = total1 * discount / 100;
                    Final_total1 = total1 - Discount_avl;
                    txt_total.Text = Final_total1.ToString();
                }
                else if (comboRoom_type_bill.Text == "normal")
                {
                    total1 = (2000 + Tax) * num_of_days * num_of_room;
                    Discount_avl = total1 * discount / 100;
                    Final_total1 = total1 - Discount_avl;
                    txt_total.Text = Final_total1.ToString();
                }
            }

        }

        private void btn_cal_bill_Click(object sender, EventArgs e)
        {
            total_calculate();
        }

        private void btnSaveBill_Click(object sender, EventArgs e)
        {

            Employee emp = new Employee();
            emp = onlineUser.getAvailableEmployee();
            //getting data from ui
            bill.ResID = txt_resvation_Bill_id.Text;
            bill.Guestid = txt_GusetID_bill.Text;
            bill.CleanerID = comboCleanerIDS.Text;
            bill.ReceptID = txtRecep_id_bill.Text;
            
            bill.CheckIn = dateTimePicker_bill_in.Value;
            bill.CheckOut = dateTimePicker_bill_out.Value;
            bill.numOfday = txt_stayed.Text;
            bill.Room_type = comboRoom_type_bill.Text;
            bill.numOfRooms = txtNum_room_bill.Text;
            bill.Discount = txtDiscount.Text;
            bill.Tax = txtTax_tot.Text;
            bill.total = txt_total.Text;


            bool success = dal.InsertBillPayment(bill);

            if (success == true)
            {
                MessageBox.Show("Guest successfully created");

                clear();
            }
            else
            {
                MessageBox.Show("Failed to add new guest");
            }

            // refreshing Data table
            DataTable dt = dal.SelectBill();
            gridbill.DataSource = dt;
        }

        private void clear()
        {
            txt_resvation_Bill_id.Text = " ";
            txt_GusetID_bill.Text = " ";
            comboCleanerIDS.Text = " ";
            txtRecep_id_bill.Text = " ";
        
            txt_stayed.Text = " ";
            comboRoom_type_bill.Text = " ";
            txtNum_room_bill.Text = " ";
            txtDiscount.Text = " ";
            txtTax_tot.Text = " ";
            txt_total.Text = " ";



        }
        public bool validateFormDetails()
        {
            bool flag = false;
            if (String.IsNullOrEmpty(txt_resvation_Bill_id.Text.Trim()))
            {
                MessageBox.Show("please enter resvation Id ", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else if (String.IsNullOrEmpty(comboCleanerIDS.Text.Trim()))
            {
                MessageBox.Show("please enter CleanerID  ", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (String.IsNullOrEmpty(txtRecep_id_bill.Text.Trim()))
            {
                MessageBox.Show("please enter Recep_id   ", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (String.IsNullOrEmpty(txt_stayed.Text.Trim()))
            {
                MessageBox.Show("please enter stay  ", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (String.IsNullOrEmpty(comboRoom_type_bill.Text.Trim()))
            {
                MessageBox.Show("please enter Room_type   ", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (String.IsNullOrEmpty(txtDiscount.Text.Trim()))
            {
                MessageBox.Show("please enter Discount  ", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (String.IsNullOrEmpty(txtTax_tot.Text.Trim()))
            {
                MessageBox.Show("please enter Tax   ", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (String.IsNullOrEmpty(txtNum_room_bill.Text.Trim()))
            {
                MessageBox.Show("please enter No Of Rooms ", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        public void setOnlineUserDetails()
        {
            Employee emp = new Employee();
            emp = onlineUser.getAvailableEmployee();
            picBoxUserImage.Image = Util.convertBinaryToImage(emp.image);
            llblUserName.Text = emp.fname + " " + emp.lname;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = Login.getInstance();
            login.Show();
        }

        private void btnClose4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBack2tomange_Click(object sender, EventArgs e)
        {
            Guest_manage1 Addg = Guest_manage1.getInstance();
            this.Hide();
            Addg.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            accomadationreport acc = new accomadationreport();
            acc.Show();
            this.Hide();
        }
    }
}
