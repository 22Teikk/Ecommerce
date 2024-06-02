using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FinalExamGroup8
{
    public class DataUtils
    {
        SqlConnection con;
        public DataUtils()
        {
            string sqlCon = "Data Source=Teikk_Laptop\\SQLEXPRESS;Initial Catalog=nhom8db;Integrated Security=True";
            con = new SqlConnection(sqlCon);
        }

        public bool checkAdmin(string username, string password)
        {
            con.Open();
            string sql = "select * from [admin] where username=@u and password=@p";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("u", username);
            cmd.Parameters.AddWithValue("p", password);
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.HasRows)
            {
                con.Close();
                return true;
            }
            con.Close();
            return false;
        }
    }
}