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
    public partial class AddNewItem : Form
    {
        private static AddNewItem uniqueInstance = null;

        Item itemRow = new Item();
        String fileName;
        String operation = "save";

        private AddNewItem()
        {
            InitializeComponent();
            changeBackImage(0);
        }

        public static AddNewItem getInstance()
        {
            if (uniqueInstance == null)
            {
                uniqueInstance = new AddNewItem();
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


        private void btnSave_Click(object sender, EventArgs e)
        {

            if (validateForm())
            {

                itemRow.itemID = txtItemID.Text;
                itemRow.name = txtItemName.Text;
                itemRow.limitQuantity = Int32.Parse(txtLimit.Text);
                itemRow.unitOfMeasurement = txtUnitOfMesasure.Text; //#########


                double purchasePrice;
                bool res1 = Double.TryParse(txtPurchacePrice.Text, out purchasePrice);
                if (res1 == false)
                {
                    MessageBox.Show("please Fill the purchase price");
                }
                else
                {
                    itemRow.purchase_price = (float)purchasePrice;
                }



                itemRow.unitOfMeasurement = txtUnitOfMesasure.Text;
                //setting category id 
                String cid = Util.getCategoryID("ItemCategory", comboItemcategories.Text);
                MessageBox.Show(cid);
                itemRow.categoryID = cid;

                itemRow.image = Util.convertImageToBinary(picBocitempic.Image);

                using (DBEntities db = new DBEntities())
                {

                    if (operation == "save")
                    {
                        db.Items.Add(itemRow);
                        MessageBox.Show("Item Added Successfully");

                    }
                    else if (operation == "update")
                    {
                        db.Entry(itemRow).State = EntityState.Modified;
                        MessageBox.Show("Item details Updated Successfully");
                    }

                    db.SaveChanges();
                }

                StockManagement sm = StockManagement.getInstance();
                sm.clearItemList();
                sm.loadKitchenItems();
                this.Hide();
                sm.Show();
            }
          
          
        }//end of save method 


        public Boolean validateForm()
        {
            Boolean flag = false;
            if (String.IsNullOrEmpty(txtItemID.Text.Trim()))
            {
                MessageBox.Show("Item ID   cannot be Empty  ");
            }
            else
            {
                flag = true;
            }
            return flag;
        }

        private void setCategoryComboBox()
        { 
            comboItemcategories.DataSource = getItemCategoryList();
            comboItemcategories.DisplayMember = "categoryName";
        }

        //method to get food category list 
        private List<ItemCategory> getItemCategoryList()
        {   //creating new List 
            List<ItemCategory> Iclist = new List<ItemCategory>();

            using (DBEntities db = new DBEntities())
            {
                Iclist = db.ItemCategories.ToList();

            }
            return Iclist;
        }
        private void setSupplierComboBox()
        {
            comBoSupplier.DataSource = getSupplierList();
            comBoSupplier.DisplayMember = "Name";

        }



        private List<Supplier> getSupplierList()
        {   //creating new List 
            List<Supplier> SupplierList = new List<Supplier>();

            using (DBEntities db = new DBEntities())
            {
                SupplierList = db.Suppliers.ToList();

            }
            return SupplierList;
        }

        private void AddNewItem_Load(object sender, EventArgs e)
        {
            setCategoryComboBox();
            setSupplierComboBox();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "JPEG|*.jpg", ValidateNames = true, Multiselect = false })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    fileName = ofd.FileName;
                    picBocitempic.Image = Image.FromFile(fileName);
                }
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            txtItemID.Text = Util.generateKey("item");
        }

        //method to edit food details
        public void editItem(String id)
        {
            //retreiving selected row 
            using (DBEntities db = new DBEntities())
            {
                itemRow = db.Items.Where(x => x.itemID == id).FirstOrDefault();
               
                //storing values to the textboxes
                txtItemID.Text = itemRow.itemID;
                txtItemName.Text = itemRow.name;
                txtLimit.Text = itemRow.limitQuantity.ToString();
                txtPurchacePrice.Text = itemRow.purchase_price.ToString();
                comBoSupplier.Text = itemRow.suppliedBy;
                picBocitempic.Image = Util.convertBinaryToImage(itemRow.image);
               
            }
        }//end of edit Food details method

        private void btnBack_Click(object sender, EventArgs e)
        {
            StockManagement sm = StockManagement.getInstance();
            sm.clearItemList();
            sm.loadKitchenItems();
            this.Hide();
            sm.Show();
        }

        public void updateStatus(String state)
        {
            if (state == "save")
            {
                operation = "save";
                btnSave.Text = "Save";
                clear();
            }
            else if (state == "update")
            {
                operation = "update";
                btnSave.Text = "Update";
            }
        }

        //method to clear all textBoxe 
        public void clear()
        {
            txtItemID.Text = txtItemName.Text = txtLimit.Text = txtPurchacePrice.Text = txtUnitOfMesasure.Text = "";
            comBoSupplier.Text = "";
        }

        private void btnDemo_Click(object sender, EventArgs e)
        {
            txtItemName.Text = "demo name";
            txtLimit.Text = 4.ToString();
            txtPurchacePrice.Text = 500.ToString();
            txtUnitOfMesasure.Text="Kg";
            comBoSupplier.Text = "Saman";
            comboItemcategories.Text = "KIc5506";


        }

        // add validatoins

        private void txtPurchacePrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if(!Char.IsDigit(ch)&& ch != 8)
            {
                e.Handled = true;
                MessageBox.Show("Can't Enter String as Purchased price !!!");

            }
        }

        private void txtLimit_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
                MessageBox.Show("Can't Enter String as Item Limit !!!");

            }
        }
    }
}
