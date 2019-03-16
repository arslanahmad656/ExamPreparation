using System;
using System.Runtime.InteropServices;

namespace COMComponent
{
    [InterfaceType(ComInterfaceType.InterfaceIsDual)]
    [Guid("c444c41e-4bb7-4ec6-a5ef-5ae069a28c21")]
    public interface ISampleCOM
    {
        [DispId(1)]
        int GetInteger(int input);
    }
}