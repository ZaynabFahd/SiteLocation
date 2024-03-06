using SiteLocationVihecule.Models.Domain;

namespace SiteLocation.Repository.Interfaces
{
    public interface IManagerRepository
    {
        Task<Manager> CreateAsync(Manager manager);
    }
}
