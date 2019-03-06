using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3.Dynamic
{
    static class Example1
    {
        public static void Run()
        {
            //BadDynamicExample();
            GoodDynamicExample();
        }

        static void BadDynamicExample()
        {
            try
            {
                dynamic obj = new SomeClass();
                obj.NonExistingMethod();    // this will compile owing the dynamic nature
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception occurred. Type: {ex.GetType().FullName}. Message {ex.Message}");
            }
        }

        static void GoodDynamicExample()
        {
            dynamic obj = new SomeClass();
            obj.SomeMethod();   // bound at runtime
        }
    }
}
