using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using _14CustomModelBinderApp.Models;

namespace _14CustomModelBinderApp.Controllers
{
    public class HomeController : Controller
    {
        private static List<Event> events;

        public HomeController()
        {
            if(events == null)
                events = new List<Event>();
        }
        public IActionResult Index()
        {
            return View(events);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Event ev)
        {
            ev.Id = Guid.NewGuid().ToString();
            events.Add(ev);
            return RedirectToAction("Index");
        }


        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
