using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class CounterThreadSafe
    {
        private int sum;

        public CounterThreadSafe() => sum = 0;

        public void Add(int count) => Interlocked.Add(ref sum, count);

        public int GetSum() => sum;
    }
}
