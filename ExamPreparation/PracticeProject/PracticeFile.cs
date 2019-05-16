using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProject
{
    static class PracticeFile
    {
        public static void Run()
        {
            //TestGenericType();
            //CalculateRunningTotal();
            CheckDoubleIndeterminate();
        }

        static void CheckDoubleIndeterminate()
        {
            double x, y;
            x = 0.0;
            y = 0.0;
            Console.WriteLine($"{x}/{y}: {x / y}");
        }

        static void CalculateRunningTotal()
        {
            int[] arr = { 1, 2, 3, 4, 5 };

            int sum = 0;
            for (int i = 0; i < arr.Length; )
            {
                sum += arr[i];
                arr[i++] = sum;
            }

            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }
        }

        static void TestGenericType()
        {
            var customer = new Customer();
            var customers = new List<Customer>();

            Console.WriteLine($"Cusomters is collection {customers is ICollection<Customer>}");
            Console.WriteLine($"Cusomters is enumberable {customers is IEnumerable<Customer>}");
            Console.WriteLine($"Cusomters is list {customers is List<Customer>}");
        }

        private class Customer
        {
            public string Name { get; set; }
        }
    }
}
