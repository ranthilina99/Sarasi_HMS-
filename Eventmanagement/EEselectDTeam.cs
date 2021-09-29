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
    public partial class EEselectDTeam : Form
    {
        //unique instance 
        private static EEselectDTeam uniqueInstance = null;
        OnlineUser onlineUser = OnlineUser.getInstance();

        private List<DecorationTeam> decoTeamsList = new List<DecorationTeam>();
        private List<ButtonEDTeams> teamsButtonsList = new List<ButtonEDTeams>();
        private ButtonEDTeams DTbutton;

        DecorationTeam DTeam = new DecorationTeam();
        private static EDTeamShowSelectCard cardDTeam;
        public EEselectDTeam()
        {
            InitializeComponent();
            setDefaultValues();
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

        public static EEselectDTeam getInstance()
        {
            if (uniqueInstance == null)
            {
                uniqueInstance = new EEselectDTeam();
            }
            return uniqueInstance;
        }


        //Create a methods for load  all deco buttons 
        public void DisplayEventDecoTeams()
        {
            teamsButtonsList.Clear();
            using (DBEntities db = new DBEntities())
            {
                decoTeamsList = db.DecorationTeams.ToList(); //get details from sql and add to this list

                foreach (DecorationTeam dTeam in decoTeamsList) //eventPackage is one raw
                                                                //Iterarte raw by raw and insert to card list
                {
                    DTbutton = new ButtonEDTeams();
                    DTbutton.DTeamID = dTeam.dtID;
                    DTbutton.DTname = dTeam.dtName;
                    teamsButtonsList.Add(DTbutton);
                }


            }
            foreach (ButtonEDTeams card in teamsButtonsList)
            {
                flowLayoutSelectButtonsDTeams.Controls.Add(card);
            }
        }


        //Create a methods for load  all deco teams 
        public void DisplayEventDecoTeamsCard(String id)
        {

            flowLayoutShowSelectDTeam.Controls.Clear();

            using (DBEntities db = new DBEntities())
            {
                DTeam = db.DecorationTeams.Where(p => p.dtID == id).FirstOrDefault(); //get details from sql and add to this list
                cardDTeam = new EDTeamShowSelectCard();

                cardDTeam.DTeamID = DTeam.dtID;
                cardDTeam.DTName = DTeam.dtName;
                cardDTeam.NoOfMem = DTeam.NoOfMembers.ToString();
                cardDTeam.price = DTeam.price.ToString();
                cardDTeam.contactNo = DTeam.contactNo.ToString();
                cardDTeam.email = DTeam.email;

                cardDTeam.description = DTeam.description;
                cardDTeam.image1 = Eventmanagement.AddEventFoodPackage.convertBinaryToImage(DTeam.image1);
                cardDTeam.image2 = Eventmanagement.AddEventFoodPackage.convertBinaryToImage(DTeam.image2);


                flowLayoutShowSelectDTeam.Controls.Add(cardDTeam);

            }
        }

        private void EEselectDTeam_Load(object sender, EventArgs e)
        {
            DisplayEventDecoTeams();
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
