#!/bin/bash
for i in {10000000..10100000}
do
	echo "$i"
	printf 'ffffffff\n%d' "$i" | ./crackme1
	
done