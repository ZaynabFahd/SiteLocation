using SiteLocationVihecule.Models.Domain;

namespace SiteLocation.Repository.Interfaces
{
    public interface IAgenceRepository
    {
        Task<Agence> CreateAsync(Agence agence);
    }
}
