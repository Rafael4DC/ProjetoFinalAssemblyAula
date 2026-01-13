using Microsoft.Data.SqlClient;
using PFModel;
using System.Data;

namespace PFRepo
{
     public class BaseRepo
    {
        static string ConnectionString = "Server=localhost;Database=Northwind;Trusted_Connection=True;TrustServerCertificate=True";

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
