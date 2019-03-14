using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace SharedMemory
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct SampleStruct
    {
        public int IntField;
        public char CharField;
        public fixed float FloatArrayField[100];
    }
}
