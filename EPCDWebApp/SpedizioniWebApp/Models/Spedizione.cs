using System.ComponentModel.DataAnnotations;

namespace SpedizioniWebApp.Models
{
    public class Spedizione
    {
        public int SpedizioneId { get; set; }
        public int ClienteId { get; set; }
        [Required]
        public DateTime DataSpedizione {  get; set; }
        [Required]
        public decimal Peso { get; set; }
        [Required]
        public string CittaDestinataria { get; set; }
        [Required]
        public string Indirizzo { get; set; }
        [Required]
        public decimal CostoSpedizione { get; set; }
        [Required]
        public DateTime DataConsegna { get; set; }
    }
}
