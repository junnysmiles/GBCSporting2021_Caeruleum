using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GBCSporting2021_Caeruleum.Models;

namespace GBCSporting2021_Caeruleum.Controllers
{
  public class CustomerController : Controller
  {
    private CaeruleumContext context { get; set; }
    public CustomerController(CaeruleumContext ctx) => context = ctx;
    [Route("/customers")]
    public IActionResult Customer()
    {
      ViewData["Message"] = "Customers Page";
      return View(context.Customers.ToList());
    }

    public IActionResult Add()
    {
      ViewBag.Action = "Add";
      return View("Edit", new Customer());
    }

    [HttpPost]
    public IActionResult Add(Customer c)
    {

      return View("Customer");
    }

    public IActionResult Edit()
    {
      ViewBag.Action = "Edit";
      ViewData["Message"] = "Edit Customer Page";
      return View();
    }

    [HttpPost]
    public IActionResult Edit(int id, Customer c)
    {

      return View("Customer");
    }

    public IActionResult Delete()
    {
      ViewData["Message"] = "Delete Customer Page";
      return View();
    }

    [HttpPost]
    public IActionResult Delete(int id)
    {

      return View("Customer");
    }
  }
}
