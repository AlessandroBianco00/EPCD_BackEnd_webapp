using Microsoft.AspNetCore.Mvc;
using SpedizioniWebApp.Models;
using System.Diagnostics;

namespace SpedizioniWebApp.Controllers
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

        public IActionResult Contatti()
        {
            return View();
        }

        public IActionResult AggiungiCliente()
        {
            return View();
        }

        public IActionResult FormPrivato()
        {
            return View(new Privato());
        }

        [HttpPost]
        public IActionResult FormPrivato(Privato privato)
        {
            //continua
            return View();
        }

        public IActionResult FormAzienda()
        {
            return View(new Azienda());
        }

        [HttpPost]
        public IActionResult FormAzienda(Azienda azienda)
        {
            //continua
            return View();
        }

        public IActionResult RegistraSpedizione()
        {
            return View();
        }

        public IActionResult AggiornamentoSpedizione()
        {
            return View();
        }

        public IActionResult StatoSpedizioni()
        {
            return View();
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
