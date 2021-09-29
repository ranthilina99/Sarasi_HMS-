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
    public partial class EselectFPackage : Form
    {
        OnlineUser onlineUser = OnlineUser.getInstance();
        //unique instance 
        private static EselectFPackage uniqueInstance = null;

        private List<EventPackage> eventPackagesList = new List<EventPackage>();
        private List<ButtonEFPackages_Click> packageButtonsList = new List<ButtonEFPackages_Click>();
        private List<EFPackageShoeSelectCard> packageCardList = new List<EFPackageShoeSelectCard>();
        private ButtonEFPackages_Click pbutton;

        EventPackage package = new EventPackage();
        private static EFPackageShoeSelectCard cardPAckage;
        public EselectFPackage()
        {
            InitializeComponent();
            setDefaultValues();
        }
        public static EselectFPackage getInstance()
        {
            if (uniqueInstance == null)
            {
                uniqueInstance = new EselectFPackage();
            }
            return uniqueInstance;
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

        //Create a methods for load  all package buttons 
        public void DisplayEventFoodPackagesButtons()
        {
            packageButtonsList.Clear();
            using (DBEntities db = new DBEntities())
            {
                eventPackagesList = db.EventPackages.ToList(); //get details from sql and add to this list

                foreach (EventPackage ePackage in eventPackagesList) //eventPackage is one raw
                                                                     //Iterarte raw by raw and insert to card list
                {
                    pbutton = new ButtonEFPackages_Click();
                    pbutton.packageID = ePackage.packageID;
                    pbutton.packageName = ePackage.Name;
                    packageButtonsList.Add(pbutton);
                }


            }
            foreach (ButtonEFPackages_Click card in packageButtonsList)
            {
                flowLayoutSelectButtonsPackages.Controls.Add(card);
            }
        }
        //Create a methods for load  all packages
        public void DisplayEventFoodPackageCard(String id)
        {
            flowLayoutShowSelectPackage.Controls.Clear();

            using (DBEntities db = new DBEntities())
            {
                package = db.EventPackages.Where(p => p.packageID == id).FirstOrDefault(); //get details from sql and add to this list
                cardPAckage = new EFPackageShoeSelectCard();

                cardPAckage.packageID = package.packageID;
                cardPAckage.packageName = package.Name;
                cardPAckage.pricePerPlate = package.plate_price.ToString();
                cardPAckage.noOfCurries = package.noOfCurries.ToString();
                cardPAckage.description = package.description;
                cardPAckage.mainMeal = AddEventFoodPackage.convertBinaryToImage(package.mainMeal);
                cardPAckage.desert = AddEventFoodPackage.convertBinaryToImage(package.desert);

                flowLayoutShowSelectPackage.Controls.Add(cardPAckage);


            }


        }

        private void EselectFPackage_Load(object sender, EventArgs e)
        {
            DisplayEventFoodPackagesButtons();
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
    }
}
