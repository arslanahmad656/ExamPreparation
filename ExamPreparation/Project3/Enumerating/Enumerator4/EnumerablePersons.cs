using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3.Enumerating.Enumerator4
{
    class EnumerablePersons : IEnumerable<Person>
    {
        private Person[] persons;

        public EnumerablePersons()
        {
            persons = new Person[]
            {
                new Person("Arslan", 23),
                new Person("Asim", 21),
                new Person("Usman", 17)
            };
        }

        public IEnumerator<Person> GetEnumerator()
        {
            foreach (var person in persons)
            {
                yield return person;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
