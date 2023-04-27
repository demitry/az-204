# AZ-204: Developing Solutions for Microsoft Azure - NEW (Udemy, Alan Rodrigues)

## Section 2: Develop Azure compute solutions - Azure Virtual Machines

### 13. Building a simple project locally

### 14. What goes into the deployment of a virtual machine

1) Any resource - part of Azure Subscription. Subscription is used for billing purposes.

2) Resource - part of resource group. resource group is used for logical grouping of resources.

3) VM requires OS disk, optionally, extra disk.

4) VM - part of virtual network, has public IP address

### 15. Lab - Building a Windows virtual machine

VS -> Run as administrator, (why?) .NET Core Sample App

Create resource -> VM

Subscription (my free 200)

Resource group - logical grouping of resources

<https://portal.azure.com/#view/HubsExtension/BrowseAll>

All resources

### 16. Connecting to the Virtual Machine

Download RDP file and login

### 17. Lab - Installing Internet Information Services

Install IIS = Host our app

Start -> Server Manager (dashboard)

Dashboard -> Add roles and features Wizard

Web server (IIS), Next, Finish

Tools -> IIS Manager

Resources -> public IP 13.81.85.54

This site can’t be reached 13.81.85.54 took too long to respond.

Web server by default listens on port 80

Network Security Group

Create rule to allow traffic on port 80

Networking -> Inbound port rules

RDP port 3389

Networking -> Add inbound port rule

Service - HTTP

Name - AllowAnyHTTPInbound_Port_80

AZ 104 Administration

<http://13.81.85.54/> - OK IIS page

### 18. Lab - Deploying a .NET Core app on Windows Server

VS -> Tools -> Options -> Azure Account -> OK

prj -> right click -> publish -> Azure -> Azure Virtual Machine -> Select group and VM

Publish page -> Show All Settings -> Connection ->

Enter Password, Validate Connection, Accept Security Certificate

Save

Publish

Enter password for VM

...

Publish Succeeded.

Web App was published successfully <http://appvm100.westeurope.cloudapp.azure.com/>

#### Step 1: Assign a DNS name to the VM

appvm -> Overview -> DNS Name: (appvm100) appvm100.westeurope.cloudapp.azure.com

Save -> OK, available from browser appvm100.westeurope.cloudapp.azure.com

#### Step 2: Add a rule for the port 8172 to the Network Security Group (open WebDeploy port (8172) on Azure)

Networking -> Add inbound port rule, 8172, AllowAnyCustom_Port_8172_Inbound

#### Step 3: Add the role of the Management Service on the VM

VM -> Dashboard -> Add roles and features

Web Server -> Management Tools -> Managements Service -> Next and Finish Install

#### Step 4: Check the configuration of the management service in IIS

VMs IIS -> appvm -> Managements Service -> Check "Enable remote Connections"

Note that port is 8172

"Apply", "Start" service

#### Step 5: Install the .NET Core Hosting Bundle. This allows .NET apps to be hosted on IIS

App is built under .NET 6.0.0 - the same should be on the VM

Dashboard -> Local Server -> IE Enhanced Security Configuration (is ON)

Disable to allow .NET install: Off, Off

<https://dotnet.microsoft.com/en-us/download>

<https://dotnet.microsoft.com/en-us/download/dotnet/6.0>

ASP.NET Core Runtime 6.0.15 (major is 6.0) it is OK

(dotnet-hosting-6.0.15-win.exe)

Download hosting bundle and install => Runtime is available on the hosting machine

Common issue - mismatch between the versions

Download and install Web Deploy v3.6 -> "Complete" install

#### Step 6: Install the Web Deploy v3.6 tool

### 19. Lab - Building a Linux VM

<https://www.putty.org/>

<https://winscp.net/eng/download.php>

Ubuntu Server 20.04 LTS (prebuilt machine)

linuxvm

Select inbound ports

* HTTP (80)

* SSH (22)

* HTTP (443)

Select HTTP and SSH

Virtual network/subnet appvm-vnet/default

