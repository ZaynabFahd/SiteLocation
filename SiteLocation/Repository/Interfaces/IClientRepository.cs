using SiteLocationVihecule.Models.Domain;

namespace SiteLocation.Repository.Interfaces
{
    public interface IClientRepository
    {
        Task<Client> CreateAsync(Client client);
    }
}
