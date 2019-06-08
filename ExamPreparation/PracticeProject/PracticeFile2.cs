using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProject
{
    static class PracticeFile2
    {
        public static void Run()
        {
            DemoInheritanceHeirarchy();
        }

        static void DemoInheritanceHeirarchy()
        {
            object obj = new object();
            object objItem = new Item();
            object objWidget = new Widget();
            Item itemItem = new Item();
            Item itemWidget = new Widget();
            Widget widget = new Widget();

            DoWork(obj);
            DoWork(objItem);
            DoWork(objWidget);
            DoWork((Widget)objWidget);
            DoWork(itemItem);
            DoWork(itemWidget);
            DoWork(widget);
        }

        static void DoWork(object obj) => Console.WriteLine("DoWork of object");

        static void DoWork(Item obj) => Console.WriteLine("DoWork of Item");

        static void DoWork(Widget obj) => Console.WriteLine("DoWork of Widget");
    }

    class Item { }

    class Widget : Item { }
}
