using Microsoft.EntityFrameworkCore;
using MovieWebApi.Domain.Core.Entities;
using MovieWebApi.Domain.Interfaces.Repositories;
using MovieWebApi.Domain.Interfaces.RequestFeatures;

namespace MovieWebApi.Infrastructure.Data.Repositories
{
    internal class MovieRepository : RepositoryBase<Movie>, IMovieRepository
    {
        private readonly RepositoryContext _repositoryContext;

        public MovieRepository(RepositoryContext repositoryContext) 
            : base(repositoryContext)
        {
        }

        public async Task<Movie> GetMovieAsync(Guid id, bool trackChanges = false) =>
            await FindByCondition(opt => opt.Id.Equals(id), trackChanges).SingleOrDefaultAsync();

        public async Task<IEnumerable<Movie>> GetMoviesAsync(MovieParameters movieParameters, bool trackChanges = false) =>
            await FindAll(trackChanges)
            .OrderBy(e => e)
            .Skip(movieParameters.PageSize * (movieParameters.PageNumber - 1))
            .Take(movieParameters.PageSize)
            .ToListAsync();
    }
}
