using MovieWebApi.Contracts.Dto;
using MovieWebApi.Domain.Interfaces.RequestFeatures;

namespace MovieWebApi.Services.Interfaces
{
    public interface IMovieService
    {
        public Task<IEnumerable<MovieDto>> GetMoviesAsync(MovieParameters movieParameters);
        public Task<MovieDto> GetMovieAsync(Guid id);
        public Task<MovieDto> UpdateMovieAsync(Guid id, MovieUpdateDto movie);
    }
}
