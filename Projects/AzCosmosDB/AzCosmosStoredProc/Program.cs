using Microsoft.Azure.Cosmos;

string cosmosDBEndpointUri = "https://.documents.azure.com:443/";
string cosmosDBKey = "==";

string databaseName = "appdb";
string containerName = "Orders";

CosmosClient cosmosClient = new CosmosClient(cosmosDBEndpointUri, cosmosDBKey);

var container = cosmosClient.GetContainer(databaseName, containerName);

await CallStoredProcedure();

async Task CallStoredProcedure()
{
    var result = await container.Scripts.ExecuteStoredProcedureAsync<string>("Display", new PartitionKey(""), null);
    Console.WriteLine(result);

    dynamic[] orderItems = new dynamic[]
    {
        new
        {
            id = Guid.NewGuid().ToString(),
            orderId = "01",
            category = "Laptop",
            quantity = 66
        },
        new
        {
            id = Guid.NewGuid().ToString(),
            orderId = "02",
            category = "Laptop",
            quantity = 77
        },
        new
        {
            id = Guid.NewGuid().ToString(),
            orderId = "03",
            category = "Laptop",
            quantity = 88
        },
    };

    var insertResult = await container.Scripts.ExecuteStoredProcedureAsync<string>(
        "createItems", 
        new PartitionKey("Laptop"), 
        new[] {orderItems});
    
    Console.WriteLine(insertResult);
}

