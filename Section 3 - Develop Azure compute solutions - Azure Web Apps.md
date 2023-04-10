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
```



## 31. Building an Application that connects to the SQL database

## 32. Publishing to our Azure Web App

## 33. Publishing from GitHub

## 34. Using the Azure Web App connection string

## 35. Using the Azure Web App connection string - Resources

## 36. Azure App Service Logging

## 37. Azure Web Apps - Autoscaling

## 38. Lab - Auto scaling a web app

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