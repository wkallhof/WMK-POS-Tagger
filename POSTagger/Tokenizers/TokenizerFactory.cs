using POSTagger.Tokenizers.Simple;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSTagger.Tokenizers
{
    public class TokenizerFactory
    {
        public static ITokenizer GetTokenizer(string tokenizerName)
        {
            switch(tokenizerName)
            {
                default: return new SimpleTokenizer();
            }
        }
    }
}
