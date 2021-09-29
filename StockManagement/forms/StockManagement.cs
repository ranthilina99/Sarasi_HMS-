using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sarasi_HMS
{

    public partial class StockManagement : Form
    {

        private static StockManagement uniqueInstance = null;
        //list of Panels 
        public static List<Button> StockManagementButtons = new List<Button>();
        public static List<Panel> StockManagementPanels = new List<Panel>();


        private static List<Item> kitchenItems = new List<Item>();
        private static List<KitchenitemCard> kitchenItemcards = new List<KitchenitemCard>();

      

        private KitchenitemCard itemcard;

        private Item itemmm; //to perform delete

        private StockManagement()
        {
            InitializeComponent();
            initialAdd();
            setDefaultValues();
            Settings.ApplyThemes(Color.Black, Color.Black, Settings.zColor(246, 255, 199), Color.White, Color.Chartreuse, Color.White, Color.Yellow,Color.White);
            //applying light theme initially

        }

        private void setDefaultValues()
        {
            DateTime time = DateTime.Now.ToLocalTime();
            lblDateTime.Text = time.ToString();
        }

        public void initialAdd()
        {
            //adding Pannels
            StockManagementPanels.Add(panelBottomStock);
            StockManagementPanels.Add(panelMainStock);
            Settings.AllPanels.AddRange(StockManagementPanels);


            //adding buttons
            StockManagementButtons.Add(btnAddNewItems);
            StockManagementButtons.Add(btnItemAlertsStock);
            StockManagementButtons.Add(btnItemList);
            StockManagementButtons.Add(btnReportsStock);
            StockManagementButtons.Add(btnBackStock);
            StockManagementButtons.Add(btnItemcategories);


            //Add to AllButtons
            Settings.AllButtons.AddRange(StockManagementButtons);

        }
        public static StockManagement getInstance()
        {

            if (uniqueInstance == null)
            {

                uniqueInstance = new StockManagement();
            }
            return uniqueInstance;
        }

        public void changeBackImage(int themenumber)
        {
            if (themenumber == 0)
            {
                this.BackgroundImage = Properties.Resources.green;

            }
            else if (themenumber == 1)
            {
                this.BackgroundImage = Properties.Resources.white;

            }
        }

        private void btnItemList_Click(object sender, EventArgs e)
        {
            clearLAyout();
            loadKitchenItems();
        }

        private void btnFoodAlerts2_Click(object sender, EventArgs e)
        {
            ItemAlerts it = ItemAlerts.getInstance();
            it.refreshExpiredItemsTable();
            it.Show();
            this.Hide();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            printreportStock rp = new printreportStock();
            this.Hide();
            rp.Show();
        }

        private void StockManagement_Load(object sender, EventArgs e)
        {
            clearLAyout();
            loadKitchenItems();
        }

        private void btnAddNewItems_Click(object sender, EventArgs e)
        {
            AddNewItem ai = AddNewItem.getInstance();
            ai.updateStatus("save");
            this.Hide();
            ai.Show();
        }

        private void btnBackStock_Click(object sender, EventArgs e)
        {
            AdminPanelForm apf = AdminPanelForm.getInstance();
            this.Hide();
            apf.Show();
        }

        private void btnItemcategories_Click(object sender, EventArgs e)
        {
            ItemCategories ic = ItemCategories.getInstance();
            this.Hide();
            ic.Show();
        }

        public void loadKitchenItems()
        {
            //clear the card list 
            kitchenItemcards.Clear();

            using (DBEntities db = new DBEntities())
            {
                kitchenItems = db.Items.ToList();

                foreach (Item Item in kitchenItems)
                {
                    //creating new card 
                    itemcard = new KitchenitemCard();
                    itemcard.itemID = Item.itemID;
                    itemcard.itemName = Item.name;
                    itemcard.itemImage = Util.convertBinaryToImage(Item.image);
                    itemcard.purchacedPrice = Item.purchase_price.ToString();


                    //adding card to the list
                    kitchenItemcards.Add(itemcard);

                }

            }


            //adding cards to the flow panel
            foreach (KitchenitemCard card in kitchenItemcards)
            {
                flowItemPanel.Controls.Add(card);
            }
        }

        public void clearItemList()
        {
            flowItemPanel.Controls.Clear();
        }

       
        public void deleteItem(String id)
        {
            if (MessageBox.Show("All the Stock Records referencing to this item will be removed !!! Are u sure u want to delete?", "Warning - Delete Item", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                using (DBEntities db = new DBEntities())
                {
                    //getting the object whichh need to be deleted 
                    itemmm = db.Items.Where(fc => fc.itemID == id).First();
                    //delete the object 
                    db.Items.Remove(itemmm);

                    db.SaveChanges();


                }
                MessageBox.Show("Food Removed Successfully!!!");

            }

            //refreshing......
            clearItemList();
            loadKitchenItems();
        }//end of delete Food method *******************

      
        private void btnCheckNewOrders_Click(object sender, EventArgs e)
        {
            NewOrders no = NewOrders.getInstance();
            this.Hide();
            no.Show();
        }

        private void clearLAyout()
        {
            flowItemPanel.Controls.Clear();
        }
    }
}

