using Microsoft.EntityFrameworkCore;
using PaapuWalks.Data;
using PaapuWalks.Models.Domain;
using PaapuWalks.Models.DTO;

namespace PaapuWalks.Repositories
{
    public class SQLRegionRepository : IRegionRepoistory
    {
        private readonly PaapuWalksDbContext _dbcontext;

        public SQLRegionRepository(PaapuWalksDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<List<Region>> GetAllAsync()
        {
           return await _dbcontext.Regions.ToListAsync();
        }

        public async Task<Region?> GetByIdAsync(Guid id)
        {
            return await _dbcontext.Regions.FindAsync(id);
        }

        public async Task<Region> CreateAsync(Region region)
        {
            await _dbcontext.Regions.AddAsync(region);
            await _dbcontext.SaveChangesAsync();

            return region;
        }

        public async Task<Region?>UpdateAsync(Guid id, Region Newregion)
        {
            var existingregion =  await _dbcontext.Regions.FindAsync(id);

            if (existingregion == null)
            {
                return null;
            }

            existingregion.Name = Newregion.Name;
            existingregion.Code = Newregion.Code;

            await _dbcontext.SaveChangesAsync();

            return existingregion;
        }

        public async Task DeleteAsync(Guid id)
        {
            var RegionDomain = await _dbcontext.Regions.FindAsync(id);

            _dbcontext.Regions.Remove(RegionDomain);
            await _dbcontext.SaveChangesAsync();
        }
    }
}
