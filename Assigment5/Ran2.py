import sys

fileName = sys.argv[1]
outName = fileName + ".txt";
with open(fileName, "rb") as inFile:
    with open(outName, "wb") as outFile: 
        counter = 0
        while (byte := inFile.read(1)):
            outFile.write((int.from_bytes(byte, "big") ^ [0x31, 0x33, 0x33, 0x37][counter % 4]).to_bytes(1, "big"))
            counter = counter + 1
