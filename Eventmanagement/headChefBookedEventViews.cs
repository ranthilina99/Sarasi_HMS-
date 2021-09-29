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
    public partial class headChefBookedEventViews : Form
    {
        //SqlConnection conn = new SqlConnection("Data Source=DESKTOP-J1R0F1R;Initial Catalog=NewSarasi;Integrated Security=True");
        //create eventfoodpackages list for insert data from sql table.
        List<BookedEvent> BookedEventsListH = new List<BookedEvent>();
        List<expOrder> expOrderList = new List<expOrder>();
        //create EFoodPackageCardList for insert cards to one list
        List<headChefBookedEventCard> BookedEventCardListH = new List<headChefBookedEventCard>();

        //create reference (instance variable) to create new card reference
        private headChefBookedEventCard chefBookedEventCard;

        private BookedEvent bEvent;
        private expOrder exp2;


        //headChefBookedEventCard hf = new headChefBookedEventCard();
        public headChefBookedEventViews()
        {
            InitializeComponent();
            setDefaultValues();
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
        //Create a methods for show all cards
        public void DisplayBookedEventsH()
        {
            BookedEventCardListH.Clear();
            using (DBEntities db = new DBEntities())
            {
                BookedEventsListH = db.BookedEvents.ToList(); //get details from sql and add to this list

                foreach (BookedEvent bEvent in BookedEventsListH) //booked event  is one raw
                                                                  //Iterarte raw by raw and insert to card list
                {
                    //searchID(bEvent.eventID);
                    chefBookedEventCard = new headChefBookedEventCard();
                    chefBookedEventCard.BookedID = bEvent.eventID;
                    chefBookedEventCard.BookedDate = bEvent.currentDate.ToString("dd/MM/yyyy");
                    chefBookedEventCard.BookedTime = bEvent.currentTime.ToString();



                    chefBookedEventCard.EventDate = bEvent.eventDate.ToString("dd/MM/yyyy");
                    chefBookedEventCard.EventTime = bEvent.eventTime.ToString();

                    chefBookedEventCard.EventName = bEvent.eventName;


                    chefBookedEventCard.Hall = bEvent.hall;
                    chefBookedEventCard.NoOfParti = bEvent.noOfParticipants.ToString();



                    chefBookedEventCard.FoodPack = bEvent.foodPckage;

                    /*exp2 = db.expOrders.Where(x => x.eventID == bEvent.eventID).FirstOrDefault();
                   if (exp2.eventID == bEvent.eventID)
                      {
                         chefBookedEventCard.btnHidden();

                      }
                      else
                      {

                      }  */

                    BookedEventCardListH.Add(chefBookedEventCard);
                }


            }
            foreach (headChefBookedEventCard card in BookedEventCardListH)
            {
                flowLayoutHeadchefBookingsView.Controls.Add(card);
            }
        }

        private void headChefBookedEventViews_Load(object sender, EventArgs e)
        {
            DisplayBookedEventsH();
        }

        private void btnMEventBack_Click(object sender, EventArgs e)
        {
            KitchenPOS emd =  KitchenPOS.getInstance();
            this.Hide();
            emd.Show();
        }
    }
}
