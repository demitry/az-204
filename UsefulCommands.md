# Useful commands

az group list | Select-String "name"

List registered AzResourceProviders

Get-AzResourceProvider -ListAvailable | Where-Object RegistrationState -eq "Registered" | Select-Object ProviderNamespace, RegistrationState | Sort-Object ProviderNamespace

Check if Microsoft.OperationsManagement AzResourceProvider is registered

Get-AzResourceProvider -ListAvailable | Where-Object RegistrationState -eq "Registered" | Select-Object ProviderNamespace, RegistrationState | Sort-Object ProviderNamespace | Select-String "OperationsManagement"

Register-AzureRmResourceProvider -ProviderNamespace Microsoft.OperationsManagement