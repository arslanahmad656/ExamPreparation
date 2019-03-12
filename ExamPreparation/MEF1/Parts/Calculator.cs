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
    class Calculator : ICalculator
    {
#pragma warning disable CS0649
        [ImportMany(typeof(IOperation))]    // The list will be populated by the composition container using a number of exports available
                        // Note that no type is supplied as argument to the attribute- the type will be determined by the composition container as IOperation.
                        // ImportMany is used because there can be more than one export available matching the import of type IOperation.
        private IEnumerable<Lazy<IOperation, IOperationData>> operations;  // Lazy<T, TMetaData> supports two properties among other ones: Value and MetaData.
#pragma warning disable

        public string Calculate(string expression)
        {
            // Parsing of the expression
            var operatorIndex = FindFirstNonDigit(expression);
            if (operatorIndex == -1)
            {
                throw new FormatException("Cannot parse the expression");
            }

            var op = expression[operatorIndex];
            if (op != '+' && op != '-' && op != '*' && op !=  '/')
            {
                throw new FormatException("Operator not recognized");
            }

            var left = int.Parse(expression.Substring(0, operatorIndex));
            var right = int.Parse(expression.Substring(operatorIndex + 1));

            // The calculation is done based on the availablity of exports supporting the operations
            foreach (Lazy<IOperation, IOperationData> export in operations)
            {
                var @operator = export.Metadata.Symbol; // Never in the exports (see CalculatorOperations.cs) is declared a class implementing IOperationData.
                                                        // This class is created during composition.
                if (@operator == op)
                {
                    var result = export.Value.Operate(left, right);
                    return result.ToString();
                }
            }

            throw new Exception("The underlying type does not support " + op + " operation");
        }

        private int FindFirstNonDigit(string expression)
        {
            for (int i = 0; i < expression.Length; i++)
            {
                if (!char.IsDigit(expression[i]))
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
