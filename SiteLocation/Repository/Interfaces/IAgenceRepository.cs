using SiteLocationVihecule.Models.Domain;

namespace SiteLocation.Repository.Interfaces
{
    public interface IAgenceRepository
    {
        Task<Agence> CreateAsync(Agence agence);
        Task<IEnumerable<Agence>> GetAllAsync();

        Task<Agence?> GetById(int id);

        Task<Agence?> UpdateAsync(Agence agence);

        Task<Agence?> DeleteAsync(int id);
    }
}
