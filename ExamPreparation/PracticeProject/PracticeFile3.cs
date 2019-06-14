using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;

namespace PracticeProject
{
    static class PracticeFile3
    {
        public static void Run()
        {
            //CheckDataContractSerialization();
            //CheckDownloadImage();
            //TestLogger();
            SerializingTest();
        }

        static void SerializingTest()
        {
            Case1();
            Case2();
            Case3();

            void Case1()
            {
                var obj = new Class11("Some value in Class11");
                using (var fs = File.Create("Class11.bin"))
                {
                    var ser = new BinaryFormatter();
                    ser.Serialize(fs, obj);
                }
            }

            void Case2()
            {
                var obj = new Class11("Serializing using data contract serializer");

                using (var fs = File.Create("Class11_1.xml"))
                {
                    var ser = new DataContractSerializer(typeof(Class11));
                    ser.WriteObject(fs, obj);
                }
            }

            void Case3()
            {
                var obj = new Class12();

                using (var fs = File.Create("Class12.xml"))
                {
                    var ser = new DataContractSerializer(typeof(Class12));
                    ser.WriteObject(fs, obj);
                }
            }
        }

        static void TestLogger()
        {
            using (LogWriter lw = new LogWriter("logfile.txt"))
            {
                lw.Log("new log entry");
                lw.Dispose();
            }
        }

        static void CheckDownloadImage()
        {
            var client = new WebClient();
            client.DownloadFile(@"https://img-prod-cms-rt-microsoft-com.akamaized.net/cms/api/am/imageFileData/RE1MmB8?ver=6c43g", "img.png");
            client.Dispose();
        }

        static void CheckDataContractSerialization()
        {
            var ind1 = new Individual();
            var ind2 = new Individual
            {
                FirstName = "Arslan",
                LastName = "Ahmad"
            };

            var serializer = new DataContractSerializer(typeof(Individual));
            using (var fs = File.Create("individual1.txt"))
            {
                serializer.WriteObject(fs, ind1);
                serializer.WriteObject(fs, ind2);
                fs.Flush();
            }
        }
    }

    [DataContract(Name = "AnInidividual")]
    class Individual
    {
        private string m_FirstName;
        private string m_LastName;

        [DataMember]
        public string FirstName { get => m_FirstName; set => m_FirstName = value; }

        [DataMember(EmitDefaultValue = false)]
        public string LastName { get => m_LastName; set => m_LastName = value; }

        public Individual() { }
    }
}
