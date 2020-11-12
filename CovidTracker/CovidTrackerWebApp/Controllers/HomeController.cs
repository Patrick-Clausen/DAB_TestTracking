using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CovidTrackerWebApp.Models;

namespace CovidTrackerWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewResult view = View();
            view.
            return View();
        }

        public IActionResult Statistics()
        {
            return View();
        }

        public IActionResult PossibleInfections()
        {
            return View();
        }

        public IActionResult NewCitizen()
        {
            return View();
        }

        public IActionResult NewTestCenter()
        {
            return View();
        }

        public IActionResult NewTestCase()
        {
            return View();
        }

        public IActionResult NewLocation()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
