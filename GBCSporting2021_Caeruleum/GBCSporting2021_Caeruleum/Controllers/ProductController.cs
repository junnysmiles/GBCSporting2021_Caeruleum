using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using GBCSporting2021_Caeruleum.Models;
using Microsoft.EntityFrameworkCore;

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
      ViewBag.ReleaseDate = DateTime.Now.ToString("yyyy-MM-dd");
      ViewBag.CountryId = 2;
      ViewBag.Countries = context.Countries.ToList();
      return View("Edit");
    }


    [HttpPost]
    public IActionResult Add(Product p)
    {
      if(ModelState.IsValid)
      {
        context.Products.Add(p);
        context.SaveChanges();
        TempData["Message"] = String.Format("{0} was added.", p.Name);
        return RedirectToAction("Product");
      }
      else
      {
        ViewBag.Action = "Add";
        ViewBag.ReleaseDate = DateTime.Now.ToString("yyyy-MM-dd");
        ViewBag.CountryId = 2;
        ViewBag.Countries = context.Countries.ToList();
        return View("Edit", p);
      }
    }

    public IActionResult Edit(int Id)
    {
      Product p = context.Products.Find(Id);
      ViewBag.Code = p.Code;
      ViewBag.Name = p.Name;
      ViewBag.Price = p.Price;
      ViewBag.ReleaseDate = p.ReleaseDate.ToString("yyyy-MM-dd");
      ViewBag.CountryId = p.CountryId;
      ViewBag.Action = "Edit";
      ViewBag.Countries = context.Countries.ToList();
      ViewData["Message"] = "Edit Product Page";
      return View("Edit");
    }

    [HttpPost]
    public IActionResult Edit(Product p)
    {
      if(ModelState.IsValid && p != null)
      {
        context.Products.Update(p);
        context.SaveChanges();
        TempData["Message"] = String.Format("{0} was updated.", p.Name);
        return RedirectToAction("Product");
      }
      else
      {
        p = context.Products.Find(p.Id);
        ViewBag.Code = p.Code;
        ViewBag.Name = p.Name;
        ViewBag.Price = p.Price;
        ViewBag.ReleaseDate = p.ReleaseDate.ToString("yyyy-MM-dd");
        ViewBag.CountryId = p.CountryId;
        ViewBag.Action = "Edit";
        ViewBag.Countries = context.Countries.ToList();
        return View("Edit", p);
      }
    }

    public IActionResult Delete(int Id)
    {
      Product p = context.Products.Find(Id);
      Country c = context.Countries.Find(p.CountryId);
      ViewBag.Id = p.Id;
      ViewBag.Code = p.Code;
      ViewBag.Name = p.Name;
      ViewBag.Price = p.Price;
      ViewBag.ReleaseDate = p.ReleaseDate.ToString("yyyy-MM-dd");
      ViewBag.Country = c.Name;
      ViewBag.Action = "Delete";
      ViewData["Message"] = "Delete Product Page";
      return View("Delete", p);
    }

    [HttpPost]
    public IActionResult Delete(Product p)
    {
      string name = p.Name;
      context.Entry(p).State = EntityState.Deleted;
      try
      {
        TempData["Message"] = String.Format("{0} was deleted.", name);
        context.SaveChanges();
        return RedirectToAction("Product");
      }
      catch(DbUpdateConcurrencyException)
      {
        ModelState.AddModelError("", String.Format("Product with id {0}, no longer exists in the database.", p.Id));
        return RedirectToAction("Product");
      }
    }

    public RedirectToActionResult Cancel()
    {
      TempData.Clear();
      return RedirectToAction("Product");
    }
  }
}
