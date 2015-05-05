namespace Agouti.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Web;
    using Umbraco.Core.Models;

    public class HomePageModel : AgoutiModel
    {

        public IEnumerable<string> TestCategories { get; set; }
        public string TestCategory { get; set; }
        public string MemberLoginName { get; set; }
        public string QuestionImageUriString { get; set; }
        public IEnumerable<string> QuestionOptions { get; set; }
        public string CorrectAnswer { get; set; }


        // Summary:
        //     Constructor to set the IPublishedContent and the CurrentCulture is set by
        //     the UmbracoContext
        //
        // Parameters:
        //   content:
        public HomePageModel(IPublishedContent content) : base(content) { }
        //
        // Summary:
        //     Constructor specifying both the IPublishedContent and the CultureInfo
        //
        // Parameters:
        //   content:
        //
        //   culture:
        public HomePageModel(IPublishedContent content, CultureInfo culture) : base(content, culture) { }
    }
}