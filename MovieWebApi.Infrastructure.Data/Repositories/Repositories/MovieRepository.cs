using Microsoft.EntityFrameworkCore;
using MovieWebApi.Domain.Core.Entities;
using MovieWebApi.Domain.Interfaces.Repositories;
using MovieWebApi.Domain.Interfaces.RequestFeatures;

namespace MovieWebApi.Infrastructure.Data.Repositories.Repositories
{
    public class MovieRepository : RepositoryBase<Movie>, IMovieRepository
    {
        private readonly RepositoryContext _repositoryContext;

        public MovieRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
            _repositoryContext = repositoryContext;
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
            .Where(e => e.Name.Contains(movieParameters.MovieName ?? e.Name))
            .Include(c => c.MovieStarrings)
            .ThenInclude(c => c.Starring)
            .ToListAsync();

        public void AddMovie(Movie movie) => Create(movie);

        public void UpdateMovie(Movie movie) => Update(movie);

        public void DeleteMovie(Movie movie) => Delete(movie);

        public async Task<IEnumerable<Movie>> GetMoviesForRecommendationAsync(string userId, bool trackChanges = false) =>
            await FindByCondition(movie => 
                _repositoryContext
                    .Set<UserRating>()
                    .Where(ur => 
                        ur.MovieId.Equals(movie.Id) && !ur.UserId.Equals(userId))
                    .FirstOrDefault() 
            != null
            &&
            _repositoryContext
                    .Set<UserRating>()
                    .Where(ur =>
                        ur.MovieId.Equals(movie.Id) && ur.UserId.Equals(userId))
                    .FirstOrDefault()
            == null
            , trackChanges)
                .ToListAsync();

    }
}
