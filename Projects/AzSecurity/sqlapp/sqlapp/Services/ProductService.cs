using Azure.Core;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.FeatureManagement;
using sqlapp.Models;
using System.Data.SqlClient;

namespace sqlapp.Services
{
    public class ProductService : IProductService
    {
        private readonly IConfiguration _configuration;

        private readonly IFeatureManager _featureManager;

        public ProductService(IConfiguration configuration, IFeatureManager featureManager)
        {
            _configuration = configuration;
            _featureManager = featureManager;
        }

        public async Task<bool> IsBetaFeatureEnabled()
        {
            return await _featureManager.IsEnabledAsync("betaFeature");
        }

        private SqlConnection GetConnection()
        {
            TokenCredential tokenCredential = new DefaultAzureCredential();

            string keyVaultUrl = "https://keyvaultdpol.vault.azure.net/";
            string secretName = "dbconnectionstring";

            SecretClient secretClient = new SecretClient(new Uri(keyVaultUrl), tokenCredential);

            var secret = secretClient.GetSecret(secretName);

            string connectionString = secret.Value.Value;

            return new SqlConnection(connectionString);
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
