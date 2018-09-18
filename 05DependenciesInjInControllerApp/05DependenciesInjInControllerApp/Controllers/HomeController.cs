using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using _05DependenciesInjInControllerApp.Models;

namespace _05DependenciesInjInControllerApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITimeService _timeService;

        public HomeController(ITimeService timeService)
        {
            _timeService = timeService;
        }
        // передача сервисов через конструктор
        public string Index()
        {
            return _timeService.Time;
        }

        // передача зависимостей в методы. FromServices
        public string Index1([FromServices] ITimeService timeService)
        {
            return timeService.Time;
        }

        // HttpContext.RequestServices
        public string Index2()
        {
            ITimeService timeService = HttpContext.RequestServices.GetService<ITimeService>();
            return timeService?.Time;
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
