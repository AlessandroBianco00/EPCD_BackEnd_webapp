using SpedizioniWebApp.Models;

namespace SpedizioniWebApp.Interfaces
{
    public interface ISpedizioneService
    {
        void AggiungiSpedizione(Spedizione spedizione);

        public List<Spedizione> GetProssimeSpedizioni();
    }
}
