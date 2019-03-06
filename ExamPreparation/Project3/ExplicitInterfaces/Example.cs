using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3.ExplicitInterfaces
{
    static class Example
    {
        public static void Run()
        {
            //Demo();
            Demo2();
        }

        static void Demo()
        {
            var person = new Person("RAVIAN656");
            // person.Print();  // can't be called print if object is not stored in one of the references of type interfaces
            IPrintable printable = person;
            printable.Print();
            ((IDisplayable)printable).Print();
        }

        static void Demo2()
        {
            try
            {
                dynamic person = new Person("Arslan");
                person.Print();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.GetType().FullName + ", " + ex.Message);
            }
        }
    }
}
