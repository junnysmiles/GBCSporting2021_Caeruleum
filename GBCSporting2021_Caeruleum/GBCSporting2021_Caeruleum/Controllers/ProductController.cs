using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GBCSporting2021_Caeruleum.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Product()
        {
            ViewData["Message"] = "Products Page";
            return View();
        }

        public IActionResult Edit()
        {
            ViewData["Message"] = "Edit Product Page";
            return View();
        }

        public IActionResult Delete()
        {
            ViewData["Message"] = "Delete Product Page";
            return View();
        }
    }
}
