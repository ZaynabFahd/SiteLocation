using SiteLocationVihecule.Models.Domain;

namespace SiteLocation.Repository.Interfaces
{
    public interface ILocationRepository
    {
        Task<Location> CreateAsync(Location location);

    }
}
