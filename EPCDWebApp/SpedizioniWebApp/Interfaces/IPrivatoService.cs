using SpedizioniWebApp.Models;

namespace SpedizioniWebApp.Interfaces
{
    public interface IPrivatoService
    {
        void AggiungiPrivato(Privato privato);

        public List<Privato> GetAllPrivati();
    }
}
