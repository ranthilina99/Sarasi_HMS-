using Bunifu.Framework.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity.Validation;
using System.Data.Entity;


namespace Sarasi_HMS
{

    public partial class AddNewFood : Form
    {

        string fileName; 

        //unique instance 
        private static AddNewFood uniqueInstance = null;

        //list of controls
        public static List<TextBox> AddFoodTexts = new List<TextBox>(); //text Boxes 
        //bunifu Panels 
        public static List<BunifuGradientPanel> buniGradientAddFoodPanels = new List<BunifuGradientPanel>();
        //panels
        public static List<Panel> AddFoodPanels = new List<Panel>();
        //combo box
        public static List<ComboBox> AddFoodCombos = new List<ComboBox>();
        //picture Box
        public static List<PictureBox> AddFoodPicBoxes = new List<PictureBox>();

        //------------------------------------------------------------------
        FoodManagement foodManagement = FoodManagement.getInstance();
      
        private static string status = "food"; //used to identify the adding food or readyMade

        //Food - table Object  
        Food food = new Food();
        Item itemModel = new Item();
        ReadyMadeProduct readymaddModel = new ReadyMadeProduct();

        private static String operation = "save";

        private AddNewFood()
        {
            InitializeComponent();
            initialAdd();
            Settings.ApplyThemes(Color.Black, Color.Black, Settings.zColor(230, 255, 128), Color.White, Color.Chartreuse, Color.White, Color.Yellow, Color.White);

            setCategoryComboBox("meal");
            changeBackImage(0);

        }

        public static AddNewFood getInstance()
        {
            if (uniqueInstance == null)
            {
                uniqueInstance = new AddNewFood();
            }
            return uniqueInstance;
        }

