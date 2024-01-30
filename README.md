# CS479/579 Reverse Engineering at NMSU
## Summary
This repo holds malware samples from "Practical Malware Analysis".
Malware samples will be added following the NMSU spring 2024 reverse engineering course. 

## System setup
Host:
The host system is an old Windows 10 machine with I7 Intel processor and 12 GB RAM. The host is disconnected from the internet and transfers data only through a USB drive. 

VM:
The VM machine uses the Microsoft distribution of Windows VM with a virtual box. The VM will stay active until April 9, 2024.
URL: https://developer.microsoft.com/en-us/windows/downloads/virtual-machines/

## Isolation
The VM is isolated from the host machine, and both the host machine and the virtual machine will stay isolated from the network. This ensures that if the virus somehow breaks out the
VM, the virus will still be contained inside the host machine. 

## Windows Defender:
Windows Defender can detect and delete viruses on the machine. To prevent Windows Defender from removing virus samples, this repo followings instructions from lab to disable windows defender. 

Steps: 
Boot system in safe mode
Add new entries to the registry. 
Boot system in normal mode
Disable task under task scheduler. 

Tools:
Flare VM
  A collection of software installation scripts that helps maintain VM environment for malware testing. (*note may contain malware)
IDA (Interactive Disassembler) education.
  A paid binary reverse engineering tool with support for microprocessors. 
  It seems to be able to generate source code from machine code, although the original comments and variable names will be missing. 
