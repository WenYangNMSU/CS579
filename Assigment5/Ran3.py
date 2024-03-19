import sys

fileName = sys.argv[1]
outName = fileName + ".txt";
with open(fileName, "rb") as inFile:
    with open(outName, "wb") as outFile: 
        counter = 1
        while (byte := inFile.read(1)):
            outFile.write((int.from_bytes(byte, "big") ^ [0x33, 0x52, 0x33, 0x56, 0x33, 0x52, 0x35][counter % 7]).to_bytes(1, "big"))
            counter = counter + 1
