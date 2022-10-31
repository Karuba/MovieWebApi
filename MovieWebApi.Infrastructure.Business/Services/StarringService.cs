
using AutoMapper;
using MovieWebApi.Contracts.Dto;
using MovieWebApi.Domain.Core.Entities;
using MovieWebApi.Domain.Interfaces.Exceptions;
using MovieWebApi.Domain.Interfaces.Repositories;
using MovieWebApi.Domain.Interfaces.RequestFeatures;
using MovieWebApi.Services.Interfaces;

namespace MovieWebApi.Infrastructure.Business.Services
{
    public class StarringService : IStarringService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        public StarringService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<StarringDto> CreateStarring(Guid movieId, StarringCreateDto starringCreateDto)
        {
            var starring = _mapper.Map<Starring>(starringCreateDto);
            _repository.Starring.AddStarring(starring);
            _repository.movieStarring.AddMovieStarring(new MovieStarring
            {
                MovieId = movieId,
                StarringId = starring.Id,
                Starring = starring
            });
            await _repository.SaveAsync();

            var movieToReturn = _mapper.Map<StarringDto>(starring);

            return movieToReturn;
        }

        public async Task DeleteStarring(Guid id)
        {
            var starring = await _repository.Starring.GetStarringAsync(id);
            if (starring is null)
                throw new NotFoundException($"Starring with id: {id} doesn't exist in the database");

            _repository.Starring.DeleteStarring(starring);
            await _repository.SaveAsync();
        }

        public Task<StarringDto> GetStarringAsync(Guid movieId, Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<StarringDto>> GetStarringsAsync(Guid movieId, StarringParameters starringParameters)
        {

            var starringsDto = _mapper.Map<IEnumerable<StarringDto>>(await _repository.Starring.GetStarringsAsync(movieId, starringParameters));
            return starringsDto;
        }

        public async Task<StarringDto> UpdateStarringAsync(Guid id, StarringUpdateDto starringUpdateDto)
        {
            if (starringUpdateDto is null)
                throw new BadRequestException($"StarringUpdateDto is null");

            var starring = await _repository.Starring.GetStarringAsync(id, trackChanges: true);
            if (starring is null)
                throw new NotFoundException($"Starring with id: {id} doesn't exist in the database");

            _mapper.Map(starringUpdateDto, starring);
            await _repository.SaveAsync();

            return _mapper.Map<StarringDto>(starring);
        }
    }
}
