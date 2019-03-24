using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;

namespace Project8.Encryption
{
    static class AsymmetricExample1
    {
        const string publicKeyFileName = "pubkey.key.xml";
        const string privateKeyFileName = "privkey.key.xml";
        const string plainTextFileName = @"encryption\plaintextsm.txt";
        const string encryptedTextFileName = "encfile.enc";

        static readonly ASCIIEncoding converter;

        static AsymmetricExample1()
        {
            converter = new ASCIIEncoding();
        }

        public static void Run()
        {
            Demo();
        }

        static void Demo()
        {
            Encrypt();
            var decrypted = Decrypt();
            Console.WriteLine("Decrypted text: ");
            Console.WriteLine(decrypted);
        }

        static void Encrypt()
        {
            var plainText = File.ReadAllText(plainTextFileName);
            Console.WriteLine("Plain text:");
            Console.WriteLine(plainText);

            var plainBytes = converter.GetBytes(plainText);

            using (RSACryptoServiceProvider encryptor = new RSACryptoServiceProvider())
            {
                Console.WriteLine($"Key exchange algorithm: {encryptor.KeyExchangeAlgorithm}");
                Console.WriteLine($"Key size: {encryptor.KeySize}");
                Console.WriteLine($"Signature algorithm: {encryptor.SignatureAlgorithm}");

                var publicKey = encryptor.ToXmlString(false);
                var privateKey = encryptor.ToXmlString(true);

                File.WriteAllText(publicKeyFileName, publicKey);
                File.WriteAllText(privateKeyFileName, privateKey);

                encryptor.FromXmlString(publicKey); // initialize the encryptor with the public key

                var encryptedBytes = encryptor.Encrypt(plainBytes, false);  // use default padding for encryption
                File.WriteAllBytes(encryptedTextFileName, encryptedBytes);
            }
        }

        static string Decrypt()
        {
            var encryptedBytes = File.ReadAllBytes(encryptedTextFileName);

            var privateKey = File.ReadAllText(privateKeyFileName);

            using (RSACryptoServiceProvider decryptor = new RSACryptoServiceProvider())
            {
                decryptor.FromXmlString(privateKey);    // use the private key to decrypt

                var decryptedBytes = decryptor.Decrypt(encryptedBytes, false);
                var decryptedText = converter.GetString(decryptedBytes);

                return decryptedText;
            }
        }
    }
}
