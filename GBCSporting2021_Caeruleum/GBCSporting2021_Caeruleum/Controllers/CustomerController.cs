using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GBCSporting2021_Caeruleum.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ModelBinding;

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
      ViewBag.CountryId = 2;
      ViewBag.Countries = context.Countries.ToList();
      return View("Edit");
    }

    [HttpPost]
    public IActionResult Add(Customer c)
    {
      List<Customer> c_list = context.Customers.ToList();
      bool email_unique = true;
      for(int i = 0; i < c_list.Count; i++)
      {
        if(c.Email == c_list[i].Email)
        {
          email_unique = false;
          break;
        }
      }
      if(ModelState.IsValid && email_unique)
      {
        context.Customers.Add(c);
        context.SaveChanges();
        return RedirectToAction("Customer");
      }
      else
      {
        ViewBag.Action = "Add";
        ViewBag.CountryId = 2;
        ViewBag.Countries = context.Countries.ToList();
        return View("Edit", c);
      }
    }

    public IActionResult Edit(int Id)
    {
      Customer c = context.Customers.Find(Id);
      ViewBag.FirstName = c.FirstName;
      ViewBag.LastName = c.LastName;
      ViewBag.Phone = c.Phone;
      ViewBag.Email = c.Email;
      ViewBag.City = c.City;
      ViewBag.State = c.State;
      ViewBag.PostalCode = c.PostalCode;
      ViewBag.CountryId = c.CountryId;
      ViewBag.Address = c.Address;
      ViewBag.Action = "Edit";
      ViewBag.Countries = context.Countries.ToList();
      ViewData["Message"] = "Edit Customer Page";
      return View("Edit");
    }

    [HttpPost]
    public IActionResult Edit(Customer c)
    {
      if(ModelState.IsValid && c != null)
      {
        try
        {
          context.Customers.Update(c);
          context.SaveChanges();
          return RedirectToAction("Customer");
        }
        catch(Exception)
        {
          ViewBag.FirstName = c.FirstName;
          ViewBag.LastName = c.LastName;
          ViewBag.Phone = c.Phone;
          ViewBag.City = c.City;
          ViewBag.State = c.State;
          ViewBag.PostalCode = c.PostalCode;
          ViewBag.CountryId = c.CountryId;
          ViewBag.Address = c.Address;
          ViewBag.Email = c.Email;
          ViewBag.Action = "Edit";
          ViewBag.Countries = context.Countries.ToList();
          ViewData["Message"] = "Edit Customer Page";
          return View("Edit", c);
        }
      }
      else
      {
        ViewBag.FirstName = c.FirstName;
        ViewBag.LastName = c.LastName;
        ViewBag.Phone = c.Phone;
        ViewBag.City = c.City;
        ViewBag.State = c.State;
        ViewBag.PostalCode = c.PostalCode;
        ViewBag.CountryId = c.CountryId;
        ViewBag.Address = c.Address;
        ViewBag.Email = c.Email;
        ViewBag.Action = "Edit";
        ViewBag.Countries = context.Countries.ToList();
        ViewData["Message"] = "Edit Customer Page";
        return View("Edit", c);
      }
    }

    public IActionResult Delete(int Id)
    {
      Customer cstmr = context.Customers.Find(Id);
      Country cntry = context.Countries.Find(cstmr.CountryId);
      ViewBag.FirstName = cstmr.FirstName;
      ViewBag.LastName = cstmr.LastName;
      ViewBag.Phone = cstmr.Phone;
      ViewBag.Email = cstmr.Email;
      ViewBag.City = cstmr.City;
      ViewBag.State = cstmr.State;
      ViewBag.PostalCode = cstmr.PostalCode;
      ViewBag.Country = cntry.Name;
      ViewBag.Address = cstmr.Address;
      ViewBag.Action = "Delete";
      ViewData["Message"] = "Delete Customer Page";
      return View("Delete", cstmr);
    }

    [HttpPost]
    public IActionResult Delete(Customer c)
    {
      context.Entry(c).State = EntityState.Deleted;
      try
      {
        context.SaveChanges();
        return RedirectToAction("Customer");
      }
      catch(DbUpdateConcurrencyException)
      {
        ModelState.AddModelError("", String.Format("Customer with id {0}, no longer exists in the database.", c.Id));
        return RedirectToAction("Customer");
      }
    }
  }
}
