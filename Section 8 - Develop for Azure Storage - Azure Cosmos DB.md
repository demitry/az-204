<!-- TOC -->

- [Section 8 - Develop for Azure Storage - Azure Cosmos DB](#section-8---develop-for-azure-storage---azure-cosmos-db)
    - [Section Resources download [145]](#section-resources-download-145)
    - [What are we going to cover [146]](#what-are-we-going-to-cover-146)
    - [What is Azure Cosmos DB [147]](#what-is-azure-cosmos-db-147)
    - [Concept of Partitions [148]](#concept-of-partitions-148)
        - [Partitions](#partitions)
        - [Partition Key](#partition-key)
    - [Costing [149]](#costing-149)
        - [Request Units](#request-units)
        - [Serverless mode](#serverless-mode)
        - [Autoscale mode](#autoscale-mode)
    - [Lab - Creating an Azure Cosmos DB Account [150]](#lab---creating-an-azure-cosmos-db-account-150)
    - [The usage of JSON [151]](#the-usage-of-json-151)
    - [Adding items to the container [152]](#adding-items-to-the-container-152)
        - [New database](#new-database)
        - [New container](#new-container)
    - [More on Partition Keys [153]](#more-on-partition-keys-153)
    - [Running a few queries [154]](#running-a-few-queries-154)
    - [Objects within Objects [155]](#objects-within-objects-155)
    - [JSON Arrays [156]](#json-arrays-156)
    - [Assignment 3: Assignment - Customer quantity total [    ]](#assignment-3-assignment---customer-quantity-total-----)
    - [Lab NET - Create Database and container [157]](#lab-net---create-database-and-container-157)
        - [Which API best suits your workload?](#which-api-best-suits-your-workload)
    - [Lab NET - Adding an item [158]](#lab-net---adding-an-item-158)
    - [Lab NET - Reading items [159]](#lab-net---reading-items-159)
    - [Lab NET - Replacing items [160]](#lab-net---replacing-items-160)
    - [Lab NET - Deleting items [161]](#lab-net---deleting-items-161)
    - [Lab NET - Array of Objects - Adding item [162]](#lab-net---array-of-objects---adding-item-162)
    - [Assignment 4: Assignment NET - Array of Objects - Reading items [    ]](#assignment-4-assignment-net---array-of-objects---reading-items-----)
    - [Assignment 5: Assignment NET - Array of Objects - Adding orders [    ]](#assignment-5-assignment-net---array-of-objects---adding-orders-----)
    - [Lab - Azure Cosmos DB - Table API [163]](#lab---azure-cosmos-db---table-api-163)
    - [Lab NET - Table API - Adding items [164]](#lab-net---table-api---adding-items-164)
    - [When to choose what API [165]](#when-to-choose-what-api-165)
    - [Lab - Stored Procedures [166]](#lab---stored-procedures-166)
    - [Lab - Stored Procedures - Create an item [167]](#lab---stored-procedures---create-an-item-167)
    - [Lab - Triggers [168]](#lab---triggers-168)
    - [Change Feed [169]](#change-feed-169)
    - [Lab - Change Feed - Azure Functions [170]](#lab---change-feed---azure-functions-170)
    - [Lab - Change Feed - Feed Processor [171]](#lab---change-feed---feed-processor-171)
    - [Using Composite Indexes [172]](#using-composite-indexes-172)
    - [Time to live [173]](#time-to-live-173)
    - [Consistency [174]](#consistency-174)

<!-- /TOC -->

<style>
r { color: Red }
o { color: Orange }
g { color: Green }
</style>

# Section 8 - Develop for Azure Storage - Azure Cosmos DB

## Section Resources download [145]

## What are we going to cover [146]

## What is Azure Cosmos DB [147]

- Fully managed NoSQL database
- Milliseconds response time
- Scale automatically

Create Cosmos DB account = choose API

- SQL API
- MongoDB API
- Gremlin (graph based)
- Cassandra
- Table-based API

According to API - different terminology (Container, Item terms)

Database account

Database

## Concept of Partitions [148]

### Partitions

- Logical Partition - items in a container are divided into subsets (partitions)
- Partition key - the partition for the item is decided by the partition key that is associated with the item in the container
- Item Id - uniquely identifies an item in the partition
- Identification: **[Partition key + Item Id]** uniquely identifies an item in the container
- Size: logical partition - up to 20 Gb
- Limit: No limit when it comes to the number of logical partitions within a container

### Partition Key

- <r> **Choose property for the partition key which the value does not change.**</r>
- The property should have a wide range of possible values.
- Once decide on a partition key for the container - <r>**you CANNOT change it.**</r>

## Costing [149]

### Request Units

- Cost of DB operations is measured in terms of Request Units
- Request Units - blended measure of CPU, IOPS and memory usage
- No matter which API is used

Everything is managed by the platform

- Cost of reading 1KB = 1 Request Unit
- Other operations - has their own measure of charged Request Units
- For each operation you can see the amount of Request Units for this operation

You are billed on an hourly basis

Provision : On the container level or on the database level

"throughput" - speed at which data is transferred

### Serverless mode

- You don't provision any throughput

- This is managed by Cosmos DB

- Bill - based on Request Units you consume

### Autoscale mode

Automatically scale up and down the required resources based on the number of requests that your application receives.

- Request Units can autoscale up and down based on demand
- Demand is checked on container abd database level
- Great for critical workloads

## Lab - Creating an Azure Cosmos DB Account [150]

mycosmosacc

mycosmosacc | Quick start

mycosmosacc | Data Explorer

## The usage of JSON [151]

JSON-based data

if sql: relationships between tables, easier to fetch related data

but not all apps need to have complicated design

- don't want to have a strict schema for the data
- don't require complex joins and foreign keys
- want fast access to data

## Adding items to the container [152]

### New database

mycosmosacc | Data Explorer

- New container
- New database

appdb

Database throughput
- Autoscale
- **Manual** (Database throughput (400 - unlimited RU/s)

Estimated cost (USD): $0.032 hourly / $0.77 daily / $23.36 monthly (1 region, 400RU/s, $0.00008/RU)

### New container

Select existing appdb

Container id: Orders (name)

Partition Key: /category

Enable Azure Synapse Link on your Cosmos DB account
Enable Azure Synapse Link to perform near real time analytical analytics on this account, without impacting the performance of your transactional workloads. Azure Synapse Link brings together Cosmos Db Analytical Store and Synapse Analytics

Enabling Azure Synapse Link for this account. This may take a few minutes before you can enable analytical store for this account.

Add Items

```json
{
    "orderId" : "01",
    "category" : "Laptop",
    "quantity" : 100
}
```

Save

```json
{
    "orderId": "01",
    "category": "Laptop",
    "quantity": 100,
    "id": "60d486d0-b378-4ae7-ac5d-634bd88f69af",
    "_rid": "lPVgAPaiwlkBAAAAAAAAAA==",
    "_self": "dbs/lPVgAA==/colls/lPVgAPaiwlk=/docs/lPVgAPaiwlkBAAAAAAAAAA==/",
    "_etag": "\"0000dd9d-0000-0c00-0000-644689cf0000\"",
    "_attachments": "attachments/",
    "_ts": 1682344399
}
```

System based properties added, generated "id" and other.

## More on Partition Keys [153]

Large amounts of data

If search query is based on "category" => quick

Wide range of partition values - important

## Running a few queries [154]

```sql
SELECT * FROM c

SELECT * FROM Orders

SELECT * FROM Orders o
WHERE o.category = "Laptop"

SELECT o.orderId, o.category, o.quantity FROM Orders o
WHERE o.category = "Laptop"
```

```sql
SELECT o.category, SUM(o.quantity) AS Quantity
FROM Orders o
GROUP BY o.category
```

```json
[
    {
        "category": "Desktop",
        "Quantity": 25
    },
    {
        "category": "Mobiles",
        "Quantity": 75
    },
    {
        "category": "Laptop",
        "Quantity": 233
    }
]
```

**Case Sensitive!!!** 

## Objects within Objects [155]

```sql
SELECT o.orderId, o.category, o.quantity, o.customer
FROM Orders o
WHERE o.category="Desktop"
```

```json
[
    {
        "orderId": "03",
        "category": "Desktop",
        "quantity": 25,
        "customer": {
            "customerId": "C3",
            "customerName": "CustomerA"
        }
    },
    {
        "orderId": "04",
        "category": "Desktop",
        "quantity": 425,
        "customer": {
            "customerId": "C3",
            "customerName": "CustomerC"
        }
    }
]
```

```sql
SELECT o.orderId, o.category, o.quantity, o.customer.customerName
FROM Orders o
WHERE o.category="Desktop"
```

```json
[
    {
        "orderId": "03",
        "category": "Desktop",
        "quantity": 25,
        "customerName": "CustomerA"
    },
    {
        "orderId": "04",
        "category": "Desktop",
        "quantity": 425,
        "customerName": "CustomerC"
    }
]
```

## JSON Arrays [156]

Create Customers container

Partition Key: /customerCity

```sql
SELECT c.orders FROM Customers c
SELECT o.quantity FROM o in Customers.orders
```

## Assignment 3: Assignment - Customer quantity total [    ]

```sql
select c.customerName, sum(orders.quantity) as Quantity
from Customers c 
join orders in c.orders 
group by c.customerName
```

```json
[
    {
        "customerName": "CustomerC",
        "Quantity": 450
    },
    {
        "customerName": "CustomerB",
        "Quantity": 75
    },
    {
        "customerName": "CustomerA",
        "Quantity": 100
    }
]
```

## Lab NET - Create Database and container [157]

### Which API best suits your workload?

- Azure Cosmos DB **for NoSQL** - Azure Cosmos DB's core, or native API for working with documents. Supports fast, flexible development with familiar SQL query language and client libraries for .NET, JavaScript, Python, and Java.
- Azure Cosmos DB **for PostgreSQL** - Fully-managed relational database service for PostgreSQL with distributed query execution, powered by the Citus open source extension. Build new apps on single or multi-node clusters—with support for JSONB, geospatial, rich indexing, and high-performance scale-out.
- Azure Cosmos DB **for MongoDB** - Fully managed database service for apps written for MongoDB. Recommended if you have existing MongoDB workloads that you plan to migrate to Azure Cosmos DB.
- Azure Cosmos DB **for Apache Cassandra** - Fully managed Cassandra database service for apps written for Apache Cassandra. Recommended if you have existing Cassandra workloads that you plan to migrate to Azure Cosmos DB.
- Azure Cosmos DB **for Table** - Fully managed database service for apps written for Azure Table storage. Recommended if you have existing Azure Table storage workloads that you plan to migrate to Azure Cosmos DB.
- Azure Cosmos DB **for Apache Gremlin** - Fully managed graph database service using the Gremlin query language, based on Apache TinkerPop project. Recommended for new workloads that need to store relationships between data.


mycosmosacc | Keys

URI and KEY

```csharp

using Microsoft.Azure.Cosmos;

string cosmosDBEndpointUri = "";
string cosmosDBKey = "==";

//await CreateDatabase("appdb");
await CreateContainer("appdb", "Orders", "/category");

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
```

## Lab NET - Adding an item [158]
```csharp
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

    public class Order
    {
        public string id { get; set; }

        public string orderId { get; set; }

        public string category { get; set; }

        public int quantity { get; set; }
    }
```

## Lab NET - Reading items [159]

```csharp
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

```

## Lab NET - Replacing items [160]

```csharp
await ReplaceItems();

await ReadItems(); //to verify

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

```

## Lab NET - Deleting items [161]

```csharp
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
```

## Lab NET - Array of Objects - Adding item [162]

```csharp
string databaseName = "appdb";
string containerName = "Customers";


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
```

## Assignment 4: Assignment NET - Array of Objects - Reading items [    ]

```csharp
await ReadItems();

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
```

## Assignment 5: Assignment NET - Array of Objects - Adding orders [    ]

```csharp
// Adding orders: Update = Replace

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
```

## Lab - Azure Cosmos DB - Table API [163]

cosmosacctable

cosmosacctable | Data Explorer

new table - no concept of partition key

Orders - entities - add entity

PartitionKey Laptop

cosmosacctable | Connection strings

```csharp
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
```

## Lab NET - Table API - Adding items [164]

## When to choose what API [165]

## Lab - Stored Procedures [166]

## Lab - Stored Procedures - Create an item [167]

## Lab - Triggers [168]

## Change Feed [169]

## Lab - Change Feed - Azure Functions [170]

## Lab - Change Feed - Feed Processor [171]

## Using Composite Indexes [172]

## Time to live [173]

## Consistency [174]

Quiz 7: Short Quiz [    ]
