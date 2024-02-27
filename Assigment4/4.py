import random
import string

key = ''.join(random.choices(string.ascii_uppercase + string.digits, k=16))
key = key[:3] + '2' + key[4:]
key = key[:7] + '%' + key[8:]
key = 'A' + key[1:]
key = key[:1] + '6' + key[2:]
key = key[:15] + '*'

print(key)