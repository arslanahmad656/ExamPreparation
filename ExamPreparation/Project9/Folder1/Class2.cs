using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Runtime.Serialization;

namespace Project9.Folder1
{
    static class Class2
    {
        public static void Run()
        {
            WriteXmlDocument();
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
}
