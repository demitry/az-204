<!-- TOC -->

- [Section 11: Monitor, troubleshoot, and optimize Azure solutions](#section-11-monitor-troubleshoot-and-optimize-azure-solutions)
    - [Section Resources download [230]](#section-resources-download-230)
    - [What are we going to cover [231]](#what-are-we-going-to-cover-231)
    - [Quick look at the Azure Monitor service [232]](#quick-look-at-the-azure-monitor-service-232)
    - [Azure Monitor - Setting up alerts [233]](#azure-monitor---setting-up-alerts-233)
    - [Azure Monitor - Dynamic thresholds [234]](#azure-monitor---dynamic-thresholds-234)
    - [What is a Log Analytics Workspace [235]](#what-is-a-log-analytics-workspace-235)
    - [Lab - Log Analytics workspace [236]](#lab---log-analytics-workspace-236)
    - [Azure Web App - Diagnostic [237]](#azure-web-app---diagnostic-237)
    - [Lab - ARM Templates - Action Groups [238]](#lab---arm-templates---action-groups-238)
    - [Lab - ARM Templates - Azure Monitor Metrics [239]](#lab---arm-templates---azure-monitor-metrics-239)
    - [Lab - ARM Templates - Dynamic Metric alerts [240]](#lab---arm-templates---dynamic-metric-alerts-240)
    - [Lab - Log Analytics Query Alert - PowerShell [241]](#lab---log-analytics-query-alert---powershell-241)
        - [My Comment](#my-comment)
    - [What is Application Insights [242]](#what-is-application-insights-242)
        - [Application Insights](#application-insights)
        - [How does it  work?](#how-does-it--work)
    - [Application Insights - Configure the SDK locally [243]](#application-insights---configure-the-sdk-locally-243)
    - [Lab - Azure Application Insights [244]](#lab---azure-application-insights-244)
        - [:8080 GET /robots933456.txt](#8080-get-robots933456txt)
    - [Lab - Application Insights - Performance data [245]](#lab---application-insights---performance-data-245)
    - [Application Insights - Usage Features [246]](#application-insights---usage-features-246)
    - [Application Insights - Availability Tests [247]](#application-insights---availability-tests-247)
    - [Application Insights - Tracking Users [248]](#application-insights---tracking-users-248)
    - [Optimizing Content Delivery [249]](#optimizing-content-delivery-249)
    - [What is Azure Cache for Redis [250]](#what-is-azure-cache-for-redis-250)
        - [Azure Cache for Redis](#azure-cache-for-redis)
        - [Use cases](#use-cases)
            - [Data Cache - Top 10 courses for the day](#data-cache---top-10-courses-for-the-day)
            - [Content Cache - Header, Footer, Static content of web page](#content-cache---header-footer-static-content-of-web-page)
            - [Session Store - E-Commerce - Cart item](#session-store---e-commerce---cart-item)
    - [Lab - Creating the Cache [251]](#lab---creating-the-cache-251)
    - [Lab - Azure Redis Data types [252]](#lab---azure-redis-data-types-252)
        - [Data types](#data-types)
        - [Redis Console Commands](#redis-console-commands)
    - [Lab - Azure Cache for Redis - .NET [253]](#lab---azure-cache-for-redis---net-253)
    - [Lab - Azure Cache for Redis - Classes [254]](#lab---azure-cache-for-redis---classes-254)
    - [Assignment 7: Assignment - .NET Classes - Get Cache data](#assignment-7-assignment---net-classes---get-cache-data)
    - [Note on Redis data types [255]](#note-on-redis-data-types-255)
    - [Redis Cache key eviction [256]](#redis-cache-key-eviction-256)
    - [Lab - Invalidate Cache keys [257]](#lab---invalidate-cache-keys-257)
        - [DeleteKey](#deletekey)
        - [Set Key Expiry Time](#set-key-expiry-time)
    - [ASP.NET Example - Azure Cache for Redis [258]](#aspnet-example---azure-cache-for-redis-258)
    - [Redis Eviction Policies](#redis-eviction-policies)
        - [Eviction policies](#eviction-policies)
    - [What is Azure Content Delivery Network [259]](#what-is-azure-content-delivery-network-259)
    - [Lab - Azure Content Delivery Network [260]](#lab---azure-content-delivery-network-260)
    - [Azure Content Delivery Network Caching [261]](#azure-content-delivery-network-caching-261)
    - [What is Azure Front Door [262]](#what-is-azure-front-door-262)
    - [Lab - Azure Front Door - Setup [263]](#lab---azure-front-door---setup-263)
    - [Lab - Azure Front Door - Implementation [264]](#lab---azure-front-door---implementation-264)
    - [Azure Front Door - Other aspects [265]](#azure-front-door---other-aspects-265)
    - [Quiz 9: Short Quiz](#quiz-9-short-quiz)

<!-- /TOC -->

# Section 11: Monitor, troubleshoot, and optimize Azure solutions
## Section Resources download [230]
## What are we going to cover [231]

## Quick look at the Azure Monitor service [232]

webapp10001 | Metrics

Monitor | Metrics

Monitor | Activity log

- Logs any Azure administrative activity, check JSON

## Azure Monitor - Setting up alerts [233]

Create an alert rule

- Scope
- Add Condition - Select a signal
- Activity Log - based on an operation on VM (Power Off, ... )
- => trigger alert
- Metrics - (CPU percentage, memory percentage, network...)
- Threshold: Static, Dynamic
- Aggregation granularity: 5 min
- Frequency of evaluation
- Actions, Action Group - what needs to be done
- Create an action Group, Notification type
- Trigger
  - Automation Runbook (Powershell Script)
  - Azure Function
  - Event Hub
  - ITSM
  - Logic App
  - Secure Webhook
  - Webhook
- Severity
  - 4 - Verbose
  - 3 - Informational
  - 2 - Warning
  - 1 - Error
  - 0 - Critical
- Alert Rule Name
- 0.10 USD/month - Metric Alert Rule - cost per month
- Create

## Azure Monitor - Dynamic thresholds [234]

Dynamic Threshold

Azure Monitor uses machine learning to check the historical behavior of metrics.

Metric is always 40 percent. But now it is 80 percent - deviating from normal.

Based on historical data.

Define sensitivity:

  - High - alert triggered for the smallest deviation.
  - Medium - more balanced thresholds
  - Low - alert only triggered on large deviation

Configure signal logic - Alert Logic - Dynamic (not static)

Threshold sensitivity: Medium

## What is a Log Analytics Workspace [235]

Log Data -> Log Analytics Workspace

Custom Query Language

Visualization and Dashboards

## Lab - Log Analytics workspace [236]

Create Log Analytics workspace and connect multiple machines log to this centralized log workspace

Deprecated:
LogWorkspace | Service map (deprecated
LogWorkspace | Virtual machines (deprecated)

linuxvm - Connect

linuxvm | Extensions and Applications - installs agent

Installs Microsoft Monitoring Agent

Which data should be collected?

LogWorkspace | Agents Configuration

- Windows event logs (application events log etc.)
- Windows performance counters
- Linux performance counters
- Syslog
- IIS Logs
- Your own custom logs

LogWorkspace | Logs - LogManagement -  check tables
- Heartbeat
- Event
- Syslog

type the name of the table - Run

Event - Run

to check log records

## Azure Web App - Diagnostic [237]

webapp10001 | Diagnostic settings

Click 'Add Diagnostic setting' above to configure the collection of the following data:

- HTTP logs
- App Service Console Logs
- App Service Application Logs
- Access Audit Logs
- IPSecurity Audit logs
- App Service Platform logs
- AllMetrics

Add diagnostic setting
- [x] HTTP logs
- [x] App Service Console Logs
- [x] App Service Application Logs
- [x] Access Audit Logs
- [x] IPSecurity Audit logs
- [x] App Service Platform logs

Destination details
- [x] Send to Log Analytics workspace
  - Select LogWorkspace

- [] Archive to a storage account
- [] Stream to an event hub
- [] Send to partner solution

Save

LogWorkspace | Logs - LogManagement

- AppServiceAppLogs
- AppServiceConsoleLogs
- AppServiceHTTPLogs

Question 8:
Your team has an Azure Web App in place. You need to set the diagnostic setting for the Azure Web App to get the required log information. Which of the following can be used to check for any configuration changes to the Azure Web App?

Answer:

- AppServiceEnvironmentPlatformLogs

Question 9:
Your team has an Azure Web App in place. You need to set the diagnostic setting for the Azure Web App to get the required log information. Which of the following can be used to check for Container operation logs?

Answer:

- AppServicePlatformLogs

Good job!

You can get this information from AppServicePlatformLogs. For more information on the different types of logs you can go to the URL - <https://azure.microsoft.com/en-us/updates/azure-app-service-diagnostic-settings-feature-reaches-general-availability/>

## Lab - ARM Templates - Action Groups [238]

**Bicep** language support for Visual Studio Code and Visual Studio

Create resource from custom template

```json
{
  "$schema": "https://schema.management.azure.com/schemas/2019-04-01/deploymentTemplate.json#",
  "contentVersion": "1.0.0.0",
  "parameters": {},
  "functions": [],
  "variables": {},
  "resources": [
    {
      "type": "Microsoft.Insights/actionGroups",
      "apiVersion": "2021-09-01",
      "name": "AlertGroupB",
      "location": "Global",
      "properties": {
        "groupShortName": "AlertGroupB",
        "enabled": true,
        "emailReceivers": [
          {
            "name": "AdminEmail",
            "emailAddress": "dpoluektov@gmail.com",
            "useCommonAlertSchema": true
          }
        ]
      }
    }
  ],
  "outputs": {}
}
```

## Lab - ARM Templates - Azure Monitor Metrics [239]

```json
{
    "$schema": "https://schema.management.azure.com/schemas/2019-04-01/deploymentTemplate.json#",
    "contentVersion": "1.0.0.0",
    "parameters": {},
    "functions": [],
    "variables": {},
    "resources": [
        {
            "name": "CPUAlert",
            "type": "Microsoft.Insights/metricAlerts",
            "location": "global",
            "apiVersion": "2018-03-01",
            "properties": {
                "description": "Alert for when the VM CPU Percentage goes beyond 70%",
                "severity": 2,
                "enabled": true,
                "scopes": [
                    "[resourceId('Microsoft.Compute/virtualMachines', 'appvm')]"
                ],
                "evaluationFrequency": "PT5M",
                "windowSize": "PT5M",
                "criteria": {
                    "odata.type": "Microsoft.Azure.Monitor.SingleResourceMultipleMetricCriteria",
                    "allOf": [
                        {
                            "name": "1st criterion",
                            "metricName": "Percentage CPU",
                            "dimensions": [],
                            "operator": "GreaterThanOrEqual",
                            "threshold": 70,
                            "timeAggregation": "Average"
                        }
                    ]
                },
                "actions": [
                    {
                        "actionGroupId": "[resourceId('Microsoft.Insights/ActionGroups', 'AlertGroupB')]"
                    }
                ]
            }
        }
    ],
    "outputs": {}
}
```

Home - Monitor - Alert Rules

## Lab - ARM Templates - Dynamic Metric alerts [240]

```
NOTE:
"criteria": {
"odata.type": "Microsoft.Azure.Monitor.MultipleResourceMultipleMetricCriteria",

... "criterionType": "DynamicThresholdCriterion"
```

```json
{
    "$schema": "https://schema.management.azure.com/schemas/2019-04-01/deploymentTemplate.json#",
    "contentVersion": "1.0.0.0",
    "parameters": {},
    "functions": [],
    "variables": {},
    "resources": [
        {
            "name": "DynamicCPUAlert",
            "type": "Microsoft.Insights/metricAlerts",
            "location": "global",
            "apiVersion": "2018-03-01",
            "properties": {
                "description": "Dynamic Alert for an Azure VM",
                "severity": 2,
                "enabled": true,
                "scopes": [
                    "[resourceId('Microsoft.Compute/virtualMachines', 'appvm')]"
                ],
                "evaluationFrequency": "PT5M",
                "windowSize": "PT5M",
                "criteria": {
                    "odata.type": "Microsoft.Azure.Monitor.MultipleResourceMultipleMetricCriteria",
                    "allOf": [
                        {
                            "criterionType": "DynamicThresholdCriterion",
                            "name": "1st criterion",
                            "metricName": "Percentage CPU",
                            "dimensions": [],
                            "operator": "GreaterThan",
                            "timeAggregation": "Average",
                            "alertSensitivity": "Medium",
                            "failingPeriods": {
                                "numberOfEvaluationPeriods": "4",
                                "minFailingPeriodsToAlert": "3"
                            }
                        }
                    ]
                },
                "actions": [
                    {
                        "actionGroupId": "[resourceId('Microsoft.Insights/ActionGroups', 'AlertGroupB')]"
                    }
                ]
            }
        }
    ],
    "outputs": {}
}
```

## Lab - Log Analytics Query Alert - PowerShell [241]

LogWorkspace | Properties
Resource ID
/subscriptions/a77b1bf0-3869-4d3f-9d30-42037952d048/resourceGroups/app-grp/providers/Microsoft.OperationalInsights/workspaces/LogWorkspace
P:
New-AzScheduledQueryRuleSource' is not recognized as a name of a cmdlet
S:
Install-Module -Name Az -AllowClobber
Install-Module -Name Az -Scope CurrentUser -Repository PSGallery -Force

### My Comment

Error message:
"The term 'New-AzScheduledQueryRuleSource' is not recognized as a name of a cmdlet, function, script file, or executable program."
```
Note, there is a difference between versions of Az Powershell v. 8.3.0 and v. 9.7.1
A lot of commands are removed in v. 9.7.1
(New-AzScheduledQueryRuleSchedule, New-AzScheduledQueryRuleSource, New-AzScheduledQueryRuleTriggerCondition etc. were removed)
Also the New-AzScheduledQueryRule command is run with a completely different set of parameters:
```
<https://learn.microsoft.com/en-us/powershell/module/az.monitor/new-azscheduledqueryrule?view=azps-8.3.0>
<https://learn.microsoft.com/en-us/powershell/module/az.monitor/new-azscheduledqueryrule?view=azps-9.7.1>

## What is Application Insights [242]

### Application Insights

  - Monitoring - performance management and monitoring of live web apps
  - Aspects - detecting performance issues, or any other issues
  - Support - .NET, Node.js, Java, Python
  - Applications - hosted on Azure, pn-premises environment, other cloud
  - Integration - Visual Studio IDE
  - Users - you can see how users interact with your application

### How does it  work?

  - Install small SDK for your application
  - Or use Application Insights agent
  - Telemetry data sent by Application Insights has very little impact on the performance of your application

## Application Insights - Configure the SDK locally [243]

VS -> sqlapp -> Right Click -> Configure Application Insights
    - Application Insights Sdk (local)
    - Azure Application Insights

Choose local,
 - [x] Code
 - [y] Nuget Package

 ```
 Connecting to Application Insights Sdk (Local) dependency appInsights1 in the project...
Installing NuGet packages to project...
Installing package 'Microsoft.ApplicationInsights.AspNetCore' with version '2.15.0'.
Adding code to Startup.cs...
Serializing new Application Insights Sdk (Local) dependency metadata to disk...
SuccessComplete. Application Insights Sdk (Local) appInsights1 is configured.
 ```

```cs
// Program.cs
builder.Services.AddApplicationInsightsTelemetry();
```

Run App

VS -> View -> Other Windows -> Application Insights Search

Diagnostic Tools -> Events => Observe Application Insights Events

Search debug session telemetry

Microsoft.ApplicationInsights.AspNetCore - **Deprecated**, **Update It**

## Lab - Azure Application Insights [244]

webapp10001 | Application Insights

Application Insights

Collect application monitoring data using Application Insights

Enable

Change your resource

Create new resource

New resource name: Insights-webapp10001202305262023

Log Analytics Workspace

  - Create a new Application Insights Resource
  - Connect it to the Azure Web App
  - Deploy New Analytic Workspace that will be connected to the Application Insights

VS -> Connected Services
    - Application Insights Sdk (Local)
    - Azure App Configuration

Right Click on Connected Services - Manage Connected Services

Application Insights Sdk (Local) - Disconnect (Remove Dependency), Save All

(because we connect to App Insights in the Azure Platform)

Publish App

Insights-webapp10001202305262023 | Live metrics

P: Data is temporarily inaccessible. The updates on our status are posted here https://aka.ms/aistatus

S: **Disable Chrome AD Blockers!**

Insights-webapp10001202305262023 

Investigate
  - Application map
  - Smart detection
  - Live metrics
  - Transaction search
  - Availability
  - Failures
  - Performance
  - Troubleshooting guides (preview)

Monitoring
  - Alerts
  - Metrics
  - Diagnostic settings
  - Logs
  - Workbooks

Usage
  - Users
  - Sessions
  - Events
  - Funnels
  - User Flows
  - Cohorts
  - More

Configure
  - Properties
  - Smart detection settings
  - Network Isolation
  - Usage and estimated costs
  - API Access
  - Work Items

Settings
  - Locks
  - Automation
  - Tasks (preview)
  - Export template
  - Support + troubleshooting
  - New Support Request

### 169.254.130.6:8080 GET /robots933456.txt

Failed Event

169.254.130.6:8080 GET /robots933456.txt

```
You can safely ignore this message. /robots933456.txt is a dummy URL path that App Service uses to check if the container is capable of serving requests. A 404 response simply indicates that the path doesn't exist, but it lets App Service know that the container is healthy and ready to respond to requests.
```

<https://github.com/MicrosoftDocs/azure-docs/blob/main/includes/app-service-web-configure-robots933456.md>

## Lab - Application Insights - Performance data [245]

Insights-webapp10001202305262023 | Performance

  - OPERATION NAME
  - DURATION (AVG)
  - COUNT

End-to-end transaction details

GET /Index transaction

+ check Dependent request to the SQL Database

dbserver11101 appdb

Command(connection to the SQL DB)

tcp:dbserver11101.database.windows.net,1433 | appdb

Cannot see actual SQL command

```cs
string sqlQuery = "SELECT ProductId, ProductName, Quantity FROM Products";
```

How to see it in Application Insights ?

Program.cs

```cs
using Microsoft.ApplicationInsights.DependencyCollector;
/// ...
builder.Services.ConfigureTelemetryModule<DependencyTrackingTelemetryModule>((module, o) => { module.EnableSqlCommandTextInstrumentation = true; });
```

Publish

Insights-webapp10001202305262023 | Performance


Select a sample operation

Sort by Date

End-to-end transaction details

Now you can see command

```sql
SELECT ProductId, ProductName, Quantity FROM Products
```

For NON-PROD envs!

## Application Insights - Usage Features [246]

Usage
  - Users - how many users?
  - Sessions - sessions of user activity, app pages and features
  - Events - how often certain pages and features have been used? 
  - Funnels - multiple stages like a pipeline, how users are processing through the app as an entire process
  - Cohorts - set if users, sessions, events or operations, that have something in common. It helps analyze a particular set of users or events.
  - Impact - how load times and other aspects of your application impact the conversion rate for your application
  - Retention - how many users return back to your application
  - User Flows
    - What users click
    - What users churn (go out) the most from the site
    - Are there places in the application where the users repeat the same action over and over again
  - More
  

Insights-webapp10001202305262023 | Users

Insights-webapp10001202305262023 | Sessions

Insights-webapp10001202305262023 | Events

...

View More Insights


## Application Insights - Availability Tests [247]

Insights-webapp10001202305262023 | Availability

Add Standard test

Name: WebTest

URL: https://webapp10001.azurewebsites.net

[] Parse dependent requests

Test Frequency

Test Locations (different locations)

"Create"

Samples, Duration from different locations....
 
## Application Insights - Tracking Users [248]

How to Record an auth user Id when it come to App Insights ?

Insights-webapp10001202305262023 | Users

**No users info**

Operating system - < undefined >

Browser version - < undefined >

=>

Services/TelemetryService.cs

```cs
using Microsoft.ApplicationInsights.AspNetCore.TelemetryInitializers;
using Microsoft.ApplicationInsights.Channel;
using Microsoft.ApplicationInsights.DataContracts;

namespace sqlapp.Services
{
    public class TelemetryService : TelemetryInitializerBase

    {
        public TelemetryService(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
        }

        protected override void OnInitializeTelemetry(HttpContext platformContext, RequestTelemetry requestTelemetry, ITelemetry telemetry)
        {
            telemetry.Context.User.AuthenticatedUserId = platformContext.User?.Identity.Name ?? string.Empty;
        }
    }
}
```

Program.cs

```cs
builder.Services.AddSingleton<ITelemetryInitializer, TelemetryService>();
```

## Optimizing Content Delivery [249]

Optimize the content delivery and performance

Web App (Central US location)

Users - across the World

How do users across the world get a seamless experience when it comes to delivery of application content?

- **Azure Content Delivery Network Service**

- **Azure Cache for Redis**

SQL Server database

Fetching data from the disk - delay

Each machine has fast cache memory

Impossible to store all data in fast memory, just frequently accessed data

Web App => Redis (faster memory) <=> Azure SQL Database

## What is Azure Cache for Redis [250]

### Azure Cache for Redis

- Data Store - In-memory data store that is based on the Redis software
- Server memory - Here you can store frequently accessed data in server memory
- Advantage - quick R\W
- For the application - helps to provide low latency to your data and high throughput

### Use cases

#### Data Cache - Top 10 courses for the day

Cache is based on persistent data

There is no direct connection between cache and database, they are separate components.

Example:

Top 10 courses for the day

- The Application would calculate the Top 10 courses for the day based on the data in the database
- Then the application would store it to the Azure Cache for Redis
- The application would catch this data from Azure Cache for Redis
- The application would then update this data on a daily basis.

#### Content Cache - Header, Footer, Static content of web page

Store Header, Footer, Static content of web page in the Azure Cache for Redis.

#### Session Store - E-Commerce - Cart item

E-Commerce session store - Cart item - stored in the Azure Cache

## Lab - Creating the Cache [251]

Create Resource - Azure Cache for Redis

DNS name: appcache1000

appcache1000.redis.cache.windows.net

Cache type: C0 (View full pricing options) - Select, Basic C0 (250 Mb Cache, No SLA) - 16$ / month

Connectivity method: Public Endpoint

Non-TLS port [] Enable

Redis version: Latest - 6

Todo: Console commands + interact from the App

## Lab - Azure Redis Data types [252]

<https://redis.io/>

<https://redis.io/docs/data-types/tutorial/>

### Data types

  - **Strings** - as sequence of bytes
  - **Lists** - lists of strings sorted by insertion order
  - **Sets** -  unordered collections of unique strings that act like the sets, you can add, remove, and test for existence O(1) time
  - **Hashes** - are record types modeled as collections of field-value pairs. As such, Redis hashes resemble Python dictionaries, Java HashMaps
  - **Sorted sets** - are collections of unique strings that maintain order by each string's associated score
  - **Streams** - is a data structure that acts like an append-only log. Streams help record events in the order they occur and then syndicate them for processing.
  - **Geospatial indexes** - are useful for finding locations within a given geographic radius or bounding box.
  - **Bitmaps** - let you perform bitwise operations on strings
  - **Bitfields** - efficiently encode multiple counters in a string value. Bitfields provide atomic get, set, and increment operations and support different overflow policies.
  - **HyperLogLog** - data structures provide probabilistic estimates of the **cardinality** (i.e., number of elements) of large sets.

Stored as key-value pairs

### Redis Console Commands
```bash
>set top:3:courses "AZ-104,AZ-305,AZ-204"
OK
>get top:3:courses
"AZ-104,AZ-305,AZ-204"
>set top:course:rating 4.9
OK
>get top:course:rating
"4.9"
>set top:course:rating 4.8
OK
>get top:course:rating
"4.8"
>exists top:course:rating
(integer) 1
>del top:course:rating
(integer) 1
>exists top:course:rating
(integer) 0
```

Introduction to Redis lists

Redis lists are linked lists of string values. Redis lists are frequently used to:

  - Implement stacks and queues.
  - Build queue management for background worker systems.

```bash
>lpush top:3:courses "AZ-104"
(error) WRONGTYPE Operation against a key holding the wrong kind of value
>del top:3:courses
(integer) 1
>lpush top:3:courses "AZ-104"
(integer) 1
>lpush top:3:courses "AZ-305"
(integer) 2
>lpush top:3:courses "AZ-204"
(integer) 3
>lrange top:3:courses
(error) ERR wrong number of arguments for 'lrange' command
>lrange top:3:courses 0 -1
1) "AZ-204"
2) "AZ-305"
3) "AZ-104"
```

## Lab - Azure Cache for Redis - .NET [253]

nuget: StackExchange.Redis

appcache1000 | Access keys

Primary connection string (StackExchange.Redis)

appcache1000.redis.cache.windows.net:6380,password=4o5...60c=,ssl=True,abortConnect=False

```cs
using StackExchange.Redis;

string connectionString = "appcache1000.redis.cache.windows.net:6380,password=4o5...S60c=,ssl=True,abortConnect=False";

string keyTopCourses = "top:3:courses";

ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(connectionString);

void SetCacheData()
{
    IDatabase database = redis.GetDatabase();
    database.StringSet(keyTopCourses, "AZ-104,AZ-305,AZ-204");
    Console.WriteLine("Cache data has been set");
}

void GetCacheData()
{
    IDatabase database = redis.GetDatabase();

    string? result = database.KeyExists(keyTopCourses) ? 
        database.StringGet(keyTopCourses) : "Key does not exist";
    
    Console.WriteLine(result);
}

SetCacheData();

GetCacheData();
```

## Lab - Azure Cache for Redis - Classes [254]

```cs
void SetClassCacheData(string userId, int productId, int quantity)
{
    IDatabase database = redis.GetDatabase();
    CartItem cartItem = new CartItem() { ProductId = productId, Quantity = quantity };
    string key = String.Concat(userId, ":cartitems");
    database.ListRightPush(key, JsonConvert.SerializeObject(cartItem));
    Console.WriteLine("Cache data has been set");
}
```

## Assignment 7: Assignment - .NET Classes - Get Cache data

```cs
List<CartItem> GetClassCacheData(string userId)
{
    IDatabase database = redis.GetDatabase();
    string key = String.Concat(userId, ":cartitems");
    RedisValue[] redisValues = database.ListRange(key);
    List<CartItem> cartItems = new List<CartItem>();

    foreach (var redisValue in redisValues)
    {
        CartItem cartItem = JsonConvert.DeserializeObject<CartItem>(redisValue);
        cartItems.Add(cartItem);
    }

    foreach (var cart in cartItems)
    {
        Console.WriteLine($"{cart.ProductId} {cart.Quantity}");
    }

    return cartItems;
}

```
## Note on Redis data types [255]

Channels in Redis: Subscribe and unsubscribe

<https://redis.io/docs/manual/pubsub/>

## Redis Cache key eviction [256]

<https://redis.io/docs/reference/eviction/>

How the eviction process works

It is important to understand that the eviction process works like this:

- A client runs a new command, resulting in more data added.
- Redis checks the memory usage, and if it is greater than the maxmemory limit , it evicts (delete) keys according to the policy.
- A new command is executed, and so forth.

## Lab - Invalidate Cache keys [257]

### DeleteKey

>exists top:3:courses

(integer) 1

```cs
void DeleteKey(string keyName)
{
    IDatabase database = redis.GetDatabase();
    if(database.KeyExists(keyName))
    {
        database.KeyDelete(keyName);
        Console.WriteLine("Key deleted");
    }
    else
    {
        Console.WriteLine("Key does not exists");
    }
}

DeleteKey("top:3:courses");
```

>exists top:3:courses

(integer) 0

### Set Key Expiry Time

```cs
void SetExpiryTime(string key, TimeSpan expiry)
{
    IDatabase database = redis.GetDatabase();
    database.KeyExpire(key, expiry);
    Console.WriteLine($"Set the key {key} expiry to {expiry.TotalSeconds} seconds");
}

SetCacheData();
SetExpiryTime(keyTopCourses, new TimeSpan(0, 0, 30));
```

>exists top:3:courses

(integer) 1

After 30 sec:

>exists top:3:courses

(integer) 0

## ASP.NET Example - Azure Cache for Redis [258]

Integrate Cache for Redis into Web App

```cs
using StackExchange.Redis;
//...
string redisConnectionString = "appcache1000.redis.cache.windows.net:6380,password=......=,ssl=True,abortConnect=False";
var multiplexer = ConnectionMultiplexer.Connect(redisConnectionString);
builder.Services.AddSingleton<IConnectionMultiplexer>(multiplexer);
```

```cs
        public List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();

            IDatabase database = _redis.GetDatabase();
            string key = "productlist";

            if(database.KeyExists(key))
            {
                long listLenght = database.ListLength(key);
                for (int i = 0; i < listLenght; i++)
                {
                    string value = database.ListGetByIndex(key, i);
                    Product product = JsonConvert.DeserializeObject<Product>(value);
                    products.Add(product);
                }
                return products;
            }

            string sqlQuery = "SELECT ProductId, ProductName, Quantity FROM Products";

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand(sqlQuery, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Product product = new Product()
                            {
                                Id = reader.GetInt32(0),
                                ProductName = reader.GetString(1),
                                Quantity = reader.GetInt32(2),
                            };
                            database.ListRightPush(key, JsonConvert.SerializeObject(product));
                            products.Add(product);
                        }
                    }
                }
                connection.Close();
                return products;
            }
        }
```


>exists productlist

(integer) 1

>lrange productlist 0 -1
1) "{\"Id\":1,\"ProductName\":\"Mobile\",\"Quantity\":100}"
2) "{\"Id\":2,\"ProductName\":\"Laptop\",\"Quantity\":200}"
3) "{\"Id\":3,\"ProductName\":\"Tabs\",\"Quantity\":300}"
>

## Redis Eviction Policies

<https://redis.io/docs/reference/eviction/>

Question 10:
Which of the following is the ideal policy to use in Redis when you have the following requirement when it comes to items in the cache?

“When you expect a subset of elements will be accessed far more than the rest”

Answer: allkeys-lru

### Eviction policies

The exact behavior Redis follows when the maxmemory limit is reached is configured using the maxmemory-policy configuration directive.

The following policies are available:

noeviction: New values aren’t saved when memory limit is reached. When a database uses replication, this applies to the primary database

allkeys-lru: Keeps most recently used keys; removes least recently used (LRU) keys

allkeys-lfu: Keeps frequently used keys; removes least frequently used (LFU) keys

volatile-lru: Removes least recently used keys with the expire field set to true.

volatile-lfu: Removes least frequently used keys with the expire field set to true.

allkeys-random: Randomly removes keys to make space for the new data added.

volatile-random: Randomly removes keys with expire field set to true.

volatile-ttl: Removes keys with expire field set to true and the shortest remaining 
time-to-live (TTL) value.

The policies volatile-lru, volatile-lfu, volatile-random, and volatile-ttl behave like noeviction if there are no keys to evict matching the prerequisites.

Picking the right eviction policy is important depending on the access pattern of your application, however you can reconfigure the policy at runtime while the application is running, and monitor the number of cache misses and hits using the Redis INFO output to tune your setup.

In general as a rule of thumb:

Use the allkeys-lru policy when you expect a power-law distribution in the popularity of your requests. That is, you expect a subset of elements will be accessed far more often than the rest. This is a good pick if you are unsure.

Use the allkeys-random if you have a cyclic access where all the keys are scanned continuously, or when you expect the distribution to be uniform.

Use the volatile-ttl if you want to be able to provide hints to Redis about what are good candidate for expiration by using different TTL values when you create your cache objects.

The volatile-lru and volatile-random policies are mainly useful when you want to use a single instance for both caching and to have a set of persistent keys. However it is usually a better idea to run two Redis instances to solve such a problem.

It is also worth noting that setting an expire value to a key costs memory, so using a policy like allkeys-lru is more memory efficient since there is no need for an expire configuration for the key to be evicted under memory pressure.

## What is Azure Content Delivery Network [259]

Azure CDN - delivering content across the globe

Web App - Central US

West US, North Europe access, not ideal access time?

CDN helps to deliver content to users across the globe by placing content on physical nodes placed across the globe.

We have source in Central US

=> Create a CDN profile on global level, endpoint is defined and configured, endpoint points to our web app.

Instead of giving URL to the app, we give URL that is attached to the CDN.

East US, User <-> CDN profile (Global level, endpoint) <-> Web app (Central US, source)

**Flow**:

1. The user from East US makes a request to the CDN endpoint

2. The CDN checks whether the the Point of Presence location is closest to the user has the requested file.

3. If not - a request is made to the source.

4. A server in the Point of presence location will then cache the requested file.

5. The server will also send the file to the user.

<https://datacenters.microsoft.com/globe/explore>

Network PoP (Point of presence) - have ability to cache your data, when it comes to Azure CDN, CDN uses these PoP locations to deliver data across the globe.

## Lab - Azure Content Delivery Network [260]

New resource

**Front Door and CDN profiles**

Azure Front Door and CDN profiles is security led, modern cloud CDN that provides static and dynamic content acceleration, global load balancing and enhanced security for your apps, APIs and websites with intelligent threat protection.

- Built-in security to protect your apps and content
- Single platform for static and dynamic acceleration
- Fast, global network with instant failover
- Seamless integration with Azure services and DevOps
- Powerful real-time advanced analytics
- Simplified billing for security and delivery


**Azure Front Door**

Azure Front Door is a secure cloud CDN which provides static and dynamic content acceleration, global load balancing and protection of your apps, APIs and websites with intelligent threat protection.

**Explore other offerings**

See offerings for our Azure Front Door (classic) and Azure CDN Standard from Microsoft (classic), along with our partner offerings.

- Azure Front Door (classic) - A global and scalable entry point that uses Microsoft global network to provide dynamic application acceleration, load balancing and security.
- Azure CDN Standard from Microsoft (classic) - A global content delivery network that uses Microsoft global network for content caching and acceleration.
- Azure CDN Premium from Verizon - Verizon Media operates a global CDN platform with a focus on media streaming, delivery and security.
- Azure CDN Standard from Verizon - Verizon Media operates a global CDN platform with a focus on media streaming, delivery and security.

Choose

Azure CDN Standard from Verizon

Region: Global

Name: cdnprofile1000

CDN endpoint name: sqlapp

Origin type: Web App

Origin hostname: webapp10001.azurewebsites.net

Review + Create

In order to create this CDN profile, please ensure that Microsoft.CDN is listed as a registered Resource Provider in your Azure subscription

```powershell
Connect-AzAccount
Select-AzSubscription -SubscriptionId 'a77b1bf0-3869-4d3f-9d30-42037952d048'

# PS cmdlet to check if the provider is registered
Get-AzResourceProvider -ProviderNamespace Microsoft.CDN

# If it is not registered, Run the below command to register the Resource Provider
Register-AzResourceProvider -ProviderNamespace Microsoft.CDN
```

OR

How to Add Microsoft.CDN as a Registered Resource Provider Using the Portal
Option 1

- Logon to your Azure portal https://portal.azure.com/
- Search for and open the Subscriptions blade
- Under Settings select Resource Providers
- Search for CDN or Microsoft.CDN
- Select Microsoft.CDN and click the register button

**WAIT 5 min** and re-create

sqlapp (cdnprofile1000/sqlapp)
Endpoint

https://sqlapp.azureedge.net

404 - Not Found

Stream line across the World, 

**WAIT 10-20 minutes**

First GET https://sqlapp.azureedge.net/ = 264 ms

Second GET https://sqlapp.azureedge.net/ = 33 ms

Third GET https://sqlapp.azureedge.net/ = 29 ms

=> CDN works.

## Azure Content Delivery Network Caching [261]

Static and dynamic data

If data not changes frequently

```sql
SELECT * FROM Products;

UPDATE Products SET Quantity = 120 WHERE ProductID = 1
```

sqlapp (cdnprofile1000/sqlapp) | Caching rules

Default cache expiration duration - 7 days (by default)

Global caching rules

These rules affect the CDN caching behavior for all requests, and can be overridden using Custom Cache Rules below for certain scenarios. Note that the Query string caching behavior setting does not affect files that are not cached by the CDN.

Custom caching rules

Create caching rules based on specific match conditions. These rules override the default settings above, and are evaluated from top to down. This means that rules lower on the list can override rules above it in the list, as well as the global caching rules and default behavior. Therefore it makes more sense to have more specific rules towards the bottom of the list so they are not overwritten by a general rule under them. For example a rule for path '/folder/images/*' should be below a rule for path '/folder/*'.

Set:

Global caching rules

Caching behavior: Override

Cache expiration duration: 1 min.

Query string caching behavior: Ignore query string

Save

sqlapp (cdnprofile1000/sqlapp)

**Purge**

[x] Purge all

Purge

Once purged - the change in the database is reflected

- reflected immediately - on original site
- and reflected after 1 min - on CDN endpoint, as it was set

## What is Azure Front Door [262]

Azure Front Door Service

A lot more features comparing content delivery

Web App Firewall - managed service

Route traffic based by certain criteria...

<https://learn.microsoft.com/en-us/azure/frontdoor/front-door-overview>

Whether you’re delivering content and files or building global apps and APIs, Azure Front Door can help you deliver higher availability, lower latency, greater scale, and more secure experiences to your users wherever they are.

Azure Front Door is Microsoft’s modern cloud Content Delivery Network (CDN) that provides fast, reliable, and secure access between your users and your applications’ static and dynamic web content across the globe. Azure Front Door delivers your content using Microsoft’s global edge network with hundreds of global and local points of presence (PoPs) distributed around the world close to both your enterprise and consumer end users.

## Lab - Azure Front Door - Setup [263]

```txt
            |- WebApp in Region 1
Front Door <>
            |- WebApp in Region 2
```

## Lab - Azure Front Door - Implementation [264]

Azure Latency Test

<https://www.azurespeed.com/Azure/Latency>

Least latency - direct to the proper site accordingly

## Azure Front Door - Other aspects [265]

Improve performance by compressing files in Azure Front Door

<https://learn.microsoft.com/en-us/azure/frontdoor/standard-premium/how-to-compression>

app-froontdoor

Update route

[x] Enable caching

[x] Enable compression

## Quiz 9: Short Quiz