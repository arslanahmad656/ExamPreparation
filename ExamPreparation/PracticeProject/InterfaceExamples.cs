using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProject
{
    interface INewInterface
    {
        void Method1();
    }

    public class Class2 : INewInterface
    {
        void INewInterface.Method1()
        {
            throw new NotImplementedException();
        }
    }

    public class Class1 : Class2
    {

    }

    static class InterfaceExamples
    {
        public static void Run()
        {
            Class2 obj2 = new Class2();
            Class1 obj1 = new Class1();
            var obj = (INewInterface)obj1;
        }
    }
}
