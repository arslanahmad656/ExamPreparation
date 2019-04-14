using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace Project8.Encryption
{
    static class SigningWithCertificates
    {
        static readonly string secretMessage;
        static readonly string certificatePath;
        static readonly string storeName;
        static readonly string password;
        static readonly ASCIIEncoding convertor;
        static readonly HashAlgorithm hasher;

        static SigningWithCertificates()
        {
            secretMessage = "ARSLAN AHMAD 656";
            certificatePath = "cert483.cer";
            storeName = "Testing483";
            password = "updating";
            convertor = new ASCIIEncoding();
            hasher = new SHA1Managed();
            StoreKey();
        }

        static void StoreKey()
        {
            using (X509Store store = new X509Store(storeName, StoreLocation.CurrentUser))
            {
                store.Open(OpenFlags.ReadWrite);
                store.Add(new X509Certificate2(certificatePath, "password", X509KeyStorageFlags.PersistKeySet | X509KeyStorageFlags.UserKeySet));
            }
        }

        public static void Run()
        {
            DemoSigning();
        }

        static void DemoSigning()
        {
            var (hash, signature) = SignWithCertificate();
            var verfied = VerifyHash(hash, signature);
            Console.WriteLine(verfied);
            hash[0] = (byte)(hash[0] + 1);
            verfied = VerifyHash(hash, signature);
            Console.WriteLine(verfied);
        }

        static bool VerifyHash(byte[] hash, byte[] signature)
        {
            // load the certificate
            X509Certificate2 certificate = new X509Certificate2(certificatePath, password);

            // create the key:
            var decryptor = certificate.PublicKey.Key as RSACryptoServiceProvider;
            var verified = decryptor.VerifyHash(hash, CryptoConfig.MapNameToOID("SHA1"), signature);

            return verified;
        }

        static (byte[] hash, byte[] signature) SignWithCertificate()
        {
            using (X509Store store = new X509Store(storeName, StoreLocation.CurrentUser))
            {
                // get bytes of the message to sign:
                byte[] bytesToSign = convertor.GetBytes(secretMessage);

                // compute the hash of the bytes to sign
                byte[] hash = hasher.ComputeHash(bytesToSign);

                // load the certificate
                X509Certificate2 certificate = store.Certificates[0];

                // create encryptor from the certificate
                RSACryptoServiceProvider encryptor = certificate.PrivateKey as RSACryptoServiceProvider;
                Console.WriteLine($"Signing hash with {encryptor.SignatureAlgorithm}");

                // sign the hash:
                byte[] signature = encryptor.SignHash(hash, CryptoConfig.MapNameToOID("SHA1"));

                return (hash, signature);
            }
        }
    }
}
