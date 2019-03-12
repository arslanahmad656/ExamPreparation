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
    // The following classes specify the exports available for imports of type IOperation.
    // These exports also specify the metadata that can be used in the imports
    // Note that although the classes implementing IOperation are defined, there is not one
    // defined that implements IOperationData. This class is left to be created by the composition
    // container for each export.

    [Export(typeof(IOperation))]
    [ExportMetadata("Symbol", '+')]
    class Add : IOperation
    {
        public int Operate(int left, int right) => left + right;
    }

    [Export(typeof(IOperation))]
    [ExportMetadata("Symbol", '-')]
    class Subtract : IOperation
    {
        public int Operate(int left, int right) => left - right;
    }

    [Export(typeof(IOperation))]
    [ExportMetadata("Symbol", '*')]
    class Multiply : IOperation
    {
        public int Operate(int left, int right) => left * right;
    }

    [Export(typeof(IOperation))]
    [ExportMetadata("Symbol", '/')]
    class Divide : IOperation
    {
        public int Operate(int left, int right) => left / right;
    }
}
