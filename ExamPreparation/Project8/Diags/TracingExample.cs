using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Project8.Diags
{
    static class TracingExample
    {
        static readonly string traceFileName = "trace.log";
        public static void Run()
        {
            Demo();
        }

        static void Demo()
        {
            var x = 10;
            Trace.Listeners.Add(new TextWriterTraceListener(traceFileName));
            Trace.WriteLine("Tracing the program");
            if (x >= 10)
            {
                Console.WriteLine("10");
                Trace.TraceInformation("x > 10");
            }
            Trace.AutoFlush = true;
        }
    }
}
