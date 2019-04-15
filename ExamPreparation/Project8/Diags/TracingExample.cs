using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace Project8.Diags
{
    static class TracingExample
    {
        static readonly string traceFileName = "trace.log";
        static readonly string traceFileName2 = "trace2.log";
        public static void Run()
        {
            //Demo1();
            //Demo2();
            //DemoTraceSource();
            DemoTraceSwitch();
        }

        static void Demo2()
        {
            var stream = File.Create(traceFileName2);
            var listener = new TextWriterTraceListener(stream);
            Trace.Listeners.Add(listener);
            Trace.AutoFlush = true;
            Trace.Write("Hello trace!");
        }

        static void Demo1()
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

        static void DemoTraceSource()
        {
            var ts = new TraceSource("Learning Trace Source", SourceLevels.All);
            ts.Listeners.Add(new TextWriterTraceListener(File.Create("TraceSource1.log")));
            ts.TraceEvent(TraceEventType.Information, 11, "Hello");
            ts.TraceEvent(TraceEventType.Critical, 12, "My message");
            ts.TraceInformation("An informative message");
            ts.TraceData(TraceEventType.Error, 44, new Exception("Sample exception"));
            ts.Flush();
            ts.Close();
        }

        static void DemoTraceSwitch()
        {
            Trace.Listeners.Add(new TextWriterTraceListener(File.Create("TraceSource2.log")));
            var traceSwitch = new TraceSwitch("My Trace Switch", "This is a test trace switch")
            {
                Level = TraceLevel.Warning
            };

            Trace.WriteLineIf(traceSwitch.TraceError, "Error is being traced");
            Trace.WriteLineIf(traceSwitch.TraceVerbose, "Verbose is being traced");
            Trace.Flush();
            Trace.Close();
        }
    }
}
