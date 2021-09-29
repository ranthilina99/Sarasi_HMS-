
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

    public partial class RestaurantPOS : Form
    {
        //unique instance 
        private static RestaurantPOS uniqueInstance = null;

            //List of Controls
        public static List<Panel> ResPOSPanels = new List<Panel>();
        public static List<Button> ResPOSButtons = new List<Button>();

        //list of category Buttons
        private static List<foodcategoryButton> foodCategoryButtonList = new List<foodcategoryButton>();
      
        private static List<FoodCategory> foodCategoryList = new List<FoodCategory>();
        private static foodcategoryButton foodcategorybutton;

        private static List<ItemCategory> readyMadecategoryList = new List<ItemCategory>();
        private static List<ItemCategoryButton> readyMadeCategoryBtnList = new List<ItemCategoryButton>();
        private static ItemCategoryButton readyMAdeCategoryBtn;

        POSsettings posSettings = POSsettings.getInstance();

        private List<Food> foodItems = new List<Food>();
        private List<POSFoodCard> posFoodCards = new List<POSFoodCard>();
        private POSFoodCard cardpos;

        private List<Item> readyMadeProducts = new List<Item>();
        private static List<POSKICard> posProducrtCard = new List<POSKICard>();
        private static POSKICard cardProduct;
        private static ReadyMadeProduct readyMAde;

        private List<BillRow> billrowList = new List<BillRow>();
        private BillRow billrow; //billrow card 
       
        public double amountToPay;

        //for add order details to the table - row objects 
        Order_ orderModel = new Order_();
        OrderFood orderFoodModel;
        OrderReadymadeProduct orderReadymadeModel;

        private OnlineUser onlineUser = OnlineUser.getInstance();

        //search 
        private List<POSFoodCard> searchedFoodsList = new List<POSFoodCard>();
        private List<getSearchFood_Result> searchResult = new List<getSearchFood_Result>();
        private POSFoodCard resPosCard;



        private RestaurantPOS()
        {
            InitializeComponent();
            initialAdd();

            posSettings.ApplyThemes(Color.Black, Color.Black);
        }

        public static RestaurantPOS getInstance()
        {
            if (uniqueInstance == null)
            {
                uniqueInstance = new RestaurantPOS();
            }
            return uniqueInstance;
        }
        private void initialAdd()
        {
            //panels
            ResPOSPanels.Add(flowPanelCategories);
            ResPOSPanels.Add(flowPanelFoods);
            ResPOSPanels.Add(panelMainResPOS);
            ResPOSPanels.Add(panelBottomResPOS);
            ResPOSPanels.Add(flowpanelBill);
            ResPOSPanels.Add(panelTotal);
            Settings.AllPanels.AddRange(ResPOSPanels);

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

        private void flowPanelFoods_Paint(object sender, PaintEventArgs e)
        { 
        }

        private void btnPOSSettings_Click(object sender, EventArgs e)
        {         
            posSettings.Show();
            posSettings.BringToFront();
           
        }

        private void RestaurantPOS_Load(object sender, EventArgs e)
        {
            //formload 
            loadCategoryButtons();
            setOnlineUserDetails();

        }

        //----------Manage Category buttons-
        public  void loadCategoryButtons()
        {
            //clear the list 
            foodCategoryButtonList.Clear();
            clearFlowcategorybutton();
            using (DBEntities db = new DBEntities())
            {
                foodCategoryList = db.FoodCategories.ToList();
                readyMadecategoryList = db.ItemCategories.Where(x => x.itemCategoryID.StartsWith("RPc")).ToList();

            }

            //adding Category buttons ==============================================================================
            foreach(FoodCategory Item in foodCategoryList)
            {
                //creating new Button
                foodcategorybutton = new foodcategoryButton();
                foodcategorybutton.ButtonName = Item.name;
                foodcategorybutton.ButtonID = Item.foodCategoryID; 
                //add button to the List 
                foodCategoryButtonList.Add(foodcategorybutton);
            }   

            //load food category button list to the flow panel 
            foreach(foodcategoryButton Item in foodCategoryButtonList)
            {
                flowPanelCategories.Controls.Add(Item);
            }


            //Adding ReadyMade products
            foreach(ItemCategory product in readyMadecategoryList)
            {
                //ceating new RP button 
                readyMAdeCategoryBtn = new ItemCategoryButton();
                readyMAdeCategoryBtn.ItemButtonName = product.categoryName;
                readyMAdeCategoryBtn.ItemButtonID = product.itemCategoryID;

                readyMadeCategoryBtnList.Add(readyMAdeCategoryBtn);
            }
            //adding to panel
            foreach (ItemCategoryButton Item in readyMadeCategoryBtnList)
            {
                flowPanelCategories.Controls.Add(Item);
            }

        } //======================================================================================================

        public void clearFlowcategorybutton()
        {
            flowPanelCategories.Controls.Clear();
        }

        public void reset()
        {
            billrowList.Clear();
            flowpanelBill.Controls.Clear();
            lblAmountToPay.Text = "0.00";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelFood_Click(object sender, EventArgs e)
        {
            // reset();

            //Guest_Mange guest = new Guest_Mange();
            //guest.Show();
            //this.Close();

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = Login.getInstance();
            login.Show();
        }

        //method to filter the Items/Foods
        public void filterFoodCards(String categoryID)
        {
            //clear the card list 
            posFoodCards.Clear();
            posProducrtCard.Clear();
            flowPanelFoods.Controls.Clear();

            using (DBEntities db = new DBEntities())
            {
                foodItems = db.Foods.Where(x => x.categoryID == categoryID).ToList();
                readyMadeProducts = db.Items.Where(y => y.categoryID == categoryID).ToList();
                

                foreach (Food Item in foodItems)
                {
                    //creating new card 
                    cardpos = new POSFoodCard();
                    cardpos.foodName = Item.name;
                    cardpos.foodCardID = Item.foodCode;
                    cardpos.foodPrice = Item.sellingPrice.ToString();
                    cardpos.foodImage = Util.convertBinaryToImage(Item.foodImage);
                    //adding card to the list
                    posFoodCards.Add(cardpos);

                }

                foreach(Item item in readyMadeProducts)
                {
                    cardProduct = new POSKICard();

                    cardProduct.KItemName = item.name;
                    cardProduct.KItemCardID = item.itemID;
                    //getting the selling price ...
                    readyMAde = db.ReadyMadeProducts.Where(s => s.productID == item.itemID).FirstOrDefault();
                    cardProduct.KItemPrice = readyMAde.sellingPrice.ToString();

                    cardProduct.ItemImage = Util.convertBinaryToImage(item.image);

                    posProducrtCard.Add(cardProduct);
                }
            
            }


            //adding Food cards to the flow panel
            foreach (POSFoodCard card in posFoodCards)
            {
                flowPanelFoods.Controls.Add(card);
            }

            //adding Product cards to the flow panel
            foreach (POSKICard card in posProducrtCard)
            {
                flowPanelFoods.Controls.Add(card);
            }


        }//end of filtering method 

        //method to add bill row 
        public void addToBillList(String id,String name, String price)
        {
            
            billrow = new BillRow();
            billrow.billrowID = id;
            billrow.FoodName = name;
            billrow.Quantity = 1.ToString(); ; //this should be changed 
            billrow.total = price;
            billrow.unitPrice = price; //price of a one food ite
            billrowList.Add(billrow);
            loadBilllist();

        }

        //method to increment row details by one 
        public void incrementByOne(String billRowId, String price)
        {
            int index = billrowList.FindIndex(x => x.billrowID == billRowId);
            if (index < 0)
            {
                MessageBox.Show("Error in getting the index of the list item");
            }
            else
            {
                // double unitprice = Double.Parse(billrow.unitPrice);
                double unitprice = Double.Parse(price);
                double total;

                int qty = Int32.Parse(billrowList[index].Quantity);
                qty = qty + 1;
                total = qty * unitprice;
                
                //updating bill row 
                billrowList[index].total = total.ToString();
                billrowList[index].Quantity = qty.ToString();

                setAmountToPay();
                loadBilllist(); //load the bill list again

            }//end of else part
        }


        //method to decrement row details by one 
        public void decrementByOne(String billRowId, String price)
        {
            int index = billrowList.FindIndex(x => x.billrowID == billRowId);
            if(index<0)
            {
                MessageBox.Show("Error in getting the index of the list item");
            }
            else
            {
                double unitprice = Double.Parse(billrowList[index].unitPrice);
                double total;

                bool res = Double.TryParse(billrowList[index].total, out total);
                if (res == false)
                {
                    MessageBox.Show("Cannot increment");
                }
                else
                {
                    total = total - unitprice;
                    //assign it to text field again
                    // billrow.total = total.ToString();
                }
                int qty = Int32.Parse(billrow.Quantity);
                qty = qty - 1;
                //update bill row details 
                  billrowList[index].total = total.ToString();
                  billrowList[index].Quantity = qty.ToString();
 
                
                if (Int32.Parse(billrow.Quantity) == 0)
                {
                    billrowList.Remove(billrow);//remove the bill roe
                                                //if quantity is 0
                }

                setAmountToPay();
                loadBilllist(); //load the bill list again      

            }
             
        }

        public void loadBilllist()
        {
            flowpanelBill.Controls.Clear(); //clearing the panel 

            foreach(BillRow row in billrowList)
            {
                flowpanelBill.Controls.Add(row);
            }
            
        }

        //method to Add Amount to Pay 
        public void setAmountToPay()
        {
            amountToPay = 0.0; //initializing 
            foreach (BillRow row in billrowList)
            {
                amountToPay = amountToPay + Double.Parse(row.total);
            }

            lblAmountToPay.Text = amountToPay.ToString();
        }
        private void btnPurchase_Click(object sender, EventArgs e)
        {
            
            String order_id = addOrderToTable();
            Cachier c = Cachier.getInstance();
            c.setTotalFromPos(amountToPay,order_id);
            c.updateInitialValues();
            this.Hide();
            c.Show();

            reset();
        }

        //method to add order details to table 
        public String addOrderToTable()
        {
            using(DBEntities db = new DBEntities())
            {
                orderModel.orderID = Util.generateKey("orders");
                orderModel.recordBy = "recep1";
                orderModel.date = DateTime.Today;
                orderModel.time = DateTime.Now.TimeOfDay;
                orderModel.amount = (float) amountToPay;

                addBillDetailsToTable(orderModel.orderID);

                db.Order_.Add(orderModel);
                db.SaveChanges();

                MessageBox.Show("Order Added Successfully !!!");

            }
            return orderModel.orderID;
        }



        //method to get the information about the ordered items Quantity and thier prices
        public void addBillDetailsToTable(String orderId)
        {
            using(DBEntities db = new DBEntities())
            {
                foreach(BillRow row in billrowList)
                {
                    orderReadymadeModel = new OrderReadymadeProduct();
                    orderFoodModel = new OrderFood();
                    String id = row.billrowID;
                    if (id.StartsWith("RP"))
                    {
                        orderReadymadeModel.orderID = orderId;
                        orderReadymadeModel.productID = row.billrowID; ;
                        orderReadymadeModel.quantity = Int32.Parse(row.Quantity);
                        orderReadymadeModel.total = (float) double.Parse(row.total);

                        db.OrderReadymadeProducts.Add(orderReadymadeModel);
                        db.SaveChanges();
                        MessageBox.Show("OrderFood Added");

                    }
                    else if (id.StartsWith("F"))
                    {
                        orderFoodModel.orderID = orderId;
                        orderFoodModel.foodID = row.billrowID;
                        orderFoodModel.quantity = Int32.Parse(row.Quantity);
                        orderFoodModel.total = (float)double.Parse(row.total);
                        db.OrderFoods.Add(orderFoodModel);
                        db.SaveChanges();

                    }                  
                    MessageBox.Show("Items Added to the table");
                }
            }
        }

        public void setOnlineUserDetails()
        {
            Employee emp = new Employee();
            emp = onlineUser.getAvailableEmployee();
            picBoxUserImage.Image = Util.convertBinaryToImage(emp.image);
            llblUserName.Text = emp.fname + " " + emp.lname;
        }

        private void btn_add_guest_Click(object sender, EventArgs e)
        {
           

           
        }

  

        private void picBoxSearchFood_Click(object sender, EventArgs e)
        {
            loadSearchedItems();

        }

        //method to search foods 

        public void loadSearchedItems()
        {
            searchedFoodsList.Clear();
            flowPanelFoods.Controls.Clear();
            String keyword = foodSerach.text;
            using (DBEntities db = new DBEntities())
            {
                searchResult = db.getSearchFood(keyword).ToList();
            }
            //filling cards 
            foreach (getSearchFood_Result item in searchResult)
            {
                resPosCard = new POSFoodCard();

                resPosCard.foodCardID = item.foodCode;
                resPosCard.foodName = item.name;
                resPosCard.foodPrice = item.sellingPrice.ToString();
                resPosCard.foodImage = Util.convertBinaryToImage(item.foodImage);

                searchedFoodsList.Add(resPosCard);

            }

            foreach (POSFoodCard card in searchedFoodsList)
            {
                flowPanelFoods.Controls.Add(card);
            }

        }

        }//end of class 

    }
