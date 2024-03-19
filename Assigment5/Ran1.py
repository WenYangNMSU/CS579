import sys

fileName = sys.argv[1]
outName = fileName + ".txt";
with open(fileName, "rb") as inFile:
    with open(outName, "wb") as outFile: 
        while (byte := inFile.read(1)):
            outFile.write((int.from_bytes(byte, "big") ^ 0x34).to_bytes(1, "big"))
