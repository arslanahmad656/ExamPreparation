using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Project6.UnsafeBasics
{
    static class Example1
    {
        public static void Run()
        {
            //DemoAllocateOnStackNormally();
            //DemoAllocateOnStackViaPointer();
            DemoAllocateOnHeap();
        }

        unsafe static void DemoAllocateOnStackNormally()
        {
            UnsafeStruct @struct;
            @struct.IntField = 10;
            @struct.CharField = 'M';
            @struct.FloatArrayField[0] = 2.15f;
            @struct.FloatArrayField[2] = 3.25f;

            Console.WriteLine($"Size of struct: {sizeof(UnsafeStruct)}");
            Console.WriteLine("Int: " + @struct.IntField);
            Console.WriteLine("Char: " + @struct.CharField);
            Console.WriteLine("Array[0]: " + @struct.FloatArrayField[0]);
            Console.WriteLine("Array[1]: " + @struct.FloatArrayField[1]);   // on stack the array is auto-initialized- there is no garbage
            Console.WriteLine("Array[2]: " + @struct.FloatArrayField[2]);
        }

        unsafe static void DemoAllocateOnStackViaPointer()
        {
            UnsafeStruct @struct;
            UnsafeStruct* structPtr = &@struct; // there is no need to free memory since struct is created on stack and will be popped off when function exits

            // Assign via pointer
            structPtr->IntField = 10;
            structPtr->CharField = 'M';
            structPtr->FloatArrayField[0] = 2.15f;
            structPtr->FloatArrayField[2] = 3.25f;

            // Access normally
            Console.WriteLine("Int: " + @struct.IntField);
            Console.WriteLine("Char: " + @struct.CharField);
            Console.WriteLine("Array[0]: " + @struct.FloatArrayField[0]);
            Console.WriteLine("Array[1]: " + @struct.FloatArrayField[1]);   // on stack the array is auto-initialized- there is no garbage
            Console.WriteLine("Array[2]: " + @struct.FloatArrayField[2]);
        }

        unsafe static void DemoAllocateOnHeap() // this can only be done using pointer
        {
            UnsafeStruct* structPtr = (UnsafeStruct*)Marshal.AllocHGlobal(sizeof(UnsafeStruct));    // it's compulsory to free this memory before exiting the method!

            structPtr->IntField = 10;
            structPtr->CharField = 'M';
            structPtr->FloatArrayField[0] = 2.15f;
            structPtr->FloatArrayField[2] = 3.25f;

            Console.WriteLine("Int: " + structPtr->IntField);
            Console.WriteLine("Char: " + structPtr->CharField);
            Console.WriteLine("Array[0]: " + structPtr->FloatArrayField[0]);
            Console.WriteLine("Array[1]: " + structPtr->FloatArrayField[1]);    // on heap, the array is not auto-initialized- intially it contains garbage
            Console.WriteLine("Array[2]: " + structPtr->FloatArrayField[2]);

            Marshal.FreeHGlobal(new IntPtr(structPtr)); // don't free the memory and suffer memory leakage!!!
        }
    }
}
