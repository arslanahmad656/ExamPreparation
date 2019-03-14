using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Project6.UnsafeBasics
{
    [StructLayout(LayoutKind.Sequential)]
    unsafe struct UnsafeStruct
    {
        public int IntField;
        public char CharField;
        public fixed float FloatArrayField[100]; // an array! and not a reference to array
    }
}
