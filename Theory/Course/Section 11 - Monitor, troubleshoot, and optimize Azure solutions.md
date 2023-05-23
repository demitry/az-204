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
        - [My Comment](#my-comment)
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

Dynamic Threshold

Azure Monitor uses machine learning to check the historical behavior of metrics.

Metric is always 40 percent. But now it is 80 percent - deviating from normal.

Based on historical data.

Define sensitivity:

  - High - alert triggered for the smallest deviation.
  - Medium - more balanced thresholds
  - Low - alert only triggered on large deviation

Configure signal logic - Alert Logic - Dynamic (not static)

Threshold sensitivity: Medium

## What is a Log Analytics Workspace [235]

Log Data -> Log Analytics Workspace

Custom Query Language

Visualization and Dashboards

## Lab - Log Analytics workspace [236]

Create Log Analytics workspace and connect multiple machines log to this centralized log workspace

Deprecated:
LogWorkspace | Service map (deprecated
LogWorkspace | Virtual machines (deprecated)

linuxvm - Connect

linuxvm | Extensions and Applications - installs agent

Installs Microsoft Monitoring Agent

Which data should be collected?

LogWorkspace | Agents Configuration

- Windows event logs (application events log etc.)
- Windows performance counters
- Linux performance counters
- Syslog
- IIS Logs
- Your own custom logs

LogWorkspace | Logs - LogManagement -  check tables
- Heartbeat
- Event
- Syslog

type the name of the table - Run

Event - Run

to check log records

## Azure Web App - Diagnostic [237]

webapp10001 | Diagnostic settings

Click 'Add Diagnostic setting' above to configure the collection of the following data:

- HTTP logs
- App Service Console Logs
- App Service Application Logs
- Access Audit Logs
- IPSecurity Audit logs
- App Service Platform logs
- AllMetrics

Add diagnostic setting
- [x] HTTP logs
- [x] App Service Console Logs
- [x] App Service Application Logs
- [x] Access Audit Logs
- [x] IPSecurity Audit logs
- [x] App Service Platform logs

Destination details
- [x] Send to Log Analytics workspace
  - Select LogWorkspace

- [] Archive to a storage account
- [] Stream to an event hub
- [] Send to partner solution

Save

LogWorkspace | Logs - LogManagement

- AppServiceAppLogs
- AppServiceConsoleLogs
- AppServiceHTTPLogs


## Lab - ARM Templates - Action Groups [238]

**Bicep** language support for Visual Studio Code and Visual Studio

Create resource from custom template

```json
{
  "$schema": "https://schema.management.azure.com/schemas/2019-04-01/deploymentTemplate.json#",
  "contentVersion": "1.0.0.0",
  "parameters": {},
  "functions": [],
  "variables": {},
  "resources": [
    {
      "type": "Microsoft.Insights/actionGroups",
      "apiVersion": "2021-09-01",
      "name": "AlertGroupB",
      "location": "Global",
      "properties": {
        "groupShortName": "AlertGroupB",
        "enabled": true,
        "emailReceivers": [
          {
            "name": "AdminEmail",
            "emailAddress": "dpoluektov@gmail.com",
            "useCommonAlertSchema": true
          }
        ]
      }
    }
  ],
  "outputs": {}
}
```

## Lab - ARM Templates - Azure Monitor Metrics [239]

```json
{
    "$schema": "https://schema.management.azure.com/schemas/2019-04-01/deploymentTemplate.json#",
    "contentVersion": "1.0.0.0",
    "parameters": {},
    "functions": [],
    "variables": {},
    "resources": [
        {
            "name": "CPUAlert",
            "type": "Microsoft.Insights/metricAlerts",
            "location": "global",
            "apiVersion": "2018-03-01",
            "properties": {
                "description": "Alert for when the VM CPU Percentage goes beyond 70%",
                "severity": 2,
                "enabled": true,
                "scopes": [
                    "[resourceId('Microsoft.Compute/virtualMachines', 'appvm')]"
                ],
                "evaluationFrequency": "PT5M",
                "windowSize": "PT5M",
                "criteria": {
                    "odata.type": "Microsoft.Azure.Monitor.SingleResourceMultipleMetricCriteria",
                    "allOf": [
                        {
                            "name": "1st criterion",
                            "metricName": "Percentage CPU",
                            "dimensions": [],
                            "operator": "GreaterThanOrEqual",
                            "threshold": 70,
                            "timeAggregation": "Average"
                        }
                    ]
                },
                "actions": [
                    {
                        "actionGroupId": "[resourceId('Microsoft.Insights/ActionGroups', 'AlertGroupB')]"
                    }
                ]
            }
        }
    ],
    "outputs": {}
}
```

Home - Monitor - Alert Rules

## Lab - ARM Templates - Dynamic Metric alerts [240]

```
NOTE:
"criteria": {
"odata.type": "Microsoft.Azure.Monitor.MultipleResourceMultipleMetricCriteria",

... "criterionType": "DynamicThresholdCriterion"
```

```json
{
    "$schema": "https://schema.management.azure.com/schemas/2019-04-01/deploymentTemplate.json#",
    "contentVersion": "1.0.0.0",
    "parameters": {},
    "functions": [],
    "variables": {},
    "resources": [
        {
            "name": "DynamicCPUAlert",
            "type": "Microsoft.Insights/metricAlerts",
            "location": "global",
            "apiVersion": "2018-03-01",
            "properties": {
                "description": "Dynamic Alert for an Azure VM",
                "severity": 2,
                "enabled": true,
                "scopes": [
                    "[resourceId('Microsoft.Compute/virtualMachines', 'appvm')]"
                ],
                "evaluationFrequency": "PT5M",
                "windowSize": "PT5M",
                "criteria": {
                    "odata.type": "Microsoft.Azure.Monitor.MultipleResourceMultipleMetricCriteria",
                    "allOf": [
                        {
                            "criterionType": "DynamicThresholdCriterion",
                            "name": "1st criterion",
                            "metricName": "Percentage CPU",
                            "dimensions": [],
                            "operator": "GreaterThan",
                            "timeAggregation": "Average",
                            "alertSensitivity": "Medium",
                            "failingPeriods": {
                                "numberOfEvaluationPeriods": "4",
                                "minFailingPeriodsToAlert": "3"
                            }
                        }
                    ]
                },
                "actions": [
                    {
                        "actionGroupId": "[resourceId('Microsoft.Insights/ActionGroups', 'AlertGroupB')]"
                    }
                ]
            }
        }
    ],
    "outputs": {}
}
```

## Lab - Log Analytics Query Alert - PowerShell [241]

LogWorkspace | Properties
Resource ID
/subscriptions/a77b1bf0-3869-4d3f-9d30-42037952d048/resourceGroups/app-grp/providers/Microsoft.OperationalInsights/workspaces/LogWorkspace
P:
New-AzScheduledQueryRuleSource' is not recognized as a name of a cmdlet
S:
Install-Module -Name Az -AllowClobber
Install-Module -Name Az -Scope CurrentUser -Repository PSGallery -Force

### My Comment

Error message:
"The term 'New-AzScheduledQueryRuleSource' is not recognized as a name of a cmdlet, function, script file, or executable program."
```
Note, there is a difference between versions of Az Powershell v. 8.3.0 and v. 9.7.1
A lot of commands are removed in v. 9.7.1
(New-AzScheduledQueryRuleSchedule, New-AzScheduledQueryRuleSource, New-AzScheduledQueryRuleTriggerCondition etc. were removed)
Also the New-AzScheduledQueryRule command is run with a completely different set of parameters:
```
<https://learn.microsoft.com/en-us/powershell/module/az.monitor/new-azscheduledqueryrule?view=azps-8.3.0>
<https://learn.microsoft.com/en-us/powershell/module/az.monitor/new-azscheduledqueryrule?view=azps-9.7.1>

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