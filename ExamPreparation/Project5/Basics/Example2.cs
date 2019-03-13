using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Project5.Basics
{
    static class Example2
    {
        /*
         *  C struct:
         *  
         *  typedef struct _SYSTEMTIME {
                WORD wYear;
                WORD wMonth;
                WORD wDayOfWeek;
                WORD wDay;
                WORD wHour;
                WORD wMinute;
                WORD wSecond;
                WORD wMilliseconds;
            } SYSTEMTIME, *PSYSTEMTIME;

         */

        [DllImport("kernel32.dll")]
        static extern void GetSystemTime(SystemTimeClass time);

        [DllImport("kernel32.dll")]
        static extern void GetSystemTime(SystemTimeStruct time);    // this won't work because GetSystemTime requires an argument that can be copied out (i.e. at least an out variable)

        [DllImport("kernel32.dll")]
        static extern void GetSystemTime(out SystemTimeStruct time);    // would also work with ref

        public static void Run()
        {
            DemoClassMarshalling();
            //DemoStructMarshallingByRef();
            //DemoStructMarshallingByValue();
        }

        static void DemoClassMarshalling()
        {
            var time = new SystemTimeClass();    // Had the time been a struct, the system time would not have been reflected by it because it's passed by value.
            GetSystemTime(time);
            Console.WriteLine($"The time is {time}");
        }

        static void DemoStructMarshallingByValue()
        {
            var time = new SystemTimeStruct();
            GetSystemTime(time);    // the changes won't be reflected because the struct is passed by value
            Console.WriteLine($"The time is {time}");
        }

        static void DemoStructMarshallingByRef()
        {
            var time = new SystemTimeStruct();
            GetSystemTime(out time);
            Console.WriteLine($"The time is {time}");
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    class SystemTimeClass    // names of the fields don't have to match; only the ordering is important
    {
        ushort Year;
        ushort Month;
        ushort WeekDay;
        ushort Day;
        ushort Hour;
        ushort Minute;
        ushort Second;
        ushort MilliSecond;
        public override string ToString()
            => $"{Hour}:{Minute}:{Second}.{MilliSecond}";
    }

    [StructLayout(LayoutKind.Sequential)]
    struct SystemTimeStruct    // names of the fields don't have to match; only the ordering is important
    {
        ushort Year;
        ushort Month;
        ushort WeekDay;
        ushort Day;
        ushort Hour;
        ushort Minute;
        ushort Second;
        ushort MilliSecond;

        public override string ToString()
            => $"{Hour}:{Minute}:{Second}.{MilliSecond}";
    }
}
