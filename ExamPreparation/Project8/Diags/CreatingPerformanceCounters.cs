using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Project8.Diags
{
    static class CreatingPerformanceCounters
    {
        static PerformanceCounter TotalImagesCounter;
        static PerformanceCounter ImagesProcessPerSecondCounter;

        public static void Run()
        {
            Demo();
        }

        static void Demo()
        {

        }

        
    }

    enum CounterSetupResult
    {
        Created,
        Loaded
    }
}
