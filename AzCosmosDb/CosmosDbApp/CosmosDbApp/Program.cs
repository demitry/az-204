
using CosmosDbApp;
using Microsoft.Azure.Cosmos;


string cosmosDBEndpointUri = "";
string cosmosDBKey = "";

string databaseName = "appdb";
string ordersContainerName = "Orders";
//1
//await CreateDatabase("appdb");

//2
//await CreateContainer("appdb", "Orders", "/category");

async Task CreateDatabase(string databaseName)
{
    CosmosClient cosmosClient;
    cosmosClient = new CosmosClient(cosmosDBEndpointUri, cosmosDBKey);

    await cosmosClient.CreateDatabaseIfNotExistsAsync(databaseName);
    Console.WriteLine("Database created");
}

async Task CreateContainer(string databaseName, string containerName, string partitionKey)
{
    CosmosClient cosmosClient;
    cosmosClient = new CosmosClient(cosmosDBEndpointUri, cosmosDBKey);

    Database database = cosmosClient.GetDatabase(databaseName);

    await database.CreateContainerAsync(containerName, partitionKey);

    Console.WriteLine("Container created");
}


// 3 Add Items
await AddItem("O1", "Laptop", 100);
await AddItem("O2", "Mobiles", 200);
await AddItem("O3", "Desktop", 75);
await AddItem("O4", "Laptop", 25);

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
        quantity = quantity
    };

    ItemResponse<Order> response = await container.CreateItemAsync<Order>(order, new PartitionKey(order.category));

    Console.WriteLine("Added item with Order Id {0}", orderId);
    Console.WriteLine("Request Units consumed {0}", response.RequestCharge);
}


/*
Added item with Order Id O1
Request Units consumed 6.67
Added item with Order Id O2
Request Units consumed 6.67
Added item with Order Id O3
Request Units consumed 6.67
Added item with Order Id O4
Request Units consumed 6.67

 */