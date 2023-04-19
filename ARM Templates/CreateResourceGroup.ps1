$ResourceGroupName="app-grp"
$Location="North Europe"
# Import-Module Az.Resources
Connect-AzAccount
New-AzResourceGroup -Name $ResourceGroupName -Location $Location