Existing Virtual network is not populated in dropdown?
Make sure that you create new VM in the same region where your VNET is located.

Changed region - it appears.

You have set SSH port(s) open to the internet.  This is only recommended for testing.  If you want to change this setting, go back to Basics tab.  

### 20. Deploying our .NET App on the Linux VM

Putty -> Public IP address, SSH (22)

Accept and log in

On linux - copy app

VS -> Publish -> New -> Folder (on local machine)

bin\Release\net6.0\publish\

SuccessPublish profile 'F:\...\git\Learn\webapp\webapp\Properties\PublishProfiles\FolderProfile.pubxml' created.

Publish, open folder

copy publish dir (webapp\webapp\bin\Release\net6) to server

WinScp, login and copy

Install hosting bundle

<https://dotnet.microsoft.com/en-us/download/dotnet/6.0>

Package manager instructions, Ubuntu, 22.04

<https://learn.microsoft.com/en-us/dotnet/core/install/linux-ubuntu#supported-distributions>

```bash
# Get Ubuntu version
declare repo_version=$(if command -v lsb_release &> /dev/null; then lsb_release -r -s; else grep -oP '(?<=^VERSION_ID=).+' /etc/os-release | tr -d '"'; fi)

# Download Microsoft signing key and repository
wget https://packages.microsoft.com/config/ubuntu/$repo_version/packages-microsoft-prod.deb -O packages-microsoft-prod.deb

# Install Microsoft signing key and repository
sudo dpkg -i packages-microsoft-prod.deb

# Clean up
rm packages-microsoft-prod.deb

# Update packages
sudo apt update
```

<details>
  <summary>Log</summary>

```bash
demitry@linuxvm:~/publish$ declare repo_version=$(if command -v lsb_release &> /dev/null; then lsb_release -r -s; else grep -oP '(?<=^VERSION_ID=).+' /e                                                                                     tc/os-release | tr -d '"'; fi)
demitry@linuxvm:~/publish$ wget https://packages.microsoft.com/config/ubuntu/$repo_version/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
--2023-04-10 13:08:31--  https://packages.microsoft.com/config/ubuntu/20.04/packages-microsoft-prod.deb
Resolving packages.microsoft.com (packages.microsoft.com)... 40.114.136.21
Connecting to packages.microsoft.com (packages.microsoft.com)|40.114.136.21|:443... connected.
HTTP request sent, awaiting response... 200 OK
Length: 3690 (3.6K) [application/octet-stream]
Saving to: ‘packages-microsoft-prod.deb’

packages-microsoft-prod.deb           100%[=========================================================================>]   3.60K  --.-KB/s    in 0s

2023-04-10 13:08:31 (628 MB/s) - ‘packages-microsoft-prod.deb’ saved [3690/3690]

demitry@linuxvm:~/publish$ sudo dpkg -i packages-microsoft-prod.deb
Selecting previously unselected package packages-microsoft-prod.
(Reading database ... 58689 files and directories currently installed.)
Preparing to unpack packages-microsoft-prod.deb ...
Unpacking packages-microsoft-prod (1.0-ubuntu20.04.1) ...
Setting up packages-microsoft-prod (1.0-ubuntu20.04.1) ...
demitry@linuxvm:~/publish$ rm packages-microsoft-prod.deb
demitry@linuxvm:~/publish$ sudo apt update
Hit:1 http://azure.archive.ubuntu.com/ubuntu focal InRelease
Get:2 http://azure.archive.ubuntu.com/ubuntu focal-updates InRelease [114 kB]
Get:3 http://azure.archive.ubuntu.com/ubuntu focal-backports InRelease [108 kB]
Get:4 http://azure.archive.ubuntu.com/ubuntu focal-security InRelease [114 kB]
Get:5 https://packages.microsoft.com/ubuntu/20.04/prod focal InRelease [3611 B]
Get:6 https://packages.microsoft.com/ubuntu/20.04/prod focal/main arm64 Packages [38.9 kB]
Get:7 https://packages.microsoft.com/ubuntu/20.04/prod focal/main amd64 Packages [192 kB]
Get:8 https://packages.microsoft.com/ubuntu/20.04/prod focal/main all Packages [2460 B]
Get:9 https://packages.microsoft.com/ubuntu/20.04/prod focal/main armhf Packages [13.5 kB]
Fetched 587 kB in 1s (955 kB/s)
Reading package lists... Done
Building dependency tree
Reading state information... Done
10 packages can be upgraded. Run 'apt list --upgradable' to see them.
```

