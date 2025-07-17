using Api_restaurant.Classes;

namespace Api_restaurant.Dto
{
    public class ClientItemDTO
    {
        public int Id { get; set; }
        public string? Nom { get; set; }
        public string? Prenom { get; set; }
        public int Telephone { get; set; }
        public string Email { get; set; }
        public int NumeroDeRue { get; set; }
        public string NomDeRue { get; set; }
        public int CodePostal { get; set; }
        public string Ville { get; set; }
        public string? Categorie { get; set; }

        public ClientItemDTO() { }
        public ClientItemDTO(Client clientsItem) => 
            
        (Id, Nom, Prenom, Telephone, Email, NumeroDeRue, NomDeRue, CodePostal, Ville, Categorie) = (clientsItem.Id, clientsItem.Nom, clientsItem.Prenom, clientsItem.Telephone , clientsItem.Email, clientsItem.NumeroDeRue, clientsItem.NomDeRue, clientsItem.CodePostal, clientsItem.Ville, clientsItem.Categorie);
    }
}
