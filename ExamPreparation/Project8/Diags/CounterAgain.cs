using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

namespace Project8.Diags
{
    static class CounterAgain
    {
        const string counterCategory = "Category CounterAgain";
        const string counterName1 = "CounterAgain";
        const string counterName2 = "CounterAgain2";

        static int factor = 1;

        static PerformanceCounter counter1;
        static PerformanceCounter counter2;

        public static void Run()
        {
            Demo();
        }

        static void Demo()
        {
            SetupCounter();

            var tasks = new[]
            {
                Task.Run(() =>
                {
                    while (true)
                    {
                        Console.WriteLine($"{counter1.CounterName}: {counter1.NextValue()}");
                        Console.WriteLine($"{counter2.CounterName}: {counter2.NextValue()}");
                        Thread.Sleep(100);
                    }
                }),
                Task.Run(() =>
                {
                    for (int i = 0; i < int.MaxValue; i++)
                    {
                        Work();
                    }
                })
            };

            Task.WaitAll(tasks);
        }

        static void Work()
        {
            counter1.Increment();
            counter2.Increment();
            Thread.Sleep(10000 / factor++);
        }

        static void SetupCounter()
        {
            if (PerformanceCounterCategory.Exists(counterCategory))
            {
                PerformanceCounterCategory.Delete(counterCategory);
            }

            var counterData = new CounterCreationData[]
            {
                new CounterCreationData(counterName1, "I hope this would give the corrrect results", PerformanceCounterType.RateOfCountsPerSecond64),
                new CounterCreationData(counterName2, "dfdsfdfs", PerformanceCounterType.NumberOfItems64)
            };

            var counterCollection = new CounterCreationDataCollection(counterData);

            PerformanceCounterCategory.Create(counterCategory, "Third time category", PerformanceCounterCategoryType.SingleInstance, counterCollection);

            counter1 = new PerformanceCounter(counterCategory, counterName1, false);
            counter2 = new PerformanceCounter(counterCategory, counterName2, false);
        }
    }
}
