using Sarasi_HMS.Eventmanagement.selectthings;
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
    public partial class managerSelectStaffFromList : Form
    {
        OnlineUser onlineUser = OnlineUser.getInstance();
        private static managerSelectStaffFromList uniqueInstance = null;
        public static List<Panel> managerSelectStaffFromListPanels = new List<Panel>();
        public static List<Panel> StaffPOSPanels = new List<Panel>();
        private static List<POStempStaffCard> tempStaffcardList = new List<POStempStaffCard>();
        private static List<TempStaff> staffList = new List<TempStaff>();
        private POStempStaffCard tempStaffcard;

        private static List<SelectedStaffRaw> selectedStaffList = new List<SelectedStaffRaw>();
        private static SelectedStaffRaw selectedStaffRaw;

        //private selectedStaff selectedStaff1; //to record the selectStaff
        private managerSelectStaffFromList()
        {
            InitializeComponent();
            initialAdd();
        }
        private void setDefaultValues()
        {
            DateTime time = DateTime.Now.ToLocalTime();
            lblDateTime.Text = time.ToString();
        }
        public static managerSelectStaffFromList getInstance()
        {
            if (uniqueInstance == null)
            {
                uniqueInstance = new managerSelectStaffFromList();
            }
            return uniqueInstance;
        }
        public void setOnlineUserDetails()
        {
            Employee emp = new Employee();
            emp = onlineUser.getAvailableEmployee();
            picBoxUserImage.Image = Util.convertBinaryToImage(emp.image);
            llblUserName.Text = emp.fname + " " + emp.lname;
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
        public void filterStaffs()
        {
            //clear the card list 
            tempStaffcardList.Clear();
            flowTempStaff.Controls.Clear();

            using (DBEntities db = new DBEntities())
            {
                staffList = db.TempStaffs.ToList(); ;

                foreach (TempStaff TempStaff in staffList)
                {
                    //creating new card 
                    tempStaffcard = new POStempStaffCard();
                    tempStaffcard.TSIDp = TempStaff.staffID;
                    tempStaffcard.TSfNamep = TempStaff.fName;
                    tempStaffcard.TSlNamep = TempStaff.lName;
                    tempStaffcard.Typep = TempStaff.type;
                    tempStaffcard.DailySalp = TempStaff.dailySal.ToString();


                    //adding card to the list
                    tempStaffcardList.Add(tempStaffcard);

                }

            }


            //adding cards to the flow panel
            foreach (POStempStaffCard card in tempStaffcardList)
            {
                flowTempStaff.Controls.Add(card);
            }

        }// 

        private void managerSelectStaffFromList_Load(object sender, EventArgs e)
        {
            filterStaffs();
            setOnlineUserDetails();
        }
        //method to select staff row 
        public void addToSelectedStaff(String id, String fname, String lname, String type, String dailySal)
        {

            selectedStaffRaw = new SelectedStaffRaw();
            selectedStaffRaw.TSIDs = id;
            selectedStaffRaw.TSfNames = fname;
            selectedStaffRaw.TSlNames = lname;

            selectedStaffRaw.Types = type;
            selectedStaffRaw.DailySals = dailySal;
            selectedStaffList.Add(selectedStaffRaw);
            loadselectStafflist();

        }

        public void loadselectStafflist()
        {
            flowSelectStaff.Controls.Clear(); //clearing the panel 

            foreach (SelectedStaffRaw row in selectedStaffList)
            {
                flowSelectStaff.Controls.Add(row);
            }

        }
        public void initialAdd()
        {
            //adding Pannels

            StaffPOSPanels.Add(flowTempStaff);
            StaffPOSPanels.Add(panelMainKitchenPOS);
            StaffPOSPanels.Add(flowSelectStaff);
            StaffPOSPanels.Add(panelBottomKitchenPOS);

        }

        private void btnEventBack_Click(object sender, EventArgs e)
        {
            ManagerBookedEventViews emd = new ManagerBookedEventViews();
            this.Hide();
            emd.Show();
        }
        public void removeraw(String id)
        {
            int index = selectedStaffList.FindIndex(x => x.TSIDs == id);
            if (index < 0)
            {
                MessageBox.Show("Error in getting the index of the list item");
            }
            else
            {
                selectedStaffList.RemoveAt(index);
                loadselectStafflist();
            }
        }
    }
}
