	.file	"shellcode_tester.c"
	.text
	.globl	foo
	.type	foo, @function
foo:
.LFB6:
	.cfi_startproc
	endbr64
	pushq	%rbp
	.cfi_def_cfa_offset 16
	.cfi_offset 6, -16
	movq	%rsp, %rbp
	.cfi_def_cfa_register 6
	nop
	popq	%rbp
	.cfi_def_cfa 7, 8
	ret
	.cfi_endproc
.LFE6:
	.size	foo, .-foo
	.section	.rodata
.LC0:
	.string	"rb"
.LC1:
	.string	"shellcode.S"
.LC2:
	.string	"Error opening file %s: %ld\n"
.LC3:
	.string	"Shellcode length: %ld\n"
	.align 8
.LC4:
	.string	"Error: %d bytes read in shellcode file %s\n"
	.text
	.globl	main
	.type	main, @function
main:
.LFB7:
	.cfi_startproc
	endbr64
	pushq	%rbp
	.cfi_def_cfa_offset 16
	.cfi_offset 6, -16
	movq	%rsp, %rbp
	.cfi_def_cfa_register 6
	subq	$256, %rsp
	movl	%edi, -244(%rbp)
	movq	%rsi, -256(%rbp)
	movq	%fs:40, %rax
	movq	%rax, -8(%rbp)
	xorl	%eax, %eax
	leaq	.LC0(%rip), %rax
	movq	%rax, %rsi
	leaq	.LC1(%rip), %rax
	movq	%rax, %rdi
	call	fopen@PLT
	movq	%rax, -224(%rbp)
	cmpq	$0, -224(%rbp)
	jne	.L4
	movq	-224(%rbp), %rax
	movq	%rax, %rdx
	leaq	.LC1(%rip), %rax
	movq	%rax, %rsi
	leaq	.LC2(%rip), %rax
	movq	%rax, %rdi
	movl	$0, %eax
	call	printf@PLT
	movl	$2, %eax
	jmp	.L7
.L4:
	movq	-224(%rbp), %rdx
	leaq	-208(%rbp), %rax
	movq	%rdx, %rcx
	movl	$200, %edx
	movl	$1, %esi
	movq	%rax, %rdi
	call	fread@PLT
	movl	%eax, -228(%rbp)
	movq	-224(%rbp), %rax
	movq	%rax, %rdi
	call	ftell@PLT
	movq	%rax, %rsi
	leaq	.LC3(%rip), %rax
	movq	%rax, %rdi
	movl	$0, %eax
	call	printf@PLT
	cmpl	$0, -228(%rbp)
	jne	.L6
	movl	-228(%rbp), %eax
	leaq	.LC1(%rip), %rdx
	movl	%eax, %esi
	leaq	.LC4(%rip), %rax
	movq	%rax, %rdi
	movl	$0, %eax
	call	printf@PLT
	movl	$1, %eax
	jmp	.L7
.L6:
	movq	-224(%rbp), %rax
	movq	%rax, %rdi
	call	pclose@PLT
	leaq	-208(%rbp), %rdx
	movl	$0, %eax
	call	*%rdx
	movq	%rax, -216(%rbp)
	movl	$0, %eax
.L7:
	movq	-8(%rbp), %rdx
	subq	%fs:40, %rdx
	je	.L8
	call	__stack_chk_fail@PLT
.L8:
	leave
	.cfi_def_cfa 7, 8
	ret
	.cfi_endproc
.LFE7:
	.size	main, .-main
	.ident	"GCC: (Ubuntu 11.4.0-1ubuntu1~22.04) 11.4.0"
	.section	.note.GNU-stack,"",@progbits
	.section	.note.gnu.property,"a"
	.align 8
	.long	1f - 0f
	.long	4f - 1f
	.long	5
0:
	.string	"GNU"
1:
	.align 8
	.long	0xc0000002
	.long	3f - 2f
2:
	.long	0x3
3:
	.align 8
4:
