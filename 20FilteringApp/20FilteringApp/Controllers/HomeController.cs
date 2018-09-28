using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _20FilteringApp.Models;

namespace _20FilteringApp.Controllers
{
    public class HomeController : Controller
    {
        private UsersContext db;

        public HomeController(UsersContext context)
        {
            db = context;
        }
        public IActionResult Index(int? company, string name)
        {
            IQueryable<User> users = db.Users.Include(p => p.Company);

            if (company != null && company != 0)
            {
                users = users.Where(p => p.CompanyId == company);
            }

            if (!string.IsNullOrEmpty(name))
            {
                users = users.Where(p => p.Name.Contains(name));
            }

            List<Company> companies = db.Companies.ToList();
            // set begining element = "all"
            companies.Insert(0, new Company {Name = "Все", Id=0});

            UsersListViewModel viewModel = new UsersListViewModel
            {
                Users = users.ToList(),
                Companies = new SelectList(companies, "Id", "Name"), 
                Name = name
            };
            return View(viewModel);
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
