using AutoMapper;
using MovieWebApi.Domain.Core.Entities;
using MovieWebApi.Domain.Interfaces.Repositories;
using MovieWebApi.Infrastructure.Business.Services;
using MovieWebApi.Services.Interfaces;
using MovieWebApi.Services.Interfaces.Authentication;

namespace MovieWebApi.Infrastructure.Business
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IMovieService> _lazyMovieService;
        private readonly Lazy<IStarringService> _lazyStarringService;
        private readonly Lazy<IAuthenticationManager> _lazyAuthenticationManager;
        public ServiceManager(IRepositoryManager repository, IMapper mapper, IAuthenticationManager authentication)
        {
            _lazyMovieService = new Lazy<IMovieService>(() => new MovieService(repository, mapper, authentication));
            _lazyStarringService = new Lazy<IStarringService>(() => new StarringService(repository, mapper));
        }
        public IMovieService movieService => _lazyMovieService.Value;

        public IStarringService starringService => _lazyStarringService.Value;

        public IAuthenticationManager authenticationManager => _lazyAuthenticationManager.Value;
    }
}