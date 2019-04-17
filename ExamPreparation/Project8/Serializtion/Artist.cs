using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project8.Serializtion
{
    [Serializable]
    class Artist
    {
        public string Name { get; set; }

        public override string ToString() => Name;
    }
}
