using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sarasi_HMS
{
    public partial class Selector : Form
    {
        private static Selector uniqueInstance = null;
        private Selector()
        {
            InitializeComponent();
        }
        public static Selector getInstance()
        {
            if (uniqueInstance == null)
            {
                uniqueInstance = new Selector();
            }
            return uniqueInstance;
        }

        private void btnRestaurant_Click(object sender, EventArgs e)
        {
            RestaurantPOS restaurantpos = RestaurantPOS.getInstance();
            restaurantpos.setOnlineUserDetails();
            restaurantpos.Show();
        }

        private void btnEventBookings_Click(object sender, EventArgs e)
        {
            Eventmanagement.AddNewEventBooking evn = Eventmanagement.AddNewEventBooking.getInstance();
            evn.Show();
            this.Hide();
        }

        private void btnreservation_Click(object sender, EventArgs e)
        {
            Acommodation.Guest_manage1 guesr = Acommodation.Guest_manage1.getInstance();
            this.Hide();
            guesr.Show();
        }

        private void btnVehicleRent_Click(object sender, EventArgs e)
        {
            VehicleManagement.vm_forms.RentalList av = VehicleManagement.vm_forms.RentalList.getInstance();
            av.Show();
            this.Hide();
        }
    }
}
