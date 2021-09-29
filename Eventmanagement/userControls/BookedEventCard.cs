using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sarasi_HMS.Eventmanagement.userControls
{
    public partial class BookedEventCard : UserControl
    {
        public BookedEventCard()
        {
            InitializeComponent();
        }
        public string BookedID
        {
            get { return lblABCardID.Text; }
            set { lblABCardID.Text = value; }
        }
        public string EventTime
        {
            get { return lblABCardEvTime.Text; }
            set { lblABCardEvTime.Text = value; }
        }
        public string BookedDate
        {
            get { return lblABCardBookedDate.Text; }
            set { lblABCardBookedDate.Text = value; }
        }

        public string BookedTime
        {
            get { return lblABCardBookedTime.Text; }
            set { lblABCardBookedTime.Text = value; }
        }
        public string CusID
        {
            get { return lblABCardCusID.Text; }
            set { lblABCardCusID.Text = value; }
        }

        public string CusName
        {
            get { return lblABCardCusName.Text; }
            set { lblABCardCusName.Text = value; }
        }

        public string EventDate
        {
            get { return lblABCardEventDate.Text; }
            set { lblABCardEventDate.Text = value; }
        }


        public string EventName
        {
            get { return lblABCardEventName.Text; }
            set { lblABCardEventName.Text = value; }
        }

        public string Time
        {
            get { return lblABCardTime.Text; }
            set { lblABCardTime.Text = value; }
        }

        public string Hall
        {
            get { return lblABCardHall.Text; }
            set { lblABCardHall.Text = value; }
        }

        public string NoOfParti
        {
            get { return lblABCardNoOFParti.Text; }
            set { lblABCardNoOFParti.Text = value; }
        }

        public string ThemeColor
        {
            get { return lblABCardTheme.Text; }
            set { lblABCardTheme.Text = value; }
        }

        public string DTeam
        {
            get { return lblABCardDTeam.Text; }
            set { lblABCardDTeam.Text = value; }
        }

        public string FoodPack
        {
            get { return lblABCardFPackage.Text; }
            set { lblABCardFPackage.Text = value; }
        }
        public string Note
        {
            get { return lblABCardNote.Text; }
            set { lblABCardNote.Text = value; }
        }
        public string Advance
        {
            get { return lblABCardadvance.Text; }
            set { lblABCardadvance.Text = value; }
        }
        private void btnEABcardEdit_Click(object sender, EventArgs e)
        {
            //getting the card id 
            String eCardId = this.BookedID;
            AddNewEventBooking fm = AddNewEventBooking.getInstance();
            BookedEventViews evp = new BookedEventViews();
            evp.Close();
            fm.editEBookings(eCardId);
            fm.Show();
        }

        private void btnEABcarddelete_Click(object sender, EventArgs e)
        {
            String cardID = this.BookedID; //getting the cliked card id 

            BookedEventViews bev = new BookedEventViews();
            bev.deleteBookedEvent(cardID); //passing the Id 

            bev.clearBookedEventList();
            bev.DisplayBookedEvents();
            AddNewEventBooking ade = AddNewEventBooking.getInstance();
            this.Hide();
            ade.Show();
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            //getting the card id 
            String eCardId = this.BookedID;
            eventPayment fm = eventPayment.getInstance();
            BookedEventViews evp = new BookedEventViews();
            evp.Close();
            fm.calculat(eCardId);
            fm.Show();
        }
    }
}
