using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1.AlarmClock;

namespace Project2.Events
{
    static class Events1
    {
        public static void Run()
        {
            Demo1();
        }

        static void Demo1()
        {
            var alarmInterval = 500;
            var clock = new AlarmClock(alarmInterval);
            clock.OnAlarmRaised += AlarmTickHandler1;
            clock.OnAlarmRaised += AlarmTickHandler2;

            Console.WriteLine($"Created alarm with an interval of {alarmInterval} ms.");
            Console.WriteLine("Press any key to start the clock...");
            Console.ReadKey();
            if (clock.StartClock())
            {
                Console.WriteLine("Clock started. Press any key to stop...");
            }
            else
            {
                throw new Exception("Could not start!");
            }

            Console.ReadKey();

            if (clock.StopClock())
            {
                Console.WriteLine("Alarm stopped.");
            }
            else
            {
                throw new Exception("Could not stop.");
            }
        }

        static void AlarmTickHandler1()
        {
            Console.WriteLine("Handler1");
        }

        static void AlarmTickHandler2()
        {
            Console.WriteLine("Handler2");
        }
    }
}
