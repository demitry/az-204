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

## 114. Lab - Using Azure Storage Explorer

## 115. Lab - Using Access keys

## 116. Lab - Shared Access Signatures - At the Blob level

## 117. Lab - Shared Access Signatures - At the Storage Account Level

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
