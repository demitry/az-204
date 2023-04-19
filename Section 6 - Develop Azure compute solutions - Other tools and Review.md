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

## 92. Lab - Azure PowerShell - Create Azure Web App

```powershell
<#
Command Reference

1. New-AzAppServicePlan
https://docs.microsoft.com/en-us/powershell/module/az.websites/new-azappserviceplan?view=azps-7.3.0

2. New-AzWebApp
https://docs.microsoft.com/en-us/powershell/module/az.websites/new-azwebapp?view=azps-7.3.0

#>
Import-Module Az.Resources

$ResourceGroupName="powershell-grp"
$Location="North Europe"
$AppServicePlanName="companyplan"
$WebAppName="companyapp19990"

Connect-AzAccount

New-AzResourceGroup -Name $ResourceGroupName -Location $Location

# We first need to create an App Service Plan

New-AzAppServicePlan -ResourceGroupName $ResourceGroupName `
-Location $Location -Tier "B1" -NumberofWorkers 1 -Name $AppServicePlanName

# Then we can create the Azure Web App

New-AzWebApp -ResourceGroupName $ResourceGroupName -Name $WebAppName `
-Location $Location -AppServicePlan $AppServicePlanName

```

## 93. Lab - Azure PowerShell - Configuration / Integration with GitHub

```powershell

<#
Command Reference

1. Set-AzResource
https://docs.microsoft.com/en-us/powershell/module/az.resources/set-azresource?view=azps-7.3.0

#>

# We are deploying an application from GitHub onto an existing Web App
# Ensure to use your own GitHub repository URL

Connect-AzAccount

$ResourceGroupName="powershell-grp"
$WebAppName="companyapp19990"

$Properties =@{
    repoUrl="https://github.com/demitry/azwebapp";
    branch="master";
    isManualIntegration="true";
}

Set-AzResource -ResourceGroupName $ResourceGroupName `
-Properties $Properties -ResourceType Microsoft.Web/sites/sourcecontrols `
-ResourceName $WebAppName/web -ApiVersion 2015-08-01 -Force

```

## 94. Lab - Azure PowerShell - Deployment Slots

Issue:
PS F:\\git\az-204> . 'F:\\git\az-204\Scripts\DeploymentSlots.ps1'
.: File F:\NEW_JOB_2023\git\az-204\Scripts\DeploymentSlots.ps1 cannot be loaded. The file F:\NEW_JOB_2023\git\az-204\Scripts\DeploymentSlots.ps1 is not digitally signed. You cannot run this script on the 
current system. For more information about running scripts and setting execution policy, see about_Execution_Policies at https://go.microsoft.com/fwlink/?LinkID=135170.

Solution:

<https://windowsreport.com/powershell-not-digitally-signed/>

```powershell
Get-ExecutionPolicy
Set-ExecutionPolicy -ExecutionPolicy unrestricted
Set-ExecutionPolicy -Scope Process -ExecutionPolicy Bypass
Unblock-File -Path C:Script.ps1
```

### Deployment slots
Deployment Slots in Azure are a feature that enables you to deploy multiple copies of your web application to different slots or environments. Each deployment slot is a separate instance of your web application that runs in Azure, but with its own separate URL and configuration settings.

The purpose of using Deployment Slots is to facilitate a smooth and safe deployment process for your web application. You can use the deployment slots to perform tasks such as:

Testing: You can deploy your new version of the web application to a staging slot for testing purposes without affecting the production environment.

Rollout: You can gradually roll out the new version of your web application to a subset of users or regions by deploying it to a deployment slot first before deploying to production.

Swap: You can perform a seamless deployment of your web application by swapping the deployment slot with the production slot once you are satisfied with the new version's performance.

Backout: If the new version of your web application has issues, you can quickly and easily roll back to the previous version by swapping the deployment slot with the production slot.

In summary, Deployment Slots in Azure allow you to deploy, test, and manage your web application in a controlled and secure way, enabling you to minimize downtime and ensure a smooth deployment process.

```powershell

<#
Command Reference

1. Set-AzAppServicePlan
https://docs.microsoft.com/en-us/powershell/module/az.websites/set-azappserviceplan?view=azps-7.3.0

2. New-AzWebAppSlot
https://docs.microsoft.com/en-us/powershell/module/az.websites/new-azwebappslot?view=azps-7.3.0

3. Switch-AzWebAppSlot
https://docs.microsoft.com/en-us/powershell/module/az.websites/switch-azwebappslot?view=azps-7.3.0

#>

# We are using an existing Azure Web App

$ResourceGroupName="powershell-grp"
$WebAppName="companyapp19990"
$AppServicePlanName="companyplan"

# For deployment slots, the App Service Plan needs to be standard or higher

Connect-AzAccount

Set-AzAppServicePlan -Name $AppServicePlanName -ResourceGroupName $ResourceGroupName `
-Tier Standard

