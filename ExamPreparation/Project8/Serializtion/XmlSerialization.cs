using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace Project8.Serializtion
{
    static class XmlSerialization
    {
        const string fileName = "musicstore.xml";
        static readonly MusicDataStore store = MusicDataStore.MusicStore;

        public static void Run()
        {
            //Serialize();
            Deserialize();
            //Serialize2();
        }

        static void Serialize()
        {
            using (var fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                var serializer = new XmlSerializer(typeof(MusicDataStore));
                serializer.Serialize(fs, store);
                fs.Flush();
            }

            Console.WriteLine($"Data has been serialized in {Path.GetFileName(fileName)}.");
        }

        static void Deserialize()
        {
            MusicDataStore deserializedObject;
            using (var fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                var deserializer = new XmlSerializer(typeof(MusicDataStore));
                deserializedObject = (MusicDataStore)deserializer.Deserialize(fs);
            }
            Console.WriteLine("Deserialized object:");
            Console.WriteLine(deserializedObject);
        }

        static void Serialize2()
        {
            var person = new Person
            {
                Age = 23,
                Name = "RAVIAN656",
                AnotherPerson = new Person
                {
                    Age = 25,
                    Name = "Arslan Ahmad 656",
                    AnotherPerson = new Person
                    {
                        Age = 18,
                        Name = "Usman Kabir",
                    }
                }
            };

            // person.AnotherPerson.AnotherPerson.AnotherPerson = person;  // circular reference -- can't be serialized by XML Serializer

            using (var fs = new FileStream("person.xml", FileMode.Create, FileAccess.Write))
            {
                var serializer = new XmlSerializer(typeof(Person));
                serializer.Serialize(fs, person);
            }
        }
    }

    public class Person
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public Person AnotherPerson { get; set; }
    }
}
