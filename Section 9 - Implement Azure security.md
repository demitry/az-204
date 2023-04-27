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
    - [Lab - Getting user and group information - Implementation [185]](#lab---getting-user-and-group-information---implementation-185)
    - [Lab - Graph API - Update user [186]](#lab---graph-api---update-user-186)
    - [Azure Key Vault [187]](#azure-key-vault-187)
    - [Lab - Azure Key Vault [188]](#lab---azure-key-vault-188)
    - [Lab - Azure Key Vault - Encryption keys [189]](#lab---azure-key-vault---encryption-keys-189)
    - [Lab - Azure Key Vault - Secrets [190]](#lab---azure-key-vault---secrets-190)
    - [Managed Identities [191]](#managed-identities-191)
    - [Lab - Managed identities [192]](#lab---managed-identities-192)
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



## Lab - Application Object - Blob objects [182]
## What is Microsoft Graph [183]
## Lab - Getting user and group information - Application Configuration [184]
## Lab - Getting user and group information - Implementation [185]
## Lab - Graph API - Update user [186]
## Azure Key Vault [187]
## Lab - Azure Key Vault [188]
## Lab - Azure Key Vault - Encryption keys [189]
## Lab - Azure Key Vault - Secrets [190]
## Managed Identities [191]
## Lab - Managed identities [192]
## Lab - Managed Identity - Getting the access token [193]
## Lab - Managed Identity - Using the access token [194]
## Lab - Azure Web App - Managed Identity [195]
## Note on user assigned identities [196]
## Lab - User Assigned Identity [197]
## Lab - User Assigned Identity - PowerShell [198]
## Lab - PowerShell - Managed Identity [199]
## Lab - PowerShell - Storage Account - Key Vault [200]
Quiz 8: Short Quiz