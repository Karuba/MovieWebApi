
namespace MovieWebApi.Domain.Interfaces.Repositories
{
    public interface IRepositoryManager
    {
        IMovieRepository Movie { get; }
        Task SaveAsync();
    }
}
