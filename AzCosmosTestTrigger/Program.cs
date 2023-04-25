
using Microsoft.Azure.Cosmos;


using System.ComponentModel;
using Container = Microsoft.Azure.Cosmos.Container;

string cosmosDBEndpointUri = "https://.documents.azure.com:443/";
string cosmosDBKey = "==";

string databaseName = "appdb";
string ordersContainerName = "Orders";

// 3 - Add Items
await AddItem("X1", "Laptop", 100);
await AddItem("X2", "Mobiles", 200);
await AddItem("X3", "Desktop", 75);
await AddItem("X4", "Laptop", 25);


async Task AddItem(string orderId, string category, int quantity)
{
    CosmosClient cosmosClient;
    cosmosClient = new CosmosClient(cosmosDBEndpointUri, cosmosDBKey);

    Database database = cosmosClient.GetDatabase(databaseName);
    Container container = database.GetContainer(ordersContainerName);

    Order order = new Order()
    {
        id = Guid.NewGuid().ToString(),
        orderId = orderId,
        category = category,
        //quantity = quantity   // NO QUANTITY
    };

    //ItemResponse<Order> response = await container.CreateItemAsync<Order>(order, new PartitionKey(order.category));
    ItemResponse<Order> response = await container.CreateItemAsync<Order>(order, null, 
        new ItemRequestOptions() { PreTriggers = new List<string> { "validateItem" } });

    Console.WriteLine("Added item with Order Id {0}", orderId);
    Console.WriteLine("Request Units consumed {0}", response.RequestCharge);
}

public class Order
{
    public string id { get; set; }

    public string orderId { get; set; }

    public string category { get; set; }

    public int quantity { get; set; }
}