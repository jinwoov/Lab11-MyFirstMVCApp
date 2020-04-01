using Lab11_MyFirstMVCApp.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Lab11_MyFirstMVCApp.Controllers
{
    public class HomeController : Controller
    {
        private IWebHostEnvironment _hostingEnvironment;

        public HomeController(IWebHostEnvironment environment)
        {
            _hostingEnvironment = environment;
        }

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
            var path = Path.Combine(_hostingEnvironment.WebRootPath, "personOfTheYear.csv");
            var people = TimePerson.GetPersons(year.FromYear, year.ToYear, path);
            return View(people);
        }

    }
}
