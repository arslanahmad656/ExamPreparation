using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Project7.ExpressionTrees
{
    static class GeneratingExpressionTrees
    {
        /*
         
            This example generates the following lambda expression at runtime:

            Func<int, int> lambda = num => num * num;
            
        */
        public static void Run()
        {
            Demo();
        }

        static void Demo()
        {
            Func<int, int> lambda = GenerateLambda();
            int result = lambda(2);
            Console.WriteLine("Square of 2 is " + result);
        }

        static Func<int, int> GenerateLambda()
        {
            ParameterExpression numParam = Expression.Parameter(typeof(int), "num");   // create a expression parameter
            BinaryExpression expression = Expression.Multiply(numParam, numParam);  // indicate that the opertion is num * num

            Expression<Func<int, int>> tree = Expression.Lambda<Func<int, int>>(expression, numParam);
            Func<int, int> lambda = tree.Compile();
            return lambda;
        }
    }
}
