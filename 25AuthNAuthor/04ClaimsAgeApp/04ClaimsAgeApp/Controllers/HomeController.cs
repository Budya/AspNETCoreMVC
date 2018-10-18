using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using _03ClaimsApp.Models;

namespace _03ClaimsApp.Controllers
{
    public class HomeController : Controller
    {
        [Authorize(Policy = "AgeLimit")]
        public IActionResult Index()
        {
            return View();
        }
     
        
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
 
            return View();
        }
    }
}
