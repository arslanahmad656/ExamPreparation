using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;
using System.Net;

namespace PracticeProject
{
    static class PracticeFile3
    {
        public static void Run()
        {
            //CheckDataContractSerialization();
            CheckDownloadImage();
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
