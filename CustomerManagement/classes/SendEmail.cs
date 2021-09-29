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
    class SendEmail
    {
        //getters and setters
        public int SendID { get; set; }
        public string Date { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }

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
                string sql2 = "SELECT* from tblSendEmail";
                //sql cmd and conn
                SqlCommand cmd2 = new SqlCommand(sql2, conn);
                //sql data adapter using cmd
                SqlDataAdapter adapter = new SqlDataAdapter(cmd2);
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
        public bool Insert(SendEmail s)
        {
            // create  return type value to false 
            bool isSuccess = false;
            //1.connect database 
            SqlConnection conn = new SqlConnection(myconnstrng);
            // return isSuccess;
            try
            {

                //2.sql query to insert 
                string sql2 = "INSERT INTO tblSendEmail(Date, Subject, Message) VALUES(@Date, @Subject, @Message)";
                //create SQL command using sql and conn
                SqlCommand cmd2 = new SqlCommand(sql2, conn);
                //Parameters to add dat
                cmd2.Parameters.AddWithValue("@Date", s.Date);
                cmd2.Parameters.AddWithValue("@Subject", s.Subject);
                cmd2.Parameters.AddWithValue("@Message", s.Message);

                //open connection
                conn.Open();
                int rows = cmd2.ExecuteNonQuery();
                //if sucessful method
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

    }
}

