using SpedizioniWebApp.Models;

namespace SpedizioniWebApp.Interfaces
{
    public interface IAuthService
    {
        Utente Login(string username, string password);
    }
}
