using System.ComponentModel.DataAnnotations;

namespace SpedizioniWebApp.Models
{
    public class Privato : Cliente
    {
        [Required]
        public string Nome { get; set; }

        [Required]
        public string Cognome { get; set; }

        [Required]
        public string CodiceFiscale { get; set; }
    }
}
