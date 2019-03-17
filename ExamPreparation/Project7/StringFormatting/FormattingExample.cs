using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project7.StringFormatting
{
    static class FormattingExample
    {
        public static void Run()
        {
            Demo();
        }

        static void Demo()
        {
            var dt = new CustomDateTime(DateTime.Now);
            Console.WriteLine("Dates in different formats:");
            Console.WriteLine($"{dt:F}");
            Console.WriteLine($"{dt:f}");
            Console.WriteLine($"{dt:T}");
            Console.WriteLine($"{dt:t}");
            Console.WriteLine($"{dt:dt}");
            Console.WriteLine($"{dt}");
            Console.WriteLine($"{dt.ToString()}");
        }
    }
}
