using Lab11_MyFirstMVCApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab11_MyFirstMVCApp.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(int fromYear, int toYear)
        {
            Year year = new Year()
            {
                FromYear = fromYear,
                ToYear = toYear
            };
            return RedirectToAction("Results", year);
        }

        [HttpGet]
        public IActionResult Results(Year year)
        {
            var people = TimePerson.GetPersons(year.FromYear, year.ToYear);
            return View(people);
        }

    }
}
