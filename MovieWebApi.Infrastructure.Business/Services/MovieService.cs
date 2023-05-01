
using AutoMapper;
using MovieWebApi.Contracts.Dto;
using MovieWebApi.Domain.Core.Entities;
using MovieWebApi.Domain.Interfaces.Exceptions;
using MovieWebApi.Domain.Interfaces.Repositories;
using MovieWebApi.Domain.Interfaces.RequestFeatures;
using MovieWebApi.Infrastructure.ML;
using MovieWebApi.Services.Interfaces;
using MovieWebApi.Services.Interfaces.Authentication;

namespace MovieWebApi.Infrastructure.Business.Services
{
    public class MovieService : IMovieService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        private readonly IAuthenticationManager _authentication;
        private readonly IMLRecommendation _recommendation;

        public MovieService(IRepositoryManager repository, IMapper mapper, IAuthenticationManager authentication, IMLRecommendation recommendation)
        {
            _repository = repository;
            _mapper = mapper;
            _authentication = authentication;
            _recommendation = recommendation;
        }

        public async Task<MovieDto> CreateMovie(MovieCreateDto movieData)
        {
            var movie = _mapper.Map<Movie>(movieData);
            _repository.Movie.AddMovie(movie);
            await _repository.SaveAsync();

            var movieToReturn = _mapper.Map<MovieDto>(movie);

            return movieToReturn;
        }

        public async Task DeleteMovie(Guid id)
        {
            var movie = await _repository.Movie.GetMovieAsync(id.ToString());
            if (movie is null)
                throw new NotFoundException($"Movie with id: {id} doesn't exist in the database");

            _repository.Movie.DeleteMovie(movie);
            await _repository.SaveAsync();

            _recommendation.ReBuild();
        }

        public async Task<MovieDto> GetMovieAsync(Guid id)
        {
            var movieDto = _mapper.Map<MovieDto>(await _repository.Movie.GetMovieAsync(id.ToString()));
            return movieDto;
        }

        public async Task<IEnumerable<MovieDto>> GetMoviesAsync(MovieParameters movieParameters)
        {
            var moviesDto = _mapper.Map<IEnumerable<MovieDto>>(await _repository.Movie.GetMoviesAsync(movieParameters));
            return moviesDto;
        }

        public async Task<MovieDto> UpdateMovieAsync(Guid id, MovieUpdateDto movieData)
        {
            if (movieData is null)
                throw new BadRequestException($"MovieUpdateDto is null");

            var movie = await _repository.Movie.GetMovieAsync(id.ToString(), trackChanges: true);
            if (movie is null)
                throw new NotFoundException($"Movie with id: {id} doesn't exist in the database");
            
            _mapper.Map(movieData, movie);
            await _repository.SaveAsync();

            return _mapper.Map<MovieDto>(movie);
        }
        
        public async Task<MovieDto> UpdateMovieRatingAsync(Guid id, UserRatingUpdateDto userRatingUpdate)
        {
            var user = await _authentication.GetUserAsync(userRatingUpdate.UserName);
            if (user is null)
                throw new NotFoundException($"The User is not registered");

            var movie = await _repository.Movie.GetMovieAsync(id.ToString(), trackChanges: true);
            if (movie is null)
                throw new NotFoundException($"Movie with id: {id} doesn't exist in the database");

            var userRating = await _repository.UserRating.GetUserRating(user.Id, id.ToString(), trackChanges: true);

            if (userRating is null)
            {
                userRating = _mapper.Map<UserRating>(userRatingUpdate);
                userRating.UserId = user.Id;
                userRating.MovieId = id.ToString();
                _repository.UserRating.AddUserRating(userRating);
            }
            else
            {
                userRating.Rating = userRatingUpdate.Rating;
            }

            await _repository.SaveAsync();

            var rating = await _repository.UserRating.GetMovieRating(id.ToString());

            movie.Rating = Math.Truncate(rating * 100) / 100;

            await _repository.SaveAsync();

            _recommendation.ReBuild();

            return _mapper.Map<MovieDto>(movie);
        }

        public async Task<MovieDto> AddMovieStarringAsync(Guid id, Guid starringId)
        {
            var starring = await _repository.Starring.GetStarringAsync(starringId.ToString());
            if (starring is null)
                throw new NotFoundException($"Starring with id: {id} doesn't exist in the database");

            var movie = await _repository.Movie.GetMovieAsync(id.ToString());
            if (movie is null)
                throw new NotFoundException($"Movie with id: {id} doesn't exist in the database");

            var movieStarring = await _repository.movieStarring.GetMovieStarring(new MovieStarring
            {
                MovieId = id.ToString(),
                StarringId = starringId.ToString(),
            });

            if (movieStarring is null)
            {
                _repository.movieStarring.AddMovieStarring(new MovieStarring
                {
                    MovieId = id.ToString(),
                    StarringId = starringId.ToString(),
                });
            }

            await _repository.SaveAsync();

            return await GetMovieAsync(id);
        }
        public async Task DeleteMovieStarringAsync(Guid id, Guid starringId)
        {
            var movieStarring = await _repository.movieStarring.GetMovieStarring(new MovieStarring
            {
                MovieId = id.ToString(),
                StarringId = starringId.ToString(),
            });

            if (movieStarring is null)
                throw new NotFoundException($"MovieStarring with id: {id} doesn't exist in the database");

            _repository.movieStarring.DeleteMovieSstarring(movieStarring);
            await _repository.SaveAsync();

            movieStarring = await _repository.movieStarring.GetMovieStarring(starringId.ToString());

            if (movieStarring is null)
            {
                var starring = await _repository.Starring.GetStarringAsync(starringId.ToString());
                _repository.Starring.DeleteStarring(starring);
            }
        }
    }
}
