
using MovieWebApi.Domain.Core.Entities;

namespace MovieWebApi.Domain.Interfaces.Repositories
{
    public interface IMovieStarringRepository
    {
        void AddMovieStarring(MovieStarring movieStarring);
        void DeleteMovieSstarring(MovieStarring movieStarring);
        Task<MovieStarring> GetMovieStarring(MovieStarring movieStarring, bool trackChanges = false);
        Task<MovieStarring> GetMovieStarring(string starringId, bool trackChanges = false);
    }
}
