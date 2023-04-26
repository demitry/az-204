Try to create leases manualy:

Error while creating container leases:
 Message: {"code":"BadRequest","message":"Message: {\"Errors\":[\"Your account is currently configured with a total throughput limit of 1000 RU\\/s. This operation failed because it would have increased the total throughput to 1200 RU\\/s. See https:\\/\\/aka.ms\\/cosmos-tp-limit for more information.\"]}\r\nActivityId: ae97ab06-107b-42c9-9360-e6fd7ceb3a73, Request URI: /apps/ca37ce2b-748a-4c23-9a52-1fb6f40781e8/services/2234be7f-77ba-4030-9609-ad90ae946922/partitions/cd2b6e88-197b-4103-8327-45a4fb491349/replicas/133253676050126400p, RequestStats: , SDK: Microsoft.Azure.Documents.Common/2.14.0"}, Request URI: /dbs/appdb/colls, RequestStats: , SDK: Microsoft.Azure.Documents.Common/2.14.0, Microsoft.Azure.Documents.Common/2.14.0, Microsoft.Azure.Documents.Common/2.14.0, Microsoft.Azure.Documents.Common/2.14.0, Microsoft.Azure.Documents.Common/2.14.0, Microsoft.Azure.Documents.Common/2.14.0, Microsoft.Azure.Documents.Common/2.14.0, Microsoft.Azure.Documents.Common/2.14.0, Microsoft.Azure.Documents.Common/2.14.0
ActivityId: f6664ef8-0c9e-4310-bcfe-ffd04ec108c5, Microsoft.Azure.Documents.Common/2.14.0


Azure Cosmos DB free tier is different from the Azure free account. The Azure free account offers Azure credits and resources for free for a limited time. When using Azure Cosmos DB as a part of this free account, you get 25-GB storage and 400 RU/s of provisioned throughput for 12 months.

Best practices to keep your account free
To keep your account free of charge, your account shouldn't have any more RU/s or storage consumption other than the one offered by the Azure Cosmos DB free tier.

For example, the following are some options that don’t result in any monthly charge:

One database with a max of 1000 RU/s provisioned throughput.
Two containers one with a max of 400 RU/s and other with a max of 600 RU/s provisioned throughput.
Account with two regions with a single region that has one container with a max of 500 RU/s provisioned throughput.

<https://learn.microsoft.com/en-us/azure/cosmos-db/free-tier>


I created both Azure Cosmos db and Azure Function with Cosmos trigger, but not working and leases container also not created. Please help me to resolve this.

2 replies
KL
Kenneth
1 upvote
8 months ago
This is happening to me as well

DP
Dmytro
0 upvotes
1 minute ago
I got the same issue, and I found the root cause - the leases container was not created, I tried to create it manually and got an error "Bad request, ... "Your account is currently configured with a total throughput limit of 1000 RU. This operation failed because it would have increased the total throughput to 1200 RU", so I deleted the Customers container to reduce RU, restarted the function, and the leases container was created automatically. https://learn.microsoft.com/en-us/azure/cosmos-db/free-tier
