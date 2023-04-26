However, when attempting to wsl --install - I'm getting an error 0x80370114.
Windows subsystem feature was disabled, I fixed it using these cmds below.

dism.exe /online /enable-feature /featurename:Microsoft-Windows-Subsystem-Linux /all /norestart 

dism.exe /online /enable-feature /featurename:VirtualMachinePlatform /all /norestart

Or turn on win features Virtual Machine Platform and WSL

Restart

sudo apt update && sudo apt upgrade

