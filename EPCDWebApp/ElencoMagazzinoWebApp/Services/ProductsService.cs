using ElencoMagazzinoWebApp.Models;
namespace ElencoMagazzinoWebApp.Services
{
    public class ProductsService : IProductsService
    {
        private static readonly List<Product> products = new List<Product>();
        private static int lastId = 0;

        public void Create(Product product)
        {
            product.ProductId = ++lastId;
            products.Add(product);
        }

        public IEnumerable<Product> GetAllProducts() => products;
    }
}
