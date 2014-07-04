using POSTagger.Corpora;
using POSTagger.Taggers.Simple;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSTagger.Taggers
{
    public class TaggerFactory
    {
        public static ITagger GetTagger(string taggerName)
        {
            switch(taggerName)
            {
                default: return new SimpleTagger();
            }
        }
    }
}
