# 1. 20 questions
1. What is the difference between machine code and assembly?
assembly are human readable version of machine code. There is a surjective relationship between assembly code and machine code. Hence 1 assembly code can not be mapped to multiple version of machien code for the same machine.   
<br>2. If the ESP register is pointing to memory address 0x00000000001270A4 and I execute a pushq rax instruction, what address will rsp now be pointing to?  
Top half of the RSP registor is unknown, since ESP is only half of RSP resgistor. pushq pushes 16 byte of information to stack, which should decrease stackpointer by 16. Bottom half of the RSP registor should now be 0x0000000000127094.  
<br>3. What is a stack frame?  
Stack frame is a datas tructure that stores local variables for a funciton.   
<br>4. What would you find in a data section?         
.data keeps global variable and local static variable. Variables in .data section are read/write. The size of ./data can not be changed in run time.                                                                                                        
<br>5. What is the heap used for?    
Heap is reserved memery space for data with undetermined size until run time.                                                                                                                          
<br>6. What is in the code section of a program's virtual memory space?      
Program instruction are stored in code section.                                                                                    
<br>7. What does the inc instruction do, and how many operands does it take?       
Increment increase the value of a registor by 1. It take one registor or memeory addresss as operand.                                                                               
<br>8. If I perform a div instruction, where would I find the remainder of the binary division (modulo)?              
According to "Intel® 64 and IA-32 Architectures Software Developer’s Manual", page (Vol. 2A 3-323, 919 on the pdf), the remainder can be stored in AH, DX, EDX, or RDX depending on the size of the operant. The document is linked below.
https://software.intel.com/en-us/download/intel-64-and-ia-32-architectures-sdm-combined-volumes-1-2a-2b-2c-2d-3a-3b-3c-3d-and-4                                         
<br>9. How does jz decide whether to jump or not?       
Jump when zero checks the status registor to see if the last arithmatic operation was zero (ZF flag set to 1). In x86, this is the FLAGS registor.                                                                                                            
<br>10. How does jne decide whether to jump or not? 
Note that jz and je, jnz and jne are actually the same intructions with different names. Jump when not equal checks the Zero flag on status registor and jump if last intruction did not result in 0.                                                                                                                
<br>11. What does a mov instruction do?   
Move instruction copies data from one locaton to another location.                                                                                                                       
<br>12. What does the TF flag do, and why is it useful for debugging?   
The Trap flag permit the processor in single step mode. This allows the debugger to step though the instructions.                                                                                            
<br>13. Why would an attacker want to control the RIP register inside a program they want to take control of?    
RIP registor is the instruction pointer. By modifing the RIP registor, the attacker can execute any code in the program. However RIP registor is normally inaccessable to the programmer.                                                 
<br>14. What is the ax register and how does it relate to rax?      
Ax is the lower 16 bit of the 64 bit rax registor. Ax is known as the accumaltor registor, which is used in most arithmatic operations.                                                                                               
<br>15. What is the result of the instruction xor rax, rax and where is it stored? 
Value 0 is stored in registor rax.                                                                                
<br>16. What does the leave instruction do in terms of registers to leave a stack frame?   
EBP is copied to ESP, and then top value on stack is poped to EBP.                                                                      
<br>17. What pop instruction is retn equivalent to?     
Ret pops the return instrution registor from the stack back to EIP registor. (Vol. 1 6-3, page 157 of the same document above)                                                                                                        
<br>18. What is a stack overflow?   
(It's a website where we find all our homework answers :O) Stack overflow happens when the program run out of allocated stack memory, most likely from recursive step been too deep. Note OS places a 8MB registor on stack size (modifiable), 
so program will run into stack overflow error long before the computer is actually out of memory.                                                                                                                               
<br>19. What is a segmentation fault (a.k.a. a segfault)?     
Seg fault happens when the program tries to access memeory space that's not allocated to the program.                                                                                                    
<br>20. What are the RSI and RDI registers for that gives them their name?      
RSI and RDI are known as source index and destination index respectively. They were originally used in implicative instructions that took no input parameters. (MOVEB, move from source to destination)                                                                                

# 2. Screen shot Ghidra and IDA
![Ghidra screenshot](/Assigment3/Ghidra.png)
![Ida screenshot](/Assigment3/Ida.png)

# 3. crackme solution
```
int validate_key(int input) {
	return input % 1223 == 0;
}
```
The function will return true for any integer that's a multiple of 1223. 
The scanf format string was "%d", so the functions will take any interger number as input. 

There is one interesting feature in this program. Notice the variable in_FS_OFFSET was never initialed. The function get a random value that happens to be left over from whatever the last program set.  
This value is then offsetted by 0x28 and the result is used at the end of the function to validate buffer overflow attack. Since this value is only known during run time, there is no way to predict what this value should be in a buffer overflow attack.  

# 4. Which one:
Personally perfer Ghidra for the sole reason that I can run it on my own computer. Since IDA requires internet usage and cloud computing resource which is not always avaiable. Also Ghidra is free, and free is a good price for me.   
Ida does have a hex viewer, which might be useful in certain cases. 