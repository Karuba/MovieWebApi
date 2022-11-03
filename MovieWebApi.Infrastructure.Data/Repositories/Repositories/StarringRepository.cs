using Microsoft.EntityFrameworkCore;
using MovieWebApi.Domain.Core.Entities;
using MovieWebApi.Domain.Interfaces.Repositories;
using MovieWebApi.Domain.Interfaces.RequestFeatures;

namespace MovieWebApi.Infrastructure.Data.Repositories.Repositories
{
    public class StarringRepository : RepositoryBase<Starring>, IStarringRepository
    {
        private readonly RepositoryContext _repositoryContext;

        public StarringRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public async Task<Starring> GetStarringAsync(string id, bool trackChanges = false) =>
            await FindByCondition(opt => opt.Id.Equals(id), trackChanges).FirstOrDefaultAsync();

        public async Task<IEnumerable<Starring>> GetStarringsAsync(string movieId, StarringParameters starringParameters, bool trackChanges = false) =>
            await _repositoryContext.Set<MovieStarring>()
                .Where(ms => ms.MovieId.Equals(movieId))
                .Include(ms => ms.Starring)
                .Select(ms => ms.Starring)
                .OrderBy(s => s.FirstName)
                .Skip(starringParameters.PageSize * (starringParameters.PageNumber - 1))
                .Take(starringParameters.PageSize)
                .ToListAsync();

        public void AddStarring(Starring starring) => Create(starring);

        public void UpdateStarring(Starring starring) => Update(starring);

        public void DeleteStarring(Starring starring) => Delete(starring);

    }
}