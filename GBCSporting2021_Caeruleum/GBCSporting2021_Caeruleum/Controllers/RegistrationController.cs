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
    public IActionResult Index()
    {
      return View();
    }

    [Route("/registrations")]
    public IActionResult Registration()
    {
      ViewData["Message"] = "Registrations Page";
      return View();
    }

    public IActionResult Add()
    {
      ViewBag.Action = "Add";
      return View("Edit", new Registration());
    }

    public IActionResult Edit()
    {
      ViewData["Message"] = "Edit Registration Page";
      return View();
    }

    public IActionResult Delete()
    {
      ViewData["Message"] = "Delete Registration Page";
      return View();
    }
  }
}
