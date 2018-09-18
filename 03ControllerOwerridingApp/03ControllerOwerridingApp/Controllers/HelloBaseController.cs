using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace _03ControllerOwerridingApp.Controllers
{
    public abstract class HelloBaseController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Request.Headers.ContainsKey("User-Agent") &&
                Regex.IsMatch(input: context.HttpContext.Request.Headers["User-Agent"].FirstOrDefault(), pattern: "MSIE 8.0"))
            {
                context.Result = Content("Internet Explorer 8.0 не поддерживается");
            }
            base.OnActionExecuting(context);
        }
        
    }
}