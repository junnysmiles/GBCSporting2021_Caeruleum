using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GBCSporting2021_Caeruleum.Models;
using Microsoft.EntityFrameworkCore;

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
      return View("Edit");
    }

    [HttpPost]
    public IActionResult Add(Technician t)
    {
      if(ModelState.IsValid)
      {
        context.Technicians.Add(t);
        context.SaveChanges();
        return RedirectToAction("Technician");
      }
      else
      {
        ViewBag.Action = "Add";
        return View("Edit", t);
      }
    }

    public IActionResult Edit(int Id)
    {
      Technician t = context.Technicians.Find(Id);
      ViewBag.FirstName = t.FirstName;
      ViewBag.LastName = t.LastName;
      ViewBag.Phone = t.Phone;
      ViewBag.Email = t.Email;
      ViewBag.Action = "Edit";
      ViewData["Message"] = "Edit Technician Page";
      return View("Edit");
    }


    [HttpPost]
    public IActionResult Edit(Technician t)
    {
      if(ModelState.IsValid && t != null)
      {
        context.Technicians.Update(t);
        context.SaveChanges();
        return RedirectToAction("Technician");
      }
      else
      {
        t = context.Technicians.Find(t.Id);
        ViewBag.FirstName = t.FirstName;
        ViewBag.LastName = t.LastName;
        ViewBag.Phone = t.Phone;
        ViewBag.Email = t.Email;
        ViewBag.Action = "Edit";
        return View("Edit", t);
      }
    }

    public IActionResult Delete(int Id)
    {
      Technician t = context.Technicians.Find(Id);
      ViewBag.Id = t.Id;
      ViewBag.FirstName = t.FirstName;
      ViewBag.LastName = t.LastName;
      ViewBag.Email = t.Email;
      ViewBag.Phone = t.Phone;
      ViewBag.Action = "Delete";
      ViewData["Message"] = "Delete Product Page";
      return View("Delete", t);
    }

    [HttpPost]
    public IActionResult Delete(Technician t)
    {
      context.Entry(t).State = EntityState.Deleted;
      try
      {
        context.SaveChanges();
        return RedirectToAction("Technician");
      }
      catch(DbUpdateConcurrencyException)
      {
        ModelState.AddModelError("", String.Format("Technician with id {0}, no longer exists in the database.", t.Id));
        return RedirectToAction("Technician");
      }
    }
  }
}
