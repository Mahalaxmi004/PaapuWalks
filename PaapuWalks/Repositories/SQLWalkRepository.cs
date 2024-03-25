using Microsoft.EntityFrameworkCore;
using PaapuWalks.Data;
using PaapuWalks.Models.Domain;

namespace PaapuWalks.Repositories
{
    public class SQLWalkRepository : IWalkRepository
    {
        private readonly PaapuWalksDbContext _dbcontext;

        public SQLWalkRepository(PaapuWalksDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<Walk> CreateWalkAsync(Walk walk)
        {
            await _dbcontext.Walks.AddAsync(walk);
            await _dbcontext.SaveChangesAsync();
            return walk;
        }

        public async Task<List<Walk>> GetAllWalksAsync()
        {
            return await _dbcontext.Walks.ToListAsync();

        }

        public async Task<Walk> GetByIdAsync(Guid id)
        {
            return await _dbcontext.Walks.FindAsync(id);
        }

        public async Task<Walk?> UpdateWalkAsync(Guid id, Walk walk)
        {
            var ExistingRegion = await _dbcontext.Walks.FindAsync(id);
            if(ExistingRegion == null)
            {
                return null;
            }

            walk.Name = ExistingRegion.Name;
            walk.Description = ExistingRegion.Description;
            walk.DifficultyId = ExistingRegion.DifficultyId;
            walk.RegionId = ExistingRegion.RegionId;
            walk.LengthInKm = ExistingRegion.LengthInKm;

            await _dbcontext.SaveChangesAsync();

            return walk;
        }
    }
}
