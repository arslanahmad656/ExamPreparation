using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Project1.ThreadBasics
{
    static class TheadLocalData
    {
        static int _NonLocal;

        // each thread will have its own copy of this field;
        // However, this field is initialized to the same value for each thread.
        [ThreadStatic]
        static int _Local;
        
        // each thread gets its copy initialized for it
        static ThreadLocal<int> _ThreadId = new ThreadLocal<int>(() => Thread.CurrentThread.ManagedThreadId);

        public static void Run()
        {
            _NonLocal = _Local = 0; // initialized (was not necessary)

            var t1 = new Thread(DisplayValues);
            t1.Name = "Thread 1";

            var t2 = new Thread(DisplayValues);
            t2.Name = "Thread 2";

            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();
        }

        static void DisplayValues()
        {
            _Local = _Local + 10;
            _NonLocal = _NonLocal + 10;

            Console.WriteLine($"Values in thead {Thread.CurrentThread.Name} ({_ThreadId}): Local {_Local}, Non Local {_NonLocal}");
        }
    }
}
