﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sarasi_HMS.VehicleManagement.vm_forms
{
    public partial class VehiclePOS : Form
    {
        public VehiclePOS()
        {
            InitializeComponent();
        }

        private void btnNewrent_Click(object sender, EventArgs e)
        {
            AddNewRent anr =  AddNewRent.getInstance();
            anr.Show();
            this.Hide();
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            VehicleManagementNew vm = new VehicleManagementNew();
            this.Hide();
            vm.Show();
        }

        private void btnRentHistory_Click(object sender, EventArgs e)
        {
            VehicleManagement.vm_forms.RentingPayment vm = new VehicleManagement.vm_forms.RentingPayment();
            this.Hide();
            vm.Show();
        }
    }
}
