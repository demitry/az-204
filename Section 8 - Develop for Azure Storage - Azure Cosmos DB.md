<!-- TOC -->

- [Section 8 - Develop for Azure Storage - Azure Cosmos DB](#section-8---develop-for-azure-storage---azure-cosmos-db)
    - [Section Resources download [145]](#section-resources-download-145)
    - [What are we going to cover [146]](#what-are-we-going-to-cover-146)
    - [What is Azure Cosmos DB [147]](#what-is-azure-cosmos-db-147)
    - [Concept of Partitions [148]](#concept-of-partitions-148)
        - [Partitions](#partitions)
        - [Partition Key](#partition-key)
    - [Costing [149]](#costing-149)
        - [Request Units](#request-units)
        - [Serverless mode](#serverless-mode)
        - [Autoscale mode](#autoscale-mode)
    - [Lab - Creating an Azure Cosmos DB Account [150]](#lab---creating-an-azure-cosmos-db-account-150)
    - [The usage of JSON [151]](#the-usage-of-json-151)
    - [Adding items to the container [152]](#adding-items-to-the-container-152)
    - [More on Partition Keys [153]](#more-on-partition-keys-153)
    - [Running a few queries [154]](#running-a-few-queries-154)
    - [Objects within Objects [155]](#objects-within-objects-155)
    - [JSON Arrays [156]](#json-arrays-156)
    - [Assignment 3: Assignment - Customer quantity total [    ]](#assignment-3-assignment---customer-quantity-total-----)
    - [Lab NET - Create Database and container [157]](#lab-net---create-database-and-container-157)
    - [Lab NET - Adding an item [158]](#lab-net---adding-an-item-158)
    - [Lab NET - Reading items [159]](#lab-net---reading-items-159)
    - [Lab NET - Replacing items [160]](#lab-net---replacing-items-160)
    - [Lab NET - Deleting items [161]](#lab-net---deleting-items-161)
    - [Lab NET - Array of Objects - Adding item [162]](#lab-net---array-of-objects---adding-item-162)
    - [Assignment 4: Assignment NET - Array of Objects - Reading items [    ]](#assignment-4-assignment-net---array-of-objects---reading-items-----)
    - [Assignment 5: Assignment NET - Array of Objects - Adding orders [    ]](#assignment-5-assignment-net---array-of-objects---adding-orders-----)
    - [Lab - Azure Cosmos DB - Table API [163]](#lab---azure-cosmos-db---table-api-163)
    - [Lab NET - Table API - Adding items [164]](#lab-net---table-api---adding-items-164)
    - [When to choose what API [165]](#when-to-choose-what-api-165)
    - [Lab - Stored Procedures [166]](#lab---stored-procedures-166)
    - [Lab - Stored Procedures - Create an item [167]](#lab---stored-procedures---create-an-item-167)
    - [Lab - Triggers [168]](#lab---triggers-168)
    - [Change Feed [169]](#change-feed-169)
    - [Lab - Change Feed - Azure Functions [170]](#lab---change-feed---azure-functions-170)
    - [Lab - Change Feed - Feed Processor [171]](#lab---change-feed---feed-processor-171)
    - [Using Composite Indexes [172]](#using-composite-indexes-172)
    - [Time to live [173]](#time-to-live-173)
    - [Consistency [174]](#consistency-174)

<!-- /TOC -->

<style>
r { color: Red }
o { color: Orange }
g { color: Green }
</style>

# Section 8 - Develop for Azure Storage - Azure Cosmos DB

## Section Resources download [145]

## What are we going to cover [146]

## What is Azure Cosmos DB [147]

- Fully managed NoSQL database
- Milliseconds response time
- Scale automatically

Create Cosmos DB account = choose API

- SQL API
- MongoDB API
- Gremlin (graph based)
- Cassandra
- Table-based API

According to API - different terminology (Container, Item terms)

Database account

Database

## Concept of Partitions [148]

### Partitions

- Logical Partition - items in a container are divided into subsets (partitions)
- Partition key - the partition for the item is decided by the partition key that is associated with the item in the container
- Item Id - uniquely identifies an item in the partition
- Identification: **[Partition key + Item Id]** uniquely identifies an item in the container
- Size: logical partition - up to 20 Gb
- Limit: No limit when it comes to the number of logical partitions within a container

### Partition Key

- <r> **Choose property for the partition key which the value does not change.**</r>
- The property should have a wide range of possible values.
- Once decide on a partition key for the container - <r>**you CANNOT change it.**</r>

## Costing [149]

### Request Units

- Cost of DB operations is measured in terms of Request Units
- Request Units - blended measure of CPU, IOPS and memory usage
- No matter which API is used

Everything is managed by the platform

- Cost of reading 1KB = 1 Request Unit
- Other operations - has their own measure of charged Request Units
- For each operation you can see the amount of Request Units for this operation

You are billed on an hourly basis

Provision : On the container level or on the database level

"throughput" - speed at which data is transferred

### Serverless mode

- You don't provision any throughput

- This is managed by Cosmos DB

- Bill - based on Request Units you consume

### Autoscale mode

Automatically scale up and down the required resources based on the number of requests that your application receives.

- Request Units can autoscale up and down based on demand
- Demand is checked on container abd database level
- Great for critical workloads
 
## Lab - Creating an Azure Cosmos DB Account [150]

## The usage of JSON [151]

## Adding items to the container [152]

## More on Partition Keys [153]

## Running a few queries [154]

## Objects within Objects [155]

## JSON Arrays [156]

## Assignment 3: Assignment - Customer quantity total [    ]

## Lab NET - Create Database and container [157]

## Lab NET - Adding an item [158]

## Lab NET - Reading items [159]

## Lab NET - Replacing items [160]

## Lab NET - Deleting items [161]

## Lab NET - Array of Objects - Adding item [162]

## Assignment 4: Assignment NET - Array of Objects - Reading items [    ]

## Assignment 5: Assignment NET - Array of Objects - Adding orders [    ]

## Lab - Azure Cosmos DB - Table API [163]

## Lab NET - Table API - Adding items [164]

## When to choose what API [165]

## Lab - Stored Procedures [166]

## Lab - Stored Procedures - Create an item [167]

## Lab - Triggers [168]

## Change Feed [169]

## Lab - Change Feed - Azure Functions [170]

## Lab - Change Feed - Feed Processor [171]

## Using Composite Indexes [172]

## Time to live [173]

## Consistency [174]

Quiz 7: Short Quiz [    ]
