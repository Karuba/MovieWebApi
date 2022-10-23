
using MovieWebApi.Domain.Core.Entities;

namespace MovieWebApi.Domain.Interfaces.Repositories
{
    public interface IUserRatingRepository
    {
        public Task<double> GetMovieRating(Guid movieId, bool trackChanges = false);
        public Task<UserRating> GetUserRating(string userId, Guid movieId, bool trackChanges = false);
        public void AddUserRating(UserRating userRating);
    }
}
