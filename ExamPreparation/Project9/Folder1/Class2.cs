using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Runtime.Serialization;
using System.Diagnostics;

namespace Project9.Folder1
{
    static class Class2
    {
        public static void Run()
        {
            //WriteXmlDocument();
            //DisposeCheck();
            LogCheck();
        }

        static void LogCheck()
        {
            BaseLogger logger = new Logger();
            logger.Log("Log started");
            
            ((Logger)logger).LogCompleted();
        }

        static void DisposeCheck()
        {
            Disposable disposable1;
            using (disposable1 = new Disposable())
            {
                disposable1.OnDisposed += (sender, e) => DisposedEventHandler(nameof(disposable1));
            }

            using (var disposable2 = new Disposable())
            {
                disposable2.OnDisposed += (sender, e) => DisposedEventHandler(nameof(disposable2));
            }

            void DisposedEventHandler(string name)
            {
                Console.WriteLine($"{name} disposed");
            }
        }

        static void CheckDirectives()
        {
#if DEBUG
            Console.WriteLine("Entering debug mode");
#else
            Console.WriteLine("Entering release mode");
#endif
        }

        static void WriteXmlDocument()
        {
            XmlWriterSettings settings = new XmlWriterSettings
            {
                Indent = true
            };

            XmlWriter writer = XmlWriter.Create(Console.Out, settings);

            writer.WriteStartDocument();

            writer.WriteStartElement("name");
            writer.WriteAttributeString("fullname", "Arslan Ahmad 656");
            writer.WriteEndElement();

            writer.WriteEndDocument();

            writer.Flush();
        }
    }

    abstract class BaseLogger
    {
        public virtual void Log(string message)
        {
            Console.WriteLine("Base: " + message);
        }

        public void LogCompleted()
        {
            Console.WriteLine("Finished");
        }
    }

    class Logger : BaseLogger
    {
        public override void Log(string message)
        {
            Console.WriteLine(message);
        }

        public new void LogCompleted()
        {
            Console.WriteLine("Finished");
        }
    }

    class Disposable : IDisposable
    {
        public event EventHandler<ObjectDisposedEventArgs> OnDisposed;

        public void Dispose()
        {
            Console.WriteLine("Disposed");
            OnDisposed?.Invoke(new object(), new ObjectDisposedEventArgs());
        }
    }

    class ObjectDisposedEventArgs
    {

    }
}
