using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Http;

namespace Project8.DataAccess
{
    static class InteractingWithWeb
    {
        public static void Run()
        {
            //DemoWebRequest();
            //DemoWebClient();
            DemoHttpClient();
        }

        static void DemoHttpClient()
        {
            // 1 - Create an instance
            // 2 - Directly read the formatted response

            var webclient = new HttpClient();
            var output = webclient.GetStringAsync("https://www.google.com.pk").Result;
            Console.WriteLine(output);
        }

        static void DemoWebClient()
        {
            // 1 - Create an instance
            // 2 - Directly read the formatted response

            var webclient = new WebClient();
            var output = webclient.DownloadString("https://www.google.com.pk");
            Console.WriteLine(output);
        }

        static void DemoWebRequest()
        {
            // Lowest level.
            // 1 - Create an instance using one of the factory methods
            // 2 - Get response
            // 3 - Associate response with a stream
            // 4 - Read from stream

            var webRequest = WebRequest.Create("https://www.google.com.pk");
            var response = webRequest.GetResponse();
            var output = "";
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                output = reader.ReadToEnd();
            }

            Console.WriteLine(output);
        }
    }
}
