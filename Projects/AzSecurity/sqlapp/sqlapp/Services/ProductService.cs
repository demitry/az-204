using Azure.Core;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.FeatureManagement;
using sqlapp.Models;
using StackExchange.Redis;
using System.Data.SqlClient;
using Newtonsoft.Json;

namespace sqlapp.Services
{
    public class ProductService : IProductService
    {
        private readonly IConnectionMultiplexer _redis;

        private readonly IConfiguration _configuration;

        private readonly IFeatureManager _featureManager;

        public ProductService(IConfiguration configuration, IFeatureManager featureManager, IConnectionMultiplexer redis)
        {
            _configuration = configuration;
            _featureManager = featureManager;
            _redis = redis;
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

        //public async Task<List<Product>> GetProducts()
        public List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();

            IDatabase database = _redis.GetDatabase();
            string key = "productlist";

            if(database.KeyExists(key))
            {
                long listLenght = database.ListLength(key);
                for (int i = 0; i < listLenght; i++)
                {
                    string value = database.ListGetByIndex(key, i);
                    Product product = JsonConvert.DeserializeObject<Product>(value);
                    products.Add(product);
                }
                return products;
            }

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
                            database.ListRightPush(key, JsonConvert.SerializeObject(product));
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
