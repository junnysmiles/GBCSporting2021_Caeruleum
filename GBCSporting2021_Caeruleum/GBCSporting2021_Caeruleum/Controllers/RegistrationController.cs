using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GBCSporting2021_Caeruleum.Models;
using Microsoft.EntityFrameworkCore;

namespace GBCSporting2021_Caeruleum.Controllers
{
  public class RegistrationController : Controller
  {
    private CaeruleumContext context { get; set; }
    public RegistrationController(CaeruleumContext ctx) => context = ctx;

    [Route("/registrations")]
    public IActionResult Registration()
    {
      ViewBag.Customers = context.Customers;
      ViewBag.Products = context.Products;
      ViewBag.CustomerCount = context.Customers.ToList().Count;
      ViewBag.ProductCount = context.Products.ToList().Count;
      ViewData["Message"] = "Registrations Page";
      return View(context.Registrations.ToList());
    }

    public IActionResult Add()
    {
      ViewBag.Action = "Add";
      ViewBag.Customers = context.Customers;
      ViewBag.Products = context.Products;
      return View("Edit");
    }

    [HttpPost]
    public IActionResult Add(Registration r)
    {
      bool noRepeat = true;
      Registration[] arr = context.Registrations.ToArray();
      for(int i = 0; i < arr.Length; i++)
      {
        if(r.CustomerId == arr[i].CustomerId && r.ProductId == arr[i].ProductId)
        {
          noRepeat = false;
          break;
        }
      }
      if(ModelState.IsValid && noRepeat)
      {
        context.Registrations.Add(r);
        context.SaveChanges();
        return RedirectToAction("Registration");
      }
      else
      {
        ViewBag.Action = "Add";
        ViewBag.Customers = context.Customers;
        ViewBag.Products = context.Products;
        return View("Edit", r);
      }
    }

    public IActionResult Edit(int Id)
    {
      Registration r = context.Registrations.Find(Id);
      Customer c = context.Customers.Find(r.CustomerId);
      ViewBag.Action = "Edit";
      ViewBag.CustomerId = r.CustomerId;
      ViewBag.ProductId = r.ProductId;
      ViewBag.Customers = context.Customers;
      ViewBag.CustomerName = String.Format("{0} {1}", c.FirstName, c.LastName);
      ViewBag.Products = context.Products;
      ViewData["Message"] = "Edit Registration Page";
      return View();
    }

    [HttpPost]
    public IActionResult Edit(Registration r)
    {
      if(ModelState.IsValid)
      {
        context.Registrations.Update(r);
        context.SaveChanges();
        return RedirectToAction("Registration");
      }
      else
      {
        Customer c = context.Customers.Find(r.CustomerId);
        ViewBag.Action = "Edit";
        ViewBag.OpenDate = DateTime.Now.ToString("yyyy-MM-dd");
        ViewBag.CustomerId = r.CustomerId;
        ViewBag.CustomerName = String.Format("{0} {1}", c.FirstName, c.LastName);
        ViewBag.ProductId = r.ProductId;
        ViewBag.Customers = context.Customers;
        ViewBag.Products = context.Products;
        return View("Edit", r);
      }
    }

    public IActionResult Delete(int Id)
    {
      Registration r = context.Registrations.Find(Id);
      Customer c = context.Customers.Find(r.CustomerId);
      Product p = context.Products.Find(r.ProductId); 
      ViewData["Message"] = "Delete Registration Page";
      ViewBag.Action = "Delete";
      if(c != null)
        ViewBag.CustomerName = String.Format("{0} {1}", c.FirstName, c.LastName);
      if(p != null)
        ViewBag.ProductName = p.Name;
      return View(r);
    }

    [HttpPost]
    public IActionResult Delete(Registration r)
    {
      context.Entry(r).State = EntityState.Deleted;
      try
      {
        context.SaveChanges();
        return RedirectToAction("Registration");
      }
      catch(DbUpdateConcurrencyException)
      {
        ModelState.AddModelError("", String.Format("Registration with id {0}, no longer exists in the database.", r.Id));
        return RedirectToAction("Registation");
      }
    }
  }
}
