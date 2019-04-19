using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Project10.Basics
{
    static class Options
    {
        public static void Run()
        {
            DemoCaseInsensitiveMatching();
            DemoWhitespaceIgnoreExample();
        }

        static void DemoWhitespaceIgnoreExample()
        {
            var text = "orange";
            var exp = "or ange";
            Console.WriteLine($"Testing {text} against {exp}: {Regex.Match(text, exp)}");

            exp = "(?x)or ange";
            Console.WriteLine($"Testing {text} against {exp}: {Regex.Match(text, exp)}");
        }

        static void DemoCaseInsensitiveMatching()
        {
            string text = "What is the color of an Orange? The colour of an oranGe is orange.";

            DemoUsingOptionsEnum();
            DemoUsingInlineOptions();

            Console.WriteLine("Another example matching AAAa against (?i)a(?-i)a");
            Console.WriteLine(Regex.Match("AAAa", "(?i)a(?-i)a"));  // will match one of the aa or Aa

            void DemoUsingInlineOptions()
            {
                var exp = "(?i)(orange)";

                Console.WriteLine("Text: " + text);
                Console.WriteLine("Pattern: " + exp);
                foreach (var matche in Regex.Matches(text, exp))
                {
                    Console.WriteLine(matche);
                }
            }

            void DemoUsingOptionsEnum()
            {
                var exp = "orange";

                Console.WriteLine("Text: " + text);
                Console.WriteLine("Pattern: " + exp);
                foreach (var match in Regex.Matches(text, exp, RegexOptions.IgnoreCase))
                {
                    Console.WriteLine(match);
                }
            }

        }
    }
}
