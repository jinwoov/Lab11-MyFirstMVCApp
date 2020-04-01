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
        /// <summary>
        /// This declare that our environment is going to be used as private variable
        /// </summary>
        /// <param name="environment">Setting the wwwroot as base folder</param>
        public HomeController(IWebHostEnvironment environment)
        {
            _hostingEnvironment = environment;
        }

        /// <summary>
        /// Get method for index page
        /// </summary>
        /// <returns>having the view page to show the page</returns>
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Posting the search from home where the query will be passed to the result page for it to run in result method
        /// </summary>
        /// <param name="fromYear">Parameter that will grab from what year</param>
        /// <param name="toYear">Parameter that will grab from to what year</param>
        /// <returns>redirecting it to result page and pasing the year</returns>
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


        /// <summary>
        /// Get method that will pass the year which will be grabbed from post method of indx
        /// </summary>
        /// <param name="year">object that carries from year and to year</param>
        /// <returns>render the view page of results.html to have people class objects</returns>
        [HttpGet]
        public IActionResult Results(Year year)
        {
            var path = Path.Combine(_hostingEnvironment.WebRootPath, "personOfTheYear.csv");
            var people = TimePerson.GetPersons(year.FromYear, year.ToYear, path);
            return View(people);
        }

    }
}
