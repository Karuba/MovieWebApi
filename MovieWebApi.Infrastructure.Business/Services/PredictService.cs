using AutoMapper;
using Microsoft.Extensions.ML;
using MovieWebApi.Contracts.Dto;
using MovieWebApi.Domain.Core.Entities;
using MovieWebApi.Domain.Interfaces.Exceptions;
using MovieWebApi.Domain.Interfaces.Repositories;
using MovieWebApi.Infrastructure.ML.DataModels;
using MovieWebApi.Services.Interfaces;

namespace MovieWebApi.Infrastructure.Business.Services
{
    public class PredictService : IPredictService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        private readonly PredictionEnginePool<MovieRating, ModelOutput> _predictionEnginePool;

        public PredictService(IRepositoryManager repository, IMapper mapper, PredictionEnginePool<MovieRating, ModelOutput> predictionEnginePool)
        {
            _repository = repository;
            _mapper = mapper;
            _predictionEnginePool = predictionEnginePool;
        }
        public async Task<IEnumerable<MovieDto>> GetUserRecommendation(User user)
        {

            var movies = await GetMoviesForRecommendationAsync(user.Id);

            if (movies.Count() == 0)
                throw new NotFoundException("We don't have enough rating movies for this user!");

            ModelOutput prediction;
            List<MovieRecommendationDto> recMovies= new List<MovieRecommendationDto>();
            foreach (var movie in movies)
            {
                prediction = await Task.FromResult(_predictionEnginePool.Predict(new MovieRating() { MovieId = movie.Id.ToString(), UserId = user.Id, Rating = 0 }));
                var recMovie = _mapper.Map<MovieRecommendationDto>(movie);
                recMovie.Score = prediction.Score;
                recMovies.Add(recMovie);
            }

            return recMovies.OrderByDescending(x => x.Score).Take(10);
        }
        private async Task<IEnumerable<MovieDto>> GetMoviesForRecommendationAsync(string userId)
        {
            var userRating = await _repository.UserRating.UserRatingExistByUser(userId);
            if (userRating is null)
                throw new NotFoundException("The user must have any ratings!");

            var movies = await _repository.Movie.GetMoviesForRecommendationAsync(userId);
            if (movies is null)
                throw new NotFoundException("The movie doesn't have enough ratings");

            return _mapper.Map<IEnumerable<MovieDto>>(movies);
        }
    }
}
