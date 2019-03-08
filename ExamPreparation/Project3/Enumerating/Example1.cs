using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3.Enumerating
{
    static class Example1
    {
        public static void Run()
        {
            DemoEnumerate1();
            //DemoEnumerate2();
        }

        static void DemoEnumerate1()
        {
            using (IEnumerator<Person> enumerator = new Enumerator1.PersonEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    Console.WriteLine(enumerator.Current);
                }
                Console.WriteLine();
                Console.WriteLine("Resetting");
                enumerator.Reset();
                while (enumerator.MoveNext())
                {
                    Console.WriteLine(enumerator.Current);
                }
            }
        }

        static void DemoEnumerate2()
        {
            foreach (var person in new Enumerator1.EnumerablePersons())
            {
                Console.WriteLine(person);
            }
        }
    }
}
