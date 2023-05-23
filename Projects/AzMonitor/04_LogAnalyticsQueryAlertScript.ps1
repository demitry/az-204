# Heartbeat | where TimeGenerated > ago(30m)

Import-Module Az
Import-Module Az.Monitor
# Get-Command -Name New-AzScheduledQueryRuleSource
# Get-Command

Connect-AzAccount

$LogQuery="Heartbeat | where TimeGenerated > ago(30m)"

# LogWorkspace | Properties
# Resource ID
$DataSourceId="/subscriptions/a77b1bf0-3869-4d3f-9d30-42037952d048/resourceGroups/app-grp/providers/Microsoft.OperationalInsights/workspaces/LogWorkspace"

$RuleSource = New-AzScheduledQueryRuleSource -Query $LogQuery `
                  -DataSourceId $DataSourceId `
				  -QueryType "ResultCount"

$RuleSchedule=New-AzScheduledQueryRuleSchedule -FrequencyInMinutes 5 -TimeWindowInMinutes 5

$TriggerCondition=New-AzScheduledQueryRuleTriggerCondition -ThresholdOperator "GreaterThan" -Threshold 3

# Monitor | Alerts
# Action groups
$ActionGroupId="/subscriptions/a77b1bf0-3869-4d3f-9d30-42037952d048/resourcegroups/app-grp/providers/Microsoft.Insights/actiongroups/AlertGroupB"
$ActionGroup=New-AzScheduledQueryRuleAznsActionGroup -ActionGroup `
@($ActionGroupId) -EmailSubject "Log Alert"

$AlertAction = New-AzScheduledQueryRuleAlertingAction -AznsAction $ActionGroup -Severity "1" `
-Trigger $TriggerCondition

$ResourceGroupName="app-grp"
New-AzScheduledQueryRule -ResourceGroupName $ResourceGroupName -Location "North Europe" `
-Action $AlertAction -Enable $true -Description "This is an alert based on Log Analytics" `
-Schedule $RuleSchedule -Source $RuleSource -Name "Log Analytics alert"