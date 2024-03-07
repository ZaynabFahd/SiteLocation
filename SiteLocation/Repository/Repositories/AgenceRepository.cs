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

        public async Task<Agence?> DeleteAsync(int id)
        {
            var existAgence = await _dbcontext.Agences.FirstOrDefaultAsync(x => x.AgenceId == id);
            if (existAgence is null)
            {
                return null;
            }
            _dbcontext.Agences.Remove(existAgence);
            await _dbcontext.SaveChangesAsync();
            return existAgence;
        }

        public async Task<IEnumerable<Agence>> GetAllAsync()
        {
            return await _dbcontext.Agences.ToListAsync();
        }

        public async Task<Agence?> GetById(int id)
        {
            return await _dbcontext.Agences.FirstOrDefaultAsync(x => x.AgenceId == id);
        }

        public async Task<Agence?> UpdateAsync(Agence agence)
        {
            var existAgence = await _dbcontext.Agences.FirstOrDefaultAsync(x => x.AgenceId == agence.AgenceId);
            if (existAgence != null)
            {
                _dbcontext.Entry(existAgence).CurrentValues.SetValues(agence);
                await _dbcontext.SaveChangesAsync();
                return agence;
            }
            return null;
        }
    }
}
