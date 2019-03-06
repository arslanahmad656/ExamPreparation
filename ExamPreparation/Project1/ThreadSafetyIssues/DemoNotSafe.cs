using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;

namespace Project1.ThreadSafetyIssues
{
    class SafetyIssueGlimpse
    {
        public static void Run()
        {
            //DemoNotSafe();
            DemoSafe();
        }

        static void DemoNotSafe()
        {
            var counter = new Counter();    // initially the value is zero

            Console.WriteLine($"Initial value of counter: {counter.GetSum()}");

            // Each of the following 200 tasks will add 20 to the value of counter:
            var tasks = new Task[200];
            for (int i = 0; i < tasks.Length; i++)
            {
                tasks[i] = Task.Run(() => Add(counter, 20));
            }

            Task.WaitAll(tasks);

            // Ideally the final value of the counter should be 0 + 200 * 20 = 4000
            Console.WriteLine($"Final value of counter: {counter.GetSum()}");   // but it is not!!! because the Counter class is not thread safe


            /// add value to ctr
            void Add(Counter ctr, int value)
            {
                counter.Add(value);
            }
        }

        static void DemoSafe()
        {
            var counter = new CounterThreadSafe();  // this is thread safe counter; in contrast to the one in DemoNotSafe

            Console.WriteLine($"Initial value of counter: {counter.GetSum()}"); // it should be zero

            // Each of the following 500 tasks will add 20 to the value of counter:
            var tasks = new Task[500];
            for (int i = 0; i < tasks.Length; i++)
            {
                tasks[i] = Task.Run(() => Add(counter, 20));
            }

            Task.WaitAll(tasks);

            // Ideally the final value of the counter should be 0 + 500 * 20 = 10000
            Console.WriteLine($"Final value of counter: {counter.GetSum()}");   // Yes it is!! because the counter is thread safe

            /// add value to ctr
            void Add(CounterThreadSafe ctr, int value)
            {
                counter.Add(value);
            }
        }
    }
}
