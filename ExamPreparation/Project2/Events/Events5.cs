using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2.Events
{
    static class Events5
    {
        static Action action = delegate { };

        public static void Run()
        {
            Demo();
        }

        static void Demo()
        {
            action = () => Console.WriteLine("Demo running");

            action += action;

            action();
        }
    }
}
