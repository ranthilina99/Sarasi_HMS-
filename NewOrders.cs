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
    public partial class NewOrders : Form
    {
        private static NewOrders uniqueInstance = null;


        private List<ordersToBePrepared> ordersIDListToprepare = new List<ordersToBePrepared>();
        private List<getOrderedItems1_Result> orderstoPrepare = new List<getOrderedItems1_Result>();
        private List<getOrderedItems1_Result> orderedFoodItems = new List<getOrderedItems1_Result>();
        private newOrderToPrepare newOrdercard;
        private List<newOrderToPrepare> newOrderCardList = new List<newOrderToPrepare>();

        private ordersToBePrepared deletingOrder; //to perform delete

        private NewOrders()
        {
            InitializeComponent();
        }

        public static NewOrders getInstance()
        {
            if (uniqueInstance == null)
            {
                uniqueInstance = new NewOrders();
            }
            return uniqueInstance;
        }



        //method to load orders 
        public void loadOrders()
        {
            newOrderCardList.Clear();

            //need to retriew the information about the orders to be prepared 
            using (DBEntities db = new DBEntities())
            {
                ordersIDListToprepare = db.ordersToBePrepareds.ToList();


                foreach (ordersToBePrepared orders in ordersIDListToprepare)
                {
                    orderstoPrepare = db.getOrderedItems1(orders.orderID).ToList();
                    //  orderstoPrepare.AddRange(orderedFoodItems);

                    newOrdercard = new newOrderToPrepare();
                    newOrdercard.orderId = orders.orderID;

                    String orderlistString = "";

                    foreach (getOrderedItems1_Result item in orderstoPrepare)
                    {
                        String row = "| " + item.name + " - " + item.quantity + "\n";
                        orderlistString = orderlistString + row; //we have to set the ordered item list here                         
                    }

                    newOrdercard.orderContent = orderlistString;
                     orderlistString = "";

                    newOrderCardList.Add(newOrdercard);
                }
            }

            foreach (newOrderToPrepare card in newOrderCardList)
            {
                flowOrders.Controls.Add(card);
            }
        }

        private void NewOrders_Load(object sender, EventArgs e)
        {
            loadOrders();
        }

        private void btnBackNewOrders_Click(object sender, EventArgs e)
        {
            StockManagement sm = StockManagement.getInstance();
            this.Hide();
            sm.Show();
        }

        public void clearFlowLyout()
        {
            flowOrders.Controls.Clear();
        }

        public void deleteAfterServed(String id)
        {
            using (DBEntities db = new DBEntities())
            {
                //getting the object whichh need to be deleted 
                deletingOrder = db.ordersToBePrepareds.Where(fc => fc.orderID == id).First();
                //delete the object 
                db.ordersToBePrepareds.Remove(deletingOrder);
                db.SaveChanges();

            }
            MessageBox.Show("Order Served!!!");

            //refreshing......
            clearFlowLyout();
            loadOrders();
        }

        
        
    }
}
