using SpedizioniWebApp.Models;

namespace SpedizioniWebApp.Interfaces
{
    public interface IAggiornamentoService
    {
        void AggiungiAggiornamento(Aggiornamento aggiornamento, int id);

        List<Aggiornamento> GetAllAggiornamenti();

        IEnumerable<Aggiornamento> StatoSpedizioni(string CFOrPIVA, int NumeroSpedizone);
    }
}
