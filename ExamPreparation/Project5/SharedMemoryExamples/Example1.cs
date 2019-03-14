using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedMemory;

namespace Project5.SharedMemoryExamples
{
    static class Example1
    {
        public static void Run()
        {
            Demo();
        }

        static void Demo()
        {
            var mappingName = "__mappedMem";
            uint bytes = 1024;
   
            try
            {
                using (var map1 = new SharedMemory.SharedMemory(mappingName, bytes))
                using (var map2 = new SharedMemory.SharedMemory(mappingName))
                {
                    Console.WriteLine("Created a shared memory...");
                    Console.WriteLine($"Handle: {map1.FileHandle}");
                    Console.Write($"Poiter: {map1.FilePtr}");
                    Console.WriteLine();
                    
                    Console.WriteLine("Subscribed to a shared memory...");
                    Console.WriteLine($"Handle: {map2.FileHandle}");
                    Console.WriteLine($"Poiter: {map2.FilePtr}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
