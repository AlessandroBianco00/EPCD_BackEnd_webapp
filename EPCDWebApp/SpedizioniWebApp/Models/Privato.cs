namespace SpedizioniWebApp.Models
{
    public class Privato : Cliente
    {
        public string Nome { get; set; }

        public string Cognome { get; set; }

        public string CodiceFiscale { get; set; }
    }
}
