## Crack 1
Very simple program. There is a string compare with user commandline input and a contant string named FIRST_PASSWORD.
The content of the string was "picklecucumberl337".
Note this passkey have no other variants. 

Procdure:  
Open in gridra  
find string compare  
find the value of the constant string.  

keygen (python)
```
print("picklecucumberl337");
```

## Crack 2
This program is the exact same one as the first one.
The string content was "artificialtree"
same procedure as first one. 

keygen (python)
```
print("artificialtree");
```

## Crack 3
Varibles:
```
int inputSize
static string FIRST_PASSWORD1  
static string First_PASSWORD2  
allocated string FIRST_PASSWORD1 + First_PASSWORD2  
  
bool pass1EqualInput  
bool pass2EqualInput  
bool passNotEqualInput  
```
key requirement:
```
inputSize != 0 && !passNotEqualInput && !pass1EqualInput && pass2EqualInput
```

A lot of smokes in this program, but the concatnation of 2 string should give the correct result.  
  
Procedure:  
Open Ghidra  
Find FIRST_PASSWORD1
Find First_PASSWORD2
Concat the 2 password

footnote:  
Ghidra thinks First_PASSWORD2 have type DAT, that need to be converted back to string type. 

Keygen:
```
print("strawberrykiwi");
```

## Crack 4
This program use commandine arugment as input.   
use commandline substution on keygen:  
./control_flow_1 "$(python keygen.py)"  
https://superuser.com/questions/461946/can-i-use-pipe-output-as-a-shell-script-argument

Program structure:  
main:  
```
char ** inputArray
char * charKey = input[1];
int inputLen = len(charKey);

if (inputLen >= 0x10) {
	rock(charKey);
}
```
program exit with error if string lenght is smaller than 16

rock:
```
char * charKey
char rockKey = charKey[3]

if (rockKey = 2) {
	paper(charKey);
}
```
charKey\[3\] must be '2'  

paper:  
```
char * charKey
char paperKey = charKey[7] - '%'

if (paperKey < '.') {
	someValue = 1 left shift by (paperKey & 0x3f)
	if (someValue & 0x280110000000) == 0) {
		if ((someValue & 1) != 0) {
			scissors(charKey);
		}
	}
}
```
Given (someValue & 1) != 0, the last digit of someValue must be 1. Given someValue & 0x280110000000 == 0, the first few digits of someValue must be 0.   
Given someValue is 1 shifted by a number, that number must 0 to fullfill the previous criterias. Thus paperKey & 0x3f must be 0. Given 0x3f have all 1 in lower digit, paperKey must be all 0.  
So charKey\[7\] must be equal to '%'.  

scissors: 
```
char * charKey
char scissorsKey = charKey[0]

if (scissorsKey == 0x41) {
	lizard(charKey);
}
```
charKey\[0\] must be 0x41, which is 'A'  

lizard:
```
char * charkey
char lizardKey = charKey[1]

if (lizardKey == 0x36) {
	spock(charKey);
}
```
charKey\[1\] must be '6'.  

spock:
```
char * charkey
char spockKey = charKey[15]

if (spockKey == '*') {
	win();
}
```
charKey\[15\] must be '*'.  

win:
``` 
exit(0);
```

Key requirement:  
string lenghth is larger than or equal to 16  
charKey\[3\] must be '2'  
So charKey\[7\] must be '%'. 
charKey\[0\] must be 'A'  
charKey\[1\] must be '6'.  
charKey\[15\] must be '*'.  

keygen:
``` 
import random
import string

key = ''.join(random.choices(string.ascii_uppercase + string.digits, k=16))
key = key[:3] + '2' + key[4:]
key = key[:7] + '%' + key[8:]
key = 'A' + key[1:]
key = key[:1] + '6' + key[2:]
key = key[:15] + '*'

print(key)
```

## Crack 5
Parameter input, see above.  

main:  
same as last one, size must be at least 16.  
calls rock.  

rock:  
key\[6\] == 'Y'  
calls paper.  

paper:  
exactly the same as last one.
key\[8\] == '#'  
calls scissors. 

scissors:  
key\[10\] == 'A'  
calls lizard.  

lizard:  
key\[13\] == '6'  
calls spock.  

spock:  
key\[11\] == '*'  
calls win.  

win:
exit(0)  

key gen:  
```
import random
import string

key = ''.join(random.choices(string.ascii_uppercase + string.digits, k=16))
key = key[:6] + 'Y' + key[7:]
key = key[:8] + '#' + key[9:]
key = key[:10] + 'A' + key[11:]
key = key[:13] + '6' + key[14:]
key = key[:11] + '*' + key[12:]

print(key)
```

## Crack 6
main:  
A little bit different from last one, size must be exactly 16.  
calls rock.  

rock:  
```
charKey[A] + charKey[B] - charKey[C] = charKey[D]
```

paper:  
```
charKey[D] ^ charKey[E] < 3
```

scissors:  
```
charKey[I] == charKey[j]
```

Lizard:
```
charKey[F] ^ charKey[E] >= 4
```

Spock:
```
charKey[F] != charKey[G]
charKey[J] ^ charKey[F] ^ charKey[G] != (charKey[I] < 3)
```

constant variable:  
A = 1, B = 3, C = 5, D = 6, E = 7, F = 8, G = 9, I = 10, H = 11, J = 12  

Summary of rules:  
```
charKey[1] + charKey[3] - charKey[5] = charKey[6]
charKey[6] ^ charKey[7] < 3
charKey[10] == charKey[12]
charKey[8] ^ charKey[7] >= 4
charKey[8] != charKey[9]
(charKey[12] ^ charKey[8] ^ charKey[9]) != (charKey[10] < 3)
```

We will be finding a keygen that generates a subset of the solution space instead of the entire solution space.  

Suppose c1 = 'A', c3 = 'C', c5 = 'B', then c6 must be 'B'    
c6 ^ c7 < 3 can be satisfied by setting c7 = 'B'  
c8 ^ c7 >= 4 can be satified by setting c8 = 'F'  
Given we are using all readable character, (c10 < 3) is always 1.  
set c10 = c12  
set c9 = 'E'
c12 ^ 'E' ^ 'F' != 1 can be satisfied by c12 = 'G'  

Particular solution of this problem:  
c1 = 'A', c3 = 'C', c5 = 'B', c6 = 'B', c7 = 'B', c8 = 'F', c9 = 'E', c10 = 'G', c12 = 'G'  

Example solution:  
0A3CdBBBFEGrG345  

KeyGen:  
```
import random
import string

key = ''.join(random.choices(string.ascii_uppercase + string.digits, k=16))
key = key[:1] + 'A' + key[2:]
key = key[:3] + 'C' + key[4:]
key = key[:5] + 'B' + key[6:]
key = key[:6] + 'B' + key[7:]
key = key[:7] + 'B' + key[8:]
key = key[:8] + 'F' + key[9:]
key = key[:9] + 'E' + key[10:]
key = key[:10] + 'G' + key[11:]
key = key[:12] + 'G' + key[13:]
print(key)
```