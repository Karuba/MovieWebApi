
using Microsoft.EntityFrameworkCore;
using MovieWebApi.Domain.Core.Entities;
using MovieWebApi.Domain.Interfaces.Repositories;

namespace MovieWebApi.Infrastructure.Data.Repositories.Repositories
{
    public class MovieStarringRepository : RepositoryBase<MovieStarring>, IMovieStarringRepository
    {
        public MovieStarringRepository(RepositoryContext repositoryContext) 
            : base(repositoryContext)
        {
        }

        public void AddMovieStarring(MovieStarring movieStarring) => Create(movieStarring);

        public void DeleteMovieSstarring(MovieStarring movieStarring) => Delete(movieStarring);

        public async Task<MovieStarring> GetMovieStarring(MovieStarring movieStarring, bool trackChanges = false) =>
            await FindByCondition(ms => ms.StarringId.Equals(movieStarring.StarringId) && ms.MovieId.Equals(movieStarring.MovieId), trackChanges).FirstOrDefaultAsync();
        public async Task<MovieStarring> GetMovieStarring(string starringId, bool trackChanges = false) =>
            await FindByCondition(ms => ms.StarringId.Equals(starringId), trackChanges).FirstOrDefaultAsync();
    }
}
