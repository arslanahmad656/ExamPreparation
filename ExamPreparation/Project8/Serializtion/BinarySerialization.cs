using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;

namespace Project8.Serializtion
{
    static class BinarySerialization
    {
        static readonly MusicDataStore store;

        static BinarySerialization()
        {
            store = MusicDataStore.MusicStore;
        }

        public static void Run()
        {
            //DemoSimpleSerialization();
            DemoEncryptedSerialization();
        }

        static void DemoEncryptedSerialization()
        {
            var fileName = "serialize2.bin";
            byte[] key;
            byte[] iv;

            Serialize();
            Deserialize();

            void Serialize()
            {
                Console.WriteLine("Store to serialize: ");
                Console.WriteLine(store);

                using (var fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
                {
                    using (Aes aes = Aes.Create())
                    {
                        key = aes.Key;
                        iv = aes.IV;

                        ICryptoTransform encryptor = aes.CreateEncryptor();

                        using (var cs = new CryptoStream(fs, encryptor, CryptoStreamMode.Write))
                        {
                            var serializer = new BinaryFormatter();
                            serializer.Serialize(cs, store);
                            cs.Flush();
                        }
                    }
                }

                Console.WriteLine($"MusicStore object has been serialized to {Path.GetFullPath(fileName)}");
            }

            void Deserialize()
            {
                MusicDataStore deserializedObject;
                using (var fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                {
                    using (Aes aes = Aes.Create())
                    {
                        aes.Key = key;
                        aes.IV = iv;

                        ICryptoTransform decryptor = aes.CreateDecryptor();

                        using (var cs = new CryptoStream(fs, decryptor, CryptoStreamMode.Read))
                        {
                            var deserializer = new BinaryFormatter();
                            deserializedObject = (MusicDataStore)deserializer.Deserialize(cs);
                        }
                    }
                }

                Console.WriteLine("Deserialized object:");
                Console.WriteLine(deserializedObject);
            }
        }

        static void DemoSimpleSerialization()
        {
            var fileName = "serialize1.bin";
            Serialize();
            Deserialize();

            void Serialize()
            {
                Console.WriteLine("Music store to serialize: ");
                Console.WriteLine(store);

                using (var fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
                {
                    var serializer = new BinaryFormatter();
                    serializer.Serialize(fs, store);
                    fs.Flush();
                }

                Console.WriteLine();
                Console.WriteLine($"Music store has been serialized to {Path.GetFullPath(fileName)}");
            }

            void Deserialize()
            {
                Console.WriteLine("Derializing");
                MusicDataStore deserializedStore;
                using (var fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                {
                    var deserializer = new BinaryFormatter();
                    deserializedStore = (MusicDataStore)deserializer.Deserialize(fs);
                }

                Console.WriteLine("Deserialized:");
                Console.WriteLine(deserializedStore);
                Console.WriteLine($"{nameof(store)} == {nameof(deserializedStore)}: {ReferenceEquals(store, deserializedStore)}");
            }
        }

        static MusicDataStore GetMusicStore()
        {
            var store = MusicDataStore.MusicStore;

            Debug.WriteLine(store);

            return store;
        }
    }
}
