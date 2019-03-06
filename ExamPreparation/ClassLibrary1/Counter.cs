using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Counter
    {
        private int sum;

        public Counter() => sum = 0;

        public void Add(int count) => sum += count;

        public int GetSum() => sum;
    }
}
