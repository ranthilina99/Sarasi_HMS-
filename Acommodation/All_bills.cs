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
    public partial class All_bills : Form
    {
        private static All_bills uniqueInstance = null;
        private OnlineUser onlineUser = OnlineUser.getInstance();
        public All_bills()
        {
            InitializeComponent();
        }

        public static All_bills getInstance()
        {
            if (uniqueInstance == null)
            {
                uniqueInstance = new All_bills();
            }
            return uniqueInstance;
        }

        BillP_dal dal = new BillP_dal();

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void All_bills_Load(object sender, EventArgs e)
        {
            DataTable dt = dal.SelectBill();

            GridAllbils.DataSource = dt;
            setOnlineUserDetails();
        }
        public void setOnlineUserDetails()
        {
            Employee emp = new Employee();
            emp = onlineUser.getAvailableEmployee();
            picBoxUserImage.Image = Util.convertBinaryToImage(emp.image);
            llblUserName.Text = emp.fname + " " + emp.lname;
        }

        private void All_bills_Activated(object sender, EventArgs e)
        {
            DataTable dt = dal.SelectBill();

            GridAllbils.DataSource = dt;
            setOnlineUserDetails();
        }

        private void btnBackacom55_Click(object sender, EventArgs e)
        {
            Guest_manage1 currentG = Guest_manage1.getInstance();
            this.Hide();
            currentG.Show();
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
    }
}
