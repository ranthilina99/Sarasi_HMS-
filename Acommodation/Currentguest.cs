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
    public partial class Currentguest : Form
    {

        private static Currentguest uniqueInstance = null;

        private OnlineUser onlineUser = OnlineUser.getInstance();
        public Currentguest()
        {
            InitializeComponent();
        }

        public static Currentguest getInstance()
        {
            if (uniqueInstance == null)
            {
                uniqueInstance = new Currentguest();
            }
            return uniqueInstance;
        }

        Guest_dal dal = new Guest_dal();
        private void Currentguest_Load(object sender, EventArgs e)
        {
            DataTable dt = dal.Select_Current_guest();

            GridCurrentGues.DataSource = dt;
            setOnlineUserDetails();
        }

        private void btnBackacom213_Click(object sender, EventArgs e)
        {
            Guest_manage1 currentG = Guest_manage1.getInstance();
            this.Hide();
            currentG.Show();
        }

        private void Currentguest_Activated(object sender, EventArgs e)
        {
            DataTable dt = dal.Select_Current_guest();

            GridCurrentGues.DataSource = dt;
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
    }
}
