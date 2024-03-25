#include <stdio.h>
#include <string.h>

int main () {
	char str[8] = "7030726e";
	
	char key[100] = {0};
	int value = 0x35478;
	char buffer[100];
	for (int i = 0; i < 7; i++) {
		int temp = *(i + str) + 0x5c;
		value ^= 0;
		temp += value;
		temp ^= 4;		
		value |= 0x2e39f3;
		sprintf(buffer, "%d", temp);
		strncat(key, buffer, strlen(buffer));
		value <<= 7;
	}
	
	printf ("%s\n", key);
}