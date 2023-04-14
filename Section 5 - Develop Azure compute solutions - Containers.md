# Section 5: Develop Azure compute solutions - Containers

## 63. What are we going to cover

## 64. What is the need for containers

### Issue 1 - Isolation

VM = App1, App2, App3... dependencies, libraries

App2 needs updating, 3rd-party libs, => impact on environment => impact on App1

Container = 1 unit = app + dependencies (libraries, frameworks) - could be deployed to VM

no impact on another container unit

### Issue 2 - Portability

Run on VM1, VM2,...

## 65. What is Docker

## 66. Lab - Installing docker on Linux VM

docker-grp

linuxvm

linuxuser/ ???

docker-grp-vnet

<https://docs.docker.com/engine/install/ubuntu/>

168.63.57.194

Install using the apt repository
Before you install Docker Engine for the first time on a new host machine, you need to set up the Docker repository. Afterward, you can install and update Docker from the repository.

Set up the repository
Update the apt package index and install packages to allow apt to use a repository over HTTPS:

```
 sudo apt-get update
 sudo apt-get install \
    ca-certificates \
    curl \
    gnupg
```

Add Docker’s official GPG key:

```
 sudo install -m 0755 -d /etc/apt/keyrings
 curl -fsSL https://download.docker.com/linux/ubuntu/gpg | sudo gpg --dearmor -o /etc/apt/keyrings/docker.gpg
 sudo chmod a+r /etc/apt/keyrings/docker.gpg
```

Use the following command to set up the repository:

```
 echo \
  "deb [arch="$(dpkg --print-architecture)" signed-by=/etc/apt/keyrings/docker.gpg] https://download.docker.com/linux/ubuntu \
  "$(. /etc/os-release && echo "$VERSION_CODENAME")" stable" | \
  sudo tee /etc/apt/sources.list.d/docker.list > /dev/null
```
Install Docker Engine
Update the apt package index:

```
 sudo apt-get update
```
Install Docker Engine, containerd, and Docker Compose.

Latest
Specific version

To install the latest version, run:

```
 sudo apt-get install docker-ce docker-ce-cli containerd.io docker-buildx-plugin docker-compose-plugin
```

Verify that the Docker Engine installation is successful by running the hello-world image:

```
 sudo docker run hello-world
```

<details>
  <summary>Log</summary>

