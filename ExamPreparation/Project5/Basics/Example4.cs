using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Project5.Basics
{
    /*
        Simulating C union.
        C Union is like structs except that the field offsets are explicitly assigned.

     */
    static class Example4
    {
        public static void Run()
        {
            Demo();
        }

        static void Demo()
        {
            var union = new CUnionExample();
            union.pack = 0; // explicitly setting the pack value to 0 The struct now contains all zero bits.
            Console.WriteLine($"#1 - Pack: {union.pack}");    // will be 0
            union.part1 = 0b10000000;   // since the offset of both part1 and pack is 0, setting either one will affect the other one.
            Console.WriteLine($"#3 - Pack: {union.pack}"); // Will be 128 because pack is 10000.........
        }
    }

    /*
     The following CUnionExample struct will have its layout given as follows: (- represent a byte positioned in memory)
        -------- long pack (8 bytes, offset 0)
        -        byte part1 (1 byte, offset 0)
          --     short part2 (2 bytes, offset 2)
            ---- int part3 (4 bytes, offset 4)

        Interpretation:
            See Demo()

    */
    [StructLayout(LayoutKind.Explicit)]
    struct CUnionExample
    {
        [FieldOffset(0)] public long pack;
        [FieldOffset(0)] public byte part1;
        [FieldOffset(2)] public short part2;
        [FieldOffset(4)] public int part3;
    }
}
