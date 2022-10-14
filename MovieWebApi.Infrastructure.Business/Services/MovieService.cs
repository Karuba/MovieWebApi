
using AutoMapper;
using MovieWebApi.Contracts.Dto;
using MovieWebApi.Domain.Core.Entities;
using MovieWebApi.Domain.Interfaces.Exceptions;
using MovieWebApi.Domain.Interfaces.Repositories;
using MovieWebApi.Domain.Interfaces.RequestFeatures;
using MovieWebApi.Services.Interfaces;

namespace MovieWebApi.Infrastructure.Business.Services
{
    internal class MovieService : IMovieService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        public MovieService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<MovieDto> GetMovieAsync(Guid id)
        {
            var movieDto = _mapper.Map<MovieDto>(await _repository.Movie.GetMovieAsync(id));
            return movieDto;
        }

        public async Task<IEnumerable<MovieDto>> GetMoviesAsync(MovieParameters movieParameters)
        {
            var movies = _mapper.Map<IEnumerable<MovieDto>>(await _repository.Movie.GetMoviesAsync(movieParameters));
            return movies;
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
    }
}
