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
        - [AD = the most secure](#ad--the-most-secure)
        - [Cannot use AD? -> use SAS](#cannot-use-ad---use-sas)
        - [Finally - use access keys](#finally---use-access-keys)
    - [Storage Accounts - Access Tiers](#storage-accounts---access-tiers)
        - [Hot tier default - accessed frequently, highest storage costs, but the lowest access costs](#hot-tier-default---accessed-frequently-highest-storage-costs-but-the-lowest-access-costs)
        - [Cool tier - infrequently accessed. min 30 days. lower storage costs and higher access costs compared to the hot tier](#cool-tier---infrequently-accessed-min-30-days-lower-storage-costs-and-higher-access-costs-compared-to-the-hot-tier)
        - [Archive tier - rarely accessed, flexible latency requirements. minimum 180 days](#archive-tier---rarely-accessed-flexible-latency-requirements-minimum-180-days)
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
        - [Avro tools](#avro-tools)
    - [What is Azure Table Storage](#what-is-azure-table-storage)
    - [Elements of Azure Table Storage](#elements-of-azure-table-storage)
    - [Lab - Azure Table Storage](#lab---azure-table-storage)
    - [Lab - .NET - Azure Table Storage - Add Entity](#lab---net---azure-table-storage---add-entity)
    - [Lab - .NET - Azure Table Storage - Reading Entities](#lab---net---azure-table-storage---reading-entities)
    - [Lab - .NET - Azure Table Storage - Deleting Entities](#lab---net---azure-table-storage---deleting-entities)
    - [Assignment 2: Assignment – Azure Blob – Updating a Table Entity](#assignment-2-assignment--azure-blob--updating-a-table-entity)
    - [Quiz 6: Short Quiz](#quiz-6-short-quiz)

<!-- /TOC -->

<style>
r { color: Red }
o { color: Orange }
g { color: Green }
</style>


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

<https://learn.microsoft.com/en-us/rest/api/storageservices/create-user-delegation-sas>

You can secure a shared access signature (SAS) token for access to a container, directory, or blob by using either Azure Active Directory (Azure AD) credentials or an account key.

A SAS that's **secured with Azure AD credentials** is called a **user delegation SAS**.

## Lab - Azure Storage Accounts - Azure AD Authentication

**Probably the most secure way to access storage account**

Azure Active Directory Authentication

Give access to resources

Azure Active Directory -> Users -> Create new user

storageusr

storageusr@dpoluektovgmail.onmicrosoft.com

Password: create temp pass, according to AD password policy it is required to change it on the first login

user storageusr@dpoluektovgmail.onmicrosoft.com = principal id

Storage explorer -> <del>Add Account</del>  Sign in with Azure...

Subscription -> Azure -> login

Tempazure1! -> newpassword

stacc10001 | Access Control (IAM) -> Add role assignment -> Role ->

Storage Account Contributor
Lets you manage storage accounts, including accessing storage account keys which provide full access to storage account data.

Next

Select Members -> storageusr -> Select

Review and Assign

**It is role-based access control**

stacc10001 | Access Control (IAM) -> Role assignments - check role assignments for users

Now you can see storage accounts in Storage Explorer for our storage user

try upload
Server failed to authenticate the request. Make sure the value of Authorization header is formed correctly including the signature. RequestId:a2ecc3d3-f01e-003b-303f-74ac96000000 Time:2023-04-21T10:55:11.1262489Z
Server failed to authenticate the request. Make sure the value of Authorization header is formed correctly including the signature. RequestId:f392f0c6-201e-005f-273f-741c36000000 Time:2023-04-21T10:56:24.1475608Z

but transfer is OK
Transfer of 'E:\MUSIC\...\cover.jpg' to 'data/' complete: 1 item transferred (used SAS, discovery completed)
Started at: 4/21/2023 1:56 PM, Duration: 4 seconds

**Probably the most secure way to access storage account**

## Azure Storage Accounts - Authorization techniques review

Azure AD - Probably the most secure way to access storage account

BUT in some cases you cannot add user

Need Audit and cannot add guest users to AD due to security policies?

=> Generate SAS (Shared Access Signature)

Audit people require temporary access to the data, (1 day, 2 weeks), so use SAS

Normally, giving Access keys - is NOT a good approach - it is last way to do authentication

Decision making:

### AD = the most secure

### Cannot use AD? -> use SAS

### Finally - use access keys

## Storage Accounts - Access Tiers

### Hot tier (default) - accessed frequently, highest storage costs, but the lowest access costs

### Cool tier - infrequently accessed. min 30 days. lower storage costs and higher access costs compared to the hot tier

### Archive tier - rarely accessed, flexible latency requirements. minimum 180 days

Azure Storage access tiers include:

- Cool tier - infrequently accessed. min 30 days. lower storage costs and higher access costs compared to the hot tier
- Archive tier - rarely accessed, flexible latency requirements. minimum 180 days
- Hot tier (default) - accessed frequently, highest storage costs, but the lowest access costs

## Lab - Hot and the Cool Access Tier

stacc10001 | Configuration

Blob access tier (default)

- Cool
- Hot (default)

this setting is for blob storage accounts

stacc10001 | Containers -> data - Access tier is hot for all

if you create st acc, New St Acc -> Advanced

Blob storage
Access tier
- **Hot**: Frequently accessed data and day-to-day usage scenarios
- **Cool**: Infrequently accessed data and backup scenarios

**Archived could be set on the blob level**

stacc10001 | Configuration -> Change to Cool -> Save

for all items in blob the Access tier is cool

storage price ↓ and access price ↑

## Lab - Storage Accounts - Archive Access Tier

blob object -> Change tier -> Archive

Setting the access tier to "Archive" will make your blob inaccessible until it is rehydrated back to "Hot" or "Cool", which may take several hours.

Save

This blob is currently archived and can't be downloaded. Rehydrate the blob by copying and pasting it in the desired storage account to download or change the blob’s tier to hot or cool.

storage cost - is the min

archive process could take time

cannot download

**rehydrate** back to "Hot" or "Cool" - Change Tier

rehydrate priority: Standard or High

## Lifecycle Management Policies

Based on lifecycle management rules - change the access tier, or even delete the object.

Define:

- Rule filters - for blobTypes - blockBlob, appendBlob
- Rule Actions - tierToCool, tierToArchive and delete
- Ru les are supported for blob and append blobs in General Purpose V2 accounts, Premium and Blob Storage accounts
- All regions are supported

stacc10001 | Lifecycle management

Add Rule ... Last modified ... more than 30 days Then move to cool access tier

Code Rule:

```json
{
  "rules": [
    {
      "enabled": true,
      "name": "RuleA",
      "type": "Lifecycle",
      "definition": {
        "actions": {
          "baseBlob": {
            "tierToCool": {
              "daysAfterModificationGreaterThan": 30
            }
          }
        },
        "filters": {
          "blobTypes": [
            "blockBlob"
          ]
        }
      }
    }
  ]
}
```

## Note on the rehydrate time

**Rehydration priority**

When you rehydrate a blob, you can set the priority for the rehydration operation via the optional x-ms-rehydrate-priority header on a Set Blob Tier or Copy Blob operation. 

Rehydration priority options:

- **Standard priority**: The rehydration request will be processed in the order it was received and may take up to <r>**15 hours**</r> to complete for objects under **10 GB in size**.

- **High priority**: The rehydration request will be prioritized over standard priority requests and may complete in <r>less than one hour</r> for objects under 10 GB in size.

## Blob Versioning

- Versions: maintain previous versions of blobs
- Restore: restore old versions
- Version ID: new ver is set whenever blob is updated
- Feature Enable/Disable: at any point in time

stacc10001 | Data protection

Check

Enable versioning for blobs

Use versioning to automatically maintain previous versions of your blobs. Learn more

Consider your workloads, their impact on the number of versions created, and the resulting costs. Optimize costs by automatically managing the data lifecycle. Learn more

Save

Containers, Object - Edit - Save, Edit, Save 

Versions

- Download
- Delete
- Make Current Version

```
2023-04-21T13:11:38.2843079Z
2023-04-21T13:10:32.9255080Z
2023-04-21T13:08:26.7892447Z
2023-04-21T13:07:12.3635830Z
...
```

stacc10001 | Data protection - Disable versioning

goto our container - versions are still here! (for this particular blob)

## Blob Snapshots

obj - Create snapshot

Delete, download, Promote a snapshot (make it current)

Edit, save, Promote a snapshot.

Q: What the difference between versions and snapshots?

A:

**Versions** will be created **for all blobs in storage accounts**. A lot of blobs -> **Impact on cost**.

What if you wants to **take a snapshot of very important 1 blob in time**? => **Use Snapshots**

## Soft Delete

- **Retention**: period 1-365 days
- **Availability**: Depending on retention period, the data could be available after deletion or after overwriting 
- **Restore**: During the retention period, can restore blobs and snapshots
- **Change**: Change the soft delete retention period at any time

stacc10001 | Data protection

Enable soft delete for containers - enabled by default

Soft delete enables you to recover blobs that were previously marked for deletion, including blobs that were overwritten.Learn more
Keep deleted blobs for (in days)

7 days (by default)

blob -> MySqlScript -> delete, also del snapshots

Button: Show deleted blobs

blob "..." menu -> Undelete

## Lab - .NET - Creating a container

```csharp
BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);
await blobServiceClient.CreateBlobContainerAsync(containerName, PublicAccessType.Blob);
```

## Lab - .NET - Uploading a Blob

```csharp
string blobName = "script.sql";
string filePath = $"f:\\aztmp\\{blobName}";

BlobContainerClient blobContainerClient = new BlobContainerClient(connectionString, containerName);

BlobClient blobClient = blobContainerClient.GetBlobClient(blobName);

await blobClient.UploadAsync(filePath, overwrite: true);

Console.WriteLine($"Uploaded blob {blobName} to the container{containerName}");
```

## Lab - .NET - List Blobs

```csharp
string ctName = "data";

BlobContainerClient blobContainerClientForListing = new BlobContainerClient(connectionString, ctName);
Console.WriteLine($"Blobs in {ctName} container:");

await foreach (BlobItem blobItem in blobContainerClientForListing.GetBlobsAsync())
{
    Console.WriteLine($"Blob name: {blobItem.Name}, Size: {blobItem.Properties.ContentLength} bytes, Tier: {blobItem.Properties.AccessTier}");
}

```

## Lab - .NET - Downloading a Blob

```csharp
string directory = $"f:\\aztmp\\download-{containerName}\\";
string filePathToDownload = $"{directory}{blobName}";

BlobClient blobClient2 = new BlobClient(connectionString, containerName, blobName);

Directory.CreateDirectory(directory);
await blobClient2.DownloadToAsync(filePathToDownload);
```

## Lab - .NET - Blob Metadata

<https://learn.microsoft.com/en-us/azure/storage/blobs/storage-blob-properties-metadata>

```csharp
public static class BlobHelper
{
    public static async Task AddBlobMetadataAsync(BlobClient blob)
    {
        Console.WriteLine("Adding blob metadata...");

        try
        {
            IDictionary<string, string> metadata =
               new Dictionary<string, string>();

            // Add metadata to the dictionary by calling the Add method
            metadata.Add("docType", "textDocuments");

            // Add metadata to the dictionary by using key/value syntax
            metadata["category"] = "guidance";

            metadata["Department"] = "Logistics";

            // Set the blob's metadata.
            await blob.SetMetadataAsync(metadata);
        }
        catch (RequestFailedException e)
        {
            Console.WriteLine($"HTTP error code {e.Status}: {e.ErrorCode}");
            Console.WriteLine(e.Message);
            Console.ReadLine();
        }
    }

    public static async Task ReadBlobMetadataAsync(BlobClient blob)
    {
        try
        {
            // Get the blob's properties and metadata.
            BlobProperties properties = await blob.GetPropertiesAsync();

            Console.WriteLine("Blob metadata:");

            // Enumerate the blob's metadata.
            foreach (var metadataItem in properties.Metadata)
            {
                Console.WriteLine($"\tKey: {metadataItem.Key}");
                Console.WriteLine($"\tValue: {metadataItem.Value}");
            }
        }
        catch (RequestFailedException e)
        {
            Console.WriteLine($"HTTP error code {e.Status}: {e.ErrorCode}");
            Console.WriteLine(e.Message);
            Console.ReadLine();
        }
    }
}
```

## Lab - .NET - Blob lease

Leasing a blob can be useful in a number of scenarios, such as:

1. Preventing concurrent writes: If multiple clients are writing to a blob at the same time, they may overwrite each other's changes and corrupt the data. By leasing the blob, you can ensure that only one client has write access at any given time.

2. Batch processing: If you need to perform batch processing on a set of blobs, you can lease each blob to prevent other clients from modifying them while the processing is taking place.

3. Coordinating access: If you have multiple threads or processes accessing a blob, you can use a lease to coordinate access and prevent conflicts.

When you acquire a lease on a blob, you can specify the duration of the lease. If the lease is not renewed before it expires, it will be automatically released. You can also release the lease manually at any time.

CloudBlob.AcquireLeaseAsync Method

//Time - If null, an infinite lease will be acquired. If not null, this must be 15 to 60 seconds.

https://learn.microsoft.com/en-us/dotnet/api/microsoft.azure.storage.blob.cloudblob.acquireleaseasync?view=azure-dotnet

https://github.com/Azure/azure-storage-net/blob/master/Test/WindowsRuntime/Blob/LeaseTests.cs

## Lab - AzCopy Tool

<https://learn.microsoft.com/en-us/azure/storage/common/storage-use-azcopy-v10>

Supported method of authorization

- Blob storage: Azure AD & SAS
- File storage: SAS only

notepad++ Settings > Preferences > Cloud & Link - Disable http links

copy azcopy to win dir or add path

```
//First create the shared access signature

// To create a container
azcopy make "https://stacc10001.blob.core.windows.net/mycontainer___SAS___"

// To upload a blob
azcopy copy myfile.txt "https://stacc10001.blob.core.windows.net/mycontainer/myfile.txt___SAS___"

// Download blob data
azcopy copy "https://stacc10001.blob.core.windows.net/mycontainer/myfile.txt___SAS___" "myfile_copy.txt"
```

## Moving a storage account to another region

<https://learn.microsoft.com/en-us/azure/storage/common/storage-account-move?tabs=azure-portal>

Create a new storage account at the destination region

<r>There in no direct way to copy or move storage account</r>

- Export a template.
- Modify the template by adding the target region and storage account name.
- Deploy the template to create the new storage account.
- Configure the new storage account.
- Move data to the new storage account.
- Delete the resources in the source region.

AzCopy or

You can also use **Azure Data Factory** to move your data



stacc10001 | Export template

new resource

Template deployment (deploy using custom templates)

 Build your own template in the editor

## Assignment 1: Assignment – AzCopy Tool

Copy from 1 acc container to 2 acc container:

azcopy copy "https://source_storage.blob.core.windows.net/source_container/source_SAS_Key" "https://target_storage.blob.core.windows.net/target_container/target_SAS_Key" --recursive=true

## Lab - Azure Blob - Change Feed

- Ordered, guaranteed, durable, immutable, read-only log of changes
- Audit log of events to Blob data - Create, update, delete
- Stored in $blobchangefeed container
- Apache Avro format

stacc10001 | Data protection

Enable blob change feed

Keep track of create, modification, and delete changes to blobs in your account.Learn more

- Keep all logs

- Delete change feed logs after (in days) 7

=> $blobchangefeed container created

Change some data in containers

$blobchangefeed / log / 00 / 2023 / 04 / 22 / 1500 / 00000.avro

### Avro tools

- Avro Tools: This is a command-line tool that comes with the Avro library. It allows you to view Avro files in various formats, including JSON and binary.

- AvroView: This is a web-based viewer that allows you to visualize and analyze Avro files in a browser. It supports filtering, sorting, and searching of data.

- Apache NiFi: This is a data integration tool that supports Avro files. It allows you to view and process Avro data in real-time.

- Hadoop File Viewer: This is a web-based viewer that is used to view and analyze Hadoop files, including Avro files. It allows you to browse, search, and download Avro files.

- Parquet Viewer: This is a GUI-based viewer that allows you to view and analyze Parquet files, which is another popular data serialization format used in big data processing. It also supports Avro files.

- There are also other commercial tools like Talend Big Data Studio and StreamSets Data Collector that provide support for Avro files 

## What is Azure Table Storage

## Elements of Azure Table Storage

## Lab - Azure Table Storage

## Lab - .NET - Azure Table Storage - Add Entity

## Lab - .NET - Azure Table Storage - Reading Entities

## Lab - .NET - Azure Table Storage - Deleting Entities

## Assignment 2: Assignment – Azure Blob – Updating a Table Entity

## Quiz 6: Short Quiz
