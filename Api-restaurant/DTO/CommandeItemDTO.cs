using Api_restaurant.Classes;
using System.Xml.Linq;

namespace Api_restaurant.DTO
{
    public class CommandeItemDTO
    {
        public int Id { get; set; }
        public Clients clients { get; set; }
        public List<Articles> Articles { get; set; }
        public DateTime DateCommande { get; set; } = DateTime.Now;

        // Constructeur
        public CommandeItemDTO() { }
        public CommandeItemDTO(Commandes commandeItem) =>
        (Id, clients, Articles, DateCommande) = (commandeItem.Id, commandeItem.clients, commandeItem.Articles, commandeItem.DateCommande);
    }

}
