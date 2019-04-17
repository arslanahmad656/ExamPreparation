using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Project8.DataAccess
{
    static class InteractingWithWebApi
    {
        static readonly HttpClient client = new HttpClient
        {
            BaseAddress = new Uri("http://dummy.restapiexample.com/")
        };

        public static void Run()
        {
            //DemoGetAll();
            //DemoGet("25065");
            //DemoPost(new Employee
            //{
            //    employee_age = "23",
            //    employee_name = "api employee",
            //    employee_salary = "22000",
            //    id = "6445656",
            //    profile_image = ""
            //});
            DemoPost2();
        }

        static void DemoGetAll()
        {
            try
            {
                string uri = "api/v1/employees";
                var result = client.GetStringAsync(uri).Result;
                var employees = JsonConvert.DeserializeObject<List<Employee>>(result);
                Console.WriteLine("Deserialized. First 10 employees:");
                employees.Take(10).ToList().ForEach(e => Console.WriteLine(e));
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void DemoGet(string id)
        {
            try
            {
                string uri = $"api/v1/employee/{id}";
                var result = client.GetStringAsync(uri).Result;
                var employee = JsonConvert.DeserializeObject<Employee>(result);
                Console.WriteLine(employee);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void DemoPost(Employee employee)
        {
            try
            {
                string uri = "api/v1/create";
                var content = new StringContent(employee.ToString(), Encoding.UTF8, "application/json");
                var result = client.PostAsync(uri, content).Result;
                if (result.IsSuccessStatusCode)
                {
                    Console.WriteLine("Post succeeded.");
                    var response = result.Content.ReadAsStringAsync().Result;
                    Console.WriteLine(response);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void DemoPost2()
        {
            try
            {
                var uri = "https://outlook.office.com/webhook/f709c553-fcd2-4eca-ab55-c00f937100e1@07ba9792-2426-43dd-92da-f24de3bd2ba3/IncomingWebhook/f6ccacb4cfeb4cbd906fd2ea39aef108/a811098d-bd7e-4e2d-874b-a07501291ca0";
                var json = new
                {
                    Text = "Sending from C#"
                };
                var serialized = JsonConvert.SerializeObject(json);

                var client = new HttpClient();
                var content = new StringContent(serialized, Encoding.UTF8, "application/json");
                var result = client.PostAsync(uri, content).Result;
                if (result.IsSuccessStatusCode)
                {
                    Console.WriteLine("Post succeeded.");
                    var response = result.Content.ReadAsStringAsync().Result;
                    Console.WriteLine(response);
                }
                else
                {
                    Console.WriteLine($"Status: {result.StatusCode} {result.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            } 
        }
    }

    class Employee
    {
        public string id { get; set; }
        public string employee_name { get; set; }
        public string employee_salary { get; set; }
        public string employee_age { get; set; }
        public string profile_image { get; set; }

        public override string ToString()
            => $"{id} {employee_name}";
    }
}
