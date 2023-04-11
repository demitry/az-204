# Section 3: Develop Azure compute solutions - Azure Web Apps

## 25. What are we going to cover

## 26. Introduction onto Azure Web Apps

## 27. Lab - Azure Web App

Create Resource -> Web App

Unique app name - webapp4400.azurewebsites.net

Publish

* Code
* Docker Container
* Static Web App

Choose Code

Runtime: .NET6 (LTS) (a lot of runtimes)

Pricing plans.

App Service plan pricing tier determines the location, features, cost and compute resources associated with your app.

SKU and size (for not FREE)

For free = limit 60 minutes compute per day

B1 (Basic)

Monitoring : No (application insights)

It is possible to Download template for automation

2 resources created: Web App and App Service Plan

App Service Plan - dictate what features are available for the application service + costs associated with them

<https://webapp4400.azurewebsites.net/>

Default page

## 28. Lab - Publishing from Visual Studio

Deploy, Publish but to the Web App (it is simple) 

## 29. Lab - Azure SQL Database

appdb

sqlserver1000.database.windows.net

* Use only Azure Active Directory (Azure AD) authentication
* Use both SQL and Azure AD authentication
* Use SQL authentication

Use SQL authentication

sqladmin

DTU = Database Transaction Units

DTU-based purchasing model

Choose Basic

ESTIMATED COST / MONTH
4.90 USD

Networking

Connectivity method

* No access
* Public endpoint
* Private endpoint

Choose Connectivity method: Public endpoint

Allow Azure services and resources to access this server: Yes

Add current client IP address: Yes

## 30. Populating our database with data

SSMS - login - sqlserver1000.database.windows.net - sqladmin

```sql
use appdb;

CREATE TABLE Products
(
 ProductId int,
 ProductName varchar(1000),
 Quantity int
)

INSERT INTO Products(ProductId, ProductName, Quantity) VALUES (1, 'Mobile', 100)
INSERT INTO Products(ProductId, ProductName, Quantity) VALUES (2, 'Laptop', 200)
INSERT INTO Products(ProductId, ProductName, Quantity) VALUES (3, 'Tabs', 300)

SELECT * FROM Products

SELECT ProductId, ProductName, Quantity FROM Products 
```

## 31. Building an Application that connects to the SQL database

## 32. Publishing to our Azure Web App

## 33. Publishing from GitHub

VS -> Git -> Create repository

Create Web App -> Deployment -> Deployment settings - Enable

GitHub Actions (Could be set up later)

Web App -> Deployment Center -> Source -> Select Source Code,

Select Organization, Repository, Branch, Build Runtime (.NET 6)

 Deployment Center -> Logs -> Success

 On each github commit DeploymentCenter will initiate re-deploy.

Settings -> Configurations -> General Settings -> .NET 6

