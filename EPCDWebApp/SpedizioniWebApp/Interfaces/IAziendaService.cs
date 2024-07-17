﻿using SpedizioniWebApp.Models;

namespace SpedizioniWebApp.Interfaces
{
    public interface IAziendaService
    {
        void AggiungiAzienda (Azienda azienda);
        public List<Azienda> GetAllAziende();
    }
}
