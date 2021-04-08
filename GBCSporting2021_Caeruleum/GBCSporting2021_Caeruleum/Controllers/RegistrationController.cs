using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GBCSporting2021_Caeruleum.Models;

namespace GBCSporting2021_Caeruleum.Controllers
{
  public class RegistrationController : Controller
  {
    private CaeruleumContext context { get; set; }
    public RegistrationController(CaeruleumContext ctx) => context = ctx;

    [Route("/registrations")]
    public IActionResult Registration()
    {
      ViewData["Message"] = "Registrations Page";
      return View(context.Registrations.ToList());
    }

    public IActionResult Add()
    {
      ViewBag.Action = "Add";
      return View("Edit", new Registration());
    }

    [HttpPost]
    public IActionResult Add(Registration r)
    {
      return View("Registration");
    }

    public IActionResult Edit()
    {
      ViewBag.Action = "Edit";
      ViewData["Message"] = "Edit Registration Page";
      return View();
    }

    [HttpPost]
    public IActionResult Edit(int id, Registration r)
    {
      return View("Registration");
    }

    public IActionResult Delete()
    {
      ViewData["Message"] = "Delete Registration Page";
      return View();
    }

    [HttpPost]
    public IActionResult Delete(int id)
    {
      return View("Registration");
    }
  }
}
