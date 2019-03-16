using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace COMComponent
{
    [ClassInterface(ClassInterfaceType.None)]
    [Guid("ff291463-a426-4af8-8565-f28a76dea520")]
    public class SampleCOM : ISampleCOM
    {
        public int GetInteger(int input)
        {
            return input * 2;
        }
    }
}
