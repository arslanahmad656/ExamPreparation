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

        [ThreadStatic]
        static int _Local;  // each thread will have its own copy of this field

        public static void Run()
        {
            _NonLocal = _Local = 0; // initialized (was not necessary)

            var t1 = new Thread(ChangeValues);
            t1.Name = "Thread 1";

            var t2 = new Thread(ChangeValues);
            t2.Name = "Thread 2";

            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();
        }

        static void ChangeValues()
        {
            _Local = _Local + 10;
            _NonLocal = _NonLocal + 10;

            Console.WriteLine($"Values in thead {Thread.CurrentThread.Name}: Local {_Local}, Non Local {_NonLocal}");
        }
    }
}
