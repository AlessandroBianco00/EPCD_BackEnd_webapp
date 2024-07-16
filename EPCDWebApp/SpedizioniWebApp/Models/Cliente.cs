using System.ComponentModel.DataAnnotations;

namespace SpedizioniWebApp.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        public enum TipoCliente
        {
            Azienda,
            Privato
        }

        public TipoCliente Tipo { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Citta { get; set; }
    }
}
