using System.ComponentModel.DataAnnotations;

namespace SpedizioniWebApp.Models
{
    public class Azienda : Cliente
    {
        [Required]
        public string RagioneSociale { get; set; }

        [Required]
        public string PartitaIva { get; set; }
    }
}
