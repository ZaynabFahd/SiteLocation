using SiteLocation.Repository.Interfaces;
using SiteLocationVihecule.Data;
using SiteLocationVihecule.Models.Domain;

namespace SiteLocation.Repository.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly ApplicationDbContext _dbcontext;
        public ClientRepository(ApplicationDbContext dbcontext)
        {
            this._dbcontext = dbcontext;
        }
        public async Task<Client> CreateAsync(Client client)
        {
            await _dbcontext.Clients.AddAsync(client);
            await _dbcontext.SaveChangesAsync();

            return client;
        }
    }
}
