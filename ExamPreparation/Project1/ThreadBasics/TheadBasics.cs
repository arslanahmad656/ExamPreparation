using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Project1.ThreadBasics
{
    static class TheadBasics
    {
        public static void Run()
        {
            DemoThreadNoArg();
            DemoThreadArg();
            DemoBackgroundThread();
            // interchange the order of following two lines and observe the result
            // Hint: even the background threads that are not joined will get completely executed. Why?
            DemoBackgroundThread2(true);
            DemoBackgroundThread2(false);
        }

        static void DemoThreadNoArg()
        {
            for (int i = 0; i < 10; i++)
            {
                var thread = new Thread(() => Console.WriteLine($"Thread name: {Thread.CurrentThread.Name}. This thread is without any argument."));
                thread.Name = $"t_noArg_{i + 1}";
                thread.Start();
            }
        }

        static void DemoThreadArg()
        {
            for (int i = 0; i < 10; i++)
            {
                var thread = new Thread((arg) => Console.WriteLine($"Thead {Thread.CurrentThread.Name} received argument: {arg.ToString()}"));
                thread.Name = $"t_arg_{i + 1}";
                thread.Start(i);
            }
        }

        static void DemoBackgroundThread()
        {
            for (int i = 0; i < 100; i++)
            {
                var thread = new Thread(() => Console.WriteLine($"This is a background thread. #{i + 1}"));
                thread.IsBackground = true;
                thread.Start();
            }
        }

        static void DemoBackgroundThread2(bool join)
        {
            var thread = new Thread(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    Console.WriteLine($"Thread executing iteration #{i + 1}");
                }
            });
            thread.IsBackground = true;
            thread.Start();

            if (join)
            {
                thread.Join();
            }
        }
    }
}
