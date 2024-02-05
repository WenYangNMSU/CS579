all: shellcode.S shellcode_tester.c
	gcc -g shellcode_tester.c -o shellcode_test -z execstack -no-pie
	as shellcode.S -o shellcode.o
	ld shellcode.o -o shellcode --oformat=binary
	rm shellcode.o
	python3 x_shellcode.py