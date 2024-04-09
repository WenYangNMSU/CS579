### Overview
This is a dynamic analysis on a version of NjRat. The version analized here is version 0.6.2 from at least 3 years ago. Newer version of the malware appears to still been deployed by threat actors.  

### OSINT
This malware was first reported in 2012 and used by threat actors in the middle east. https://attack.mitre.org/software/S0385/. 
Newer versions of the software are still been observed as of Apirl, 2024. https://gridinsoft.com/backdoor/njrat. 
Static analysis of the software indicates it attampts to create a key in registry and communicate back to C&C. 
The program also places a copy of itself in startup folder. The program runs copys of itself as "svchost.exe". 
https://infosecwriteups.com/part1-static-code-analysis-of-the-rat-njrat-2f273408df43

### RegShot
Large amount of keys were added during program execution. Majority of those keys were related to device drivers. This is reasonable considering the virus intents to take over control of devices on the computer. 
![explorer.exe](/Assigment8/driver.png) 

The program also modfied large amount of binary under a icon key, I suspect this might be some kind of overflow attack. 
![explorer.exe](/Assigment8/icon.png) 

The program did not show up in start up folder, this could be due to the program is partially broken as indicated when the program starts up. The original file was not deleted, this is different from the static analysis on the newer version of the malware. 
![explorer.exe](/Assigment8/startup.png) 

A copy of windows.exe is added to C:\windows, this was also reported by the static analysis as a copy of the virus. 
![explorer.exe](/Assigment8/windows.png) 

Changes of many devices driver keys could be an indicator for this particular version of virus, although it requires constant comparsion between versions of registor and yields large amount of false positives. 
Computer admin could also look for windows.exe under C:\windows, since there should not be a real windows.exe file in that particular folder. 

### Fakenet
When running the program with fakenet enabled, the following message can be seen.  
![explorer.exe](/Assigment8/zaaptoo.png)  
The message under the zaaptoo request was base64 encoding for "C:\Usurs\Usur\Downloads\fakenut1.4.11\fakunet1.4.11\fakenet.exe".  

We also see tcp request from svchost.exe immidately after virus was run, this seems to corrlate with the static analysis of the program run as "scvhost.exe".  
![explorer.exe](/Assigment8/svchost.png) 

The program attempted to connect to zaaptoo.zapto.org. Http requst to the site results in DNS_PROBE_FINISHED_NXDOMAIN. Zapto can be found in linkin, it appears they are a information techology company based in Berzil that focus on bridging bussiness to bussiness convenient.  
https://www.linkedin.com/company/zapto  
The address that attackers uses seems to be down, so it is likely the attacker was abusing a legitimate service used by Zapto company. Network admin can idenfiy this version of virus by spotting request to the address "zaaptoo.zapto.org".  

