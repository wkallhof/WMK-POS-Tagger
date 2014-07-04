using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSTagger.Corpora.BrillsEnglish
{
    public class BrillsEnglishCorpus : Corpus
    {
        public BrillsEnglishCorpus()
        {
            this.WordMap = this.LoadWordMap();
            this.TagMap = this.LoadTagMap();
        }

        private List<List<string>> LoadTagMap()
        {
            return LoadJsonFile<TagMapDTO>("Corpora/BrillsEnglish/BrillsTagMap.json").TagMap;
        }

        private Dictionary<string, int> LoadWordMap()
        {
            return LoadJsonFile<Dictionary<string, int>>("Corpora/BrillsEnglish/BrillsWordMap.json");
        }

        private T LoadJsonFile<T>(string path)
        {
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                return JsonConvert.DeserializeObject<T>(json);
            }
        }

        private class TagMapDTO
        {
            public List<List<string>> TagMap { get; set; }
        }
    }
}
