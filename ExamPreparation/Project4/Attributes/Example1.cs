using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project4.Attributes
{
    static class Example1
    {
        public static void Run()
        {
            Demo();
        }

        static void Demo()
        {
            Console.WriteLine($"{typeof(Test1).Name} has attribute {typeof(SerializableAttribute).Name}: {Attribute.IsDefined(typeof(Test1), typeof(SerializableAttribute))}");
            Console.WriteLine($"{typeof(Test2).Name} has attribute {typeof(SerializableAttribute).Name}: {Attribute.IsDefined(typeof(Test2), typeof(SerializableAttribute))}");
        }
    }


    [Serializable]
    class Test1
    {

    }

    class Test2
    {

    }
}
