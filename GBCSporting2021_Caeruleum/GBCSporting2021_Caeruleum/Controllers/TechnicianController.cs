using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GBCSporting2021_Caeruleum.Models;

namespace GBCSporting2021_Caeruleum.Controllers
{
  public class TechnicianController : Controller
  {
    public IActionResult Index()
    {
      return View();
    }

    [Route("/technicians")]
    public IActionResult Technician()
    {
      ViewData["Message"] = "Technicians Page";
      return View();
    }

    public IActionResult Add()
    {
      ViewBag.Action = "Add";
      return View("Edit", new Technician());
    }

    public IActionResult Edit()
    {
      ViewData["Message"] = "Edit Technician Page";
      return View();
    }

    public IActionResult Delete()
    {
      ViewData["Message"] = "Delete Technician Page";
      return View();
    }
  }
}
