using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Project10.Basics
{
    static class Quantifiers
    {
        public static void Run()
        {
            //Demo1();
            //Demo2();
            //Demo3();
            //Demo4();
            //Demo5();
            //Demo6();
            GreedyVsLazyQuantifier();
        }

        static void Demo1()
        {
            // demo *

            // The following matches cv.doc, along with any numbered versions of the same file(e.g., cv2.doc, cv15.doc):

            string pattern = @"cv\d*\.doc";
            foreach (var item in new[] { "cv.doc", "cv1.doc", "cv13.doc", "cvmy.doc" })
            {
                var match = Regex.Match(item, pattern);
                Console.Write($"{item} matches {pattern}: {match.Success}");
                if (match.Success)
                {
                    Console.Write($" ({match.Value}, {match.Index})");
                }
                Console.WriteLine();
            }
        }

        static void Demo2()
        {
            // demo *

            // The following matches only that cv.doc having a number appended to it(e.g., cv2.doc, cv15.doc):

            string pattern = @"cv\d+\.doc";
            foreach (var item in new[] { "cv.doc", "cv1.doc", "cv13.doc", "cvmy.doc" })
            {
                var match = Regex.Match(item, pattern);
                Console.Write($"{item} matches {pattern}: {match.Success}");
                if (match.Success)
                {
                    Console.Write($" ({match.Value}, {match.Index})");
                }
                Console.WriteLine();
            }
        }

        static void Demo3()
        {
            // demo *

            // The following matches only cv.doc or a single-numbered version of cv.doc (eg. cv2.doc)

            string pattern = @"cv\d?\.doc";
            foreach (var item in new[] { "cv.doc", "cv1.doc", "cv13.doc", "cvmy.doc" })
            {
                var match = Regex.Match(item, pattern);
                Console.Write($"{item} matches {pattern}: {match.Success}");
                if (match.Success)
                {
                    Console.Write($" ({match.Value}, {match.Index})");
                }
                Console.WriteLine();
            }
        }

        static void Demo4()
        {
            // demo *

            // The following matches only single-numbered versions of cv.doc (eg. cv2.doc)

            string pattern = @"cv\d{1}\.doc";
            foreach (var item in new[] { "cv.doc", "cv1.doc", "cv13.doc", "cvmy.doc" })
            {
                var match = Regex.Match(item, pattern);
                Console.Write($"{item} matches {pattern}: {match.Success}");
                if (match.Success)
                {
                    Console.Write($" ({match.Value}, {match.Index})");
                }
                Console.WriteLine();
            }
        }

        static void Demo5()
        {
            // demo *

            // The following matches only three-numbered to six-numbered versions of cv.doc (eg. cv100.doc, cv666555.doc)

            string pattern = @"cv\d{3,6}\.doc";
            foreach (var item in new[] { "cv.doc", "cv1.doc", "cv100.doc", "cv666555.doc", "cv001.doc" })
            {
                var match = Regex.Match(item, pattern);
                Console.Write($"{item} matches {pattern}: {match.Success}");
                if (match.Success)
                {
                    Console.Write($" ({match.Value}, {match.Index})");
                }
                Console.WriteLine();
            }
        }

        static void Demo6()
        {
            // demo *

            // The following matches only three-numbered to six-numbered versions of cv.doc (eg. cv100.doc, cv666555.doc)
            // such that there is no leading zero like (cv001.doc)

            string pattern = @"cv[1-9]\d{2,5}\.doc";
            foreach (var item in new[] { "cv.doc", "cv1.doc", "cv100.doc", "cv666555.doc", "cv001.doc", "cv0656.doc" })
            {
                var match = Regex.Match(item, pattern);
                Console.Write($"{item} matches {pattern}: {match.Success}");
                if (match.Success)
                {
                    Console.Write($" ({match.Value}, {match.Index})");
                }
                Console.WriteLine();
            }
        }

        static void GreedyVsLazyQuantifier()
        {
            string text = "<i>By default</i>, quantifiers are <i>greedy</i>.";
            DemoGreedy();
            DemoLazy();

            void DemoGreedy()
            {
                var pattern = @"<i>.*</i>";
                Console.WriteLine($"Matching {text} with {pattern}. Matches found:");
                foreach (Match match in Regex.Matches(text, pattern))
                {
                    Console.WriteLine(match);
                }
            }

            void DemoLazy()
            {
                var pattern = @"<i>.*?</i>";
                Console.WriteLine($"Matching {text} with {pattern}. Matches found:");
                foreach (Match match in Regex.Matches(text, pattern))
                {
                    Console.WriteLine(match);
                }
            }
        }
    }
}
