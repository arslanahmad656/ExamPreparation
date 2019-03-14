using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using SharedMemory;

namespace MapCreatingApplication
{
    class Program
    {
        const string _Name = "___sharedMem__";
        const int _Size = 1024;

        static void Main(string[] args)
        {
            Run();
        }

        unsafe static void Run()
        {
            using (var mapping = new SharedMemory.SharedMemory(_Name, _Size))
            {
                Console.WriteLine($"P1 created a map named {_Name} of {_Size} bytes.");
                Console.WriteLine($"P1 writing to memory...");

                void* ptr = mapping.FilePtr.ToPointer();
                SampleStruct* structPtr = (SampleStruct*)ptr;   // This is amazing! mapped memory can be directly cast in to an unsafe struct!
                structPtr->IntField = 656;
                structPtr->CharField = 'M';
                structPtr->FloatArrayField[0] = 100;
                structPtr->FloatArrayField[2] = 101;

                Console.WriteLine($"P1 written to memory.");
                Console.WriteLine($"P2 can read and edit now!");
                Console.WriteLine("P1 Press 'c' when done...");

                char c;
                do
                {
                    c = Console.ReadKey().KeyChar;
                } while (c != 'c');

                Console.WriteLine();
                Console.WriteLine($"P1 reading values from memory");
                Console.WriteLine($"P1 Int: {structPtr->IntField}");
                Console.WriteLine($"P1 Char: {structPtr->CharField}");
                Console.WriteLine($"P1 Array[0]: {structPtr->FloatArrayField[0]}");
                Console.WriteLine($"P1 Array[1]: {structPtr->FloatArrayField[1]}");
                Console.WriteLine($"P1 Array[2]: {structPtr->FloatArrayField[3]}");

            }
        }
    }
}
