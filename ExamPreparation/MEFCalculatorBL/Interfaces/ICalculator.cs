using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEFCalculatorBL.Interfaces
{
    public interface ICalculator
    {
        double Calculate(double left, double right, string operation);
    }
}
