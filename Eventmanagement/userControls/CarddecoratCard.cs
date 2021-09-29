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
    public partial class CarddecoratCard : UserControl
    {
        public CarddecoratCard()
        {
            InitializeComponent();
        }

        public string DTeamID
        {
            get { return lblDTid.Text; }
            set { lblDTid.Text = value; }
        }

        public string DTName
        {
            get { return lblDTName.Text; }
            set { lblDTName.Text = value; }
        }

        public string NoOfMem
        {
            get { return lblDTNoOfMem.Text; }
            set { lblDTNoOfMem.Text = value; }
        }

        public string Price
        {
            get { return lblDTPrice.Text; }
            set { lblDTPrice.Text = value; }
        }

        public string Contact
        {
            get { return lblDTContact.Text; }
            set { lblDTContact.Text = value; }
        }

        public string Email
        {
            get { return lblDTEmail.Text; }
            set { lblDTEmail.Text = value; }
        }
        public Image image1
        {
            get { return DTCardpictureBox1.Image; }
            set { DTCardpictureBox1.Image = value; }
        }

        public Image image2
        {
            get { return DTCardpictureBox2.Image; }
            set { DTCardpictureBox2.Image = value; }
        }

        private void btnEDTcardEdit_Click(object sender, EventArgs e)
        {
            //getting the card id 
            String eDTCardId = this.DTeamID;
            AddEventDecorationTeam edt = new AddEventDecorationTeam();

            edt.editEDecoTeam(eDTCardId);
            edt.Show();
            this.Hide();
        }

        private void btnEDTcarddelete_Click(object sender, EventArgs e)
        {
            String dtcardID = this.DTeamID; //getting the cliked card id 

            Decorationteamviews ds = new Decorationteamviews();
            ds.deleteDecoTeam(dtcardID); //passing the Id 

            AddEventDecorationTeam ade = new AddEventDecorationTeam();
            this.Hide();
            ade.Show();
        }
    }
}
