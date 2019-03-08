using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3.Enumerating
{
    static class Example2
    {
        public static void Run()
        {
            //DemoEnumerate1();
            DemoEnumerate2();
        }

        static void DemoEnumerate1()
        {
            foreach (var person in new Enumerator2.EnumerablePersons())
            {
                Console.WriteLine(person);
            }
        }

        static void DemoEnumerate2()
        {
            using (IEnumerator<Person> enumerator = new Enumerator2.EnumerablePersons())    // without 'using' this method is not functionality equivalent to 'foreach'. Foreach calls the dispose after enumeration.
            {
                while (enumerator.MoveNext())
                {
                    Console.WriteLine(enumerator.Current);
                }
            }
        }
    }
}
