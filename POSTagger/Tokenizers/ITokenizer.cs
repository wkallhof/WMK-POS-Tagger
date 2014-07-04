using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSTagger.Tokenizers
{
    public interface ITokenizer
    {
        List<string> Tokenize(string inputText);
    }
}
