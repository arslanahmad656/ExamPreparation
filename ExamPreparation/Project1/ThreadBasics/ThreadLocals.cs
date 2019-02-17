// reference: https://docs.microsoft.com/en-us/dotnet/api/system.threading.threadlocal-1

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Project1.ThreadBasics
{
    static class ThreadLocals
    {
        public static void Run()
        {
            //DemoThreadLocal1();
            //DemoThreadLocal2();
            //DemoThreadLocal3();
            DemoThreadLocal4();
        }

        static void DemoThreadLocal4()
        {
            var threadLocal = new ThreadLocal<string>(() => $"Thread{Thread.CurrentThread.ManagedThreadId}", true);

            for (int i = 0; i < 5; i++)
            {
                var thread = new Thread(() =>
                {
                    Console.WriteLine($"Initial value: {threadLocal.Value ?? "<null>"}.");
                    try
                    {
                        threadLocal.Values.ToList().ForEach(v => Console.Write($"{v}; "));
                        Console.WriteLine();
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                });
                thread.Start();
                thread.Join();
            }
        }

        static void DemoThreadLocal3()
        {
            var threadLocal = new ThreadLocal<string>(() => $"Thread{Thread.CurrentThread.ManagedThreadId}");

            for (int i = 0; i < 5; i++)
            {
                var thread = new Thread(() =>
                {
                    Console.WriteLine($"Initial value: {threadLocal.Value ?? "<null>"}.");
                    try
                    {
                        threadLocal.Values.ToList().ForEach(v => Console.Write($"{v}; "));
                        Console.WriteLine();
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                });
                thread.Start();
                thread.Join();
            }
        }

        static void DemoThreadLocal2()
        {
            var threadLocal = new ThreadLocal<string>(true)
            {
                Value = "No func but only value specified for this ThreadLocal."
            };

            for (int i = 0; i < 5; i++)
            {
                var thread = new Thread(() =>
                {
                    Console.WriteLine($"Initial value: {threadLocal.Value ?? "<null>"}.");
                    try
                    {
                        threadLocal.Values.ToList().ForEach(v => Console.Write($"{v}; "));
                        Console.WriteLine();
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                });
                thread.Start();
                thread.Join();
            }
        }

        static void DemoThreadLocal1()
        {
            var threadLocal = new ThreadLocal<string>
            {
                Value = "No Func but only value specified for this ThreadLocal."
            };

            for (int i = 0; i < 5; i++)
            {
                var thread = new Thread(() =>
                {
                    Console.WriteLine($"Initial value: {threadLocal.Value ?? "<null>"}.");
                    try
                    {
                        threadLocal.Values.ToList().ForEach(v => Console.Write($"{v}; "));
                        Console.WriteLine();
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                });
                thread.Start();
                thread.Join();
            }
        }
    }
}
