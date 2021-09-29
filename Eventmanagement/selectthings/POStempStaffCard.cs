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
    public partial class POStempStaffCard : UserControl
    {
        managerSelectStaffFromList mg =  managerSelectStaffFromList.getInstance();
        public POStempStaffCard()
        {
            InitializeComponent();
        }
        public string TSIDp
        {
            get { return lblSTSID.Text; }
            set { lblSTSID.Text = value; }
        }
        public string TSfNamep
        {
            get { return lblSTSfName.Text; }
            set { lblSTSfName.Text = value; }
        }
        public string TSlNamep
        {
            get { return lblSTSlName.Text; }
            set { lblSTSlName.Text = value; }
        }

        public string DailySalp
        {
            get { return lblSTSSalary.Text; }
            set { lblSTSSalary.Text = value; }
        }

        public string Typep
        {
            get { return lblSTSType.Text; }
            set { lblSTSType.Text = value; }
        }

        private void btnaddSelectStaff_Click(object sender, EventArgs e)
        {
            mg.addToSelectedStaff(this.TSIDp, this.TSfNamep, this.TSlNamep, this.Typep, this.DailySalp);
        }
    }
}
