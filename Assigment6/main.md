## Crackme 1 Solution
To solve this crackme, you need to input password to program parameter.  

My solution is 
```
import random
import string

rand = random.choices(string.ascii_uppercase + string.digits, k=3)
key = "0XY0-0" + rand[0] + rand[1] + "0-00" + rand[2] + "0-0YZ0"

print(key)
``` 

## How I did it using Ghidra (and any other tools you used like gdb):

1. I opened the crackme in Ghidra  
2. I found the main function and noticed seven function calls.  

--
The final function called in the program was decraycray, I noticed this funciton is likely a printf function that's been encrypted using xor. 
Direct comparesion did not work, so I tried using little endian on the byte encoder. Here are the results.  

redro nI      In order  
ccus ot       to succ   
uoy dee       eed you   
iaf tsum      must fai  
ht os ,l      l, so th  
k uoy ta      at you k  
tahw wun      now what  
ot ton        not to    
n eht od      do the n  
emit txe      ext time  
ohtnA-.      .-Antho    
'D .J ny      ny J. D'  
olegnA        Angelo    
boJ dooG      Good Job  
  
This is a indication that once decraycray is called, the problem is solved. Since the program calls functions sequentially in main function, we just need to make sure program don't exit before decracray is called.   

The first function is rock, first thing we notice in the function are calls to bomb. Bomb prints some stuff then exit with error, so I assume we don't want to take that path. 

All characters must be bigger than or equal to 0, or "-".  
All characters must not between ":" and "@", includesive.
All character must not be between "Z" and "a", excludsive, and must be smaller than 'z', inclusive.  
The character length must be 19.  

Rock limited valid input charater to \[A-Za-z0-9\\-\]  

Paper:  
input\[10\] ^ input\[8\] < 10  
input\[13\] ^ input\[5\] < 10  
xor can't give negative number, so paper 1 lower is not possible state.  

input\[3\] == input\[15\] == input\[10\] ^ input\[8\] + '0'  
input\[18\] == input\[0\] == input\[13\] ^ input\[5\] + '0'  

scissors:  
input\[2\] + input\[1\] >= 171
input\[17\] + input\[16\] >= 171
input\[17\] + input\[16\] != input\[2\] + input\[1\]

cracker:  
input\[14\] + input\[4\] + input\[9\] == 135

