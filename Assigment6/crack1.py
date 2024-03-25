import random
import string

rand = random.choices(string.ascii_uppercase + string.digits, k=3)
key = "0XY0-0" + rand[0] + rand[1] + "0-00" + rand[2] + "0-0YZ0"

print(key)