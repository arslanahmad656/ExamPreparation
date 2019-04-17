using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace Project8.Serializtion
{
    static class JsonSerialization
    {
        const string fileName = "musicstore.json";
        static readonly MusicDataStore store = MusicDataStore.MusicStore;

        public static void Run()
        {
            Serialize();
            Deserialize();
        }

        static void Serialize()
        {
            using (var fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            using (var writer = new StreamWriter(fs))
            {
                var serializedData = JsonConvert.SerializeObject(store);
                writer.Write(serializedData);
            }

            Console.WriteLine($"Data has been written to {Path.GetFullPath(fileName)}");
        }

        static void Deserialize()
        {
            MusicDataStore deserializedObject;
            using (var fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            using (var reader = new StreamReader(fs))
            {
                var jsonText = reader.ReadToEnd();
                deserializedObject = JsonConvert.DeserializeObject<MusicDataStore>(jsonText);
            }

            Console.WriteLine("Deserialized object:");
            Console.WriteLine(deserializedObject);
        }
    }
}
