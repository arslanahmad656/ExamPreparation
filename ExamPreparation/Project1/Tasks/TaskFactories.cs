using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Project1.Tasks
{
    static class TaskFactories
    {
        public static void Run()
        {
            Demo1();
        }

        static void Demo1()
        {
            var factory = new TaskFactory(TaskCreationOptions.AttachedToParent, TaskContinuationOptions.ExecuteSynchronously);
            for (int i = 0; i < 3; i++)
            {
                int num = i;
                var subTask = factory.StartNew(() =>
                {
                    Console.WriteLine($"\r\nChild task {num} started...");
                    Console.WriteLine($"T{num} finish...");
                });
                Thread.Sleep(10);   // remove this and observe the effects
            }

        }
    }
}
