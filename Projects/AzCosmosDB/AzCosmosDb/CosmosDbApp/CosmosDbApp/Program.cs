using CosmosDbApp;
using Microsoft.Azure.Cosmos;

string cosmosDBEndpointUri = "";
string cosmosDBKey = "";

string databaseName = "appdb";
string ordersContainerName = "Orders";

// 1 - Create Database
//await CreateDatabase("appdb");

// 2 - Create Container
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


// 3 - Add Items
//await AddItem("O1", "Laptop", 100);
//await AddItem("O2", "Mobiles", 200);
//await AddItem("O3", "Desktop", 75);
//await AddItem("O4", "Laptop", 25);

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


// 4 - Read Items

await ReadItems();

async Task ReadItems()
{
    CosmosClient cosmosClient = new CosmosClient(cosmosDBEndpointUri, cosmosDBKey);

    Database database = cosmosClient.GetDatabase(databaseName);
    Container container = database.GetContainer(ordersContainerName);

    string sqlQuery = "SELECT o.orderId, o.category, o.quantity FROM Orders o";

    QueryDefinition queryDefinition = new QueryDefinition(sqlQuery);
    
    using FeedIterator<Order> feedIterator = container.GetItemQueryIterator<Order>(queryDefinition);

    while (feedIterator.HasMoreResults)
    {
        FeedResponse<Order> response = await feedIterator.ReadNextAsync();
        foreach (Order order in response)
        {
            Console.WriteLine("Order Id {0}", order.orderId);
            Console.WriteLine("Category {0}", order.category);
            Console.WriteLine("Quantity {0}", order.quantity);
        }
    }
}

// 5 - Replace Items 

//await ReplaceItems();

//await ReadItems(); //to verify

async Task ReplaceItems()
{
    CosmosClient cosmosClient;
    cosmosClient = new CosmosClient(cosmosDBEndpointUri, cosmosDBKey);

    Database database = cosmosClient.GetDatabase(databaseName);
    Container container = database.GetContainer(ordersContainerName);

    string orderId = "O1";
    string sqlQuery = $"SELECT o.id,o.category FROM Orders o WHERE o.orderId='{orderId}'";

    string id = string.Empty;
    string category = string.Empty;

    QueryDefinition queryDefinition = new QueryDefinition(sqlQuery);

    using FeedIterator<Order> feedIterator = container.GetItemQueryIterator<Order>(queryDefinition);

    while (feedIterator.HasMoreResults)
    {
        FeedResponse<Order> response = await feedIterator.ReadNextAsync();
        foreach (Order order in response)
        {
            id = order.id;
            category = order.category;
        }
    }

    // Get the specific item first
    ItemResponse<Order> orderResponse = await container.ReadItemAsync<Order>(id, new PartitionKey(category));

    var item = orderResponse.Resource;
    item.quantity = 300;

    // Now let's replace the item

    await container.ReplaceItemAsync<Order>(item, item.id, new PartitionKey(item.category));
    Console.WriteLine("Item is updated");
}

/*
Order Id O1
Category Laptop
Quantity 100
Order Id O2
Category Mobiles
Quantity 200
Order Id O3
Category Desktop
Quantity 75
Order Id O4
Category Laptop
Quantity 25

Item is updated

Order Id O1
Category Laptop
Quantity 300    // <---
Order Id O2
Category Mobiles
Quantity 200
Order Id O3
Category Desktop
Quantity 75
Order Id O4
Category Laptop
Quantity 25
*/

// 6 - Delete Item

await DeleteItem();

await ReadItems(); //to verify

async Task DeleteItem()
{
    CosmosClient cosmosClient;
    cosmosClient = new CosmosClient(cosmosDBEndpointUri, cosmosDBKey);

    Database database = cosmosClient.GetDatabase(databaseName);
    Container container = database.GetContainer(ordersContainerName);

    string orderId = "O1";
    string sqlQuery = $"SELECT o.id,o.category FROM Orders o WHERE o.orderId='{orderId}'";

    string id = string.Empty;
    string category = string.Empty;

    QueryDefinition queryDefinition = new QueryDefinition(sqlQuery);

    using FeedIterator<Order> feedIterator = container.GetItemQueryIterator<Order>(queryDefinition);

    while (feedIterator.HasMoreResults)
    {
        FeedResponse<Order> response = await feedIterator.ReadNextAsync();
        foreach (Order order in response)
        {
            id = order.id;
            category = order.category;
        }
    }

    // Get the specific item first
    ItemResponse<Order> orderResponse = await container.ReadItemAsync<Order>(id, new PartitionKey(category));

    await container.DeleteItemAsync<Order>(id, new PartitionKey(category));

    Console.WriteLine("Item is deleted");
}

/*
Order Id O1
Category Laptop
Quantity 300
Order Id O2
Category Mobiles
Quantity 200
Order Id O3
Category Desktop
Quantity 75
Order Id O4
Category Laptop
Quantity 25

Item is deleted

Order Id O2
Category Mobiles
Quantity 200
Order Id O3
Category Desktop
Quantity 75
Order Id O4
Category Laptop
Quantity 25
*/