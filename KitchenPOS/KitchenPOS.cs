﻿using System;
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
    public partial class KitchenPOS : Form
    {
        //unique instance 
        private static KitchenPOS uniqueInstance = null;

        public static List<Panel> KitchenPOSPanels = new List<Panel>();
        kitchenPOSSettings kitchenPosSettings = kitchenPOSSettings.getInstance();

        private static List<ItemCategory> itemCategoriesList = new List<ItemCategory>();
        private static List<ItemCategoryButton> itemCategoryButtonList = new List<ItemCategoryButton>();
        private static ItemCategoryButton buttonItemCategory;

        private static List<POSKICard> kitchenitemcardList = new List<POSKICard>();
        private static List<Item> itemsList = new List<Item>();
        private POSKICard kicard;

        private static List<BillItemRow> billItemList = new List<BillItemRow>();
        private static BillItemRow billItemRow;

        private double outAmount;

        private StockAudit stockAuditModel; //to record the stock out 

        private OnlineUser onlineUser = OnlineUser.getInstance();

        //for search
        private List<POSKICard> seachedItemList = new List<POSKICard>();
        private List<getSearchItems_Result> searchResult = new List<getSearchItems_Result>();
        private POSKICard serchedKiPosCard;
        

        private KitchenPOS()
        {
            InitializeComponent();
            initialAdd();
            kitchenPosSettings.ApplyThemes(Color.Black, Color.Black);

        }

        public static KitchenPOS getInstance()
        {
            if (uniqueInstance == null)
            {
                uniqueInstance = new KitchenPOS();
            }
            return uniqueInstance;
        }
        public void initialAdd()
        {
            //adding Pannels
            KitchenPOSPanels.Add(panelBottomKitchenPOS);
            KitchenPOSPanels.Add(flowCategoryButtons);
            KitchenPOSPanels.Add(flowKitchenItems);
            KitchenPOSPanels.Add(panelMainKitchenPOS);
            KitchenPOSPanels.Add(flowStockOut);

        }

        public void changeBackImage(int themenumber)
        {
            if (themenumber == 0)
            {
                this.BackgroundImage = Properties.Resources.Light;
            }
            else if (themenumber == 1)
            {
                this.BackgroundImage = Properties.Resources.posDark;
            }
        }



        private void btnPOSSettings_Click(object sender, EventArgs e)
        {

            kitchenPosSettings.Show();
            kitchenPosSettings.BringToFront();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = Login.getInstance();
            login.Show();
        }

        //method to load category buttons
        public void loadCategoryButtons()
        {
            //clear the list 
            itemCategoryButtonList.Clear();
            clearFlowcategorybutton();

            using (DBEntities db = new DBEntities())
            {
                itemCategoriesList = db.ItemCategories.Where(x=>x.itemCategoryID.StartsWith("KIc")).ToList();
            }

            foreach (ItemCategory Item in itemCategoriesList)
            {
                //creating new Button
                buttonItemCategory = new ItemCategoryButton();

                buttonItemCategory.ItemButtonName = Item.categoryName;
                buttonItemCategory.ItemButtonID = Item.itemCategoryID;

                //add button to the List 
                itemCategoryButtonList.Add(buttonItemCategory);
            }

            //load button list to the flow panel 
            foreach (ItemCategoryButton Item in itemCategoryButtonList)
            {
                flowCategoryButtons.Controls.Add(Item);
            }
        }//end of the method 

        //method to display filtered kitchenitem list
        public void filterFoodCards(String categoryID)
        {
            //clear the card list 
            kitchenitemcardList.Clear();
            flowKitchenItems.Controls.Clear();

            using (DBEntities db = new DBEntities())
            {
                itemsList = db.Items.Where(x => x.categoryID == categoryID).ToList(); ;

                foreach (Item Item in itemsList)
                {
                    //creating new card 
                    kicard = new POSKICard();

                    kicard.KItemName = Item.name;
                    kicard.KItemCardID = Item.itemID;
                    kicard.KItemPrice = Item.purchase_price.ToString();
                    kicard.ItemImage = Util.convertBinaryToImage(Item.image);
                    kicard.MeasurementUnit = Item.unitOfMeasurement;
                    //adding card to the list
                    kitchenitemcardList.Add(kicard);

                }

            }


            //adding cards to the flow panel
            foreach (POSKICard card in kitchenitemcardList)
            {
                flowKitchenItems.Controls.Add(card);
            }

        }//

        //method to clear flow layout panel
        public void clearFlowcategorybutton()
        {
            flowCategoryButtons.Controls.Clear();
        }

        //method to stock out rowa 
        public void addToStockOutList(String id, String name, String price, String measureUnit)
        {

            billItemRow = new BillItemRow();
            billItemRow.billrowID = id;
            billItemRow.ItemName = name;
            billItemRow.measurementUnit = measureUnit;
            billItemRow.Quantity = 1.ToString(); ; //this should be changed 
            billItemRow.total = price;
            billItemRow.purchasePrice = price; //price of a one food ite
            billItemList.Add(billItemRow);
            loadBilllist();

        }

        public void loadBilllist()
        {
            flowStockOut.Controls.Clear(); //clearing the panel 

            foreach (BillItemRow row in billItemList)
            {
                flowStockOut.Controls.Add(row);
            }

        }


        public void incrementByOne(String billRowId, String price)
        {
            int index  = billItemList.FindIndex(x => x.billrowID == billRowId);
            if (index < 0)
            {
                MessageBox.Show("Error in getting the index of the list item");
            }else
            {               
                double unitprice = Double.Parse(price);
                double total;

                int qty = Int32.Parse(billItemRow.Quantity);
                qty = qty + 1;
      
                total = qty * unitprice;
                    

                billItemList[index].total = total.ToString();
                billItemList[index].Quantity = qty.ToString();
              
                setStockoutAmount();
                loadBilllist(); //load the bill list again
            }
           
        }

        //method to decrement row details by one 
        public void decrementByOne(String billRowId, String price)
        {
            int index = billItemList.FindIndex(x => x.billrowID == billRowId);
            if (index < 0)
            {
                MessageBox.Show("Error in getting the index of the list item");
            }else
            {
                double unitprice = Double.Parse(billItemList[index].purchasePrice);
                double total;
                bool res = Double.TryParse(billItemRow.total, out total);
                if (res == false)
                {
                    MessageBox.Show("Cannot increment");
                }
                else
                {
                    total = total - unitprice;
                }
                int qty = Int32.Parse(billItemRow.Quantity);
                qty = qty - 1;
                //update bill row details 
                billItemList[index].total = total.ToString();
                billItemList[index].Quantity = qty.ToString();

                if (Int32.Parse(billItemRow.Quantity) == 0)
                {
                    billItemList.Remove(billItemRow);//remove the bill roe
                                                     //if quantity is 0
                }
                setStockoutAmount();
                loadBilllist(); //load the bill list again
            }
           
        }

        public void setStockoutAmount()
        {
            outAmount = 0.0; //initializing 
            foreach (BillItemRow row in billItemList)
            {
                outAmount = outAmount + Double.Parse(row.total);
            }

              lblOutAmount.Text = outAmount.ToString();
        }
       
        private void KitchenPOS_Load(object sender, EventArgs e)
        {
            loadCategoryButtons();
        }
        private void btnLogout_Click_1(object sender, EventArgs e)
        {
            Login lf = Login.getInstance();
            lf.Show();
            this.Close();
        }

        private void btnRetriew_Click(object sender, EventArgs e)
        {
            //want to get the current billItemRows details appear in the panel
            //then we need to update the stock audit table
            //for each item    
            //prepare a row 
            //auto generate key for stockAudit
            //get the item id 
            //set curret time and the date 
            //get the item quantity
            //mark inOut as 0
            //set expire date to null

            performStockOut(billItemList);

        }

        //method to remove the selected items from the stock
        private void performStockOut(List<BillItemRow> outList)
        {

            using(DBEntities db = new DBEntities())
            {
                foreach (BillItemRow Item in outList)
                {
                    stockAuditModel = new StockAudit(); //creating a new stock audit row 

                    //auto generating an stock audit id 
                    stockAuditModel.stockAuditID = Util.generateKey("stock");
                    stockAuditModel.itemID = Item.billrowID;

                    stockAuditModel.date = DateTime.Today;
                    stockAuditModel.time = DateTime.Now.TimeOfDay;

                    stockAuditModel.quantity = Int32.Parse(Item.Quantity);
                    stockAuditModel.inOut = false; //indicating this is a stock out 
                    stockAuditModel.expireDate = null;

                    //we need to check whether that any of item has cross thier limit quantities as well         
                   
                       

                    bool r = Util.checkForLimitCross(billItemRow.billrowID); //equals to the item id
                    if (r)
                    {
                        //adding new record to the stockAudit
                        db.StockAudits.Add(stockAuditModel);
                        db.SaveChanges();
                    }
                    else
                    {
                        continue;
                    }
                }

            }
            MessageBox.Show("Stock Updated Successfully ");
        }

        public void setOnlineUserDetails()
        {
            Employee emp = new Employee();
            emp = onlineUser.getAvailableEmployee();
            picBoxUserImage.Image = Util.convertBinaryToImage(emp.image);
            llblUserName.Text = emp.fname + " " + emp.lname;
        }

        private void picBoxSearchItem_Click(object sender, EventArgs e)
        {
            loadSearchedItems();
        }

        public void loadSearchedItems()
        {
            seachedItemList.Clear();
            flowKitchenItems.Controls.Clear();
            String keyword = itemSerach.text;
            using(DBEntities db = new DBEntities())
            {
                searchResult = db.getSearchItems(keyword).ToList();
            }
            //filling cards 
            foreach(getSearchItems_Result item  in searchResult)
            {
                serchedKiPosCard = new POSKICard();
                serchedKiPosCard.MeasurementUnit = item.unitOfMeasurement;
                serchedKiPosCard.KItemCardID = item.itemID;
                serchedKiPosCard.KItemName = item.name;
                serchedKiPosCard.KItemPrice = item.purchase_price.ToString();
                serchedKiPosCard.ItemImage = Util.convertBinaryToImage(item.image);

                seachedItemList.Add(serchedKiPosCard);

            }

            foreach(POSKICard card in seachedItemList)
            {
                flowKitchenItems.Controls.Add(card);
            }


        }

        private void btnexpOrders_Click(object sender, EventArgs e)
        {
            Eventmanagement.headChefBookedEventViews emh = new Eventmanagement.headChefBookedEventViews();
            this.Hide();
            emh.Show();
        }

        
    }
}
