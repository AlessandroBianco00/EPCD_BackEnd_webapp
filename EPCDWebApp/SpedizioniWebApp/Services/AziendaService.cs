using SpedizioniWebApp.Interfaces;
using SpedizioniWebApp.Models;
using System.Data.SqlClient;

namespace SpedizioniWebApp.Services
{
    public class AziendaService : SqlServerServiceBase, IAziendaService
    {
        public AziendaService(IConfiguration config) : base(config)
        {
        }

        private const string INSERT_COMMAND = "INSERT INTO Clienti(TipoCliente, RagioneSociale,PartitaIva, Email, Citta) VALUES(@tipocliente, @ragionesociale, @partitaiva, @email, @citta)";
        private const string SELECT_ALL_COMMAND = "SELECT ClienteId, RagioneSociale, PartitaIva, Email, Citta FROM Clienti WHERE TipoCliente = 'a'";

        public void AggiungiAzienda(Azienda azienda)
        {
            try
            {
                var cmd = GetCommand(INSERT_COMMAND);
                cmd.Parameters.Add(new SqlParameter("@tipocliente", "a"));
                cmd.Parameters.Add(new SqlParameter("@ragionesociale", azienda.RagioneSociale));
                cmd.Parameters.Add(new SqlParameter("@partitaiva", azienda.PartitaIva));
                cmd.Parameters.Add(new SqlParameter("@email", azienda.Email));
                cmd.Parameters.Add(new SqlParameter("@citta", azienda.Citta));
                var conn = GetConnection();
                conn.Open();
                var result = cmd.ExecuteNonQuery();
                conn.Close();
                if (result != 1) throw new Exception("Inserimento fallito");
            }
            catch (Exception ex)
            {
                throw new Exception("Errore nella creazione dell'azienda", ex);
            }
        }

        public List<Azienda> GetAllAziende()
        {
            var list = new List<Azienda>();
            try

            {
                using var conn = GetConnection();
                conn.Open();
                using var cmd = GetCommand(SELECT_ALL_COMMAND);
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                    list.Add(new Azienda
                    {
                        Id = reader.GetInt32(0),
                        RagioneSociale = reader.GetString(1),
                        PartitaIva = reader.GetString(2),
                        Email = reader.GetString(3),
                        Citta = reader.GetString(4)
                    });
                conn.Close();
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception("Errore nel recupero aziende", ex);
            }
        }
    }
}
