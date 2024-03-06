namespace SiteLocation.Models.DTO
{
    public class CreateLocationRequestDto
    {
        public DateTime DateLocation { get; set; }
        public DateTime DateRetour { get; set; }
        public string Client { get; set; }
        public string Manager { get; set; }
        public string Vehicule { get; set; }
        public string EtatVehicule { get; set; }
        public string AgenceRetrait { get; set; }
        public string AgenceRetour { get; set; }
        public bool Assurance { get; set; }

    }
}
