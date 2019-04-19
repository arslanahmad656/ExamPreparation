using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Project10.Basics
{
    static class Fundamentals
    {
        public static void Run()
        {
            //DemoIsMatch();
            //DemoMatch();
            DemoEnumerableMatches("What is the color of an Orange? The colour of an oranGe is orange.", "[oO]ran[gG]e");
            DemoEnumerableMatches("Her name is Jennifer. At home, she is called Jen. She is known by her nickname Jenny.", "Jen(ny|nifer)?");
        }

        static void DemoEnumerableMatches(string text, string exp)
        {
            Console.WriteLine($"Text: {text}");
            Console.WriteLine();
            Console.WriteLine($"RegExp: {exp}");

            foreach (Match match in Regex.Matches(text, exp))
            {
                Console.WriteLine("Match Found:");
                Console.WriteLine($"\tIndex: {match.Index}");
                Console.WriteLine($"\tLength: {match.Length}");
                Console.WriteLine($"\tName: {match.Name}");
                Console.WriteLine($"\tSucess: {match.Success}");
                Console.WriteLine($"\tValue: {match.Value}");
            }
        }

        static void DemoMatch()
        {
            string text = "What is the color of an Orange? The colour of an orange is orange.";
            string exp = "colou?r";

            Console.WriteLine($"Text: {text}");
            Console.WriteLine($"RegExp: {exp}");

            Match match = Regex.Match(text, exp);

            Console.WriteLine("First Match:");
            Console.WriteLine($"\tIndex: {match.Index}");
            Console.WriteLine($"\tLength: {match.Length}");
            Console.WriteLine($"\tName: {match.Name}");
            Console.WriteLine($"\tSucess: {match.Success}");
            Console.WriteLine($"\tValue: {match.Value}");

            match = match.NextMatch();

            Console.WriteLine("Second Match:");
            Console.WriteLine($"\tIndex: {match.Index}");
            Console.WriteLine($"\tLength: {match.Length}");
            Console.WriteLine($"\tName: {match.Name}");
            Console.WriteLine($"\tSucess: {match.Success}");
            Console.WriteLine($"\tValue: {match.Value}");
        }

        static void DemoIsMatch()
        {
            string text = "color";
            string exp = "colou?r";
            Console.WriteLine($"{text} matches {exp}: {Regex.IsMatch(text, exp)}");

            text = "colour";
            Console.WriteLine($"{text} matches {exp}: {Regex.IsMatch(text, exp)}");

            text = "colur";
            Console.WriteLine($"{text} matches {exp}: {Regex.IsMatch(text, exp)}");
        }
    }
}