```console
login as: linuxuser

linuxuser@168.63.57.194 password:
Welcome to Ubuntu 20.04.6 LTS (GNU/Linux 5.15.0-1035-azure x86_64)

 * Documentation:  https://help.ubuntu.com
 * Management:     https://landscape.canonical.com
 * Support:        https://ubuntu.com/advantage

  System information as of Fri Apr 14 11:33:01 UTC 2023

  System load:  0.0               Processes:             125
  Usage of /:   5.2% of 28.89GB   Users logged in:       0
  Memory usage: 4%                IPv4 address for eth0: 10.0.0.4
  Swap usage:   0%

Expanded Security Maintenance for Applications is not enabled.

0 updates can be applied immediately.

Enable ESM Apps to receive additional future security updates.
See https://ubuntu.com/esm or run: sudo pro status


The list of available updates is more than a week old.
To check for new updates run: sudo apt update


The programs included with the Ubuntu system are free software;
the exact distribution terms for each program are described in the
individual files in /usr/share/doc/*/copyright.

Ubuntu comes with ABSOLUTELY NO WARRANTY, to the extent permitted by
applicable law.

To run a command as administrator (user "root"), use "sudo <command>".
See "man sudo_root" for details.

linuxuser@linuxvm:~$ sudo apt-get update
Hit:1 http://azure.archive.ubuntu.com/ubuntu focal InRelease
Get:2 http://azure.archive.ubuntu.com/ubuntu focal-updates InRelease [114 kB]
Get:3 http://azure.archive.ubuntu.com/ubuntu focal-backports InRelease [108 kB]
Get:4 http://azure.archive.ubuntu.com/ubuntu focal-security InRelease [114 kB]
Get:5 http://azure.archive.ubuntu.com/ubuntu focal/universe amd64 Packages [8628 kB]
Get:6 http://azure.archive.ubuntu.com/ubuntu focal/universe Translation-en [5124 kB]
Get:7 http://azure.archive.ubuntu.com/ubuntu focal/universe amd64 c-n-f Metadata [265 kB]
Get:8 http://azure.archive.ubuntu.com/ubuntu focal/multiverse amd64 Packages [144 kB]
Get:9 http://azure.archive.ubuntu.com/ubuntu focal/multiverse Translation-en [104 kB]
Get:10 http://azure.archive.ubuntu.com/ubuntu focal/multiverse amd64 c-n-f Metadata [9136 B]
Get:11 http://azure.archive.ubuntu.com/ubuntu focal-updates/main amd64 Packages [2469 kB]
Get:12 http://azure.archive.ubuntu.com/ubuntu focal-updates/main Translation-en [421 kB]
Get:13 http://azure.archive.ubuntu.com/ubuntu focal-updates/main amd64 c-n-f Metadata [16.4 kB]
Get:14 http://azure.archive.ubuntu.com/ubuntu focal-updates/restricted amd64 Packages [1717 kB]
Get:15 http://azure.archive.ubuntu.com/ubuntu focal-updates/restricted Translation-en [242 kB]
Get:16 http://azure.archive.ubuntu.com/ubuntu focal-updates/restricted amd64 c-n-f Metadata [612 B]
Get:17 http://azure.archive.ubuntu.com/ubuntu focal-updates/universe amd64 Packages [1048 kB]
Get:18 http://azure.archive.ubuntu.com/ubuntu focal-updates/universe Translation-en [247 kB]
Get:19 http://azure.archive.ubuntu.com/ubuntu focal-updates/universe amd64 c-n-f Metadata [24.2 kB]
Get:20 http://azure.archive.ubuntu.com/ubuntu focal-updates/multiverse amd64 Packages [25.2 kB]
Get:21 http://azure.archive.ubuntu.com/ubuntu focal-updates/multiverse Translation-en [7408 B]
Get:22 http://azure.archive.ubuntu.com/ubuntu focal-updates/multiverse amd64 c-n-f Metadata [592 B]
Get:23 http://azure.archive.ubuntu.com/ubuntu focal-backports/main amd64 Packages [45.7 kB]
Get:24 http://azure.archive.ubuntu.com/ubuntu focal-backports/main Translation-en [16.3 kB]
Get:25 http://azure.archive.ubuntu.com/ubuntu focal-backports/main amd64 c-n-f Metadata [1420 B]
Get:26 http://azure.archive.ubuntu.com/ubuntu focal-backports/restricted amd64 c-n-f Metadata [116 B]
Get:27 http://azure.archive.ubuntu.com/ubuntu focal-backports/universe amd64 Packages [24.9 kB]
Get:28 http://azure.archive.ubuntu.com/ubuntu focal-backports/universe Translation-en [16.3 kB]
Get:29 http://azure.archive.ubuntu.com/ubuntu focal-backports/universe amd64 c-n-f Metadata [880 B]
Get:30 http://azure.archive.ubuntu.com/ubuntu focal-backports/multiverse amd64 c-n-f Metadata [116 B]
Get:31 http://azure.archive.ubuntu.com/ubuntu focal-security/main amd64 Packages [2085 kB]
Get:32 http://azure.archive.ubuntu.com/ubuntu focal-security/main Translation-en [338 kB]
Get:33 http://azure.archive.ubuntu.com/ubuntu focal-security/main amd64 c-n-f Metadata [12.5 kB]
Get:34 http://azure.archive.ubuntu.com/ubuntu focal-security/restricted amd64 Packages [1609 kB]
Get:35 http://azure.archive.ubuntu.com/ubuntu focal-security/restricted Translation-en [227 kB]
Get:36 http://azure.archive.ubuntu.com/ubuntu focal-security/restricted amd64 c-n-f Metadata [612 B]
Get:37 http://azure.archive.ubuntu.com/ubuntu focal-security/universe amd64 Packages [821 kB]
Get:38 http://azure.archive.ubuntu.com/ubuntu focal-security/universe Translation-en [165 kB]
Get:39 http://azure.archive.ubuntu.com/ubuntu focal-security/universe amd64 c-n-f Metadata [17.6 kB]
Get:40 http://azure.archive.ubuntu.com/ubuntu focal-security/multiverse amd64 Packages [22.9 kB]
Get:41 http://azure.archive.ubuntu.com/ubuntu focal-security/multiverse Translation-en [5488 B]
Get:42 http://azure.archive.ubuntu.com/ubuntu focal-security/multiverse amd64 c-n-f Metadata [516 B]
Fetched 26.2 MB in 5s (5558 kB/s)
Reading package lists... Done
linuxuser@linuxvm:~$ sudo apt-get install \
>     ca-certificates \
>     curl \
>     gnupg
Reading package lists... Done
Building dependency tree
Reading state information... Done
ca-certificates is already the newest version (20211016ubuntu0.20.04.1).
ca-certificates set to manually installed.
curl is already the newest version (7.68.0-1ubuntu2.18).
curl set to manually installed.
gnupg is already the newest version (2.2.19-3ubuntu2.2).
gnupg set to manually installed.
0 upgraded, 0 newly installed, 0 to remove and 22 not upgraded.
linuxuser@linuxvm:~$ sudo install -m 0755 -d /etc/apt/keyrings
linuxuser@linuxvm:~$ curl -fsSL https://download.docker.com/linux/ubuntu/gpg | sudo gpg --dearmor -o /etc/apt/keyrings/docker.gpg
linuxuser@linuxvm:~$ sudo chmod a+r /etc/apt/keyrings/docker.gpg
linuxuser@linuxvm:~$ echo \
>   "deb [arch="$(dpkg --print-architecture)" signed-by=/etc/apt/keyrings/docker.gpg] https://download.docker.com/linux/ubuntu \
>   "$(. /etc/os-release && echo "$VERSION_CODENAME")" stable" | \
>   sudo tee /etc/apt/sources.list.d/docker.list > /dev/null
linuxuser@linuxvm:~$ sudo apt-get update
Hit:1 http://azure.archive.ubuntu.com/ubuntu focal InRelease
Hit:2 http://azure.archive.ubuntu.com/ubuntu focal-updates InRelease
Hit:3 http://azure.archive.ubuntu.com/ubuntu focal-backports InRelease
Hit:4 http://azure.archive.ubuntu.com/ubuntu focal-security InRelease
Get:5 https://download.docker.com/linux/ubuntu focal InRelease [57.7 kB]
Get:6 https://download.docker.com/linux/ubuntu focal/stable amd64 Packages [26.8 kB]
Fetched 84.5 kB in 1s (125 kB/s)
Reading package lists... Done
linuxuser@linuxvm:~$ sudo apt-get install docker-ce docker-ce-cli containerd.io docker-buildx-plugin docker-compose-plugin
Reading package lists... Done
Building dependency tree
Reading state information... Done
The following additional packages will be installed:
  docker-ce-rootless-extras pigz slirp4netns
Suggested packages:
  aufs-tools cgroupfs-mount | cgroup-lite
The following NEW packages will be installed:
  containerd.io docker-buildx-plugin docker-ce docker-ce-cli docker-ce-rootless-extras docker-compose-plugin pigz slirp4netns
0 upgraded, 8 newly installed, 0 to remove and 22 not upgraded.
Need to get 109 MB of archives.
After this operation, 395 MB of additional disk space will be used.
Do you want to continue? [Y/n] Y
Get:1 http://azure.archive.ubuntu.com/ubuntu focal/universe amd64 pigz amd64 2.4-1 [57.4 kB]
Get:2 http://azure.archive.ubuntu.com/ubuntu focal/universe amd64 slirp4netns amd64 0.4.3-1 [74.3 kB]
Get:3 https://download.docker.com/linux/ubuntu focal/stable amd64 containerd.io amd64 1.6.20-1 [28.3 MB]
Get:4 https://download.docker.com/linux/ubuntu focal/stable amd64 docker-buildx-plugin amd64 0.10.4-1~ubuntu.20.04~focal [25.9 MB]
Get:5 https://download.docker.com/linux/ubuntu focal/stable amd64 docker-ce-cli amd64 5:23.0.3-1~ubuntu.20.04~focal [13.2 MB]
Get:6 https://download.docker.com/linux/ubuntu focal/stable amd64 docker-ce amd64 5:23.0.3-1~ubuntu.20.04~focal [22.0 MB]
Get:7 https://download.docker.com/linux/ubuntu focal/stable amd64 docker-ce-rootless-extras amd64 5:23.0.3-1~ubuntu.20.04~focal [8778 kB]
Get:8 https://download.docker.com/linux/ubuntu focal/stable amd64 docker-compose-plugin amd64 2.17.2-1~ubuntu.20.04~focal [10.9 MB]
Fetched 109 MB in 1s (83.4 MB/s)
Selecting previously unselected package pigz.
(Reading database ... 58689 files and directories currently installed.)
Preparing to unpack .../0-pigz_2.4-1_amd64.deb ...
Unpacking pigz (2.4-1) ...
Selecting previously unselected package containerd.io.
Preparing to unpack .../1-containerd.io_1.6.20-1_amd64.deb ...
Unpacking containerd.io (1.6.20-1) ...
Selecting previously unselected package docker-buildx-plugin.
Preparing to unpack .../2-docker-buildx-plugin_0.10.4-1~ubuntu.20.04~focal_amd64.deb ...
Unpacking docker-buildx-plugin (0.10.4-1~ubuntu.20.04~focal) ...
Selecting previously unselected package docker-ce-cli.
Preparing to unpack .../3-docker-ce-cli_5%3a23.0.3-1~ubuntu.20.04~focal_amd64.deb ...
Unpacking docker-ce-cli (5:23.0.3-1~ubuntu.20.04~focal) ...
Selecting previously unselected package docker-ce.
Preparing to unpack .../4-docker-ce_5%3a23.0.3-1~ubuntu.20.04~focal_amd64.deb ...
Unpacking docker-ce (5:23.0.3-1~ubuntu.20.04~focal) ...
Selecting previously unselected package docker-ce-rootless-extras.
Preparing to unpack .../5-docker-ce-rootless-extras_5%3a23.0.3-1~ubuntu.20.04~focal_amd64.deb ...
Unpacking docker-ce-rootless-extras (5:23.0.3-1~ubuntu.20.04~focal) ...
Selecting previously unselected package docker-compose-plugin.
Preparing to unpack .../6-docker-compose-plugin_2.17.2-1~ubuntu.20.04~focal_amd64.deb ...
Unpacking docker-compose-plugin (2.17.2-1~ubuntu.20.04~focal) ...
Selecting previously unselected package slirp4netns.
Preparing to unpack .../7-slirp4netns_0.4.3-1_amd64.deb ...
Unpacking slirp4netns (0.4.3-1) ...
Setting up slirp4netns (0.4.3-1) ...
Setting up docker-buildx-plugin (0.10.4-1~ubuntu.20.04~focal) ...
Setting up containerd.io (1.6.20-1) ...
Created symlink /etc/systemd/system/multi-user.target.wants/containerd.service → /lib/systemd/system/containerd.service.
Setting up docker-compose-plugin (2.17.2-1~ubuntu.20.04~focal) ...
Setting up docker-ce-cli (5:23.0.3-1~ubuntu.20.04~focal) ...
Setting up pigz (2.4-1) ...
Setting up docker-ce-rootless-extras (5:23.0.3-1~ubuntu.20.04~focal) ...
Setting up docker-ce (5:23.0.3-1~ubuntu.20.04~focal) ...
Created symlink /etc/systemd/system/multi-user.target.wants/docker.service → /lib/systemd/system/docker.service.
Created symlink /etc/systemd/system/sockets.target.wants/docker.socket → /lib/systemd/system/docker.socket.
Processing triggers for man-db (2.9.1-1) ...
Processing triggers for systemd (245.4-4ubuntu3.20) ...
linuxuser@linuxvm:~$ docker version
Client: Docker Engine - Community
 Version:           23.0.3
 API version:       1.42
 Go version:        go1.19.7
 Git commit:        3e7cbfd
 Built:             Tue Apr  4 22:06:10 2023
 OS/Arch:           linux/amd64
 Context:           default
permission denied while trying to connect to the Docker daemon socket at unix:///var/run/docker.sock: Get "http://%2Fvar%2Frun%2Fdocker.sock/v1.24/version": dial unix /var/run/docker.sock: connect: permission denied
linuxuser@linuxvm:~$ sudo docker version
Client: Docker Engine - Community
 Version:           23.0.3
 API version:       1.42
 Go version:        go1.19.7
 Git commit:        3e7cbfd
 Built:             Tue Apr  4 22:06:10 2023
 OS/Arch:           linux/amd64
 Context:           default

Server: Docker Engine - Community
 Engine:
  Version:          23.0.3
  API version:      1.42 (minimum version 1.12)
  Go version:       go1.19.7
  Git commit:       59118bf
  Built:            Tue Apr  4 22:06:10 2023
  OS/Arch:          linux/amd64
  Experimental:     false
 containerd:
  Version:          1.6.20
  GitCommit:        2806fc1057397dbaeefbea0e4e17bddfbd388f38
 runc:
  Version:          1.1.5
  GitCommit:        v1.1.5-0-gf19387a
 docker-init:
  Version:          0.19.0
  GitCommit:        de40ad0
linuxuser@linuxvm:~$

```
</details>

