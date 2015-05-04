namespace Agouti.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Web;
    using Umbraco.Core.Models;
    using Umbraco.Web.Models;

    public class AgoutiModel : RenderModel
    {
        // Summary:
        //     Constructor to set the IPublishedContent and the CurrentCulture is set by
        //     the UmbracoContext
        //
        // Parameters:
        //   content:
        public AgoutiModel(IPublishedContent content) : base(content) { }
        //
        // Summary:
        //     Constructor specifying both the IPublishedContent and the CultureInfo
        //
        // Parameters:
        //   content:
        //
        //   culture:
        public AgoutiModel(IPublishedContent content, CultureInfo culture) : base(content, culture) { }
    }
}