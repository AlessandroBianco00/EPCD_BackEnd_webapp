using SpedizioniWebApp.Interfaces;
using SpedizioniWebApp.Models;
using System.Data.SqlClient;

namespace SpedizioniWebApp.Services

{
    public class PrivatoService : SqlServerServiceBase, IPrivatoService
    {
        public PrivatoService(IConfiguration config) : base(config)
        {
        }

        public void AggiungiPrivato(Privato privato)
        {
            try
            {
                var cmd = GetCommand("INSERT INTO Clienti(TipoCliente, Nome, Cognome, CodiceFiscale, Email, Citta) VALUES(@tipocliente, @nome, @cognome, @codicefiscale, @email, @citta)");
                cmd.Parameters.Add(new SqlParameter("@tipocliente", "p"));
                cmd.Parameters.Add(new SqlParameter("@nome", privato.Nome));
                cmd.Parameters.Add(new SqlParameter("@cognome", privato.Cognome));
                cmd.Parameters.Add(new SqlParameter("@codicefiscale", privato.CodiceFiscale));
                cmd.Parameters.Add(new SqlParameter("@email", privato.Email));
                cmd.Parameters.Add(new SqlParameter("@citta", privato.Citta));
                var conn = GetConnection();
                conn.Open();
                var result = cmd.ExecuteNonQuery();
                conn.Close();
                if (result != 1) throw new Exception("Inserimento fallito");
            }
            catch (Exception ex)
            {
                throw new Exception("Errore nella creazione del cliente", ex);
            }   
        }
    }
}
