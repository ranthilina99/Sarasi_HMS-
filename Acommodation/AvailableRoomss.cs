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
    public partial class AvailableRoomss : Form
    {
        private static AvailableRoomss uniqueInstance = null;
        Room_dal dal = new Room_dal();

        private OnlineUser onlineUser = OnlineUser.getInstance();
        public AvailableRoomss()
        {
            InitializeComponent();
        }
        public static AvailableRoomss getInstance()
        {
            if (uniqueInstance == null)
            {
                uniqueInstance = new AvailableRoomss();
            }
            return uniqueInstance;
        }

        private void AvailableRoomss_Load(object sender, EventArgs e)
        {
            DataTable dt = dal.Select_avilable();

            greidAvilRoom.DataSource = dt;
            setOnlineUserDetails();
        }

        private void btnBack222acom_Click(object sender, EventArgs e)
        {
            Guest_manage1 fm = Guest_manage1.getInstance();
            this.Hide();
            fm.Show();
        }

        private void AvailableRoomss_Activated(object sender, EventArgs e)
        {
            DataTable dt = dal.Select_avilable();

            greidAvilRoom.DataSource = dt;
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
