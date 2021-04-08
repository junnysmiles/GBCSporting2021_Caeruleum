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
    private CaeruleumContext context { get; set; }
    public TechnicianController(CaeruleumContext ctx) => context = ctx;

    [Route("/technicians")]
    public IActionResult Technician()
    {
      ViewData["Message"] = "Technicians Page";
      var model = context.Technicians.ToList();
      return View(model);
    }

    public IActionResult Add()
    {
      ViewBag.Action = "Add";
      return View("Edit", new Technician());
    }

    [HttpPost]
    public IActionResult Add(Technician t)
    {
      return View("Technician");
    }

    public IActionResult Edit()
    {
      ViewBag.Action = "Edit";
      ViewData["Message"] = "Edit Technician Page";
      return View();
    }


    [HttpPost]
    public IActionResult Edit(int id, Technician t)
    {

      return View("Technician");
    }
    public IActionResult Delete()
    {
      ViewData["Message"] = "Delete Technician Page";
      return View();
    }

    [HttpPost]
    public IActionResult Delete(int id)
    {

      return View("Technician");
    }
  }
}
