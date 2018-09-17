using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using _02MobileStore.Models;
using _02MobileStore.Util;

namespace _02MobileStore.Controllers
{
    public class HomeController : Controller
    {
        private MobileContext db;

        public HomeController(MobileContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            return View(db.Phones.ToList());
        }

        [HttpGet]
        public IActionResult Buy(int id)
        {
            ViewBag.PhoneId = id;
            return View();
        }

        [HttpPost]
        public string Buy(Order order)
        {
            db.Orders.Add(order);
            // save shanges
            db.SaveChanges();
            return "Thanks, " + order.User + ", for your order!";
        }

        public HtmlResult GetHtml()
        {
            return new HtmlResult("<h2>Привет ASP.NET Core<h2>");
        }

        public IActionResult Square(int altitude, int height)
        {
            //Для отправки ContentResult не надо использовать конструктор, 
            //так как в контроллере уже определен специальный метод Content(),
            //который принимает отправляемую строку и создает объект ContentResult.
            double square = altitude * height / 2;
            return Content($"Площадь треугольника с основанием {altitude} и высотой {height} равна {square}");
        }

        //для отправки клиенту объекта User мы можем написать следующий метод:
        public JsonResult GetUser()
        {
            User user = new User { Name = "Tom", Age = 28 };
            return Json(user);
        }
    }
}
