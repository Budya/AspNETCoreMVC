using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using _13ModelsApp.Models;
using _13ModelsApp.ViewModels;

namespace _13ModelsApp.Controllers
{
    public class HomeController : Controller
    {
        private List<Company> companies;
        private List<Phone> phones;

        public HomeController()
        {
            Company apple = new Company {Id = 1, Name = "Apple", Country = "USA"};
            Company microsoft = new Company {Id = 2, Name = "Microsoft", Country = "USA"};
            Company google = new Company {Id = 3, Name = "Google", Country = "USA"};
            companies = new List<Company>{apple, microsoft, google};

            phones = new List<Phone>
            {
                new Phone { Id=1, Manufacturer= apple, Name="iPhone 6S", Price=56000 },
                new Phone { Id=2, Manufacturer= apple, Name="iPhone 5S", Price=41000 },
                new Phone { Id=3, Manufacturer= microsoft, Name="Lumia 550", Price=9000 },
                new Phone { Id=4, Manufacturer= microsoft, Name="Lumia 950", Price=40000 },
                new Phone { Id=5, Manufacturer= google, Name="Nexus 5X", Price=30000 },
                new Phone { Id=6, Manufacturer= google, Name="Nexus 6P", Price=50000 }
            };
        }

        public IActionResult Index(int? companyId)
        {
            // prepare list of companies for transmission to view
            List<CompanyModel> compModels = companies
                .Select(c => new CompanyModel {Id = c.Id, Name = c.Name})
                .ToList();
            // add first element
            compModels.Insert(0, new CompanyModel {Id = 0, Name = "Все"});

            IndexViewModel ivm = new IndexViewModel {Companies = compModels, Phones = phones};

            // if paramteter id is transferred, use filter
            if (companyId != null && companyId > 0)
                ivm.Phones = phones.Where(p => p.Manufacturer.Id == companyId);

            return View(ivm);
        }
        //public IActionResult Index()
        //{
        //    return View(phones);
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
