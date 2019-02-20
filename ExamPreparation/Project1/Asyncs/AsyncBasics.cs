using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;

namespace Project1.Asyncs
{
    static class AsyncBasics
    {
        static bool _completed = false;
        public static void Run()
        {
            Demo1();
        }

        async static void Demo1()
        {
            using (var client = new HttpClient())
            {
                Console.WriteLine("Getting content...");
                #pragma warning disable CS4014
                //Task.Run(() =>
                //{
                //    while (!_completed)
                //    {
                //        Thread.Sleep(500);
                //        Console.WriteLine("Still fetching...");
                //    }
                //});
                #pragma warning restore CS4014
                var result = await client.GetStringAsync("http://www.google.com/");
                _completed = true;
                Console.WriteLine("Fetching done!");
            }
        }
    }
}
