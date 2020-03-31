using Lab11_MyFirstMVCApp.Models;
using Microsoft.AspNetCore.Mvc;
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
            List<TimePerson> people = TimePerson.GetPersons(fromYear, toYear);

            return RedirectToAction("Results", people);
        }

        [HttpGet]
        public IActionResult Results(List<TimePerson> peeple)
        {
            return View(peeple);
        }

    }
}