# We then create a Web App slot

$SlotName="Staging"
New-AzWebAppSlot -Name $WebAppName -ResourceGroupName $ResourceGroupName `
-Slot $SlotName

# We then deploy an application onto the Staging slot
# Ensure to use your own GitHub URL

$Properties =@{
    repoUrl="https://github.com/demitry/azwebapp";
    branch="master";
    isManualIntegration="true";
}

Set-AzResource -ResourceGroupName $ResourceGroupName `
-Properties $Properties -ResourceType Microsoft.Web/sites/slots/sourcecontrols `
-ResourceName $WebAppName/$SlotName/web -ApiVersion 2015-08-01 -Force

# The following can be used to switch slots

$TargetSlot="production"

Switch-AzWebAppSlot -Name $WebAppName -ResourceGroupName $ResourceGroupName `
-SourceSlotName $SlotName -DestinationSlotName $TargetSlot
```

## 95. Installing Azure CLI

<https://learn.microsoft.com/en-us/cli/azure/install-azure-cli>

az login

## 96. Lab - Azure CLI - Azure Web App - Docker Container

<https://learn.microsoft.com/en-us/cli/azure/webapp?view=azure-cli-latest>

```
# 1. First we can create an App service plan

# --is-linux = linux compute machine,
# windows by default)
az appservice plan create --name companyplan --resource-group app-grp --is-linux

# 2. Then we create the web app

az webapp create --resource-group app-grp --plan companyplan --name sqlappGenfromAz --deployment-container-image-name appregistry3100.azurecr.io/sqlapp:latest

# 3. If you want to turn on container-based logging

az webapp log config --name sqlappGenfromAz --resource-group app-grp --docker-container-logging filesystem

# 4. Enable the log stream

az webapp log tail --name sqlappGenfromAz --resource-group app-grp
```

## 97. Lab - Azure CLI - Azure Kubernetes

Azure Cloud Shell requires storage account

```command
1. Create the resource group

az group create --name kubernetes-grp --location northeurope

2. Then create the cluster

To see all registered resource providers for your subscription, use:

Get-AzResourceProvider -ListAvailable | Where-Object RegistrationState -eq "Registered" | Select-Object ProviderNamespace, RegistrationState | Sort-Object ProviderNamespace | Find-String "OperationsManagement"

Register-AzureRmResourceProvider -ProviderNamespace Microsoft.OperationsManagement

az aks create --resource-group kubernetes-grp --name appcluster --node-count 1 --enable-addons monitoring --generate-ssh-keys

3. If you don't have the kubectl tool installed locally, then install the CLI

az aks install-cli

4. Then download the credentials so that the kubectl tool can use the kubernetes cluster

az aks get-credentials --resource-group kubernetes-grp --name appcluster

# Merged "appcluster" as current context in C:\Users\dmitry\.kube\config

5. To get the nodes in the cluster

kubectl get nodes

# PS C:\Users\dmitry> kubectl get nodes
# NAME                                STATUS   ROLES   AGE     VERSION
# aks-nodepool1-24186844-vmss000000   Ready    agent   5m13s   v1.25.6

6. We can then deploy our application via the kubectl command (upload yml first)

kubectl apply -f deployment.yml
kubectl apply -f service.yml

7. We can delete the resource group

az group delete --name kubernetes-grp
```

## 98. What are ARM templates

Azure Resource Manager template (ARM template)

Allow to define Infrastructure As Code

Submit code to Azure

Azure deploy resources based on this code

1) Define your infrastructure as code
2) Create an Azure Resource Manager template (ARM template)
3) JSON contains yhe definition of infrastructure
4) Submit ARM to Azure, Azure will deploy resources 

<https://learn.microsoft.com/en-us/azure/azure-resource-manager/templates/syntax>

Template format, simplest structure:

```json
{
  "$schema": "https://schema.management.azure.com/schemas/2019-04-01/deploymentTemplate.json#",
  "contentVersion": "",
  "apiProfile": "",
  "parameters": {  },
  "variables": {  },
  "functions": [  ],
  "resources": [  ],
  "outputs": {  }
}
```

## 99. ARM Templates - Setting up Visual Studio Code

## 100. ARM - Lab - Azure Storage Account - Building the template

## 101. ARM - Lab - Azure Storage Account - Deploying the template

## 102. ARM - Lab - Deploying a template via the Azure Portal

## 103. ARM - Lab - Multiple copies of a resource

## 104. ARM Templates - Azure Virtual Machines

## Quiz 5: Short Quiz