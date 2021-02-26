using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GBCSporting2021_Caeruleum.Controllers
{
    public class IncidentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Incident()
        {
            ViewData["Message"] = "Incidents Page";
            return View();
        }

        public IActionResult Add()
        {
            ViewData["Message"] = "Add Incident Page";
            return View();
        }

        public IActionResult Edit()
        {
            ViewData["Message"] = "Edit Incident Page";
            return View();
        }

        public IActionResult Delete()
        {
            ViewData["Message"] = "Delete Incident Page";
            return View();
        }
    }
}