## 67. Running a simple container

<https://hub.docker.com/_/nginx>

linuxvm | Networking -> Add inbound security rule

HTTP Port 80 -> AllowAnyHTTPInbound_Port_80

```
sudo docker run --name appnginx -p 80:80 -d nginx
```

try to find image locally, if no image - get from hub, run as appnginx -d(daemon), with mapped -p (ports) (container to vm) 80 to 80.

```
sudo docker images
sudo docker ps
```

<details>
  <summary>Log</summary>

```command
linuxuser@linuxvm:~$ sudo docker run --name appnginx -p 80:80 -d nginx
Unable to find image 'nginx:latest' locally
latest: Pulling from library/nginx
26c5c85e47da: Pull complete
4f3256bdf66b: Pull complete
2019c71d5655: Pull complete
8c767bdbc9ae: Pull complete
78e14bb05fd3: Pull complete
75576236abf5: Pull complete
Digest: sha256:63b44e8ddb83d5dd8020327c1f40436e37a6fffd3ef2498a6204df23be6e7e94
Status: Downloaded newer image for nginx:latest
65ed8eab5b7203e7a5d11b7942a4571f3ecf71a40301a00c0f30bff59dd377db
linuxuser@linuxvm:~$ sudo docker images
REPOSITORY   TAG       IMAGE ID       CREATED      SIZE
nginx        latest    6efc10a0510f   2 days ago   142MB
linuxuser@linuxvm:~$ sudo docker ps
CONTAINER ID   IMAGE     COMMAND                  CREATED              STATUS              PORTS                               NAMES
65ed8eab5b72   nginx     "/docker-entrypoint.…"   About a minute ago   Up About a minute   0.0.0.0:80->80/tcp, :::80->80/tcp   appnginx
linuxuser@linuxvm:~$
```
</details>


Public IP address = nginx page

168.63.57.194

nginx is running in container in VM

## 68. Let's containerize a .NET application

## 69. If you have made a mistake

## 70. The need for a registry

## 71. Lab - Azure Container Registry

## 72. Pushing an image to the Azure container registry

## 73. Azure Container Instances

## 74. Multi-stage builds

## 75. Azure Container Groups

## 76. Setting up our application against MySQL database

## 77. Deploying a MySQL database container

## 78. Creating a custom MySQL image

## 79. Check the application is connecting to MySQL container

## 80. Deploying the custom MySQL container

## 81. Let's deploy an Azure Container Group

## 82. What is Azure Kubernetes

## 83. Lab - Deploying an Azure Kubernetes cluster

## 84. Lab - Azure Kubernetes - Deployment - NGINX

## 85. Lab - Deploying our application on Kubernetes

## Quiz 4: Short Quiz
