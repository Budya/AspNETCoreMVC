using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace _15HtmlHelpersApp.App_Code
{
    public static class ListHelper
    {
        public static HtmlString CreateList(this IHtmlHelper html,
            string[] items)
        {
            TagBuilder ul = new TagBuilder("ul");
            
            foreach (string item in items)
            {
                TagBuilder li = new TagBuilder("li");
                // add text in li
                li.InnerHtml.Append(item);
                // add li in ul
                ul.InnerHtml.AppendHtml(li);
            }

            ul.Attributes.Add("class", "itemsList");
            var writer = new System.IO.StringWriter();
            ul.WriteTo(writer, HtmlEncoder.Default);
            return new HtmlString(writer.ToString());
        }
    }
}
