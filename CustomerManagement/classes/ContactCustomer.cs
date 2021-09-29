using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sarasi_HMS
{
    class ContactCustomer
    {
        //getters and setters
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }

        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;

        //get data from database
        public DataTable Select()
        {
            //db connection 
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                //sql quary
                string sql = "SELECT * from tblContact";
                //sql cmd and conn
                SqlCommand cmd = new SqlCommand(sql, conn);
                //sql data adapter using cmd
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);
            }
            catch (Exception)
            {

            }
            finally
            {
                conn.Close();
            }
            return dt;
        }
        //Insert data 
        public bool Insert(ContactCustomer c)
        {
            // create  return type value to false 
            bool isSuccess = false;
            //1.connect database 
            SqlConnection conn = new SqlConnection(myconnstrng);
            // return isSuccess;
            try
            {
                //2.sql query to insert 
                string sql = "INSERT INTO tblContact (CustomerName, ContactNo, Email ) VALUES(@CustomerName, @ContactNo, @Email)";
                //create SQL command using sql and conn
                SqlCommand cmd = new SqlCommand(sql, conn);
                //Parameters to add data
                cmd.Parameters.AddWithValue("@CustomerName", c.CustomerName);
                cmd.Parameters.AddWithValue("@ContactNo", c.ContactNo);
                cmd.Parameters.AddWithValue("@Email", c.Email);

                //open connection
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                //if sucessful ..method
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch (Exception)
            {

            }
            finally
            {
                conn.Close();
            }
            return isSuccess;
        }

        //UPDATE values
        public bool Update(ContactCustomer c)
        {
            //default type to false 
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                //update data in database
                string sql = "UPDATE tblContact SET CustomerName=@CustomerName, ContactNo=@ContactNo, Email=@Email WHERE CustomerID=@CustomerID";
                //SQL command 
                SqlCommand cmd = new SqlCommand(sql, conn);
                //parameters to value 
                cmd.Parameters.AddWithValue("@CustomerName", c.CustomerName);
                cmd.Parameters.AddWithValue("@ContactNo", c.ContactNo);
                cmd.Parameters.AddWithValue("@Email", c.Email);
                cmd.Parameters.AddWithValue("@CustomerID", c.CustomerID);
                // database conection
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                //if sucecc method 
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch (Exception)
            {

            }
            finally
            {
                conn.Close();
            }
            return isSuccess;
        }
        //DELETE
        public bool Delete(ContactCustomer c)
        {
            //default return 
            bool isSuccess = false;
            //Sql connection
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                //sql to delte data
                string sql = "DELETE FROM tblContact WHERE CustomerID=@CustomerID";
                //sql command 
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("CustomerID", c.CustomerID);
                //open connection
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                //method
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;

                }
            }

            catch (Exception)
            {

            }
            finally
            {
                //close connection
                conn.Close();
            }

            return isSuccess;
        }
    }
}

