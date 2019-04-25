using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Project10.Basics
{
    static class Words
    {
        public static void Run()
        {
            //DemoWords();
            //DemoWordBoundaries();
            AnotherDemo();
        }

        static void DemoWords()
        {
            string text = "The quick brown fox jumps over the lazy dog.";
            Console.WriteLine($"There are {Regex.Matches(text, @"\b\w+\b").Count} words in {text}.");
        }

        static void AnotherDemo()
        {
            // find any words ending with 'ness'
            string sampleText = "Sickness takes away all of your happiness. First you feel sick; a time comes when sadness take over.";

            string pattern = @"\b\w*ness\b";

            Console.WriteLine($"Matching {sampleText} using {pattern}. Matches:");
            foreach (Match match in Regex.Matches(sampleText, pattern))
            {
                Console.WriteLine($"{match} at {match.Index}");
            }
        }

        static void DemoWordBoundaries()
        {
            // in this example we will match case-insensitively 'in' in a sentence

            string sampleText = "There are in words in the word binding.";

            DemoSimple();
            Console.WriteLine();
            DemoBoundaries();

            void DemoBoundaries()
            {
                string pattern = @"(?i)\bin\b"; // this will match only 'in' words. It will not match 'in' in 'binding'

                Console.WriteLine($"Matching {sampleText} using {pattern}. Matches:");
                foreach (Match match in Regex.Matches(sampleText, pattern))
                {
                    Console.WriteLine($"{match} at {match.Index}");
                }
            }

            void DemoSimple()
            {
                string pattern = @"(?i)in"; // this will match any 'in' pattern regardless of whether it appears as a word or in a word
                                            // For instance, this pattern matches two 'in' in the word 'binding'

                Console.WriteLine($"Matching {sampleText} using {pattern}. Matches:");
                foreach (Match match in Regex.Matches(sampleText, pattern))
                {
                    Console.WriteLine($"{match} at {match.Index}");
                }
            }
        }
    }
}
