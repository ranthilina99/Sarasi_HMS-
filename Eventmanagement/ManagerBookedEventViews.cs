using Sarasi_HMS.Eventmanagement.userControls;
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
    public partial class ManagerBookedEventViews : Form
    {
        //create eventfoodpackages list for insert data from sql table.
        List<BookedEvent> BookedEventsListM = new List<BookedEvent>();

        //create EFoodPackageCardList for insert cards to one list
        List<ManagerBookedEventCard> BookedEventCardListM = new List<ManagerBookedEventCard>();

        //create reference (instance variable) to create new card reference
        private ManagerBookedEventCard managerBookedEventCard;

        private BookedEvent bem2;
        public ManagerBookedEventViews()
        {
            InitializeComponent();
            setDefaultValues(); //setting up the default aspects 
        }
        private void setDefaultValues()
        {
            DateTime time = DateTime.Now.ToLocalTime();
            lblDateTime.Text = time.ToString();
        }
        //Create a methods for show all cards
        public void DisplayBookedEventsM()
        {
            BookedEventCardListM.Clear();
            
            using (DBEntities db = new DBEntities())
            {
                BookedEventsListM = db.BookedEvents.ToList(); //get details from sql and add to this list

                foreach (BookedEvent bEvent in BookedEventsListM) //booked event  is one raw
                                                                  //Iterarte raw by raw and insert to card list
                {
                    managerBookedEventCard = new ManagerBookedEventCard();
                    managerBookedEventCard.BookedID = bEvent.eventID;
                    managerBookedEventCard.BookedDate = bEvent.currentDate.ToString("dd/MM/yyyy");
                    managerBookedEventCard.BookedTime = bEvent.currentTime.ToString();



                    managerBookedEventCard.EventDate = bEvent.eventDate.ToString("dd/MM/yyyy");
                    managerBookedEventCard.EventTime = bEvent.eventTime.ToString();

                    managerBookedEventCard.EventName = bEvent.eventName;


                    managerBookedEventCard.Hall = bEvent.hall;
                    managerBookedEventCard.NoOfParti = bEvent.noOfParticipants.ToString();


                    managerBookedEventCard.FoodPack = bEvent.foodPckage;


                    BookedEventCardListM.Add(managerBookedEventCard);
                }


            }
            foreach (ManagerBookedEventCard card in BookedEventCardListM)
            {
                flowLayoutManagerBookingsView.Controls.Add(card);
            }
        }

        public void clearBookedEventList()
        {
            flowLayoutManagerBookingsView.Controls.Clear();
        }

        private void ManagerBookedEventViews_Load(object sender, EventArgs e)
        {
            DisplayBookedEventsM();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMEventBack_Click(object sender, EventArgs e)
        {
            EventManagementDashboard emd = new EventManagementDashboard();
            this.Hide();
            emd.Show();
        }

        private void btnMEBShowMore_Click(object sender, EventArgs e)
        {
            BookedEventViews emd = new BookedEventViews();
            this.Hide();
            emd.Show();
        }
    }
}
