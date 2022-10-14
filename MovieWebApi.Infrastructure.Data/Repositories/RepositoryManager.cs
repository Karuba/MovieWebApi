using MovieWebApi.Domain.Interfaces.Repositories;
using MovieWebApi.Infrastructure.Data.Repositories.Repositories;

namespace MovieWebApi.Infrastructure.Data.Repositories
{
    internal class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private IMovieRepository _movieRepository;

        public IMovieRepository Movie
        {
            get
            {
                if (_movieRepository is null)
                    _movieRepository = new MovieRepository(_repositoryContext);
                return _movieRepository;
            }
        }
        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }
        public Task SaveAsync() => _repositoryContext.SaveChangesAsync();
    }
}
