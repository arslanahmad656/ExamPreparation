using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using MEFCalculatorBL.Interfaces;

namespace MEFCalculatorOperations
{
    [Export(typeof(IOperation))]
    [ExportMetadata("Operator", "Add")]
    class AddOperation : IOperation
    {
        public double Operate(double left, double right)
        {
            return left + right;
        }
    }

    [Export(typeof(IOperation))]
    [ExportMetadata("Operator", "Subtract")]
    class SubtractOperation : IOperation
    {
        public double Operate(double left, double right)
        {
            return left - right;
        }
    }

    [Export(typeof(IOperation))]
    [ExportMetadata("Operator", "Multiply")]
    class MultiplyOperation : IOperation
    {
        public double Operate(double left, double right)
        {
            return left * right;
        }
    }

    [Export(typeof(IOperation))]
    [ExportMetadata("Operator", "Divide")]
    class DivideOperation : IOperation
    {
        public double Operate(double left, double right)
        {
            return left / right;
        }
    }

    [Export(typeof(IOperation))]
    [ExportMetadata("Operator", "Mod")]
    class ModOperation : IOperation
    {
        public double Operate(double left, double right)
        {
            return left % right;
        }
    }
}
