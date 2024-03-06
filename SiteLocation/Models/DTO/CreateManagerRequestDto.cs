namespace SiteLocation.Models.DTO
{
    public class CreateManagerRequestDto
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string Agence { get; set; }
        public string Adresse { get; set; }
        public DateTime DateNaissance { get; set; }
        public byte Tel { get; set; }
    }
}
