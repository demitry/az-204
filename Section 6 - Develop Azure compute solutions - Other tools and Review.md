# Section 6: Develop Azure compute solutions - Other tools and Review

## 87. Other tools to consider

Dedicated course for each tool

* Azure PowerShell
* Azure CLI
* ARM Templates

## 88. What is PowerShell

PowerShell

* command-line shell
* scripting language
* configuration framework

Linux / Windows / Mac OS

Ability to work with .NET objects

Text input -> cmd -> text output or .NET objects

Cmdlets (commands) - collected in modules (collections of commands)

## 89. Installing PowerShell

https://learn.microsoft.com/en-us/powershell/scripting/install/installing-powershell?view=powershell-7.3

```powershell
$PSVersionTable
$PSVersionTable.PSVersion
```

## 90. Installing Azure PowerShell

Install Az

<https://learn.microsoft.com/en-us/powershell/azure/install-az-ps?view=azps-9.6.0>

```
Set-ExecutionPolicy -ExecutionPolicy RemoteSigned -Scope CurrentUser
Install-Module -Name Az -Scope CurrentUser -Repository PSGallery -Force -AllowClobber
Connect-AzAccount
```

```powershell
PS C:\Users\dmitry> Set-ExecutionPolicy -ExecutionPolicy RemoteSigned -Scope CurrentUser
PS C:\Users\dmitry> Install-Module -Name Az -Scope CurrentUser -Repository PSGallery -Force
Install-Package: The following commands are already available on this
system:'Login-AzAccount,Logout-AzAccount,Resolve-Error,Send-Feedback'. This module 'Az.Accounts' may override the
existing commands. If you still want to install this module 'Az.Accounts', use -AllowClobber parameter.
PS C:\Users\dmitry> Install-Module -Name Az -Scope CurrentUser -Repository PSGallery -Force -AllowClobber

PS C:\Users\dmitry> Connect-AzAccount
WARNING: Both Az and AzureRM modules were detected on this machine. Az and AzureRM modules cannot be imported in the same session or used in the same script or runbook. If you are running PowerShell in an environment you control you can use the 'Uninstall-AzureRm' cmdlet to remove all AzureRm modules from your machine. If you are running in Azure Automation, take care that none of your runbooks import both Az and AzureRM modules. More information can be found here: https://aka.ms/azps-migration-guide

Account              SubscriptionName     TenantId                             Environment
-------              ----------------     --------                             -----------
dpoluektov@gmail.com Azure subscription 1 87349d34-316a-481c-ab12-5f5c7af3cd99 AzureCloud
```

## 91. Azure PowerShell - Using Visual Studio Code

VSCode + PowerShell + Azure PowerShell

## 92. Lab - Azure PowerShell - Azure Web App

## 93. Lab - Azure PowerShell - Configuration with GitHub

## 94. Lab - Azure PowerShell - Deployment Slots

## 95. Installing Azure CLI

## 96. Lab - Azure CLI - Azure Web App - Docker Container

## 97. Lab - Azure CLI - Azure Kubernetes

## 98. What are ARM templates

## 99. ARM Templates - Setting up Visual Studio Code

## 100. ARM - Lab - Azure Storage Account - Building the template

## 101. ARM - Lab - Azure Storage Account - Deploying the template

## 102. ARM - Lab - Deploying a template via the Azure Portal

## 103. ARM - Lab - Multiple copies of a resource

## 104. ARM Templates - Azure Virtual Machines

## Quiz 5: Short Quiz