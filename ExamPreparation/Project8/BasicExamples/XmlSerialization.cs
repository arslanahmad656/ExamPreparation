using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using Person = Project8.Common.Person;

namespace Project8.BasicExamples
{
    static class XmlSerialization
    {
        public static void Run()
        {
            Demo();
        }

        static void Demo()
        {
            var person = new Person("Arslan", 23);
            Console.WriteLine($"Person: {person}");
            var xml = Serialize(person);
            Console.WriteLine("XML:");
            Console.WriteLine(xml);
            var deserialized = Deserialize(xml);
            Console.WriteLine(deserialized);
        }

        static string Serialize(Person person)
        {
            var xmlSerializer = new XmlSerializer(typeof(Person));

            string xml;
            using (var writer = new StringWriter())
            {
                xmlSerializer.Serialize(writer, person);
                writer.Flush();
                xml = writer.ToString();
            }

            return xml;
        }

        static Person Deserialize(string xml)
        {
            var xmlSerializer = new XmlSerializer(typeof(Person));
            var reader = new StringReader(xml);
            var person = (Person)xmlSerializer.Deserialize(reader);
            return person;
        }
    }
}
