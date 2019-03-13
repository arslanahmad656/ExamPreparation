using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Project5.Basics
{
    static class Example3
    {
        /*
            BOOL EnumWindows (WNDENUMPROC lpEnumFunc, LPARAM lParam);
            
            Definition of WNDENUMPROC lpEnumFunc:
            BOOL CALLBACK EnumWindowsProc (HWND hwnd, LPARAM lParam);

        */

        delegate bool EnumWindowsProc(IntPtr hwnd, IntPtr lParam);  // creating a delegate to match win32 unmanaged callback. Delegate name and parameter names are not important

        [DllImport("user32.dll")]
        static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, IntPtr lParam);

        public static void Run()
        {
            Demo();
        }

        static void Demo()
        {
            EnumWindows(CallBack, IntPtr.Zero);
        }

        static bool CallBack(IntPtr hwnd, IntPtr lParam)
        {
            Console.Write($"hnwd: {hwnd}  ");
            Console.WriteLine($"lParam: {lParam}");

            return true;
        }
    }
}
