using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Reflection;
using MEFCalculatorBL.Interfaces;

namespace MEFCalculatorBL
{
    public class Calculator : ICalculator
    {
        [ImportMany]
        private IEnumerable<Lazy<IOperation, IOperationData>> operations;

        public Calculator()
        {
            var folderName = "MEFCalculatorPluginsDirectory";
            var path = Path.Combine(@"../../../", folderName);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new DirectoryCatalog(path));
            var container = new CompositionContainer(catalog);
            container.ComposeParts(this);
        }

        public List<string> AvailableOperations
        {
            get
            {
                var available = operations.Select(op => op.Metadata.Operator).ToList();
                return available;
            }
        }

        public double Calculate(double left, double right, string operation)
        {
            foreach (var export in operations)
            {
                var op = export.Metadata.Operator;
                if (operation.Equals(op, StringComparison.InvariantCultureIgnoreCase))
                {
                    var result = export.Value.Operate(left, right);
                    return result;
                }
            }

            throw new Exception($"Operator {operation} not recognized.");
        }
    }
}
