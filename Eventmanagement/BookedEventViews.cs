using Sarasi_HMS.Eventmanagement.userControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sarasi_HMS.Eventmanagement
{
    public partial class BookedEventViews : Form
    {
        //create eventfoodpackages list for insert data from sql table.
        List<BookedEvent> BookedEventsList = new List<BookedEvent>();

        //create EFoodPackageCardList for insert cards to one list
        List<BookedEventCard> BookedEventCardList = new List<BookedEventCard>();

        //create reference (instance variable) to create new card reference
        private BookedEventCard bookedEventCard;

        private BookedEvent be2;
        public BookedEventViews()
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
        public void DisplayBookedEvents()
        {
            BookedEventCardList.Clear();
            using (DBEntities db = new DBEntities())
            {
                BookedEventsList = db.BookedEvents.ToList(); //get details from sql and add to this list

                foreach (BookedEvent bEvent in BookedEventsList) //booked event  is one raw
                                                                 //Iterarte raw by raw and insert to card list
                {
                    bookedEventCard = new BookedEventCard();
                    bookedEventCard.BookedID = bEvent.eventID;
                    bookedEventCard.BookedDate = bEvent.currentDate.ToString("dd/MM/yyyy");
                    bookedEventCard.BookedTime = bEvent.currentTime.ToString();

                    bookedEventCard.CusID = bEvent.customerID;
                    bookedEventCard.CusName = bEvent.customerName;

                    bookedEventCard.EventDate = bEvent.eventDate.ToString("dd/MM/yyyy");
                    bookedEventCard.EventTime = bEvent.eventTime.ToString();

                    bookedEventCard.EventName = bEvent.eventName;
                    bookedEventCard.Time = bEvent.time;

                    bookedEventCard.Hall = bEvent.hall;
                    bookedEventCard.NoOfParti = bEvent.noOfParticipants.ToString();

                    bookedEventCard.ThemeColor = bEvent.themeColor;
                    bookedEventCard.DTeam = bEvent.decoTeam;
                    bookedEventCard.FoodPack = bEvent.foodPckage;
                    bookedEventCard.Note = bEvent.note;
                    bookedEventCard.Advance = bEvent.advance.ToString();


                    /*  DateTime Received;
                      DateTime.TryParse(reader["ReceivedDate"].ToString(),
                                    CultureInfo.InvariantCulture, DateTimeStyles.None, out Received); */



                    BookedEventCardList.Add(bookedEventCard);
                }


            }
            foreach (BookedEventCard card in BookedEventCardList)
            {
                flowLayoutBookedEventView.Controls.Add(card);
            }
        }

        private void BookedEventViews_Load(object sender, EventArgs e)
        {
            DisplayBookedEvents();
        }
        public void clearBookedEventList()
        {
            flowLayoutBookedEventView.Controls.Clear();
        }


        public void deleteBookedEvent(String id)
        {
            if ((MessageBox.Show("Are you sure to Delete this record?", "Delete Booked Event", MessageBoxButtons.YesNo) == DialogResult.Yes))
            {

                using (DBEntities db = new DBEntities())
                {
                    be2 = db.BookedEvents.Where(x => x.eventID == id).FirstOrDefault();
                    MessageBox.Show(be2.eventID);

                    db.BookedEvents.Remove(be2);
                    try
                    {
                        db.SaveChanges();
                    }
                    catch (DbEntityValidationException ex)
                    {
                        foreach (var entityValidationErrors in ex.EntityValidationErrors)
                        {
                            foreach (var validationError in entityValidationErrors.ValidationErrors)
                            {
                                MessageBox.Show("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                            }
                        }
                    }


                }
                MessageBox.Show("Booked Events Removed Successfully!!!");


            }
            //refreshing......
            clearBookedEventList();
            DisplayBookedEvents();
        }// end of deleteCategory

        private void btnEventBack_Click(object sender, EventArgs e)
        {
            AddNewEventBooking bv =  AddNewEventBooking.getInstance();
            this.Hide();
            bv.Show();
        }

        private void btnETSadd_Click(object sender, EventArgs e)
        {
            AddNewEventBooking bv = AddNewEventBooking.getInstance();
            this.Hide();
            bv.Show();
        }
    }
}
