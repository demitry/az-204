<!-- TOC -->

- [Section 7: Develop for Azure Storage - Azure Storage Accounts](#section-7-develop-for-azure-storage---azure-storage-accounts)
    - [What are Azure Storage Accounts](#what-are-azure-storage-accounts)
    - [Different types of storage accounts](#different-types-of-storage-accounts)
    - [Lab - Creating an Azure storage account](#lab---creating-an-azure-storage-account)
    - [Azure Blob service](#azure-blob-service)
    - [Lab - Blob service - Uploading a blob](#lab---blob-service---uploading-a-blob)
    - [Lab - Blob service - Accessing the blob](#lab---blob-service---accessing-the-blob)
    - [Azure Storage Accounts - Different authorization techniques](#azure-storage-accounts---different-authorization-techniques)
    - [Lab - Using Azure Storage Explorer](#lab---using-azure-storage-explorer)
    - [Lab - Using Access keys](#lab---using-access-keys)
    - [Lab - Shared Access Signatures - At the Blob level](#lab---shared-access-signatures---at-the-blob-level)
    - [Lab - Shared Access Signatures - At the Storage Account Level](#lab---shared-access-signatures---at-the-storage-account-level)
    - [Lab - Azure Storage Accounts - Stored Access Policy](#lab---azure-storage-accounts---stored-access-policy)
    - [Note on different types of Shares Access Signatures](#note-on-different-types-of-shares-access-signatures)
    - [Lab - Azure Storage Accounts - Azure AD Authentication](#lab---azure-storage-accounts---azure-ad-authentication)
    - [Azure Storage Accounts - Authorization techniques review](#azure-storage-accounts---authorization-techniques-review)
    - [Storage Accounts - Access Tiers](#storage-accounts---access-tiers)
    - [Lab - Hot and the Cool Access Tier](#lab---hot-and-the-cool-access-tier)
    - [Lab - Storage Accounts - Archive Access Tier](#lab---storage-accounts---archive-access-tier)
    - [Lifecycle Management Policies](#lifecycle-management-policies)
    - [Note on the rehydrate time](#note-on-the-rehydrate-time)
    - [Blob Versioning](#blob-versioning)
    - [Blob Snapshots](#blob-snapshots)
    - [Soft Delete](#soft-delete)
    - [Lab - .NET - Creating a container](#lab---net---creating-a-container)
    - [Lab - .NET - Uploading a Blob](#lab---net---uploading-a-blob)
    - [Lab - .NET - List Blobs](#lab---net---list-blobs)
    - [Lab - .NET - Downloading a Blob](#lab---net---downloading-a-blob)
    - [Lab - .NET - Blob Metadata](#lab---net---blob-metadata)
    - [Lab - .NET - Blob lease](#lab---net---blob-lease)
    - [Lab - AzCopy Tool](#lab---azcopy-tool)
    - [Moving a storage account to another region](#moving-a-storage-account-to-another-region)
    - [Assignment 1: Assignment – AzCopy Tool](#assignment-1-assignment--azcopy-tool)
    - [Lab - Azure Blob - Change Feed](#lab---azure-blob---change-feed)
    - [What is Azure Table Storage](#what-is-azure-table-storage)
    - [Elements of Azure Table Storage](#elements-of-azure-table-storage)
    - [Lab - Azure Table Storage](#lab---azure-table-storage)
    - [Lab - .NET - Azure Table Storage - Add Entity](#lab---net---azure-table-storage---add-entity)
    - [Lab - .NET - Azure Table Storage - Reading Entities](#lab---net---azure-table-storage---reading-entities)
    - [Lab - .NET - Azure Table Storage - Deleting Entities](#lab---net---azure-table-storage---deleting-entities)
    - [Assignment 2: Assignment – Azure Blob – Updating a Table Entity](#assignment-2-assignment--azure-blob--updating-a-table-entity)
    - [Quiz 6: Short Quiz](#quiz-6-short-quiz)

<!-- /TOC -->

# Section 7: Develop for Azure Storage - Azure Storage Accounts

## What are Azure Storage Accounts

Azure Storage Accounts

provides storage in the cloud

* **Blob** - Objects, Images, Videos
* **Table** - Table data
* **Queue** - storing Queues, used for sending and receiving messages
* **File** - used for creating shares

## Different types of storage accounts

* Standard General Purpose = standard file shares, queues, and tables
* Premium block blobs = block and append blobs. Fast access, hight transaction rates
* Premium page blobs = page blobs. Storing virtual hard disks for Azure VMs, fast access, hight transaction rates
* Premium file shares = access files, hight transaction rates.

## Lab - Creating an Azure storage account

All Resources -> Create a resource -> Storage account

or

Storage Accounts -> Create

stacc10001

Performance

* **Standard**: Recommended for most scenarios (general-purpose v2 account)

* **Premium**: Recommended for scenarios that require low latency.
  * **Block blobs**: Best for high transaction rates or low storage latency
  * **File Shares**: Best for enterprise or high-performance applications that need to scale
  * **Page Blobs**: Best for random read and write operations

Data storage:

* Containers
* File shares
* Queues
* Tables

## Azure Blob service

Blob Service - optimized for storing large amounts of unstructured data

You starting a container ("root folder")and upload files/images/videos etc.

Each of file is object = has unique URL, as a part of service.

* block blobs

* append blobs

* page blobs

## Lab - Blob service - Uploading a blob

Container - Create - Upload

Upload - Advanced - Upload to folder (it will create a folder)

BUT if you want to have **a folder structure in place = use Data Lake Storage Gen2 (DLS Gen2)**

## Lab - Blob service - Accessing the blob

Logged as admin - can download

Unique URL

https://stacc10001.blob.core.windows.net/data/UsefulCommands.md

URL: http://<storage account>.<service>/<name of container>/<name of object>

**storage account** - stacc10001

**service** - blob.core.windows.net

**name of container** - data

**name of object** - UsefulCommands.md

but

This XML file does not appear to have any style information associated with it. The document tree is shown below.

```xml
<Error>
<Code>ResourceNotFound</Code>
<Message>The specified resource does not exist. RequestId:49b221bb-401e-0029-6878-73988a000000 Time:2023-04-20T11:09:03.3935965Z</Message>
</Error>
```

We don't have access (not authorized)

As of version 2009-09-19, the container permissions provide the following options for managing container access:

* **No public read access**: Container and blob data can be read by the account owner only.

* **Full public read access**: Container and blob data can be read via anonymous request. Clients can enumerate blobs within the container via anonymous request, but they can't enumerate containers within the storage account.

* **Public read access for blobs only**: Blob data within this container can be read via anonymous request, but container data isn't available. Clients can't enumerate blobs within the container via anonymous request.

<https://learn.microsoft.com/en-us/rest/api/storageservices/get-container-acl>

There is various ways to authorize.

NOT secure way to give access

if change ACL to Public read access for blobs only
=> can access this file anonymously

## Azure Storage Accounts - Different authorization techniques

There is various ways to authorize as a user or application:

* Access Keys
* Shared Access Signatures
* Azure Active Directory

## Lab - Using Azure Storage Explorer

<https://azure.microsoft.com/en-us/products/storage/storage-explorer/>

Issue:

No Subscription Found after Successful Sign-In

https://github.com/microsoft/AzureStorageExplorer/issues/5777

Solution:

<https://github.com/microsoft/AzureStorageExplorer/issues/5777>

MRayermannMSFT commented on May 26, 2022
@mrw3050 do you have any other tenants listed? They would be at the same logical level as the "Microsoft account (home tenant)". If so, is it possible your subscription is in one of those tenants? **If so, please click on the checkboxes for those tenants.**
Create storage simple

Upload, Delete, you can **Copy Command**

Upload object:
```
$env:AZCOPY_CRED_TYPE = "Anonymous";
$env:AZCOPY_CONCURRENCY_VALUE = "AUTO";
./azcopy.exe copy "E:\MUSIC\Music Dark Usa\3rd Secret - 2022 - 3rd Secret (24bit-96kHz)\11 The Yellow Dress.flac" "https://stacc10001.blob.core.windows.net/new/11%20The%20Yellow%20Dress.flac?sv=2021-10-04&se=2023-05-20T12%3A10%3A47Z&sr=c&sp=rwl&sig=KIo******%3D" --overwrite=prompt --from-to=LocalBlob --blob-type Detect --follow-symlinks --check-length=true --put-md5 --follow-symlinks --disable-auto-decoding=false --recursive --log-level=INFO;
$env:AZCOPY_CRED_TYPE = "";
$env:AZCOPY_CONCURRENCY_VALUE = "";
```

Delete object:
```
$env:AZCOPY_CONCURRENCY_VALUE = "AUTO";
$env:AZCOPY_CRED_TYPE = "Anonymous";
./azcopy.exe remove "https://stacc10001.blob.core.windows.net/new/11%20The%20Yellow%20Dress.flac?sv=2021-10-04&se=2023-05-20T12%3A21******o%3D" --from-to=BlobTrash --recursive --log-level=INFO;
$env:AZCOPY_CONCURRENCY_VALUE = "";
$env:AZCOPY_CRED_TYPE = "";

```

## Lab - Using Access keys

stacc10001 | Access keys

Q: Why 2 keys?

A: **If Key1 is compromised**, app can use Key2, then you can **Rotate** 
Key1(make old key unusable)

User has no Azure account

Connect Dialog -> Storage account or service -> Account name and key -> Connect

## Lab - Shared Access Signatures - At the Blob level

Shared Access Signatures set at the blob level

stacc10001 | Containers, data container - Private access

Goto object, Generate SAS (Shared Access Signature)

Uses 1 of access keys to generate SAS

Permission: Read etc.

Start / **Expiry date/time** of this Shared Access Signature (SAS)

Allowed IP addresses - has access

Generate **Blob SAS token** and **Blog SAS URL**

Another object cannot be accessed

## Lab - Shared Access Signatures - At the Storage Account Level

stacc10001 | Shared access signature

* Allowed services: Blob
* Allowed resource type: Service
* Allowed permissions: List, Read
* Allowed resource types: Service, Container, Object
* Allowed blob index permissions: Disable All
* Start End Time
* Allowed IP addresses
* Signed key 1 or 2

**Generate SAS and connection string**

* Connection string
* SAS token
* Blob service SAS URL

Blob service SAS URL = access entire service

try to access Blob service SAS URL:

```xml
<Error>
<Code>InvalidQueryParameterValue</Code>
<Message>Value for one of the query parameters specified in the request URI is invalid. RequestId:348e947c-101e-005c-0291-731f31000000 Time:2023-04-20T14:07:03.3308095Z</Message>
<QueryParameterName>comp</QueryParameterName>
<QueryParameterValue/>
<Reason/>
</Error>
```

Storage Explorer - detach old

Connect -> Shared access signature URL (SAS)

Service URL: **Blob service SAS URL**

Have access only to blob service, as it was set up. (no queues etc.)

Cannot upload: Failed to start transfer: Insufficient credentials.

because we set up just List/Read access

## Lab - Azure Storage Accounts - Stored Access Policy

What is Shared access signature gets in wrong hands? Compromised?

Wait for expiry date-time?

Stored Access Policy could be attached to SAS

stacc -> Containers -> data | Access policy

2 types of policies:

**Stored access policies** -> Add policy

- Identifier: ReadPolicy
- Permissions: Read, List
- Start/Expiry Date Time

Data Explorer

data-> Get Shared Access Signature

Access Policy: Read Policy -> Expiry Date Time, Create

We have SAS:

If you get SAS for blob => connect blob
If you get SAS for account => connect account

data (blob) => right click -> Get Shared access signature - select ReadPolicy

Connect -> Blob Container -> Shared access signature URL SAS -> Paste

Have access

Remove access to the policy assigned to the SAS Shared Access Signature.

data | Access policy

Edit Read Policy - remove permissions

=> In the data explorer try to access data container:

 Server failed to authenticate the request. Make sure the value of Authorization header is formed correctly including the signature. RequestId:2c8a2e67-701e-0003-5bb6-73edcf000000 Time:2023-04-20T18:35:06.6247556Z

Because access policy permissions were changed.

## Note on different types of Shares Access Signatures

## Lab - Azure Storage Accounts - Azure AD Authentication

## Azure Storage Accounts - Authorization techniques review

## Storage Accounts - Access Tiers

## Lab - Hot and the Cool Access Tier

## Lab - Storage Accounts - Archive Access Tier

## Lifecycle Management Policies

## Note on the rehydrate time

## Blob Versioning

## Blob Snapshots

## Soft Delete

## Lab - .NET - Creating a container

## Lab - .NET - Uploading a Blob

## Lab - .NET - List Blobs

## Lab - .NET - Downloading a Blob

## Lab - .NET - Blob Metadata

## Lab - .NET - Blob lease

## Lab - AzCopy Tool

## Moving a storage account to another region

## Assignment 1: Assignment – AzCopy Tool

## Lab - Azure Blob - Change Feed

## What is Azure Table Storage

## Elements of Azure Table Storage

## Lab - Azure Table Storage

## Lab - .NET - Azure Table Storage - Add Entity

## Lab - .NET - Azure Table Storage - Reading Entities

## Lab - .NET - Azure Table Storage - Deleting Entities

## Assignment 2: Assignment – Azure Blob – Updating a Table Entity

## Quiz 6: Short Quiz
