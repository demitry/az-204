# Create app function from command line

<https://learn.microsoft.com/en-us/azure/azure-functions/scripts/functions-cli-create-serverless>
```bash
# Function app and storage account names must be unique.

# Variable block
let "randomIdentifier=$RANDOM*$RANDOM"
location="eastus"
resourceGroup="msdocs-azure-functions-rg-$randomIdentifier"
tag="create-function-app-consumption"
storage="msdocsaccount$randomIdentifier"
functionApp="msdocs-serverless-function-$randomIdentifier"
skuStorage="Standard_LRS"
functionsVersion="4"

# Create a resource group
echo "Creating $resourceGroup in "$location"..."
az group create --name $resourceGroup --location "$location" --tags $tag

# Create an Azure storage account in the resource group.
echo "Creating $storage"
az storage account create --name $storage --location "$location" --resource-group $resourceGroup --sku $skuStorage

# Create a serverless function app in the resource group.
echo "Creating $functionApp"
az functionapp create --name $functionApp --storage-account $storage --consumption-plan-location "$location" --resource-group $resourceGroup --functions-version $functionsVersion
```

```
Run ./Script2.sh
Creating msdocs-azure-functions-rg-279706930 in eastus...
{
  "id": "/subscriptions/a77b1bf0-3869-4d3f-9d30-42037952d048/resourceGroups/msdocs-azure-functions-rg-279706930",
  "location": "eastus",
  "managedBy": null,
  "name": "msdocs-azure-functions-rg-279706930",
  "properties": {
    "provisioningState": "Succeeded"
  },
  "tags": {
    "create-function-app-consumption": ""
  },
  "type": "Microsoft.Resources/resourceGroups"
}
Creating msdocsaccount279706930
The public access to all blobs or containers in the storage account will be disallowed by default in the future, which means default value for --allow-blob-public-access is still null bu
t will be equivalent to false.
{
  "accessTier": "Hot",
  "allowBlobPublicAccess": true,
  "allowCrossTenantReplication": null,
  "allowSharedKeyAccess": null,
  "allowedCopyScope": null,
  "azureFilesIdentityBasedAuthentication": null,
  "blobRestoreStatus": null,
  "creationTime": "2023-04-26T08:35:33.984494+00:00",
  "customDomain": null,
  "defaultToOAuthAuthentication": null,
  "dnsEndpointType": null,
  "enableHttpsTrafficOnly": true,
  "enableNfsV3": null,
  "encryption": {
    "encryptionIdentity": null,
    "keySource": "Microsoft.Storage",
    "keyVaultProperties": null,
    "requireInfrastructureEncryption": null,
    "services": {
      "blob": {
        "enabled": true,
        "keyType": "Account",
        "lastEnabledTime": "2023-04-26T08:35:34.140745+00:00"
      },
      "file": {
        "enabled": true,
        "keyType": "Account",
        "lastEnabledTime": "2023-04-26T08:35:34.140745+00:00"
      },
      "queue": null,
      "table": null
    }
  },
  "extendedLocation": null,
  "failoverInProgress": null,
  "geoReplicationStats": null,
  "id": "/subscriptions/a77b1bf0-3869-4d3f-9d30-42037952d048/resourceGroups/msdocs-azure-functions-rg-279706930/providers/Microsoft.Storage/storageAccounts/msdocsaccount279706930",
  "identity": null,
  "immutableStorageWithVersioning": null,
  "isHnsEnabled": null,
  "isLocalUserEnabled": null,
  "isSftpEnabled": null,
  "keyCreationTime": {
    "key1": "2023-04-26T08:35:34.125120+00:00",
    "key2": "2023-04-26T08:35:34.125120+00:00"
  },
  "keyPolicy": null,
  "kind": "StorageV2",
  "largeFileSharesState": null,
  "lastGeoFailoverTime": null,
  "location": "eastus",
  "minimumTlsVersion": "TLS1_0",
  "name": "msdocsaccount279706930",
  "networkRuleSet": {
    "bypass": "AzureServices",
    "defaultAction": "Allow",
    "ipRules": [],
    "resourceAccessRules": null,
    "virtualNetworkRules": []
  },
  "primaryEndpoints": {
    "blob": "https://msdocsaccount279706930.blob.core.windows.net/",
    "dfs": "https://msdocsaccount279706930.dfs.core.windows.net/",
    "file": "https://msdocsaccount279706930.file.core.windows.net/",
    "internetEndpoints": null,
    "microsoftEndpoints": null,
    "queue": "https://msdocsaccount279706930.queue.core.windows.net/",
    "table": "https://msdocsaccount279706930.table.core.windows.net/",
    "web": "https://msdocsaccount279706930.z13.web.core.windows.net/"
  },
  "primaryLocation": "eastus",
  "privateEndpointConnections": [],
  "provisioningState": "Succeeded",
  "publicNetworkAccess": null,
  "resourceGroup": "msdocs-azure-functions-rg-279706930",
  "routingPreference": null,
  "sasPolicy": null,
  "secondaryEndpoints": null,
  "secondaryLocation": null,
  "sku": {
    "name": "Standard_LRS",
    "tier": "Standard"
  },
  "statusOfPrimary": "available",
  "statusOfSecondary": null,
  "storageAccountSkuConversionStatus": null,
  "tags": {},
  "type": "Microsoft.Storage/storageAccounts"
}
Creating msdocs-serverless-function-279706930
Application Insights "msdocs-serverless-function-279706930" was created for this Function App. You can visit https://portal.azure.com/#resource/subscriptions/a77b1bf0-3869-4d3f-9d30-4203
7952d048/resourceGroups/msdocs-azure-functions-rg-279706930/providers/microsoft.insights/components/msdocs-serverless-function-279706930/overview to view your Application Insights compon
ent
{
  "availabilityState": "Normal",
  "clientAffinityEnabled": false,
  "clientCertEnabled": false,
  "clientCertExclusionPaths": null,
  "clientCertMode": "Required",
  "cloningInfo": null,
  "containerSize": 1536,
  "customDomainVerificationId": "6E8C5799957DE516385E5347C2409277A201796191A179CF96B530624AE7F292",
  "dailyMemoryTimeQuota": 0,
  "defaultHostName": "msdocs-serverless-function-279706930.azurewebsites.net",
  "enabled": true,
  "enabledHostNames": [
    "msdocs-serverless-function-279706930.azurewebsites.net",
    "msdocs-serverless-function-279706930.scm.azurewebsites.net"
  ],
  "extendedLocation": null,
  "hostNameSslStates": [
    {
      "certificateResourceId": null,
      "hostType": "Standard",
      "ipBasedSslResult": null,
      "ipBasedSslState": "NotConfigured",
      "name": "msdocs-serverless-function-279706930.azurewebsites.net",
      "sslState": "Disabled",
      "thumbprint": null,
      "toUpdate": null,
      "toUpdateIpBasedSsl": null,
      "virtualIp": null
    },
    {
      "certificateResourceId": null,
      "hostType": "Repository",
      "ipBasedSslResult": null,
      "ipBasedSslState": "NotConfigured",
      "name": "msdocs-serverless-function-279706930.scm.azurewebsites.net",
      "sslState": "Disabled",
      "thumbprint": null,
      "toUpdate": null,
      "toUpdateIpBasedSsl": null,
      "virtualIp": null
    }
  ],
  "hostNames": [
    "msdocs-serverless-function-279706930.azurewebsites.net"
  ],
  "hostNamesDisabled": false,
  "hostingEnvironmentProfile": null,
  "httpsOnly": false,
  "hyperV": false,
  "id": "/subscriptions/a77b1bf0-3869-4d3f-9d30-42037952d048/resourceGroups/msdocs-azure-functions-rg-279706930/providers/Microsoft.Web/sites/msdocs-serverless-function-279706930",
  "identity": null,
  "inProgressOperationId": null,
  "isDefaultContainer": null,
  "isXenon": false,
  "keyVaultReferenceIdentity": "SystemAssigned",
  "kind": "functionapp",
  "lastModifiedTimeUtc": "2023-04-26T08:36:21.346666",
  "location": "eastus",
  "maxNumberOfWorkers": null,
  "name": "msdocs-serverless-function-279706930",
  "outboundIpAddresses": "52.152.200.89,52.149.189.39,52.186.36.97,52.188.180.20,52.188.91.218,52.188.91.246,20.49.104.32",
  "possibleOutboundIpAddresses": "52.152.200.89,52.149.189.39,52.186.36.97,52.188.180.20,52.188.91.218,52.188.91.246,52.188.92.114,52.188.92.122,52.188.92.141,52.152.201.79,52.188.92.250
,52.188.93.14,52.188.93.126,52.188.93.147,52.186.38.103,52.186.38.19,40.88.18.164,52.152.202.231,52.188.93.170,52.188.93.205,52.188.93.214,52.188.93.219,52.188.93.235,52.188.176.242,52.1
88.93.239,52.188.93.245,52.188.94.57,52.188.94.132,52.188.94.145,52.186.36.229,20.49.104.32",
  "publicNetworkAccess": null,
  "redundancyMode": "None",
  "repositorySiteName": "msdocs-serverless-function-279706930",
  "reserved": false,
  "resourceGroup": "msdocs-azure-functions-rg-279706930",
  "scmSiteAlsoStopped": false,
  "serverFarmId": "/subscriptions/a77b1bf0-3869-4d3f-9d30-42037952d048/resourceGroups/msdocs-azure-functions-rg-279706930/providers/Microsoft.Web/serverfarms/EastUSPlan",
  "siteConfig": {
    "acrUseManagedIdentityCreds": false,
    "acrUserManagedIdentityId": null,
    "alwaysOn": false,
    "antivirusScanEnabled": null,
    "apiDefinition": null,
    "apiManagementConfig": null,
    "appCommandLine": null,
    "appSettings": null,
    "autoHealEnabled": null,
    "autoHealRules": null,
    "autoSwapSlotName": null,
    "azureMonitorLogCategories": null,
    "azureStorageAccounts": null,
    "connectionStrings": null,
    "cors": null,
    "customAppPoolIdentityAdminState": null,
    "customAppPoolIdentityTenantState": null,
    "defaultDocuments": null,
    "detailedErrorLoggingEnabled": null,
    "documentRoot": null,
    "elasticWebAppScaleLimit": null,
    "experiments": null,
    "fileChangeAuditEnabled": null,
    "ftpsState": null,
    "functionAppScaleLimit": 0,
    "functionsRuntimeScaleMonitoringEnabled": null,
    "handlerMappings": null,
    "healthCheckPath": null,
    "http20Enabled": false,
    "http20ProxyFlag": null,
    "httpLoggingEnabled": null,
    "ipSecurityRestrictions": [
      {
        "action": "Allow",
        "description": "Allow all access",
        "headers": null,
        "ipAddress": "Any",
        "name": "Allow all",
        "priority": 2147483647,
        "subnetMask": null,
        "subnetTrafficTag": null,
        "tag": null,
        "vnetSubnetResourceId": null,
        "vnetTrafficTag": null
      }
    ],
    "ipSecurityRestrictionsDefaultAction": null,
    "javaContainer": null,
    "javaContainerVersion": null,
    "javaVersion": null,
    "keyVaultReferenceIdentity": null,
    "limits": null,
    "linuxFxVersion": "",
    "loadBalancing": null,
    "localMySqlEnabled": null,
    "logsDirectorySizeLimit": null,
    "machineKey": null,
    "managedPipelineMode": null,
    "managedServiceIdentityId": null,
    "metadata": null,
    "minTlsCipherSuite": null,
    "minTlsVersion": null,
    "minimumElasticInstanceCount": 0,
    "netFrameworkVersion": null,
    "nodeVersion": null,
    "numberOfWorkers": 1,
    "phpVersion": null,
    "powerShellVersion": null,
    "preWarmedInstanceCount": null,
    "publicNetworkAccess": null,
    "publishingPassword": null,
    "publishingUsername": null,
    "push": null,
    "pythonVersion": null,
    "remoteDebuggingEnabled": null,
    "remoteDebuggingVersion": null,
    "requestTracingEnabled": null,
    "requestTracingExpirationTime": null,
    "routingRules": null,
    "runtimeADUser": null,
    "runtimeADUserPassword": null,
    "scmIpSecurityRestrictions": [
      {
        "action": "Allow",
        "description": "Allow all access",
        "headers": null,
        "ipAddress": "Any",
        "name": "Allow all",
        "priority": 2147483647,
        "subnetMask": null,
        "subnetTrafficTag": null,
        "tag": null,
        "vnetSubnetResourceId": null,
        "vnetTrafficTag": null
      }
    ],
    "scmIpSecurityRestrictionsDefaultAction": null,
    "scmIpSecurityRestrictionsUseMain": null,
    "scmMinTlsVersion": null,
    "scmType": null,
    "sitePort": null,
    "storageType": null,
    "supportedTlsCipherSuites": null,
    "tracingOptions": null,
    "use32BitWorkerProcess": null,
    "virtualApplications": null,
    "vnetName": null,
    "vnetPrivatePortsCount": null,
    "vnetRouteAllEnabled": null,
    "webSocketsEnabled": null,
    "websiteTimeZone": null,
    "winAuthAdminState": null,
    "winAuthTenantState": null,
    "windowsConfiguredStacks": null,
    "windowsFxVersion": null,
    "xManagedServiceIdentityId": null
  },
  "slotSwapStatus": null,
  "state": "Running",
  "storageAccountRequired": false,
  "suspendedTill": null,
  "tags": null,
  "targetSwapSlot": null,
  "trafficManagerHostNames": null,
  "type": "Microsoft.Web/sites",
  "usageState": "Normal",
  "virtualNetworkSubnetId": null,
  "vnetContentShareEnabled": false,
  "vnetImagePullEnabled": false,
  "vnetRouteAllEnabled": false
}
```