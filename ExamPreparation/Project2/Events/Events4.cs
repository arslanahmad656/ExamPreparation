using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading.Tasks;

namespace Project2.Events
{
    static class Events4
    {
        delegate void Op();

        public static void Run()
        {

            Demo();
        }

        static void Demo()
        {
            Op op = new Op(() => { });

            Console.WriteLine($"Type of {nameof(Op)}: {typeof(Op).FullName}");
            Console.WriteLine($"Type of {nameof(op)}: {op.GetType().FullName}");

            Console.WriteLine($"{typeof(Delegate).FullName} is a base type of the type of {nameof(op)}: {typeof(Delegate).IsAssignableFrom(op.GetType())}");
        }
    }
}
