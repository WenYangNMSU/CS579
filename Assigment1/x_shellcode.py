#!/usr/bin/env python3

with open("shellcode", "rb") as f:
    a = f.read()
    print(f"Generated shellcode is of length: {len(a)}")
    print(a.hex())
    if b"\0" in a:
        print("Warning: shellcode may not copy properly, it contains null bytes!")