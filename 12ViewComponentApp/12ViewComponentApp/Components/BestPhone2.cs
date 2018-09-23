using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using _12ViewComponentApp.Models;

namespace _12ViewComponentApp.Components
{
    [ViewComponent]
    public class BestPhone2
    {
        List<Phone> phones;
        IRepository repo;
        public BestPhone2(IRepository repository)
        {
            phones = repository.GetPhones();
        }
        public string Invoke()
        {
            var item = phones.OrderByDescending(x => x.Price).Take(1).FirstOrDefault();
 
            return $"Самый дорогой телефон: {item.Title} Цена: {item.Price}";
        }
    }
}
