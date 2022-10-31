
using MovieWebApi.Domain.Core.Entities;
using MovieWebApi.Domain.Interfaces.RequestFeatures;

namespace MovieWebApi.Domain.Interfaces.Repositories
{
    public interface IStarringRepository
    {
        Task<IEnumerable<Starring>> GetStarringsAsync(Guid movieId, StarringParameters starringParameters, bool trackChanges = false);
        Task<Starring> GetStarringAsync(Guid movieId, bool trackChanges = false);
        void AddStarring(Starring starring);
        void UpdateStarring(Starring starring);
        void DeleteStarring(Starring starring);
    }
}
