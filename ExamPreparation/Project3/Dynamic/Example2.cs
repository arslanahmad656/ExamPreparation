using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Dynamic;

namespace Project3.Dynamic
{
    static class Example2
    {
        public static void Run()
        {
            Demo();
        }

        static void Demo()
        {
            dynamic obj = new ExpandoObject();  // object initializer will not work for ExpandoObject
            obj.Name = "Arslan";
            obj.Title = "RAVIAN656";

            Console.WriteLine(obj.Name);
            Console.WriteLine(obj.Title);
        }
    }
}
