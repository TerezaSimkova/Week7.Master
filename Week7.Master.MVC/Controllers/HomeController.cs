using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Week7.Master.MVC.Models;

namespace Week7.Master.MVC.Controllers
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
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Prova()
        {
            //Viewbag
            ViewBag.Messaggio = "Benvenuti nella pagina. Questo e il messaggio contenute nella variabile Messaggio della viewbag.";
            ViewBag.Valore = @"25/10/2021";

            //ViewData
            ViewData["MessaggioVD"] = "Benvenuti da parte del ViewData!"; // cerca prima la variabile in view data ,attenzione ai nomi uguali! 
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
