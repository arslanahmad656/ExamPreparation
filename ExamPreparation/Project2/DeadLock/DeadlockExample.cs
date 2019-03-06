using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2.DeadLock
{
    static class DeadlockExample
    {
        static readonly object lock1 = new object();
        static readonly object lock2 = new object();

        public static void Run()
        {
            //DemoSequential();
            DemoConcurrent();
        }

        static void DemoSequential()
        {
            // no deadlock will occur
            Method1();
            Method2();
        }

        static void DemoConcurrent()
        {
            // there will be a deadlock
            Task.Run(() => Method1()).Wait();
            Task.Run(() => Method2());
        }

        static void Method1()
        {
            Console.WriteLine($"Method1 waiting for lock1");
            lock (lock1)
            {
                Console.WriteLine("Method1 got lock 1. Waiting for lock2...");
                lock (lock2)
                {
                    Console.WriteLine("Method1 got lock 2");
                }
                Console.WriteLine("Method1 released lock 2");
            }
            Console.WriteLine("Method1 released lock1");
            Console.WriteLine("Method1 end");
        }

        static void Method2()
        {
            Console.WriteLine($"Method2 waiting for lock2");
            lock (lock2)
            {
                Console.WriteLine("Method2 got lock 2. Waiting for lock1...");
                lock (lock1)
                {
                    Console.WriteLine("Method2 got lock 1");
                }
                Console.WriteLine("Method2 released lock 1");
            }
            Console.WriteLine("Method2 released lock2");
            Console.WriteLine("Method2 end");
        }
    }
}
