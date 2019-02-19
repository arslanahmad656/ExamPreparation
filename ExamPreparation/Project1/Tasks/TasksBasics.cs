using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Tasks
{
    static class TasksBasics
    {
        public static void Run()
        {
            // interchange the following to lines and observe the results.
            // Hint: The waitForFinsh = false tasks also gets almost completed. Why?
            DemoTask(true);
            DemoTask(false);
        }

        static void DemoTask(bool waitForFinish)
        {
            var t = Task.Run(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"Task, wait for finish {waitForFinish}, iteration {i}");
                }
            });

            if (waitForFinish)
            {
                t.Wait();
            }
        }
    }
}
