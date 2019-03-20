using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project8.Common
{
    public class Person
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public List<string> PhoneNumbers;

        public Person(string name, int age)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Age = age;
        }

        public Person()
        {
            // required for xml serialization
        }

        public override string ToString() => $"{Name}, {Age} years";
    }
}
