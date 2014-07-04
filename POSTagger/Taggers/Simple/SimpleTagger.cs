using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POSTagger.Corpora;

namespace POSTagger.Taggers.Simple
{
    public class SimpleTagger : ITagger
    {

        public List<TaggerResult> Tag(Corpus corpus, List<string> tokens)
        {
            var ret = new string[tokens.Count];

            for (int i = 0, size = tokens.Count; i < size; i++) {

                if(!corpus.WordMap.ContainsKey(tokens[i]) || !corpus.WordMap.ContainsKey(tokens[i].ToLower()))
                {
                    ret[i] = tokens[i].Length == 1 ? "^" : "NN";
                }
                else
                {
                    var value = corpus.WordMap[tokens[i]];
                    ret[i] = corpus.TagMap[value][0];
                }
                    
            }
	
	        /**
             * Apply transformational rules
             **/
            for (int i = 0; i < tokens.Count; i++) {
                var token = ret[i];
		        //  rule 1: DT, {VBD | VBP} --> DT, NN
                if (i > 0 && ret[i - 1] == "DT") {
                    if (token == "VBD" ||
                    token == "VBP" ||
                    token == "VB") {
                        ret[i] = "NN";
                    }
                }
                // rule 2: convert a noun to a number (CD) if "." appears in the word
                if (token.StartsWith("N")) {
			        if (tokens[i].IndexOf(".") > -1) {
                        ret[i] = "CD";
                    }
			        // Attempt to convert into a number
                    float f;
                    if (float.TryParse(tokens[i],out f))
                        ret[i] = "CD";
                }
                // rule 3: convert a noun to a past participle if tokens[i] ends with "ed"
                if (ret[i].StartsWith("N") && tokens[i].EndsWith("ed")) 
                    ret[i] = "VBN";
                // rule 4: convert any type to adverb if it ends in "ly";
                if (tokens[i].EndsWith("ly")) 
                    ret[i] = "RB";
                // rule 5: convert a common noun (NN or NNS) to a adjective if it ends with "al"
                if (ret[i].StartsWith("NN") && token.EndsWith("al")) 
                    ret[i] = "JJ";
                // rule 6: convert a noun to a verb if the preceding work is "would"
                if (i > 0 && ret[i].StartsWith("NN") && tokens[i - 1].ToLower() == "would") 
                    ret[i] = "VB";
                // rule 7: if a word has been categorized as a common noun and it ends with "s",
                //         then set its type to plural common noun (NNS)
                if (ret[i] == "NN" && tokens[i].EndsWith("s")) 
                    ret[i] = "NNS";
                // rule 8: convert a common noun to a present participle verb (i.e., a gerund)
                if (ret[i].StartsWith("NN") && tokens[i].EndsWith("ing")) 
                    ret[i] = "VBG";
            }

            return tokens.Select((x,i) => new TaggerResult()
                {
                    Token = x,
                    Tag = ret[i]
                }).ToList();
        }
    }
}