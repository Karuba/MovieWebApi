using Microsoft.EntityFrameworkCore;
using MovieWebApi.Domain.Core.Entities;
using MovieWebApi.Domain.Interfaces.Repositories;

namespace MovieWebApi.Infrastructure.Data.Repositories.Repositories
{
    public class UserRatingRepository : RepositoryBase<UserRating>, IUserRatingRepository
    {
        public UserRatingRepository(RepositoryContext repositoryContext) 
            : base(repositoryContext)
        {
        }

        public void AddUserRating(UserRating userRating) => Create(userRating);

        public async Task<double> GetMovieRating(string movieId, bool trackChanges = false)
        {
            var userRating = await FindByCondition(ur => ur.MovieId.Equals(movieId), trackChanges).Select(s => s.Rating).ToListAsync();
            return userRating.Sum()/(double)userRating.Count;
        }

        public async Task<UserRating> GetUserRating(string userId, string movieId, bool trackChanges = false) =>
            await FindByCondition(us => us.UserId.Equals(userId) && us.MovieId.Equals(movieId), trackChanges).FirstOrDefaultAsync();

        public async Task<UserRating> UserRatingExistByUser(string userId, bool trackChanges = false) =>
            await FindByCondition(ur => ur.UserId.Equals(userId), trackChanges).FirstOrDefaultAsync();
    }
}
