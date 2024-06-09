using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace FinalExamGroup8
{
    public class DashboardDataUtil
    {
        SqlConnection con;
        public DashboardDataUtil()
        {
            string sqlCon = "Data Source=Teikk_Laptop\\SQLEXPRESS;Initial Catalog=nhom8db;Integrated Security=True";
            con = new SqlConnection(sqlCon);
        }

        public int SaleToday()
        {
            int sale = 0;
            con.Open();
            string sql = "SELECT SUM(oi.quantity) AS total_products_sold_today " +
                     "FROM [dbo].[order_item] oi " +
                     "INNER JOIN [dbo].[order] o ON oi.order_id = o.order_id " +
                     "WHERE CONVERT(DATE, o.order_date) = CONVERT(DATE, GETDATE());";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.Read() && !rd.IsDBNull(0))
            {
                sale = int.Parse(rd["total_products_sold_today"].ToString());
            }
            con.Close();
            return sale;
        }
        public int SalePreviousDay()
        {
            int sale = 0;
            con.Open();
            string sql = "SELECT SUM(oi.quantity) AS total_products_sold_yesterday " +
                     "FROM [dbo].[order_item] oi " +
                     "INNER JOIN [dbo].[order] o ON oi.order_id = o.order_id " +
                     "WHERE CONVERT(DATE, o.order_date) = CONVERT(DATE, DATEADD(DAY, -1, GETDATE()));";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.Read() && !rd.IsDBNull(0))
            {
                sale = int.Parse(rd["total_products_sold_today"].ToString());
            }
            con.Close();
            return sale;
        }

        public decimal RevenueMonth()
        {
            decimal revenue = 0;
            con.Open();
            string sql = "SELECT SUM(p.amount) AS total_revenue FROM [dbo].[payment] p WHERE YEAR(p.payment_date) = YEAR(GETDATE()) AND MONTH(p.payment_date) = MONTH(GETDATE());";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.Read() && !rd.IsDBNull(0))
            {
                revenue = rd.GetDecimal(0);
            }
            con.Close();
            return revenue;
        }

        public decimal RevenuePreviousMonth()
        {
            decimal revenue = 0;
            con.Open();
            // Truy vấn SQL để lấy tổng doanh thu từ tất cả các thanh toán trong tháng trước
            string sql = "SELECT SUM(p.amount) AS total_revenue " +
                         "FROM [dbo].[payment] p " +
                         "WHERE YEAR(p.payment_date) = YEAR(DATEADD(MONTH, -1, GETDATE())) " +
                         "AND MONTH(p.payment_date) = MONTH(DATEADD(MONTH, -1, GETDATE()));";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.Read() && !rd.IsDBNull(0))
            {
                revenue = rd.GetDecimal(0);
            }
            con.Close();
            return revenue;
        }


        public int CustomerYear()
        {
            int customerYear = 0;
            con.Open();
            string sql = "SELECT COUNT(DISTINCT o.customer_id) AS customer_count FROM [dbo].[order] o WHERE YEAR(o.order_date) = YEAR(GETDATE());";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.Read() && !rd.IsDBNull(0))
            {
                customerYear = rd.GetInt32(0);
            }
            con.Close();
            return customerYear;
        }

        public int CustomerPreviousYear()
        {
            int customerCount = 0;
            con.Open();
            // Truy vấn SQL để lấy số lượng khách hàng từ tất cả các đơn đặt hàng trong năm trước
            string sql = "SELECT COUNT(DISTINCT o.customer_id) AS customer_count " +
                         "FROM [dbo].[order] o " +
                         "WHERE YEAR(o.order_date) = YEAR(DATEADD(YEAR, -1, GETDATE()));";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.Read() && !rd.IsDBNull(0))
            {
                customerCount = rd.GetInt32(0);
            }
            con.Close();
            return customerCount;
        }

    }
}