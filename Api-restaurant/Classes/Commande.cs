namespace Api_restaurant.Classes
    {
        public class Commande
        {
            public int Id { get; set; }

            public Client clients { get; set; } 

        public List<Article> Articles { get; set; } = new List<Article>();

            public DateTime DateCommande { get; set; } = DateTime.Now;

            public decimal CalculerTotal()
            {
                return Articles.Sum(a => a.Prix);
            }

            public override string ToString()
            {
                return $"Commande #{Id} - Client: {clients.Nom} - Date: {DateCommande:d} - Total: {CalculerTotal():C}";
            }
        }
    }
