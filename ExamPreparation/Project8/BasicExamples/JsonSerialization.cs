using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Person = Project8.Common.Person;

namespace Project8.BasicExamples
{
    static class JsonSerialization
    {
        public static void Run()
        {
            DemoSerializeAndDeserialize();
        }

        static void DemoSerializeAndDeserialize()
        {
            var person = new Person("Arslan Ahmad", 23);
            Console.WriteLine($"Person: {person}");
            var json = SerializePerson(person);
            Console.WriteLine($"Serialized json:");
            Console.WriteLine(json);
            var deserialized = DeSerializeJson(json);
            Console.WriteLine($"After deserialization: {deserialized}");

            DeSerializeJson("dsfdsfdsfds");
        }

        static string SerializePerson(Person person)
        {
            return JsonConvert.SerializeObject(person);
        }

        static Person DeSerializeJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<Person>(json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.GetType().FullName}: {ex.Message}");
                return null;
            }
        }
    }
}
