using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;

namespace Project8.Encryption
{
    static class Example3
    {
        const string targetFileName = @"encryption\plaintext.txt";
        const string infoFileName = "encryptionInfo.enc";
        const string encryptedTextFileName = "cyphertext.enc";

        public static void Run()
        {
            try
            {
                Demo();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void Demo()
        {
            Encrypt();
            var decrypted = Decrypt();
            Console.WriteLine($"Decrypted text:");
            Console.WriteLine(decrypted);
        }

        static void Encrypt()
        {
            byte[] key;
            byte[] iv;

            using (Aes aes = Aes.Create())
            {
                key = aes.Key;
                iv = aes.IV;
                
                using (FileStream fs = new FileStream(infoFileName, FileMode.Create, FileAccess.Write))
                {
                    using (StreamWriter writer = new StreamWriter(fs))
                    {
                        var keyStr = Convert.ToBase64String(key);
                        writer.WriteLine(keyStr);
                        var ivStr = Convert.ToBase64String(iv);
                        writer.WriteLine(ivStr);

                        writer.Flush();
                    }
                }

                ICryptoTransform encryptor = aes.CreateEncryptor();

                using (FileStream fs = new FileStream(encryptedTextFileName, FileMode.Create, FileAccess.Write))
                {
                    using (CryptoStream cryptoStream = new CryptoStream(fs, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter writer = new StreamWriter(cryptoStream))
                        {
                            var text = File.ReadAllText(targetFileName);
                            writer.Write(text);
                            writer.Flush();
                        }

                        cryptoStream.Flush();
                    }

                    //fs.Flush();   throws file closed exception
                }
            }
        }

        static string Decrypt()
        {
            byte[] key;
            byte[] iv;
            string decryptedText;

            using (FileStream fs = new FileStream(infoFileName, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader reader = new StreamReader(fs))
                {
                    var keyStr = reader.ReadLine();
                    key = Convert.FromBase64String(keyStr);

                    var ivStr = reader.ReadLine();
                    iv = Convert.FromBase64String(ivStr);
                }
            }

            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = iv;

                ICryptoTransform decryptor = aes.CreateDecryptor();

                using (FileStream fs = new FileStream(encryptedTextFileName, FileMode.Open, FileAccess.Read))
                {
                    using (CryptoStream cryptoStream = new CryptoStream(fs, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader reader = new StreamReader(cryptoStream))
                        {
                            decryptedText = reader.ReadToEnd();
                        }
                    }
                }
            }

            return decryptedText;
        }
    }
}
