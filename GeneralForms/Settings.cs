using Bunifu.Framework.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sarasi_HMS
{
    public partial class Settings : Form
    {
        //unique instance 
        private static Settings uniqueInstance = null;
        private int currentTheme; //save the currently applied Theme

        //Lists  of Controls 
        public static List<Button> AllButtons = new List<Button>();
        public static List<Panel> AllPanels = new List<Panel>();
        public static List<BunifuGradientPanel> AllBuniPanels = new List<BunifuGradientPanel>();
        public static List<TextBox> AllTextBoxes = new List<TextBox>();
        public static List<Label> AllLabels = new List<Label>();
        public static List<PictureBox> AllPicBoxes = new List<PictureBox>();
        public static List<ComboBox> AllComboBoxes = new List<ComboBox>();
      
        AdminPanelForm apf = AdminPanelForm.getInstance();
        FoodManagement fm = FoodManagement.getInstance();
        AddNewFood addnewFood = AddNewFood.getInstance();
        ReadyMadrProductAlerts readyMadrProductAlerts = ReadyMadrProductAlerts.getInstance();
        Categories categories = Categories.getInstance();
        AddFoodCategory addFoodCategory = AddFoodCategory.getInstance();
        StockManagement sm = StockManagement.getInstance();
        AddNewItem addNewItem = AddNewItem.getInstance();
        ItemAlerts itemAlerts = ItemAlerts.getInstance();
        ItemCategories itemCategories = ItemCategories.getInstance();
        AddItemCategory addItemCategory = AddItemCategory.getInstance();

        private  Employee emp = new Employee();
        private UserLogin userLogin = new UserLogin();
        private UserLogin loginModel = new UserLogin();
        private static String state = "ok";

        private Settings()
        {
            InitializeComponent();
            themeSelector.SelectedIndex = currentTheme;
           
        }

        public static Settings getInstance()
        {
            if (uniqueInstance == null)
            {
                uniqueInstance = new Settings();
            }
            return uniqueInstance;
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            themeSelector.SelectedIndex = currentTheme;
        }


        private void btnSettings_Click(object sender, EventArgs e)
        {          
           this.Hide();
            apf.Show();
        }
        //--------------------------------
        public static void ApplyThemes(Color btnColor,Color panelColor,Color txtBoxColor,Color Bleft,Color bRight,Color tLeft,Color tRight,Color btnForColor)
        {
            foreach(Button Item in AllButtons)
            {
                Item.BackColor = Color.FromArgb(160, btnColor);
                Item.ForeColor = btnForColor;
            }

            foreach(Panel Item in AllPanels)
            {
                Item.BackColor = Color.FromArgb(160, panelColor);
            }

            foreach (TextBox Item in AllTextBoxes)
            {
                Item.BackColor = txtBoxColor;
            }

            foreach (ComboBox Item in AllComboBoxes)
            {
                Item.BackColor = txtBoxColor;
            }
            foreach (PictureBox Item in AllPicBoxes)
            {
                Item.BackColor = txtBoxColor;
            }

            foreach (Label Item in AllLabels)
            {
                Item.ForeColor = btnForColor;
            }

            foreach (BunifuGradientPanel Item in AllBuniPanels)
            {
                Item.GradientBottomLeft = Bleft;
                Item.GradientBottomRight = bRight;
                Item.GradientTopLeft = tLeft;
                Item.GradientTopRight = tRight;
            }
           

        }

        public static Color zColor(int r, int g, int b)
        {   //this method will return rgb Colors
            return Color.FromArgb(r, g, b);
        }

      

        private void btnOk_Click(object sender, EventArgs e)
        {
            performOperation();
        }

        public void performOperation()
        {
            if (state == "ok")
            {
                MessageBox.Show("OK");
            }else if (state == "update")
            {
                updateLoginDetails();
            }

            backToAdminPanel();
        }

        public void updateLoginDetails()
        {
            loginModel.loginID = emp.employeeId;
            loginModel.username = txtUserName.Text;
            loginModel.password = txtPassword.Text;

            using(DBEntities db = new DBEntities())
            {
                db.Entry(loginModel).State = EntityState.Modified;
                db.SaveChanges();
            }

            MessageBox.Show("Credentials Updated !!!");
        }

        public void loadAccountDetais()
        {
            OnlineUser onlineUser = OnlineUser.getInstance();
           
            emp = onlineUser.getAvailableEmployee();
            picBoxUserImage.Image = Util.convertBinaryToImage(emp.image);
            lblShowUserName.Text = emp.fname + " " + emp.lname;
            lblID.Text = emp.nic;
            lblEmpId.Text = emp.employeeId;

        }

        private void picBoxEdit_Click(object sender, EventArgs e)
        {
            state = "update";
            btnOk.Text = "Update";

            panelGeneralDetails.Visible = false;
            panelLoginDetails.Visible = true;
            picBoxCancel.Visible = true;
            picBoxEdit.Visible = false;

            fillTheForm();

        }

        private void picBoxCancel_Click(object sender, EventArgs e)
        {
            state = "ok";
            btnOk.Text = "OK";

            picBoxCancel.Visible = false;
            picBoxEdit.Visible = true;
            panelGeneralDetails.Visible = true;
            panelLoginDetails.Visible = false;
        }

        public void fillTheForm()
        {
           using(DBEntities db = new DBEntities())
            {
                userLogin = db.UserLogins.Where(x => x.loginID == emp.employeeId).FirstOrDefault();
              
            }

            txtUserName.Text = userLogin.username;
            txtPassword.Text = userLogin.password;
        }

        public void backToAdminPanel()
        {
            AdminPanelForm apf = AdminPanelForm.getInstance();
            this.Hide();
            apf.Show();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            backToAdminPanel();
        }

        private void themeSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (themeSelector.Text == "Light")
            {
                ApplyThemes(Color.Black, Color.Black, zColor(228, 255, 171), Color.White, Color.Chartreuse, Color.White, Color.Yellow,Color.White);
                currentTheme = 0;
                apf.changeBackImage(0);
                fm.changeBackImage(0);
                addnewFood.changeBackImage(0);
                readyMadrProductAlerts.changeBackImage(0);
                categories.changeBackImage(0);
                addFoodCategory.changeBackImage(0);
                sm.changeBackImage(0);
                addNewItem.changeBackImage(0);
                itemAlerts.changeBackImage(0);
                itemCategories.changeBackImage(0);
                addItemCategory.changeBackImage(0);


                FoodProgress.FoodprogressColor = Color.FromArgb(160, Color.Black);

            }
            else if (themeSelector.Text == "Dark")
            {
                ApplyThemes(zColor(57, 115, 172), zColor(102,102,255), zColor(204, 204, 255), Color.DarkCyan, Color.White, Color.PaleTurquoise, zColor(192, 64, 0),Color.Black);
                currentTheme = 1;
                apf.changeBackImage(1);
                fm.changeBackImage(1);
                addnewFood.changeBackImage(1);
                readyMadrProductAlerts.changeBackImage(1);
                categories.changeBackImage(1);
                addFoodCategory.changeBackImage(1);
                sm.changeBackImage(1);
                addNewItem.changeBackImage(1);
                itemAlerts.changeBackImage(1);
                itemCategories.changeBackImage(1);
                addItemCategory.changeBackImage(1);

                FoodProgress.FoodprogressColor = Color.FromArgb(160, Color.RosyBrown);

            }
        }
    }
}
