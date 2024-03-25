using PaapuWalks.Models.Domain;

namespace PaapuWalks.Repositories
{
    public interface IWalkRepository
    {
        Task<Walk> CreateWalkAsync(Walk walk);

        Task<List<Walk>> GetAllWalksAsync();
        Task<Walk> GetByIdAsync(Guid id);

        Task<Walk> UpdateWalkAsync(Guid id,Walk walk);
    }
}
