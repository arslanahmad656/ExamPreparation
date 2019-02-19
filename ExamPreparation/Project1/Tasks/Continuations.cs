using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Project1.Tasks
{
    static class Continuations
    {
        public static void Run()
        {
            //Demo1();
            //Demo2();
            //Demo3();
            Demo4(true);
            Demo4(false);
        }

        static void Demo4(bool fault)
        {
            var parentTask = Task.Run(() =>
            {
                if (fault)
                {
                    throw new Exception("Intentionally faulting the task.");
                }
                else
                {
                    return "Sucessfull execution";
                }
            });

            parentTask.ContinueWith(p =>
            {
                Console.WriteLine("\n\n\n\nSuccesfull continuation.");
            }, TaskContinuationOptions.OnlyOnFaulted);

            parentTask.ContinueWith(p =>
            {
                Console.WriteLine("\n\n\n\nFaulted continutation.");
            }, TaskContinuationOptions.OnlyOnRanToCompletion);

            parentTask.Wait();
        }

        static void Demo3()
        {
            bool @throw = true;
            var t = Task<int>.Run(() =>
            {
                if (@throw)
                {
                    try
                    {
                        throw new Exception("Exception thrown in task.");
                    }
                    catch
                    {
                        Console.WriteLine("In child task: rethrowing exception.");
                        throw;
                    }
                }
                else
                {
                    return 1;
                }
            });

            try
            {
                var result = t.Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "; " + ex.InnerException.Message);
            }
        }

        static void Demo2()
        {
            Console.WriteLine("Main thread started...scheduling tasks.");
            var t = Task.Run(() =>
            {
                Console.WriteLine("Parent thread started... going to sleep.");
                Thread.Sleep(3000);
                Console.WriteLine("Parent thread back from dorm.");
                return 32;
            }).ContinueWith(r =>
            {
                Console.WriteLine("Child thread started...reading the value from parent thread.");
                var value = r.Result;   // will block
                Console.WriteLine($"Value read: {value}");
                Console.WriteLine("Child going to sleep...");
                Thread.Sleep(3000);
                Console.WriteLine("Child back from dorm...");
                return value * 2;
            });

            Console.WriteLine("Main thread after scheduling tasks, reading grand-child thread value.");
            var result = t.Result;  // will block
            Console.WriteLine($"Main thread value read: {result}");
        }

        static void Demo1()
        {
            var t = Task.Run(() => 32).ContinueWith(continuedValue =>
            {
                Console.WriteLine($"Value received: {continuedValue.Result}");
                return continuedValue.Result * 2;
            });

            Console.WriteLine($"Resultant value: {t.Result}");
        }
    }
}
