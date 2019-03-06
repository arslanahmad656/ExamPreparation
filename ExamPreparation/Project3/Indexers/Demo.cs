using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3.Indexers
{
    static class Demo
    {
        public static void Run()
        {
            Example();
        }

        static void Example()
        {
            var collection = new IndexedCollection();
            collection["four"] = 4;
            Console.WriteLine($"Value[four]: {collection["four"]}");
            Console.WriteLine($"Value[4]: {collection[4]}");
        }
    }
}
