## ransomware1:
key: lumpy_cactus_fruit  

it looks like each byte is XOR with 0x34, although I was not particulerly convenced that's the case since there were a lot of constance and unknown functions invovled.   
I went to a hex editor and compared the cipher text to plain text, and the results comply with this hypophysis.  

## ransomware2:
key: delicious

The decompiled code was petty messy, however, I noticed that something involving input buffer was xor with a size 4 array. The elements in the array happens to be \[1, 3, 3, 7\]. 
I went back to the hex editor and found a section filled with 0 in the plain text, what I noticed was that the corrsponding cipher text have 4 different values repeating. However the values were not the same ones as in the input array. 
I suspect that some optimization might have caused this inconsistancies, since there are a lot of unknown functions and varianbles that makes understanding the entire problem quite diffcult. 

## ransomware2:
key: delicious
hidden key: S4W4S64

From the decrypt funciton, all I could tell was something was xor with something, and the key is dependent on the position in the text. 
I was not able to find the array from the decryption method, but I found the array from hex editor. \[33, 52, 33, 56, 33, 52, 35\]

I am unsure what the hidden key was supposed to be used for. 