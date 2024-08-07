using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SpedizioniWebApp.Interfaces;
using SpedizioniWebApp.Models;
using System.Diagnostics;

namespace SpedizioniWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DbContext _dbContext;

        public HomeController(ILogger<HomeController> logger, DbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        // VIEW STATICHE
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contatti()
        {
            return View();
        }

        [Authorize]
        public IActionResult Privacy()
        {
            return View();
        }

        // ALTRO
        /*public IActionResult AggiornamentoSpedizione()
        {
            return View();
        } non necessaria  */

        public IActionResult StatoSpedizioni()
        {
            return View();
        }

        [HttpPost]
        public IActionResult StatoSpedizioni(int numeroSpedizione, string CForIVA)
        {
            var aggiornamenti = _dbContext.Aggiornamenti.StatoSpedizioni(CForIVA, numeroSpedizione);
            return View("AggiornamentoSpedizione", aggiornamenti);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
