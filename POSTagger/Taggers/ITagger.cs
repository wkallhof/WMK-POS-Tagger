using POSTagger.Corpora;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSTagger.Taggers
{
    public interface ITagger
    {
        List<TaggerResult> Tag(Corpus corpus, List<string> tokens);
    }
}
