using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEF1.Interfaces
{
    public interface ICalculator    // It is very important to make the interfaces public, otherwise MEF won't be able to find these and will raise exceptions
    {
        string Calculate(string expression);
    }
}
