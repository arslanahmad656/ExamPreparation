using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace Project2.Exceptions
{
    static class Exceptions1
    {
        public static void Run()
        {
            //DemoFinally1();
            DemoFinally2();
            //DemoFinally3();
            //DemoFinally4();
            //DemoFinally5();
        }

        static void DemoFinally1()
        {
            try
            {
                return;
            }
            finally
            {
                File.AppendAllText("return.log", DateTime.Now.ToLongTimeString());
            }
        }

        static void DemoFinally2()
        {
            try
            {
                throw new Exception();
            }
            finally
            {
                File.AppendAllText("exception.log", DateTime.Now.ToLongTimeString());
            }
        }

        static void DemoFinally3()
        {
            try
            {
                Environment.Exit(0);
            }
            finally
            {
                File.AppendAllText("exit.log", DateTime.Now.ToLongTimeString());
            }
        }

        static void DemoFinally4()
        {
            try
            {
                Environment.FailFast("");
            }
            finally
            {
                File.AppendAllText("fail.log", DateTime.Now.ToLongTimeString());
            }
        }

        static void DemoFinally5()
        {
            try
            {
                Process.GetCurrentProcess().Kill();
            }
            finally
            {
                System.IO.File.AppendAllText("kill.log", DateTime.Now.ToLongTimeString());
            }
        }
    }
}
