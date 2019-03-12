using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using MEF1.Interfaces;


namespace OperationsMEF.Operations
{
    [Export(typeof(IOperation))]
    [ExportMetadata("Symbol", '%')]
    public class Mod : IOperation
    {
        public int Operate(int left, int right)
        {
            return left % right;
        }
    }

    [Export(typeof(IOperation))]
    [ExportMetadata("Symbol", '^')]
    public class AnOperation1 : IOperation
    {
        public int Operate(int left, int right)
        {
            Console.WriteLine("Opreation 1");
            return 1;
        }
    }

    [Export(typeof(IOperation))]
    [ExportMetadata("Symbol", '$')]
    class AnOperation2 : IOperation // Even the internal classes in other assemblies are available as exports to catalogs
    {
        public int Operate(int left, int right)
        {
            Console.WriteLine("Opreation 2");
            return 1;
        }
    }
}
