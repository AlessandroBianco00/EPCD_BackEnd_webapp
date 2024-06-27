using System.ComponentModel.DataAnnotations;

namespace ElencoMagazzinoWebApp.Models
{
    public class ProductInputModel
    {
        [Required(ErrorMessage = "Inserire il nome")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "Inserire descrizione")]
        public string Description { get; set; }
        [Required, Range(1, 1000)]
        public int QuantityAvailable { get; set; }
        [Required(ErrorMessage = "Inserire l'immagine del prodotto")]
        public IFormFile ProductPicture { get; set; }
    }
}
