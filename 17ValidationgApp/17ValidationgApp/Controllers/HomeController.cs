using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using _17ValidationgApp.Models;

namespace _17ValidationgApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Person person)
        {
            //if (ModelState.IsValid)
            //    return Content($"{person.Name} - {person.Email}");

            if (string.IsNullOrEmpty(person.Name))
            {
                ModelState.AddModelError("Name", "Некорректное имя");
            }
            else if (person.Name.Length > 5)
            {
                ModelState.AddModelError("Name", "Недопустимая длина строки");
            }
            else if (person.Name == person.Password)
            {
                ModelState.AddModelError("", "Имя и пароль не должны совпадать");
            }


            if (ModelState.IsValid)
            {
                return Content($"{person.Name} - {person.Email}");
            }
            
            return View(person);
        }

        [AcceptVerbs("Get", "Post")]
        public IActionResult CheckEmail(string email)
        {
            if (email == "admin@mail.ru" || email == "aaa@gmail.com")
                return Json(false);
            return Json(true);
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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
