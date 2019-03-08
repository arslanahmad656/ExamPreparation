using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3.Enumerating
{
    static class Example4
    {
        public static void Run()
        {
            DemoEnumerate1();
            DemoEnumerate2();
        }

        static void DemoEnumerate1()
        {
            foreach (var person in new Enumerator4.EnumerablePersons())
            {
                Console.WriteLine(person);
            }
        }

        static void DemoEnumerate2()
        {
            var enumerator = ((IEnumerable<Person>)new Enumerator4.EnumerablePersons()).GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
            }
        }
    }
}
