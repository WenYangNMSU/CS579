### Description
This software checks 4 location in file system for the virus. It also looks for njrat.exe and windows.exe in the process.  
This program requires .net version 6.0 to run. Buildin liberary is too large.

The scan button checks for current running process and look for njrat.exe and windows.exe. It also look for copies of njrat.exe in C, startup folder, and appdata/temp. The program logs the instances found in the textbox.  
The delete button closes the found process and removes the files found.  

### video 
C:/njrat.exe was only deleted after second press of delete button. 2:49 shows the file missing. This was likely due to the computer crash from earlier. .temp file are ignored since they will be automaticly removed by the OS. 
