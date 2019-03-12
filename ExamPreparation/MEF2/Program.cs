using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

namespace MEF2
{

    class Program
    {
        [Import(typeof(ICalculator))]
        public ICalculator calculator;

        private CompositionContainer container;

        private Program()
        {
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(Program).Assembly));
            container = new CompositionContainer(catalog);
            container.ComposeParts(this);
        }

        static void Main(string[] args)
        {
            var p = new Program();
            var result = p.calculator.Calculate("3+4");
            Console.WriteLine(result);
        }
    }

    [Export(typeof(ICalculator))]
    class Calculator : ICalculator
    {
        [ImportMany]
        private IEnumerable<Lazy<IOperation, IOperationData>> operations;

        public string Calculate(string expression)
        {
            return $"Calculated {expression}";
        }
    }

    [Export(typeof(IOperation))]
    [ExportMetadata("Symbol", )]
    class Add : IOperation
    {
        public int Operate(int left, int right)
        {
            Console.WriteLine("Operating in Add.");
            return 1;
        }
    }

    public interface ICalculator
    {
        string Calculate(string expression);
    }

    public interface IOperation
    {
        int Operate(int left, int right);
    }

    public interface IOperationData
    {
        char Symbol { get; }
    }
}
