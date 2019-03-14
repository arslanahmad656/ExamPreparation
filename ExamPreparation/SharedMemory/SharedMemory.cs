using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.ComponentModel;

namespace SharedMemory
{
    /// <summary>
    /// Represent a memory mapping.
    /// </summary>
    public class SharedMemory : IDisposable
    {
        private static readonly IntPtr _EmptyPtr;

        private IntPtr fileHandle;
        private IntPtr filePtr;

        static SharedMemory()
        {
            _EmptyPtr = new IntPtr(-1);
        }

        /// <summary>
        /// Creates a new memory mapping by the specified name.
        /// </summary>
        /// <param name="name">Name of the mapping to create</param>
        /// <param name="numberOfBytes">Number of bytes to allocate to the mapping</param>
        public SharedMemory(string name, uint numberOfBytes)
        {
            fileHandle = Win32Helper.CreateFileMapping(_EmptyPtr, 0, FileProtection.ReadWrite, 0, numberOfBytes, name);

            if (fileHandle == IntPtr.Zero)
            {
                throw new Win32Exception("Could not create the mapping");
            }

            MapViewOfFile();

            if (filePtr == IntPtr.Zero)
            {
                throw new Win32Exception("Could create the map view of file.");
            }
        }

        /// <summary>
        /// Subsribes to an existing mapping.
        /// </summary>
        /// <param name="name">The name of the existing mapping to subscribe to.</param>
        public SharedMemory(string name)
        {
            fileHandle = Win32Helper.OpenFileMapping(FileRights.ReadWrite, false, name);

            if (fileHandle == IntPtr.Zero)
            {
                throw new Win32Exception("Could not subscribe to the mapping");
            }

            MapViewOfFile();

            if (filePtr == IntPtr.Zero)
            {
                throw new Win32Exception("Could create the map view of file.");
            }
        }

        private void MapViewOfFile()
        {
            filePtr = Win32Helper.MapViewOfFile(fileHandle, FileRights.ReadWrite, 0, 0, 0);
        }

        public void Dispose()
        {
            if (filePtr != IntPtr.Zero)
            {
                Win32Helper.UnmapViewOfFile(filePtr);
            }

            if (fileHandle != IntPtr.Zero)
            {
                Win32Helper.CloseHandle(fileHandle);
            }

            filePtr = IntPtr.Zero;
            fileHandle = IntPtr.Zero;
        }
    }
}