        private void initialAdd()
        {
            //buniPanels
            buniGradientAddFoodPanels.Add(buniPanelTopAddFood);
           
            Settings.AllBuniPanels.AddRange(buniGradientAddFoodPanels);
         
         
            //textBoxes 
            AddFoodTexts.Add(txtDiscountRate);
            AddFoodTexts.Add(txtSellingPrice);
            AddFoodTexts.Add(txtDescription);
            AddFoodTexts.Add(txtName);
            AddFoodTexts.Add(txtFoodPurchasePrice);
            AddFoodTexts.Add(txtID);
            AddFoodTexts.Add(textReadymadeLimitQuantity);
        
            AddFoodTexts.Add(txtSellingPrice);

            Settings.AllTextBoxes.AddRange(AddFoodTexts);

            //combobox
            AddFoodCombos.Add(comboCategory);
            AddFoodCombos.Add(comboSupliers);
            Settings.AllComboBoxes.AddRange(AddFoodCombos);

            //pic Box
            AddFoodPicBoxes.Add(picBoxImage);
            Settings.AllPicBoxes.AddRange(AddFoodPicBoxes);

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


        private void radioMealItem_CheckedChanged_1(object sender, EventArgs e)
        {
            radioMealItemClicked();
        }
        private void radioMealItemClicked()
        {
            panelMealItem.Visible = true;
            panelRedyMade.Visible = false;
            status = "food";

            setCategoryComboBox("meal");
        }

        private void radioRedyMad_CheckedChanged_1(object sender, EventArgs e)
        {
            radioReadyMadeClicked();
        }

        private void radioReadyMadeClicked()
        {
            status = "readyMade";
            panelMealItem.Visible = false;
            panelRedyMade.Visible = true;
            //hiding description 
            lblDescription.Visible = false;
            txtDescription.Visible = false;
            name.Text = "Product Name";
            setCategoryComboBox("readyMade");
        }

        private void AddNewFood_Load(object sender, EventArgs e)
        {
            panelMealItem.Visible = true;
            panelRedyMade.Visible = false;
        }

        private void setCategoryComboBox(String type)
        {
            if (type == "meal")
            {
                comboCategory.DataSource = getFoodCategoryList();
                comboCategory.DisplayMember = "name";
            }else if (type == "readyMade")
            {
                comboCategory.DataSource = getItemCategoryList();
                comboCategory.DisplayMember = "categoryName";
            }     
        }

        //method to get food category list 
        private List<FoodCategory> getFoodCategoryList()
        {   //creating new List 
            List<FoodCategory> fclist = new List<FoodCategory>();

            using(DBEntities db = new DBEntities())
            {
                fclist = db.FoodCategories.ToList();
                
            }
            return fclist;
        }

        //method to get Item Category list
        private List<ItemCategory> getItemCategoryList()
        {   //creating new List 
            List<ItemCategory> Iclist = new List<ItemCategory>();

            using (DBEntities db = new DBEntities())
            {
                Iclist = db.ItemCategories.ToList();

            }
            return Iclist;
        }

        private void btnProductIDGenerate_Click_1(object sender, EventArgs e)
        {
            String result = Util.generateKey(status);
            MessageBox.Show(result);
            txtID.Text = result;
        }


        //Adding Item to the Data Base -----------------------
        private void btnSaveFoodItem_Click_1(object sender, EventArgs e)
        {
            if (status == "food") //adding meal/food details
            {
                //getting the user entered value 
                food.foodCode = txtID.Text;
                food.name = txtName.Text;
                food.description = txtDescription.Text;

                //setting selling price
                double sellingPrice;
                bool result1 = Double.TryParse(txtSellingPrice.Text, out sellingPrice);
                if (result1 == false)
                {
                    MessageBox.Show("Please enter Selling price");
                }
                else
                {
                    food.sellingPrice = (float)sellingPrice;
                }

                //setting discount rate
                double discountRate;
                bool result2 = Double.TryParse(txtDiscountRate.Text, out discountRate);
                if (result2 == false)
                {
                    MessageBox.Show("Please enter Discount Rate");
                }
                else
                {
                    food.disountRate = (float)discountRate;
                }

                //setting category id 
                String cid = Util.getCategoryID("FoodCategory", comboCategory.Text);
                food.categoryID = cid;

                //setting Image 
                food.foodImage = Util.convertImageToBinary(picBoxImage.Image);

                //****** saving informations to the database 
                using (DBEntities db = new DBEntities())
                {

                    if (operation == "save")
                    {

                        db.Foods.Add(food);
                        MessageBox.Show("Meal/Food Item Added Successfully!!!");

                    }
                    else if (operation == "update")
                    {
                        //updating the database 

                        db.Entry(food).State = EntityState.Modified;
                        MessageBox.Show("Food details Updated Successfully");
                    }

                    try
                    {
                        db.SaveChanges();
                    }
                    catch (System.Data.Entity.Validation.DbEntityValidationException ex)
                    {
                        foreach (var entityValidationErrors in ex.EntityValidationErrors)
                        {
                            foreach (var validationError in entityValidationErrors.ValidationErrors)
                            {
                                MessageBox.Show("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                            }
                        }
                    }


                    clear();
                }
            }
            else if (status == "readyMade") //addimng a readymade product details
            {
                //setting values to the row object 
                itemModel.itemID = txtID.Text;
                itemModel.name = txtName.Text;

                //setting purchase price
                double purchaseprice;
                bool result3 = Double.TryParse(txtFoodPurchasePrice.Text, out purchaseprice);
                if (result3 == false)
                {
                    MessageBox.Show("Please enter Purchase price");
                }
                else
                {
                    itemModel.purchase_price = (float)purchaseprice;
                }

                itemModel.suppliedBy = null; //this shold be implemented After adding supplier table
                itemModel.limitQuantity = Int32.Parse(textReadymadeLimitQuantity.Text);

                //setting category id 
                String cid = Util.getCategoryID("ItemCategory", comboCategory.Text);
                itemModel.categoryID = cid;

                //setting Image 
                itemModel.image = Util.convertImageToBinary(picBoxImage.Image);


                //************* details adding to readyMAde product table *
                readymaddModel.productID = txtID.Text;
                //setting selling price of the product
                double productSellPrice;
                bool result4 = Double.TryParse(txtReadyMadeSellingPrice.Text, out productSellPrice);
                if (result4 == false)
                {
                    MessageBox.Show("Please enter Selling  price of the product");
                }
                else
                {
                    readymaddModel.sellingPrice = (float)productSellPrice;
                }
                //*************

                using (DBEntities db = new DBEntities())
                {
                    db.Items.Add(itemModel);
                    db.ReadyMadeProducts.Add(readymaddModel);
                    db.SaveChanges();

                    MessageBox.Show("Ready Made product Added Successfully");
                    clear();
                }

            }
            else
            {
                MessageBox.Show("Cannot identify !!! (rm or Food) ");
            }

            FoodManagement fm = FoodManagement.getInstance();
            fm.clearFoodcardpanel();
            fm.loadFoodItemCards();
            this.Hide();
            fm.Show();

        }// --------------------------------------------------------------------------------------------


        //method to edit food details
        public void editcategory(String id)
        {
            //retreiving selected row 
            using (DBEntities db = new DBEntities())
            { 
                food = db.Foods.Where(x => x.foodCode == id).FirstOrDefault();
                MessageBox.Show(food.foodCode);

                //storing values to the textboxes
                txtID.Text = food.foodCode;
                txtName.Text = food.name;
                txtDescription.Text = food.description;
                txtSellingPrice.Text = food.sellingPrice.ToString();
                txtDiscountRate.Text = food.disountRate.ToString();

                picBoxImage.Image = Util.convertBinaryToImage(food.foodImage);

                if (id.StartsWith("F"))
                {
                    radioMealItemClicked();
                }
                else if (id.StartsWith("RP"))
                {
                    radioReadyMadeClicked();
                }

            }
        }//end of edit Food details method

        //method to create AddnewFoodForm
        public void clear()
        {
            txtID.Text = txtName.Text = txtDescription.Text = txtSellingPrice.Text = txtDiscountRate.Text =
                txtFoodPurchasePrice.Text = txtReadyMadeSellingPrice.Text =textReadymadeLimitQuantity.Text= "";
             picBoxImage.Image = null;
        }


        private void btnbrowseImage_Click_1(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "JPEG|*.jpg", ValidateNames = true, Multiselect = false })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    fileName = ofd.FileName;
                    picBoxImage.Image = Image.FromFile(fileName);
                }
            }
        }

        public void updateStatus(String operati)
        {
            if (operati == "save")
            {
                operation = "save";
                btnSaveFoodItem.Text = "Save";
                //clearForm();

            }
            else if (operati == "update")
            {
                operation = "update";
                btnSaveFoodItem.Text = "Update";

            }
        }

        private void btnBackfromAddFood_Click_1(object sender, EventArgs e)
        {
            foodManagement.clearFoodcardpanel();
            foodManagement.loadFoodItemCards();
            this.Hide();
            foodManagement.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtDescription.Text = " small description";
            txtDiscountRate.Text = 1.ToString();
            txtFoodPurchasePrice.Text = 300.ToString();
            txtName.Text = "Chineese Noodles";
            txtReadyMadeSellingPrice.Text = "250";
            txtSellingPrice.Text = "200";
            comboCategory.Text = "Fc611";
            comboSupliers.Text = "s21";
        }
    }//end of class
}
