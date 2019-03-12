using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace Project4.MEF
{
    static class Example1
    {
        public static void Run()
        {
            Demo();
        }

        static void Demo()
        {
            var path = @"..\..\..\MEF1\bin\Debug\MEF1.exe";
            path = Path.GetFullPath(path);
            if (!File.Exists(path))
            {
                Console.WriteLine($"Executable {path} does not exist. MEF1 needs rebuilding in debug mode.");
                return;
            }

            var p = Process.Start(path);
            p.WaitForExit();
        }
    }
}