</details>

```bash
sudo apt-get update && sudo apt-get install -y dotnet-sdk-6.0
```

</details>

<details>
  <summary>Log</summary>

  ```bash
demitry@linuxvm:~/publish$ sudo apt-get remove dotnet-sdk-6.0
Reading package lists... Done
Building dependency tree
Reading state information... Done
Package 'dotnet-sdk-6.0' is not installed, so not removed
0 upgraded, 0 newly installed, 0 to remove and 10 not upgraded.
demitry@linuxvm:~/publish$ sudo apt-get update && sudo apt-get install -y dotnet-sdk-6.0
Hit:1 http://azure.archive.ubuntu.com/ubuntu focal InRelease
Hit:2 http://azure.archive.ubuntu.com/ubuntu focal-updates InRelease
Get:3 http://azure.archive.ubuntu.com/ubuntu focal-backports InRelease [108 kB]
Get:4 http://azure.archive.ubuntu.com/ubuntu focal-security InRelease [114 kB]
Hit:5 https://packages.microsoft.com/ubuntu/20.04/prod focal InRelease
Fetched 222 kB in 1s (383 kB/s)
Reading package lists... Done
Reading package lists... Done
Building dependency tree
Reading state information... Done
The following additional packages will be installed:
  aspnetcore-runtime-6.0 aspnetcore-targeting-pack-6.0 dotnet-apphost-pack-6.0 dotnet-host dotnet-hostfxr-6.0 dotnet-runtime-6.0 dotnet-runtime-deps-6.0 dotnet-targeting-pack-6.0 netstandard-targeting-pack-2.1
The following NEW packages will be installed:
  aspnetcore-runtime-6.0 aspnetcore-targeting-pack-6.0 dotnet-apphost-pack-6.0 dotnet-host dotnet-hostfxr-6.0 dotnet-runtime-6.0 dotnet-runtime-deps-6.0 dotnet-sdk-6.0 dotnet-targeting-pack-6.0 netstandard-targeting-pack-2.1
0 upgraded, 10 newly installed, 0 to remove and 10 not upgraded.
Need to get 125 MB of archives.
After this operation, 508 MB of additional disk space will be used.
Get:1 https://packages.microsoft.com/ubuntu/20.04/prod focal/main amd64 dotnet-host amd64 7.0.4-1 [57.2 kB]
Get:2 https://packages.microsoft.com/ubuntu/20.04/prod focal/main amd64 dotnet-hostfxr-6.0 amd64 6.0.15-1 [142 kB]
Get:3 https://packages.microsoft.com/ubuntu/20.04/prod focal/main amd64 dotnet-runtime-deps-6.0 amd64 6.0.15-1 [2796 B]
Get:4 https://packages.microsoft.com/ubuntu/20.04/prod focal/main amd64 dotnet-runtime-6.0 amd64 6.0.15-1 [23.1 MB]
Get:5 https://packages.microsoft.com/ubuntu/20.04/prod focal/main amd64 aspnetcore-runtime-6.0 amd64 6.0.15-1 [6612 kB]
Get:6 https://packages.microsoft.com/ubuntu/20.04/prod focal/main amd64 dotnet-targeting-pack-6.0 amd64 6.0.15-1 [2131 kB]
Get:7 https://packages.microsoft.com/ubuntu/20.04/prod focal/main amd64 aspnetcore-targeting-pack-6.0 amd64 6.0.15-1 [1314 kB]
Get:8 https://packages.microsoft.com/ubuntu/20.04/prod focal/main amd64 dotnet-apphost-pack-6.0 amd64 6.0.15-1 [3511 kB]
Get:9 https://packages.microsoft.com/ubuntu/20.04/prod focal/main amd64 netstandard-targeting-pack-2.1 amd64 2.1.0-1 [1476 kB]
Get:10 https://packages.microsoft.com/ubuntu/20.04/prod focal/main amd64 dotnet-sdk-6.0 amd64 6.0.407-1 [86.7 MB]
Fetched 125 MB in 1s (180 MB/s)
Selecting previously unselected package dotnet-host.
(Reading database ... 58697 files and directories currently installed.)
Preparing to unpack .../0-dotnet-host_7.0.4-1_amd64.deb ...
Unpacking dotnet-host (7.0.4-1) ...
Selecting previously unselected package dotnet-hostfxr-6.0.
Preparing to unpack .../1-dotnet-hostfxr-6.0_6.0.15-1_amd64.deb ...
Unpacking dotnet-hostfxr-6.0 (6.0.15-1) ...
Selecting previously unselected package dotnet-runtime-deps-6.0.
Preparing to unpack .../2-dotnet-runtime-deps-6.0_6.0.15-1_amd64.deb ...
Unpacking dotnet-runtime-deps-6.0 (6.0.15-1) ...
Selecting previously unselected package dotnet-runtime-6.0.
Preparing to unpack .../3-dotnet-runtime-6.0_6.0.15-1_amd64.deb ...
Unpacking dotnet-runtime-6.0 (6.0.15-1) ...
Selecting previously unselected package aspnetcore-runtime-6.0.
Preparing to unpack .../4-aspnetcore-runtime-6.0_6.0.15-1_amd64.deb ...
Unpacking aspnetcore-runtime-6.0 (6.0.15-1) ...
Selecting previously unselected package dotnet-targeting-pack-6.0.
Preparing to unpack .../5-dotnet-targeting-pack-6.0_6.0.15-1_amd64.deb ...
Unpacking dotnet-targeting-pack-6.0 (6.0.15-1) ...
Selecting previously unselected package aspnetcore-targeting-pack-6.0.
Preparing to unpack .../6-aspnetcore-targeting-pack-6.0_6.0.15-1_amd64.deb ...
Unpacking aspnetcore-targeting-pack-6.0 (6.0.15-1) ...
Selecting previously unselected package dotnet-apphost-pack-6.0.
Preparing to unpack .../7-dotnet-apphost-pack-6.0_6.0.15-1_amd64.deb ...
Unpacking dotnet-apphost-pack-6.0 (6.0.15-1) ...
Selecting previously unselected package netstandard-targeting-pack-2.1.
Preparing to unpack .../8-netstandard-targeting-pack-2.1_2.1.0-1_amd64.deb ...
Unpacking netstandard-targeting-pack-2.1 (2.1.0-1) ...
Selecting previously unselected package dotnet-sdk-6.0.
Preparing to unpack .../9-dotnet-sdk-6.0_6.0.407-1_amd64.deb ...
Unpacking dotnet-sdk-6.0 (6.0.407-1) ...
Setting up dotnet-host (7.0.4-1) ...
Setting up dotnet-apphost-pack-6.0 (6.0.15-1) ...
Setting up netstandard-targeting-pack-2.1 (2.1.0-1) ...
Setting up dotnet-targeting-pack-6.0 (6.0.15-1) ...
Setting up dotnet-runtime-deps-6.0 (6.0.15-1) ...
Setting up aspnetcore-targeting-pack-6.0 (6.0.15-1) ...
Setting up dotnet-hostfxr-6.0 (6.0.15-1) ...
Setting up dotnet-runtime-6.0 (6.0.15-1) ...
Setting up aspnetcore-runtime-6.0 (6.0.15-1) ...
Setting up dotnet-sdk-6.0 (6.0.407-1) ...
This software may collect information about you and your use of the software, and send that to Microsoft.
Please visit http://aka.ms/dotnet-cli-eula for more information.
Welcome to .NET!
---------------------
Learn more about .NET: https://aka.ms/dotnet-docs
Use 'dotnet --help' to see available commands or visit: https://aka.ms/dotnet-cli-docs

Telemetry
---------
The .NET tools collect usage data in order to help us improve your experience. It is collected by Microsoft and shared with the community. You can opt-out of telemetry by setting the DOTNET_CLI_TELEMETRY_OPTOUT environment variable to '1' or 'true' using your favorite shell.

Read more about .NET CLI Tools telemetry: https://aka.ms/dotnet-cli-telemetry

Configuring...
--------------
A command is running to populate your local package cache to improve restore speed and enable offline access. This command takes up to one minute to complete and only runs once.
Processing triggers for man-db (2.9.1-1) ...
demitry@linuxvm:~/publish$

  ```

