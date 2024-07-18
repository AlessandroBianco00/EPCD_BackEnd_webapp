using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SpedizioniWebApp.Interfaces;
using SpedizioniWebApp.Models;

namespace SpedizioniWebApp.Controllers
{
    [Authorize(Policy = Policies.IsAdmin)]
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;
        private readonly DbContext _dbContext;

        public AdminController(ILogger<AdminController> logger, DbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }
        // ACTION AGGIUNTA CLIENTI (PRIVATI & AZIENDE)
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
            _dbContext.Privati.AggiungiPrivato(privato);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult FormAzienda()
        {
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult FormAzienda(Azienda azienda)
        {
            _dbContext.Aziende.AggiungiAzienda(azienda);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult RegistraSpedizione()
        {
            var privati = _dbContext.Privati.GetAllPrivati();
            ViewBag.Privati = privati;
            var aziende = _dbContext.Aziende.GetAllAziende();
            ViewBag.Aziende = aziende;
            return View(new Spedizione());
        }

        [HttpPost]
        public IActionResult RegistraSpedizione(Spedizione spedizione)
        {
            _dbContext.Spedizioni.AggiungiSpedizione(spedizione);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult RegistraAggiornamento(int id)
        {
            ViewBag.Id = id;
            return View(new Aggiornamento());
        }

        [HttpPost]
        public IActionResult RegistraAggiornamento(Aggiornamento aggiornamento, int id)
        {
            _dbContext.Aggiornamenti.AggiungiAggiornamento(aggiornamento, id);
            return RedirectToAction("Index", "Home");
        }

        // ACTION AMMINISTRAZIONE

        public IActionResult ProssimeSpedizioni()
        {
            var spedizioni = _dbContext.Spedizioni.GetProssimeSpedizioni();
            return View(spedizioni);
        }

        public IActionResult QueryAmministrazione()
        {
            int numeroSpedizioni = _dbContext.Spedizioni.GetNumeroSpedizioni();
            ViewBag.NumeroSpedizioni = numeroSpedizioni;
            Dictionary<string, int> spedizioniCitta = _dbContext.Spedizioni.GetSpedizioniPerCitta();
            ViewBag.SpedizioniCitta = spedizioniCitta;
            List<Spedizione> spedizioniOdierne = _dbContext.Spedizioni.GetSpedizioniDiOggi();
            return View(spedizioniOdierne);
        }
    }
}
