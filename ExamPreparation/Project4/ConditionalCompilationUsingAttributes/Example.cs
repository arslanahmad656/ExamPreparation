#define DIRECTIVE1
//#define DIRECTIVE2

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Project4.ConditionalCompilationUsingAttributes
{
    static class Example
    {
        public static void Run()
        {
            // try changing the directives at the top of file
            Method1();
            Method2();
            Method3();
        }

        [Conditional("DIRECTIVE1")]
        static void Method1()
        {
            Console.WriteLine("Called only if DIRECTIVE1 attribute is specified.");
        }

        [Conditional("DIRECTIVE2")]
        static void Method2()
        {
            Console.WriteLine("Called only if DIRECTIVE2 attribute is specified.");
        }

        [Conditional("DIRECTIVE1")]
        [Conditional("DIRECTIVE2")]
        static void Method3()
        {
            Console.WriteLine("Called only if either of the attribute is specified.");
        }
    }
}
