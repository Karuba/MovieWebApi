
using AutoMapper;
using MovieWebApi.Contracts.Dto;
using MovieWebApi.Domain.Core.Entities;
using MovieWebApi.Domain.Interfaces.Exceptions;
using MovieWebApi.Domain.Interfaces.Repositories;
using MovieWebApi.Domain.Interfaces.RequestFeatures;
using MovieWebApi.Services.Interfaces;
using MovieWebApi.Services.Interfaces.Authentication;

namespace MovieWebApi.Infrastructure.Business.Services
{
    public class MovieService : IMovieService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        private readonly IAuthenticationManager _authentication;

        public MovieService(IRepositoryManager repository, IMapper mapper, IAuthenticationManager authentication)
        {
            _repository = repository;
            _mapper = mapper;
            _authentication = authentication;
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
            var movie = await _repository.Movie.GetMovieAsync(id);
            if (movie is null)
                throw new NotFoundException($"Movie with id: {id} doesn't exist in the database");

            _repository.Movie.DeleteMovie(movie);
            await _repository.SaveAsync();
        }

        public async Task<MovieDto> GetMovieAsync(Guid id)
        {
            var movieDto = _mapper.Map<MovieDto>(await _repository.Movie.GetMovieAsync(id));
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

            var movie = await _repository.Movie.GetMovieAsync(id, trackChanges: true);
            if (movie is null)
                throw new NotFoundException($"Movie with id: {id} doesn't exist in the database");
            
            _mapper.Map(movieData, movie);
            await _repository.SaveAsync();

            return _mapper.Map<MovieDto>(movie);
        }
        
        public async Task<MovieDto> UpdateMovieRatingAsync(Guid id, UserRatingUpdateDto userRatingUpdate)
        {
            var user = await _authentication.GetUserAsync(userRatingUpdate.UserId);
            if (user is null)
                throw new NotFoundException($"The User is not registered");

            var movie = await _repository.Movie.GetMovieAsync(id, trackChanges: true);
            if (movie is null)
                throw new NotFoundException($"Movie with id: {id} doesn't exist in the database");

            var userRating = await _repository.UserRating.GetUserRating(user.Id, id, trackChanges: true);

            if (userRating is null)
            {
                userRating = _mapper.Map<UserRating>(userRatingUpdate);
                userRating.UserId = user.Id;
                userRating.MovieId = id;
                _repository.UserRating.AddUserRating(userRating);
            }
            else
            {
                userRating.Rating = userRatingUpdate.Rating;
            }

            await _repository.SaveAsync();

            var rating = await _repository.UserRating.GetMovieRating(id);

            movie.Rating = rating;

            await _repository.SaveAsync();

            return _mapper.Map<MovieDto>(movie);
        }
    }
}
