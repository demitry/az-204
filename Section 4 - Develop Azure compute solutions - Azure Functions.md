# Section 4: Develop Azure compute solutions - Azure Functions

## 50. What are we going to cover

## 51. What are Azure Function Apps

Completely managed service, no need to maintain infrastructure

## 52. Lab - Azure Function Apps

### Create Function App (service)

appfunction1100

Runtime: .NET

??? Why storage there is no account selection ???

Operating System: Windows or Linux

The plan you choose dictates how your app scales, what features are enabled, and how it is priced. Learn more

Hosting options and plans

* Consumption (Serverless)
Optimized for serverless and event-driven workloads.
* Functions Premium (Not supported for selected region and operating system)
Event based scaling and network isolation, ideal for workloads running continuously.
* App service plan (Not supported for selected subscription)
Fully isolated and dedicated environment suitable for workloads that need large SKUs or need to co-locate Web Apps and Functions.

## 53. Inspecting a HTTP Trigger-based function

appfunction1100 | Functions

```
Your app is currently in read only mode because you have source control integration enabled.
```

Create

```
Select development environment
Instructions will vary based on your development environment. Learn more

Development environmentDevelopment environment
Install dependencies
Before you can get started, you should install Visual Studio Code. You should also install Node.JS which includes npm.

Next, install the Azure Functions extension for Visual Studio Code. Once the extension is installed, click on the Azure logo in the Activity Bar. Under Azure: Functions, click Sign in to Azure... and follow the on-screen instructions.


Create an Azure Functions project
Click the Create New Project… icon in the Azure: Functions panel.

You will be prompted to choose a directory for your app. Choose an empty directory.

You will then be prompted to select a language for your project. Choose .

Create a function
Click the Create Function… icon in the Azure: Functions panel.

You will be prompted to choose a template for your function. We recommend HTTP trigger for getting started.


Run your function project locally
Press F5 to run your function app.

The runtime will output a URL for any HTTP functions, which can be copied and run in your browser's address bar.

To stop debugging, press Shift + F5.


Deploy your code to Azure
Click the Deploy to Function App… () icon in the Azure: Functions panel.

When prompted to select a function app, choose appfunction1100.

```

```
Your app is currently in read only mode because you are running from a package file. To make any changes update the content in your zip file and WEBSITE_RUN_FROM_PACKAGE app setting.
 
```

```
Yes! When you deploy the function app to azure functions for the first time, it will show that message.

There are 2 steps to get rid out of that message:

Step 1: Modify your azure function code locally and publish it again to same function app. Refresh your function application in the azure portal and run your application now in the code+Test menu.

Step 2: Go to Azure Portal > Your Function App > Configuration (in the left index pane) > click on the WEBSITE_RUN_FROM_PACKAGE in the Application Setting and make its value to 0 and click Ok and Save. Restart your function app and go to code+test menu to run your application.
```

Restart appfunction1100
demoHttpTrigger
demostorageaccount1001


functionapp1100 | Functions

Create function

Development environment: Develop in a portal

----------

### Templates:

**HTTP trigger**

A function that will be run whenever it receives an HTTP request, responding based on data in the body or query string

**Timer trigger**

A function that will be run on a specified schedule

**Azure Queue Storage trigger**

A function that will be run whenever a message is added to a specified Azure Storage queue

**Azure Service Bus Queue trigger**

A function that will be run whenever a message is added to a specified Service Bus queue

**Azure Service Bus Topic trigger**

A function that will be run whenever a message is added to the specified Service Bus topic

**Azure Blob Storage trigger**

A function that will be run whenever a blob is added to a specified container

**Azure Event Hub trigger**

A function that will be run whenever an event hub receives a new event

**Azure Cosmos DB trigger**

A function that will be run whenever documents change in a document collection

**IoT Hub (Event Hub)**

A function that will be run whenever an IoT Hub receives a new event from IoT Hub (Event Hub)

**SendGrid**

A function that sends a confirmation e-mail when a new item is added to a particular queue

**Azure Event Grid trigger**

A function that will be run whenever an event grid receives a new event

**Durable Functions Entity HTTP starter**

A function that will trigger whenever it receives an HTTP request to execute an orchestrator function.

**Durable Functions HTTP starter**

A function that will trigger whenever it receives an HTTP request to execute an orchestrator function.

**Durable Functions activity**

A function that will be run whenever an Activity is called by an orchestrator function.

