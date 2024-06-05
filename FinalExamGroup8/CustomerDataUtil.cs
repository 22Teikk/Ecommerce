using FinalExamGroup8.model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FinalExamGroup8
{
    public class CustomerDataUtil
    {
        SqlConnection con;

        public CustomerDataUtil()
        {
            string sqlCon = "Data Source=Teikk_Laptop\\SQLEXPRESS;Initial Catalog=nhom8db;Integrated Security=True";
            con = new SqlConnection(sqlCon);
        }

        public List<Customer> listCustomer()
        {
            List<Customer> list = new List<Customer>();
            con.Open();
            string sql = "select * from customer";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                Customer customer = new Customer();
                customer.customer_id = int.Parse(rd["customer_id"].ToString());
                customer.first_name = rd["first_name"].ToString();
                customer.last_name = rd["last_name"].ToString();
                customer.email = rd["email"].ToString();
                customer.password = rd["password"].ToString();
                customer.address = rd["address"].ToString();
                customer.phone_number = rd["phone_number"].ToString();
                list.Add(customer);
            }
            con.Close();
            return list;
        }

        public Customer GetCustomer(int id)
        {
            Customer customer = new Customer();
            con.Open();
            string sql = "select * from customer where customer_id = @id";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("id", id);
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                customer.customer_id = int.Parse(rd["customer_id"].ToString());
                customer.first_name = rd["first_name"].ToString();
                customer.last_name = rd["last_name"].ToString();
                customer.email = rd["email"].ToString();
                customer.password = rd["password"].ToString();
                customer.address = rd["address"].ToString();
                customer.phone_number = rd["phone_number"].ToString();
            }
            con.Close();
            return customer;
        }

        public void UpdateCustomer(Customer customer)
        {
            string sql = "update customer set first_name = @firstName, last_name = @lastName, email = @email, password = @password, address = @address, phone_number = @phoneNumber where customer_id = @id";
            con.Open();
            SqlCommand sqlCommand = new SqlCommand(sql, con);
            sqlCommand.Parameters.AddWithValue("id", customer.customer_id);
            sqlCommand.Parameters.AddWithValue("firstName", customer.first_name);
            sqlCommand.Parameters.AddWithValue("lastName", customer.last_name);
            sqlCommand.Parameters.AddWithValue("email", customer.email);
            sqlCommand.Parameters.AddWithValue("password", customer.password);
            sqlCommand.Parameters.AddWithValue("address", customer.address);
            sqlCommand.Parameters.AddWithValue("phoneNumber", customer.phone_number);
            sqlCommand.ExecuteNonQuery();
            con.Close();
        }

        public void AddCustomer(Customer customer)
        {
            string sql = "insert into customer (first_name, last_name, email, password, address, phone_number) values (@firstName, @lastName, @email, @password, @address, @phoneNumber)";
            con.Open();
            SqlCommand sqlCommand = new SqlCommand(sql, con);
            sqlCommand.Parameters.AddWithValue("firstName", customer.first_name);
            sqlCommand.Parameters.AddWithValue("lastName", customer.last_name);
            sqlCommand.Parameters.AddWithValue("email", customer.email);
            sqlCommand.Parameters.AddWithValue("password", customer.password);
            sqlCommand.Parameters.AddWithValue("address", customer.address);
            sqlCommand.Parameters.AddWithValue("phoneNumber", customer.phone_number);
            sqlCommand.ExecuteNonQuery();
            con.Close();
        }

        public void DeleteCustomer(int id)
        {
            string sql = "delete customer where customer_id = @id";
            con.Open();
            SqlCommand sqlCommand = new SqlCommand(sql, con);
            sqlCommand.Parameters.AddWithValue("id", id);
            sqlCommand.ExecuteNonQuery();
            con.Close();
        }
    }
}