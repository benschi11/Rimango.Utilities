using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rimango.Utilities.Helpers {
    using System.Text.RegularExpressions;

    public class HtmlHelper {
        public static string StripHtml(string input) {
            return Regex.Replace(input, "<.*?>", " ");
        }
    }
}