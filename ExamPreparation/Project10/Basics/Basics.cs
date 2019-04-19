using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Project10.Basics
{
    static class Basics
    {
        public static void Run()
        {
            DisplayNotes();
        }

        static void DisplayNotes()
        {
            string notes = File.ReadAllText(@"Basics\Notes.txt");
            Console.WriteLine(notes);
        }
    }
}
