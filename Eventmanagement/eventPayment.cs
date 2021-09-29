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

namespace Sarasi_HMS.Eventmanagement
{
    public partial class eventPayment : Form
    {
        private static eventPayment uniqueinstance = null;

        private double Advance;
        private string typedPaidAmount = "";
        private String orderNumber;
        private double packageprice;
        private double decoAmount;
        private double Remaining;
        private double total;
        private int parti;

        EventPackage mod1 = new EventPackage(); //database table name
        BookedEvent ABE = new BookedEvent();
        DecorationTeam Dt = new DecorationTeam();
        expOrder exp = new expOrder();
        evPay ev = new evPay();
        private static String status = "insert";

        private eventPayment()
        {
            InitializeComponent();
        }
        public static eventPayment getInstance()
        {
            if (uniqueinstance == null)
            {
                uniqueinstance = new eventPayment();
            }

            return uniqueinstance;
        }

        public void calculat(String id)
        {
            using (DBEntities db = new DBEntities())
            {
                ABE = db.BookedEvents.Where(x => x.eventID == id).FirstOrDefault();
                mod1 = db.EventPackages.Where(x => x.packageID == ABE.foodPckage).FirstOrDefault();
                Dt = db.DecorationTeams.Where(x => x.dtID == ABE.decoTeam).FirstOrDefault();
                packageprice = mod1.plate_price;
                decoAmount = Dt.price;
                parti = (int)ABE.noOfParticipants;
                Advance =(float) ABE.advance;
                total = decoAmount + packageprice * parti;
                Remaining = total - Advance;




            }

        }

        public void updateInitialValues()
        {
            lbleventID.Text = ABE.eventID;
            lblTotal.Text = total.ToString();
            advancelbl.Text = Advance.ToString();
            lblremining.Text = Remaining.ToString();
            lblDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            lblTime.Text = DateTime.Now.TimeOfDay.ToString();
        }

        private void eventPayment_Load(object sender, EventArgs e)
        {
            lblTypePaidAmount.Text = typedPaidAmount;
            updateInitialValues();
        }
        public void updatePaideAmount(String Clickednumber)
        {
            typedPaidAmount = typedPaidAmount + Clickednumber;
            lblTypePaidAmount.Text = typedPaidAmount;
            calculateChange();
            moveLabelLeft();

        }


        public void calculateChange()
        {
            lblPaid.Text = typedPaidAmount;
            double change = double.Parse(typedPaidAmount) - Remaining;
            lblchange.Text = change.ToString();

        }


        public void moveLabelLeft()
        {
            lblTypePaidAmount.Location = new Point(lblTypePaidAmount.Location.X - 15, lblTypePaidAmount.Location.Y);

            if (lblTypePaidAmount.Location.X > this.Width)
            {
                lblTypePaidAmount.Location = new Point(0 - lblTypePaidAmount.Width, lblTypePaidAmount.Location.Y);
            }
        }


        public void moveLabelRight()
        {
            lblTypePaidAmount.Location = new Point(lblTypePaidAmount.Location.X + 15, lblTypePaidAmount.Location.Y);

            if (lblTypePaidAmount.Location.X > this.Width)
            {
                lblTypePaidAmount.Location = new Point(0 + lblTypePaidAmount.Width, lblTypePaidAmount.Location.Y);
            }
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            updatePaideAmount("1");
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            updatePaideAmount("2");
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            updatePaideAmount("3");
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            updatePaideAmount("4");
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            updatePaideAmount("5");
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            updatePaideAmount("6");
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            updatePaideAmount("7");
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            updatePaideAmount("8");
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            updatePaideAmount("9");
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            updatePaideAmount("0");
        }

        private void btnEventBack_Click(object sender, EventArgs e)
        {
            BookedEventViews bookevent = new BookedEventViews();
            bookevent.Show();
            this.Hide();
        }

        private void btnBackspace_Click(object sender, EventArgs e)
        {
            performBackspace();
            moveLabelRight();
        }
        public void performBackspace()
        {
            if ((String.Compare(typedPaidAmount, " ") < 0))
            {
                typedPaidAmount = typedPaidAmount.Substring(0, typedPaidAmount.Length - 1 + 1);
            }
            else
            {
                typedPaidAmount = typedPaidAmount.Substring(0, typedPaidAmount.Length - 1);
            }

            lblTypePaidAmount.Text = typedPaidAmount;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ev.paymentID = Util.generateKey("evPay");
            ev.eventID = lbleventID.Text.Trim();
           
            ev.date = DateTime.Today;
            ev.time = DateTime.Now.TimeOfDay;
            ev.remainning = float.Parse(lblremining.Text.Trim());
            ev.advance = float.Parse(advancelbl.Text.Trim());
            ev.total = float.Parse(lblTotal.Text.Trim());
            ev.change = float.Parse(lblchange.Text.Trim());
            ev.paid = float.Parse(lblPaid.Text.Trim());







            using (DBEntities db = new DBEntities())
            {
                if (status == "insert")
                {
                    db.evPays.Add(ev);

                    MessageBox.Show("Successfully saved");
                }
                else if (status == "update")
                {
                    //updating the database 
                    db.Entry(ev).State = EntityState.Modified;

                    MessageBox.Show("Bookings Updated Successfully");
                }
                db.SaveChanges();
            }
            
        }
    }
}
