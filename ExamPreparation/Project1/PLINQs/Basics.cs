using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.PLINQs
{
    static class Basics
    {
        public static void Run()
        {
            //DemoSimpleParallel();
            //DemoSimpleParallel(true);
            //DemoSimpleParallel(true, 4);
            //DemoOrdering(); // might need a few executions to observe the effects
            //DemoOrdering(true);
            //DemoForAll();
            //DemoForEach();
            //DemoFor();
            //DemoEach();
            DemoAggregateException();
        }

        static void DemoAggregateException()
        {
            var pQuery = ParallelEnumerable.Range(0, 100);
            int count = 0;
            try
            {
                Parallel.ForEach(pQuery, i =>
                {
                    count++;
                    if (i % 20 == 0)
                    {
                        throw new Exception($"Multiple of 20 - {i}");
                    }
                });
                Console.WriteLine($"Total iterations: {count}");
            }
            catch (AggregateException ex)
            {
                Console.WriteLine($"Total exceptions caught: {ex.InnerExceptions.Count}");
                for (int i = 0; i < ex.InnerExceptions.Count; i++)
                {
                    Console.WriteLine($"Exception {i + 1}: {ex.InnerExceptions[i].Message}");
                }
            }
        }

        static void DemoFor()
        {
            Parallel.For(0, 10, i => Console.Write(i + "  "));
        }

        static void DemoEach()
        {
            Parallel.ForEach(Enumerable.Range(0, 10), i => Console.Write(i + "  "));
        }

        static void DemoForEach()
        {
            // other technique: ForAll
            var pQuery = ParallelEnumerable.Range(0, 100000);
            int count = 0;
            pQuery.All(num =>
            {
                if (num % 2 == 0)
                {
                    count++;
                }
                return true;
            });
            Console.WriteLine($"Total even numbers: {count}");  // observe the result...the result might not have been completed
        }

        static void DemoForAll()
        {
            // ForAll does not wait for the result to complete; it just starts executing.
            // other technique: ForEach
            var pQuery = ParallelEnumerable.Range(0, 100000);
            int count = 0;
            pQuery.ForAll(num =>
            {
                if (num % 2 == 0)
                {
                    count++;
                }
            });
            Console.WriteLine($"Total even numbers: {count}");  // observe the result...the result might not have been completed
        }

        static void DemoOrdering(bool preserveOrdering = false)
        {
            var range = Enumerable.Range(1, 10);
            var sequentialNumbers = range.ToList();
            var pQuery = range.AsParallel().WithExecutionMode(ParallelExecutionMode.ForceParallelism);
            if (preserveOrdering)
            {
                pQuery = pQuery.AsParallel().AsOrdered();   // AsParallel() is necessary here
            }
            var parallelNumbers = pQuery.ToList();
            Console.Write("Sequentially: ");
            sequentialNumbers.ForEach(n => Console.Write(n + "   "));
            Console.WriteLine();
            Console.Write("Parallelly: ");
            parallelNumbers.ForEach(n => Console.Write(n + "   "));
            Console.WriteLine();
        }

        static void DemoSimpleParallel(bool force = false, int? degree = null)
        {
            var range = ParallelEnumerable.Range(0, 100000);
            var query = range
                        .AsParallel();   // already parallel -- not really necessary
            if (force)
            {
                query = query.WithExecutionMode(ParallelExecutionMode.ForceParallelism);
            }

            if (degree > 0)
            {
                query = query.WithDegreeOfParallelism(degree.Value);
            }

            var evenNumbers = query.Where(i => i % 2 == 0).ToList();
            Console.WriteLine($"Total even numbers: {evenNumbers.Count}");
        }
    }
}
