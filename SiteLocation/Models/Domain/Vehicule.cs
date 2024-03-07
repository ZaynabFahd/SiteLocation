namespace SiteLocationVihecule.Models.Domain
{
    public class Vehicule
    {
        public int VehiculeId { get; set; }
        public string NomVehicule {  get; set; }
        public string Marque { get; set; }
        public DateTime AnneeConstruction { get; set; }
        public bool Disponibilite { get; set; } 
        public string Carburant { get; set; }
        public string TypeVehicule { get; set; }
        public byte NombrePlace { get; set; }
        public string Couleur { get; set;}
        public bool FullOption { get; set; }
        public string Agence { get; set; }
        public byte AgeMinConducteur { get; set; }
        public double Prix { get; set; }
        public string ImageUrl { get; set; }
    }
}
