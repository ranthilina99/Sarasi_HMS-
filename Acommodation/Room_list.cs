using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.Entity.Validation;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sarasi_HMS.Acommodation
{
    public partial class Room_list : Form
    {

        private static Room_list uniqueInstance = null;
        private List<Room1> RCategoriesList = new List<Room1>();
        private List<addroomcards> roomcardlist = new List<addroomcards>();
        private addroomcards roomccard;
        private Room1 room;

        OnlineUser onlineUser = OnlineUser.getInstance();


        public Room_list()
        {
            InitializeComponent();
        }

        public static Room_list getInstance()
        {
            if (uniqueInstance == null)
            {
                uniqueInstance = new Room_list();
            }
            return uniqueInstance;
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRooms_Click(object sender, EventArgs e)
        {


            AddRoom roomss = AddRoom.getInstance();
            this.Hide();
            roomss.Show();
        }


        public void loadRooms()
        {
            //clear the card list 
            roomcardlist.Clear();

            using (DBEntities db = new DBEntities())
            {
                RCategoriesList = db.Room1.ToList();

                foreach (Room1 Item in RCategoriesList)
                {
                    //creating new card 
                    roomccard = new addroomcards();

                    roomccard.Roommaxadult = Item.maxaadult;
                    roomccard.Roombedtype = Item.bedtype;
                    roomccard.roomnumber = Item.RoomNo;
                    roomccard.Roombedtype = Item.bedtype;
                    roomccard.Roombedtype = Item.bedtype;
                    roomccard.roomImage = Util.convertBinaryToImage(Item.RoomImage);
                    roomccard.cardId = Item.RoomID;

                    //adding card to the list
                    roomcardlist.Add(roomccard);

                }

            }
            foreach (addroomcards card in roomcardlist)
            {
                Flowroompanel.Controls.Add(card);
            }
        }

        private void Room_list_Load(object sender, EventArgs e)
        {
            loadRooms();
            setOnlineUserDetails();
        }

        public void clearCatgoryList()
        {
            Flowroompanel.Controls.Clear();
        }

        public void deleteCategory(String id)
        {
            if (MessageBox.Show("Are you sure to Delete this record?", "Delete Category", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                using (DBEntities db = new DBEntities())
                {
                    //getting the object whichh need to be deleted 
                    room = db.Room1.Where(fc => fc.RoomID == id).First();
                    //delete the object 
                    db.Room1.Remove(room);
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
            clearCatgoryList();
            loadRooms();
        }//end of delete category method *******************

        private void Room_list_Activated(object sender, EventArgs e)
        {
            clearCatgoryList();
            loadRooms();
        }

        public void setOnlineUserDetails()
        {
            Employee emp = new Employee();
            emp = onlineUser.getAvailableEmployee();
            picBoxUserImage.Image = Util.convertBinaryToImage(emp.image);
            llblUserName.Text = emp.fname + " " + emp.lname;
        }

        private void btnBack2tomange_Click(object sender, EventArgs e)
        {
            AdminPanelForm admin = AdminPanelForm.getInstance();
            admin.Show();
            this.Hide();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = Login.getInstance();
            login.Show();
        }
    }
}
