using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Project1.Tasks
{
    static class TasksReturningValue
    {
        public static void Run()
        {
            //Demo1();
            Demo2(true);
        }

        static void Demo1()
        {
            var t = Task<int>.Run(() =>
            {
                return 36;
            });

            var result = t.Result;  // t.Result will block the calling thread unless t returns value on completion
            Console.WriteLine($"Return value: {result}");
        }

        static void Demo2(bool waitForFinish)
        {
            var t1 = Task.Run(() =>
            {
                Console.WriteLine("T1 started...going to sleep");
                Thread.Sleep(2000);
                Console.WriteLine("T1 ready again");
                return "Task t1";
            });

            var t2 = Task.Run(() =>
            {
                Console.WriteLine("T2 started...going to sleep");
                Thread.Sleep(2000);
                Console.WriteLine("T2 ready again");
                return "Task t2";
            });

            var t3 = Task.Run(() =>
            {
                Console.WriteLine("T3 started...going to sleep");
                Thread.Sleep(2000);
                Console.WriteLine("T3 ready again");
                return "Task t3";
            });

            if (waitForFinish)
            {
                Console.WriteLine("Results: ");
                Console.WriteLine($"T1: {t1.Result}, T2: {t2.Result}, T3: {t3.Result}");    // will block
            }
        }
    }
}
