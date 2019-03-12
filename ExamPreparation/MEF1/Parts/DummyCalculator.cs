using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using MEF1.Interfaces;

namespace MEF1.Parts
{
    [Export(typeof(ICalculator))]   // Specify that this class is an export that will be discovered by a catalog
    class DummyCalculator : ICalculator
    {
        public string Calculate(string expression) => $"Evaluated {expression}";
    }
}
