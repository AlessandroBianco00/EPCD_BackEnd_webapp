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
        private readonly IPrivatoService _privatoService;
        private readonly IAziendaService _aziendaService;
        private readonly ISpedizioneService _spedizioneService;
        private readonly IAggiornamentoService _aggiornamentoService;

        public HomeController(ILogger<HomeController> logger, IPrivatoService privatoService, IAziendaService aziendaService, ISpedizioneService spedizioneService, IAggiornamentoService aggiornamentoService)
        {
            _logger = logger;
            _privatoService = privatoService;
            _aziendaService = aziendaService;
            _spedizioneService = spedizioneService;
            _aggiornamentoService = aggiornamentoService;
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
            _privatoService.AggiungiPrivato(privato);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult FormAzienda()
        {
            return View(new Azienda());
        }

        [HttpPost]
        public IActionResult FormAzienda(Azienda azienda)
        {
            _aziendaService.AggiungiAzienda(azienda);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult RegistraSpedizione()
        {
            var privati = _privatoService.GetAllPrivati();
            ViewBag.Privati = privati;
            var aziende = _aziendaService.GetAllAziende();
            ViewBag.Aziende = aziende;
            return View(new Spedizione());
        }

        [HttpPost]
        public IActionResult RegistraSpedizione(Spedizione spedizione)
        {
            _spedizioneService.AggiungiSpedizione(spedizione);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult RegistraAggiornamento(int id)
        {
            ViewBag.Id = id;
            return View(new Aggiornamento());
        }

        [HttpPost]
        public IActionResult RegistraAggiornamento(Aggiornamento aggiornamento, int id)
        {
            _aggiornamentoService.AggiungiAggiornamento(aggiornamento, id);
            return RedirectToAction(nameof(Index));
        }

        // ACTION AMMINISTRAZIONE

        public IActionResult ProssimeSpedizioni()
        {
            var spedizioni = _spedizioneService.GetProssimeSpedizioni();
            return View(spedizioni);
        }

        public IActionResult QueryAmministrazione()
        {
            List<Spedizione> spedizioniOdierne = _spedizioneService.GetSpedizioniDiOggi();
            return View(spedizioniOdierne);
        }

        // ALTRO
        public IActionResult AggiornamentoSpedizione()
        {
            return View();
        }

        public IActionResult StatoSpedizioni()
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
