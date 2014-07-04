using POSTagger.Corpora;
using POSTagger.Taggers;
using POSTagger.Tokenizers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebExample.Models;

namespace WebExample.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(new TaggerViewModel());
        }

        [HttpPost]
        public ActionResult Index(TaggerViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var corpus = CorpusFactory.GetCorpus("brills");

            var tokenizer = TokenizerFactory.GetTokenizer("simple");
            var tokens = tokenizer.Tokenize(model.Text);

            var tagger = TaggerFactory.GetTagger("simple");
            var results = tagger.Tag(corpus, tokens.Where(x => !string.IsNullOrWhiteSpace(x)).ToList());

            ViewBag.Results = String.Join(" ", results.Select(x => string.Format("{0}({1})", x.Token, x.Tag)));

            return View(model);
        }
    }
}
