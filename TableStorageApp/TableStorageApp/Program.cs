using Azure.Data.Tables;

namespace TableStorageApp
{
    public class Program
    {
        static string connectionString = "";

        static string tableName = "Orders";

        static async Task Main(string[] args)
        {
            AddEntity("O1", "Mobile", 100);
            AddEntity("O2", "Laptop", 50);
            AddEntity("O3", "Desktop", 70);
            AddEntity("O4", "Laptop", 200);
        }

        public static void AddEntity(string orderID, string category, int quantity)
        {
            TableClient tableClient = new TableClient(connectionString, tableName);

            TableEntity tableEntity = new TableEntity(category, orderID)
            {
                {"quantity",quantity}
            };

            tableClient.AddEntity(tableEntity);
            Console.WriteLine("Added Entity with order ID {0}", orderID);
        }
    }
}


