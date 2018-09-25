using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using _15HtmlHelpersApp.Models;

namespace _15HtmlHelpersApp.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            List<Phone> phones = new List<Phone>
            {
                new Phone {Id=1, Name="iPhone 7 Pro", Price=680 },
                new Phone {Id=2, Name="Galaxy 7 Edge", Price=640 },
                new Phone {Id=3, Name="HTC 10", Price=500 },
                new Phone {Id=4, Name="Honor 5X", Price=400 },
            };

            Phone phone = new Phone { Id = 1, Name = "Nexus 6P", Price = 49000 };
            ViewBag.phone = phone;
            ViewBag.Phones = new SelectList(phones, "Id", "Name");
            return View(phone);
        }

        public IActionResult Create()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult Create(Phone myPhone)
        //{
            
        //}

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
