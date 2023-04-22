<!-- TOC -->

- [Section 8 - Develop for Azure Storage - Azure Cosmos DB](#section-8---develop-for-azure-storage---azure-cosmos-db)
    - [Section Resources download [145.]](#section-resources-download-145)
    - [What are we going to cover [146.]](#what-are-we-going-to-cover-146)
    - [What is Azure Cosmos DB [147.]](#what-is-azure-cosmos-db-147)
    - [Concept of Partitions [148.]](#concept-of-partitions-148)
    - [Costing [149.]](#costing-149)
    - [Lab - Creating an Azure Cosmos DB Account [150.]](#lab---creating-an-azure-cosmos-db-account-150)
    - [The usage of JSON [151.]](#the-usage-of-json-151)
    - [Adding items to the container [152.]](#adding-items-to-the-container-152)
    - [More on Partition Keys [153.]](#more-on-partition-keys-153)
    - [Running a few queries [154.]](#running-a-few-queries-154)
    - [Objects within Objects [155.]](#objects-within-objects-155)
    - [JSON Arrays [156.]](#json-arrays-156)
    - [Assignment 3: Assignment - Customer quantity total [    ]](#assignment-3-assignment---customer-quantity-total-----)
    - [Lab - .NET - Create Database and container [157.]](#lab---net---create-database-and-container-157)
    - [Lab - .NET - Adding an item [158.]](#lab---net---adding-an-item-158)
    - [Lab - .NET - Reading items [159.]](#lab---net---reading-items-159)
    - [Lab - .NET - Replacing items [160.]](#lab---net---replacing-items-160)
    - [Lab - .NET - Deleting items [161.]](#lab---net---deleting-items-161)
    - [Lab - .NET - Array of Objects - Adding item [162.]](#lab---net---array-of-objects---adding-item-162)
    - [Assignment 4: Assignment - .NET - Array of Objects - Reading items [    ]](#assignment-4-assignment---net---array-of-objects---reading-items-----)
    - [Assignment 5: Assignment - .NET - Array of Objects - Adding orders [    ]](#assignment-5-assignment---net---array-of-objects---adding-orders-----)
    - [Lab - Azure Cosmos DB - Table API [163.]](#lab---azure-cosmos-db---table-api-163)
    - [Lab - .NET - Table API - Adding items [164.]](#lab---net---table-api---adding-items-164)
    - [When to choose what API [165.]](#when-to-choose-what-api-165)
    - [Lab - Stored Procedures [166.]](#lab---stored-procedures-166)
    - [Lab - Stored Procedures - Create an item [167.]](#lab---stored-procedures---create-an-item-167)
    - [Lab - Triggers [168.]](#lab---triggers-168)
    - [Change Feed [169.]](#change-feed-169)
    - [Lab - Change Feed - Azure Functions [170.]](#lab---change-feed---azure-functions-170)
    - [Lab - Change Feed - Feed Processor [171.]](#lab---change-feed---feed-processor-171)
    - [Using Composite Indexes [172.]](#using-composite-indexes-172)
    - [Time to live [173.]](#time-to-live-173)
    - [Consistency [174.]](#consistency-174)
    - [Quiz 7: Short Quiz [    ]](#quiz-7-short-quiz-----)

<!-- /TOC -->

# Section 8 - Develop for Azure Storage - Azure Cosmos DB
## Section Resources download [145.]
## What are we going to cover [146.]
## What is Azure Cosmos DB [147.]
## Concept of Partitions [148.]
## Costing [149.]
## Lab - Creating an Azure Cosmos DB Account [150.]
## The usage of JSON [151.]
## Adding items to the container [152.]
## More on Partition Keys [153.]
## Running a few queries [154.]
## Objects within Objects [155.]
## JSON Arrays [156.]
   ## Assignment 3: Assignment - Customer quantity total [    ]
## Lab - .NET - Create Database and container [157.]
## Lab - .NET - Adding an item [158.]
## Lab - .NET - Reading items [159.]
## Lab - .NET - Replacing items [160.]
## Lab - .NET - Deleting items [161.]
## Lab - .NET - Array of Objects - Adding item [162.]
   ## Assignment 4: Assignment - .NET - Array of Objects - Reading items [    ]
   ## Assignment 5: Assignment - .NET - Array of Objects - Adding orders [    ]
## Lab - Azure Cosmos DB - Table API [163.]
## Lab - .NET - Table API - Adding items [164.]
## When to choose what API [165.]
## Lab - Stored Procedures [166.]
## Lab - Stored Procedures - Create an item [167.]
## Lab - Triggers [168.]
## Change Feed [169.]
## Lab - Change Feed - Azure Functions [170.]
## Lab - Change Feed - Feed Processor [171.]
## Using Composite Indexes [172.]
## Time to live [173.]
## Consistency [174.]
   ## Quiz 7: Short Quiz [    ]