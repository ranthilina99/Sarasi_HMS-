using Guna.UI.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;


namespace Sarasi_HMS
{
    public partial class AddFoodCategory : Form
    {
        private static AddFoodCategory uniqueInstance = null;
        private static String status = "insert"; //add or update

        FoodCategory foodCategory = new FoodCategory(); //instance of the table 

        private AddFoodCategory()
        {
            InitializeComponent();
            changeBackImage(0);
        }

        public static AddFoodCategory getInstance()
        {
            if (uniqueInstance == null)
            {
                uniqueInstance = new AddFoodCategory();
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


        private void btnCancel_Click(object sender, EventArgs e)
        {
            Categories categories = Categories.getInstance();
            categories.clearCatgoryList();
            categories.loadFoodCategories();
            this.Hide();
            categories.Show();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateFormDetails())
            {
                //taking the user inputs and preparing the object 
                foodCategory.foodCategoryID = txtCategoryID.Text;
                foodCategory.name = txtCategoryName.Text;
                foodCategory.description = txtCategoryDescription.Text;

                using (DBEntities db = new DBEntities())
                {
                    if (status == "insert")
                    {
                        db.FoodCategories.Add(foodCategory);

                        MessageBox.Show("Category Added Successfully");
                    }
                    else if (status == "update")
                    {
                        //updating the database 
                        db.Entry(foodCategory).State = EntityState.Modified;

                        MessageBox.Show("Category Updated Successfully");
                        
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



                    clearTexts();

                }
                //addding new Item to the Restaurant POS as a button
                RestaurantPOS.getInstance().loadCategoryButtons();


                ///-------clear the flow layout and re load the category list 
                Categories categories = Categories.getInstance();
                categories.clearCatgoryList();
                categories.loadFoodCategories();
                categories.Show();
                this.Hide();
            }//end of if
          
        } // end of brnSave clicked event 


        //*****************************Validating The form **********
        public bool validateFormDetails()
        {
            bool flag = false;
            if (String.IsNullOrEmpty(txtCategoryID.Text.Trim()))
            {
                MessageBox.Show("please enter Category Id ", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else if (String.IsNullOrEmpty(txtCategoryName.Text.Trim()))
            { 
                MessageBox.Show("please enter Category name ", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (Int32.TryParse(txtCategoryName.Text, out var res))
                {
                    MessageBox.Show("Category Name cannot be a number", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    flag = true;
                }
            }
            return flag;
        }


        //method to edit category details 
        public  void editcategory(String id)
        {
            //retreiving selected row 
            using(DBEntities db = new DBEntities())
            {
  
                foodCategory = db.FoodCategories.Where(x => x.foodCategoryID == id).FirstOrDefault();
               //storing values to the textboxes
                txtCategoryID.Text = foodCategory.foodCategoryID;
                txtCategoryName.Text = foodCategory.name;
                txtCategoryDescription.Text = foodCategory.description;
            
            }
        }//end of edit item category method

    

        public void clearTexts()
        {
            txtCategoryDescription.Text = txtCategoryID.Text = txtCategoryName.Text = "";
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            
            String result = Util.generateKey("FoodCategory");
            MessageBox.Show(result);
            txtCategoryID.Text = result;
        }

        public void updateStatus(String state)
        {
            if (state == "insert")
            {
                status = "insert";
                btnSave.Text = "Save";
                clearTexts();

            }else if (state == "update")
            {
                status = "update";
                btnSave.Text = "Update";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtCategoryDescription.Text = "newly added category";
            txtCategoryName.Text = "Noodles";

        }
    }
}
