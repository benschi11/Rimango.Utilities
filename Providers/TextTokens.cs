using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rimango.Utilities.Providers {
    using Orchard.Localization;
    using Orchard.Tokens;

    using Rimango.Utilities.Helpers;

    public class TextTokens : ITokenProvider {

        public TextTokens()
        {
            T = NullLocalizer.Instance;
        }
        
        public Localizer T { get; set; }
        public void Describe(DescribeContext context)
        {
            context.For("Text", T("Text"), T("Text"))
                .Token("StripHtml", this.T("StripHtml"), T("Removes all HTML Tags from this string."));
        }

        public void Evaluate(EvaluateContext context)
        {
            context.For<string>("Text")
                .Token("StripHtml", HtmlHelper.StripHtml);
        }
    }
}