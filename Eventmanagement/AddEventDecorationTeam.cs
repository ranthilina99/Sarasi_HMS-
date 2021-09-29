using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sarasi_HMS.Eventmanagement
{
    public partial class AddEventDecorationTeam : Form
    {
        OnlineUser onlineUser = OnlineUser.getInstance();
        DecorationTeam dt1 = new DecorationTeam();
        private static String status = "insert";
        String fileName;
        public AddEventDecorationTeam()
        {
            InitializeComponent();
            setDefaultValues();
        }
        void Clear()
        {
            txtEDTteamID.Text = txtEDTname.Text = txtEDTnoofmembers.Text = txtEDTprice.Text = txtEDTcontact.Text = txtEDTemail.Text = richTxtEDTdesc.Rtf = "";

            btnEDTsave.Text = "Save";
            // btnEDTdelete.Enabled = false;
            EDTpictureBox1.Image = null;
            EDTpictureBox2.Image = null;


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

        public void setOnlineUserDetails()
        {
            Employee emp = new Employee();
            emp = onlineUser.getAvailableEmployee();
            picBoxUserImage.Image = Util.convertBinaryToImage(emp.image);
            llblUserName.Text = emp.fname + " " + emp.lname;
        }

        private void AddEventDecorationTeam_Load(object sender, EventArgs e)
        {
            setOnlineUserDetails();
        }

        private void logoutbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = Login.getInstance();
            login.Show();
        }

        private void btnDTgenarate_Click(object sender, EventArgs e)
        {
            String result = Util.generateKey("DecorationTeam");
            MessageBox.Show(result);
            txtEDTteamID.Text = result;
        }

        private void btnEDTsave_Click(object sender, EventArgs e)
        {

            //asssign to table
            dt1.dtID = txtEDTteamID.Text.Trim();
            dt1.dtName = txtEDTname.Text.Trim();
            dt1.NoOfMembers = Int16.Parse(txtEDTnoofmembers.Text);
            double price;
            bool Results = double.TryParse(txtEDTprice.Text, out price);
            if (!Results)
            {
                MessageBox.Show("Please enter per plate price");
            }
            else
            {
                dt1.price = (float)price;
            }
            dt1.contactNo = Int32.Parse(txtEDTcontact.Text);
            dt1.email = txtEDTemail.Text.Trim();
            dt1.description = richTxtEDTdesc.Text.Trim();

            dt1.image1 = convertImageToBinary(EDTpictureBox1.Image);
            dt1.image2 = convertImageToBinary(EDTpictureBox2.Image);


            using (DBEntities db = new DBEntities())
            {
                if (status == "insert")
                {
                    db.DecorationTeams.Add(dt1);

                    MessageBox.Show("Successfully saved");
                }
                else if (status == "update")
                {
                    //updating the database 
                    db.Entry(dt1).State = EntityState.Modified;

                    MessageBox.Show("Category Updated Successfully");
                    /* Decorationteamviews edtv = new Decorationteamviews();
                     edtv.clearPanel();
                     edtv.DisplayEventDecoTeams();
                     edtv.Show();
                     this.Hide();*/
                }
                db.SaveChanges();
            }
            Clear();
            /*Decorationteamviews edtv = new Decorationteamviews();
            edtv.clearPanel();
            edtv.DisplayEventDecoTeams();
            edtv.Show();
            this.Hide();*/
        }

        public static byte[] convertImageToBinary(Image img)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }

        }
        public static Image convertBinaryToImage(byte[] data)
        {
            using (MemoryStream ms = new MemoryStream(data))
            {
                return Image.FromStream(ms);
            }
        }

        private void btnEDTreset_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnEDTbrowse1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "JPEG|*.jpg", ValidateNames = true, Multiselect = false })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    fileName = ofd.FileName;
                    EDTpictureBox1.Image = Image.FromFile(fileName);
                }
            }
        }

        private void btnEDTbrowse2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "JPEG|*.jpg", ValidateNames = true, Multiselect = false })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    fileName = ofd.FileName;
                    EDTpictureBox2.Image = Image.FromFile(fileName);
                }
            }
        }

        public void editEDecoTeam(String id)
        {

            //retreiving selected raw
            using (DBEntities db = new DBEntities())
            {
                //setting status to update 
                status = "update";
                btnEDTsave.Text = "Update";

                dt1 = db.DecorationTeams.Where(x => x.dtID == id).FirstOrDefault();
                MessageBox.Show(dt1.dtID);

                //btnOLgenarate.Enabled = false;
                btnDTgenarate.Visible = false;
                //set values to the textboxess
                this.txtEDTteamID.Text = dt1.dtID;
                txtEDTname.Text = dt1.dtName;
                txtEDTnoofmembers.Text = dt1.NoOfMembers.ToString();
                txtEDTprice.Text = dt1.price.ToString();
                txtEDTcontact.Text = dt1.contactNo.ToString();
                txtEDTemail.Text = dt1.email;
                richTxtEDTdesc.Text = dt1.description;

                EDTpictureBox1.Image = AddEventDecorationTeam.convertBinaryToImage(dt1.image1);
                EDTpictureBox2.Image = AddEventDecorationTeam.convertBinaryToImage(dt1.image2);

                // MessageBox.Show("end of method");



            }
        }

        private void btnEventBack_Click(object sender, EventArgs e)
        {
            EventManagementDashboard emd = new EventManagementDashboard();
            this.Hide();
            emd.Show();
        }

        private void btnEDTview_Click(object sender, EventArgs e)
        {
            Decorationteamviews eventDecoTeamsViews = new Decorationteamviews();
            //EventManagement eventManagement = EventManagement.getInstance();
            eventDecoTeamsViews.Show();
            this.Hide();
        }
    }
}
