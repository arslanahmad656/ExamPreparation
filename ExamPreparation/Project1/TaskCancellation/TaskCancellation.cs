using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Project1.TaskCancellation
{
    static class TaskCancellation
    {
        public static void Run()
        {
            //Example1();
            //Example2();
            StopWithException();
        }

        static void Example1()
        {
            CancellationTokenSource token = new CancellationTokenSource();

            Task.Run(() => Tick());
            Console.WriteLine("Clock started. Press any key to stop...");
            Console.ReadKey();
            token.Cancel();

            void Tick()
            {
                while (!token.IsCancellationRequested)
                {
                    Console.Write($".");
                    Thread.Sleep(500);
                }

                Console.WriteLine($"{Environment.NewLine}Ticking clock stopped.");
            }
        }

        static void Example2()
        {
            CancellationTokenSource token = new CancellationTokenSource();
            Task.Run(() => Tick(token.Token));

            void Tick(CancellationToken cancellationToken)
            {
                Console.WriteLine($"Clock started...");
                while (!cancellationToken.IsCancellationRequested)
                {
                    Console.Write($".");
                    Thread.Sleep(500);
                }

                Console.WriteLine($"{Environment.NewLine}Ticking clock stopped.");
            }

            Console.ReadKey();
            token.Cancel();
        }

        static void StopWithException()
        {
            CancellationTokenSource token = new CancellationTokenSource();
            Console.WriteLine("Starting clock...");
            var task = Task.Run(() => Tick(token.Token));
            Console.WriteLine();
            Console.WriteLine("Press any key to stop...");
            Console.ReadKey();

            if (task.IsCompleted)
            {
                Console.WriteLine("Task completed successfully");
            }
            else
            {
                try
                {
                    token.Cancel();
                    task.Wait();    // waiting is required if one wants to be sure whether the task was cancelled.
                }
                catch (AggregateException ex)
                {
                    Console.WriteLine($"Task was cancelled. First exception: {ex.InnerExceptions.First().GetType().FullName}");
                }
            }

            void Tick(CancellationToken cancellationToken)
            {
                for (int i = 0; !cancellationToken.IsCancellationRequested && i < 20; i++)
                {
                    Console.Write(".");
                    Thread.Sleep(500);
                }

                cancellationToken.ThrowIfCancellationRequested();
            }
        }
    }
}
