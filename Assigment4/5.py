import random
import string

key = ''.join(random.choices(string.ascii_uppercase + string.digits, k=16))
key = key[:6] + 'Y' + key[7:]
key = key[:8] + '#' + key[9:]
key = key[:10] + 'A' + key[11:]
key = key[:13] + '6' + key[14:]
key = key[:11] + '*' + key[12:]

print(key)