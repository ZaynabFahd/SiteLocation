using SiteLocationVihecule.Models.Domain;

namespace SiteLocation.Repository.Interfaces
{
    public interface IManagerRepository
    {
        Task<Manager> CreateAsync(Manager manager);

        Task<IEnumerable<Manager>> GetAllAsync();

        Task<Manager?> GetById(int id);

        Task<Manager?> UpdateAsync(Manager manager);

        Task<Manager?> DeleteAsync(int id);
    }
}

