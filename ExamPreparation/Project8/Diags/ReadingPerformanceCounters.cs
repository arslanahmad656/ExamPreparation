using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

namespace Project8.Diags
{
    static class ReadingPerformanceCounters
    {
        public static void Run()
        {
            ReadCPU();
        }

        static void ReadCPU()
        {
            using (PerformanceCounter counter = new PerformanceCounter(
                categoryName: "Processor Information",
                counterName: "% Processor Time",
                instanceName: "_Total"))
            {
                Console.WriteLine($"Counter Category: {counter.CategoryName}");
                Console.WriteLine($"Counter Help: {counter.CounterHelp}");
                Console.WriteLine($"Counter Type: {counter.CounterType}");
                Console.WriteLine($"Counter Instance Lifetime: {counter.InstanceLifetime}");
                Console.WriteLine($"Counter Machine Name: {counter.MachineName}");
                Console.WriteLine($"Counter Raw value: {counter.RawValue}");
                Console.WriteLine($"Counter Readonly: {counter.ReadOnly}");

                Console.WriteLine();
                Console.WriteLine("Measuring % CPU time. \nPress c to start cpu-bound task. \nPress s to stop...");

                char ch = '\0';
                bool taskStarted = false;
                do
                {
                    if (Console.KeyAvailable)
                    {
                        ch = Console.ReadKey().KeyChar;
                    }

                    var value = counter.NextValue();
                    Console.WriteLine($"Current CPU consumption: {Math.Round(value)}");
                    Thread.Sleep(250);

                    if (!taskStarted && ch == 'c')
                    {
                        Task.Run(() =>
                        {
                            while (true)
                            {
                                //for (int i = 0; i < 100000; i++)
                                //{
                                //    Thread.Sleep(500);
                                //}

                            }
                        });
                        taskStarted = true;
                    }

                } while (ch != 's');
            }
        }
    }
}
