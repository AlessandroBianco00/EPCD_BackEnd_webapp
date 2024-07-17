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

        public void AggiungiAzienda(Azienda azienda)
        {
            try
            {
                var cmd = GetCommand("INSERT INTO Clienti(TipoCliente, RagioneSociale,PartitaIva, Email, Citta) VALUES(@tipocliente, @ragionesociale, @partitaiva, @email, @citta)");
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
    }
}