</details>

demitry@linuxvm:~/publish$ dotnet --version

6.0.407

Run our app:

```
dotnet webapp.dll
```

<details>
  <summary>Log</summary>

```bash
dotnet webapp.dll
warn: Microsoft.AspNetCore.DataProtection.KeyManagement.XmlKeyManager[35]
      No XML encryptor configured. Key {66b193eb-f09f-47a9-a90c-cbaa5b5d7929} may be persisted to storage in unencrypted form.
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: http://localhost:5000
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Production
info: Microsoft.Hosting.Lifetime[0]
      Content root path: /home/demitry/publish/
```
</details>

Duplicate session

```bash
curl http://localhost:5000
```

and get your html page

### 21. Using NGINX on the Linux VM

1) Publish to a folder (done)
2) Copy folder to the server (done)
3) Install ASP.Net 6.0 (done)
4) NGINX Web Server

Config: If there are any HTTP request coming to port 80

Please direct it to the port 5000, where we have an application.

Install NGINX Web Server

sudo apt-get install nginx

Now public IP => Welcome to nginx! page

```
cd /etc/nginx/sites-available

sudo chmod 777 default
```

<details>
  <summary>Nginx original config</summary>

```config
##
# You should look at the following URL's in order to grasp a solid understanding
# of Nginx configuration files in order to fully unleash the power of Nginx.
# https://www.nginx.com/resources/wiki/start/
# https://www.nginx.com/resources/wiki/start/topics/tutorials/config_pitfalls/
# https://wiki.debian.org/Nginx/DirectoryStructure
#
# In most cases, administrators will remove this file from sites-enabled/ and
# leave it as reference inside of sites-available where it will continue to be
# updated by the nginx packaging team.
#
# This file will automatically load configuration files provided by other
# applications, such as Drupal or Wordpress. These applications will be made
# available underneath a path with that package name, such as /drupal8.
#
# Please see /usr/share/doc/nginx-doc/examples/ for more detailed examples.
##

# Default server configuration
#
server {
	listen 80 default_server;
	listen [::]:80 default_server;

	# SSL configuration
	#
	# listen 443 ssl default_server;
	# listen [::]:443 ssl default_server;
	#
	# Note: You should disable gzip for SSL traffic.
	# See: https://bugs.debian.org/773332
	#
	# Read up on ssl_ciphers to ensure a secure configuration.
	# See: https://bugs.debian.org/765782
	#
	# Self signed certs generated by the ssl-cert package
	# Don't use them in a production server!
	#
	# include snippets/snakeoil.conf;

	root /var/www/html;

	# Add index.php to the list if you are using PHP
	index index.html index.htm index.nginx-debian.html;

	server_name _;

	location / {
		# First attempt to serve request as file, then
		# as directory, then fall back to displaying a 404.
		try_files $uri $uri/ =404;
	}

	# pass PHP scripts to FastCGI server
	#
	#location ~ \.php$ {
	#	include snippets/fastcgi-php.conf;
	#
	#	# With php-fpm (or other unix sockets):
	#	fastcgi_pass unix:/var/run/php/php7.4-fpm.sock;
	#	# With php-cgi (or other tcp sockets):
	#	fastcgi_pass 127.0.0.1:9000;
	#}

	# deny access to .htaccess files, if Apache's document root
	# concurs with nginx's one
	#
	#location ~ /\.ht {
	#	deny all;
	#}
}

# Virtual Host configuration for example.com
#
# You can move that to a different file under sites-available/ and symlink that
# to sites-enabled/ to enable it.
#
#server {
#	listen 80;
#	listen [::]:80;
#
#	server_name example.com;
#
#	root /var/www/example.com;
#	index index.html;
#
#	location / {
#		try_files $uri $uri/ =404;
#	}
#}

```

