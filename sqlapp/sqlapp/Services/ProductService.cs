using sqlapp.Models;
using System.Data.SqlClient;

namespace sqlapp.Services
{
    public class ProductService
    {
        private static string dbSource = "sqlserver1000.database.windows.net";

        private static string dbUserName = "sqladmin";

        private static string dbPassword = "";

        private static string dbName = "appdb";

        private SqlConnection GetConnection()
        {
            var sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = dbSource;
            sqlConnectionStringBuilder.UserID = dbUserName;
            sqlConnectionStringBuilder.Password = dbPassword;
            sqlConnectionStringBuilder.InitialCatalog = dbName;

            return new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
        }

        public List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();
            string sqlQuery = "SELECT ProductId, ProductName, Quantity FROM Products";
            
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand(sqlQuery, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Product product = new Product()
                            {
                                Id = reader.GetInt32(0),
                                ProductName = reader.GetString(1),
                                Quantity = reader.GetInt32(2),
                            };

                            products.Add(product);
                        }
                    }
                }
                connection.Close();
                return products;
            }
        }
    }
}
