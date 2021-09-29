using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sarasi_HMS.VehicleManagement.user_controks
{
    public partial class RentCard : UserControl
    {
        public RentCard()
        {
            InitializeComponent();
        }
        public String RentID
        {
            get { return lblRentID.Text; }
            set { lblRentID.Text = value; }
        }

        public String vehicleId
        {
            get { return lblVCardID.Text; }
            set { lblVCardID.Text = value; }

        }
        public String vNumber
        {
            get { return lblVNumber.Text; }
            set { lblVNumber.Text = value; }

        }

        public String vtype
        {
            get { return lblvtype.Text; }
            set { lblvtype.Text = value; }

        }


        public String CustomerName
        {
            get { return lblCustomerName.Text; }
            set { lblCustomerName.Text = value; }
        }

        public String RentDate
        {
            get { return lblRentDate.Text; }
            set { lblRentDate.Text = value; }
        }

        public Image vimage
        {
            get { return picBoxvehicle.Image; }
            set { picBoxvehicle.Image = value; }
        }

        private void buttonpayyyy_Click(object sender, EventArgs e)
        {
            VehicleManagement.vm_forms.RentingPayment vm = new VehicleManagement.vm_forms.RentingPayment();
            this.Hide();
            vm.Show();
        }

        private void btneditAddVehi_Click(object sender, EventArgs e)
        {
            //getting the card id 
            String cardId = this.RentID;
            AddRentDetails avC = AddRentDetails.getInstance();
            avC.editRent(cardId);

            avC.Show();
        }

        private void buttondltAddvehi_Click(object sender, EventArgs e)
        {
            String cardID = this.RentID; //getting the cliked card id 

            VehicleManagement.vm_forms.RentalList Vcategories = VehicleManagement.vm_forms.RentalList.getInstance();
            Vcategories.deleteRent(cardID); //passing the Id
        }

    }
}
