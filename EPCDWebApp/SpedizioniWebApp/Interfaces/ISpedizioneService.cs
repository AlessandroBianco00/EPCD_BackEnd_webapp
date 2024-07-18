using SpedizioniWebApp.Models;

namespace SpedizioniWebApp.Interfaces
{
    public interface ISpedizioneService
    {
        void AggiungiSpedizione(Spedizione spedizione);

        List<Spedizione> GetProssimeSpedizioni();

        List<Spedizione> GetSpedizioniDiOggi();

        int GetNumeroSpedizioni();

        public Dictionary<string, int> GetSpedizioniPerCitta();
    }
}
