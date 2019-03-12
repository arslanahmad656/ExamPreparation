using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using MEF1.Interfaces;

namespace MEF1
{
    class Program
    {
#pragma warning disable CS0649  // suppress the ugly warning highlighter arising because this field will never be assigned to at compile time. This field is assigned value by the composition engine
        [Import(typeof(ICalculator))]   // Means that out of the exports made available by the catalog, ICalculator type will be used to fill in this
        private ICalculator calculator; // this is an import that will be filled in by the composition container
#pragma warning restore CS0649

        private static Program _app;

        static Program()
        {
            _app = new Program();
        }

        private Program()
        {
            var catalog = new AggregateCatalog();   // a catalog that will discover the available exports from some source
            catalog.Catalogs.Add(new AssemblyCatalog(this.GetType().Assembly)); // specifying that the catalog should discover the exports from 'this' assembly (which is the current project)

            var container = new CompositionContainer(catalog);  // create a composition container that will satisfy the imports of some object (specified below) with the exports discovered by the catalog object.
            try
            {
                container.ComposeParts(this);   // specify that the composition container should start composing the parts (i.e. start satisfying the imports) of 'this' object
                                                // Lest an export matching the import for calculator is discovered by the catalog object, the composition container will not be able to satisfy the said import and will throw an exception.
            }
            catch (CompositionException ex)
            {
                Console.WriteLine("Error while composing: " + ex.Message);
                Environment.FailFast("", ex);
            }
        }

        static void Main(string[] args)
        {
            var result = _app.calculator.Calculate("2+3");  // lest the calculator import is satisfied by the composition container, this line will throw null

            Console.WriteLine(result);
        }
    }
}
