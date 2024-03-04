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

        // La méthode GetById qui prend en paramettre l'Id ou elle retourne null avec le ?
        Task<Vehicule?> GetById(int id);

        // La méthode qui prend en paramétre le model Vehicule
        Task<Vehicule?> UpdateAsync(Vehicule vehicule);

        Task<Vehicule?> DeleteAsync(int id);
    }
}
