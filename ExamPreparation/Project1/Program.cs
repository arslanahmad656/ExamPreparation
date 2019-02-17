using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    class Program
    {
        static void Main(string[] args)
        {
            //ThreadBasics.TheadBasics.Run();
            ThreadBasics.TheadLocalData.Run();

            //Pause();
        }

        static void Pause()
        {
            Console.WriteLine("End of main reached. Press any key to continue...");
            Console.ReadKey();
        }
    }
}
