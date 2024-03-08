using SiteLocationVihecule.Models.Domain;

namespace SiteLocation.Repository.Interfaces
{
    public interface IClientRepository
    {
        Task<Client> CreateAsync(Client client);
        Task<IEnumerable<Client>> GetAllAsync();

        Task<Client?> GetById(int id);

        Task<Client?> UpdateAsync(Client client);

        Task<Client?> DeleteAsync(int id);
    }
}
