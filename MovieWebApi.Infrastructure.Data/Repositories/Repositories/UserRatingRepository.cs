using Microsoft.EntityFrameworkCore;
using MovieWebApi.Domain.Core.Entities;
using MovieWebApi.Domain.Interfaces.Repositories;
using MovieWebApi.Domain.Interfaces.RequestFeatures;

namespace MovieWebApi.Infrastructure.Data.Repositories.Repositories
{
    public class UserRatingRepository : RepositoryBase<UserRating>, IUserRatingRepository
    {
        public UserRatingRepository(RepositoryContext repositoryContext) 
            : base(repositoryContext)
        {
        }

        public void AddUserRating(UserRating userRating) => Create(userRating);

        public async Task<double> GetMovieRating(Guid movieId, bool trackChanges = false)
        {
            var userRating = await FindByCondition(ur => ur.MovieId.Equals(movieId), trackChanges).Select(s => s.Rating).ToListAsync();
            return userRating.Sum()/(double)userRating.Count;
        }

        public async Task<UserRating> GetUserRating(string userId, Guid movieId, bool trackChanges = false) =>
            await FindByCondition(us => us.UserId.Equals(userId) && us.MovieId.Equals(movieId), trackChanges).FirstOrDefaultAsync();
    }
}
