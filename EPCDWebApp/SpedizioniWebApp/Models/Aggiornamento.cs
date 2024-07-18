namespace SpedizioniWebApp.Models
{
    public class Aggiornamento
    {
        public int Id { get; set; }
        public int IdSpedizione { get; set; }
        public string PosizioneAttuale { get; set; }
        public string Descrizione { get; set; }
        public DateTime DataAggiornamento { get; set; }
        public char StatoAggiornamento { get; set; }
    }
}
