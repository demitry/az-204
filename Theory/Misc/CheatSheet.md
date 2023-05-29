```
The best approach to working with Microsoft Azure can be summarized in three words: “always be learning.” The Azure product development teams release new features every workday, so if you aren’t actively working to stay current, you’ll fall behind, and your career will suffer.
This Cheat Sheet offers some essential ingredients in Azure automation. Remember that the Azure portal is all well and good until you’re tasked with deploying 50 virtual machines!

Core ingredients of cloud computing
If you ask 100 people what cloud computing is and you’ll likely get 100 different answers. And for good reason! While the big vendors all tout specific features that make their cloud solution shine, the truth is that everyone is trying to sell you the same four features: compute capacity, storage, network, and analytics. Let’s dive into those key ingredients:

Compute capacity: Compute is raw computing power — the central processing unit (CPU) and random-access memory (RAM) that form the platform for applications and data.

Storage: Persistent storage means you have a place on a cloud server to store your files and other data. When you save a file to a cloud-hosted storage account, it should remain in place forever, or at least until you move or delete it.

Network: Cloud platforms such as Azure provide a software-defined network infrastructure on which you can host your virtual machines and other Azure services. Because the cloud almost always involves an Internet connection, online and cloud are essentially synonymous.

Analytics: You’ll never get to touch the cloud providers’ computing, storage, or network resources. The closest you’ll get to viewing anything about the cloud environment is the vendor’s telemetry data in your web browser or a management app.

With Azure and other public cloud providers, you are given tools to see how much of their services you consume each minute. Cloud analytics also gives you valuable troubleshooting and performance-tuning advice for your cloud infrastructure.

The difference between cloud deployment and delivery models
You’ve finally been convinced to part ways with the data center. Congratulations! Now what? Your mission is to pick the most secure yet affordable approach to deployment and delivery. But what’s the difference? Even the IT folks in the room get a bit confused. Let’s break it down here.

Deployment explores how you provision resources in the cloud. In contrast, service delivery defines the application creation and management approaches for those provisioned resources.

The three deployment models are public, private, and hybrid:

Public cloud deployment: Resources in Azure are generally considered public because the services, storage, and network capacity are shared among many parties and delivered over the Internet.The infrastructure (hardware, software) and costs incurred to manage resources are shared among many customers, not just one or two. The advantages touted by vendors such as Microsoft include lower costs, no infrastructure maintenance, near-unlimited scalability, and high reliability.
Private cloud deployment: Private clouds are maintained in a data center or hosted by a third-party service provider. The difference is that all infrastructure resources are maintained on a private network, which means that the hardware and software are dedicated to your organization.
Hybrid cloud deployment: If you are looking for the best of both worlds, then hybrid is your preferred choice. Suppose you still have resources that must remain on-premises (private cloud), and desire resources to be shared and publicly accessible (public cloud). In that case, you’ll want to implement a hybrid deployment.The benefit of hybrid is simple: it allows you and your organization to share data and apps between the two environments.
Within these deployment models, organizations may use commercial off-the-shelf software (COTS), custom applications, data solutions, and fully working virtualized environments.

Depending on the business need, the service delivery model varies. Let’s recap the three main service delivery models:

Software as a Service (SaaS): Web-based software such as Microsoft 365, Microsoft Power Platform (Power Apps and Power BI), and Microsoft Dynamics all fall into the category of SaaS. These are applications that require no development by the organization.
Sure, there are always configurations, but you and your team are not responsible for the code or infrastructure. The responsibility falls 100 percent on the vendor.

Infrastructure as a Service (IaaS): Instead of running applications in that big data center server cluster, you can shift your workloads to the cloud. How so? You can create contained server environments using virtual machines to complete specific activities that were formerly completed in-house.
The big difference is that you are responsible for configuring the environment and managing the applications running in that environment. Those activities include data protection, security, and performance tuning.

Vendors such as Microsoft are responsible for ensuring the servers (infrastructure) that you used to make sure work 24/7 in-house are always on and available for users to consume the environments.

Platform as a Service (PaaS): Perhaps you have a three-tier application leveraging a specific operating system and database. Previously this would have been hosted in the data center, likely using a virtual machine.
But is the virtual machine the best option to migrate from the data center to the cloud? Highly unlikely! It’s possible to build the application in the cloud, assuming pre-configured operating systems and database solutions are available that can be containerized.

The custom application code found as part of an app service points to the shared platform resources, which has numerous benefits related to maintainability. You are not responsible for operating system and database maintenance, including configuration, security, and performance tuning.

The application can scale as desired without you having to intervene. There is only one thing you do in a PaaS deployment: create custom, innovative code that connects to these hosted resources.

Essential Azure PowerShell Commands
Not every one of the following PowerShell commands is an Azure command. PowerShell is a universal task automation language, however, so once you get the hang of its basic syntax and use, you’ll be productive in Azure, Amazon Web Services (AWS), and beyond.

On Windows 10, you can install the Azure PowerShell modules by running the following command from an administrative command prompt or PowerShell session:

Install-Module -Name Az

Following are some general commands you may commonly use when working with Azure. Of course, you can use the following three commands in any context, Azure- or non-Azure-related:

Get-Command: Discover useful PowerShell commands.
Get-Command -Module Az.Compute -Verb Get -Noun *disk*

Get-Help: Read syntax help and view example use.
Get-Help -Name New-AzVM -Examples

Connect-AzAccount: Authenticate to Azure.
$credential = Get-Credential

Connect-AzAccount -Credential $credential

Set-AzContext: Set your active subscription context.
Set-AzContext -SubscriptionName 'Corporate Subscription'

New-AzResourceGroupDeployment: Deploy an ARM template and, optionally, a parameter file.
New-AzResourceGroupDeployment -ResourceGroupName 'Engineering'

-TemplateFile 'D:\templates\env-deploy.json'

-TemplateParameterFile 'D:\templates\

env-deploy-params.json'

Essential Azure CLI Commands
Most beginners prefer the Azure Command-Line Interface (CLI) interface to Azure PowerShell because the CLI is so newcomer-friendly, especially when run in interactive mode.

The Azure CLI runs on Windows, macOS, and Linux; get installation details from the Azure documentation.

az interactive: Starts the Azure CLI interactive command shell.
az login: Authenticate to your Azure AD tenant and subscriptions.
az login --tenant corp1.onmicrosoft.com

az account: Set your active subscription context.
az account set --subscription 'Corporate Subscription'

az configure: Specify your default output type (among other options).
az configure --defaults group=myRG web=myweb vm=myvm

az group deployment create: Deploy an Azure Resource Manager (ARM) template.
az group deployment create --resource-group 'Engineering'

--template-file 'D:\templates\env-deploy.json'

--parameters '{"location": {"value": "eastus2"}}'

ARM Template Elements
Every ARM template contains at least some of the following JavaScript Object Notation (JSON) elements. Here’s a good roll-up of them, along with brief descriptions:

$schema: Required; the JSON schema file against which your template is validated
contentVersion: Required; for your team’s use (Azure simply requires some value.)
apiProfile: Optional; API version collection for particular resource types
parameters: Optional; values passed in to the deployment at run time
variables: Optional; JSON fragments that simplify template language expressions (generating unique resource names, for example)
functions: Optional; user-defined functions that are made available within the template
resources: Required; the resources that Azure will deploy in to a resource group or subscription
outputs: Optional; values returned postdeployment
Well-Known Azure Domains
Until you stand up a site-to-site virtual private network or an ExpressRoute circuit between your local network and Azure, you’ll probably have to create some firewall rules to allow traffic from well-known Azure services.

Following, is a nonexhaustive list of Azure service URLs and a brief description of the service(s) each hosts:

azure.com: The public Azure website
azureedge.net: Azure Content Delivery Network
azurewebsites.net: Azure App Service
cloudapp.net: Azure Virtual Machines (among other services)
core.windows.net: Azure storage
database.windows.net: Azure SQL Database product family
documents.azure.com: Azure Cosmos DB
graph.windows.net: Microsoft Graph API used in Azure AD
logic.azure.com: Azure Logic Apps
login.microsoftonline.com: Azure authentication endpoint
onmicrosoft.com: Azure AD
trafficmanager.net: Azure Traffic Manager
vault.azure.net: Azure Key Vault
windowsazure.com: The legacy (original) Azure domain, still seen from time to time (Azure MFA, Azure Account Center)

```
https://www.dummies.com/article/technology/information-technology/networking/cloud-computing/microsoft-azure-for-dummies-cheat-sheet-268984/

https://www.techrepublic.com/article/microsoft-azure-the-smart-persons-guide/