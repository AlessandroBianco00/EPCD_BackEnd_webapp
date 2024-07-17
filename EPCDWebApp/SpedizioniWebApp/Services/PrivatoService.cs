using Microsoft.Extensions.Logging;
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

        private const string INSERT_COMMAND = "INSERT INTO Clienti(TipoCliente, Nome, Cognome, CodiceFiscale, Email, Citta) VALUES(@tipocliente, @nome, @cognome, @codicefiscale, @email, @citta)";
        private const string SELECT_ALL_COMMAND = "SELECT ClienteId, Nome, Cognome, CodiceFiscale, Email, Citta FROM Clienti WHERE TipoCliente = 'p'";

        public void AggiungiPrivato(Privato privato)
        {
            try
            {
                var cmd = GetCommand(INSERT_COMMAND);
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

        public List<Privato> GetAllPrivati()
        {
            var list = new List<Privato>();
            try
            
            {
                using var conn = GetConnection();
                conn.Open();
                using var cmd = GetCommand(SELECT_ALL_COMMAND);
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                    list.Add(new Privato
                    {
                        Id = reader.GetInt32(0),
                        Nome = reader.GetString(1),
                        Cognome = reader.GetString(2),
                        CodiceFiscale = reader.GetString(3),
                        Email = reader.GetString(4),
                        Citta = reader.GetString(5)
                    });
                conn.Close();
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception("Errore nel recupero clienti", ex);
            }
        }
    }
}
