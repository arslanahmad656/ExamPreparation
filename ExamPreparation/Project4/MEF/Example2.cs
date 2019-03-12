using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace Project4.MEF
{
    static class Example2
    {
        public static void Run()
        {
            Demo();
        }

        static void Demo()
        {
            var path = @"..\..\..\MEFCalculatorUI\bin\Debug\MEFCalculatorUI.exe";
            path = Path.GetFullPath(path);
            if (!File.Exists(path))
            {
                Console.WriteLine($"Executable {path} does not exist. MEFCalculatorUI needs rebuilding in debug mode.");
            }

            var process = Process.Start(path);
            process.WaitForExit();
        }
    }
}
