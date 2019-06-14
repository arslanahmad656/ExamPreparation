using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PracticeProject
{
    class LogWriter : IDisposable
    {
        StreamWriter log;
        bool disposed = false;

        public LogWriter(string filePath)
        {
            log = File.AppendText(filePath);
        }

        public async void Log(string entry)
        {
            await log.WriteLineAsync(entry);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }

            if (disposing)
            {
                log.Flush();
                log.Dispose();
            }

            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
