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
    public partial class TStaffCard : UserControl
    {
        public TStaffCard()
        {
            InitializeComponent();
        }
        public string TStaffID
        {
            get { return lblETSID.Text; }
            set { lblETSID.Text = value; }
        }

        public string TSfname
        {
            get { return lblETSfName.Text; }
            set { lblETSfName.Text = value; }
        }

        public string TSlname
        {
            get { return lblETSlName.Text; }
            set { lblETSlName.Text = value; }
        }

        public string Gender
        {
            get { return lblETSgender.Text; }
            set { lblETSgender.Text = value; }
        }

        public string Contact
        {
            get { return lblETScontact.Text; }
            set { lblETScontact.Text = value; }
        }

        public string Email
        {
            get { return lblETSemail.Text; }
            set { lblETSemail.Text = value; }
        }

        public string DailySal
        {
            get { return lblETSdailySal.Text; }
            set { lblETSdailySal.Text = value; }
        }

        public string Type
        {
            get { return lblETStype.Text; }
            set { lblETStype.Text = value; }
        }

        private void btnETScardEdit_Click(object sender, EventArgs e)
        {
            //getting the card id 
            String TScard = this.TStaffID;
            AddTemporyStaff ts = new AddTemporyStaff();
            TemporyStaffViews evp = new TemporyStaffViews();
            ts.editTempStaff(TStaffID);
            ts.Show();
            this.Hide();
        }

        private void btnETScarddelete_Click(object sender, EventArgs e)
        {
            String cardID = this.TStaffID; //getting the cliked card id 

            TemporyStaffViews ts = new TemporyStaffViews();
            ts.deleteTempStaff(cardID); //passing the Id

            AddTemporyStaff ade = new AddTemporyStaff();
            this.Hide();
            ade.Show();
        }
    }
}
