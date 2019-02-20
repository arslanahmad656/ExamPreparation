using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace Project1.ConcurrentCollections
{
    static class Example1
    {
        public static void Run()
        {
            Demo1();
        }

        static void Demo1()
        {
            var path = Path.Combine(Environment.CurrentDirectory, "WpfApp2");
            var file = $@"{path}\WpfApp2.exe";
            if (!File.Exists(file))
            {
                MessageBox.Show($"File {file} does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var proc = Process.Start(file);
            proc.WaitForExit();
        }
    }
}
