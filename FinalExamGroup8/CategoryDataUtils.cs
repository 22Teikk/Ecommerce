using FinalExamGroup8.model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace FinalExamGroup8
{
    public class CategoryDataUtils
    {
        SqlConnection con;
        public CategoryDataUtils()
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

        public List<Category> listCategory()
        {
            List<Category> list = new List<Category>();
            con.Open();
            string sql = "select * from category";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                Category category = new Category();
                category.category_id = int.Parse(rd["category_id"].ToString());
                category.category_name = rd["category_name"].ToString();
                list.Add(category);
            }
            con.Close();
            return list;
        }

        public List<Category> listOtherCategory()
        {
            List<Category> list = new List<Category>();
            con.Open();
            string sql = "select * from category ORDER BY category_id OFFSET 3 ROWS";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                Category category = new Category();
                category.category_id = int.Parse(rd["category_id"].ToString());
                category.category_name = rd["category_name"].ToString();
                list.Add(category);
            }
            con.Close();
            return list;
        }

        public Category GetCategory(int id)
        {
            Category category = new Category();
            con.Open();
            string sql = "select * from category where category_id = @id";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue ("id", id);
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                category.category_id = int.Parse(rd["category_id"].ToString());
                category.category_name = rd["category_name"].ToString();
            }
            con.Close();
            return category;
        }

        public void UpdateCategory(Category category)
        {
            string sql = "update category set category_name = @name where category_id = @id";
            con.Open();
            SqlCommand sqlCommand = new SqlCommand(sql, con);
            sqlCommand.Parameters.AddWithValue("id", category.category_id);
            sqlCommand.Parameters.AddWithValue("name", category.category_name);
            sqlCommand.ExecuteNonQuery();
            con.Close();
        }

        public void AddCategory(string name)
        {
            string sql = "insert into category (category_name) values (@name)";
            con.Open();
            SqlCommand sqlCommand = new SqlCommand(sql, con);
            sqlCommand.Parameters.AddWithValue("name", name);
            sqlCommand.ExecuteNonQuery();
            con.Close();
        }

        public void DeleteCategory(int id)
        {
            string sql = "delete category where category_id = @id";
            con.Open();
            SqlCommand sqlCommand = new SqlCommand(sql, con);
            sqlCommand.Parameters.AddWithValue("id", id);
            sqlCommand.ExecuteNonQuery();
            con.Close();
        }
    }
}