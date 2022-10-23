using MovieWebApi.Contracts.Dto;
using MovieWebApi.Domain.Interfaces.RequestFeatures;

namespace MovieWebApi.Services.Interfaces
{
    public interface IMovieService
    {
        Task<IEnumerable<MovieDto>> GetMoviesAsync(MovieParameters movieParameters);
        Task<MovieDto> GetMovieAsync(Guid id);
        Task<MovieDto> UpdateMovieAsync(Guid id, MovieUpdateDto movie);
        Task DeleteMovie(Guid id);
        Task<MovieDto> CreateMovie(MovieCreateDto movie);
        Task<MovieDto> UpdateMovieRatingAsync(Guid id, UserRatingUpdateDto userRatingUpdate);
    }
}
