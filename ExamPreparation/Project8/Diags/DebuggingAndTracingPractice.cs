using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace Project8.Diags
{
    static class DebuggingAndTracingPractice
    {
        static TextWriterTraceListener listener;

        static DebuggingAndTracingPractice()
        {
            listener = new TextWriterTraceListener(File.Create("trace.out.log"));
            Trace.Listeners.Add(listener);
            Trace.AutoFlush = true;
        }

        public static void Run()
        {
            //DemoDebugWriting();
            //DemoDebugAsset();
            //DemoTrace();
            //DemoTraceSwitch();
            //DemoTraceSource();
            DemoSourceSwitch();
        }

        static void DemoDebugWriting()
        {
            Debug.WriteLine("Writing to debug. By default in output window");
        }

        static void DemoDebugAsset()
        {
            Console.WriteLine("Asserting something");
            Debug.Assert(false, "Assertion Failure", "This is an assertion that is made false on purpose");
            Console.WriteLine("After assertion");
        }

        static void DemoTrace()
        {
            Trace.Fail("Trace.Fail", "Demonstrating Trace.Fail");
            Trace.TraceError("Tracing error via Trace.TraceError");
            Trace.TraceInformation("Tracing information via Trace.TraceInformation");
            Trace.TraceWarning("Tracing warning via Trace.TraceWarning");
            Trace.WriteLine("Writing a line via Trace.WriteLine");
        }

        static void DemoTraceSwitch()
        {
            var tswitch = new TraceSwitch("Demo Trace Switch", "Created to demonstrated the functionality of trace switch")
            {
                Level = TraceLevel.Info
            };

            Trace.WriteLine($"Trace tracing {tswitch.Level} and above levels");
            Trace.WriteLineIf(tswitch.TraceVerbose, "Verbose level is being traced");
            Trace.WriteLineIf(tswitch.TraceInfo, "Info level is being traced");
            Trace.WriteLineIf(tswitch.TraceWarning, "Warning level is being traced");
            Trace.WriteLineIf(tswitch.TraceError, "Error level is being traced");
        }

        static void DemoTraceSource()
        {
            var level = SourceLevels.Warning;
            var tsource = new TraceSource("Demo Trace Source", level);
            Trace.WriteLine($"Trace source tracing {level} and above levels");

            tsource.Listeners.Add(new TextWriterTraceListener(File.Create("tsource.log")));

            tsource.TraceTransfer(1, "TraceTransfer", Guid.NewGuid());
            tsource.TraceInformation("Trace Information");
            tsource.TraceEvent(TraceEventType.Start, 100, "Tracing event");
            tsource.TraceEvent(TraceEventType.Verbose, 200, "Tracing verbose");
            tsource.TraceEvent(TraceEventType.Information, 300, "Tracing Information");
            tsource.TraceEvent(TraceEventType.Warning, 400, "Tracing Warning");
            tsource.TraceEvent(TraceEventType.Error, 500, "Tracing Error");
            tsource.TraceData(TraceEventType.Error, 6, new StringBuilder("Data1"), new object(), "data");
        }

        static void DemoSourceSwitch()
        {
            var level = SourceLevels.Warning;
            var sswitch = new SourceSwitch("Demo source switch")
            {
                Level = level
            };

            var tsource = new TraceSource("Demo Trace Source", SourceLevels.All)
            {
                Switch = sswitch
            };

            Trace.WriteLine($"Trace source tracing {level} and above levels");

            tsource.Listeners.Add(new TextWriterTraceListener(File.Create("tsource.log")));

            tsource.TraceTransfer(1, "TraceTransfer", Guid.NewGuid());
            tsource.TraceInformation("Trace Information");
            tsource.TraceEvent(TraceEventType.Start, 100, "Tracing event");
            tsource.TraceEvent(TraceEventType.Verbose, 200, "Tracing verbose");
            tsource.TraceEvent(TraceEventType.Information, 300, "Tracing Information");
            tsource.TraceEvent(TraceEventType.Warning, 400, "Tracing Warning");
            tsource.TraceEvent(TraceEventType.Error, 500, "Tracing Error");
            tsource.TraceData(TraceEventType.Error, 6, new StringBuilder("Data1"), new object(), "data");
        }
    }
}
