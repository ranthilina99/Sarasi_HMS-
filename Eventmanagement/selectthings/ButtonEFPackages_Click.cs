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
    public partial class ButtonEFPackages_Click : UserControl
    {
        public ButtonEFPackages_Click()
        {
            InitializeComponent();
        }
        //Getters and setters -1 step-
        public string packageID
        {
            get { return lblPackageBtnID.Text; }
            set { lblPackageBtnID.Text = value; }
        }

        public string packageName
        {
            get { return lblPackageBtnName.Text; }
            set { lblPackageBtnName.Text = value; }
        }

        private void ButtonEFPackages_Click_Click(object sender, EventArgs e)
        {
            String id = this.packageID;
            EselectFPackage esp = EselectFPackage.getInstance();
             esp.DisplayEventFoodPackageCard(id);
            // esp.Show();
        }
    }
}
