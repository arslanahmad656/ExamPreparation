using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace PracticeProject
{
    [DataContract]
    [Serializable]
    class Class11
    {
        string oneValue;

        [DataMember]
        private string OneValue
        {
            get { return oneValue; }
            set { oneValue = value; }
        }

        public Class11(string _oneValue)
        {
            oneValue = _oneValue;
        }
    }

    [DataContract]
    class Class12
    {
        List<string> values;
        
        [DataMember]
        private List<string> Values
        {
            get { return values; }
            set { values = value; }
        }

        public Class12(List<string> _values)
        {
            values = _values;
        }

        public Class12()
        {

        }
    }
}