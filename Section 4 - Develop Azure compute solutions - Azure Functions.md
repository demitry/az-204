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

## 54. Lab - Azure Functions - Azure SQL database - GET Products

## 55. Publishing the Function to Azure

## 56. Lab - Azure Functions - Azure SQL database - GET Product by id

## 57. Lab - Azure Functions - Azure SQL database - POST Adding a method

## 58. Using the POSTMAN Tool

## 59. Using Connection Strings

## 60. Calling an Azure Function from a web app

## 61. There is more we need to cover

## Quiz 3: Short Quiz