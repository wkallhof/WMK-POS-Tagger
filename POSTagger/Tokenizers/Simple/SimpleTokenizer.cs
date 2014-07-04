using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace POSTagger.Tokenizers.Simple
{
    public class SimpleTokenizer : ITokenizer
    {
        private static string numberPattern = @"([0-9]*\.[0-9]+|[0-9]+)";
        private static string whiteSpacePattern = @"([ \t\n\r])";
        private static string punctuationPattern = @"([\.\,\?\!])";

        public List<string> Tokenize(string inputText)
        {
            var tokens = Regex.Split(inputText, numberPattern, RegexOptions.IgnoreCase).AsEnumerable();
            tokens = tokens.SelectMany(x => Regex.Split(x, whiteSpacePattern, RegexOptions.IgnoreCase));
            tokens = tokens.SelectMany(x => Regex.Split(x, punctuationPattern, RegexOptions.IgnoreCase));

            return tokens.ToList();
        }

    }
}
