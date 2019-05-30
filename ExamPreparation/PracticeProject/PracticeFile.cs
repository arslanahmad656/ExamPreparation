using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace PracticeProject
{
    static class PracticeFile
    {
        public static void Run()
        {
            //TestGenericType();
            //CalculateRunningTotal();
            //CheckDoubleIndeterminate();
            //FormatPractice();
            CheckReg();
        }

        static void CheckReg()
        {
            var pattern = "search";
            var text = "i can perform search by using a search function that performs a search operation and then return the search result.";
            MatchCollection matches = Regex.Matches(text, pattern);
            List<string> result = new List<string>();
            var enumerator = matches.GetEnumerator();
            while (enumerator.MoveNext())
            {
                result.Add(((Match)enumerator.Current).Value);
            }
            Console.WriteLine(result.Count);
        }

        static void FormatPractice()
        {
            for (int i = 4; i <= 40000000; i *= 10)
            {
                Console.WriteLine($"C2: {i,20:C2} D8: {i:D8} E3: {i:E3} F3: {i,15:F3} G3: {i,7:G3} N3: {i,20:N3} x: {i,8:x} X3: {i,8:X3}");
            }

            var n = 123.45;
            Console.WriteLine();
            Console.WriteLine($"0: {n:0}, 00000: {n:00000} 00000.0000 {n:00000.0000}");
            Console.WriteLine($"#: {n:#}, #######: {n:#######}, #####.###: {n:#####.###}, #####-#######-#: {3450204400597:#####-#######-#}");
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
