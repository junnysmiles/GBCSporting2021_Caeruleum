using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GBCSporting2021_Caeruleum.Models;

namespace GBCSporting2021_Caeruleum.Controllers
{
  public class IncidentController : Controller
  {
    private CaeruleumContext context { get; set; }
    public IncidentController(CaeruleumContext ctx) => context = ctx;
    public IActionResult Index()
    {
      return View();
    }

    [Route("/incidents")]
    public IActionResult Incident()
    {
      ViewData["Message"] = "Incidents Page";
      return View(context.Incidents.ToList());
    }

    public IActionResult Add()
    {
      ViewBag.Action = "Add";
      ViewData["Message"] = "Add Incident Page";
      return View("Edit", new Incident());
    }

    [HttpPost]
    public IActionResult Add(Incident i)
    {
      return View("Incident");
    }

    public IActionResult Edit()
    {
      ViewBag.Action = "Edit";
      ViewData["Message"] = "Edit Incident Page";
      return View();
    }

    [HttpPost]
    public IActionResult Edit(int id, Incident i)
    {
      return View("Inicident");
    }

    public IActionResult Delete()
    {
      ViewData["Message"] = "Delete Incident Page";
      return View();
    }

    [HttpPost]
    public IActionResult Delete(int id)
    {
      return View("Incident");
    }
  }
}
