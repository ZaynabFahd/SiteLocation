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
    }
}
