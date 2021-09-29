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
    public partial class VcardEDAddVe : UserControl
    {
        public VcardEDAddVe()
        {
            InitializeComponent();
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

        public String rentPerDay
        {
            get { return lblRentPerday.Text; }
            set { lblRentPerday.Text = value; }

        }

        public String rentPerKM
        {
            get { return lblRentperKM.Text; }
            set { lblRentperKM.Text = value; }

        }

        public Image vimage
        {
            get { return picBoxvehicle.Image; }
            set { picBoxvehicle.Image = value; }
        }

        private void buttondltAddvehi_Click(object sender, EventArgs e)
        {
            String cardID = this.vehicleId; //getting the cliked card id 

            VehicleManagement.vm_forms.VehicleNewList Vcategories = VehicleManagement.vm_forms.VehicleNewList.getInstance();
            Vcategories.deleteVehicle(cardID); //passing the Id
        }

        private void btneditAddVehi_Click(object sender, EventArgs e)
        {
            //getting the card id 
            String cardId = this.vehicleId;
            AddnewVehicle avC = AddnewVehicle.getInstance();
            avC.editVehicle(cardId);

            avC.Show();
        }

    }
}
