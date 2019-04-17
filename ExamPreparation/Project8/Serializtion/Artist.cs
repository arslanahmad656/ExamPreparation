using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Project8.Serializtion
{
    [Serializable]
    public class Artist : ISerializable
    {
        public string Name { get; set; }

        public override string ToString() => Name;

        public Artist()
        {

        }

        protected Artist(SerializationInfo info, StreamingContext context)
        {
            var value = info.GetString("name");
            var index = value.LastIndexOf("blablabla");
            Name = value.Substring(0, index);
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("name", Name + "blablabla");
        }

        [OnSerializing]
        internal void BeforeSerialization(StreamingContext context)
        {
            Console.WriteLine("Before serializing");
        }

        [OnSerialized]
        internal void AfterSerialization(StreamingContext context)
        {
            Console.WriteLine("After serializing");
        }

        [OnDeserializing]
        internal void BeforeDeserializing(StreamingContext context)
        {
            Console.WriteLine("Before deserializing");
        }

        [OnDeserialized]
        internal void AfterDeserializing(StreamingContext context)
        {
            Console.WriteLine("After deserializing");
        }
    }
}
