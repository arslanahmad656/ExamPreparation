using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Project10.Basics
{
    static class Groups
    {
        public static void Run()
        {
            DemoNumberedGroups();
            DemoNamesGroups();
        }

        static void DemoNumberedGroups()
        {
            // matching words starting and ending with same character

            string[] words = { "bob", "beep", "peep", "moon", "noon" };

            string pattern = @"\b(\w)\w+\1\b";

            Console.WriteLine($"Pattern: {pattern}");

            foreach (var word in words)
            {
                Match match = Regex.Match(word, pattern);

                Console.Write($"Matching {word}: {match.Success}");
                if (match.Success)
                {
                    Console.Write($" ({match.Value})");
                }
                Console.WriteLine();
            }
        }

        static void DemoNamesGroups()
        {
            // matching words starting and ending with same character

            string[] words = { "bob", "beep", "peep", "moon", "noon" };

            string pattern = @"\b(?<group1>\w)\w+\k<group1>\b";

            Console.WriteLine($"Pattern: {pattern}");

            foreach (var word in words)
            {
                Match match = Regex.Match(word, pattern);

                Console.Write($"Matching {word}: {match.Success}");
                if (match.Success)
                {
                    Console.Write($" ({match.Value})");
                }
                Console.WriteLine();
            }
        }
    }
}
