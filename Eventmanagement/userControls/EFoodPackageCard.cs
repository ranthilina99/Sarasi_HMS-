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
    public partial class EFoodPackageCard : UserControl
    {
        public EFoodPackageCard()
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

        public Image mainMeal
        {
            get { return EPCardpictureBox1.Image; }
            set { EPCardpictureBox1.Image = value; }
        }

        public Image desert
        {
            get { return EPCardpictureBox2.Image; }
            set { EPCardpictureBox2.Image = value; }
        }

        private void btnEFPcardEdit_Click(object sender, EventArgs e)
        {
            //getting the card id 
            String eCardId = this.packageID;
            AddEventFoodPackage fm = new AddEventFoodPackage();
            EventPackageViews evp = new EventPackageViews();
            fm.editEFoodPackage(eCardId);
            fm.Show();
            this.Hide();

        }

        private void btnEFPcarddelete_Click(object sender, EventArgs e)
        {

            String cardID = this.packageID; //getting the cliked card id 

            EventPackageViews ds = new EventPackageViews();
            ds.deleteEPackage(cardID); //passing the Id 

            ds.clearFoodPackageList();
            ds.DisplayEventFoodPackages();
            AddEventFoodPackage ade = new AddEventFoodPackage();
            this.Hide();
            ade.Show();
        }




    }
}
