using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3.Enumerating.Enumerator1
{
    class PersonEnumerator : IEnumerator<Person>
    {
        private Person[] persons;
        private int current;

        public PersonEnumerator()
        {
            persons = new Person[]
            {
                new Person("Arslan", 23),
                new Person("Asim", 21),
                new Person("Usman", 17)
            };
            Reset();
        }

        private void Reset() => current = 0;

        Person IEnumerator<Person>.Current => persons[current++];

        object IEnumerator.Current => persons[current];

        void IDisposable.Dispose() => Console.WriteLine($"{this.GetType().FullName} has nothing to dispose of.");

        bool IEnumerator.MoveNext() => current < persons.Length;

        void IEnumerator.Reset() => this.Reset();
    }
}
