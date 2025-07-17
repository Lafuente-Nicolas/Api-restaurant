namespace Api_restaurant.DTO
{
    public class CommandeDTO
    {
        public int Id { get; set; }
        public string ClientNom { get; set; } = string.Empty;
        public List<string> ArticlesNoms { get; set; } = new List<string>();
        public decimal Total { get; set; }
        public CommandeDTO(int id, string clientNom, List<string> articlesNoms, decimal total)
        {
            Id = id;
            ClientNom = clientNom;
            ArticlesNoms = articlesNoms;
            Total = total;
        }
    }
}
