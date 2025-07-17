namespace Api_restaurant.Classes
{
    public class Client
    {
        public int Id { get; set; }
        public string? Nom { get; set; }
        public string? Prenom { get; set; }
        public int Telephone { get; set; }
        public string Email { get; set; }
        public int NumeroDeRue{ get; set; }
        public string NomDeRue{ get; set; }
        public int CodePostal { get; set; }
        public string Ville { get; set; }
    }
}
