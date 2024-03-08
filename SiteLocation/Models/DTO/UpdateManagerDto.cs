namespace SiteLocation.Models.DTO
{
    public class UpdateManagerDto
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string Agence { get; set; }
        public string Adresse { get; set; }
        public DateTime DateNaissance { get; set; }
        public string Tel { get; set; }
    }
}
