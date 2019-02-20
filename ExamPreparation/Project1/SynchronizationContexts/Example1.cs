using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Diagnostics;

namespace Project1.SynchronizationContexts
{
    static class Example1
    {
        public static void Run()
        {
            Application.EnableVisualStyles();
            //DemoStartForm();
            //Demo1();
            DemoWpfSynchronizationContext();
        }

        static void DemoWpfSynchronizationContext()
        {
            var path = Path.Combine(Environment.CurrentDirectory, "WpfApp1");
            var file = $@"{path}\WpfApp1.exe";
            if (!File.Exists(file))
            {
                MessageBox.Show($"File {file} does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var proc = Process.Start(file);
            proc.WaitForExit();
        }

        static void Demo1()
        {
            var form = new Common.Form1();
            form.ShowDialog();
        }

        static void DemoStartForm()
        {
            var form = new Form
            {
                Text = "Demo Form",
                Size = new System.Drawing.Size(640, 480)
            };

            //Application.EnableVisualStyles();
            form.ShowDialog();
        }
    }
}
