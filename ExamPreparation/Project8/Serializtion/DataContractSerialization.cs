using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.IO;

namespace Project8.Serializtion
{
    static class DataContractSerialization
    {
        const string fileName = "vehicle.xml";
        static readonly Vehicle vehicle = new Vehicle
        {
            Make = "Honda",
            Model = "City",
            RegistrationNumber = "LEB-09-5192"
        };

        public static void Run()
        {
            Serialize();
            Deserialize();
        }

        static void Serialize()
        {
            Console.WriteLine($"Object to serialize: {vehicle}");
            using (var fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                var serializer = new DataContractSerializer(vehicle.GetType());
                serializer.WriteObject(fs, vehicle);
            }

            Console.WriteLine($"Data has been serialized in {Path.GetFullPath(fileName)}");
        }

        static void Deserialize()
        {
            Vehicle deserializedObject;
            using (var fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                var deserializer = new DataContractSerializer(typeof(Vehicle));
                deserializedObject = (Vehicle)deserializer.ReadObject(fs);
            }

            Console.WriteLine("Deserialized object:");
            Console.WriteLine(deserializedObject);
        }

        [DataContract]
        class Vehicle   // XmlSerializer cannot serialize internal classes
        {
            [DataMember]    // XmlSerializer cannot serialize private fields
            private string privateField = "This is a vehicle";

            [DataMember]
            public string Make { get; set; }

            [DataMember]
            public string Model { get; set; }
            
            public string RegistrationNumber { get; set; }

            public override string ToString()
                => $"{Make} {Model} ({RegistrationNumber})";
        }
    }
}
