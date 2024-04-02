## Detecting DLL Injection
### Prove that the loader is using DLL injection. (Don't forget a relevant snapshot in Ghidra.)  

We can see import of EnumProcessModule, GetModuleBaseName, and EnumProcess from psapi.dll. This indicats that the program want to look at process list at some point.  
![func import](/Assigment7/img1.png)  
The program then finds a handle for a unknown process and writes lab12.dll into the process's memeory. The program then creates a remote thread under the process. The content of lab12.dll is passed to thread.  
![inject](/Assigment7/img2.png)  

### Identify the process that will be injected into. Seeing a string in Ghidra isn't sufficient -- explain how the process gets selected.
During the process selection process, the process goes though all current process, for each process it runs a funciton to check something. If the check value is correct, the loop ends.  
![search loop](/Assigment7/img3.png)  
Inside the function, the id of the process seems to be compared to explorer.exe. The pointer to function LoadLiberaryA was passed around to compare funciton, but inside compare funciton both inputs seems to be char pointers.  
![explorer.exe](/Assigment7/img4.png)  

### Identify the entry point of the DLL injection. Where is DllMain?
In lab12.exe, on the newly created thread (img2.png), LoadLiberaryA is called and the address containing lab12.dll is passed as parameter. Since this address does not have an file extension, LoadLiberaryA will treat it as a dll file. 
https://learn.microsoft.com/en-us/windows/win32/api/libloaderapi/nf-libloaderapi-loadlibrarya  
If the module's dll is not mapped for the calling process, the dll's dllmain is called with DLL_PROCESS_ATTACH value.  
DLL_PROCESS_ATTACH is equalent to 1, so following the dll entry point, we should call the first function inside the lab section. 
![lab section](/Assigment7/img5.png) 

### This malware does something every ______ seconds. How often, and where is the loop where that waiting happens?
Every 60,000 seconds, the program spawns a thread. This happens inside a seperate tread that's created by dllmain.  
![dll loop](/Assigment7/img6.png) 

### What does the malware do every _______ seconds?
The program creates a message box containing "Press OK to reboot", the header of the message looks like "Practical malware analysis %d". 
![dll loop](/Assigment7/img7.png) 