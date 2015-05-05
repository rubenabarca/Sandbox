namespace Agouti.Web.Controllers
{
    using Agouti.Web.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using Archetype.Models;
    using Archetype.Extensions;
    using Newtonsoft.Json.Linq;
    using Umbraco.Core.Models;
    using System.Web.Mvc;

    public class HomePageController : AgoutiController<HomePageModel>
    {

        private static Random _randomGenerator = new Random();

        public override HomePageModel GetModel(Umbraco.Core.Models.IPublishedContent publishedContent, System.Globalization.CultureInfo cultureInfo)
        {
            return new HomePageModel(publishedContent, cultureInfo);
        }

        protected override System.Web.Mvc.ActionResult OnIndexAction()
        {

            if (!Umbraco.MemberIsLoggedOn())
            {
                return null;
            }

            PageModel.TestCategories = new List<string>(UmbracoExtensions.GetDropDownDataTypeValues(Globals.TestCategoryId));
            PageModel.TestCategory = Request.QueryString["category"];

            if (string.IsNullOrEmpty(PageModel.TestCategory))
            {
                return null;
            }


            var vocabularyContainer = Umbraco.ContentAtRoot().Where("DocumentTypeAlias == \"VocabularyApi\"").FirstOrDefault();

            var animalEntries = ((ArchetypeModel)vocabularyContainer.vocabularyEntries)
                .Where(entry => entry.GetValue<JArray>("tags").ToObject<string[]>().Contains(PageModel.TestCategory))
                .OrderBy(x => _randomGenerator.Next())
                .Take(4)
                .ToArray();

            var correctEntry = animalEntries
                .OrderBy(x => _randomGenerator.Next())
                .FirstOrDefault();

            PageModel.CorrectAnswer = correctEntry
                .GetValue<ArchetypeModel>("words")
                .Where(w => w.GetValue("language") == "English")
                .FirstOrDefault()
                .GetValue("word");

            PageModel.QuestionImageUriString = ((IPublishedContent)Umbraco.Media(correctEntry
                .GetValue<ArchetypeModel>("images")
                .Where(image => image.GetValue("breakpoint") == "Desktop")
                .FirstOrDefault()
                .GetValue("imageFolderId")))
                .Children
                .OrderBy(x => _randomGenerator.Next())
                .FirstOrDefault().Url;

            PageModel.QuestionOptions = (from animalEntry in animalEntries
                                         let words = animalEntry.GetValue<ArchetypeModel>("words")
                                         let englishWords = words.Where(w => w.GetValue("language") == "English").Select(w => w.GetValue("word")).FirstOrDefault()
                                         select englishWords).ToArray();


            return null;
        }
    }
}