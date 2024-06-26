using FormCinema.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Diagnostics;

namespace FormCinema.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        static List<SalaCinema> sale = new List<SalaCinema>() { new SalaCinema { Name = "Sala Nord" }, new SalaCinema { Name = "Sala Est" }, new SalaCinema { Name = "Sala Sud" } };

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Crea(Biglietto b)
        {
            int indiceSala = int.Parse(b.Sala);
            sale[indiceSala].biglietti.Add(b);
            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            var biglietto = new Biglietto();
            ViewData["listaSale"] = sale;
            return View(biglietto);
        }

        public IActionResult Privacy()
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
