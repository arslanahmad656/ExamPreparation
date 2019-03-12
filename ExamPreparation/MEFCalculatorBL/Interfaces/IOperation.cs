using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEFCalculatorBL.Interfaces
{
    public interface IOperation
    {
        double Operate(double left, double right);
    }
}
