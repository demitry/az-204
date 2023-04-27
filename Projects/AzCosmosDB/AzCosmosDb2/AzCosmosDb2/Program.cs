using Microsoft.Azure.Cosmos;

string cosmosDBEndpointUri = "";
string cosmosDBKey = "";

string databaseName = "appdb";
string containerName = "Customers";

/*
await AddItem("C1", "CustomerA", "New York",
    new List<Order>()
    {
        new Order
        {
            orderId = "O1",
            category = "Laptop",
            quantity = 100
        },
        new Order
        {
            orderId = "O2",
            category = "Mobile",
            quantity = 10
        }
    });

await AddItem("C2", "CustomerB", "Chicago",
    new List<Order>() {
    new Order
    {
        orderId = "O3",
        category = "Laptop",
        quantity = 20
    }});

var orders = new List<Order>()
{
    new Order
    {
        orderId = "O4",
        category = "Desktop",
        quantity = 30
    },
    new Order
    {
         orderId = "O5",
         category = "Mobile",
         quantity = 40
    }
};

await AddItem("C3", "CustomerC", "Miami", orders);
*/

async Task AddItem(string customerId, string customerName, string customerCity, List<Order> orders)
{
    CosmosClient cosmosClient = new CosmosClient(cosmosDBEndpointUri, cosmosDBKey);
    Database database = cosmosClient.GetDatabase(databaseName);
    Container container = database.GetContainer(containerName);

    Customer customer = new Customer()
    {
        customerId = customerId,
        customerName = customerName,
        customerCity = customerCity,
        orders = orders
    };

    ItemResponse<Customer> response = await container.CreateItemAsync<Customer>(customer, new PartitionKey(customer.customerCity));

    Console.WriteLine("Added item with Customer Id {0}", customerId);
    Console.WriteLine("Request Units consumed {0}", response.RequestCharge);
}

/*
Added item with Customer Id C1
Request Units consumed 8.95
Added item with Customer Id C2
Request Units consumed 8.19
Added item with Customer Id C3
Request Units consumed 8.95 
*/


// await ReadItems();

async Task ReadItems()
{
    CosmosClient cosmosClient;
    cosmosClient = new CosmosClient(cosmosDBEndpointUri, cosmosDBKey);

    Database database = cosmosClient.GetDatabase(databaseName);
    Container container = database.GetContainer(containerName);

    string sqlQuery = "SELECT c.id, c.customerName, c.customerCity, c.orders AS Orders FROM Customer c";

    QueryDefinition queryDefinition = new QueryDefinition(sqlQuery);
    
    using FeedIterator<Customer> feedIterator = container.GetItemQueryIterator<Customer>(queryDefinition);

    while (feedIterator.HasMoreResults)
    {
        FeedResponse<Customer> response = await feedIterator.ReadNextAsync();
        foreach (Customer customer in response)
        {
            Console.WriteLine("Customer Id {0}", customer.customerId);
            Console.WriteLine("Customer Name {0}", customer.customerName);
            Console.WriteLine("Customer City {0}", customer.customerCity);
            foreach (Order order in customer.orders)
            {
                Console.WriteLine("Order ID {0}", order.orderId);
                Console.WriteLine("Category  {0}", order.category);
                Console.WriteLine("Quantity {0}", order.quantity);
            }
        }
    }
}

// Adding orders - Update = Replace

await AddOrderUpdateCustomer();

async Task AddOrderUpdateCustomer()
{
    CosmosClient cosmosClient;
    cosmosClient = new CosmosClient(cosmosDBEndpointUri, cosmosDBKey);

    Database database = cosmosClient.GetDatabase(databaseName);
    Container container = database.GetContainer(containerName);

    string customerId = "C2";
    string sqlQuery = $"SELECT c.id,c.customerCity FROM Customer c WHERE c.id='{customerId}'";

    string customerCity = "";

    QueryDefinition queryDefinition = new QueryDefinition(sqlQuery);
    
    using FeedIterator<Customer> feedIterator = container.GetItemQueryIterator<Customer>(queryDefinition);

    while (feedIterator.HasMoreResults)
    {
        FeedResponse<Customer> response = await feedIterator.ReadNextAsync();
        foreach (Customer customer in response)
        {
            customerCity = customer.customerCity;
        }
    }

    // Get the specific item first
    ItemResponse<Customer> customerResponse = await container.ReadItemAsync<Customer>(customerId, new PartitionKey(customerCity));

    var item = customerResponse.Resource;

    item.orders.Add(new Order { orderId = "O6", category = "Desktop", quantity = 300 });

    // Now let's replace the item
    await container.ReplaceItemAsync<Customer>(item, customerId, new PartitionKey(customerCity));
    Console.WriteLine("Item is updated");
}