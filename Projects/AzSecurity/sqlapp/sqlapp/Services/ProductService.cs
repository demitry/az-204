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
            string tenantId = "87349d34-316a-481c-ab12-5f5c7af3cd99";           // Directory (tenant) ID
            string clientId = "9402fc42-8020-454e-a041-a11c8bf615a7";           // Application (client) ID
            string clientSecret = "wJE8Q~";                                     // KeyVaultApp | Certificates & secrets - new

            string keyVaultUrl = "https://keyvaultdpol.vault.azure.net/";
            string secretName = "dbconnectionstring";

            ClientSecretCredential clientSecretCredential = new ClientSecretCredential(tenantId, clientId, clientSecret);
            SecretClient secretClient = new SecretClient(new Uri(keyVaultUrl), clientSecretCredential);

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
