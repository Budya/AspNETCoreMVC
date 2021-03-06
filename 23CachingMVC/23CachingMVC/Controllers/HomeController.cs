﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using _23CachingMVC.Models;
using _23CachingMVC.Services;

namespace _23CachingMVC.Controllers
{
    public class HomeController : Controller
    {
        private ProductService productService;

        public HomeController(ProductService service)
        {
            productService = service;
            productService.Initialize();
        }
        public async Task<IActionResult> Index(int id)
        {
            Product product = await productService.GetProduct(id);
            if (product != null)
                return Content($"Product: {product.Name}");
            return Content("Product not found");
        }
    }
}
