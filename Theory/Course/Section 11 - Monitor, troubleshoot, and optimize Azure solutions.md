<!-- TOC -->

- [Section 11: Monitor, troubleshoot, and optimize Azure solutions](#section-11-monitor-troubleshoot-and-optimize-azure-solutions)
    - [Section Resources download [230]](#section-resources-download-230)
    - [What are we going to cover [231]](#what-are-we-going-to-cover-231)
    - [Quick look at the Azure Monitor service [232]](#quick-look-at-the-azure-monitor-service-232)
    - [Azure Monitor - Setting up alerts [233]](#azure-monitor---setting-up-alerts-233)
    - [Azure Monitor - Dynamic thresholds [234]](#azure-monitor---dynamic-thresholds-234)
    - [What is a Log Analytics Workspace [235]](#what-is-a-log-analytics-workspace-235)
    - [Lab - Log Analytics workspace [236]](#lab---log-analytics-workspace-236)
    - [Azure Web App - Diagnostic [237]](#azure-web-app---diagnostic-237)
    - [Lab - ARM Templates - Action Groups [238]](#lab---arm-templates---action-groups-238)
    - [Lab - ARM Templates - Azure Monitor Metrics [239]](#lab---arm-templates---azure-monitor-metrics-239)
    - [Lab - ARM Templates - Dynamic Metric alerts [240]](#lab---arm-templates---dynamic-metric-alerts-240)
    - [Lab - Log Analytics Query Alert - PowerShell [241]](#lab---log-analytics-query-alert---powershell-241)
    - [What is Application Insights [242]](#what-is-application-insights-242)
    - [Application Insights - Configure the SDK locally [243]](#application-insights---configure-the-sdk-locally-243)
    - [Lab - Azure Application Insights [244]](#lab---azure-application-insights-244)
    - [Lab - Application Insights - Performance data [245]](#lab---application-insights---performance-data-245)
    - [Application Insights - Usage Features [246]](#application-insights---usage-features-246)
    - [Application Insights - Availability Tests [247]](#application-insights---availability-tests-247)
    - [Application Insights - Tracking Users [248]](#application-insights---tracking-users-248)
    - [Optimizing Content Delivery [249]](#optimizing-content-delivery-249)
    - [What is Azure Cache for Redis [250]](#what-is-azure-cache-for-redis-250)
    - [Lab - Creating the Cache [251]](#lab---creating-the-cache-251)
    - [Lab - Azure Redis Data types [252]](#lab---azure-redis-data-types-252)
    - [Lab - Azure Cache for Redis - .NET [253]](#lab---azure-cache-for-redis---net-253)
    - [Lab - Azure Cache for Redis - Classes [254]](#lab---azure-cache-for-redis---classes-254)
    - [Assignment 7: Assignment - .NET Classes - Get Cache data [   ]](#assignment-7-assignment---net-classes---get-cache-data----)
    - [Note on Redis data types [255]](#note-on-redis-data-types-255)
    - [Redis Cache key eviction [256]](#redis-cache-key-eviction-256)
    - [Lab - Invalidate Cache keys [257]](#lab---invalidate-cache-keys-257)
    - [ASP.NET Example - Azure Cache for Redis [258]](#aspnet-example---azure-cache-for-redis-258)
    - [What is Azure Content Delivery Network [259]](#what-is-azure-content-delivery-network-259)
    - [Lab - Azure Content Delivery Network [260]](#lab---azure-content-delivery-network-260)
    - [Azure Content Delivery Network Caching [261]](#azure-content-delivery-network-caching-261)
    - [What is Azure Front Door [262]](#what-is-azure-front-door-262)
    - [Lab - Azure Front Door - Setup [263]](#lab---azure-front-door---setup-263)
    - [Lab - Azure Front Door - Implementation [264]](#lab---azure-front-door---implementation-264)
    - [Azure Front Door - Other aspects [265]](#azure-front-door---other-aspects-265)
    - [Quiz 9: Short Quiz](#quiz-9-short-quiz)

<!-- /TOC -->

# Section 11: Monitor, troubleshoot, and optimize Azure solutions
## Section Resources download [230]
## What are we going to cover [231]

## Quick look at the Azure Monitor service [232]

webapp10001 | Metrics

Monitor | Metrics

Monitor | Activity log

- Logs any Azure administrative activity, check JSON

## Azure Monitor - Setting up alerts [233]

Create an alert rule

- Scope
- Add Condition - Select a signal
- Activity Log - based on an operation on VM (Power Off, ... )
- => trigger alert
- Metrics - (CPU percentage, memory percentage, network...)
- Threshold: Static, Dynamic
- Aggregation granularity: 5 min
- Frequency of evaluation
- Actions, Action Group - what needs to be done
- Create an action Group, Notification type
- Trigger
  - Automation Runbook (Powershell Script)
  - Azure Function
  - Event Hub
  - ITSM
  - Logic App
  - Secure Webhook
  - Webhook
- Severity
  - 4 - Verbose
  - 3 - Informational
  - 2 - Warning
  - 1 - Error
  - 0 - Critical
- Alert Rule Name
- 0.10 USD/month - Metric Alert Rule - cost per month
- Create

## Azure Monitor - Dynamic thresholds [234]
## What is a Log Analytics Workspace [235]
## Lab - Log Analytics workspace [236]
## Azure Web App - Diagnostic [237]
## Lab - ARM Templates - Action Groups [238]
## Lab - ARM Templates - Azure Monitor Metrics [239]
## Lab - ARM Templates - Dynamic Metric alerts [240]
## Lab - Log Analytics Query Alert - PowerShell [241]
## What is Application Insights [242]
## Application Insights - Configure the SDK locally [243]
## Lab - Azure Application Insights [244]
## Lab - Application Insights - Performance data [245]
## Application Insights - Usage Features [246]
## Application Insights - Availability Tests [247]
## Application Insights - Tracking Users [248]
## Optimizing Content Delivery [249]
## What is Azure Cache for Redis [250]
## Lab - Creating the Cache [251]
## Lab - Azure Redis Data types [252]
## Lab - Azure Cache for Redis - .NET [253]
## Lab - Azure Cache for Redis - Classes [254]
   ## Assignment 7: Assignment - .NET Classes - Get Cache data [   ]
## Note on Redis data types [255]
## Redis Cache key eviction [256]
## Lab - Invalidate Cache keys [257]
## ASP.NET Example - Azure Cache for Redis [258]
## What is Azure Content Delivery Network [259]
## Lab - Azure Content Delivery Network [260]
## Azure Content Delivery Network Caching [261]
## What is Azure Front Door [262]
## Lab - Azure Front Door - Setup [263]
## Lab - Azure Front Door - Implementation [264]
## Azure Front Door - Other aspects [265]
## Quiz 9: Short Quiz