import random
import string

rand1 = random.choices(string.ascii_uppercase, k=4)
rand2 = random.choices(string.ascii_lowercase, k=4)
username = rand2[0] + rand1[0] + rand2[1] + rand1[1] + rand2[2] + rand1[2] + rand2[3] + rand1[3]

sn = str(ord(rand2[0])) + str(ord(rand1[0])) + str(ord(rand2[1])) + str(ord(rand1[1]))
sn = sn[:8]

print(username)
print(sn)