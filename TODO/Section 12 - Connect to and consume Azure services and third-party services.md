<!-- TOC -->

- [Section 12: Connect to and consume Azure services and third-party services](#section-12-connect-to-and-consume-azure-services-and-third-party-services)
    - [Section Resources download [266]](#section-resources-download-266)
    - [Using a messaging service [267]](#using-a-messaging-service-267)
    - [The purpose of the queue service [268]](#the-purpose-of-the-queue-service-268)
    - [Lab - Azure Storage Queue [269]](#lab---azure-storage-queue-269)
    - [Lab - Azure Storage Queue - .NET - Sending messages [270]](#lab---azure-storage-queue---net---sending-messages-270)
    - [Lab - Azure Storage Queue - .NET - Peek messages [271]](#lab---azure-storage-queue---net---peek-messages-271)
    - [Lab - Azure Storage Queue - .NET - Receive messages [272]](#lab---azure-storage-queue---net---receive-messages-272)
    - [Lab - Azure Storage Queue - .NET - Get queue length [273]](#lab---azure-storage-queue---net---get-queue-length-273)
    - [Lab - Sending and Receiving objects [274]](#lab---sending-and-receiving-objects-274)
    - [Lab - Azure Storage Queue - Azure Functions [275]](#lab---azure-storage-queue---azure-functions-275)
    - [Lab - Sending Messages in base64 encoded [276]](#lab---sending-messages-in-base64-encoded-276)
    - [Assignment 8: Assignment - Peek messages in base64 encoded [   ]](#assignment-8-assignment---peek-messages-in-base64-encoded----)
    - [Lab - Other trigger input type [277]](#lab---other-trigger-input-type-277)
    - [Lab - Output to Table storage [278]](#lab---output-to-table-storage-278)
    - [Another way of writing the code to output to table storage [279]](#another-way-of-writing-the-code-to-output-to-table-storage-279)
    - [Azure Queue trigger - Important Note [280]](#azure-queue-trigger---important-note-280)
    - [What is Azure Service Bus [281]](#what-is-azure-service-bus-281)
    - [Lab - Creating an Azure Service Bus Queue [282]](#lab---creating-an-azure-service-bus-queue-282)
    - [Lab - Working with the Azure Service Bus Queue [283]](#lab---working-with-the-azure-service-bus-queue-283)
    - [Lab - Azure Service Bus queue - .NET - Sending messages [284]](#lab---azure-service-bus-queue---net---sending-messages-284)
    - [Lab - Azure Service Bus queue - .NET - Peek messages [285]](#lab---azure-service-bus-queue---net---peek-messages-285)
    - [Assignment 9: Assignment - Azure Service Bus queue - .NET - Receive messages [   ]](#assignment-9-assignment---azure-service-bus-queue---net---receive-messages----)
    - [Lab - Azure Service Bus queue - Message properties [286]](#lab---azure-service-bus-queue---message-properties-286)
    - [Lab - Azure Service Bus queue - Application properties [287]](#lab---azure-service-bus-queue---application-properties-287)
    - [Azure Service Bus queue - Message processor [288]](#azure-service-bus-queue---message-processor-288)
    - [Azure Service Bus queue - Message lock duration [289]](#azure-service-bus-queue---message-lock-duration-289)
    - [Lab - Azure Service Bus queue - Message lock duration [290]](#lab---azure-service-bus-queue---message-lock-duration-290)
    - [Lab - Azure Service Bus queue - Time to live [291]](#lab---azure-service-bus-queue---time-to-live-291)
    - [Lab - Azure Service Bus queue - Dead letter queue [292]](#lab---azure-service-bus-queue---dead-letter-queue-292)
    - [Lab - Azure Service Bus queue - Duplicate message detection [293]](#lab---azure-service-bus-queue---duplicate-message-detection-293)
    - [Azure Service Bus queue vs Storage queues [294]](#azure-service-bus-queue-vs-storage-queues-294)
    - [Lab - Azure Service Bus - Topics [295]](#lab---azure-service-bus---topics-295)
    - [Lab - Azure Service Bus Topics - .NET - Sending messages [296]](#lab---azure-service-bus-topics---net---sending-messages-296)
    - [Lab - Azure Service Bus Topics - .NET - Receiving messages [297]](#lab---azure-service-bus-topics---net---receiving-messages-297)
    - [Topic Filters [298]](#topic-filters-298)
    - [Lab - Azure Service Bus Topic - Boolean filters [299]](#lab---azure-service-bus-topic---boolean-filters-299)
    - [Lab - Azure Service Bus Topic - SQL filters [300]](#lab---azure-service-bus-topic---sql-filters-300)
    - [Azure Service Bus Topic - Correlation filters [301]](#azure-service-bus-topic---correlation-filters-301)
    - [Lab - Azure Service Bus Queue - Azure Functions [302]](#lab---azure-service-bus-queue---azure-functions-302)
    - [Lab - Azure Service Bus Queue - Azure Functions - Trigger data [303]](#lab---azure-service-bus-queue---azure-functions---trigger-data-303)
    - [Assignment 10: Assignment - Azure Service Bus Topic - Azure Functions [   ]](#assignment-10-assignment---azure-service-bus-topic---azure-functions----)
    - [What are Azure Event Hubs [304]](#what-are-azure-event-hubs-304)
    - [Lab - Creating an Azure Event Hub [305]](#lab---creating-an-azure-event-hub-305)
    - [Lab - .NET - Sending data to Azure Event Hub [306]](#lab---net---sending-data-to-azure-event-hub-306)
    - [Lab - .NET - Reading data to Azure Event Hub [307]](#lab---net---reading-data-to-azure-event-hub-307)
    - [So let's understand some concepts [308]](#so-lets-understand-some-concepts-308)
    - [Lab - .NET - Reading Events from a particular partition [309]](#lab---net---reading-events-from-a-particular-partition-309)
    - [Lab - .NET - Using the Event Processor class [310]](#lab---net---using-the-event-processor-class-310)
    - [Azure Event Hubs - Other concepts [311]](#azure-event-hubs---other-concepts-311)
    - [Lab - Specifying a partition key [312]](#lab---specifying-a-partition-key-312)
    - [Lab - Enabling the capture feature [313]](#lab---enabling-the-capture-feature-313)
    - [Streaming diagnostics data from an Azure SQL database [314]](#streaming-diagnostics-data-from-an-azure-sql-database-314)
    - [Comparison with Azure Service Bus [315]](#comparison-with-azure-service-bus-315)
    - [What is Azure Event Grid [316]](#what-is-azure-event-grid-316)
    - [Lab - Azure Functions - Azure Blob Storage [317]](#lab---azure-functions---azure-blob-storage-317)
    - [Lab - Azure Functions - Blob trigger [318]](#lab---azure-functions---blob-trigger-318)
    - [So which one should we use [319]](#so-which-one-should-we-use-319)
    - [Lab - Azure Functions - Processing blobs [320]](#lab---azure-functions---processing-blobs-320)
    - [Lab - Azure Functions - Copying blobs [321]](#lab---azure-functions---copying-blobs-321)
    - [Event Grid Schema [322]](#event-grid-schema-322)
    - [Debugging Azure Event Grid locally [323]](#debugging-azure-event-grid-locally-323)
    - [Getting more information about the event [324]](#getting-more-information-about-the-event-324)
    - [Getting events at the resource group level [325]](#getting-events-at-the-resource-group-level-325)
    - [Lab - Azure Storage Queue as the consumer [326]](#lab---azure-storage-queue-as-the-consumer-326)
    - [Lab - Filters - Subject begins with [327]](#lab---filters---subject-begins-with-327)
    - [Lab - Filters - Subject ends with [328]](#lab---filters---subject-ends-with-328)
    - [Connecting to an HTTP endpoint [329]](#connecting-to-an-http-endpoint-329)
    - [Lab - Custom topics [330]](#lab---custom-topics-330)
    - [Quick comparison [331]](#quick-comparison-331)
    - [What is the API Management service [332]](#what-is-the-api-management-service-332)
    - [Our Product API [333]](#our-product-api-333)
    - [Lab - Creating the Azure API Management Instance [334]](#lab---creating-the-azure-api-management-instance-334)
    - [Publishing our API [335]](#publishing-our-api-335)
    - [Calling via the POSTMAN tool [336]](#calling-via-the-postman-tool-336)
    - [Allow access only via API Management [337]](#allow-access-only-via-api-management-337)
    - [Using swagger definition [338]](#using-swagger-definition-338)
    - [API management policy - IP restriction [339]](#api-management-policy---ip-restriction-339)
    - [API management policy - expressions [340]](#api-management-policy---expressions-340)
    - [API management policy - Rewrite URL [341]](#api-management-policy---rewrite-url-341)
    - [Note on the different policy sections [342]](#note-on-the-different-policy-sections-342)
    - [API management policy - Return response [343]](#api-management-policy---return-response-343)
    - [API management policy - Cache [344]](#api-management-policy---cache-344)
    - [Quick note on caching [345]](#quick-note-on-caching-345)
    - [API management policy - OAuth - Setup [346]](#api-management-policy---oauth---setup-346)
    - [API management policy - OAuth - Implementation [347]](#api-management-policy---oauth---implementation-347)
    - [Assignment 11: Assignment – Using a subscription key [   ]](#assignment-11-assignment--using-a-subscription-key----)
    - [API management - Virtual Network [348]](#api-management---virtual-network-348)
    - [Lab - API management - Virtual Network - Setup [349]](#lab---api-management---virtual-network---setup-349)
    - [Lab - API management - Virtual Network - Implementation [350]](#lab---api-management---virtual-network---implementation-350)
    - [Quiz 10: Short Quiz](#quiz-10-short-quiz)

<!-- /TOC -->

# Section 12: Connect to and consume Azure services and third-party services
## Section Resources download [266]
## Using a messaging service [267]
## The purpose of the queue service [268]
## Lab - Azure Storage Queue [269]
## Lab - Azure Storage Queue - .NET - Sending messages [270]
## Lab - Azure Storage Queue - .NET - Peek messages [271]
## Lab - Azure Storage Queue - .NET - Receive messages [272]
## Lab - Azure Storage Queue - .NET - Get queue length [273]
## Lab - Sending and Receiving objects [274]
## Lab - Azure Storage Queue - Azure Functions [275]
## Lab - Sending Messages in base64 encoded [276]
   ## Assignment 8: Assignment - Peek messages in base64 encoded [   ]
## Lab - Other trigger input type [277]
## Lab - Output to Table storage [278]
## Another way of writing the code to output to table storage [279]
## Azure Queue trigger - Important Note [280]
## What is Azure Service Bus [281]
## Lab - Creating an Azure Service Bus Queue [282]
## Lab - Working with the Azure Service Bus Queue [283]
## Lab - Azure Service Bus queue - .NET - Sending messages [284]
## Lab - Azure Service Bus queue - .NET - Peek messages [285]
   ## Assignment 9: Assignment - Azure Service Bus queue - .NET - Receive messages [   ]
## Lab - Azure Service Bus queue - Message properties [286]
## Lab - Azure Service Bus queue - Application properties [287]
## Azure Service Bus queue - Message processor [288]
## Azure Service Bus queue - Message lock duration [289]
## Lab - Azure Service Bus queue - Message lock duration [290]
## Lab - Azure Service Bus queue - Time to live [291]
## Lab - Azure Service Bus queue - Dead letter queue [292]
## Lab - Azure Service Bus queue - Duplicate message detection [293]
## Azure Service Bus queue vs Storage queues [294]
## Lab - Azure Service Bus - Topics [295]
## Lab - Azure Service Bus Topics - .NET - Sending messages [296]
## Lab - Azure Service Bus Topics - .NET - Receiving messages [297]
## Topic Filters [298]
## Lab - Azure Service Bus Topic - Boolean filters [299]
## Lab - Azure Service Bus Topic - SQL filters [300]
## Azure Service Bus Topic - Correlation filters [301]
## Lab - Azure Service Bus Queue - Azure Functions [302]
## Lab - Azure Service Bus Queue - Azure Functions - Trigger data [303]
   ## Assignment 10: Assignment - Azure Service Bus Topic - Azure Functions [   ]
## What are Azure Event Hubs [304]
## Lab - Creating an Azure Event Hub [305]
## Lab - .NET - Sending data to Azure Event Hub [306]
## Lab - .NET - Reading data to Azure Event Hub [307]
## So let's understand some concepts [308]
## Lab - .NET - Reading Events from a particular partition [309]
## Lab - .NET - Using the Event Processor class [310]
## Azure Event Hubs - Other concepts [311]
## Lab - Specifying a partition key [312]
## Lab - Enabling the capture feature [313]
## Streaming diagnostics data from an Azure SQL database [314]
## Comparison with Azure Service Bus [315]
## What is Azure Event Grid [316]
## Lab - Azure Functions - Azure Blob Storage [317]
## Lab - Azure Functions - Blob trigger [318]
## So which one should we use [319]
## Lab - Azure Functions - Processing blobs [320]
## Lab - Azure Functions - Copying blobs [321]
## Event Grid Schema [322]
## Debugging Azure Event Grid locally [323]
## Getting more information about the event [324]
## Getting events at the resource group level [325]
## Lab - Azure Storage Queue as the consumer [326]
## Lab - Filters - Subject begins with [327]
## Lab - Filters - Subject ends with [328]
## Connecting to an HTTP endpoint [329]
## Lab - Custom topics [330]
## Quick comparison [331]
## What is the API Management service [332]
## Our Product API [333]
## Lab - Creating the Azure API Management Instance [334]
## Publishing our API [335]
## Calling via the POSTMAN tool [336]
## Allow access only via API Management [337]
## Using swagger definition [338]
## API management policy - IP restriction [339]
## API management policy - expressions [340]
## API management policy - Rewrite URL [341]
## Note on the different policy sections [342]
## API management policy - Return response [343]
## API management policy - Cache [344]
## Quick note on caching [345]
## API management policy - OAuth - Setup [346]
## API management policy - OAuth - Implementation [347]
   ## Assignment 11: Assignment – Using a subscription key [   ]
## API management - Virtual Network [348]
## Lab - API management - Virtual Network - Setup [349]
## Lab - API management - Virtual Network - Implementation [350]
## Quiz 10: Short Quiz
