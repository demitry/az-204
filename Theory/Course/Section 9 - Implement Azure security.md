<!-- TOC -->

- [Section 9 - Implement Azure security](#section-9---implement-azure-security)
    - [Section Resources download [175]](#section-resources-download-175)
    - [What are we going to cover [176]](#what-are-we-going-to-cover-176)
    - [What is Azure Active Directory [177]](#what-is-azure-active-directory-177)
    - [Lab - Creating a user in Azure AD [178]](#lab---creating-a-user-in-azure-ad-178)
    - [So what is Role-based access control [179]](#so-what-is-role-based-access-control-179)
    - [Lab - Role-based access control [180]](#lab---role-based-access-control-180)
    - [Introduction to Application Objects [181]](#introduction-to-application-objects-181)
    - [Lab - Application Object - Blob objects [182]](#lab---application-object---blob-objects-182)
    - [What is Microsoft Graph [183]](#what-is-microsoft-graph-183)
    - [Lab - Getting user and group information - Application Configuration [184]](#lab---getting-user-and-group-information---application-configuration-184)
        - [Register an Application in Azure AD](#register-an-application-in-azure-ad)
        - [Provide permissions](#provide-permissions)
        - [Provide admin consent](#provide-admin-consent)
    - [Lab - Getting user and group information - Implementation [185]](#lab---getting-user-and-group-information---implementation-185)
    - [Lab - Graph API - Update user [186]](#lab---graph-api---update-user-186)
    - [Azure Key Vault [187]](#azure-key-vault-187)
    - [Lab - Azure Key Vault [188]](#lab---azure-key-vault-188)
    - [Lab - Azure Key Vault - Encryption keys [189]](#lab---azure-key-vault---encryption-keys-189)
    - [Lab - Azure Key Vault - Secrets [190]](#lab---azure-key-vault---secrets-190)
    - [Managed Identities [191]](#managed-identities-191)
    - [Lab - Managed identities [192]](#lab---managed-identities-192)
        - [Configure Managed identity for VM](#configure-managed-identity-for-vm)
        - [DefaultAzureCredential Class](#defaultazurecredential-class)
        - [Setup RDP, map C drive](#setup-rdp-map-c-drive)
    - [Lab - Managed Identity - Getting the access token [193]](#lab---managed-identity---getting-the-access-token-193)
    - [Lab - Managed Identity - Using the access token [194]](#lab---managed-identity---using-the-access-token-194)
    - [Lab - Azure Web App - Managed Identity [195]](#lab---azure-web-app---managed-identity-195)
    - [Note on user assigned identities [196]](#note-on-user-assigned-identities-196)
    - [Lab - User Assigned Identity [197]](#lab---user-assigned-identity-197)
    - [Lab - User Assigned Identity - PowerShell [198]](#lab---user-assigned-identity---powershell-198)
    - [Lab - PowerShell - Managed Identity [199]](#lab---powershell---managed-identity-199)
    - [Lab - PowerShell - Storage Account - Key Vault [200]](#lab---powershell---storage-account---key-vault-200)

<!-- /TOC -->
# Section 9 - Implement Azure security
## Section Resources download [175]
## What are we going to cover [176]

## What is Azure Active Directory [177]

AD Identity Provider - once you authenticated - you authorize to use multiple apps hosted on company env

- What is it - cloud-based identity and access management
- Usage - as identity provider for Azure, Microsoft 365 and othe SaaS products
- Identities - manage identities (users, groups and applications)
- Features - security aspects

Tiers

- Free - User groups and Management
- Premium P1 - Dynamic groups, hybrid identities, self-service password reset for on-premise users
- Premium P2 - Azure AD identity protection abd Privileged Identity Management  

## Lab - Creating a user in Azure AD [178]

Azure Active Directory -> New user
UserA@dpoluektovgmail.onmicrosoft.com
Login, change password
Wapa298356 -> LZ1!
usera@dpoluektovgmail.onmicrosoft.com
All resources - No resources (no permissions granted for UserA)

## So what is Role-based access control [179]

Resource is part of the resource group
Resource group is part of Subscription

- Subscription
    - Resource group
        - Resource

Role-based access control RBAC

## Lab - Role-based access control [180]

<https://learn.microsoft.com/en-us/azure/role-based-access-control/built-in-roles>

Built-in roles
Create custom roles

Storage account based access control (Storage Account Contributor)

Allowed permissions (script):
Type/Access
Microsoft.Storage/storageAccounts/read - Returns the list of storage accounts or gets the properties for the specified storage account.

```json
{
  "assignableScopes": [
    "/"
  ],
  "description": "Lets you manage classic storage accounts, but not access to them.",
  "id": "/subscriptions/{subscriptionId}/providers/Microsoft.Authorization/roleDefinitions/86e8f5dc-a6e9-4c67-9d15-de283e8eac25",
  "name": "86e8f5dc-a6e9-4c67-9d15-de283e8eac25",
  "permissions": [
    {
      "actions": [
        "Microsoft.Authorization/*/read",
        "Microsoft.ClassicStorage/storageAccounts/*",
        "Microsoft.Insights/alertRules/*",
        "Microsoft.ResourceHealth/availabilityStatuses/read",
        "Microsoft.Resources/deployments/*",
        "Microsoft.Resources/subscriptions/resourceGroups/read",
        "Microsoft.Support/*"
      ],
      "notActions": [],
      "dataActions": [],
      "notDataActions": []
    }
  ],
  "roleName": "Classic Storage Account Contributor",
  "roleType": "BuiltInRole",
  "type": "Microsoft.Authorization/roleDefinitions"
}
```

stacc505050 | Access Control (IAM)

Add role assignment

Role -> select Reader role
select User: Members - select user - Next
Review and assign

Role assignments to see assignments

1 min to take effect

UserA now can access storage account

- Can apply on 1 resource
- Can apply on resource group (all resources in group)
- Can apply on the level of Subscription

## Introduction to Application Objects [181]

1 Way: App - authorize - Azure Storage Account

2 Way:
- Create separate Application Object in Azure Active Directory
- Application Object can given access via RBAC on storage account
- Set different permissions on different objects
- Can reuse Application Objects
- Application Objects - part of Microsoft Identity Platform

## Lab - Application Object - Blob objects [182]

Operations: list blobs, read, write - we authorized with access keys.

BUT

we will define app obj in azure AD

Access key:
K0l...iv8A==

storage connection string:
DefaultEndpointsProtocol=https;AccountName=stacc505050;AccountKey=...;EndpointSuffix=core.windows.net

The problem with Access Keys - could be compromised
Account Key have all sort of permissions

Create app object

- Azure AD
- App registrations
- New registration
- Register an application
- BlobApp
- Redirect URI (optional)
- Register

Associate object with dotnet application

stacc505050 | Access Control (IAM)
Role assignments
Add role assignment
Reader
Next
Select Members
**Search BlobApp**
Select
Review and Assign

stacc505050 | Access Control (IAM)
Add role assignment
Storage Blob Data Reader
Select Members
**Search BlobApp**
Select
Review and Assign

Account Key have all sort of permissions
but here we have granular permissions

no need container name and connection string

BlobApp
Application (client) ID
45c63e12-a365-4dea-bb53-79e516131d8a

Directory (tenant) ID
87349d34-316a-481c-ab12-5f5c7af3cd99

BlobApp

Certificates and Secrets
New client secret
Expies

COPY SECRET VALUE yo the secret place

```cs
using Azure.Identity;
using Azure.Storage.Blobs;

string tenantId = "87349d34-316a-481c-ab12-5f5c7af3cd99";
string clientId = "45c63e12-a365-4dea-bb53-79e516131d8a";
string clientSecret = "";

string blobURI = "https://stacc505050.blob.core.windows.net/mycontainer/myfile.txt";

string filePath = "F:\\aztmp\\myfile.txt";

ClientSecretCredential clientCredential = new ClientSecretCredential(tenantId, clientId, clientSecret);

BlobClient blobClient = new BlobClient(new Uri(blobURI),clientCredential);

await blobClient.DownloadToAsync(filePath);

Console.WriteLine("The blob is downloaded");

```

## What is Microsoft Graph [183]

https://graph.microsoft.com

https://learn.microsoft.com/en-us/graph/overview

Get info about users, groups etc.

The workflow is important

for OAuth

**you have to authorize** to access this api

## Lab - Getting user and group information - Application Configuration [184]

I want info about AD Users

API call to MS Graph API

Step 1 : Authorize

Access Token like a key

### Register an Application in Azure AD

=> Define application object to use in Postman to get this access token.

App registrations

New

Postman

### Provide permissions

Allow postman to read info into Azure directory

Postman | API permissions

Microsoft Graph (1)
User.Read
Delegated
Sign in and read user profile
**Remove it**

Two types of permissions

- Application
- Delegated

Add permission
Microsoft Graph
https://graph.microsoft.com/

What type of permissions does your application require?

- Delegated permissions
Your application needs to access the API as the signed-in user.
- Application permissions
Your application runs as a background service or daemon without a signed-in user.

Application permissions

User.Read.All

### Provide admin consent

Not granted for Default directory

Press "Grant admin consent for Default Directory"

## Lab - Getting user and group information - Implementation [185]

Application permissions = Runs on behalf of the application

```
APP ----------------- Call the MS auth service -------------------------> AD 

APP <----------------- Get the access token ----------------------------- AD 

APP ----------------- Access a resource using the access token ---------> AD 

```

App registrations:

Application (client) ID:  2618a067-95e9-4460-bd00-d616f50baafc
Object ID:                f8d1d5dc-49b5-4d0e-aa48-3854f7fe9ae5
Directory (tenant) ID :   87349d34-316a-481c-ab12-5f5c7af3cd99

Postman Overview - Endpoints

OAuth 2.0 token endpoint (v2)

POST

```
https://login.microsoftonline.com/87349d34-316a-481c-ab12-5f5c7af3cd99/oauth2/v2.0/token
```
note, 87349d34-316a-481c-ab12-5f5c7af3cd99 - is a directory tenant id

Body

x-www-form-urlencoded

key values

grant_type    client_credentials (part of OAuth)
client_id     2618a067-95e9-4460-bd00-d616f50baafc (Application (client) ID: )
client_secret Postman | Certificates & secrets -> New, Copy Value
scope         https://graph.microsoft.com/.default

Send to get the access token, get:

```json
{
    "token_type": "Bearer",
    "expires_in": 3599,
    "ext_expires_in": 3599,
    "access_token": "eyJ0e...H9YlA"
}
```

GET https://graph.microsoft.com/v1.0/users

Headers

Authorization - Bearer ourToken

```json
{
    "@odata.context": "https://graph.microsoft.com/v1.0/$metadata#users",
    "value": [
        {
          ...
        },
        {
          ...
        },
        {
            "businessPhones": [],
            "displayName": "UserA",
            "givenName": null,
            "jobTitle": null,
            "mail": null,
            "mobilePhone": null,
            "officeLocation": null,
            "preferredLanguage": null,
            "surname": null,
            "userPrincipalName": "UserA@dpoluektovgmail.onmicrosoft.com",
            "id": "f7cfd9f3-7ea0-450d-b65f-4f3715670516"
        }
    ]
}
```

Access token - have no required permissions,

Permissions should be granted for app object

If you add extra permissions, old token will not help,

The token should be regenerated, based on app object and permissions.

## Lab - Graph API - Update user [186]

Postman - **Add App permission**: User.ReadWrite.All Read and write all users' full profiles

Grant admin consent ...

=> **REGENERATE TOKEN**

User Id 

"id": "f7cfd9f3-7ea0-450d-b65f-4f3715670516"

**PATCH** https://graph.microsoft.com/v1.0/users/f7cfd9f3-7ea0-450d-b65f-4f3715670516

```json
{
    "error": {
        "code": "InvalidAuthenticationToken",
        "message": "Access token is empty.",
        "innerError": {
            "date": "2023-04-27T15:31:47",
            "request-id": "e29f462a-4e5a-4dd1-9593-f163d9ca4fa2",
            "client-request-id": "e29f462a-4e5a-4dd1-9593-f163d9ca4fa2"
        }
    }
}
```

Headers

Authorization Bearer **newtoken**

Body - Raw, Text - JSON

```json
{
    "givenName":"John Doe"
}
```

Send, Status 204 No Content (Success, no content was returned)

Check in portal, the first name of UserA is updated.

## Azure Key Vault [187]

Store

- Encryption keys
- Certificates
- Secrets (Passwords)

## Lab - Azure Key Vault [188]

- Create a key vault
- Unique name keyvaultdpol
- Days to retain deleted vaults:12
- Review and create, Create

keyvaultdpol | Keys

## Lab - Azure Key Vault - Encryption keys [189]

keyvaultdpol | Keys

Create a key

appkey

VS

nuget Azure.Security.KeyVault.Keys

keyapp

keyvaultdpol | Access policies
Create an access policy

Key Management Operations -> Check [x] Get
Cryptographic Operations -> Check [x] Decrypt, [x] Encrypt

Principal - select KeyVaultApp

So KeyVaultApp = Key Permissions: Get, Encrypt, Decrypt

Without these permissions you will get
```
Azure.RequestFailedException: 'The user, group or application 'appid=9402fc42-8020-454e-a041-a11c8bf615a7;oid=87888664-2036-409f-8151-eb3de636052b;iss=https://sts.windows.net/87349d34-316a-481c-ab12-5f5c7af3cd99/' does not have keys get permission on key vault 'keyvaultdpol;location=northeurope'. For help resolving this issue, please see https://go.microsoft.com/fwlink/?linkid=2125287
Status: 403 (Forbidden)
ErrorCode: Forbidden
``` 

```csharp
using Azure.Identity;
using Azure.Security.KeyVault.Keys;
using Azure.Security.KeyVault.Keys.Cryptography;
using System.Text;

//App registrations:
string tenantId = "87349d34-316a-481c-ab12-5f5c7af3cd99"; //Directory (tenant) ID
string clientId = "9402fc42-8020-454e-a041-a11c8bf615a7"; //Application (client) ID
string clientSecret = "v1g8Q~.._3dwj"; // KeyVautApp | Certificates & secrets - new

string keyVaultUrl = "https://keyvaultdpol.vault.azure.net/"; //keyvaultdpol Vault URI
string keyName = "appkey"; // keyvaultdpol | Keys

string textToEncrypt = "This a secret text";

ClientSecretCredential clientSecretCredential = new ClientSecretCredential(tenantId, clientId, clientSecret);

KeyClient keyClient = new KeyClient(new Uri(keyVaultUrl), clientSecretCredential);

var key = keyClient.GetKey(keyName);

// The CryptographyClient class is part of the Azure Key vault package
// This is used to perform cryptographic operations with Azure Key Vault keys

var cryptoClient = new CryptographyClient(key.Value.Id, clientSecretCredential);

// We first need to take the bytes of the string that needs to be converted

byte[] textToBytes = Encoding.UTF8.GetBytes(textToEncrypt);

EncryptResult result = cryptoClient.Encrypt(EncryptionAlgorithm.RsaOaep, textToBytes);

Console.WriteLine("The encrypted text");
Console.WriteLine(Convert.ToBase64String(result.Ciphertext));

// Now lets decrypt the text
// We first need to convert our Base 64 string of the Cipertext to bytes

byte[] cipherToBytes = result.Ciphertext;

DecryptResult textDecrypted = cryptoClient.Decrypt(EncryptionAlgorithm.RsaOaep, cipherToBytes);

Console.WriteLine("Decrypted text:");
Console.WriteLine(Encoding.UTF8.GetString(textDecrypted.Plaintext));

Console.ReadKey();
```

## Lab - Azure Key Vault - Secrets [190]

Secure save secret in a Key Vault instead of embedding into application itself

Secure call to the Azure Key Vault to catch the secret

Connection String

keyvaultdpol | Secrets

Create a secret

dbconnectionstring

database | Connection Strings

copy cn with the password

**NB!**

- keyvaultdpol | Access policies
- KeyVaultApp -> Edit
- Secret permissions [x] Get

nuget Azure.Security.KeyVault.Secrets

```csharp
using Azure.Security.KeyVault.Secrets;
//...
        private SqlConnection GetConnection()
        {
            string tenantId = "";     // Directory (tenant) ID
            string clientId = "";     // Application (client) ID
            string clientSecret = ""; // KeyVaultApp | Certificates & secrets - new

            string keyVaultUrl = "https://keyvaultdpol.vault.azure.net/";
            string secretName = "dbconnectionstring";
            
            ClientSecretCredential clientSecretCredential = new ClientSecretCredential(tenantId, clientId, clientSecret);
            SecretClient secretClient = new SecretClient(new Uri(keyVaultUrl), clientSecretCredential);

            var secret = secretClient.GetSecret(secretName);

            string connectionString = secret.Value.Value;

            return new SqlConnection(connectionString);
        }
```

**We still use clientSecret in our app.**

## Managed Identities [191]

Helps Azure resources to authenticate TO services that support Azure AD authentication

appvm
demitry/ LZ1!

## Lab - Managed identities [192]

Previous versions:

```csharp
using Azure.Identity;
using Azure.Storage.Blobs;

string tenantId = "87349d34-316a-481c-ab12-5f5c7af3cd99";
string clientId = "45c63e12-a365-4dea-bb53-79e516131d8a";
string clientSecret = "R1u8Q....9ucLf";

string blobURI = "https://stacc505050.blob.core.windows.net/mycontainer/myfile.txt";

string filePath = "F:\\aztmp\\myfile.txt";

ClientSecretCredential clientCredential = new ClientSecretCredential(tenantId, clientId, clientSecret);

BlobClient blobClient = new BlobClient(new Uri(blobURI),clientCredential);

await blobClient.DownloadToAsync(filePath);

Console.WriteLine("The blob is downloaded");

```

appvm = 40.87.148.228

### Configure Managed identity for VM

appvm | Identity

System assigned

Turn on and Save

A system assigned managed identity is restricted to one per resource and is tied to the lifecycle of this resource.

You can grant permissions to the managed identity by using Azure role-based access control (Azure RBAC).

The managed identity is authenticated with Azure AD, **so you don’t have to store any credentials in code**

stacc505050 | Access Control (IAM)

- Add role assignment
- **Reader**
- Select members
- Search appvm - you will see identity
- Select
- Review and assign

- Add role assignment
- **Storage Blob Data Reader**
- Select members
- Search appvm - you will see identity
- Select
- Review and assign

On this env we will deploy our app

```csharp
using Azure.Core;
using Azure.Identity;
using Azure.Storage.Blobs;

string blobURI = "https://stacc505050.blob.core.windows.net/mycontainer/myfile.txt";
string filePath = "C:\\tmp1\\myfile.txt";

TokenCredential tokenCredential = new DefaultAzureCredential();

BlobClient blobClient = new BlobClient(new Uri(blobURI), tokenCredential);

await blobClient.DownloadToAsync(filePath);

Console.WriteLine("The blob is downloaded");
```

### DefaultAzureCredential Class

https://learn.microsoft.com/en-us/dotnet/api/azure.identity.defaultazurecredential?view=azure-dotnet

Provides a default TokenCredential authentication flow for applications that will be deployed to Azure. The following credential types if enabled will be tried, in order:

If we define WorkloadIdentityCredential, **DefaultAzureCredential can automatically get a token based on credentials that are defined for our environment**

- EnvironmentCredential (environment variables for virtual machine, for example)
- **WorkloadIdentityCredential** (our case)
- ManagedIdentityCredential
- AzureDeveloperCliCredential
- SharedTokenCacheCredential
- VisualStudioCredential
- VisualStudioCodeCredential
- AzureCliCredential
- AzurePowerShellCredential
- InteractiveBrowserCredential

### Setup RDP, map C drive

VM

appvm | Connect (Preview)

Native RDP
Connect via native RDP without any additional software needed. Recommended for testing only

Download and open the RDP file
Download and open the RDP file to connect to the virtual machine.

appvm.rdp
```
full address:s:40.87.148.228:3389
    prompt for credentials:i:1
    administrative session:i:1
```

appvm.rdp -> Edit -> Local resources -> More -> Drives -> [x] Local Disk (C:)

Connect

copy uor debug deploy

az-204\Projects\AzSecurity\ManagedIdentities\BlobApp\BlobApp\bin\Debug\

-> VM

create c:\tmp1, run app

## Lab - Managed Identity - Getting the access token [193]

## Lab - Managed Identity - Using the access token [194]

## Lab - Azure Web App - Managed Identity [195]

## Note on user assigned identities [196]

## Lab - User Assigned Identity [197]

## Lab - User Assigned Identity - PowerShell [198]

## Lab - PowerShell - Managed Identity [199]

## Lab - PowerShell - Storage Account - Key Vault [200]

Quiz 8: Short Quiz