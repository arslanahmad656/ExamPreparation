using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;

namespace Project8.Encryption
{
    static class Example2
    {
        public static void Run()
        {
            Demo();
        }

        static void Demo()
        {
            string plainText = "My name is Arslan Ahmad.";

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
                        var bytes = text.ToArray().Select(c => Convert.ToByte(c)).ToList();
                        bytes.ForEach(b => cryptoStream.WriteByte(b));
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
            StringBuilder decryptedText = new StringBuilder();

            Aes aes = Aes.Create();
            aes.Key = key;
            aes.IV = iv;

            ICryptoTransform decryptor = aes.CreateDecryptor();

            using (MemoryStream ms = new MemoryStream(encryptedText))
            {
                using (CryptoStream cryptoStream = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                {
                    int @byte;
                    while ((@byte = cryptoStream.ReadByte()) != -1)
                    {
                        var @char = Convert.ToChar(@byte);
                        decryptedText.Append(@char);
                    }
                }
            }

            return decryptedText.ToString();
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
