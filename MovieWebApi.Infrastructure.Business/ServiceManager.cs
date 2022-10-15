using AutoMapper;
using MovieWebApi.Domain.Interfaces.Repositories;
using MovieWebApi.Infrastructure.Business.Services;
using MovieWebApi.Services.Interfaces;

namespace MovieWebApi.Infrastructure.Business
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IMovieService> _lazyMovieService;
        public ServiceManager(IRepositoryManager repository, IMapper mapper)
        {
            _lazyMovieService = new Lazy<IMovieService>(() => new MovieService(repository, mapper));
        }
        public IMovieService movieService => _lazyMovieService.Value;
    }
}