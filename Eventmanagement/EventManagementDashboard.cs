using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sarasi_HMS.Eventmanagement
{
    public partial class EventManagementDashboard : Form
    {
        OnlineUser onlineUser = OnlineUser.getInstance();
        public EventManagementDashboard()
        {
            InitializeComponent();
            setDefaultValues(); //setting up the default aspects 
        }
        private void setDefaultValues()
        {
            DateTime time = DateTime.Now.ToLocalTime();
            lblDateTime.Text = time.ToString();
        }
        public void setOnlineUserDetails()
        {
            Employee emp = new Employee();
            emp = onlineUser.getAvailableEmployee();
            picBoxUserImage.Image = Util.convertBinaryToImage(emp.image);
            llblUserName.Text = emp.fname + " " + emp.lname;
        }

        private void btnFoodPackageE_Click(object sender, EventArgs e)
        {
            AddEventFoodPackage addEventFoodPackage = new AddEventFoodPackage();
            this.Hide();
            addEventFoodPackage.Show();
        }

        private void btntempororyStaff_Click(object sender, EventArgs e)
        {
            AddTemporyStaff addTempStaff = new AddTemporyStaff();
            addTempStaff.Show();
            this.Hide();
        }

        private void btnDecorationTeams_Click(object sender, EventArgs e)
        {
            AddEventDecorationTeam addEventDecorationTeam = new AddEventDecorationTeam();
            addEventDecorationTeam.Show();
            this.Hide();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void logoutbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = Login.getInstance();
            login.Show();
        }

        private void EventManagementDashboard_Load(object sender, EventArgs e)
        {
            setOnlineUserDetails();
        }

        private void btnEventBack_Click(object sender, EventArgs e)
        {
            AdminPanelForm admin = AdminPanelForm.getInstance();
            admin.Show();
            this.Hide();
        }

        private void btnBookedEvent_Click(object sender, EventArgs e)
        {
            ManagerBookedEventViews managerB = new ManagerBookedEventViews();
            managerB.Show();
            this.Hide();
        }
    }
}
