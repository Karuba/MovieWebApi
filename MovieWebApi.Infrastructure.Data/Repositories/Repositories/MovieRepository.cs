using Microsoft.EntityFrameworkCore;
using MovieWebApi.Domain.Core.Entities;
using MovieWebApi.Domain.Interfaces.Repositories;
using MovieWebApi.Domain.Interfaces.RequestFeatures;

namespace MovieWebApi.Infrastructure.Data.Repositories.Repositories
{
    public class MovieRepository : RepositoryBase<Movie>, IMovieRepository
    {
        public MovieRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task<Movie> GetMovieAsync(string id, bool trackChanges = false) =>
            await FindByCondition(opt => opt.Id.Equals(id), trackChanges)
                .Include(c => c.MovieStarrings)
                .ThenInclude(c => c.Starring)
                .SingleOrDefaultAsync();

        public async Task<IEnumerable<Movie>> GetMoviesAsync(MovieParameters movieParameters, bool trackChanges = false) =>
            await FindAll(trackChanges)
            .OrderBy(e => e.Name)
            .Skip(movieParameters.PageSize * (movieParameters.PageNumber - 1))
            .Take(movieParameters.PageSize)
            .Include(c => c.MovieStarrings)
            .ThenInclude(c => c.Starring)
            .ToListAsync();

        public void AddMovie(Movie movie) => Create(movie);

        public void UpdateMovie(Movie movie) => Update(movie);

        public void DeleteMovie(Movie movie) => Delete(movie);

    }
}
