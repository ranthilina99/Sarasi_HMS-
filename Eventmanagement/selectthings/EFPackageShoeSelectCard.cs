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
    public partial class EFPackageShoeSelectCard : UserControl
    {
        public EFPackageShoeSelectCard()
        {
            InitializeComponent();
        }
        //Getters and setters -1 step-
        public string packageID
        {
            get { return lblEPcardID.Text; }
            set { lblEPcardID.Text = value; }
        }

        public string packageName
        {
            get { return lblEFPcardName.Text; }
            set { lblEFPcardName.Text = value; }
        }

        public string pricePerPlate
        {
            get { return lblEFPcardPriceper.Text; }
            set { lblEFPcardPriceper.Text = value; }
        }

        public string noOfCurries
        {
            get { return lblEFPcardNuOfCurie.Text; }
            set { lblEFPcardNuOfCurie.Text = value; }
        }

        public string description
        {
            get { return richTxtCardDesc.Text; }
            set { richTxtCardDesc.Text = value; }
        }

        public Image mainMeal
        {
            get { return ShowCardPic1.Image; }
            set { ShowCardPic1.Image = value; }
        }

        public Image desert
        {
            get { return ShowCardPic2.Image; }
            set { ShowCardPic2.Image = value; }
        }

        private void btnEFPcardSelect_Click(object sender, EventArgs e)
        {
            //getting the card id 
            String eDTCardId = this.packageID;
            Eventmanagement.AddNewEventBooking edt = Eventmanagement.AddNewEventBooking.getInstance();

            edt.SetSelectedFPID(eDTCardId);
           edt.Show();
            this.Hide();
        }
    }
}
