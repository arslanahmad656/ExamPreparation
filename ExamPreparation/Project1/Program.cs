using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            //ThreadBasics.TheadBasics.Run();
            //ThreadBasics.TheadLocalData.Run();
            //ThreadBasics.ThreadLocals.Run();
            //Tasks.TasksBasics.Run();
            //Tasks.TasksReturningValue.Run();
            //Tasks.Continuations.Run();
            //Tasks.TaskFactories.Run();
            //Tasks.Waits.Run();
            //Asyncs.AsyncBasics.Run();
            //Tasks.Waits.Run();
            //SynchronizationContexts.Example1.Run();
            //PLINQs.Basics.Run();
            //ConcurrentCollections.Example1.Run();
            //Miscs.Miscs.Run();
            //TaskCancellation.TaskCancellation.Run();
            ThreadSafetyIssues.DemoNotSafe.Run();


            //Pause();
        }

        static void Pause()
        {
            Console.Write("\r\n\r\nEnd of main reached. Press any key to continue...");
            Console.ReadKey();
        }
    }
}
