#include <CkCrypt2.h>

void ChilkatSample(void)
    {
    // This example requires the Chilkat API to have been previously unlocked.
    // See Global Unlock Sample for sample code.

    CkCrypt2 crypt;

    // Specify 3DES for the encryption algorithm:
    crypt.put_CryptAlgorithm("3des");

    crypt.put_CipherMode("ecb");

    // For 2-Key Triple-DES, use a key length of 128
    // (Given that each byte's msb is a parity bit, the strength is really 112 bits).
    crypt.put_KeyLength(128);

    // Pad with zeros
    crypt.put_PaddingScheme(3);

    // EncodingMode specifies the encoding of the output for
    // encryption, and the input for decryption.
    // It may be "hex", "url", "base64", or "quoted-printable".
    crypt.put_EncodingMode("hex");

    // Let's create a secret key by using the MD5 hash of a password.
    // The Digest-MD5 algorithm produces a 16-byte hash (i.e. 128 bits)
    crypt.put_HashAlgorithm("md5");
    const char *keyHex = crypt.hashStringENC("secretPassword");

    // Set the encryption key:
    crypt.SetEncodedKey(keyHex,"hex");

    // Encrypt
    const char *encStr = crypt.encryptStringENC("The quick brown fox jumped over the lazy dog");
    std::cout << encStr << "\r\n";

    // Now decrypt:
    const char *decStr = crypt.decryptStringENC(encStr);
    std::cout << decStr << "\r\n";
    }
