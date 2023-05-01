using AutoMapper;
using Microsoft.Extensions.ML;
using MovieWebApi.Domain.Interfaces.Repositories;
using MovieWebApi.Infrastructure.Business.Authentication;
using MovieWebApi.Infrastructure.Business.Services;
using MovieWebApi.Infrastructure.ML;
using MovieWebApi.Infrastructure.ML.DataModels;
using MovieWebApi.Services.Interfaces;
using MovieWebApi.Services.Interfaces.Authentication;

namespace MovieWebApi.Infrastructure.Business
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IMovieService> _lazyMovieService;
        private readonly Lazy<IStarringService> _lazyStarringService;
        private readonly Lazy<IPredictService> _lazyPredictService;
        public ServiceManager(IRepositoryManager repository, IMapper mapper, IAuthenticationManager authentication, IMLRecommendation recommendation, PredictionEnginePool<MovieRating, ModelOutput> predictionEnginePool)
        {
            _lazyMovieService = new Lazy<IMovieService>(() => new MovieService(repository, mapper, authentication, recommendation));
            _lazyStarringService = new Lazy<IStarringService>(() => new StarringService(repository, mapper));
            _lazyPredictService = new Lazy<IPredictService>(() => new PredictService(repository, mapper, predictionEnginePool));
        }
        public IMovieService movieService => _lazyMovieService.Value;

        public IStarringService starringService => _lazyStarringService.Value;

        public IPredictService predictService => _lazyPredictService.Value;
    }
}