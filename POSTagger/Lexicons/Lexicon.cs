using POSTagger.Models;
using System.Collections.Generic;

namespace POSTagger.Lexicons
{
    public abstract class Lexicon
    {
        public Dictionary<string,int> WordMap { get; set; }
        public List<List<string>> TagMap { get; set; }
    }
}
