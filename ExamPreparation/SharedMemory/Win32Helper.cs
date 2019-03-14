using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.ComponentModel;

namespace SharedMemory
{
    internal static class Win32Helper
    {
        /// <summary>
        /// Creates a new memory mapping
        /// </summary>
        /// <param name="hFile"></param>
        /// <param name="lpAttributes">Access mode of mapping</param>
        /// <param name="flProtect"></param>
        /// <param name="dwMaximumSizeHigh"></param>
        /// <param name="dwMaximumSizeLow">Number of bytes to allocate</param>
        /// <param name="lpName">Name of the memory mapping</param>
        /// <returns></returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern IntPtr CreateFileMapping(IntPtr hFile,
                                                int lpAttributes,
                                                FileProtection flProtect,
                                                uint dwMaximumSizeHigh,
                                                uint dwMaximumSizeLow,
                                                string lpName);

        /// <summary>
        /// Subscribes to an existing memory mapping
        /// </summary>
        /// <param name="dwDesiredAccess">Access mode of the mapping</param>
        /// <param name="bInheritHandle"></param>
        /// <param name="lpName">Name of the memory mapping to which to subscribe</param>
        /// <returns></returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern IntPtr OpenFileMapping(FileRights dwDesiredAccess,
                                                bool bInheritHandle,
                                                string lpName);

        /// <summary>
        /// Converts the file handle to a pointer
        /// </summary>
        /// <param name="hFileMappingObject">File handle to convert</param>
        /// <param name="dwDesiredAccess">Access mode to assign</param>
        /// <param name="dwFileOffsetHigh"></param>
        /// <param name="dwFileOffsetLow"></param>
        /// <param name="dwNumberOfBytesToMap"></param>
        /// <returns></returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern IntPtr MapViewOfFile(IntPtr hFileMappingObject,
                                            FileRights dwDesiredAccess,
                                            uint dwFileOffsetHigh,
                                            uint dwFileOffsetLow,
                                            uint dwNumberOfBytesToMap);

        /// <summary>
        /// Converts the pointer back to handle.
        /// </summary>
        /// <param name="map">File pointer to convert</param>
        /// <returns></returns>
        [DllImport("Kernel32.dll", SetLastError = true)]
        internal static extern bool UnmapViewOfFile(IntPtr map);

        /// <summary>
        /// Closes the memory mapping using file handle (not pointer!)
        /// </summary>
        /// <param name="hObject">Handle of the memory mapping to close</param>
        /// <returns></returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern int CloseHandle(IntPtr hObject);
    }
}
