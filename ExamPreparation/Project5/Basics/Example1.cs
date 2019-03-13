using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Project5.Basics
{
    static class Example1
    {
        [DllImport("user32.dll")]
        static extern int MessageBox(IntPtr handle, string text, string caption, int type);

        [DllImport("user32.dll")]
        static extern int MessageBox(IntPtr handle, object someObj);

        [DllImport("kernel32.dll")]
        static extern int GetWindowsDirectory(StringBuilder sb, int maxChars);

        public static void Run()
        {
            //Demo1();
            //Demo2();
            Demo3();
        }

        static void Demo1()
        {
            MessageBox(IntPtr.Zero, "This is a native windows dialog box. C# could display it using DllImport.", "The caption", 0);
        }

        static void Demo2()
        {
            try
            {
                MessageBox(IntPtr.Zero, new Object());
            }
            catch (Exception ex)    // access violations won't be caught!
            {
                MessageBox(IntPtr.Zero, ex.Message, ex.GetType().Name, 0);
            }
        }

        static void Demo3()
        {
            int maxChars = 128;
            var sb = new StringBuilder(maxChars);
            int winDir = GetWindowsDirectory(sb, maxChars);
            Console.WriteLine($"Windows directory: {sb.ToString()}");
        }
    }
}
