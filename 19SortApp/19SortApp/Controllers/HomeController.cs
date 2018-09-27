using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using _19SortApp.Models;
using Microsoft.EntityFrameworkCore;

namespace _19SortApp.Controllers
{
    public class HomeController : Controller
    {
        private UsersContext db;

        public HomeController(UsersContext context)
        {
            this.db = context;
        }

        public async Task<IActionResult> Index(SortState sortOrder = SortState.NameAsc)
        {
            ViewData["NameSort"] = sortOrder==SortState.NameAsc ? SortState.NameDesc : SortState.NameAsc;
            ViewData["AgeSort"] = sortOrder == SortState.AgeAsc ? SortState.AgeDesc : SortState.AgeAsc;
            ViewData["CompSort"] = sortOrder == SortState.CompanyAsc ? SortState.CompanyDesc : SortState.CompanyAsc;

            IOrderedQueryable<User> users;
            
            switch (sortOrder)
            {
                case SortState.NameDesc:
                    users =  db.Users.OrderByDescending(s => s.Name);
                    break;
                case SortState.AgeAsc:
                    users = db.Users.OrderBy(s => s.Age);
                    break;
                case SortState.AgeDesc:
                    users = db.Users.OrderByDescending(s => s.Age);
                    break;
                case SortState.CompanyAsc:
                    users = db.Users.OrderBy(s => s.Company.Name);
                    break;
                case SortState.CompanyDesc:
                    users = db.Users.OrderByDescending(s => s.Company.Name);
                    break;
                default:
                    users = db.Users.OrderBy(s => s.Name);
                    break;
            }
            return View(await users.AsNoTracking().ToListAsync());
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
