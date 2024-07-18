using SpedizioniWebApp.Services;

namespace SpedizioniWebApp.Interfaces
{
    public static class Helpers
    {
        /// <summary>
        /// Extension method per la configurazione nella D.I. dei DAO.
        /// </summary>
        /// <param name="services">La collezione dei servizi gestiti dalla D.I.</param>
        public static IServiceCollection RegisterDAOs(this IServiceCollection services)
        {
            return services
                .AddScoped<IAggiornamentoService, AggiornamentoService>()
                .AddScoped<IAziendaService, AziendaService>()
                .AddScoped<IPrivatoService, PrivatoService>()
                .AddScoped<ISpedizioneService, SpedizioneService>()
                ;
        }
    }
}
