using Api_restaurant.Classes;

namespace Api_restaurant.DTO
{
    public class CommandeItemDTO
    {
        public int Id { get; set; }
        public Client clients { get; set; }
        public List<Article> Articles { get; set; }
        public DateTime DateCommande { get; set; } = DateTime.Now;

        // Constructeur
        public CommandeItemDTO() { }
        public CommandeItemDTO(Commande commandeItem) =>
        (Id, clients, Articles, DateCommande) = (commandeItem.Id, commandeItem.clients, commandeItem.Articles, commandeItem.DateCommande);
    }

}
