using Microsoft.EntityFrameworkCore;
using SiteLocation.Repository.Interfaces;
using SiteLocationVihecule.Data;
using SiteLocationVihecule.Models.Domain;

namespace SiteLocation.Repository.Repositories
{
    public class ManagerRepository : IManagerRepository
    {
        private readonly ApplicationDbContext _dbcontext;
        public ManagerRepository(ApplicationDbContext dbcontext)
        {
            this._dbcontext = dbcontext;
        }
        public async Task<Manager> CreateAsync(Manager manager)
        {
            await _dbcontext.Managers.AddAsync(manager);
            await _dbcontext.SaveChangesAsync();

            return manager;
        }

        public async Task<Manager?> DeleteAsync(int id)
        {
            var existManager = await _dbcontext.Managers.FirstOrDefaultAsync(x => x.ManagerId == id);
            if (existManager is null)
            {
                return null;
            }
            _dbcontext.Managers.Remove(existManager);
            await _dbcontext.SaveChangesAsync();
            return existManager;
        }

        public async  Task<IEnumerable<Manager>> GetAllAsync()
        {
            return await _dbcontext.Managers.ToListAsync();
        }

        public async  Task<Manager?> GetById(int id)
        {
            return await _dbcontext.Managers.FirstOrDefaultAsync(x => x.ManagerId == id);
        }

        public async Task<Manager?> UpdateAsync(Manager manager)
        {
            var existManager = await _dbcontext.Managers.FirstOrDefaultAsync(x => x.ManagerId == manager.ManagerId);
            if (existManager != null)
            {
                _dbcontext.Entry(existManager).CurrentValues.SetValues(manager);
                await _dbcontext.SaveChangesAsync();
                return manager;
            }
            return null;
        }
    }
}
