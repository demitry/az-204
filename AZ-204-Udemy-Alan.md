# AZ-204: Developing Solutions for Microsoft Azure - NEW (Udemy, Alan Rodrigues)

## Section 2: Develop Azure compute solutions - Azure Virtual Machines

### 13. Building a simple project locally

VS -> Run as administrator, (why?) .NET Core Sample App

### 15. Lab - Building a Windows virtual machine

Create resource -> VM

Subscription (my free 200)

Resource group - logical grouping of resources

<https://portal.azure.com/#view/HubsExtension/BrowseAll>

All resources

### 16. Connecting to the Virtual Machine

Download RDP file and login

### 17. Lab - Installing Internet Information Services

Install IIS = Host our app

Start -> Server Manager (dashboard)

Dashboard -> Add roles and features Wizard

Web server (IIS), Next, Finish

Tools -> IIS Manager

Resources -> public IP 13.81.85.54

This site can’t be reached 13.81.85.54 took too long to respond.

Web server by default listens on port 80

Network Security Group

Create rule to allow traffic on port 80

Networking -> Inbound port rules

RDP port 3389

Networking -> Add inbound port rule

Service - HTTP

Name - AllowAnyHTTPInbound_Port_80

AZ 104 Administration

<http://13.81.85.54/> - OK IIS page

### 18. Lab - Deploying a .NET Core app on Windows Server

VS -> Tools -> Options -> Azure Account -> OK

prj -> right click -> publish -> Azure -> Azure Virtual Machine -> Select group and VM

Publish page -> Show All Settings -> Connection ->

Enter Password, Validate Connection, Accept Security Certificate

Save

Publish

Enter password for VM

...

Publish Succeeded.

Web App was published successfully <http://appvm100.westeurope.cloudapp.azure.com/>


#### Step 1: Assign a DNS name to the VM

appvm -> Overview -> DNS Name: (appvm100) appvm100.westeurope.cloudapp.azure.com

Save -> OK, available from browser appvm100.westeurope.cloudapp.azure.com

#### Step 2: Add a rule for the port 8172 to the Network Security Group (open WebDeploy port (8172) on Azure)

Networking -> Add inbound port rule, 8172, AllowAnyCustom_Port_8172_Inbound

#### Step 3: Add the role of the Management Service on the VM

VM -> Dashboard -> Add roles and features

Web Server -> Management Tools -> Managements Service -> Next and Finish Install

#### Step 4: Check the configuration of the management service in IIS

VMs IIS -> appvm -> Managements Service -> Check "Enable remote Connections"

Note that port is 8172

"Apply", "Start" service

#### Step 5: Install the .NET Core Hosting Bundle. This allows .NET apps to be hosted on IIS

App is built under .NET 6.0.0 - the same should be on the VM

Dashboard -> Local Server -> IE Enhanced Security Configuration (is ON)

Disable to allow .NET install: Off, Off

<https://dotnet.microsoft.com/en-us/download>

<https://dotnet.microsoft.com/en-us/download/dotnet/6.0>

ASP.NET Core Runtime 6.0.15 (major is 6.0) it is OK

(dotnet-hosting-6.0.15-win.exe)

Download hosting bundle and install => Runtime is available on the hosting machine

Common issue - mismatch between the versions

Download and install Web Deploy v3.6 -> "Complete" install

#### Step 6: Install the Web Deploy v3.6 tool

### 19. Lab - Building a Linux VM

### 20. Deploying our .NET App on the Linux VM

### 21. Using NGINX on the Linux VM

### 22. Keeping a check on the cost of your resources

### 23. Quick Note
