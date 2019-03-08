using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3.Enumerating.Enumerator1
{
    class EnumerablePersons : IEnumerable<Person>
    {
        public IEnumerator<Person> GetEnumerator() => new PersonEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => new PersonEnumerator();
    }
}
