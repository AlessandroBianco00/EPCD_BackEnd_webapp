using SpedizioniWebApp.Interfaces;
using SpedizioniWebApp.Models;
using System.Data.SqlClient;

namespace SpedizioniWebApp.Services
{
    public class SpedizioneService: SqlServerServiceBase, ISpedizioneService
    {
        public SpedizioneService(IConfiguration config) : base(config)
        {
        }

        private const string INSERT_COMMAND = "INSERT INTO Spedizioni(ClienteId, DataSpedizione, Peso, CittaDestinataria, Indirizzo, CostoSpedizione, DataConsegna) VALUES(@clienteId, @dataSpedizione, @peso, @cittaDestinataria, @indirizzo, @costoSpedizione, @dataConsegna)";
        private const string SELECT_NEXT_COMMAND = "SELECT SpedizioneId, ClienteId, DataSpedizione, Peso, CittaDestinataria, Indirizzo, CostoSpedizione, DataConsegna FROM Spedizioni WHERE DataConsegna >= GETDATE()";

        public void AggiungiSpedizione(Spedizione spedizione)
        {
            try
            {
                var cmd = GetCommand(INSERT_COMMAND);
                cmd.Parameters.Add(new SqlParameter("@clienteId", spedizione.ClienteId));
                cmd.Parameters.Add(new SqlParameter("@dataSpedizione", spedizione.DataSpedizione));
                cmd.Parameters.Add(new SqlParameter("@peso", spedizione.Peso));
                cmd.Parameters.Add(new SqlParameter("@cittaDestinataria", spedizione.CittaDestinataria));
                cmd.Parameters.Add(new SqlParameter("@indirizzo", spedizione.Indirizzo));
                cmd.Parameters.Add(new SqlParameter("@costoSpedizione", spedizione.CostoSpedizione));
                cmd.Parameters.Add(new SqlParameter("@dataConsegna", spedizione.DataConsegna));
                var conn = GetConnection();
                conn.Open();
                var result = cmd.ExecuteNonQuery();
                conn.Close();
                if (result != 1) throw new Exception("Inserimento fallito");
            }
            catch (Exception ex)
            {
                throw new Exception("Errore nella creazione della spedizione", ex);
            }
        }

        public List<Spedizione> GetProssimeSpedizioni()
        {
            var list = new List<Spedizione>();
            try

            {
                using var conn = GetConnection();
                conn.Open();
                using var cmd = GetCommand(SELECT_NEXT_COMMAND);
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                    list.Add(new Spedizione
                    {
                        SpedizioneId = reader.GetInt32(0),
                        ClienteId = reader.GetInt32(1),
                        DataSpedizione = reader.GetDateTime(2),
                        Peso = reader.GetDecimal(3),
                        CittaDestinataria = reader.GetString(4),
                        Indirizzo = reader.GetString(5),
                        CostoSpedizione = reader.GetDecimal(6),
                        DataConsegna = reader.GetDateTime(7)
                    });
                conn.Close();
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception("Errore nel recupero spedizioni", ex);
            }
        }
    }
}
