namespace Agouti.Web.Controllers
{
    using Agouti.Web.Models;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Umbraco.Core.Models;
    using Umbraco.Web.Mvc;

    public abstract class AgoutiController<ModelType> : RenderMvcController  where ModelType : AgoutiModel
    {
        public ModelType PageModel { get; private set; }
        public abstract ModelType GetModel(IPublishedContent publishedContent, CultureInfo cultureInfo);

        //[OutputCache(VaryByParam = "none", Duration = 86400)]
        public override System.Web.Mvc.ActionResult Index(Umbraco.Web.Models.RenderModel model)
        {
            PageModel = GetModel(model.Content, model.CurrentCulture);
            var actionResult = OnIndexAction();
            if (actionResult != null) { return actionResult; }
            return CurrentTemplate(PageModel);
        }

        protected abstract ActionResult OnIndexAction();


    }
}