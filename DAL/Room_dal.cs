using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Sarasi_HMS.DAL
{
    class Room_dal
    {

        static string myconnstrng = ConfigurationManager.ConnectionStrings["DBEntities1"].ConnectionString;
        #region Search user

        public DataTable Search(string Keywords)
        {
            SqlConnection conn = new SqlConnection(myconnstrng);

            DataTable dt = new DataTable();
            try
            {
                String sql = "SELECT * FROM Room WHERE RoomNo LIKE '%" + Keywords + "%'  OR MaxAdult LIKE'%" + Keywords + "%' OR RoomType LIKE '%" + Keywords + "%' OR Floor_  LIKE '%" + Keywords + "%' ";
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



        #region Select avilable room

        public DataTable Select_avilable()
        {
            SqlConnection conn = new SqlConnection(myconnstrng);

            DataTable dt = new DataTable();
            try
            {
                String sql = "SELECT RoomNo,bedtype,maxaadult,floor,roomtype FROM Room1 WHERE available=1";
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


        #region Search available

        public DataTable Search_avail(string Keywords)
        {
            SqlConnection conn = new SqlConnection(myconnstrng);

            DataTable dt = new DataTable();
            try
            {
                String sql = "SELECT * FROM Room WHERE available=1 AND  RoomNo LIKE '%" + Keywords + "%'  OR maxaadult LIKE'%" + Keywords + "%' OR roomtype LIKE '%" + Keywords + "%' OR floor  LIKE '%" + Keywords + "%' ";
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