</details>

Remove

```
	location / {
		# First attempt to serve request as file, then
		# as directory, then fall back to displaying a 404.
		try_files $uri $uri/ =404;
	}
```

Add (this is bad config with missing ;;;)

<del>

```
	location / {
		proxy_pass		http://localhost:5000;
		proxy_http_version	1.1
		proxy_set_header	Upgrade $http_upgrade
		proxy_set_header	Connection keep-alive
		proxy_set_header	Host $host
		proxy_cache_bypass	$http_upgrade
	}

```
</del>

Proper config:

```
	location / {
		proxy_pass		http://localhost:5000;
		proxy_http_version	1.1;
		proxy_set_header	Upgrade $http_upgrade;
		proxy_set_header	Connection keep-alive;
		proxy_set_header	Host $host;
		proxy_cache_bypass	$http_upgrade;
	}

```

Back to 644 permissions
```
sudo chmod 644 default
```

```
sudo service nginx start
```

```
demitry@linuxvm:/etc/nginx/sites-available$ sudo service nginx start
Job for nginx.service failed because the control process exited with error code.
See "systemctl status nginx.service" and "journalctl -xe" for details.
demitry@linuxvm:/etc/nginx/sites-available$
demitry@linuxvm:/etc/nginx/sites-available$ systemctl status nginx.service
● nginx.service - A high performance web server and a reverse proxy server
     Loaded: loaded (/lib/systemd/system/nginx.service; enabled; vendor preset: enabled)
     Active: failed (Result: exit-code) since Mon 2023-04-10 15:28:14 UTC; 3min 42s ago
       Docs: man:nginx(8)
    Process: 17124 ExecStartPre=/usr/sbin/nginx -t -q -g daemon on; master_process on; (code=exited, status=1/FAILURE)

Apr 10 15:28:14 linuxvm systemd[1]: Starting A high performance web server and a reverse proxy server...
Apr 10 15:28:14 linuxvm nginx[17124]: nginx: [emerg] unexpected "}" in /etc/nginx/sites-enabled/default:55
Apr 10 15:28:14 linuxvm nginx[17124]: nginx: configuration file /etc/nginx/nginx.conf test failed
Apr 10 15:28:14 linuxvm systemd[1]: nginx.service: Control process exited, code=exited, status=1/FAILURE
Apr 10 15:28:14 linuxvm systemd[1]: nginx.service: Failed with result 'exit-code'.
Apr 10 15:28:14 linuxvm systemd[1]: Failed to start A high performance web server and a reverse proxy server.
demitry@linuxvm:/etc/nginx/sites-available$ sudo service nginx start
Job for nginx.service failed because the control process exited with error code.
See "systemctl status nginx.service" and "journalctl -xe" for details.
demitry@linuxvm:/etc/nginx/sites-available$

```

There was a missing ; at the end of a new added line inside the server block {...} .

Ensure the curly braces and ; are all in place.

```
sudo chmod 777 default
nano default 
(Add missing ;;;)
sudo chmod 644 default
sudo service nginx start
```

Proper config:

```
	location / {
		proxy_pass		http://localhost:5000;
		proxy_http_version	1.1;
		proxy_set_header	Upgrade $http_upgrade;
		proxy_set_header	Connection keep-alive;
		proxy_set_header	Host $host;
		proxy_cache_bypass	$http_upgrade;
	}

```

Troubleshoot nginx

```
systemctl status nginx.service
journalctl -xe
```

### 22. Keeping a check on the cost of your resources

Delete whole group ar delete resources in a group?

### 23. Quick Note

Home -> Cost Management -> Cos analysis -> Custom: Cost Analysis -> Configuration

SDK for development purposes, Runtime for runtime.

