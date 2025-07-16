namespace Api_restaurant.Classes
    {
        public class Commandes
        {
            public int Id { get; set; }

            public Clients { get; set; }

        public List<Articles> Articles { get; set; } = new List<Articles>();
            public DateTime DateCommande { get; set; } = DateTime.Now;

            public decimal CalculerTotal()
            {
                return Articles.Sum(a => a.Prix);
            }

            public override string ToString()
            {
                return $"Commande #{Id} - Client: {Clients.Nom} - Date: {DateCommande:d} - Total: {CalculerTotal():C}";
            }
        }
    }
