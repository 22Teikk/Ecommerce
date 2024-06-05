using FinalExamGroup8.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FinalExamGroup8
{
    public class ProductDataUtils
    {
        SqlConnection con;
        public ProductDataUtils()
        {
            string sqlCon = "Data Source=Teikk_Laptop\\SQLEXPRESS;Initial Catalog=nhom8db;Integrated Security=True";
            con = new SqlConnection(sqlCon);
        }

        public List<Product> listProductByCategoryName(string category_name)
        {
            List<Product> list = new List<Product>();
            con.Open();
            string sql = "select * from product inner join category on product.category_id = category.category_id where category_name = @name";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("name", category_name);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                Product product = new Product();
                product.product_id = int.Parse(rd["product_id"].ToString());
                product.sku = rd["sku"].ToString();
                product.name = rd["name"].ToString();
                product.image = rd["image"].ToString();
                product.price = decimal.Parse(rd["price"].ToString());
                product.stock = int.Parse(rd["stock"].ToString());
                product.category_id = int.Parse(rd["category_id"].ToString());
                list.Add(product);
            }
            con.Close();
            return list;
        }

        public List<Product> listProductStock(string category_name)
        {
            List<Product> list = new List<Product>();
            con.Open();
            string sql = "select * from product inner join category on product.category_id = category.category_id where category_name = @name and stock > 0";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("name", category_name);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                Product product = new Product();
                product.product_id = int.Parse(rd["product_id"].ToString());
                product.sku = rd["sku"].ToString();
                product.name = rd["name"].ToString();
                product.image = rd["image"].ToString();
                product.price = decimal.Parse(rd["price"].ToString());
                product.stock = int.Parse(rd["stock"].ToString());
                product.category_id = int.Parse(rd["category_id"].ToString());
                list.Add(product);
            }
            con.Close();
            return list;
        }

        public List<Product> listProductOutStock(string category_name)
        {
            List<Product> list = new List<Product>();
            con.Open();
            string sql = "select * from product inner join category on product.category_id = category.category_id where category_name = @name and stock = 0";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("name", category_name);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                Product product = new Product();
                product.product_id = int.Parse(rd["product_id"].ToString());
                product.sku = rd["sku"].ToString();
                product.name = rd["name"].ToString();
                product.image = rd["image"].ToString();
                product.price = decimal.Parse(rd["price"].ToString());
                product.stock = int.Parse(rd["stock"].ToString());
                product.category_id = int.Parse(rd["category_id"].ToString());
                list.Add(product);
            }
            con.Close();
            return list;
        }

        public Product GetProduct(int id)
        {
            Product product = new Product();
            con.Open();
            string sql = "select * from product where product_id = @id";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("id", id);
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                product.product_id = int.Parse(rd["product_id"].ToString());
                product.sku = rd["sku"].ToString();
                product.name = rd["name"].ToString();
                product.image = rd["image"].ToString();
                product.price = decimal.Parse(rd["price"].ToString());
                product.stock = int.Parse(rd["stock"].ToString());
                product.category_id = int.Parse(rd["category_id"].ToString());
            }
            con.Close();
            return product;
        }

        public void UpdateProduct(Product product)
        {
            string sql = "UPDATE product SET sku = @sku, name = @name, price = @price, stock = @stock, image = @image, category_id = @cid WHERE product_id = @pid";
            con.Open();
            SqlCommand sqlCommand = new SqlCommand(sql, con);
            sqlCommand.Parameters.AddWithValue("name", product.name);
            sqlCommand.Parameters.AddWithValue("price", product.price);
            sqlCommand.Parameters.AddWithValue("stock", product.stock);
            sqlCommand.Parameters.AddWithValue("image", product.image);
            sqlCommand.Parameters.AddWithValue("cid", product.category_id);
            sqlCommand.Parameters.AddWithValue("sku", product.sku);
            sqlCommand.Parameters.AddWithValue("pid", product.product_id);
            sqlCommand.ExecuteNonQuery();
            con.Close();

        }

        public void AddProduct(Product product)
        {
            string sql = "insert into product (sku, name, price, stock, image, category_id) values (@sku, @name, @price, @stock, @image, @cid)";
            con.Open();
            SqlCommand sqlcommand = new SqlCommand(sql, con);
            sqlcommand.Parameters.AddWithValue("sku", product.sku);
            sqlcommand.Parameters.AddWithValue("name", product.name);
            sqlcommand.Parameters.AddWithValue("price", product.price);
            sqlcommand.Parameters.AddWithValue("stock", product.stock);
            sqlcommand.Parameters.AddWithValue("image", product.image);
            sqlcommand.Parameters.AddWithValue("cid", product.category_id);
            sqlcommand.ExecuteNonQuery();
            con.Close();
        }

        public void DeleteProduct(int id) 
        {
            string sql = "delete product where product_id = @id";
            con.Open();
            SqlCommand sqlCommand = new SqlCommand(sql, con);
            sqlCommand.Parameters.AddWithValue("id", id);
            sqlCommand.ExecuteNonQuery();
            con.Close();
        }

        public List<Product> GetProductsByCategory(int cateid)
        {
            List<Product> list = new List<Product>();
            string sql = @"
                SELECT *
                FROM product 
                WHERE category_id = @id";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("id", cateid);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                Product product = new Product();
                product.product_id = int.Parse(rd["product_id"].ToString());
                product.sku = rd["sku"].ToString();
                product.name = rd["name"].ToString();
                product.image = rd["image"].ToString();
                product.price = decimal.Parse(rd["price"].ToString());
                product.stock = int.Parse(rd["stock"].ToString());
                product.category_id = int.Parse(rd["category_id"].ToString());
                list.Add(product);
            }
            con.Close();
            return list;
        }

    }
}