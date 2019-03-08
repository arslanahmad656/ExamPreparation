using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3.Enumerating.Enumerator3
{
    class EnumerablePersons : IEnumerable<Person>
    {
        private Person[] persons;
        private int current;

        public EnumerablePersons()
        {
            persons = new Person[]
            {
                new Person("Arslan", 23),
                new Person("Asim", 21),
                new Person("Usman", 17)
            };
            Reset();
        }

        void Reset() => current = 0;

        IEnumerator<Person> IEnumerable<Person>.GetEnumerator() => ((IEnumerable<Person>)persons).GetEnumerator();  // using the IEnumerator of inner collection

        IEnumerator IEnumerable.GetEnumerator() => persons.GetEnumerator();
    }
}
