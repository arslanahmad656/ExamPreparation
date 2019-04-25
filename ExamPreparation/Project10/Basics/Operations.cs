using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Project10.Basics
{
    static class Operations
    {
        public static void Run()
        {
            //DemoStringVsRegex();
            ReplacingHtmlTagWithAttribute();
        }

        static void DemoStringVsRegex()
        {
            string text = "cat is sniffing the catapult.";
            string toReplace = "cat";
            string replaceWith = "dog";

            Console.WriteLine($"Text: {text}");
            Console.WriteLine($"Replacing {toReplace} with {replaceWith}");

            DemoStringReplace();
            DemoRegexReplace();

            void DemoStringReplace()
            {
                Console.WriteLine();
                Console.WriteLine("Replacing with String method. Result:");

                var replaced = text.Replace(toReplace, replaceWith);
                Console.WriteLine(replaced);
            }

            void DemoRegexReplace()
            {
                Console.WriteLine();
                Console.WriteLine("Replacing with Regex method. Result:");

                var replaced = Regex.Replace(text, "\bcat\b", replaceWith);
                Console.WriteLine(replaced);
            }
        }

        static void ReplacingHtmlTagWithAttribute()
        {
            string pattern = @"(?i)<(?<tagName>[a-z]\w*?)>" // starting tag
                            + @"(?<content>.+?)"    // content of a tag
                            + @"</\k<tagName>>";

            string replaceWith = @"<${tagName} value=""${content}""/>";

            Console.WriteLine(Regex.Replace("<msg>hello</msg>", pattern, replaceWith));
        }
    }
}
