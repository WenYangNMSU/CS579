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
```
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
```
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

## Crackme 2 Solution
To solve this crackme, you need to input username and serial number

My solution is 
```
import random
import string

rand1 = random.choices(string.ascii_uppercase, k=4)
rand2 = random.choices(string.ascii_lowercase, k=4)
username = rand2[0] + rand1[0] + rand2[1] + rand1[1] + rand2[2] + rand1[2] + rand2[3] + rand1[3]

sn = str(ord(rand2[0])) + str(ord(rand1[0])) + str(ord(rand2[1])) + str(ord(rand1[1]))
sn = sn[:8]

print(username)
print(sn)
``` 

## How I did it using Ghidra (and any other tools you used like gdb):

1. I opened the crackme in Ghidra  
2. I found the main function and noticed.  
--
main:  
username must be between 8 and 12 characters.  

from the look of it, even character is turned to lower case, odd characters are turned to uppper case.  
The serial output should always be 8 characters, since we want serial to equal to sn, and sn is input. Serial is copied from iss which is copied in a for loop with max 8 from serialstream.  
substr takes 2 input parameter, start position and end postion. I believe the usernamelength = (iVar2 + -8) \* 2 defines initial postiion. So for 8 length username, initial postion is 0, 2 for 9 lenght, 4 for 10, 6 for 11, and 8 for 12.   
The comparsion at the end of the stream seems to indicate the serial is suppose to be a number. Without futher lead, I created a brute force attack that aim to obtain a name key pair.  

```
#!/bin/bash
for i in {10000000..99999999}
do
	echo "$i"
	printf 'AAAAAAAA\n%d' "$i" | ./crackme1
	
done
```
The key turns out to be "97659765". From there we can see that 97 seems to corrspond to "a", while 65 corrspond to "A". Futher testing indicats it's only checking the first 4 characters.

## Crackme 3 Solution
To solve this crackme, you need to input username and serial number

My solution is 
```
import random
import string

rand1 = random.choices(string.ascii_uppercase, k=4)
rand2 = random.choices(string.ascii_lowercase, k=4)
username = rand2[0] + rand1[0] + rand2[1] + rand1[1] + rand2[2] + rand1[2] + rand2[3] + rand1[3]

sn = str(ord(rand2[0])) + str(ord(rand1[0])) + str(ord(rand2[1])) + str(ord(rand1[1]))
sn = sn[:8]

print(username)
print(sn)
``` 

## How I did it using Ghidra (and any other tools you used like gdb):

1. I opened the crackme in Ghidra  
2. I found the main function and noticed.  
--
The author give a hint on readme, indication the encryption is just simple xor. 
