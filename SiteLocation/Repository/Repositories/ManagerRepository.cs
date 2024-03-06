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
    }
}
