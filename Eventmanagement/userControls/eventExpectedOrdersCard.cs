using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sarasi_HMS.Eventmanagement.userControls
{
    public partial class eventExpectedOrdersCard : UserControl
    {
        public eventExpectedOrdersCard()
        {
            InitializeComponent();
        }
        public string OrderID
        {
            get { return txtOrderIDC.Text; }
            set { txtOrderIDC.Text = value; }
        }

        public string BookedID
        {
            get { return txteventIDC.Text; }
            set { txteventIDC.Text = value; }
        }
        public string EventTime
        {
            get { return txteventTimeC.Text; }
            set { txteventTimeC.Text = value; }
        }



        public string EventDate
        {
            get { return txteventDateC.Text; }
            set { txteventDateC.Text = value; }
        }


        public string EventName
        {
            get { return txteventNameC.Text; }
            set { txteventNameC.Text = value; }
        }




        public string NoOfParti
        {
            get { return txtNoOfPartiC.Text; }
            set { txtNoOfPartiC.Text = value; }
        }

        public string FoodPackage
        {
            get { return txtpackageNameC.Text; }
            set { txtpackageNameC.Text = value; }
        }

        public string OrderList
        {
            get { return txtexpOrderListC.Text; }
            set { txtexpOrderListC.Text = value; }
        }

        private void btnExpOrdercardedit_Click(object sender, EventArgs e)
        {
            //getting the card id 
            String ExpOrdercard = this.OrderID;
            hChefAddOrderList ts = new hChefAddOrderList();
            chefEventExpectedOrdersView evp = new chefEventExpectedOrdersView();
            ts.editexpOrder(OrderID);
            ts.Show();
            this.Hide();
        }

        private void btnExpOrdercarddelete_Click(object sender, EventArgs e)
        {
            String cardID = this.OrderID; //getting the cliked card id 

            chefEventExpectedOrdersView ds = new chefEventExpectedOrdersView();
            ds.deleteExpOrder(cardID); //passing the Id 

            ds.clearExpecteOrderList();
            ds.DisplayExpectedOrders();
            hChefAddOrderList ade = new hChefAddOrderList();
            this.Hide();
            ade.Show();
        }
    }
}
