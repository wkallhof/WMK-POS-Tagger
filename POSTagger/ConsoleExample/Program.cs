using POSTagger.Corpora;
using POSTagger.Taggers;
using POSTagger.Tokenizers;
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
            text = "I made $5.60 today in 1 hour of work.  The E.M.T.'s were on time, but only barely.";

            var corpus = CorpusFactory.GetCorpus("brills");

            var tokenizer = TokenizerFactory.GetTokenizer("simple");
            var tokens = tokenizer.Tokenize(text);

            var tagger = TaggerFactory.GetTagger("simple");
            var results = tagger.Tag(corpus, tokens.Where(x => !string.IsNullOrWhiteSpace(x)).ToList());

            Console.WriteLine(String.Join(",",results.Select(x => string.Format("{0}({1})",x.Token,x.Tag))));
            Console.WriteLine("Press any key to exit");
            var stop = Console.ReadLine();
        }
    }
}
