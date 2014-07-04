using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using POSTagger.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSTagger.Lexicons.BrillsEnglish
{
    public class BrillsEnglishLexicon : Lexicon
    {
        public BrillsEnglishLexicon()
        {
            this.WordMap = this.LoadWordMap();
            this.TagMap = this.LoadTagMap();
        }

        private List<List<string>> LoadTagMap()
        {
            return LoadJsonFile<TagMapDTO>("Lexicons/BrillsEnglish/BrillsTagMap.json").TagMap;
        }

        private Dictionary<string, int> LoadWordMap()
        {
            return LoadJsonFile<Dictionary<string, int>>("Lexicons/BrillsEnglish/BrillsWordMap.json");
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