**Durable Functions entity (class)**

A C# entity that stores state and represented by a class.

**Durable Functions entity (function)**

A C# entity that stores state and represented by a function.

**Durable Functions orchestrator**

An orchestrator function that invokes activity functions in a sequence.

**Kafka output**

A function that will send messages to a specified Kafka topic

**Kafka trigger**

A function that will be run whenever a message is added to a specified Kafka topic

**RabbitMQ trigger**

A function that will be run whenever a message is added to a specified RabbitMQ queue

**SignalR negotiate HTTP trigger**

An HTTP triggered function that SignalR clients will call to begin connection negotiation

----------  
DemoHttpTrigger
----------  

run.csx - C# script, it has Run() function

```csharp
#r "Newtonsoft.Json" // Include external libraries

using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;

public static async Task<IActionResult> Run(HttpRequest req, ILogger log)
{
    log.LogInformation("C# HTTP trigger function processed a request.");

// for GET method
    string name = req.Query["name"]; 

// for POST method
    string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
    dynamic data = JsonConvert.DeserializeObject(requestBody);
    name = name ?? data?.name;

    string responseMessage = string.IsNullOrEmpty(name)
        ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                : $"Hello, {name}. This HTTP triggered function executed successfully.";

// OkObjectResult Map to 200 status code
            return new OkObjectResult(responseMessage);
}
```

Get function URL

https://functionapp1100.azurewebsites.net/api/DemoHttpTrigger?code=DdRDJD2Orofa6OGlFUl53np5I8zpweQY2DfwV7ssLiPsAzFu3nLxQA==

?code - code for Azure function

https://functionapp1100.azurewebsites.net/api/DemoHttpTrigger?code=DdRDJD2Orofa6OGlFUl53np5I8zpweQY2DfwV7ssLiPsAzFu3nLxQA==&name=JohnDoe

Add **&name=John%20Doe**

and

Trigger from anywhere:

<https://functionapp1100.azurewebsites.net/api/DemoHttpTrigger?code=DdRDJD2Orofa6OGlFUl53np5I8zpweQY2DfwV7ssLiPsAzFu3nLxQA==&name=John%20Doe>

## 54. Lab - Azure Functions - Azure SQL database - GET Products

GetProduct function in VS

Azure Functions Core Tools
Core Tools Version:       4.0.5095 Commit hash: N/A  (64-bit)
Function Runtime Version: 4.16.5.20396

```bash
[2023-04-13T15:06:06.162Z] Found F:\2023\git\AzureFunctionApp\AzureFunctionApp\AzureFunctionApp.csproj. Using for user secrets file configuration.

Functions:

        GetProduct: [GET] http://localhost:7071/api/GetProduct

For detailed output, run func with --verbose flag.
[2023-04-13T15:06:17.690Z] Host lock lease acquired by instance ID '000000000000000000000000D9201DEE'.
[2023-04-13T15:08:11.317Z] Executing 'GetProduct' (Reason='This function was programmatically called via the host APIs.', Id=f15d3ad4-41d6-4c68-bd35-0312a3533016)
[2023-04-13T15:08:12.240Z] Executed 'GetProduct' (Succeeded, Id=f15d3ad4-41d6-4c68-bd35-0312a3533016, Duration=967ms)
```

```
http://localhost:7071/api/GetProduct
```
```
[{"id":1,"productName":"Mobile","quantity":100},{"id":2,"productName":"Laptop","quantity":200},{"id":3,"productName":"Tabs","quantity":300}]
```

## 55. Publishing the Function to Azure

publish

You can now see that our prior demo function got **deleted** and now it has been **replaced** by our new function.

app is currently in read only mode because you are running from a package.
But we have chosen the setting from Visual Studio.
a package and it is being uploaded onto the function app.

GetProduct | Code + Test

No actual code (as we done in demo) - just function.json


Test Run

```json
[
  {
    "id": 1,
    "productName": "Mobile",
    "quantity": 100
  },
  {
    "id": 2,
    "productName": "Laptop",
    "quantity": 200
  },
  {
    "id": 3,
    "productName": "Tabs",
    "quantity": 300
  }
]
```

Get function Url

https://functionapp1100.azurewebsites.net/api/GetProduct?code=_PgkuLEAPOs6PEFpcbOMF3b5WJiH_tI_6tvkPi0JEco5AzFuB-NQ9Q==

