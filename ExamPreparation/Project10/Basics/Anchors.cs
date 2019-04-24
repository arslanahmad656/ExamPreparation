using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Project10.Basics
{
    static class Anchors
    {
        public static void Run()
        {
            //Demo1();
            //Demo2();
            //DemoEmptyLines();
            DemoPasswordPolicy();
        }

        static void DemoPasswordPolicy()
        {
            string[] samplePasswords = new[]
            {
                "updating",
                "updating1",
                "12345678",
                "updating$",
                "7updating",
                "upd6ating$",
                "Updating6*",
                "small1"
            };

            Demo1();

            void Demo1()
            {
                // enforcing a password having at least 8 characters

                string pattern = @"(?=.*\d).{8,}";

                Console.WriteLine("Matched passwords:");
                foreach (var pwd in samplePasswords)
                {
                    var match = Regex.Match(pwd, pattern);
                    Console.Write($"{pwd} matches {pattern}: {match.Success}");
                    if (match.Success)
                    {
                        Console.Write($" ({match})");
                    }
                    Console.WriteLine();
                }
            }
        }

        static void DemoEmptyLines()
        {
            var text = $@"This textis splitted
{'\t'}
in to multiple
lines;

It might
also
contain some 
{'\t'}{'\t'}
empty lines.
";    // On windows, new line is \r\n; on linux it is \n

            Console.WriteLine("Sample text:");
            Console.WriteLine($"'{text}'");

            DemoStrictlyEmptyLines();
            DemoWhitespaces();

            void DemoWhitespaces()  // containing only spaces or tabs
            {
                string pattern = @"(?m)^[ \t]*(?=\r?$)";

                Console.WriteLine("Whitespce lines in occurs at the following locations:");

                foreach (Match match in Regex.Matches(text, pattern))
                {
                    Console.WriteLine($"At {match.Index} after {text[match.Index - 3]}");
                }
            }

            void DemoStrictlyEmptyLines()   // only those containing only spaces
            {
                string pattern = @"(?m)^(?=\r?$)";

                Console.WriteLine("Empty lines in occurs at the following locations:");

                foreach (Match match in Regex.Matches(text, pattern))
                {
                    Console.WriteLine($"At {match.Index} after {text[match.Index - 3]}");
                }
            }
        }

        static void Demo1()
        {
            string text = "bob";
            string pattern = @"^b";
            Match match = Regex.Match(text, pattern);
            Console.WriteLine($"Matching {text} with {pattern}: {match} at {match.Index}");
            pattern = @"b$";
            match = Regex.Match(text, pattern);
            Console.WriteLine($"Matching {text} with {pattern}: {match} at {match.Index}");
        }

        static void Demo2()
        {
            string fileNames = "a.txt" + "\r\n" + "b.doc" + "\r\n" + "c.txt";

            DemoSingleLineMode();
            DemoMultilineMode();

            void DemoSingleLineMode()
            {
                // find filenames ending with .txt at boundaries.
                // By default, it matches only at string ends.

                string pattern = @".+\.txt(?=\r?$)";

                foreach (Match match in Regex.Matches(fileNames, pattern))
                {
                    Console.WriteLine($"{match} at {match.Index}");
                }
            }

            void DemoMultilineMode()
            {
                // when in multiline mode, it will match both at the end of string or at the end of lines

                string pattern = @"(?m).+\.txt(?=\r?$)";

                foreach (Match match in Regex.Matches(fileNames, pattern))
                {
                    Console.WriteLine($"{match} at {match.Index}");
                }
            }
        }
    }
}
