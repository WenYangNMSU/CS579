# Report for win32 keypass
## Summary
Keypass is a windows 32 bit ransomeware that can be detected by windows defender and is nolonger a threat to most windows users.

Report from microsfot:
https://www.microsoft.com/en-us/wdsi/threats/malware-encyclopedia-description?Name=Ransom:Win32/Keypass&threatId=-2147196705

## Type of Malware:
Target OS: Windows Vista, 7, 8.1, 10, and 11
Installation: Requires manuel execution, virus instead of worm. 
Content type: Payload, upon execution it moves itself to another location and encrypts user files. 
Compiler: Microsoft visual C/C++

## Signiture: 
MD5: 6999c944d1c98b2739d015448c99a291
Sha256: 35b067642173874bd2766da0d108401b4cf45d6e2a8b3971d95bf474be4f6282

Reports from virus total (matched as Win32.KeyPass.bin): 
https://www.virustotal.com/gui/file/35b067642173874bd2766da0d108401b4cf45d6e2a8b3971d95bf474be4f6282/details

## Compromise Indicator
Most file extensions are changed to .pass and are encryped.
File icons are changed to the bitcoin logo.
Unable to varify if http connections were attempted.
A file named !!!KEYPASS_DECRYPTION_INFO!!!.txt" is created on the desktop

## Clues about orgin
The distributor of the virus may not be an native English speaker, as noted with several grammer errors in the "!!!KEYPASS_DECRYPTION_INFO!!!.txt" file 
The distributor uses a Switzerland email address as proxy, although this doesn't necessarily suggest that the command and control server is also located in Switzerland.
The backup email address uses .india extension. Same reasoning as above. 

## YARA rule
Thoughts:
While one could make Yara rule as comprehensive as possible, it is always possible to get around Yara rules. This is one of the reason why packers are useful for virus makers, as any kind of encryption would render yara rule completely useless. 
Thus while one could use Yara rule to detect virus, it would be unwise to completely rely on it. In fact, devoting too much resource into making Yara rule would be proven futile unless the target is completely incapable of adapting. (ie, worms)

The following Yara rule attempts to identify the string "!!!KEYPASS_DECRYPTION_INFO!!!" in utf-16 format
```
import "pe"
rule keypass_string : keypass
{
	meta: 
		description: "find !!!KEYPASS_DECRYPTION_INFO!!! in utf-16 format"
		threat_level = 3
	
	strings:
		$text = { 00 21 00 21 00 21 00 4b 00 45 00 59 00 50 00 41 00 53 00 53 00 5f 00 44 00 45 00 43 00 52 00 59 00 50 00 54 00 49 00 4f 00 4e 00 5f 00 49 00 4e 00 46 00 4f 00 21 00 21 00 21 }
		
	condition:
		$text and pe.is_pe and filesize > 2.8MB and filesize < 3MB
}
```
Note: windows uses utf-16 encoding, and utf-16 only support bytes in multiple of 2. (utf-8 supports single byte character)

It's unlikely that this rule would generate false positives, since it only detects an execuable containing a petty unique string that happens to be between 2.8MB and 3MB. 
However, it is possible by pure chance that some random program just happened to contain those bytes in this sequence, the probablity for this to happen with an random distribution is 1 in (2^(8&ast;29)) or 6.9&ast;10^69.

It's easy to get around of this rule by simply padding the file with 0s.

## Additional information:
Virus report by Orkhan Mamedov and Fedor Sinitsyn (2018):
https://securelist.com/keypass-ransomware/87412/

According to the report, the ransomware uses AES-256 symmetric encryption algorthm and relyings on internet connection to sent out the information to the server.
However if the device is offline, the ransomeware uses a default key and userID, which makes decryption trivial. 

Even if the ransomeware randomly generate a key when the device is offline, it should still be possible to retrive the key, since it must be store somewhere on the computer. 

This flaw can be avoided if the ransomware uses a asymmetric encryption algorthm(ie, RSA) where only the public key is known by the software. And the private key is still required for decryption and can not be obtained from the software or the source code.
One downside of this decision would be that all infested device would share the same private key, although this issue can be mitigated if the software randomly pick from a set of pre determined public/private keypairs. 

