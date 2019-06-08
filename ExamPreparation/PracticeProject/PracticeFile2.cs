using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace PracticeProject
{
    static class PracticeFile2
    {
        public static void Run()
        {
            //DemoInheritanceHeirarchy();
            //DictionaryValuesTest();
            //AssemblyLoadTest();
            FormatTest();
        }

        static void FormatTest()
        {
            Func<string, string, int, decimal, string> formatter = (firstName, lastName, orderNo, price) =>
                $"Thankyou {firstName} {lastName} for order {orderNo}. Your price is {price:C2}";

            var result1 = formatter("Arslan", "Ahmad", 12, 656m);
            var result2 = formatter("Asim", "Kabir", 13, 456.6m);
            var result3 = formatter("Usman", "Kabir", 14, 565.565m);

            Console.WriteLine(result1);
            Console.WriteLine(result2);
            Console.WriteLine(result3);
        }

        static void AssemblyLoadTest()
        {
            var ass = Assembly.Load("Assembly ass1key1, Version=1.0.2.5, Culture=en-US, PublicKeyToken=199287ff83a380a2");
            var loaded = AppDomain.CurrentDomain.GetAssemblies().Select(a => a.FullName);
        }

        static void DictionaryValuesTest()
        {
            var dic = new Dictionary<string, int>
            {
                { "Accounting", 1 },
                { "Marketing", 2 },
                { "Operations", 3 }
            };

            Func<string, int, bool?> searchFunc = (searchTerm, value) =>
            {
                return dic.Contains(new KeyValuePair<string, int>(searchTerm, value));
            };

            var result1 = searchFunc("Finance", 0);
            var result2 = searchFunc("Accounting", 1);
            var result3 = searchFunc("Accounting", 2);

            Console.WriteLine(result1?.ToString() ?? "NULL");
            Console.WriteLine(result2?.ToString() ?? "NULL");
            Console.WriteLine(result3?.ToString() ?? "NULL");
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
