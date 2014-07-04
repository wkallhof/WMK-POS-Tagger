using System.Collections.Generic;

namespace POSTagger.Corpora
{
    public abstract class Corpus
    {
        public Dictionary<string,int> WordMap { get; set; }
        public List<List<string>> TagMap { get; set; }
    }
}
