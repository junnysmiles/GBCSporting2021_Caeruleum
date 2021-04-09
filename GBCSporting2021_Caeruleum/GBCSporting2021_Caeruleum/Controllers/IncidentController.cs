using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GBCSporting2021_Caeruleum.Models;
using Microsoft.EntityFrameworkCore;

namespace GBCSporting2021_Caeruleum.Controllers
{
  public class IncidentController : Controller
  {
    private CaeruleumContext context { get; set; }
    public IncidentController(CaeruleumContext ctx) => context = ctx;

    [Route("/incidents")]
    public IActionResult Incident()
    {
      ViewData["Message"] = "Incidents Page";
      ViewBag.Customers = context.Customers;
      ViewBag.Products = context.Products;
      return View(context.Incidents.ToList());
    }

    public IActionResult Add()
    {
      ViewBag.Action = "Add";
      ViewBag.OpenDate = DateTime.Now.ToString("yyyy-MM-dd");
      ViewBag.Customers = context.Customers.ToList();
      ViewBag.Products = context.Products.ToList();
      ViewBag.Technicians = context.Technicians.ToList();
      ViewData["Message"] = "Add Incident Page";
      return View("Add");
    }

    [HttpPost]
    public IActionResult Add(Incident i)
    {
      if(ModelState.IsValid)
      {
        context.Incidents.Add(i);
        context.SaveChanges();
        return RedirectToAction("Incident");
      }
      else
      {
        ViewBag.Action = "Add";
        ViewBag.OpenDate = DateTime.Now.ToString("yyyy-MM-dd");
        ViewBag.Customers = context.Customers.ToList();
        ViewBag.Products = context.Products.ToList();
        ViewBag.Technicians = context.Technicians.ToList();
        return View("Add", i);
      }
    }

    public IActionResult Edit(int Id)
    {
      Incident i = context.Incidents.Find(Id);
      Customer c = context.Customers.Find(i.CustomerId);
      Product p = context.Products.Find(i.ProductId);
      Technician t = context.Technicians.Find(i.TechnicianId);
      if(t != null)
        ViewBag.TechnicianName = String.Format("{0} {1}", t.FirstName, t.LastName);
      ViewBag.CustomerName = String.Format("{0} {1}", c.FirstName, c.LastName);
      if(p != null)
        ViewBag.ProductName = p.Name;
      ViewBag.Description = i.Description;
      ViewBag.CloseDate = i.CloseDate;
      ViewBag.Action = "Edit";
      ViewData["Message"] = "Edit Incident Page";
      return View("Edit", i);
    }

    [HttpPost]
    public IActionResult Edit(Incident i)
    {
      if(ModelState.IsValid && i != null)
      {
        context.Incidents.Update(i);
        context.SaveChanges();
        return RedirectToAction("Incident");
      }
      else
      {
        i = context.Incidents.Find(i.Id);
        Customer c = context.Customers.Find(i.CustomerId);
        Product p = context.Products.Find(i.ProductId);
        Technician t = context.Technicians.Find(i.TechnicianId);
        if(t != null)
          ViewBag.TechnicianName = String.Format("{0} {1}", t.FirstName, t.LastName);
        ViewBag.CustomerName = String.Format("{0} {1}", c.FirstName, c.LastName);
        if(p != null)
          ViewBag.ProductName = p.Name;
        ViewBag.Description = i.Description;
        ViewBag.CloseDate = i.CloseDate;
        ViewBag.Description = i.Description;
        ViewBag.Action = "Edit";
        ViewData["Message"] = "Edit Incident Page";
        return View("Edit", i);
      }
    }

    public IActionResult Delete(int Id)
    {
      Incident i = context.Incidents.Find(Id);
      Customer c = context.Customers.Find(i.CustomerId);
      Technician t = context.Technicians.Find(i.TechnicianId);
      Product p = context.Products.Find(i.ProductId);
      if(c != null)
        ViewBag.CustomerName = String.Format("{0} {1}", c.FirstName, c.LastName);
      if(t != null)
        ViewBag.TechnicianName = String.Format("{0} {1}", t.FirstName, c.LastName);
      if(p != null)
        ViewBag.ProductName = p.Name;
      ViewData["Message"] = "Delete Incident Page";
      return View(i);
    }

    [HttpPost]
    public IActionResult Delete(Incident i)
    {
      context.Entry(i).State = EntityState.Deleted;
      try
      {
        context.SaveChanges();
        return RedirectToAction("Incident");
      }
      catch(DbUpdateConcurrencyException)
      {
        ModelState.AddModelError("", String.Format("Incident with id {0}, no longer exists in the database.", i.Id));
        return RedirectToAction("Incident");
      }
    }
  }
}
