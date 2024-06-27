using ElencoMagazzinoWebApp.Models;

namespace ElencoMagazzinoWebApp.Services
{
    public interface IProductsService
    {
        public void Create(Product product);
        public IEnumerable<Product> GetAllProducts();
    }
}
