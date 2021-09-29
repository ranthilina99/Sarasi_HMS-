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
    public partial class ManagerBookedEventCard : UserControl
    {
        public ManagerBookedEventCard()
        {
            InitializeComponent();
        }
        public string BookedID
        {
            get { return lblABCardIDm.Text; }
            set { lblABCardIDm.Text = value; }
        }
        public string EventTime
        {
            get { return lblABCardEvTimem.Text; }
            set { lblABCardEvTimem.Text = value; }
        }
        public string BookedDate
        {
            get { return lblABCardBookedDatem.Text; }
            set { lblABCardBookedDatem.Text = value; }
        }

        public string BookedTime
        {
            get { return lblABCardBookedTimem.Text; }
            set { lblABCardBookedTimem.Text = value; }
        }


        public string EventDate
        {
            get { return lblABCardEventDatem.Text; }
            set { lblABCardEventDatem.Text = value; }
        }


        public string EventName
        {
            get { return lblABCardEventNamem.Text; }
            set { lblABCardEventNamem.Text = value; }
        }


        public string Hall
        {
            get { return lblABCardHallm.Text; }
            set { lblABCardHallm.Text = value; }
        }

        public string NoOfParti
        {
            get { return lblABCardNoOFPartim.Text; }
            set { lblABCardNoOFPartim.Text = value; }
        }





        public string FoodPack
        {
            get { return lblABCardFPackagem.Text; }
            set { lblABCardFPackagem.Text = value; }
        }

        private void btnESelectStaff_Click(object sender, EventArgs e)
        {
            managerSelectStaffFromList ev = managerSelectStaffFromList.getInstance();
            ev.Show();
            
        }
    }
}
