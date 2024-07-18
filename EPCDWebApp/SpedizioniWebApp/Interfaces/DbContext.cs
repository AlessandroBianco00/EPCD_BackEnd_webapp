namespace SpedizioniWebApp.Interfaces
{
    public class DbContext
    {
        public IAggiornamentoService Aggiornamenti { get; set; }
        public IAziendaService Aziende { get; set; }
        public IPrivatoService Privati {  get; set; }
        public ISpedizioneService Spedizioni { get; set; }

        public DbContext(IAggiornamentoService aggiornamentoDao, IAziendaService aziendaDao, IPrivatoService privatoDao, ISpedizioneService spedizioneDao)
        {
            Aggiornamenti = aggiornamentoDao;
            Aziende = aziendaDao;
            Privati = privatoDao;
            Spedizioni = spedizioneDao;
        }
    }
}
