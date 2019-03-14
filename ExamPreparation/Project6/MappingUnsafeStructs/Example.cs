using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Project6.MappingUnsafeStructs
{
    static class Example
    {
        public static void Run()
        {
            Demo();
        }

        static void Demo()
        {
            var tasks = new Task[2];
            tasks[0] = Task.Run(() =>
            {
                var p = Process.Start("MapCreatingApplication.exe");
                p.WaitForExit();
            });

            tasks[1] = Task.Run(() =>
            {
                Thread.Sleep(200);  // it should wait a little just to ensure that the other task should have created the memory
                var p = Process.Start("MapReadingApplication.exe");
                p.WaitForExit();
            });

            Task.WaitAll(tasks);
        }
    }
}