```json
[{"id":1,"productName":"Mobile","quantity":100},{"id":2,"productName":"Laptop","quantity":200},{"id":3,"productName":"Tabs","quantity":300}]
```

## 56. Lab - Azure Functions - Azure SQL database - GET Product by id
http://localhost:7071/api/GetProduct?id=1

```csharp
        [FunctionName("GetProduct")]
        public static async Task<IActionResult> RunGetProduct(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req, ILogger log)
        {
            int productId = int.Parse(req.Query["id"]);
            string sqlQueryTemplate = "SELECT ProductId, ProductName, Quantity FROM Products WHERE ProductId = {0}";
            string sqlQuery = string.Format(sqlQueryTemplate, productId);
            
            Product product = new Product();
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();

                    using (var command = new SqlCommand(sqlQuery, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {

                            reader.Read();
                            product.Id = reader.GetInt32(0);
                            product.ProductName = reader.GetString(1);
                            product.Quantity = reader.GetInt32(2);
                        }
                    }
                    connection.Close();
                    return new OkObjectResult(product);
                }
            }
            catch (System.Exception)
            {
                var response = "No records found";
                return new OkObjectResult(response);
            }
        }
```

https://functionapp1100.azurewebsites.net/api/GetProduct?code=_PgkuLEAPOs6PEFpcbOMF3b5WJiH_tI_6tvkPi0JEco5AzFuB-NQ9Q==<span style="color:red">&Id=1</span>

{"id":1,"productName":"Mobile","quantity":100}

## 57. Lab - Azure Functions - Azure SQL database - POST Adding a method

```csharp
    public static class AddProduct
    {
        [FunctionName("AddProduct")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            Product product = JsonConvert.DeserializeObject<Product>(requestBody);

            SqlConnection sqlConnection = ConnectionHelper.GetConnection();
            sqlConnection.Open();

            string statement = "INSERT INTO Products(ProductId, ProductName, Quantity) VALUES (@id, @name, @quantity)";

            using (SqlCommand sqlCommand = new SqlCommand(statement, sqlConnection))
            {
                sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = product.Id;
                sqlCommand.Parameters.Add("@name", SqlDbType.VarChar).Value = product.ProductName;
                sqlCommand.Parameters.Add("@quantity", SqlDbType.Int).Value = product.Quantity;
                
                sqlCommand.CommandType = CommandType.Text;

                sqlCommand.ExecuteNonQuery();
            }

            return new OkObjectResult("Product has been added");
        }
    }
```

```json
{
    "Id" : 4,
    "ProductName" : "Desktop",
    "Quantity" : 3
}
```

Product has been added

## 58. Using the POSTMAN Tool

## 59. Using Connection Strings

```csharp
        public static SqlConnection GetConnection()
        {
            string connectionString = Environment.GetEnvironmentVariable("SQLAZURECONNSTR_SqlConnectionString");
            return new SqlConnection(connectionString);
        }
```

<https://learn.microsoft.com/en-us/azure/app-service/configure-common?tabs=portal#configure-connection-strings>

Env var prefixed:

* SQLServer: SQLCONNSTR_

* MySQL: MYSQLCONNSTR_

* SQLAzure: SQLAZURECONNSTR_

* Custom: CUSTOMCONNSTR_

* PostgreSQL: POSTGRESQLCONNSTR_

## 60. Calling an Azure Function from a web app

in sql app:

```csharp
    public async Task<List<Product>> GetProducts()
    {
        string functionUrl = "https://functionapp1100.azurewebsites.net/api/GetProducts?code=JF8zoZOxbN4m6QbaIudlJQpYBnqW7rkRFget-PHBlhW6AzFuUaOYdA==";

        using (HttpClient httpClient = new HttpClient())
        {
            HttpResponseMessage responseMessage = await httpClient.GetAsync(functionUrl);

            string content = await responseMessage.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<List<Product>>(content);
        }
    }
```

```csharp
    public void OnGet()
    {
        IsBeta = _productService.IsBetaFeatureEnabled().Result;

        //Products = _productService.GetProducts();
        Products = _productService.GetProducts().GetAwaiter().GetResult();
    }
```

in Azure functions:

```csharp
    // return new OkObjectResult(products);
    // Handshake
    return new OkObjectResult(JsonConvert.SerializeObject(products));
```

## 61. There is more we need to cover

## Quiz 3: Short Quiz