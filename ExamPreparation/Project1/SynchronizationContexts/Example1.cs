using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Windows;
using System.Xaml;
using WpfApp1;
using FormsApplication = System.Windows.Forms.Application;
using WpfApplication = System.Windows.Application;

namespace Project1.SynchronizationContexts
{
    static class Example1
    {
        public static void Run()
        {
            FormsApplication.EnableVisualStyles();
            //DemoStartForm();
            //Demo1();
            Demo2();
        }

        static void Demo2()
        {
            var app = new WpfApplication();
            app.Run(new MainWindow());
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
