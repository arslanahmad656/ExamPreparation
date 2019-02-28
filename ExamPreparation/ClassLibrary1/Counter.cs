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

        public void Add(int count)
        {
            for (int i = 0; i < count; i++)
            {
                sum = sum + 1;
            }
        }

        public int GetSum() => sum;
    }
}
