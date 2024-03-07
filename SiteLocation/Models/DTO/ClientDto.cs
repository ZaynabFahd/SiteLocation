namespace SiteLocation.Models.DTO
{
    public class ClientDto
    {
        public int ClientId { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string MotPass { get; set; }
        public string Adresse { get; set; }
        public string PermisConduire { get; set; }
        public DateTime DateNaissance { get; set; }
        public string Tel { get; set; }
    }
}
