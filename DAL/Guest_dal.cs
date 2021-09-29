using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;
using Sarasi_HMS.BLL;

namespace Sarasi_HMS.DAL
{
    class Guest_dal
    {

        static string myconnstrng = ConfigurationManager.ConnectionStrings["DBEntities1"].ConnectionString;


        #region Select data from database

        public DataTable Select()
        {
            // create sql connection
            SqlConnection conn = new SqlConnection(myconnstrng);


            // create dataatable . data table is a temporary table
            DataTable dt = new DataTable();

            try
            {   // query to select all data from database
                String sql = " SELECT guest_id,recepID,Name,address_,NIC,Gender,ContacNo,Country,PassportNo,Room_No FROM Guest  ";
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


        #region Insert data to database

        public bool InsertGuest(Guest_bll g)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);


            try
            {

                String sql = "INSERT INTO Guest(guest_id,recepID,Name,address_,NIC,Gender,ContacNo,Country,PassportNo,available,Room_No) VALUES(@guest_id,@recepID,@Name,@address_,@NIC,@Gender,@ContacNo,@Country,@PassportNo,@available,@Room_No) ";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@guest_id", g.guest_id);
                cmd.Parameters.AddWithValue("@recepID", g.recepID);
                cmd.Parameters.AddWithValue("@Name", g.Name);
                cmd.Parameters.AddWithValue("@address_", g.address_);
                cmd.Parameters.AddWithValue("@NIC", g.NIC);
                cmd.Parameters.AddWithValue("@Gender", g.Gender);
                cmd.Parameters.AddWithValue("@ContacNo", g.ContacNo);
                cmd.Parameters.AddWithValue("@Country", g.Country);
                cmd.Parameters.AddWithValue("@PassportNo", g.PassportNo);
                cmd.Parameters.AddWithValue("@available", g.available);
                cmd.Parameters.AddWithValue("@Room_No", g.Room_No);

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

        #region Update data in Database

        public bool UpdateGuest(Guest_bll g)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                string sql = "UPDATE Guest SET recepID=@recepID,Name=@Name,address_=@address_,NIC=@NIC,Gender=@Gender,ContacNo=@ContacNo,Country=@Country,PassportNo= @PassportNo,Room_No=@Room_No WHERE guest_id=@guest_id ";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@recepID", g.recepID);
                cmd.Parameters.AddWithValue("@Name", g.Name);
                cmd.Parameters.AddWithValue("@address_", g.address_);
                cmd.Parameters.AddWithValue("@NIC", g.NIC);
                cmd.Parameters.AddWithValue("@Gender", g.Gender);
                cmd.Parameters.AddWithValue("@ContacNo", g.ContacNo);
                cmd.Parameters.AddWithValue("@Country", g.Country);
                cmd.Parameters.AddWithValue("@PassportNo", g.PassportNo);
                cmd.Parameters.AddWithValue("@Room_No", g.Room_No);
                cmd.Parameters.AddWithValue("@guest_id", g.guest_id);

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


        #region Delete guest from Database 

        public bool DeleteGuest(Guest_bll g)
        {
            bool isSuccess = false;

            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                string sql = "DELETE FROM Guest WHERE guest_id=@guest_id";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@guest_id", g.guest_id);
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



        #region guest leaving

        public bool leaving(Guest_bll g)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                string sql = "UPDATE Guest SET available=@available WHERE guest_id=@guest_id ";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@available", g.available);
                cmd.Parameters.AddWithValue("@guest_id", g.guest_id);

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





        #region RoomTable Update
        public bool RoomtableUpdate(Room_bll u, string roonum)
        {
            //  string sql = "UPDATE Room SET available=@available WHERE guest_id LIKE '%"+ RoomNo_Pass + "%' ";
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                string sql = "UPDATE Room1 SET available=@available WHERE RoomNo LIKE '%" + roonum + "%' ";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@available", u.available);
                cmd.Parameters.AddWithValue("@RoomNo", u.RoomNo);

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



        #region Select Current guest

        public DataTable Select_Current_guest()
        {
            SqlConnection conn = new SqlConnection(myconnstrng);

            DataTable dt = new DataTable();
            try
            {
                String sql = "SELECT guest_id,recepID,Name,address_,NIC,Gender,ContacNo,Country,PassportNo,Room_No FROM Guest WHERE available=1";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
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
            return dt;
        }
        #endregion



        #region Select All guest

        public DataTable Select_All_guest()
        {
            SqlConnection conn = new SqlConnection(myconnstrng);

            DataTable dt = new DataTable();
            try
            {
                String sql = "SELECT guest_id,recepID,Name,address_,NIC,Gender,ContacNo,Country,PassportNo,Room_No FROM Guest";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
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
            return dt;
        }
        #endregion



        #region Search Guest

        public DataTable Search_guest(string Keywords)
        {
            SqlConnection conn = new SqlConnection(myconnstrng);

            DataTable dt = new DataTable();
            try
            {
                String sql = "SELECT * FROM Guest WHERE recepID LIKE '%" + Keywords + "%'  OR Name LIKE'%" + Keywords + "%' OR address_ LIKE '%" + Keywords + "%' OR NIC  LIKE '%" + Keywords + "%' ";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
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
            return dt;
        }

        #endregion
    }
}
