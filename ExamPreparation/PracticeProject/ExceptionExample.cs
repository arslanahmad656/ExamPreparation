using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProject
{
    class ExceptionExample
    {
        static void ProcessOrders (string orderRefNumber)
        {
            if (orderRefNumber == null)
            {
                throw new ArgumentNullException();
            }
        }

        static void Run()
        {
            try
            {
                string orderNumber = null;
                ProcessOrders(orderNumber);
            }
            catch (ArgumentNullException ex)
            {

                Console.WriteLine("argument null exception");
            }
            catch (Exception ex)
            {
                Console.WriteLine("main exception");
            }
        }
    }
}
