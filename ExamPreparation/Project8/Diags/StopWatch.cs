using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Project8.Diags
{
    static class StopWatch
    {
        static readonly int lowerLimit = 0;
        static readonly int upperLimit = 10000000;
        static readonly Stopwatch stopwatch = new Stopwatch();

        public static void Run()
        {
            DemoParallel();
            DemoSequential();
        }

        static void DemoParallel()
        {
            stopwatch.Restart();
            Parallel.For(lowerLimit, upperLimit, i => Work(i));
            stopwatch.Stop();

            Console.WriteLine($"\n\nTotal time (ms) taken for parallel: {stopwatch.ElapsedMilliseconds}");
        }
        
        static void DemoSequential()
        {
            stopwatch.Restart();

            for (int i = lowerLimit; i < upperLimit; i++)
            {
                Work(i);
            }

            Console.WriteLine($"\n\nTotal time (ms) taken for sequential: {stopwatch.ElapsedMilliseconds}");
        }

        static void Work(int iteration)
        {
            if (iteration % 10000 == 0 || iteration == upperLimit)
            {
                var total = upperLimit;
                double percentComplete = (double)iteration / total * 100;
                Console.WriteLine($"Completed {percentComplete:0.00}%");
            }
        }
    }
}
