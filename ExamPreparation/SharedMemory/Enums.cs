using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedMemory
{
    public enum MemoryMode
    {
        /// <summary>
        /// Subscribe to an existing memory mapping
        /// </summary>
        Subscribe,

        /// <summary>
        /// Create a new memory mapping
        /// </summary>
        Create
    }

    enum FileProtection : uint // constants from winnt.h
    {
        ReadOnly = 2,
        ReadWrite = 4
    }

    enum FileRights : uint // constants from WinBASE.h
    {
        Read = 4,
        Write = 2,
        ReadWrite = Read + Write
    }
}
