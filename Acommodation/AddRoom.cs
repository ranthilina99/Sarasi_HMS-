using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sarasi_HMS.Acommodation
{

    public partial class AddRoom : Form
    {

        private static AddRoom uniqueInstance = null;
        Room1 room = new Room1();
        String status = "insert";
        String fileName;

        OnlineUser onlineUser = OnlineUser.getInstance();
        public AddRoom()
        {
            InitializeComponent();
        }

        public static AddRoom getInstance()
        {
            if (uniqueInstance == null)
            {
                uniqueInstance = new AddRoom();
            }
            return uniqueInstance;
        }

        private void btn_getRoom_id_Click(object sender, EventArgs e)
        {
            txtroomID.Text = Util.generateKey("Room");
        }

        private void btnSaveRoom_Click(object sender, EventArgs e)
        {
            room.RoomID = txtroomID.Text;
            room.RoomNo = txtRoomNum.Text;
            room.bedtype = ComboBeadType.Text;
            room.maxaadult = txtmaxAdult.Text;
            room.floor = txtfloor.Text;
            room.roomtype = comboRoomtyp.Text;
            room.available = "1";

            room.RoomImage = Util.convertImageToBinary(picroom.Image);

            using (DBEntities db = new DBEntities())
            {
                if (status == "insert")
                {
                    db.Room1.Add(room);
                    MessageBox.Show("Room category added successfully");
                }
                else if (status == "update")
                {
                    db.Entry(room).State = EntityState.Modified;

                    MessageBox.Show("Vehicle Category Updated Successfully");
                }

                db.SaveChanges();

            }

            ///-------clear the flow layout and re load the category list 
            Acommodation.Room_list em = new Acommodation.Room_list();
            em.clearCatgoryList();
            em.loadRooms();
            em.Show();
            this.Hide();
        }

        private void btnbrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "JPEG|*.jpg", ValidateNames = true, Multiselect = false })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    fileName = ofd.FileName;
                    picroom.Image = Image.FromFile(fileName);
                }
            }
        }


        public void editcategory(String id)
        {
            //retreiving selected row 
            using (DBEntities db = new DBEntities())
            {
                //setting status to update
                status = "update";
                btnSaveRoom.Text = "Update";

                room = db.Room1.Where(x => x.RoomID == id).FirstOrDefault();
                MessageBox.Show(room.RoomID);

                //storing values to the textboxes
                txtroomID.Text = room.RoomID;
                txtfloor.Text = room.floor;
                txtmaxAdult.Text = room.maxaadult;
                txtRoomNum.Text = room.RoomNo;
                ComboBeadType.Text = room.bedtype;
                comboRoomtyp.Text = room.roomtype;

                picroom.Image = Util.convertBinaryToImage(room.RoomImage);

            }
        }//end of edit item category method

        private void btnbackto_Rooms_Click(object sender, EventArgs e)
        {
     

            Room_list list = Room_list.getInstance();
            this.Hide();
            list.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void setOnlineUserDetails()
        {
            Employee emp = new Employee();
            emp = onlineUser.getAvailableEmployee();
            picBoxUserImage.Image = Util.convertBinaryToImage(emp.image);
            llblUserName.Text = emp.fname + " " + emp.lname;
        }

        private void AddRoom_Load(object sender, EventArgs e)
        {
            setOnlineUserDetails();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = Login.getInstance();
            login.Show();
        }
    }
}
