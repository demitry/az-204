Connect-AzAccount

New-AzResourceGroupDeployment -ResourceGroupName app-grp -TemplateFile StorageAccountForAppGrp.json