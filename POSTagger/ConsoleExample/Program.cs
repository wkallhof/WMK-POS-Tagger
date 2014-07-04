using POSTagger.Lexicons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter text to tag");
            var text = Console.ReadLine();

            var lexicon = LexiconFactory.GetLexicon("brills");
            var tags = lexicon.TagMap;
            var words = lexicon.WordMap;

            Console.WriteLine("Press any key to exit");
            var stop = Console.ReadLine();
        }
    }
}
