using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3.Conversions
{
    class Example1
    {
        public static void Run()
        {
            Demo();
        }

        static void Demo()
        {
            var distSi = new DistanceSI(50, 25);
            DistanceMetric metric = distSi;
            Console.WriteLine(metric);
        }
    }
}
