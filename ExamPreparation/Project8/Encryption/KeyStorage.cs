using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Project8.Encryption
{
    static class KeyStorage
    {
        const string containerName = "ExamPrepTestingKey";

        public static void Run()
        {
            //DemoUserLevelPersistingKeys();
            //DemoUserLevelNonPersistingKeys();
            //DemoMachineLevelPersistingKeys();
            DemoUserLevelNonPersistingKeys();
        }

        static void DemoMachineLevelNonPersistingKeys()
        {
            StoreKey(machineLevel: true, clear: true);
            LoadKey(machineLevel: true, clear: true);
        }

        static void DemoMachineLevelPersistingKeys()
        {
            StoreKey(machineLevel: true);
            LoadKey(machineLevel: true);
        }

        static void DemoUserLevelPersistingKeys()
        {
            StoreKey();
            LoadKey();  // This will load a different key
        }

        static void DemoUserLevelNonPersistingKeys()
        {
            StoreKey(clear: true);
            LoadKey(clear: true);
        }

        static void StoreKey(bool machineLevel = false, bool clear = false)
        {
            CspParameters cspParams = new CspParameters
            {
                KeyContainerName = containerName,
            };

            if (machineLevel)
            {
                cspParams.Flags = CspProviderFlags.UseMachineKeyStore;
            }

            using (RSACryptoServiceProvider provider = new RSACryptoServiceProvider(cspParams))
            {
                var key = provider.ToXmlString(true);   // private key
                Console.WriteLine("Stored Key: ");
                Console.WriteLine(key);
                Console.WriteLine("\nKey stored.");
                if (clear)
                {
                    provider.PersistKeyInCsp = false;
                    provider.Clear();
                    Console.WriteLine("\nKey cleared");
                }
            }
        }

        static void LoadKey(bool machineLevel = false, bool clear = false)
        {
            CspParameters cspParams = new CspParameters
            {
                KeyContainerName = containerName
            };

            if (machineLevel)
            {
                cspParams.Flags = CspProviderFlags.UseMachineKeyStore;
            }

            using (RSACryptoServiceProvider provider = new RSACryptoServiceProvider(cspParams))
            {
                var key = provider.ToXmlString(true);
                Console.WriteLine("Key loaded from container:");
                Console.WriteLine(key);
                if (clear)
                {
                    provider.PersistKeyInCsp = false;
                    provider.Clear();
                    Console.WriteLine("\nKey cleared");
                }
            }
        }
    }
}
