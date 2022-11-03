using MovieWebApi.Domain.Core.Entities;
using MovieWebApi.Domain.Interfaces.RequestFeatures;

namespace MovieWebApi.Domain.Interfaces.Repositories
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>> GetMoviesAsync(MovieParameters movieParameters, bool trackChanges = false);
        Task<Movie> GetMovieAsync(string id, bool trackChanges = false);
        void AddMovie(Movie movie);
        void UpdateMovie(Movie movie);
        void DeleteMovie(Movie movie);
    }
}