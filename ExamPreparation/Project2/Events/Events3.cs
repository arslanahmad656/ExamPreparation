using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2.Events
{
    class Events3
    {

        public static void Run()
        {
            //DemoExceptionNotHandled();
            DemoExceptionHandled();
        }

        static void DemoExceptionNotHandled()
        {
            try
            {
                GetActionWithException()(); // one of the attached methods contains an exception not all of the attached methods will get executed.
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void DemoExceptionHandled()
        {
            var exceptionList = new List<Exception>();
            foreach (Delegate method in GetActionWithException().GetInvocationList())
            {
                try
                {
                    method.DynamicInvoke();
                }
                catch (Exception ex)
                {
                    exceptionList.Add(ex);
                }
            }

            Console.WriteLine($"Exceptions: {exceptionList.Count}.");
            Console.WriteLine($"First exception: {exceptionList.FirstOrDefault()?.Message}");
        }

        static Action GetActionWithException()
        {
            Action action = delegate { };

            for (int i = 0; i < 10; i++)
            {
                if (i == 5)
                {
                    action += () => throw new Exception("Exception thrown in a delegate.");
                }
                else
                {
                    int value = i + 1;
                    action += () => Console.WriteLine($"Action#{value}");
                }
            }

            return action;
        }
    }
}
