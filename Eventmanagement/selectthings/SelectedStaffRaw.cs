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

    public partial class SelectedStaffRaw : UserControl
    {
        managerSelectStaffFromList mg = managerSelectStaffFromList.getInstance();
        public SelectedStaffRaw()
        {
            InitializeComponent();
        }
        public string TSIDs
        {
            get { return lblSTSID1.Text; }
            set { lblSTSID1.Text = value; }
        }
        public string TSfNames
        {
            get { return lblSTSfName1.Text; }
            set { lblSTSfName1.Text = value; }
        }
        public string TSlNames
        {
            get { return lblSTSlName1.Text; }
            set { lblSTSlName1.Text = value; }
        }

        public string DailySals
        {
            get { return lblSTSSalary1.Text; }
            set { lblSTSSalary1.Text = value; }
        }

        public string Types
        {
            get { return lblSTSType1.Text; }
            set { lblSTSType1.Text = value; }
        }

        private void btndeleteSelect_Click(object sender, EventArgs e)
        {
            managerSelectStaffFromList mg = managerSelectStaffFromList.getInstance();
            mg.removeraw(this.TSIDs);
        }
    }
}
