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