using SpedizioniWebApp.Interfaces;
using SpedizioniWebApp.Models;
using System.Data.SqlClient;

namespace SpedizioniWebApp.Services
{
    public class AggiornamentoService : SqlServerServiceBase, IAggiornamentoService
    {
        public AggiornamentoService(IConfiguration config) : base(config)
        {
        }

        private const string INSERT_COMMAND = "INSERT INTO Aggiornamenti(SpedizioneId_FK, PosizioneAttuale, Descrizione, StatoAggiornamento) VALUES(@spedizioneId, @posizioneAttuale, @descrizione, @statoAggiornamento)";
        private const string SELECT_BY_ID_COMMAND = "SELECT AggiornamentoId, SpedizioneId_FK, PosizioneAttuale, Descrizione, DataAggiornamento, StatoAggiornamento FROM Aggiornamenti WHERE SpedizioneId_FK = @id";

        public void AggiungiAggiornamento(Aggiornamento aggiornamento, int id)
        {
            try
            {
                var cmd = GetCommand(INSERT_COMMAND);
                cmd.Parameters.Add(new SqlParameter("@spedizioneId", id));
                cmd.Parameters.Add(new SqlParameter("@posizioneAttuale", aggiornamento.PosizioneAttuale));
                cmd.Parameters.Add(new SqlParameter("@descrizione", aggiornamento.Descrizione));
                cmd.Parameters.Add(new SqlParameter("@statoAggiornamento", aggiornamento.StatoAggiornamento));
                var conn = GetConnection();
                conn.Open();
                var result = cmd.ExecuteNonQuery();
                conn.Close();
                if (result != 1) throw new Exception("Inserimento fallito");
            }
            catch (Exception ex)
            {
                throw new Exception("Errore nella creazione del aggiornamento", ex);
            }
        }

        public List<Aggiornamento> GetAllAggiornamenti()
        {
            var list = new List<Aggiornamento>();
            try

            {
                using var conn = GetConnection();
                conn.Open();
                using var cmd = GetCommand(SELECT_BY_ID_COMMAND);
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                    list.Add(new Aggiornamento
                    {
                        Id = reader.GetInt32(0),
                        IdSpedizione = reader.GetInt32(1),
                        PosizioneAttuale = reader.GetString(2),
                        Descrizione = reader.GetString(3),
                        DataAggiornamento = reader.GetDateTime(4),
                        StatoAggiornamento = reader.GetChar(5)
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
