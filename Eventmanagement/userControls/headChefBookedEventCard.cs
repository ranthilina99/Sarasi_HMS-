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
    public partial class headChefBookedEventCard : UserControl
    {
        public headChefBookedEventCard()
        {
            InitializeComponent();
        }
        public void btnHidden()
        {
            btnEAddOrderList.Visible = false;
        }

        public string BookedID
        {
            get { return lblABCardIDh.Text; }
            set { lblABCardIDh.Text = value; }
        }
        public string EventTime
        {
            get { return lblABCardEvTimeh.Text; }
            set { lblABCardEvTimeh.Text = value; }
        }
        public string BookedDate
        {
            get { return lblABCardBookedDateh.Text; }
            set { lblABCardBookedDateh.Text = value; }
        }

        public string BookedTime
        {
            get { return lblABCardBookedTimeh.Text; }
            set { lblABCardBookedTimeh.Text = value; }
        }


        public string EventDate
        {
            get { return lblABCardEventDateh.Text; }
            set { lblABCardEventDateh.Text = value; }
        }


        public string EventName
        {
            get { return lblABCardEventNameh.Text; }
            set { lblABCardEventNameh.Text = value; }
        }


        public string Hall
        {
            get { return lblABCardHallh.Text; }
            set { lblABCardHallh.Text = value; }
        }

        public string NoOfParti
        {
            get { return lblABCardNoOFPartih.Text; }
            set { lblABCardNoOFPartih.Text = value; }
        }





        public string FoodPack
        {
            get { return lblABCardFPackageh.Text; }
            set { lblABCardFPackageh.Text = value; }
        }

        public string Done
        {
            get { return done.Text; }
            set { done.Text = value; }
        }

        private void btnEAddOrderList_Click(object sender, EventArgs e)
        {
            
            //getting the card id 
            String eCardId = this.BookedID;
            hChefAddOrderList ob = new  hChefAddOrderList();
            headChefBookedEventViews evp = new headChefBookedEventViews();
            evp.Close();
            ob.viewDetails(eCardId);
            ob.Show();
        }
    }
}
