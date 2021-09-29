using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sarasi_HMS.Eventmanagement.selectthings
{
    public partial class EDTeamShowSelectCard : UserControl
    {
        public EDTeamShowSelectCard()
        {
            InitializeComponent();
        }
        //Getters and setters -1 step-
        public string DTeamID
        {
            get { return lblEDTcardID.Text; }
            set { lblEDTcardID.Text = value; }
        }

        public string DTName
        {
            get { return lblEDTcardName.Text; }
            set { lblEDTcardName.Text = value; }
        }

        public string NoOfMem
        {
            get { return lblEDTcardNoOfMem.Text; }
            set { lblEDTcardNoOfMem.Text = value; }
        }

        public string price
        {
            get { return lblEDTcardPrice.Text; }
            set { lblEDTcardPrice.Text = value; }
        }

        public string contactNo
        {
            get { return lblEDTContact.Text; }
            set { lblEDTContact.Text = value; }
        }

        public string email
        {
            get { return lblEDTcardEmail.Text; }
            set { lblEDTcardEmail.Text = value; }
        }

        public string description
        {
            get { return richTxtCardDesc.Text; }
            set { richTxtCardDesc.Text = value; }
        }

        public Image image1
        {
            get { return ShowCardPic1.Image; }
            set { ShowCardPic1.Image = value; }
        }

        public Image image2
        {
            get { return ShowCardPic2.Image; }
            set { ShowCardPic2.Image = value; }
        }

        private void btnEDTcardSelect_Click(object sender, EventArgs e)
        {
            //getting the card id 
            String eDTCardId = this.DTeamID;
            AddNewEventBooking edt = Eventmanagement.AddNewEventBooking.getInstance();
            edt.SetSelectedDTID(eDTCardId);
            edt.Show();
            this.Hide();
        }
    }
}
