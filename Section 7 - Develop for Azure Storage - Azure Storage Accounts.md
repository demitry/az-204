# Section 7: Develop for Azure Storage - Azure Storage Accounts

## 107. What are Azure Storage Accounts

Azure Storage Accounts

provides storage in the cloud

* **Blob** - Objects, Images, Videos
* **Table** - Table data
* **Queue** - storing Queues, used for sending and receiving messages
* **File** - used for creating shares

## 108. Different types of storage accounts

* Standard General Purpose = standard file shares, queues, and tables
* Premium block blobs = block and append blobs. Fast access, hight transaction rates
* Premium page blobs = page blobs. Storing virtual hard disks for Azure VMs, fast access, hight transaction rates
* Premium file shares = access files, hight transaction rates.

## 109. Lab - Creating an Azure storage account

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

## 110. Azure Blob service

Blob Service - optimized for storing large amounts of unstructured data

You starting a container ("root folder")and upload files/images/videos etc.

Each of file is object = has unique URL, as a part of service.

* block blobs

* append blobs

* page blobs

## 111. Lab - Blob service - Uploading a blob

Container - Create - Upload

Upload - Advanced - Upload to folder (it will create a folder)

BUT if you want to have **a folder structure in place = use Data Lake Storage Gen2 (DLS Gen2)**

## 112. Lab - Blob service - Accessing the blob

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

## 113. Azure Storage Accounts - Different authorization techniques

There is various ways to authorize as a user or application:

* Access Keys
* Shared Access Signatures
* Azure Active Directory

## 114. Lab - Using Azure Storage Explorer

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

## 115. Lab - Using Access keys

stacc10001 | Access keys

Q: Why 2 keys?

A: **If Key1 is compromised**, app can use Key2, then you can **Rotate** 
Key1(make old key unusable)

User has no Azure account

Connect Dialog -> Storage account or service -> Account name and key -> Connect

## 116. Lab - Shared Access Signatures - At the Blob level

Shared Access Signatures set at the blob level

stacc10001 | Containers, data container - Private access

Goto object, Generate SAS (Shared Access Signature)

Uses 1 of access keys to generate SAS

Permission: Read etc.

Start / **Expiry date/time** of this Shared Access Signature (SAS)

Allowed IP addresses - has access

Generate **Blob SAS token** and **Blog SAS URL**

Another object cannot be accessed

## 117. Lab - Shared Access Signatures - At the Storage Account Level

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

## 118. Lab - Azure Storage Accounts - Stored Access Policy

## 119. Note on different types of Shares Access Signatures

## 120. Lab - Azure Storage Accounts - Azure AD Authentication

## 121. Azure Storage Accounts - Authorization techniques review

## 122. Storage Accounts - Access Tiers

## 123. Lab - Hot and the Cool Access Tier

## 124. Lab - Storage Accounts - Archive Access Tier

## 125. Lifecycle Management Policies

## 126. Note on the rehydrate time

## 127. Blob Versioning

## 128. Blob Snapshots

## 129. Soft Delete

## 130. Lab - .NET - Creating a container

## 131. Lab - .NET - Uploading a Blob

## 132. Lab - .NET - List Blobs

## 133. Lab - .NET - Downloading a Blob

## 134. Lab - .NET - Blob Metadata

## 135. Lab - .NET - Blob lease

## 136. Lab - AzCopy Tool

## 137. Moving a storage account to another region

## Assignment 1: Assignment – AzCopy Tool

## 138. Lab - Azure Blob - Change Feed

## 139. What is Azure Table Storage

## 140. Elements of Azure Table Storage

## 141. Lab - Azure Table Storage

## 142. Lab - .NET - Azure Table Storage - Add Entity

## 143. Lab - .NET - Azure Table Storage - Reading Entities

## 144. Lab - .NET - Azure Table Storage - Deleting Entities

## Assignment 2: Assignment – Azure Blob – Updating a Table Entity

## Quiz 6: Short Quiz
