
using MovieWebApi.Domain.Core.Entities;
using MovieWebApi.Domain.Interfaces.RequestFeatures;

namespace MovieWebApi.Domain.Interfaces.Repositories
{
    public interface IStarringRepository
    {
        Task<IEnumerable<Starring>> GetStarringsAsync(Guid movieId, StarringParameters starringParameters, bool trackChanges = false);
        Task<Starring> GetStarringAsync(Guid id, bool trackChanges = false);
        void AddStarring(Guid movieId, Starring starring);
        void UpdateStarring(Guid movieId, Starring starring);
        void DeleteStarring(Guid movieId, Starring starring);
    }
}
