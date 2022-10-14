using MovieWebApi.Contracts.Dto;
using MovieWebApi.Domain.Core.Entities;
using MovieWebApi.Domain.Interfaces.RequestFeatures;

namespace MovieWebApi.Services.Interfaces
{
    public interface IMovieService
    {
        Task<IEnumerable<MovieDto>> GetMoviesAsync(MovieParameters movieParameters);
        Task<MovieDto> GetMovieAsync(Guid id);
        Task<MovieDto> UpdateMovieAsync(Guid id, MovieUpdateDto movie);
        void DeleteMovie(Movie movie);
        void AddMovie(Movie movie);
    }
}
