using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;

namespace Project1.ThreadSafetyIssues
{
    class DemoNotSafe
    {
        public static void Run()
        {
            Demo();
        }

        static void Demo()
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
    }
}
