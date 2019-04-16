using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

namespace Project8.Diags
{
    static class EventLogging
    {
        const string sourceName = "EventSource656";
        const string logName = "Log656";

        public static void Run()
        {
            var tasks = new[]
            {
                Task.Run(() =>
                {
                    var logger = GetLogger();
                    Console.WriteLine("Logger has been setup.");
                    Console.WriteLine("Enter any text to write to event log. <Enter> to exit...");
                    string text = "First Entry";
                    do
                    {
                        logger.WriteEntry(text, EventLogEntryType.Information, 656);
                        text = Console.ReadLine();
                    } while (!string.IsNullOrWhiteSpace(text));
                }),
                Task.Run(() =>
                {
                    var logger = GetLogger();
                    Console.WriteLine("Listening to event writes...");
                    logger.EnableRaisingEvents = true;
                    logger.EntryWritten += (sender, e) =>
                    {
                        Console.WriteLine($"Recieved event. {e.Entry.Category}, {e.Entry.EntryType}, {e.Entry.InstanceId}, {e.Entry.Source}, {e.Entry.Message}");
                    };
                })
            };

            Task.WaitAll(tasks);
        }
        
        static EventLog GetLogger()
        {
            if (!EventLog.SourceExists(sourceName))
            {
                EventLog.CreateEventSource(sourceName, logName);
            }

            var logger = new EventLog
            {
                Log = logName,
                Source = sourceName
            };

            return logger;
        }
    }

    enum LogSetupResult
    {
        Created,
        Loaded
    }
}
