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

        public string Email { get; set; }

        public string Citta { get; set; }
    }
}
