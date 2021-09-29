using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sarasi_HMS.Acommodation
{
    public partial class addroomcards : UserControl
    {
        public addroomcards()
        {
            InitializeComponent();
        }

        public String cardId
        {
            get { return lblcardid.Text; }
            set { lblcardid.Text = value; }
        }

        public String Roommaxadult
        {
            get { return lblmaxaudit.Text; }
            set { lblmaxaudit.Text = value; }
        }

        public String Roomfloor
        {
            get { return lblfloortype.Text; }
            set { lblfloortype.Text = value; }
        }
        public String roomnumber
        {
            get { return lblroonumber.Text; }
            set { lblroonumber.Text = value; }
        }
        public String Roombedtype
        {
            get { return lblbedtype.Text; }
            set { lblbedtype.Text = value; }
        }
        public Image roomImage
        {
            get { return roompicture.Image; }
            set { roompicture.Image = value; }
        }


        private void btnEdit_Click(object sender, EventArgs e)
        {
            String cardId = this.lblcardid.Text;
            AddRoom accomadations = AddRoom.getInstance();
            accomadations.editcategory(cardId);
            accomadations.Show();
            this.Hide();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            String cardID = this.lblcardid.Text;

            Room_list em = new Room_list();
            em.deleteCategory(cardID);
        }

        private void btnEdit_Click_1(object sender, EventArgs e)
        {
            String cardId = this.lblcardid.Text;
            AddRoom accomadations = AddRoom.getInstance();
            accomadations.editcategory(cardId);
            accomadations.Show();
            this.Hide();
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            String cardID = this.lblcardid.Text;

            Room_list em = new Room_list();
            em.deleteCategory(cardID);
        }
    }
}
