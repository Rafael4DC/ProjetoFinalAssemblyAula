using Microsoft.Data.SqlClient;
using PFModel;
using System.Collections.Generic;
using System.Data;

namespace PFRepo
{
     public class BaseRepo
    {
        static string ConnectionString = "Server=localhost;Database=Northwind;Trusted_Connection=True;TrustServerCertificate=True";

        public static List<Category> GetCategories()
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                string query = @"
                            select * from Categories";

                // SqlCommand cmd = con.CreateCommand();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = query;
                cmd.Connection = con;

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (!reader.HasRows) return null;

                List<Category> categories = new List<Category>();

                while (reader.Read())
                {
                    Category category = new Category();
                    category.ID = reader["CategoryID"].ToString();
                    category.Name = reader["CategoryName"].ToString();
                    category.Description = reader["Description"].ToString();
                    category.Picture = reader["Picture"].ToString();

                }
                return categories;
            }
        }

        public static Employee GetEmployee(string userId)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                string query = "Select * from Employees where EmployeeID = @user_id";

                // SqlCommand cmd = con.CreateCommand();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = query;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@user_id", userId);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (!reader.HasRows) return null;

                reader.Read();

                return new Employee()
                {
                    ID = Convert.ToInt32(reader["EmployeeID"]),
                    Name = reader["FirstName"] + " " + reader["LastName"],
                };

            }
        }

        public static List<Products> GetProducts(int skip, int limit)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                string query = @"
                            select * from Products 
                            ORDER BY ProductID
                            OFFSET @skip ROWS
                            FETCH NEXT @limit ROWS ONLY;";

                // SqlCommand cmd = con.CreateCommand();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = query;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@skip", skip*limit);
                cmd.Parameters.AddWithValue("@limit", limit);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (!reader.HasRows) return null;

                List<Products> products = new List<Products>(); 

                while (reader.Read())
                {
                    Products product = new Products();
                    product.ID = reader["ProductID"].ToString();
                    product.Name = reader["ProductName"].ToString();
                    product.Category.ID = reader["CategoryID"].ToString();
                    product.QuantityByUnit = reader["QuantityPerUnit"].ToString();
                    product.UnitPrice = Convert.ToDouble(reader["UnitPrice"]);
                    product.UnitsInStock = Convert.ToInt32(reader["UnitsInStock"]);

                }
                return products;
            }
        }

        public static Employee? Login(User user)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                string query = "Select * from Employees where Username = @Username and password = @password";

                // SqlCommand cmd = con.CreateCommand();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = query;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@Username",user.Username);
                cmd.Parameters.AddWithValue("@password",user.Password);


                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (!reader.HasRows) return null;

                reader.Read();

                return new Employee()
                {
                    ID = Convert.ToInt32(reader["EmployeeID"]),
                    Name = reader["FirstName"] + " " + reader["LastName"],
                };

            }

        }
    }
}
