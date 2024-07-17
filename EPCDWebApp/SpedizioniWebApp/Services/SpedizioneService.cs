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
    }
}
