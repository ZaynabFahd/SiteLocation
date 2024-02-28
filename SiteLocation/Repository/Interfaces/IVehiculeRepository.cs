using SiteLocationVihecule.Models.Domain;

namespace SiteLocation.Repository.Interfaces
{
    public interface IVehiculeRepository
    {
        // Je crée une méthode de création de vehicule,Task de type Vehicule 
        // La methode CreateAsync qui prend en parametre Vehicule du domain model 
        //Methode qui crée le vehicule dans la base de données

        Task<Vehicule> CreateAsync(Vehicule vehicule);

        // La methode GetAllAsync qui prend en parametre Vehicule du domain model
        Task<IEnumerable<Vehicule>> GetAllAsync();
    }
}
