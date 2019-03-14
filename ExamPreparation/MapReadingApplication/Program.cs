using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedMemory;

namespace MapReadingApplication
{
    class Program
    {
        const string _Name = "___sharedMem__";

        static void Main(string[] args)
        {
            Run();
        }

        unsafe static void Run()
        {
            using (var mapping = new SharedMemory.SharedMemory(_Name))
            {
                Console.WriteLine($"P2 subscribed to shared memory.");

                void* ptr = mapping.FilePtr.ToPointer();
                SampleStruct* structPtr = (SampleStruct*)ptr;   // Amazing how naturally the memory mapping maps to unsafe structs

                Console.WriteLine();
                Console.WriteLine($"P2 reading values from memory");
                Console.WriteLine($"P2 Int: {structPtr->IntField}");
                Console.WriteLine($"P2 Char: {structPtr->CharField}");
                Console.WriteLine($"P2 Array[0]: {structPtr->FloatArrayField[0]}");
                Console.WriteLine($"P2 Array[1]: {structPtr->FloatArrayField[1]}");
                Console.WriteLine($"P2 Array[2]: {structPtr->FloatArrayField[3]}");

                Console.WriteLine();
                Console.WriteLine($"P2 changing values...");

                structPtr->IntField = structPtr->IntField + 1;
                structPtr->CharField = 'A';
                structPtr->FloatArrayField[0] = 200;
                structPtr->FloatArrayField[2] = 202;

                Console.WriteLine($"P2 Values changed. P1 can read values now");
            }
        }
    }
}
