using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sarasi_HMS.Eventmanagement
{
    public partial class AddNewEventBooking : Form
    {
        OnlineUser onlineUser = OnlineUser.getInstance();
        private static AddNewEventBooking uniqueInstance = null;
        DecorationTeam mod1 = new DecorationTeam();
        EventPackage mod2 = new EventPackage();
        BookedEvent AB1 = new BookedEvent();
        private static String status = "insert";
        public AddNewEventBooking()
        {
            InitializeComponent();
            setDefaultValues(); //setting up the default aspects 
        }
        public static AddNewEventBooking getInstance()
        {
            if (uniqueInstance == null)
            {
                uniqueInstance = new AddNewEventBooking();
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
        private void setDefaultValues()
        {
            DateTime time = DateTime.Now.ToLocalTime();
            lblDateTime.Text = time.ToString();
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

        private void AddNewEventBooking_Load(object sender, EventArgs e)
        {
            setOnlineUserDetails();
        }

        private void btnEABselect1_Click(object sender, EventArgs e)
        {
            EEselectDTeam es = EEselectDTeam.getInstance();
            this.Hide();
            es.Show();
        }

        private void btnEABselect2_Click(object sender, EventArgs e)
        {
            EselectFPackage em = EselectFPackage.getInstance();
            this.Hide();
            em.Show();
        }
        void Clear()
        {
            txtEABEventID.Text = txtEABcustID.Text = txtEABcustName.Text = txtEABeventname.Text = combEABhall.Text = txtEABnoofparti.Text = combEABTime.Text = combEABtheme.Text = txtEABDteam.Text = txtEABFpackage.Text = richTxtEABnote.Rtf = txtEABeventtime.Text =txtEABadvance.Text= "";
            btnEABsave.Text = "Save";



        }

        public void SetSelectedDTID(String id)
        {
            using (DBEntities db = new DBEntities())
            {
                mod1 = db.DecorationTeams.Where(x => x.dtID == id).FirstOrDefault();
                MessageBox.Show(mod1.dtID);
                //set values to the textboxess
                this.txtEABDteam.Text = mod1.dtID;

                /* EDTeamShowSelectCard esc = new EDTeamShowSelectCard();
                 txtEABDteam.Text = esc.DTeamID;*/
            }

        }

        public void SetSelectedFPID(String id)
        {
            using (DBEntities db = new DBEntities())
            {
                mod2 = db.EventPackages.Where(x => x.packageID == id).FirstOrDefault();
                MessageBox.Show(mod2.packageID);
                //set values to the textboxess
                this.txtEABFpackage.Text = mod2.packageID;
                /* EDTeamShowSelectCard esc = new EDTeamShowSelectCard();
                 txtEABDteam.Text = esc.DTeamID;*/
            }

        }

        private void btnABgenarate_Click(object sender, EventArgs e)
        {
            String result = Util.generateKey("BookedEvent");
            MessageBox.Show(result);
            txtEABEventID.Text = result;
        }
        public void editEBookings(String id)
        {

            //retreiving selected raw
            using (DBEntities db = new DBEntities())
            {
                //setting status to update 
                status = "update";
                btnEABsave.Text = "Update";

                AB1 = db.BookedEvents.Where(x => x.eventID == id).FirstOrDefault();
                MessageBox.Show(AB1.eventID);

                btnABgenarate.Visible = false;

                //set values to the textboxess
                this.txtEABEventID.Text = AB1.eventID;
                txtEABcustID.Text = AB1.customerID;
                txtEABcustName.Text = AB1.customerName;
                dateTEAB2.Value = AB1.eventDate.Date;
                txtEABeventtime.Text = AB1.eventTime.ToString();
                txtEABeventname.Text = AB1.eventName;
                combEABhall.SelectedItem = AB1.hall;
                txtEABnoofparti.Text = AB1.noOfParticipants.ToString();
                combEABTime.SelectedItem = AB1.time;
                combEABtheme.SelectedItem = AB1.themeColor;
                txtEABDteam.Text = AB1.decoTeam;
                txtEABFpackage.Text = AB1.foodPckage;
                richTxtEABnote.Text = AB1.note;
                txtEABadvance.Text = AB1.advance.ToString();

            }
        }

        private void btnEABsave_Click(object sender, EventArgs e)
        {
            AB1.eventID = txtEABEventID.Text.Trim();
            AB1.customerID = txtEABcustID.Text.Trim();
            AB1.customerName = txtEABcustName.Text.Trim();
            AB1.eventDate = dateTEAB2.Value;
            AB1.eventName = txtEABeventname.Text.Trim();
            AB1.hall = combEABhall.Text.Trim();
            AB1.noOfParticipants = Int16.Parse(txtEABnoofparti.Text);
            AB1.time = combEABTime.Text.Trim();
            AB1.themeColor = combEABtheme.Text;
            AB1.decoTeam = txtEABDteam.Text.Trim();
            AB1.foodPckage = txtEABFpackage.Text.Trim();
            AB1.note = richTxtEABnote.Text;
            AB1.advance = float.Parse(txtEABadvance.Text);

            AB1.currentDate = DateTime.Today;
            AB1.currentTime = DateTime.Now.TimeOfDay;
            // AB1.eventTime = Convert.ToDateTime(txtEABeventtime.Text);
            //  DateTime.Parse(dateTimeStr);
            //  DateTime time = DateTime.Parse(txtEABeventtime.Text);
            //AB1.eventTime = (DateTime.TimeOfDay)txtEABeventtime;
            //DateTime dateTime = DateTime.ParseExact(txtEABeventtime.Text, "HH:mm:ss",
            // CultureInfo.InvariantCulture);


            AB1.eventTime = TimeSpan.Parse(txtEABeventtime.Text);


            using (DBEntities db = new DBEntities())
            {
                if (status == "insert")
                {
                    db.BookedEvents.Add(AB1);

                    MessageBox.Show("Successfully saved");
                }
                else if (status == "update")
                {
                    //updating the database 
                    db.Entry(AB1).State = EntityState.Modified;

                    MessageBox.Show("Bookings Updated Successfully");
                }
                db.SaveChanges();
            }
            Clear();
        }

        private void btnEABreset_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnViewBookings_Click(object sender, EventArgs e)
        {
            BookedEventViews bv = new BookedEventViews();
            this.Hide();
            bv.Show();
        }

        private void btnEventBack_Click(object sender, EventArgs e)
        {
            RestaurantPOS emd =  RestaurantPOS.getInstance();
            this.Hide();
            emd.Show();
        }
    }
}
