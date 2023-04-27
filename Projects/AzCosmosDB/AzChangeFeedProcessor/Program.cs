using Microsoft.Azure.Cosmos;

string cosmosEndpointUri = "https://.documents.azure.com:443/";

string cosmosDBKey = "==";

string databaseName = "appdb";

string monitoredContainerName = "Orders";

string leaseContainerName = "leases";

await StartChangeProcessor();

async Task StartChangeProcessor()
{
    CosmosClient cosmosClient = new CosmosClient(cosmosEndpointUri, cosmosDBKey);

    Container leaseContainer = cosmosClient.GetContainer(databaseName, leaseContainerName);

    ChangeFeedProcessor changeFeedProcessor =
        cosmosClient.GetContainer(databaseName, monitoredContainerName)
        .GetChangeFeedProcessorBuilder<Order>(
            processorName: "ManageChanges", 
            onChangesDelegate: ManageChanges)
        .WithInstanceName("appHost")
        .WithLeaseContainer(leaseContainer)
        .Build();

    Console.WriteLine("Starting the change feed processor");
    await changeFeedProcessor.StartAsync();

    Console.Read();
    await changeFeedProcessor.StopAsync();
}

static async Task ManageChanges(
    ChangeFeedProcessorContext context,
    IReadOnlyCollection<Order> itemCollection,
    CancellationToken cancellationToken)
{
    foreach(var item in itemCollection)
    {
        Console.WriteLine(item);
    }
}

public class Order
{
    public string id { get; set; }

    public string orderId { get; set; }

    public string category { get; set; }

    public int quantity { get; set; }
    
    public DateTime creationTime { get; set; }

    public override string ToString() => $"Id: {id} OrderId: {orderId}, Category: {category}, Quantity: {quantity} CreationTime: {creationTime}";
    
}