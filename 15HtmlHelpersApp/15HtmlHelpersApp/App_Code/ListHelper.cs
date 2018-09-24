using System;
using System.Collections.Generic;
using System.Linq;
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
            string result = "<ul>";
            foreach (string item in items)
            {
                result += $"<li>{item}</li>";
            }

            result += "</ul>";
            return new HtmlString(result);
        }
    }
}
