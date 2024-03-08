using SiteLocationVihecule.Models.Domain;

namespace SiteLocation.Repository.Interfaces
{
    public interface ILocationRepository
    {
        Task<Location> CreateAsync(Location location);

        Task<IEnumerable<Location>> GetAllAsync();

        Task<Location?> GetById(int id);

        Task<Location?> UpdateAsync(Location location);

        Task<Location?> DeleteAsync(int id);
    }

}

