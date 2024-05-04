## Pwntools
### Design 
We follow tutorial on https://medium.com/@two06/solving-a-simple-buffer-overflow-with-pwntools-575a37e4ddb1 for the purpose of this assigment.  
The idea is to modify rip registor though buffer overflow. We found rip offset through pwntool's cyclic module, we then changed current instruction to our shell code that's right after the rip location.  
We made the program leak some pointers and found a pointer to the begining of rip offset location. We then noticed the shell code is 32 byte away from this pointer through gdb and set rip to this memeory address.  

### what it is doing
The return instruction does not appear to be invovled in this overflow attack. I believe the program was able to modifiy rip directly through the rip offset address. 
https://reverseengineering.stackexchange.com/questions/19682/x86-64-bit-buffer-overflow-help-with-overwriting-rip  
Once rip registor is modifiy, we can make the program run whatever data we need.  
