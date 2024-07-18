using SpedizioniWebApp.Models;

namespace SpedizioniWebApp.Interfaces
{
    public interface IAggiornamentoService
    {
        void AggiungiAggiornamento(Aggiornamento aggiornamento, int id);

        public List<Aggiornamento> GetAllAggiornamenti();
    }
}
