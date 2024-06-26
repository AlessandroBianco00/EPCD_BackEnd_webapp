namespace FormCinema.Models
{
    public class SalaCinema
    {
        public string Name { get; set; }
        private int posti = 120;
        public List<Biglietto> biglietti = new List<Biglietto>();

        public int GetAvailableTickets() { return posti - biglietti.Count; }
        public int GetDiscountedTickets()
        {
            int discountedTickets = 0;
            foreach (var ticket in biglietti)
            {
                if (ticket.Tariffa.Equals('r')) discountedTickets++;
            }
            return discountedTickets;
        }
    }
}
