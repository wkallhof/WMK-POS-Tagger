using POSTagger.Lexicons.BrillsEnglish;

namespace POSTagger.Lexicons
{
    public static class LexiconFactory
    {
        public static Lexicon GetLexicon(string lexiconName)
        {
            switch(lexiconName)
            {
                default: return new BrillsEnglishLexicon();
            }
        }
    }
}
