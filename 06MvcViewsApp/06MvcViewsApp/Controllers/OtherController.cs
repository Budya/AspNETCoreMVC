using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace _06MvcViewsApp.Controllers
{
    public class OtherController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}