using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcKutuphane.Helpers
{
    public static class MyExtensions
    {
        public static MvcHtmlString BootstrapInput(this HtmlHelper helper, string name, string value, string type = "text", string claS = "", string MaxLength = "")
        {
            string html = string.Format("<input type='{0}' name='{1} id={1}' value = {2} class = 'form-control {3}' maxlength='{4}'/>", type, name, value, claS, MaxLength);
            return MvcHtmlString.Create(html);

        }

    }


}