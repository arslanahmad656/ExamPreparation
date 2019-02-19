using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Project1.Tasks
{
    static class Waits
    {
        public static void Run()
        {
            //NoWaitDemo();
            //WaitAllDemo();
            //WaitAnyDemo();
            //WhenAllDemo();
            WhenAnyDemo();
        }

        static void WhenAnyDemo()
        {
            var tf = new TaskFactory(TaskCreationOptions.AttachedToParent, TaskContinuationOptions.None);
            var tasks = new List<Task>();
            for (int i = 0; i < 5; i++)
            {
                int index = i;
                tasks.Add(tf.StartNew(() =>
                {
                    Console.WriteLine();
                    Console.WriteLine($"T{index} started...going to sleep...");
                    Thread.Sleep(3000);
                    Console.WriteLine($"T{index} awake...");
                }));
            }

            var task = Task.WhenAny(tasks);
            var result = task.Result;   // same blocking effect as task.Wait()
            Console.WriteLine("At least one task completed...");
        }

        static void WhenAllDemo()
        {
            var tf = new TaskFactory(TaskCreationOptions.AttachedToParent, TaskContinuationOptions.None);
            var tasks = new List<Task>();
            for (int i = 0; i < 5; i++)
            {
                int index = i;
                tasks.Add(tf.StartNew(() =>
                {
                    Console.WriteLine();
                    Console.WriteLine($"T{index} started...going to sleep...");
                    Thread.Sleep(3000);
                    Console.WriteLine($"T{index} awake...");
                }));
            }

            var task = Task.WhenAll(tasks);
            task.Wait();
            Console.WriteLine("All tasks completed...");
        }

        static void WaitAnyDemo()
        {
            var tf = new TaskFactory(TaskCreationOptions.AttachedToParent, TaskContinuationOptions.None);
            var tasks = new List<Task>();
            for (int i = 0; i < 5; i++)
            {
                int index = i;
                tasks.Add(tf.StartNew(() =>
                {
                    Console.WriteLine();
                    Console.WriteLine($"T{index} started...going to sleep...");
                    Thread.Sleep(3000);
                    Console.WriteLine($"T{index} awake...");
                }));
            }

            var tasksArray = tasks.ToArray();
            var completedIndex = Task.WaitAny(tasksArray);
            Console.WriteLine($"T{completedIndex} completed...");
        }

        static void WaitAllDemo()
        {
            var tf = new TaskFactory(TaskCreationOptions.AttachedToParent, TaskContinuationOptions.None);
            var tasks = new List<Task>();
            for (int i = 0; i < 5; i++)
            {
                int index = i;
                tasks.Add(tf.StartNew(() =>
                {
                    Console.WriteLine();
                    Console.WriteLine($"T{index} started...going to sleep...");
                    Thread.Sleep(3000);
                    Console.WriteLine($"T{index} awake...");
                }));
            }

            Task.WaitAll(tasks.ToArray());
        }

        static void NoWaitDemo()
        {
            var tf = new TaskFactory(TaskCreationOptions.AttachedToParent, TaskContinuationOptions.None);
            var tasks = new List<Task>();
            for (int i = 0; i < 5; i++)
            {
                int index = i;
                tasks.Add(tf.StartNew(() =>
                {
                    Console.WriteLine();
                    Console.WriteLine($"T{index} started...going to sleep...");
                    Thread.Sleep(3000);
                    Console.WriteLine($"T{index} awake...");
                }));
            }
        }
    }
}
