using Azure;
using Azure.Data.Tables;

string connectionString = "";

string tableName = "Orders";

//AddEntity("O1", "Mobile", 100);
//AddEntity("O2", "Laptop", 50);
//AddEntity("O3", "Desktop", 70);
//AddEntity("O4", "Laptop", 200);

void AddEntity(string orderID, string category, int quantity)
{
    TableClient tableClient = new TableClient(connectionString, tableName);

    TableEntity tableEntity = new TableEntity(category, orderID)
    {
        {"quantity",quantity}
    };

    tableClient.AddEntity(tableEntity);
    Console.WriteLine("Added Entity with order ID {0}", orderID);
}

//add one entity twice => Azure.RequestFailedException: 'The specified entity already exists.

QueryEntity("Laptop");
DeleteEntity("Laptop", "O2");
UpdateEntity("Laptop", "O4");
QueryEntity("Laptop");


void QueryEntity(string category)
{
    TableClient tableClient = new TableClient(connectionString, tableName);

    Pageable<TableEntity> results = tableClient.Query<TableEntity>(entity => entity.PartitionKey == category);

    foreach (TableEntity tableEntity in results)
    {
        Console.WriteLine("Order Id {0}", tableEntity.RowKey);
        Console.WriteLine("Quantity is {0}", tableEntity.GetInt32("quantity"));
    }
}

void DeleteEntity(string category, string orderID)
{
    TableClient tableClient = new TableClient(connectionString, tableName);
    tableClient.DeleteEntity(category, orderID);
    Console.WriteLine("Entity with Partition Key {0} and Row Key {1} deleted", category, orderID);
}

void UpdateEntity(string category, string orderID)
{
    TableClient tableClient = new TableClient(connectionString, tableName);
    
    // Get the entity to update.
    TableEntity qEntity = tableClient.GetEntity<TableEntity>(category, orderID);
    qEntity["Price"] = 7.00;
    qEntity["quantity"] = 100;

    tableClient.UpdateEntity(qEntity, qEntity.ETag);

    Console.WriteLine("Entity with Partition Key {0} and Row Key {1} updated", category, orderID);
}