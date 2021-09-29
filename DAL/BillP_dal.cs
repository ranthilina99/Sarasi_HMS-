using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sarasi_HMS.BLL;
using System.Data;

namespace Sarasi_HMS.DAL
{
    class BillP_dal
    {

        static string myconnstrng = ConfigurationManager.ConnectionStrings["DBEntities1"].ConnectionString;
        #region Insert data to database

        public bool InsertBillPayment(BillP_bll B)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);


            try
            {

                String sql = "INSERT INTO BillPayment1(ResID,Guestid,CleanerID,ReceptID,CheckIn,CheckOut,numOfday,Room_type,numOfRooms,Discount,Tax,total) VALUES(@ResID,@Guestid,@CleanerID,@ReceptID,@CheckIn,@CheckOut,@numOfday,@Room_type,@numOfRooms,@Discount,@Tax,@total) ";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ResID", B.ResID);
                cmd.Parameters.AddWithValue("@Guestid", B.Guestid);
                cmd.Parameters.AddWithValue("@CleanerID", B.CleanerID);
                cmd.Parameters.AddWithValue("@ReceptID", B.ReceptID);
                cmd.Parameters.AddWithValue("@CheckIn", B.CheckIn);
                cmd.Parameters.AddWithValue("@CheckOut",B.CheckOut);
                cmd.Parameters.AddWithValue("@numOfday", B.numOfday);
                cmd.Parameters.AddWithValue("@Room_type", B.Room_type);
                cmd.Parameters.AddWithValue("@numOfRooms",B.numOfday);
                cmd.Parameters.AddWithValue("@Discount", B.Discount);
                cmd.Parameters.AddWithValue("@Tax", B.Tax);
                cmd.Parameters.AddWithValue("@total", B.total);

                conn.Open();

                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return isSuccess;
        }


        #endregion



        #region Select data from database

        public DataTable SelectBill()
        {
            // create sql connection
            SqlConnection conn = new SqlConnection(myconnstrng);


            // create dataatable . data table is a temporary table
            DataTable dt = new DataTable();

            try
            {   // query to select all data from database
                String sql = " SELECT*FROM BillPayment1  ";
                // for executing command
                SqlCommand cmd = new SqlCommand(sql, conn);

                // getting data from datatable
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                conn.Open();

                // fill data in to datatable
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

                conn.Close();
            }
            // returnn the value in datatable
            return dt;

        }
        #endregion

    }
}
