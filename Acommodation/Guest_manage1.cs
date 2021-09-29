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
    public partial class Guest_manage1 : Form
    {
        private static Guest_manage1 uniqueInstance = null;
        private OnlineUser onlineUser = OnlineUser.getInstance();
        public Guest_manage1()
        {
            InitializeComponent();
        }

        public static Guest_manage1 getInstance()
        {
            if (uniqueInstance == null)
            {
                uniqueInstance = new Guest_manage1();
            }
            return uniqueInstance;
        }

        private void btnavilableRoom_Click(object sender, EventArgs e)
        {
          
            AvailableRoomss avail = AvailableRoomss.getInstance();
            this.Hide();
            avail.Show();
        }

        private void btnBack2acom_Click(object sender, EventArgs e)
        {
            AdminPanelForm admin = AdminPanelForm.getInstance();
            this.Hide();
            admin.Show();
        }

        private void btnAddguests1_Click(object sender, EventArgs e)
        {
            AddGuest addggg = AddGuest.getInstance();
            this.Hide();
            addggg.Show();
        }

        private void btnCurrentGuest_Click(object sender, EventArgs e)
        {
            Currentguest addgegg = Currentguest.getInstance();
            this.Hide();
            addgegg.Show();
        }

        public void setOnlineUserDetails()
        {
            Employee emp = new Employee();
            emp = onlineUser.getAvailableEmployee();
            picBoxUserImage.Image = Util.convertBinaryToImage(emp.image);
            llblUserName.Text = emp.fname + " " + emp.lname;
        }

        private void Guest_manage1_Load(object sender, EventArgs e)
        {
            setOnlineUserDetails();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = Login.getInstance();
            login.Show();
        }

        private void btnClose7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAllGuest_Click(object sender, EventArgs e)
        {
            All_bills allbilss = All_bills.getInstance();
            this.Hide();
            allbilss.Show();
        }
    }
}
