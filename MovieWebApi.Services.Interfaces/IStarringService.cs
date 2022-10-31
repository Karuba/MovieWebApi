using MovieWebApi.Contracts.Dto;
using MovieWebApi.Domain.Interfaces.RequestFeatures;

namespace MovieWebApi.Services.Interfaces
{
    public interface IStarringService
    {
        Task<IEnumerable<StarringDto>> GetStarringsAsync(Guid movieId, StarringParameters starringParameters);
        Task<StarringDto> GetStarringAsync(Guid movieId, Guid id);
        Task<StarringDto> UpdateStarringAsync(Guid id, StarringUpdateDto starringUpdateDto);
        Task DeleteStarring(Guid id);
        Task<StarringDto> CreateStarring(Guid movieId, StarringCreateDto striringCreateDto);
    }
}
