using Microsoft.EntityFrameworkCore;
using SiteLocation.Repository.Interfaces;
using SiteLocationVihecule.Data;
using SiteLocationVihecule.Models.Domain;

namespace SiteLocation.Repository.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private readonly ApplicationDbContext _dbcontext;
        public LocationRepository(ApplicationDbContext dbcontext)
        {
            this._dbcontext = dbcontext;
        }
        public async Task<Location> CreateAsync(Location location)
        {
            await _dbcontext.Locations.AddAsync(location);
            await _dbcontext.SaveChangesAsync();

            return location;
        }

        public async Task<Location?> DeleteAsync(int id)
        {
            var existLocation = await _dbcontext.Locations.FirstOrDefaultAsync(x => x.LocationId == id);
            if (existLocation is null)
            {
                return null;
            }
            _dbcontext.Locations.Remove(existLocation);
            await _dbcontext.SaveChangesAsync();
            return existLocation;
        }

        public async Task<IEnumerable<Location>> GetAllAsync()
        {
            return await _dbcontext.Locations.ToListAsync();
        }

        public async Task<Location?> GetById(int id)
        {
            return await _dbcontext.Locations.FirstOrDefaultAsync(x => x.LocationId == id);
        }

        public async Task<Location?> UpdateAsync(Location location)
        {
            var existLocation = await _dbcontext.Locations.FirstOrDefaultAsync(x => x.LocationId == location.LocationId);
            if (existLocation != null)
            {
                _dbcontext.Entry(existLocation).CurrentValues.SetValues(location);
                await _dbcontext.SaveChangesAsync();
                return location;
            }
            return null;
        }
    }
}
