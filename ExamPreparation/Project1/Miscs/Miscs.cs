using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Project1.Miscs
{
    static class Miscs
    {
        static Action _unCaughtExceptionAction;
        static Action _caughtExceptionAction;

        static Miscs()
        {
            _caughtExceptionAction = () =>
            {
                Console.WriteLine("Action started...");
                Console.WriteLine("Throwing an exeption that is caught...");
                try
                {
                    throw new Exception();
                }
                catch
                {
                    Console.WriteLine("Exception caught");
                }
                Console.WriteLine("After exception");
            };

            _unCaughtExceptionAction = () =>
            {
                Console.WriteLine("Action started...");
                Console.WriteLine("Throwing an exeption that is not caught...");
                throw new Exception();
            };
        }

        public static void Run()
        {
            //DemoParallelInvoke();
            //DemoParallelForeach();
            //DemoLoopStateStop();
            //DemoExcepitonInThread();
            DemoExceptionInTasks();
        }

        static void DemoExceptionInTasks()
        {
            var tasks = new Task[2];

            tasks[0] = Task.Run(_unCaughtExceptionAction);
            tasks[1] = Task.Run(_caughtExceptionAction);

            Task.WaitAll(tasks);
        }

        static void DemoExcepitonInThread()
        {
            new Thread(() => _unCaughtExceptionAction()).Start();

            new Thread(() => _caughtExceptionAction()).Start();
        }

        static void DemoLoopStateStop()
        {
            int size = 100;
            var status = new bool[size];
            ParallelLoopResult result = Parallel.For(0, size, (iter, loopState) =>
            {
                status[iter] = true;
                if (iter == size / 2)
                {
                    loopState.Stop();
                }
            });

            Console.WriteLine($"Is loop completed: {result.IsCompleted}");
            Console.WriteLine($"Lowest break iteration: {result.LowestBreakIteration}");

            var itemsProcessed = status.Where(s => s).Select((s, iter) => iter).ToList();
            Console.Write("Indexes processed: ");
            itemsProcessed.ForEach(i => Console.Write(i + "  "));
        }

        static void DemoParallelInvoke()
        {
            Action longRunningMethod = () =>
            {
                Console.WriteLine($"Started method {MethodBase.GetCurrentMethod().Name}. Going to sleep");
                Thread.Sleep(3000);
                Console.WriteLine($"Back from sleep.");
            };

            Parallel.Invoke(() =>
            {
                Console.WriteLine("Task 1");
                longRunningMethod();
            }, () =>
            {
                Console.WriteLine("Task 2");
                longRunningMethod();
            }, () =>
            {
                Console.WriteLine("Task 3");
                longRunningMethod();
            });

            Console.WriteLine("Done parallel tasks.");
        }

        static void DemoParallelForeach()
        {
            var range = Enumerable.Range(0, 100);

            Parallel.ForEach(range, item =>
            {
                Console.WriteLine("Started work on item" + item);
                Thread.Sleep(100);
                Console.WriteLine("Finished work on item " + item);
            });

            Console.WriteLine("Done processing each item");
        }
    }
}
