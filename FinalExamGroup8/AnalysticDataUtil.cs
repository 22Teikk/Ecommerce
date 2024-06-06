using FinalExamGroup8.model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FinalExamGroup8
{
    public class AnalysticDataUtil
    {
        SqlConnection con;
        public AnalysticDataUtil()
        {
            string sqlCon = "Data Source=Teikk_Laptop\\SQLEXPRESS;Initial Catalog=nhom8db;Integrated Security=True";
            con = new SqlConnection(sqlCon);
        }

        public List<TotalSold> GetBestProductByOrder(bool isDesc)
        {
            List<TotalSold> list = new List<TotalSold>();
            con.Open();
            string order = isDesc ? "DESC" : "ASC";
            string sql = $@"
        SELECT TOP 1 WITH TIES 
            p.product_id, 
            p.sku, 
            p.price, 
            p.image, 
            p.name,  
            p.stock, 
            SUM(oi.quantity) AS total_sold 
        FROM order_item oi 
        JOIN product p ON oi.product_id = p.product_id 
        GROUP BY 
            p.product_id, 
            p.name, 
            p.sku,  
            p.price,  
            p.stock, 
            p.image 
        ORDER BY total_sold {order}";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                TotalSold product = new TotalSold();
                product.product_id = int.Parse(rd["product_id"].ToString());
                product.sku = rd["sku"].ToString();
                product.name = rd["name"].ToString();
                product.image = rd["image"].ToString();
                product.price = decimal.Parse(rd["price"].ToString());
                product.stock = int.Parse(rd["stock"].ToString());
                product.total_sold = int.Parse(rd["total_sold"].ToString());
                list.Add(product);
            }
            con.Close();
            return list;
        }

        public List<OrderDate> GetOrderDate(string period)
        {
            List<OrderDate> list = new List<OrderDate>();
            con.Open();

            string sql = string.Empty;

            switch (period.ToLower())
            {
                case "day":
                    sql = @"
                        SELECT 
                            FORMAT(order_date, 'dd/MM/yyyy') AS FormattedDate,
                            COUNT(order_id) AS TotalOrders,
                            SUM(total_price) AS TotalRevenue
                        FROM 
                            [dbo].[order]
                        GROUP BY 
                            FORMAT(order_date, 'dd/MM/yyyy')
                        ORDER BY 
                            FormattedDate";
                    break;
                case "month":
                    sql = @"
                        SELECT 
                            YEAR(order_date) AS Year,
                            MONTH(order_date) AS Month,
                            COUNT(order_id) AS TotalOrders,
                            SUM(total_price) AS TotalRevenue
                        FROM 
                            [dbo].[order]
                        GROUP BY 
                            YEAR(order_date),
                            MONTH(order_date)
                        ORDER BY 
                            Year,
                            Month";
                    break;
                case "year":
                    sql = @"
                        SELECT 
                            YEAR(order_date) AS Year,
                            COUNT(order_id) AS TotalOrders,
                            SUM(total_price) AS TotalRevenue
                        FROM 
                            [dbo].[order]
                        GROUP BY 
                            YEAR(order_date)
                        ORDER BY 
                            Year";
                    break;
                default:
                    throw new ArgumentException("Invalid period specified. Use 'day', 'month', or 'year'.");
            }

            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader rd = cmd.ExecuteReader();

            while (rd.Read())
            {
                OrderDate stats = new OrderDate();

                if (period.ToLower() == "day")
                {
                    stats.FormattedDate = rd["FormattedDate"].ToString();
                }
                else if (period.ToLower() == "month")
                {
                    stats.Year = int.Parse(rd["Year"].ToString());
                    stats.Month = int.Parse(rd["Month"].ToString());
                }
                else if (period.ToLower() == "year")
                {
                    stats.Year = int.Parse(rd["Year"].ToString());
                }

                stats.TotalOrders = int.Parse(rd["TotalOrders"].ToString());
                stats.TotalRevenue = decimal.Parse(rd["TotalRevenue"].ToString());

                list.Add(stats);
            }

            con.Close();
            return list;
        }

    }
}