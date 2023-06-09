<!-- TOC -->

- [Section 5: Develop Azure compute solutions - Containers](#section-5-develop-azure-compute-solutions---containers)
    - [What are we going to cover](#what-are-we-going-to-cover)
    - [What is the need for containers](#what-is-the-need-for-containers)
        - [Issue 1 - Isolation](#issue-1---isolation)
        - [Issue 2 - Portability](#issue-2---portability)
    - [What is Docker](#what-is-docker)
    - [Lab - Installing docker on Linux VM](#lab---installing-docker-on-linux-vm)
    - [Running a simple container](#running-a-simple-container)
    - [Let's containerize a .NET application](#lets-containerize-a-net-application)
    - [If you have made a mistake](#if-you-have-made-a-mistake)
    - [The need for a registry](#the-need-for-a-registry)
    - [Lab - Azure Container Registry](#lab---azure-container-registry)
    - [Pushing an image to the Azure container registry](#pushing-an-image-to-the-azure-container-registry)
        - [Step-by-step installation instructions to install the Azure CLI.](#step-by-step-installation-instructions-to-install-the-azure-cli)
        - [Use Azure CLI to push images to Azure](#use-azure-cli-to-push-images-to-azure)
    - [Azure Container Instances](#azure-container-instances)
    - [Multi-stage builds](#multi-stage-builds)
    - [Azure Container Groups](#azure-container-groups)
    - [Setting up our application against MySQL database](#setting-up-our-application-against-mysql-database)
    - [Deploying a MySQL database container](#deploying-a-mysql-database-container)
    - [Creating a custom MySQL image](#creating-a-custom-mysql-image)
    - [Check the application is connecting to MySQL container](#check-the-application-is-connecting-to-mysql-container)
    - [Deploying the custom MySQL container](#deploying-the-custom-mysql-container)
    - [Let's deploy an Azure Container Group](#lets-deploy-an-azure-container-group)
    - [What is Azure Kubernetes](#what-is-azure-kubernetes)
    - [Lab - Deploying an Azure Kubernetes cluster](#lab---deploying-an-azure-kubernetes-cluster)
        - [Pod](#pod)
        - [Deployment](#deployment)
    - [Lab - Azure Kubernetes - Deployment - NGINX](#lab---azure-kubernetes---deployment---nginx)
        - [Request a quota increase](#request-a-quota-increase)
    - [Lab - Deploying our application on Kubernetes](#lab---deploying-our-application-on-kubernetes)
    - [Quiz 4: Short Quiz](#quiz-4-short-quiz)
    - [Misc](#misc)

<!-- /TOC -->

# Section 5: Develop Azure compute solutions - Containers

## What are we going to cover

## What is the need for containers

### Issue 1 - Isolation

VM = App1, App2, App3... dependencies, libraries

App2 needs updating, 3rd-party libs, => impact on environment => impact on App1

Container = 1 unit = app + dependencies (libraries, frameworks) - could be deployed to VM

no impact on another container unit

### Issue 2 - Portability

Run on VM1, VM2,...

## What is Docker

## Lab - Installing docker on Linux VM

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

## Running a simple container

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

## Let's containerize a .NET application

Build Image: on Windows machine - docker toolset is required, additional services

Lets do it on linux:

VS -> Publish to folder

Publish, Settings Target location -> copy

copy \sqlapp\bin\release\net6.0\publish\ to our server

How to build our image? - Dockerfile

app needs runtime

Dockerfile

```docker
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY . .
EXPOSE 80
ENTRYPOINT [ "dotnet", "sqlapp.dll" ]
```

copy it to publish folder

```
cd publish

sudo docker build -t sqlapp .
```
```command
linuxuser@linuxvm:~$ cd publish/
linuxuser@linuxvm:~/publish$ sudo docker build -t sqlapp .
[+] Building 4.9s (8/8) FINISHED
 => [internal] load .dockerignore                                                                                                                                                 0.1s
 => => transferring context: 2B                                                                                                                                                   0.0s
 => [internal] load build definition from Dockerfile                                                                                                                              0.1s
 => => transferring dockerfile: 151B                                                                                                                                              0.0s
 => [internal] load metadata for mcr.microsoft.com/dotnet/aspnet:6.0                                                                                                              0.3s
 => [1/3] FROM mcr.microsoft.com/dotnet/aspnet:6.0@sha256:211c84ef15e0d2bc77c8d37ea1d936ecf2f4edd11ffd260b11ec9371db63dd3d                                                        3.2s
 => => resolve mcr.microsoft.com/dotnet/aspnet:6.0@sha256:211c84ef15e0d2bc77c8d37ea1d936ecf2f4edd11ffd260b11ec9371db63dd3d                                                        0.1s
 => => sha256:6df469f23ae176b9dea89ebf6761b862c0721143da3bbd6303b953f6ab2091f1 15.17MB / 15.17MB                                                                                  0.3s
 => => sha256:7e979fe76393e15203b15743ea2e37a46e9172f53248116bce0d545a4c5a7e91 31.63MB / 31.63MB                                                                                  0.6s
 => => sha256:6c9b5f8b63cb27e4b5bea60cb5c622bc78b29181d906f19c8d5efd8aaeeaef4d 154B / 154B                                                                                        0.2s
 => => sha256:211c84ef15e0d2bc77c8d37ea1d936ecf2f4edd11ffd260b11ec9371db63dd3d 1.82kB / 1.82kB                                                                                    0.0s
 => => sha256:2c736203ee3a2852f55f4f98407fbebe59beabf4cf4fc297c337e6382699277f 1.37kB / 1.37kB                                                                                    0.0s
 => => sha256:d684409386e7c775aaf25265dbaaa9792813d8a89a5e18ae61a0d644761ff2d3 3.26kB / 3.26kB                                                                                    0.0s
 => => sha256:74ba3f43cec3022bb6970ba2a7a4350adbafe10f5b519ee7ea67a513b78bb69b 9.46MB / 9.46MB                                                                                    0.4s
 => => extracting sha256:6df469f23ae176b9dea89ebf6761b862c0721143da3bbd6303b953f6ab2091f1                                                                                         0.5s
 => => extracting sha256:7e979fe76393e15203b15743ea2e37a46e9172f53248116bce0d545a4c5a7e91                                                                                         0.7s
 => => extracting sha256:6c9b5f8b63cb27e4b5bea60cb5c622bc78b29181d906f19c8d5efd8aaeeaef4d                                                                                         0.0s
 => => extracting sha256:74ba3f43cec3022bb6970ba2a7a4350adbafe10f5b519ee7ea67a513b78bb69b                                                                                         0.3s
 => [internal] load build context                                                                                                                                                 0.4s
 => => transferring context: 12.36MB                                                                                                                                              0.3s
 => [2/3] WORKDIR /app                                                                                                                                                            0.1s
 => [3/3] COPY . .                                                                                                                                                                0.1s
 => exporting to image                                                                                                                                                            0.9s
 => => exporting layers                                                                                                                                                           0.9s
 => => writing image sha256:1b44ddcac9b01975b36d117a5f37c418bf4d0c3fd65dba592857837816378a9c                                                                                      0.0s
 => => naming to docker.io/library/sqlapp                                                                                                                                         0.0s
linuxuser@linuxvm:~/publish$

```
sudo docker images
```
linuxuser@linuxvm:~/publish$ sudo docker images
REPOSITORY   TAG       IMAGE ID       CREATED              SIZE
sqlapp       latest    1b44ddcac9b0   About a minute ago   221MB
nginx        latest    6efc10a0510f   2 days ago           142MB
linuxuser@linuxvm:~/publish$

```

```
linuxuser@linuxvm:~/publish$ sudo docker ps
CONTAINER ID   IMAGE     COMMAND                  CREATED        STATUS        PORTS                               NAMES
65ed8eab5b72   nginx     "/docker-entrypoint.…"   10 hours ago   Up 10 hours   0.0.0.0:80->80/tcp, :::80->80/tcp   appnginx
linuxuser@linuxvm:~/publish$
```
now we have nginx on port 80

sudo docker stop 65e

```
linuxuser@linuxvm:~/publish$ sudo docker stop 65ed8eab5b72
65ed8eab5b72
linuxuser@linuxvm:~/publish$ sudo docker ps
CONTAINER ID   IMAGE     COMMAND   CREATED   STATUS    PORTS     NAMES
```

sudo docker run --name sqlapp-1 -p 80:80 -d sqlapp

```
linuxuser@linuxvm:~/publish$ sudo docker run --name sqlapp-1 -p 80:80 -d sqlapp
c2fb884ecd172541b44f2fa31fd1451644369f3ddf1ae7febc9a136fa46d5b17
linuxuser@linuxvm:~/publish$ sudo docker ps
CONTAINER ID   IMAGE     COMMAND               CREATED          STATUS          PORTS                               NAMES
c2fb884ecd17   sqlapp    "dotnet sqlapp.dll"   22 seconds ago   Up 21 seconds   0.0.0.0:80->80/tcp, :::80->80/tcp   sqlapp-1
linuxuser@linuxvm:~/publish$

```

Public IP = our sql app
168.63.57.194

??? Open question: Where is the base image

mcr.microsoft.com/dotnet/aspnet:6.0

is it depends on publish settings ?

```
 sudo docker images
REPOSITORY   TAG       IMAGE ID       CREATED          SIZE
sqlapp       latest    1b44ddcac9b0   13 minutes ago   221MB
nginx        latest    6efc10a0510f   2 days ago       142MB
```

## If you have made a mistake

remove publish dir, copy new + Dockerfile

sudo docker stop c2f

sudo docker rm c2f

sudo docker image rm sqlapp

sudo docker build -t sqlapp .

sudo docker run --name sqlapp-1 -p 80:80 -d sqlapp

```command
linuxuser@linuxvm:~$ ls
publish
linuxuser@linuxvm:~$ sudo docker ps
CONTAINER ID   IMAGE     COMMAND               CREATED          STATUS          PORTS                               NAMES
c2fb884ecd17   sqlapp    "dotnet sqlapp.dll"   37 minutes ago   Up 37 minutes   0.0.0.0:80->80/tcp, :::80->80/tcp   sqlapp-1
linuxuser@linuxvm:~$ sudo docker stop c2f
c2f
linuxuser@linuxvm:~$ sudo docker rm c2f
c2f
linuxuser@linuxvm:~$ sudo docker image rm sqlapp
Untagged: sqlapp:latest
Deleted: sha256:1b44ddcac9b01975b36d117a5f37c418bf4d0c3fd65dba592857837816378a9c
linuxuser@linuxvm:~$ cd publish/
linuxuser@linuxvm:~/publish$ sudo docker build -t sqlapp .
 => => naming to docker.io/library/sqlapp                                                                                          
linuxuser@linuxvm:~/publish$ sudo docker run --name sqlapp-1 -p 80:80 -d sqlapp
36741c03f741ad2001b8c0d7121162963bd76c7b79c0a5a9862f3b0bae78fdd1
linuxuser@linuxvm:~/publish$
```

## The need for a registry

## Lab - Azure Container Registry

Create container registry

appregistry3100

appregistry3100.azurecr.io

Goto appregistry3100 | Repositories

it is empty

Goto appregistry3100 | Access keys

Enable Admin User => you have user name appregistry3100 and passwords

## Pushing an image to the Azure container registry

Install the Azure CLI on Linux

<https://learn.microsoft.com/en-us/cli/azure/install-azure-cli-linux?pivots=apt>

```
 Warning

Ubuntu 20.04 (Focal Fossa) and 20.10 (Groovy Gorilla) include an azure-cli package with version 2.0.81 provided by the universe repository. This package is outdated and not recommended. If this package is installed, remove the package before continuing by running the command sudo apt remove azure-cli -y && sudo apt autoremove -y. See Ubuntu package management or ask ubuntu for more information on apt remove.
```

sudo apt remove azure-cli -y && sudo apt autoremove -y

### Step-by-step installation instructions to install the Azure CLI.

Get packages needed for the install process:

```
sudo apt-get update
sudo apt-get install ca-certificates curl apt-transport-https lsb-release gnupg
```

Download and install the Microsoft signing key:

```
sudo mkdir -p /etc/apt/keyrings
curl -sLS https://packages.microsoft.com/keys/microsoft.asc |
    gpg --dearmor |
    sudo tee /etc/apt/keyrings/microsoft.gpg > /dev/null
sudo chmod go+r /etc/apt/keyrings/microsoft.gpg
```

Add the Azure CLI software repository:

```
AZ_REPO=$(lsb_release -cs)
echo "deb [arch=`dpkg --print-architecture` signed-by=/etc/apt/keyrings/microsoft.gpg] https://packages.microsoft.com/repos/azure-cli/ $AZ_REPO main" |
    sudo tee /etc/apt/sources.list.d/azure-cli.list
```

Update repository information and install the azure-cli package:

```
sudo apt-get update
sudo apt-get install azure-cli
```

### Use Azure CLI to push images to Azure

login to appregistry3100 / appregistry3100.azurecr.io

```command
sudo az acr login --name appregistry3100 --username appregistry3100 --password AZREPOPASS

sudo docker tag sqlapp appregistry3100.azurecr.io/sqlapp

sudo docker push appregistry3100.azurecr.io/sqlapp
```

Goto appregistry3100 | Repositories

Observe the image in the repo

## Azure Container Instances

1) Easy deploy
2) No need to manage infrastructure
3) Azure containers can also get **Public IP and DNS names**
4) Persist data using **Azure file shares**

appregistry3100 | Repositories

sqlapp

Create container instance (service)

Container name: appinstance

Image source
* Quickstart images
* Azure Container Registry
* Other registry

Azure Container Registry

We can pick-up container from Azure Container Registry **because** we have **enabled Admin User in registry Access Keys**

Networking - Expose Port 80

Microsoft.ContainerInstances-20230415145017

appinstance | Containers

Logs

Public Ip = our site

20.54.23.204

## Multi-stage builds

```
sudo docker images
REPOSITORY                          TAG       IMAGE ID       CREATED        SIZE
appregistry3100.azurecr.io/sqlapp   latest    cb9464ed8f75   13 hours ago   221MB
sqlapp                              latest    cb9464ed8f75   13 hours ago   221MB
nginx                               latest    6efc10a0510f   3 days ago     142MB
```

Size: 221MB

Image = runtime and app

Try to decrease size of image

Multi-stage build:

* copy entire project without building it and build it on the server using docker

* when the build is complete - use it as a part of the image.

Dockerfile in the same location, where is csproj

```docker
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /source

COPY *.csproj ./
RUN dotnet restore

COPY . .
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /source/out .
EXPOSE 80
ENTRYPOINT [ "dotnet", "sqlapp.dll" ]
```

Copy source

??? Open question: no need of sln file ???

MSB4018: The "ResolvePackageAssets" task failed unexpectedly.

Issue: error MSB4018: The "ResolvePackageAssets" task failed unexpectedly. [/source/sqlapp.csproj]

Solution: Add file 

.dockerignore

```
# directories
**/bin/
**/obj/
**/out/

# files
Dockerfile*
**/*.trx
**/*.md
**/*.ps1
**/*.cmd
**/*.sh
```

```bash
linuxuser@linuxvm:~/source/sqlapp$ sudo docker build -t sqlapp-new .
...
 => => writing image sha256:a132a7cdcbff88d18354d016a21d38c4b9afdc7f824685b51de87dd66c7398fc                                                                                                                                          0.0s
 => => naming to docker.io/library/sqlapp-new           

```

Stop old run new image

* sudo docker ps
* sudo docker stop 367
* sudo docker images
* sudo docker run --name sqlapp-2 -p 80:80 -d sqlapp-new
* sudo docker ps
```
linuxuser@linuxvm:~/source/sqlapp$ sudo docker ps
CONTAINER ID   IMAGE     COMMAND               CREATED        STATUS        PORTS                               NAMES
36741c03f741   sqlapp    "dotnet sqlapp.dll"   15 hours ago   Up 15 hours   0.0.0.0:80->80/tcp, :::80->80/tcp   sqlapp-1
linuxuser@linuxvm:~/source/sqlapp$ sudo docker stop 367
367
linuxuser@linuxvm:~/source/sqlapp$ sudo docker images
REPOSITORY                          TAG       IMAGE ID       CREATED          SIZE
sqlapp-new                          latest    a132a7cdcbff   11 minutes ago   221MB
appregistry3100.azurecr.io/sqlapp   latest    cb9464ed8f75   15 hours ago     221MB
sqlapp                              latest    cb9464ed8f75   15 hours ago     221MB
nginx                               latest    6efc10a0510f   3 days ago       142MB
linuxuser@linuxvm:~/source/sqlapp$ sudo docker run --name sqlapp-2 -p 80:80 -d sqlapp-new
c5817e68884184fb275908002a0da2367b8f2cc298aa5128971b7732554541bd
linuxuser@linuxvm:~/source/sqlapp$ sudo docker ps
CONTAINER ID   IMAGE        COMMAND               CREATED          STATUS          PORTS                               NAMES
c5817e688841   sqlapp-new   "dotnet sqlapp.dll"   11 seconds ago   Up 10 seconds   0.0.0.0:80->80/tcp, :::80->80/tcp   sqlapp-2
linuxuser@linuxvm:~/source/sqlapp$

```

The size of the image is the same, we just build from the source

## Azure Container Groups

1-st container = application, 2-nd container = database

Need deploy together = use Azure Container Groups

1) Collection of containers on the same host
2) Shared life cycle, resources, local network, storage resources
3) Deployment via Resource Manager template or YAML file
4) Persist data via Azure File shares

## Setting up our application against MySQL database

mysqlserver1100 | Connect

Add Client IP  to allow connectivity using any local client tools like MySQL workbench, VS Code and etc.

"Server=mysqlserver1100.mysql.database.azure.com; Port=3306; UserID=sqladmin; Password= ; Database=appdb; SslMode=Required;"

## Deploying a MySQL database container

linuxvm | Networking

Add inbound security rule

Service: MySQL

AllowAnyMySQLInbound_Port3306

sudo docker ps

sudo docker run --name=mysql-instance -p 3306:3306 --restart on-failure -d -e MYSQL_ROOT_PASSWORD={PASSWORD} mysql

-e = environment variable

```
linuxuser@linuxvm:~$ sudo docker ps
linuxuser@linuxvm:~$ sudo docker run --name=mysql-instance -p 3306:3306 --restart on-failure -d -e MYSQL_ROOT_PASSWORD={PASSWORD} mysql
Unable to find image 'mysql:latest' locally
latest: Pulling from library/mysql
328ba678bf27: Pull complete
...
148dcef42e3b: Pull complete
Digest: sha256:f496c25da703053a6e0717f1d52092205775304ea57535cc9fcaa6f35867800b
Status: Downloaded newer image for mysql:latest
60da6aa067ef264cea459706c741039321af96b2ecfc45f85011cfdc5e332049
linuxuser@linuxvm:~$ sudo docker ps
```

Run **mysql** command:

* sudo docker exec -it mysql-instance **mysql** -uroot -p

* -it = interaction mode

* -uroot = use root, -p = ask for password

```
sudo docker exec -it mysql-instance mysql -uroot -p

Enter password:
Welcome to the MySQL monitor.  Commands end with ; or \g.
Your MySQL connection id is 8
Server version: 8.0.32 MySQL Community Server - GPL

Copyright (c) 2000, 2023, Oracle and/or its affiliates.

Oracle is a registered trademark of Oracle Corporation and/or its
affiliates. Other names may be trademarks of their respective
owners.

Type 'help;' or '\h' for help. Type '\c' to clear the current input statement.

mysql> show databases
    -> ;
+--------------------+
| Database           |
+--------------------+
| information_schema |
| mysql              |
| performance_schema |
| sys                |
+--------------------+
4 rows in set (0.01 sec)

```

Workbench -> New cn, linuxvm, 168.63.57.194

## Creating a custom MySQL image

01.sql

```sql
CREATE TABLE Products
(
	ProductId int,
	ProductName varchar(1000),
	Quantity int
);

INSERT INTO Products(ProductId, ProductName, Quantity) VALUES (0, 'MySql', 0), (1, 'Mobile', 100), (2, 'Laptop', 200), (3, 'Tabs', 300);
```

Dockerfile

```dockerfile
FROM mysql AS base
ENV MYSQL_ROOT_PASSWORD=AzureAzure@1!
ENV MYSQL_DATABASE=appdb

COPY 01.sql /docker-entrypoint-initdb.d/
```

remove previous mysql:
* sudo docker stop 60da6aa067ef
* sudo docker ps
* sudo docker rm 60da6aa067ef

sudo docker build -t mysql-custom-image .

sudo docker run -d -p 3306:3306 --name appsql mysql-custom-image

sudo docker exec -it appsql bash

mysql -uroot -p

```
linuxuser@linuxvm:~/MySqlCustom$ sudo docker build -t mysql-custom-image .
...
linuxuser@linuxvm:~/MySqlCustom$ sudo docker run -d -p 3306:3306 --name appsql mysql-custom-image
c0cf1efb53d5045d7df854f6056c36e21ff0ed71b6ea2ce36661ccaf75456794
linuxuser@linuxvm:~/MySqlCustom$ sudo docker ps
CONTAINER ID   IMAGE                    COMMAND                  CREATED          STATUS          PORTS                                                                                            NAMES
c0cf1efb53d5   mysql-custom-image       "docker-entrypoint.s…"   16 seconds ago   Up 15 seconds   0.0.0.0:3306->3306/tcp, :::3306->3306/tcp, 33060/tcp                                             appsql
...
```

```
mysql> show databases
    -> ;
+--------------------+
| Database           |
+--------------------+
| appdb              |
| information_schema |
| mysql              |
| performance_schema |
| sys                |
+--------------------+
5 rows in set (0.00 sec)

mysql> use appdb;
Reading table information for completion of table and column names
You can turn off this feature to get a quicker startup with -A

Database changed
mysql> show tables;
+-----------------+
| Tables_in_appdb |
+-----------------+
| Products        |
+-----------------+
1 row in set (0.00 sec)

mysql> SELECT * FROM Products;
+-----------+-------------+----------+
| ProductId | ProductName | Quantity |
+-----------+-------------+----------+
|         0 | MySql       |        0 |
|         1 | Mobile      |      100 |
|         2 | Laptop      |      200 |
|         3 | Tabs        |      300 |
+-----------+-------------+----------+
4 rows in set (0.00 sec)

```

## Check the application is connecting to MySQL container

```cs
        private MySqlConnection GetConnection()
        {
            return new MySqlConnection("Server=168.63.57.194; Port=3306; UserID=root; Password={PASSWORD}; Database=appdb; SslMode=Required;");
        }
```
## Deploying the custom MySQL container

appregistry3100 | Access keys 

Check password

```
sudo az acr login --name appregistry3100 --username appregistry3100 --password mg4...+q

sudo docker tag mysql-custom-image appregistry3100.azurecr.io/mysql-custom-image

sudo docker push appregistry3100.azurecr.io/mysql-custom-image
```

appregistry3100 | Repositories

Create container instance

mysql-instance

20.105.125.202 (check VS connection)

Azure Container Registry

Change port 80 -> 3306

mysql-instance | Containers -> Connect -> bash

mysql -uroot -p

show databases;

## Let's deploy an Azure Container Group

Deploy with localhost cn

```cs
        private MySqlConnection GetConnection()
        {
            return new MySqlConnection("Server=localhost; Port=3306; UserID=root; Password=; Database=appdb; SslMode=Required;");
        }
```

stop old containers and remove their images

copy publish dir

```
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY . .
EXPOSE 80
ENTRYPOINT [ "dotnet", "sqlapp.dll" ]
```

sudo docker build -t sqlapp .

sudo docker tag sqlapp appregistry3100.azurecr.io/sqlapp

delete old sqlapp from repo

sudo docker push appregistry3100.azurecr.io/sqlapp


```yml
apiVersion: 2019-12-01
location: northeurope
name: SQLAppGroup
properties:
  containers: 
  - name: db
    properties:
      image: appregistry3100.azurecr.io/mysql-custom-image:latest
      resources:
        requests:
          cpu: 1
          memoryInGb: 1.5
      ports:
      - port: 3306
  - name: web
    properties:
      image: appregistry3100.azurecr.io/sqlapp:latest
      resources:
        requests:
          cpu: 1
          memoryInGb: 1.5
      ports:
      - port: 80          
  osType: Linux
  ipAddress:
    type: Public
    ports:
    - protocol: tcp
      port: 80
  imageRegistryCredentials:
    - server: appregistry3100.azurecr.io
      username: appregistry3100
      password: mg4...+q
type: Microsoft.ContainerInstance/containerGroups
```

Azure Shell

Powershell

You have no storage mounted

Storage account dickerstoragelog5999 in docker-grp

```
az container create --resource-group docker-grp --file deployment.yml
```

<details>

<summary>Log</summary>

```json
PS /home/dmytro> az container create --resource-group docker-grp --file deployment.yml
{
  "extendedLocation": null,
  "id": "/subscriptions/a77b1bf0-3869-4d3f-9d30-42037952d048/resourceGroups/docker-grp/providers/Microsoft.ContainerInstance/containerGroups/SQLAppGroup",
  "identity": null,
  "kind": null,
  "location": "northeurope",
  "managedBy": null,
  "name": "SQLAppGroup",
  "plan": null,
  "properties": {
    "containers": [
      {
        "name": "db",
        "properties": {
          "environmentVariables": [],
          "image": "appregistry3100.azurecr.io/mysql-custom-image:latest",
          "instanceView": {
            "currentState": {
              "detailStatus": "",
              "startTime": "2023-04-17T15:37:44.228Z",
              "state": "Running"
            },
            "events": [
              {
                "count": 1,
                "firstTimestamp": "2023-04-17T15:37:12Z",
                "lastTimestamp": "2023-04-17T15:37:12Z",
                "message": "pulling image \"appregistry3100.azurecr.io/mysql-custom-image@sha256:497068e5eaf3ce23f363cb3c84edfeb61fd061c76c2b72acca4a98b08400afdd\"",
                "name": "Pulling",
                "type": "Normal"
              },
              {
                "count": 1,
                "firstTimestamp": "2023-04-17T15:37:33Z",
                "lastTimestamp": "2023-04-17T15:37:33Z",
                "message": "Successfully pulled image \"appregistry3100.azurecr.io/mysql-custom-image@sha256:497068e5eaf3ce23f363cb3c84edfeb61fd061c76c2b72acca4a98b08400afdd\"",
                "name": "Pulled",
                "type": "Normal"
              },
              {
                "count": 1,
                "firstTimestamp": "2023-04-17T15:37:44Z",
                "lastTimestamp": "2023-04-17T15:37:44Z",
                "message": "Started container",
                "name": "Started",
                "type": "Normal"
              }
            ],
            "restartCount": 0
          },
          "ports": [
            {
              "port": 3306
            }
          ],
          "resources": {
            "requests": {
              "cpu": 1.0,
              "memoryInGB": 1.5
            }
          }
        }
      },
      {
        "name": "web",
        "properties": {
          "environmentVariables": [],
          "image": "appregistry3100.azurecr.io/sqlapp:latest",
          "instanceView": {
            "currentState": {
              "detailStatus": "",
              "startTime": "2023-04-17T15:37:43.961Z",
              "state": "Running"
            },
            "events": [
              {
                "count": 1,
                "firstTimestamp": "2023-04-17T15:37:12Z",
                "lastTimestamp": "2023-04-17T15:37:12Z",
                "message": "pulling image \"appregistry3100.azurecr.io/sqlapp@sha256:255a7fd621cc7f4847ffdef7dd7d3a51c1a77f423bdcf8b67d2db846c5467c69\"",
                "name": "Pulling",
                "type": "Normal"
              },
              {
                "count": 1,
                "firstTimestamp": "2023-04-17T15:37:33Z",
                "lastTimestamp": "2023-04-17T15:37:33Z",
                "message": "Successfully pulled image \"appregistry3100.azurecr.io/sqlapp@sha256:255a7fd621cc7f4847ffdef7dd7d3a51c1a77f423bdcf8b67d2db846c5467c69\"",
                "name": "Pulled",
                "type": "Normal"
              },
              {
                "count": 1,
                "firstTimestamp": "2023-04-17T15:37:43Z",
                "lastTimestamp": "2023-04-17T15:37:43Z",
                "message": "Started container",
                "name": "Started",
                "type": "Normal"
              }
            ],
            "restartCount": 0
          },
          "ports": [
            {
              "port": 80
            }
          ],
          "resources": {
            "requests": {
              "cpu": 1.0,
              "memoryInGB": 1.5
            }
          }
        }
      }
    ],
    "imageRegistryCredentials": [
      {
        "server": "appregistry3100.azurecr.io",
        "username": "appregistry3100"
      }
    ],
    "initContainers": [],
    "instanceView": {
      "events": [],
      "state": "Running"
    },
    "ipAddress": {
      "ip": "40.127.216.242",
      "ports": [
        {
          "port": 80,
          "protocol": "TCP"
        }
      ],
      "type": "Public"
    },
    "isCustomProvisioningTimeout": false,
    "osType": "Linux",
    "provisioningState": "Succeeded",
    "provisioningTimeoutInSeconds": 1800,
    "sku": "Standard"
  },
  "resourceGroup": "docker-grp",
  "sku": null,
  "tags": null,
  "type": "Microsoft.ContainerInstance/containerGroups"
}
```

</details>

All Resources

SQLAppGroup

Public IP = our app

## What is Azure Kubernetes

## Lab - Deploying an Azure Kubernetes cluster

### Pod

^ used to group containers

* gets shared storage and network resources

Pod 10.0.0.16 = Container (port 8080) + Container (port 8090) + ...

### Deployment

* Declarative way to describe the state of Pods and ReplicaSets

* Deployment controller is used to ensure the desired state of environement is always met

## Lab - Azure Kubernetes - Deployment - NGINX

Create

Azure Kubernetes Service (AKS)

Create Kubernetes cluster

kubernetes-grp

Cluster configuration: Dev/Test

Kube cluster name: appcluster

Connect your cluster to an Azure Container Registry to enable seamless deployments from a private image registry.

Integrations Tab - Container Registry: appregistry3100

---

<details>
<summary>Issue qith quotas</summary>

The maximum node count you can select is 0 due to the remaining quota in the selected subscription (2 cores).

Additional information: I assume this may not be an AKS limitation but an Azure limitation. This is based upon core quota's that you have for a subscription in specific regions. You can request additional quota by placing a request here
https://learn.microsoft.com/en-us/azure/azure-supportability/resource-manager-core-quotas-request

az vm list-usage --location "East US" -o table

```
az vm list-usage --location "East US" -o table
```

```
az vm list-usage --location "North Europe" -o table
Name                                      CurrentValue    Limit
----------------------------------------  --------------  -------
Availability Sets                         0               2500
Total Regional vCPUs                      2               4
Virtual Machines                          1               25000
```
---

cannot increase quota with basic subscitpion

Check resource usage against limits

<https://learn.microsoft.com/en-us/azure/networking/check-usage-against-limits>

### Request a quota increase

<https://learn.microsoft.com/en-us/azure/quotas/quickstart-increase-quota-portal>

The maximum node count you can select is 0 due to the remaining quota in the selected subscription (2 cores).

</details>

---

appcluster

Create

Add with YAML

```yml
apiVersion: apps/v1
kind: Deployment
metadata:
  name: nginx-deployment
  labels:
    app: nginx
spec:
  replicas: 1
  selector:
    matchLabels:
      app: nginx
  template:
    metadata:
      labels:
        app: nginx
    spec:
      containers:
      - name: nginx
        image: nginx
        ports:
        - containerPort: 80
```

=> Deployment is created (nginx-deployment)

Create a service to access nginx container

appcluster | Services and ingresses -> Add with YAML

```yml
apiVersion: v1
kind: Service
metadata:
  name: nginxservice
spec:
  selector:
    app: nginx
  ports:
    - protocol: TCP
      port: 80
      targetPort: 80
  type: LoadBalancer
```

LoadBalancer = has external IP address = nginx site

## Lab - Deploying our application on Kubernetes

appcluster | Services and ingresses

delete nginxservice

appcluster | Workloads

delete nginx-deployment

Change cn: Server=mysql, because name oof our service in yml is "mysql"

```cs
        private MySqlConnection GetConnection()
        {
            return new MySqlConnection("Server=mysql; Port=3306; UserID=root; Password=; Database=appdb; SslMode=Required;");
        }
```

```
sudo docker build -t sqlapp .
sudo docker tag sqlapp appregistry3100.azurecr.io/sqlapp
sudo docker push appregistry3100.azurecr.io/sqlapp
```

appregistry3100 | Repositories

* mysql-custom-image
* sqlapp

sql deployment - appcluster | Workloads

```yml
apiVersion: apps/v1
kind: Deployment
metadata:
  name: mysql
spec:
  selector:
    matchLabels:
      app: mysql
  strategy:
    type: Recreate
  template:
    metadata:
      labels:
        app: mysql
    spec:
      containers:
      - image: appregistry3100.azurecr.io/mysql-custom-image:latest
        name: mysql
        ports:
        - containerPort: 3306
          name: mysql
```

Sql Service - appcluster | Services and ingresses

```yml
apiVersion: v1
kind: Service
metadata:
  name: mysql
spec:
  ports:
  - port: 3306
  selector:
    app: mysql
  clusterIP: None
```

Application: Deployment - appcluster | Workloads

```yml
apiVersion: apps/v1
kind: Deployment
metadata:
  name: sqlapp
spec:
  selector:
    matchLabels:
      app: sqlapp
  template:
    metadata:
      labels:
        app: sqlapp
    spec:
      containers:
      - image: appregistry3100.azurecr.io/sqlapp:latest
        name: sqlapp
        ports:
        - containerPort: 80
          name: sqlapp
```

Application: Service - appcluster | Services and ingresses

```yml
apiVersion: v1
kind: Service
metadata:
  name: appservice
spec:
  selector:
    app: sqlapp
  ports:
    - protocol: TCP
      port: 80
      targetPort: 80
  type: LoadBalancer
```
appservice has public IP = our site

## Quiz 4: Short Quiz

## Misc

Azure Resource Mover

"I understand that tools and scripts associated with moved resources will not work until I update them to use new resource IDs"
