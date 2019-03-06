using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3.ExplicitInterfaces
{
    class Person : IPrintable, IDisplayable
    {
        public string Name { get; set; }

        public Person(string name) => Name = name;

        void IDisplayable.Print() => Console.WriteLine($"In displayable, {Name}");

        void IPrintable.Print() => Console.WriteLine($"In printable, {Name}");
    }
}
