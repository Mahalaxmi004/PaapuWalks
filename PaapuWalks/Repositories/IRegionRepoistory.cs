using PaapuWalks.Models.Domain;

namespace PaapuWalks.Repositories
{
    public interface IRegionRepoistory
    {
        Task<List<Region>> GetAllAsync();
        Task<Region?> GetByIdAsync(Guid id);

        Task<Region> CreateAsync(Region region);

        Task<Region?> UpdateAsync(Guid id,Region region);

        Task DeleteAsync(Guid id);


    }
}
