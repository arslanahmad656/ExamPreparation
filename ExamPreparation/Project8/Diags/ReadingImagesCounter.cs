using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Project8.Diags
{
    static class ReadingImagesCounter
    {
        static bool imagesProcessingDone = false;

        static readonly string categoryName = CreatingPerformanceCounters.counterCategoryName;
        static readonly string totalCounterName = CreatingPerformanceCounters.totalImagesCounterName;
        static readonly string perSecondCouterName = CreatingPerformanceCounters.imagesProcessedPerSecondCounterName;

        static readonly string categoryName2 = "Copied Image Processing";
        static readonly string totalCounterName2 = "# of images processed";
        static readonly string perSecondCouterName2 = "# images processed per second";

        public static bool ImagesProcessingDone
        {
            get
            {
                lock (locker)
                {
                    return imagesProcessingDone;
                }
            }

            set
            {
                lock (locker)
                {
                    imagesProcessingDone = value;
                }
            }
        }

        static object locker = new object();

        public static void Run()
        {
            Demo();
        }

        static void Demo()
        {
            if (SetupCounters() == CounterSetupResult.Created)
            {
                Console.WriteLine("Counters have been created. Restart the program to start counting.");
                return;
            }

            PerformanceCounter totalImagesCounter = new PerformanceCounter(categoryName, perSecondCouterName);
            Console.WriteLine("Counter created");
            var tasks = new[]
            {
                Task.Run(() => MeasureCounterValues(totalImagesCounter)),
                Task.Run(() => ProcessImages())
            };

            Task.WaitAll(tasks);
        }

        static void MeasureCounterValues(PerformanceCounter counter)
        {
            while (!ImagesProcessingDone)
            {
                Console.WriteLine($"Current {counter.CounterName} value: {Math.Round(counter.NextValue())}");
                Thread.Sleep(500);
            }
        }

        static void ProcessImages()
        {
            Console.WriteLine("Starting image processing sequentially");
            CreatingPerformanceCounters.SequentialTest();
            Console.WriteLine("Processed sequentially. Starting in parallel");
            CreatingPerformanceCounters.ParallelTest();
            Console.WriteLine("Processed in parallel");
            ImagesProcessingDone = true;
        }

        static CounterSetupResult SetupCounters()
        {
            return CreatingPerformanceCounters.SetupCounters();
        }
    }
}
