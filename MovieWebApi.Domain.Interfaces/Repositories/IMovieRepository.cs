using MovieWebApi.Domain.Core.Entities;
using MovieWebApi.Domain.Interfaces.RequestFeatures;

namespace MovieWebApi.Domain.Interfaces.Repositories
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>> GetMoviesAsync(MovieParameters movieParameters, bool trackChanges = false);
        Task<Movie> GetMovieAsync(Guid id, bool trackChanges = false);
    }
}