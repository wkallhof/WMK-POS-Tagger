using POSTagger.Corpora.BrillsEnglish;

namespace POSTagger.Corpora
{
    public static class CorpusFactory
    {
        public static Corpus GetCorpus(string lexiconName)
        {
            switch(lexiconName)
            {
                default: return new BrillsEnglishCorpus();
            }
        }
    }
}
