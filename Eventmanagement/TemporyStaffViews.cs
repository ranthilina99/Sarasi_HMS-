using Sarasi_HMS.Eventmanagement.userControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sarasi_HMS.Eventmanagement
{
    public partial class TemporyStaffViews : Form
    {
        //create eventfoodpackages list for insert data from sql table.
        List<TempStaff> TempStaffList = new List<TempStaff>();

        //create EFoodPackageCardList for insert cards to one list
        List<TStaffCard> TempStaffCardList = new List<TStaffCard>();

        //create reference (instance variable) to create new card reference
        private TStaffCard tStaffCard;

        private TempStaff ts1;
        public TemporyStaffViews()
        {
            InitializeComponent();
            setDefaultValues();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //Create a methods for show all cards
        public void DisplayTemporyStaffs()
        {
            using (DBEntities db = new DBEntities())
            {
                TempStaffList = db.TempStaffs.ToList(); //get details from sql and add to this list

                foreach (TempStaff tempStaff in TempStaffList) //eventPackage is one raw
                                                               //Iterarte raw by raw and insert to card list
                {
                    tStaffCard = new TStaffCard();
                    tStaffCard.TStaffID = tempStaff.staffID;
                    tStaffCard.TSfname = tempStaff.fName;
                    tStaffCard.TSlname = tempStaff.lName;
                    tStaffCard.Gender = tempStaff.gender;
                    tStaffCard.Contact = tempStaff.contact.ToString();
                    tStaffCard.Email = tempStaff.email;
                    tStaffCard.Gender = tempStaff.gender;
                    tStaffCard.DailySal = tempStaff.dailySal.ToString();
                    tStaffCard.Type = tempStaff.type;

                    TempStaffCardList.Add(tStaffCard);
                }


            }
            foreach (TStaffCard card in TempStaffCardList)
            {
                flowLayoutTemporyStaffView.Controls.Add(card);
            }
        }

        private void TemporyStaffViews_Load(object sender, EventArgs e)
        {
            DisplayTemporyStaffs();
        }
        public void deleteTempStaff(String id)
        {
            if ((MessageBox.Show("Are you sure to Delete this record?", "Delete this Staff member", MessageBoxButtons.YesNo) == DialogResult.Yes))
            {

                using (DBEntities db = new DBEntities())
                {
                    ts1 = db.TempStaffs.Where(x => x.staffID == id).FirstOrDefault();
                    MessageBox.Show(ts1.staffID);

                    db.TempStaffs.Remove(ts1);
                    try
                    {
                        db.SaveChanges();
                    }
                    catch (DbEntityValidationException ex)
                    {
                        foreach (var entityValidationErrors in ex.EntityValidationErrors)
                        {
                            foreach (var validationError in entityValidationErrors.ValidationErrors)
                            {
                                MessageBox.Show("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                            }
                        }
                    }


                }
                MessageBox.Show("Staff member Removed Successfully!!!");


            }
            //refreshing......
            clearTempStafffs();
            DisplayTemporyStaffs();
        }// end of deleteCategory

        public void clearTempStafffs()
        {
            flowLayoutTemporyStaffView.Controls.Clear();
        }

        private void btnEventBack_Click(object sender, EventArgs e)
        {
            AddTemporyStaff ad = new AddTemporyStaff();
            this.Hide();
            ad.Show();
        }
        private void setDefaultValues()
        {
            DateTime time = DateTime.Now.ToLocalTime();
            lblDateTime.Text = time.ToString();
        }

        private void btnETSadd_Click(object sender, EventArgs e)
        {
            AddTemporyStaff ad = new AddTemporyStaff();
            this.Hide();
            ad.Show();
        }
    }
}
