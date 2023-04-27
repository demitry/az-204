# QnA

Q: What is the NetworkWatcherRG?

A: Network Watcher resources are located in the hidden NetworkWatcherRG resource group which is created automatically. For example, the NSG Flow Logs resource is a child resource of Network Watcher and is enabled in the NetworkWatcherRG.

The Network Watcher resource represents the backend service for Network Watcher and is fully managed by Azure. Customers do no need to manage it. Operations like move are not supported on the resource. However, the resource can be deleted.