(it doesn't understand)

## 34. Using the Azure Web App connection string

Configuration -> Connection Strings -> Add/Edit connection string

Name: SQLConnection

Value : 

```
Server=tcp:sqlserver1000.database.windows.net,1433;Initial Catalog=appdb;Persist Security Info=False;User ID=sqladmin;Password=MySuperPuperPassword;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;
```

Type: Sql Azure
At runtime, connection strings are available as environment variables. Learn more

## 35. Using the Azure Web App connection string - Resources

You can use the following as a reference for the connecting string

```json
{
  "ConnectionStrings": {
    "SQLConnection": "Server=tcp:appserver6000.database.windows.net,1433;Initial Catalog=appdb;Persist Security Info=False;User ID=sqlusr;Password=Azure@123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
  } 
}
```

ProductService -> Extract interface

Remove hardcoded Connection string, get it from IConfiguration (saved in Azure)

## 36. Azure App Service Logging

Monitoring -> App Service Logs

```
Application logging (Filesystem)
Application logging (Blob)
Storage Containers
Retention Period (Days)
Web server logging
Off
Storage: File System
Quota (MB): 35
Retention Period (Days)
Detailed error messages
Failed request tracing
Download logs
FTP/deployment username: No FTP/deployment user set
FTP: ftp://waws-prod-db3-273.ftp.azurewebsites.windows.net/site/wwwroot
FTPS: ftps://waws-prod-db3-273.ftp.azurewebsites.windows.net/site/wwwroot

```

Monitoring -> Log Stream

* Application Logs

* Web Server Logs

<details>
<summary>Raw Log (actual raw HTTP requests)</summary>

```
Connecting...
2023-04-11T16:34:35  Welcome, you are now connected to log-streaming service. The default timeout is 2 hours. Change the timeout with the App Setting SCM_LOGSTREAM_TIMEOUT (in seconds).
2023-04-11T16:35:35  No new trace in the past 1 min(s).
#Software: Microsoft Internet Information Services 8.0#Fields: date time s-sitename cs-method cs-uri-stem cs-uri-query s-port cs-username c-ip cs(User-Agent) cs(Cookie) cs(Referer) cs-host sc-status sc-substatus sc-win32-status sc-bytes cs-bytes time-taken
2023-04-11 16:35:13 WEBAPP4400 GET / X-ARR-LOG-ID=d34fffa1-e963-4000-a215-935f465482f2 443 - ___IP___ Mozilla/5.0+(Windows+NT+10.0;+Win64;+x64)+AppleWebKit/537.36+(KHTML,+like+Gecko)+Chrome/112.0.0.0+Safari/537.36 ARRAffinity=e922f965bb5fb02c95e6fbd6d05e06119d940387edc2373906c12f13efd97606;+ARRAffinitySameSite=e922f965bb5fb02c95e6fbd6d05e06119d940387edc2373906c12f13efd97606 - webapp4400.azurewebsites.net 200 0 0 1782 1609 5955
2023-04-11 16:35:13 ~1WEBAPP4400 GET /api/logstream/ X-ARR-LOG-ID=381b0b83-83fb-4882-b84f-6f49cfbd016b 443 - ___IP___ Mozilla/5.0+(Windows+NT+10.0;+Win64;+x64)+AppleWebKit/537.36+(KHTML,+like+Gecko)+Chrome/112.0.0.0+Safari/537.36 - - webapp4400.scm.azurewebsites.net 200 0 64 672 1514 66408

```

Interesting, The trace listener AzureBlobTraceListener is disabled,

Is it auto-disabled after 5 min?

```
2023-04-11T16:39:14  No new trace in the past 1 min(s).
2023-04-11T16:40:14  No new trace in the past 2 min(s).
2023-04-11T16:41:14  No new trace in the past 3 min(s).
2023-04-11T16:42:14  No new trace in the past 4 min(s).
2023-04-11T16:43:14  No new trace in the past 5 min(s).
2023-04-11T16:44:09System.ApplicationException: The trace listener AzureBlobTraceListener is disabled. ---> System.InvalidOperationException: The SAS URL for the cloud storage account is not specified. Use the environment variable 'DIAGNOSTICS_AZUREBLOBCONTAINERSASURL' to define it.at Microsoft.WindowsAzure.WebSites.Diagnostics.AzureBlobTraceListener.RefreshConfig()--- End of inner exception stack trace ---
2023-04-11T16:45:14  No new trace in the past 1 min(s).
2023-04-11T16:46:14  No new trace in the past 2 min(s).
```

</details>

## 37. Azure Web Apps - Autoscaling

```
auto scaling feature, part of your Web apps.
It's actually part of the app's plan.
a number of users are actually going ahead and accessing your Web application.
-> the load on the application is increasing on that underlying compute infrastructure.
bottleneck?

```

* BASIC service plan = scale up to 3 VMs manualy!!!

* STANDARD service plan or higher = scaling automation, based on load (cpu etc.)

## 38. Lab - Auto scaling a web app

See Metrics: App Service plan

* CPU Percentage
* Memory Percentage
* Data In/DataOut 

Scale automatically based on metrics

webapp4400 | Scale up (App Service plan)

Update service plan Change from B1 to S1 ( can auto-scale up to 10 instances)

=>

webapp4400 | Scale out (App Service plan)

* Manual scale - Maintain a fixed instance count
 
* Custom autoscale - Scale on any schedule, based on any metrics

Scale mode

* Scale based on a metric
* Scale to a specific instance count

### Scale based on a metric
    *  Add a rule 
    * ->  Scale is based on metric trigger rules but no rule(s) is defined; click Add a rule to create a rule. For example: 'Add a rule that increases instance count by 1 when CPU Percentage is above 70%'. If no rules is defined, the resource will be set to default instance count.

Cool down (minutes)

The amount of time to wait after a scale operation before scaling again. For example, if cooldown is 10 minutes and a scale operation just occurred, Autoscale will not attempt to scale again until after 10 minutes. This is to allow the metrics to stabilize first.

Instance limits: Min 1, Max 3, Default 1

Issue (Save rule error) - MissingSubscriptionRegistration

```json
There was an error saving setting for resource 'ASP-appgrp-a27b'. Detail message '{"error":{"code":"MissingSubscriptionRegistration","message":"The subscription is not registered to use namespace 'microsoft.insights'. See https://aka.ms/rps-not-found for how to register subscriptions.","details":[{"code":"MissingSubscriptionRegistration","target":"microsoft.insights","message":"The subscription is not registered to use namespace 'microsoft.insights'. See https://aka.ms/rps-not-found for how to register subscriptions."}]}}', Please try again in a few moments.
```

Solution

This article describes resource provider registration errors that occur when you use a resource provider that you haven't already used in your Azure subscription. The errors are displayed when you deploy resources with a Bicep file or Azure Resource Manager template (ARM template). If Azure doesn't automatically register a resource provider, you can do a manual registration.

### Troubleshoot common Azure deployment errors

<https://learn.microsoft.com/en-us/azure/azure-resource-manager/troubleshooting/common-deployment-errors#noregisteredproviderfound>

### Resolve errors for resource provider registration

<https://learn.microsoft.com/en-us/azure/azure-resource-manager/troubleshooting/error-register-resource-provider?tabs=azure-cli#code-try-3>

### My Solution: register microsoft.insights
doskey /history
```
az provider list --output table
az login
az provider list --output table
az provider list --query "[?namespace=='microsoft.insights']" --output table
az provider register --namespace microsoft.insights
az provider show -n microsoft.insights
az provider list --query "[?namespace=='microsoft.insights']" --output table
```

### Help 


Use az provider list to display the registration status for your subscription's resource providers. The examples use the --output table parameter to filter the output for readability. You can omit the parameter to see all properties.

The following command lists all the subscription's resource providers and whether they're Registered or NotRegistered.

```bash
az provider list --output table
```

You can filter the output by registration state. Replace the query value with Registered or NotRegistered.

```bash
az provider list --query "[?registrationState=='Registered']" --output table
```

Get the registration status for a specific resource provider:

```bash
az provider list --query "[?namespace=='Microsoft.Compute']" --output table
```

To register a resource provider, use the az provider register command, and specify the namespace to register.

```bash
az provider register --namespace Microsoft.Cdn
```

To get a resource type's supported locations, use az provider show:

```bash
az provider show --namespace Microsoft.Web --query "resourceTypes[?resourceType=='sites'].locations"
```

Get a resource type's supported API versions:

```bash
az provider show --namespace Microsoft.Web --query "resourceTypes[?resourceType=='sites'].apiVersions"
```


## 39. Azure Web Apps - Custom domains

## 40. Azure Web Apps - SSL

## 41. Deployment Slots

## 42. Lab - Deployment Slots

## 43. Deployment slots with databases

## 44. Lab - Deployment slots with databases

## 45. Azure App Configuration

## 46. Lab - Azure App Configuration - Configuration Settings

## 47. Lab - Azure App Configuration - Feature Flags

## 48. Note on Controller actions

Quiz 2: Short Quiz




Wow

Deploy Mode: Self-Contained and Framework-Dependent 

