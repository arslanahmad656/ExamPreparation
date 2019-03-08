using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3.Enumerating.Enumerator2
{
    class EnumerablePersons : IEnumerable<Person>, IEnumerator<Person>
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

        Person IEnumerator<Person>.Current => persons[current++];

        object IEnumerator.Current => persons[current++];

        void IDisposable.Dispose() => Console.WriteLine($"{this.GetType().FullName} has nothing to dispose of.");

        IEnumerator<Person> IEnumerable<Person>.GetEnumerator() => this as IEnumerator<Person>; // as IEnumerator<Person> is literally not necessary; but it's good for readability

        IEnumerator IEnumerable.GetEnumerator() => this as IEnumerator;

        bool IEnumerator.MoveNext() => current < persons.Length;

        void Reset() => current = 0;

        void IEnumerator.Reset() => Reset();
    }
}
