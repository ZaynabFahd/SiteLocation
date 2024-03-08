using Microsoft.EntityFrameworkCore;
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

        public async Task<Client?> DeleteAsync(int id)
        {
            var existClient = await _dbcontext.Clients.FirstOrDefaultAsync(x => x.ClientId == id);
            if (existClient is null)
            {
                return null;
            }
            _dbcontext.Clients.Remove(existClient);
            await _dbcontext.SaveChangesAsync();
            return existClient;
        }

        public async Task<IEnumerable<Client>> GetAllAsync()
        {
            return await _dbcontext.Clients.ToListAsync();
        }

        public async Task<Client?> GetById(int id)
        {
            return await _dbcontext.Clients.FirstOrDefaultAsync(x => x.ClientId == id);
        }

        public async Task<Client?> UpdateAsync(Client client)
        {
            var existClient = await _dbcontext.Clients.FirstOrDefaultAsync(x => x.ClientId == client.ClientId);
            if (existClient != null)
            {
                _dbcontext.Entry(existClient).CurrentValues.SetValues(client);
                await _dbcontext.SaveChangesAsync();
                return client;
            }
            return null;
        }
    }
}
