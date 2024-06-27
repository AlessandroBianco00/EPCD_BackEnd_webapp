using ElencoMagazzinoWebApp.Models;
using ElencoMagazzinoWebApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ElencoMagazzinoWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductsService _productsService;

        public HomeController(ILogger<HomeController> logger, IProductsService productsService)
        {
            _logger = logger;
            _productsService = productsService;
        }

        public IActionResult Index()
        {
            var products = _productsService.GetAllProducts();
            return View(products);
        }

        public IActionResult AggiungiProdotto()
        {
            var prodotto = new Product();
            ViewData["ListaProdotti"] = _productsService.GetAllProducts();
            return View(prodotto);
        }
        [HttpPost]
        public IActionResult AggiungiProdotto(Product prodotto)
        {
            _productsService.Create(prodotto);
            return RedirectToAction(nameof(Index));
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
