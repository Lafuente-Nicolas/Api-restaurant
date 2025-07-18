namespace Api_restaurant.Classes
{
    public class CommandeArticle
    {
        public int CommandeId { get; set; }
        public Commande? Commande { get; set; }
        public int ArticleId { get; set; }
        public Article? Article { get; set; }

        

    }
}
