using Microsoft.EntityFrameworkCore;
using SiteLocation.Repository.Interfaces;
using SiteLocationVihecule.Data;
using SiteLocationVihecule.Models.Domain;

namespace SiteLocation.Repository.Repositories
{
    public class AgenceRepository : IAgenceRepository
    {
        private readonly ApplicationDbContext _dbcontext;
        public AgenceRepository(ApplicationDbContext dbcontext)
        {
            this._dbcontext = dbcontext;
        }
        public async Task<Agence> CreateAsync(Agence agence)
        {
            await _dbcontext.Agences.AddAsync(agence);
            await _dbcontext.SaveChangesAsync();

            return agence;
        }
    }
}
