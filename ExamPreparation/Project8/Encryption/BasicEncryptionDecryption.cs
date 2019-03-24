using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace Project8.Encryption
{
    static class BasicEncryptionDecryption
    {

        /*
         * Encryption process:
         * 
         * Plain Text       Stream Writer       CryptoStream                  [ Stream (Readable/Writable)            ]
         *      |                 |                |                          [            |                          ]
         *      |    write to     |    write to    |  contains encrypt text   [            |                          ]
         *      | --------------> | -------------> | -----------------------> [            | Contains encrypted bytes ]
         *      |                 |                |  (optionally write to)   [            |                          ]
         *      |                 |                |                          [            |                          ]
         *      
         */     

        /*
         * Decryption process:
         * 
         * Encrypted Bytes   Stream (Writable)  CryptoStream                        [ Stream (Readable)           ]
         *     |                   |                |                               [       |                     ]
         *     |     write to      |    write to    |    contains decrypt bytes     [       |                     ]
         *     | ----------------> | -------------> | ----------------------------> [       | Contains plain text ]
         *     |                   |                |    (optionally connect to)    [       |                     ]
         *     |                   |                |                               [       |                     ]
         */     

        public static void Run()
        {
            Demo();
        }

        static void Demo()
        {
            string plainText = "My name Arslan Ahmad.";

            Console.WriteLine("Plain text: " + plainText);

            var encryptedInfo = Encrypt(plainText);
            DumpBytes("Encryption key bytes: ", encryptedInfo.key);
            DumpBytesToString("Encyption key string: ", encryptedInfo.key);
            DumpBytes("Enryption IV bytes: ", encryptedInfo.iv);
            DumpBytesToString("Encryption IV string: ", encryptedInfo.iv);
            DumpBytes("Encrypted text bytes: ", encryptedInfo.encryptedText);
            DumpBytesToString("Encrypted text string: ", encryptedInfo.encryptedText);

            var decryptedText = Decrypt(encryptedInfo.encryptedText, encryptedInfo.key, encryptedInfo.iv);
            Console.WriteLine($"Decrypted text: {decryptedText}");
        }
        
        static (byte[] encryptedText, byte[] key, byte[] iv) Encrypt(string text)
        {
            byte[] key;
            byte[] iv;
            byte[] encryptedText;

            using (Aes aes = Aes.Create())
            {
                key = aes.Key;
                iv = aes.IV;

                ICryptoTransform encryptor = aes.CreateEncryptor();

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter sw = new StreamWriter(cryptoStream))
                        {
                            sw.Write(text);
                            sw.Flush();
                        }

                        cryptoStream.Flush();
                    }

                    ms.Flush();
                    encryptedText = ms.ToArray();
                }
            }

            return (encryptedText, key, iv);
        }

        static string Decrypt(byte[] encryptedText, byte[] key, byte[] iv)
        {
            string decryptedText;

            Aes aes = Aes.Create();
            aes.Key = key;
            aes.IV = iv;

            ICryptoTransform decryptor = aes.CreateDecryptor();

            using (MemoryStream ms = new MemoryStream(encryptedText))
            {
                using (CryptoStream cryptoStream = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader reader = new StreamReader(cryptoStream))
                    {
                        decryptedText = reader.ReadToEnd();
                    }
                }
            }

            return decryptedText;
        }

        static void DumpBytes(string title, byte[] bytes)
        {
            Console.Write(title);
            bytes.ToList().ForEach(b => Console.Write($"{b:X} "));
            Console.WriteLine();
        }

        static void DumpBytesToString(string title, byte[] bytes)
        {
            Console.Write(title);
            var decoded = Convert.ToBase64String(bytes);
            Console.WriteLine(decoded);
        }
    }
}
