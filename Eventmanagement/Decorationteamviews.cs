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
    public partial class Decorationteamviews : Form
    {
        //create eventdecoteams list for insert data from sql table.
        List<DecorationTeam> EventDecoTeamsList = new List<DecorationTeam>();

        //create EDecoTeamCardList for insert cards to one list
        List<CarddecoratCard> EDecoTeamCardList = new List<CarddecoratCard>();

        //create reference (instance variable) to create new card reference
        private CarddecoratCard eDecorationTeamsCard;

        private DecorationTeam dt2;
        public Decorationteamviews()
        {
            InitializeComponent();
            setDefaultValues();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void setDefaultValues()
        {
            DateTime time = DateTime.Now.ToLocalTime();
            lblDateTime.Text = time.ToString();
        }

        public void DisplayEventDecoTeams()
        {
            EDecoTeamCardList.Clear();
            using (DBEntities db = new DBEntities())
            {
                EventDecoTeamsList = db.DecorationTeams.ToList(); //get details from sql and add to this list

                foreach (DecorationTeam eDeco in EventDecoTeamsList) //eventPackage is one raw
                                                                         //Iterarte raw by raw and insert to card list
                {
                    eDecorationTeamsCard = new CarddecoratCard();
                    eDecorationTeamsCard.DTeamID = eDeco.dtID;
                    eDecorationTeamsCard.DTName = eDeco.dtName;
                    eDecorationTeamsCard.NoOfMem = eDeco.NoOfMembers.ToString();
                    eDecorationTeamsCard.Price = eDeco.price.ToString();
                    eDecorationTeamsCard.Contact = eDeco.contactNo.ToString();
                    eDecorationTeamsCard.Email = eDeco.email;
                    eDecorationTeamsCard.image1 = AddEventDecorationTeam.convertBinaryToImage(eDeco.image1);
                    eDecorationTeamsCard.image2 = AddEventDecorationTeam.convertBinaryToImage(eDeco.image2);

                    EDecoTeamCardList.Add(eDecorationTeamsCard);
                }


            }
            foreach (CarddecoratCard card in EDecoTeamCardList)
            {
                flowLayoutDecorationTeamView.Controls.Add(card);
            }

        }
        public void clearPanel()
        {
            flowLayoutDecorationTeamView.Controls.Clear();
        }

        private void Decorationteamviews_Load(object sender, EventArgs e)
        {
            DisplayEventDecoTeams();
        }
        public void deleteDecoTeam(String id)
        {
            if ((MessageBox.Show("Are you sure to Delete this record?", "Delete Category", MessageBoxButtons.YesNo) == DialogResult.Yes))
            {

                using (DBEntities db = new DBEntities())
                {
                    dt2 = db.DecorationTeams.Where(x => x.dtID == id).FirstOrDefault();
                    MessageBox.Show(dt2.dtID);

                    db.DecorationTeams.Remove(dt2);
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
                MessageBox.Show("Category Removed Successfully!!!");


            }
            //refreshing......
            clearPanel();
            DisplayEventDecoTeams();
        }// end of deleteCategory

        private void btnBack2_Click(object sender, EventArgs e)
        {
            AddEventDecorationTeam ed = new AddEventDecorationTeam();
            ed.Show();
            this.Hide();
        }
    }
}
