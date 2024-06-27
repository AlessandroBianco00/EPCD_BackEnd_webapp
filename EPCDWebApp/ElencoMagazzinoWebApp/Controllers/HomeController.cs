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
        private readonly IWebHostEnvironment _env;

        public HomeController(ILogger<HomeController> logger, IProductsService productsService, IWebHostEnvironment env)
        {
            _logger = logger;
            _productsService = productsService;
            _env = env;
        }

        public IActionResult Index()
        {
            var products = _productsService.GetAllProducts();
            return View(products);
        }

        public IActionResult AggiungiProdotto()
        {
            ViewData["ListaProdotti"] = _productsService.GetAllProducts();
            return View(new ProductInputModel());
        }
        [HttpPost]
        public IActionResult AggiungiProdotto(ProductInputModel inputProdotto)
        {
            var prodotto = new Product { ProductName = inputProdotto.ProductName , Description = inputProdotto.Description, QuantityAvailable = inputProdotto.QuantityAvailable };
            _productsService.Create(prodotto);
            string uploads = Path.Combine(_env.WebRootPath, "images");
            if (inputProdotto.ProductPicture.Length > 0)
            {
                string filePath = Path.ChangeExtension(Path.Combine(uploads, prodotto.ProductId.ToString()), "jpg");
                using Stream fileStream = new FileStream(filePath, FileMode.Create);
                inputProdotto.ProductPicture.CopyTo(fileStream);
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Detail(int id)
        {
            var product = _productsService.GetById(id);
            string uploads = Path.Combine(_env.WebRootPath, "images");
            var cover = Path.ChangeExtension(Path.Combine(uploads, product.ProductId.ToString()), "jpg");
            if (System.IO.File.Exists(cover))
                ViewBag.Cover = $"/images/{product.ProductId}.jpg";
            return View(product);
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
