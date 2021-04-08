using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GBCSporting2021_Caeruleum.Models;

namespace GBCSporting2021_Caeruleum.Controllers
{
  public class ProductController : Controller
  {
    private CaeruleumContext context { get; set; }
    public ProductController(CaeruleumContext ctx) => context = ctx;

    [Route("/products")]
    public IActionResult Product()
    {
      ViewData["Message"] = "Products Page"; 
      return View(context.Products.ToList());
    }

    public IActionResult Add()
    {
      ViewBag.Action = "Add";
      return View("Edit", new Product());
    }

    [HttpPost]
    public IActionResult Add(Product p)
    {
      return View("Product");
    }

    public IActionResult Edit()
    {
      ViewBag.Action = "Edit";
      ViewData["Message"] = "Edit Product Page";
      return View();
    }

    [HttpPost]
    public IActionResult Edit(int id, Product p)
    {
      return View("Product");
    }

    public IActionResult Delete()
    {
      ViewData["Message"] = "Delete Product Page";
      return View();
    }

    [HttpPost]
    public IActionResult Delete(int id)
    {
      return View("Product");
    }
  }
}
