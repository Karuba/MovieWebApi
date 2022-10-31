
namespace MovieWebApi.Domain.Interfaces.Repositories
{
    public interface IRepositoryManager
    {
        IMovieRepository Movie { get; }
        IStarringRepository Starring { get; }
        IUserRatingRepository UserRating { get; }
        IMovieStarringRepository movieStarring { get; }
        Task SaveAsync();
    }
}
